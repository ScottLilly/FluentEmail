# RELEASE NOTES

Each release gets a `## Version x.y.z` heading, spelled exactly that way and matching `<Version>`
in `FluentEmail/FluentEmail.csproj`. The release workflow extracts everything between that heading
and the next one to use as the GitHub release body, so anything written above the first heading is
never published. Newest release first.

## Version 1.1.0

- New package icon, redrawn to the standard colors (#31).
- Copyright metadata now names the rights holder and covers 2022-2026.
- The package ships a `.snupkg` with Source Link, so a consumer can step into this library's source from their own debugger.
- The package tags are separated correctly. Version 1.0.0 published them comma separated, which NuGet packs verbatim, so two of the four tags carried a trailing comma and matched nothing anyone searched for.
- The package links to its release notes on nuget.org, pinned to the tag for this version. Version 1.0.0 published none at all.
