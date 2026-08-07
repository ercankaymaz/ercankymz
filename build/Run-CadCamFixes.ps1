$ErrorActionPreference = 'Stop'
$patchScript = Join-Path $PSScriptRoot 'Apply-CadCamFixes-v2.ps1'
if (-not (Test-Path $patchScript)) { throw 'Apply-CadCamFixes-v2.ps1 is missing.' }
$text = [IO.File]::ReadAllText($patchScript)
$text = $text.Replace('$name:', '${name}:')
[IO.File]::WriteAllText($patchScript, $text, (New-Object Text.UTF8Encoding($false)))
& $patchScript
