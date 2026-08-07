$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot

$items = @(
    @{ Zip = 'build/deps/mwInterop-buMW.zip'; TargetDir = 'buMW/lib'; Expected = 'mwInterop.dll' },
    @{ Zip = 'build/deps/mwInterop-buCadCamRes.zip'; TargetDir = 'buCadCamRes/lib'; Expected = 'mwInterop.dll' }
)

foreach ($item in $items) {
    $zip = Join-Path $root $item.Zip
    $targetDir = Join-Path $root $item.TargetDir
    if (-not (Test-Path $zip)) {
        throw "Required compressed dependency is missing: $($item.Zip)"
    }
    New-Item -ItemType Directory -Force -Path $targetDir | Out-Null
    Expand-Archive -Path $zip -DestinationPath $targetDir -Force
    $dll = Join-Path $targetDir $item.Expected
    if (-not (Test-Path $dll)) {
        throw "Archive $($item.Zip) did not restore $($item.Expected) into $($item.TargetDir)"
    }
    Write-Host "Restored $dll ($((Get-Item $dll).Length) bytes)" -ForegroundColor Green
}
