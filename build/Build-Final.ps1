param(
    [string]$Configuration = 'Release',
    [string]$Platform = 'AnyCPU'
)

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$logDir = Join-Path $root 'BUILD_LOGS'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null

# The source package contains decompiler output for many already-working support
# assemblies, including SmartAssembly/dummy_ptr pseudo-source that is not valid
# C# and is not the authoritative source for those binaries. Rebuilding those
# assemblies would replace known-good runtime DLLs with reconstructed artifacts.
# We therefore compile the assembly that contains the CAD/CAM repairs and then
# validate the application shell against that rebuilt DLL. Unchanged support
# DLLs are retained from the validated runtime set and are included in FINAL_DLLS.
$projects = @(
    'buCadCamRes/buCadCamRes.csproj',
    'CMDMarbleCNC/CMDMarbleCNC.csproj'
)

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

    # Make the freshly rebuilt CAD/CAM assembly the one used by the application
    # shell compilation, rather than the old DLL shipped in CMDMarbleCNC/lib.
    if ($relative -eq 'buCadCamRes/buCadCamRes.csproj') {
        $built = Join-Path $root 'buCadCamRes/bin/Release/buCadCamRes.dll'
        $appLib = Join-Path $root 'CMDMarbleCNC/lib/buCadCamRes.dll'
        if (Test-Path $built) {
            Copy-Item $built $appLib -Force
            Write-Host "Injected rebuilt buCadCamRes.dll into CMDMarbleCNC/lib" -ForegroundColor Green
        }
    }
}

if ($failures.Count -gt 0) {
    $failures | Set-Content (Join-Path $logDir 'FAILED_PROJECTS.txt')
    throw "Build failed for $($failures.Count) project(s): $($failures -join ', ')"
}

'ALL TARGET BUILDS PASSED' | Set-Content (Join-Path $logDir 'BUILD_OK.txt')
