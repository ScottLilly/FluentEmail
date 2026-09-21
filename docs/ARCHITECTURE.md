# Architecture

What exists and why it is built this way. Work that is not built yet lives in
[GitHub Issues](https://github.com/ScottLilly/FluentEmail/issues), not in a document.

## Shape

```
FluentEmail.sln
  FluentEmail/          netstandard2.0    the library, packed as ScottLilly.FluentEmail
  Tests.FluentEmail/    net8.0            MSTest, covers the library
```

One public type per file:

| File | Holds |
|---|---|
| `FluentMailMessage.cs` | The builder |
| `IMustAddFromAddress.cs` | Step 1 of the chain |
| `IMustAddToAddress.cs` | Step 2 |
| `ICanAddToCcBccOrSubject.cs` | Step 3, the only step that can repeat |
| `IMustAddBody.cs` | Step 4 |
| `ICanAddAttachmentOrBuild.cs` | Step 5, and `Build()` |
| `ExtensionMethods.cs` | `internal static Matches`, a string comparison helper |

## Decisions already made

### The method chain is typed, not validated

Each step returns an interface exposing only the calls that are legal next, so an incomplete
`MailMessage` cannot be built. `CreateMailMessage()` and `CreateHtmlMailMessage()` return
`IMustAddFromAddress`; `From()` returns `IMustAddToAddress`; `To()` returns
`ICanAddToCcBccOrSubject`, which is where `To`, `CC` and `BCC` can repeat; `Subject()` returns
`IMustAddBody`; `Body()` returns `ICanAddAttachmentOrBuild`, which is the only place `Build()`
appears.

This is the reason the package exists. `MailMessage` requires a from address and a recipient at
runtime but not at compile time, and the chain moves that failure to compile time.

The cost is that the sequence is fixed by the type system. Making a step optional, or letting two
steps swap order, means changing which interface a method returns, which is a breaking change for
anyone mid-chain.

### The builder implements every interface itself

`FluentMailMessage` implements all five interfaces, and the constructor is private. One class holds
the accumulating `MailMessage`; the interfaces only narrow what is visible at each step.

### Recipients are de-duplicated by address, ignoring case

Every `To`, `CC` and `BCC` overload builds a `MailAddress` and hands it to `AddIfNew`, which
compares `MailAddress.Address` against the addresses already in that collection with
`OrdinalIgnoreCase`. Adding the same recipient twice is a no-op. Comparing the parsed address
rather than the string the caller passed means `qwe@test.com` and `Qwe Test <qwe@test.com>` are
recognized as the same person.

The three collections are otherwise independent: an address in `To` does not stop the same address
being added to `CC`.

### Attachments are de-duplicated by filename, ignoring case

`_attachmentFileNames` is a `HashSet<string>` using `OrdinalIgnoreCase`, and the three
`AddAttachmentIfNew` overloads consult it before attaching. Adding the same file twice is a no-op
rather than an error or a duplicate attachment.

The three `Stream` overloads deliberately do not take part. Skipping a filename costs nothing, but
skipping a stream orphans it: the caller has already opened it, and only an attachment that is
actually added gets disposed when the `MailMessage` is. Two streams may also legitimately share a
name, and `AddAttachment(Stream, ContentType)` has no name to key on at all when `ContentType.Name`
is null.

### netstandard2.0

Widest reach, and the library needs nothing newer. It does mean the library compiles as C# 7.3, so
language features from C# 8 onward are not available to it. That is why block namespaces are kept
and `.editorconfig` holds the file-scoped rule silent.

### The version lives in the csproj

`<Version>` in `FluentEmail/FluentEmail.csproj` is what `release.yml` packs and what it derives the
release tag from, so the tag can never disagree with the package. There is no
`Directory.Build.props` to hold it instead.

## Dependencies

| Package | Why it is here |
|---|---|
| (none) | The library references only `System.Net.Mail` from netstandard2.0 |

Test project only: `MSTest`, `Microsoft.NET.Test.Sdk`, `coverlet.collector`.

## Open questions

- Issue [#22](https://github.com/ScottLilly/FluentEmail/issues/22) proposes adding the ability to
  send email, not just build a `MailMessage`. That changes the package from a builder with no I/O
  into something that talks to an SMTP server, and it is the one open item that would reshape the
  architecture rather than extend it.

## Decided against

Where a settled "no" goes, so the same idea is not proposed again in three months. One line each,
with the reason, because a closed issue is not somewhere anyone looks before proposing a change.

- De-duplicating the `Stream` attachment overloads the way the filename ones are de-duplicated.
  Dropping a stream the caller opened would leak it. See "Attachments are de-duplicated by
  filename, ignoring case" above for the whole reason.
