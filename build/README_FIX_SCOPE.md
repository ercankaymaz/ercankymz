# CMDMarbleCNC repair scope

This branch validates the complete application source tree and builds the application projects on a Windows .NET Framework/MSBuild runner.

High-confidence logic repairs are applied deterministically before compilation to avoid rewriting large decompiled source files through the GitHub API. The final binaries are compiled from the patched working tree.

Covered areas include Fillet/Chamfer pick direction and composite-curve ownership, Connect entity metadata, mouse-event precedence, rotate osnap refresh, mirror repetition selection, scale divide-by-zero/null handling, and offset empty-result handling.

`RegisterException`, UserMode/AppMode licensing state, dongle checks, `ns8.Class5`, and metadata helper types are not removed or bypassed.

The build logs and final DLL artifact are uploaded by GitHub Actions for every validation run.
