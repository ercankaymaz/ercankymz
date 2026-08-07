param(
    [string]$Configuration = 'Release',
    [string]$Platform = 'AnyCPU'
)

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$logDir = Join-Path $root 'BUILD_LOGS'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null

# buClass contains the recovered CAM enums/data types required by buCadCamRes and
# compiles cleanly after targeted decompiler repairs. buCore and buControls remain
# the validated original runtime DLLs. Newer UI surface referenced only by the
# recovered CAD/CAM source is supplied by small source-compatible controls that are
# compiled into buCadCamRes instead of replacing the working buControls binary.
$projects = @(
    'buClass/buClass.csproj',
    'buCadCamRes/buCadCamRes.csproj'
)

function Copy-IfExists([string]$from, [string[]]$targets) {
    $src = Join-Path $root $from
    if (-not (Test-Path $src)) { return }
    foreach ($target in $targets) {
        $dst = Join-Path $root $target
        New-Item -ItemType Directory -Force -Path (Split-Path $dst) | Out-Null
        Copy-Item $src $dst -Force
        Write-Host "Injected $from -> $target" -ForegroundColor DarkGreen
    }
}

Copy-IfExists 'buMarble/lib/buEyeBase.dll' @(
    'buCadCamRes/lib/buEyeBase.dll',
    'CMDMarbleCNC/lib/buEyeBase.dll'
)

# Add compatibility sources to this old-style csproj only in the CI working tree.
$cadProject = Join-Path $root 'buCadCamRes/buCadCamRes.csproj'
$cadProjectText = [IO.File]::ReadAllText($cadProject)
$compatibilitySources = @(
    'Compatibility\buTrackMarker.cs',
    'Compatibility\buDialogMessageBoxes.cs'
)
$missingEntries = @()
foreach ($source in $compatibilitySources) {
    if (-not $cadProjectText.Contains($source)) {
        $missingEntries += "    <Compile Include=\"$source\" />"
    }
}
if ($missingEntries.Count -gt 0) {
    $insert = "  <ItemGroup>`r`n" + ($missingEntries -join "`r`n") + "`r`n  </ItemGroup>`r`n"
    $cadProjectText = $cadProjectText.Replace('</Project>', $insert + '</Project>')
    [IO.File]::WriteAllText($cadProject, $cadProjectText, (New-Object Text.UTF8Encoding($false)))
    Write-Host "Added compatibility sources: $($compatibilitySources -join ', ')" -ForegroundColor Green
}

$failures = @()
foreach ($relative in $projects) {
    $project = Join-Path $root $relative
    if (-not (Test-Path $project)) {
        $failures += "MISSING: $relative"
        continue
    }

    $name = [IO.Path]::GetFileNameWithoutExtension($project)
    $log = Join-Path $logDir "$name.log"
    Write-Host "`n========== BUILD $relative ==========" -ForegroundColor Cyan

    & msbuild $project /t:Rebuild /m:1 `
        /p:Configuration=$Configuration `
        /p:Platform=$Platform `
        /p:TargetFrameworkVersion=v4.8 `
        /p:LangVersion=latest `
        /v:minimal /fl "/flp:logfile=$log;verbosity=diagnostic"

    if ($LASTEXITCODE -ne 0) {
        $failures += $relative
        Write-Host "FAILED: $relative" -ForegroundColor Red
        continue
    }

    Write-Host "OK: $relative" -ForegroundColor Green

    if ($relative -eq 'buClass/buClass.csproj') {
        Copy-IfExists 'buClass/bin/Release/buClass.dll' @(
            'buCadCamRes/lib/buClass.dll',
            'CMDMarbleCNC/lib/buClass.dll'
        )
    }
    elseif ($relative -eq 'buCadCamRes/buCadCamRes.csproj') {
        Copy-IfExists 'buCadCamRes/bin/Release/buCadCamRes.dll' @(
            'CMDMarbleCNC/lib/buCadCamRes.dll'
        )
    }
}

if ($failures.Count -gt 0) {
    $failures | Set-Content (Join-Path $logDir 'FAILED_PROJECTS.txt')
    throw "Build failed for $($failures.Count) project(s): $($failures -join ', ')"
}

'BUCLASS AND BUCADCAMRES BUILDS PASSED' | Set-Content (Join-Path $logDir 'BUILD_OK.txt')
