# RELEASE NOTES

Each release gets a `## Version x.y.z` heading, spelled exactly that way and matching `<Version>`
in `FluentEmail/FluentEmail.csproj`. The release workflow extracts everything between that heading
and the next one to use as the GitHub release body, so anything written above the first heading is
never published. Newest release first.

## Version 1.1.0

- `ReplyTo()` sets the reply-to addresses. It sits beside `To()`, `CC()` and `BCC()`, takes the same six overloads, and de-duplicates the same way (#11).
- `Body()` takes a `TransferEncoding`, on its own or alongside a body `Encoding` (#7).
- `AddAlternateView()` and `AddAlternateViews()` add a second rendering of the body, such as HTML beside plain text (#9).
- `AddHeader()` and `AddHeaders()` add custom headers. A name used twice keeps both values (#10).
- `DeliveryNotificationOptions()` sets the delivery receipts to ask the mail server for (#8).
- New package icon, redrawn to the standard colors (#31).
- Copyright metadata now names the rights holder and covers 2022-2026.
- The package ships a `.snupkg` with Source Link, so a consumer can step into this library's source from their own debugger.
- The package tags are separated correctly. Version 1.0.0 published them comma separated, which NuGet packs verbatim, so two of the four tags carried a trailing comma and matched nothing anyone searched for.
- The package links to its release notes on nuget.org, pinned to the tag for this version. Version 1.0.0 published none at all.
