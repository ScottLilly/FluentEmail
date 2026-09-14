# tools

Scripts and utilities that are not part of the build and do not ship.

Nothing lives here yet. When something does, add a line to this file saying what it is and how to
run it, and add a `<File>` entry for it to the `tools` solution folder in `FluentEmail.sln` so it
is reachable from Solution Explorer.

Anything in here that is a C# project is listed in the solution as a file, never as a project, so
`dotnet build` at the root does not build it.
