# FluentEmail

@~/.claude/project-rules/programming.md
@~/.claude/project-rules/csharp.md
@~/.claude/project-rules/nuget.md
@~/.claude/project-rules/github.md

Project-specific guidance for this repo. Rules that apply to more than one project live in the
user-level `CLAUDE.md` and in the imported files above; this file is only for things particular
to FluentEmail.

## Layout

```
FluentEmail.sln
  FluentEmail/          netstandard2.0, the library, packed as ScottLilly.FluentEmail
  Tests.FluentEmail/    net8.0, MSTest, covers the library
docs/                   design notes and architecture
tools/                  scripts and utilities that are not part of the build
.github/workflows/      build-and-test.yml on every push, release.yml run by hand
```

All markdown except this file, `README.md`, `INSTRUCTIONS.md`, `LICENSE.md` and
`RELEASE_NOTES.md` lives in `docs/`. Those four stay at the root: the README and instructions are
linked from the NuGet listing, the license is embedded in the package, and `release.yml` reads
`RELEASE_NOTES.md` from the root.

## Where this project differs from the standard

These are decisions, not oversights. Do not "fix" them without being asked.

- **`.sln`, not `.slnx`.** This project stays on .NET 8. Reading a `.slnx` needs the .NET 9 or 10
  SDK, so converting it would force the CI workflows off the 8.0 SDK they pin. Do not convert it.
- **No `Directory.Build.props`.** The package version lives in `FluentEmail/FluentEmail.csproj`,
  which is where `release.yml` expects to find it. Moving it would break the release tag check.
- **Block namespaces.** The library targets netstandard2.0, which defaults to C# 7.3, so
  file-scoped namespaces are not available to it at all. `.editorconfig` keeps the rule silent.

## Releasing

`release.yml` is triggered by hand from the Actions tab. It reads `<Version>` from
`FluentEmail/FluentEmail.csproj` and refuses to run if a tag for that version already exists, so
bump it there first. Release notes come from the matching `## Version x.y.z` section of
`RELEASE_NOTES.md`, falling back to GitHub's generated notes when there is no such section.

## Writing documents in docs/

- **Be terse.** Long documents do not get read. Cut preamble and restatement.
- **Do not speculate past what I told you.** Do not turn three sentences into three pages of
  inferred rationale or decisions I never made.
- **Mark inference as inference.** Tag it `*(inference)*` so my intent is distinguishable from
  your reading of it.
- A short list beats prose. One concrete example beats a general explanation.
- If a document has grown unwieldy, say so and offer to consolidate rather than adding to it.
- No em dashes, no en dashes, no smart quotes.

## Settled work leaves no trace

This project has no backlog document. Unbuilt work is a GitHub issue, and an idea worth keeping is
raised as one rather than written into a file.

When something is **built**, it gets no write-up anywhere. No superseded sections, no struck-through
questions, no "amended on such a date" banners. The documents describe the project as it is now.
Git holds the history.

When something is **decided against**, it gets one brief line under `## Decided against` in
[docs/ARCHITECTURE.md](docs/ARCHITECTURE.md) saying why, so it does not get re-proposed. A GitHub
issue that is dropped is closed as not planned and taken off its milestone, so it does not count as
that milestone's work.
