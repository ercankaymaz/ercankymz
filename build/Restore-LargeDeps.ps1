$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot

$items = @(
    @{ Zip = 'build/deps/mwInterop-buMW.zip'; TargetDir = 'buMW/lib'; Expected = 'mwInterop.dll' },
    @{ Zip = 'build/deps/mwInterop-buCadCamRes.zip'; TargetDir = 'buCadCamRes/lib'; Expected = 'mwInterop.dll' }
)

$missing = @()
foreach ($item in $items) {
    $zip = Join-Path $root $item.Zip
    $targetDir = Join-Path $root $item.TargetDir
    if (-not (Test-Path $zip)) {
        Write-Warning "Compressed dependency not present yet: $($item.Zip). Build will continue so compiler diagnostics from all other projects can still be collected."
        $missing += $item.Zip
        continue
    }
    New-Item -ItemType Directory -Force -Path $targetDir | Out-Null
    Expand-Archive -Path $zip -DestinationPath $targetDir -Force
    $dll = Join-Path $targetDir $item.Expected
    if (-not (Test-Path $dll)) {
        throw "Archive $($item.Zip) did not restore $($item.Expected) into $($item.TargetDir)"
    }
    Write-Host "Restored $dll ($((Get-Item $dll).Length) bytes)" -ForegroundColor Green
}

if ($missing.Count -gt 0) {
    New-Item -ItemType Directory -Force -Path (Join-Path $root 'BUILD_LOGS') | Out-Null
    $missing | Set-Content (Join-Path $root 'BUILD_LOGS/MISSING_LARGE_DEPENDENCIES.txt') -Encoding UTF8
}
