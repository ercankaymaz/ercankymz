$ErrorActionPreference = 'Stop'
$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs'
if (-not (Test-Path $path)) { throw "Missing $path" }
$text = [IO.File]::ReadAllText($path)
$bad = 'FirstDepthStep = num6 + ZOffset;'
$count = ([regex]::Matches($text, [regex]::Escape($bad))).Count
if ($count -eq 0) { Write-Host 'Round17 text-height fix already applied.'; exit 0 }
if ($count -ne 4) { throw "Expected 4 unsafe FirstDepthStep+ZOffset assignments, found $count" }
$text = $text.Replace($bad, 'FirstDepthStep = num6;')
[IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
Write-Host 'Round17 text-height fix applied to 4 wireframe CAM branches.'
