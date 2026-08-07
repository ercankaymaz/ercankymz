$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$out = Join-Path $root 'FINAL_DLLS'
if (Test-Path $out) { Remove-Item $out -Recurse -Force }
New-Item -ItemType Directory -Force -Path $out | Out-Null

$manifest = New-Object System.Collections.Generic.List[object]

function Copy-WithManifest([string]$source, [string]$kind, [bool]$overwrite = $true) {
    if (-not (Test-Path $source)) { return }
    $name = [IO.Path]::GetFileName($source)
    $dest = Join-Path $out $name
    if ((Test-Path $dest) -and -not $overwrite) { return }
    Copy-Item $source $dest -Force
    $f = Get-Item $dest
    $hash = (Get-FileHash $dest -Algorithm SHA256).Hash
    $manifest.Add([pscustomobject]@{
        File = $name
        SourceKind = $kind
        Source = $source.Substring($root.Length + 1)
        Size = $f.Length
        SHA256 = $hash
    })
}

# Known-good application runtime set from the supplied source package.
$appLib = Join-Path $root 'CMDMarbleCNC/lib'
if (Test-Path $appLib) {
    Get-ChildItem $appLib -File -Filter *.dll | Sort-Object Name | ForEach-Object {
        Copy-WithManifest $_.FullName 'validated-original-runtime' $false
    }
}

# CAD/CAM has additional indirect dependencies (buFile, buPowerNest,
# ModuleWorks, etc.) not all duplicated in the application lib folder.
$cadLib = Join-Path $root 'buCadCamRes/lib'
if (Test-Path $cadLib) {
    Get-ChildItem $cadLib -File -Filter *.dll | Sort-Object Name | ForEach-Object {
        Copy-WithManifest $_.FullName 'validated-original-cad-dependency' $false
    }
}

# Rebuilt files override their original counterparts.
Copy-WithManifest (Join-Path $root 'buCadCamRes/bin/Release/buCadCamRes.dll') 'rebuilt-cadcam' $true
Copy-WithManifest (Join-Path $root 'CMDMarbleCNC/bin/Release/CMDMarbleCNC.exe') 'rebuilt-application' $true

$manifest | ConvertTo-Json -Depth 4 | Set-Content (Join-Path $out 'manifest.json') -Encoding UTF8
$manifest | Format-Table -AutoSize | Out-String -Width 240 | Set-Content (Join-Path $out 'manifest.txt') -Encoding UTF8

"Final runtime files: $($manifest.Count)" | Set-Content (Join-Path $out 'README.txt') -Encoding UTF8
if (Test-Path (Join-Path $root 'CADCAM_PATCH_REPORT.txt')) {
    Copy-Item (Join-Path $root 'CADCAM_PATCH_REPORT.txt') (Join-Path $out 'CADCAM_PATCH_REPORT.txt') -Force
}
