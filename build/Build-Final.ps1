param(
    [string]$Configuration = 'Release',
    [string]$Platform = 'AnyCPU'
)

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$logDir = Join-Path $root 'BUILD_LOGS'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null

$projects = @(
    'CmdLangAPI/CmdLangAPI.csproj',
    'buCore/buCore.csproj',
    'buFile/buFile.csproj',
    'buClass/buClass.csproj',
    'buComm/buComm.csproj',
    'buPowerNest/buPowerNest.csproj',
    'buOpcDlls/buOpcDlls.csproj',
    'buOpcUA/buOpcUA.csproj',
    'buMotion/buMotion.csproj',
    'buEyeBase/buEyeBase.csproj',
    'buMW/buMW.csproj',
    'buControls/buControls.csproj',
    'buMarble/buMarble.csproj',
    'buCadCamRes/buCadCamRes.csproj',
    'CMDMarbleCNC/CMDMarbleCNC.csproj'
)

$failures = @()
foreach ($relative in $projects) {
    $project = Join-Path $root $relative
    if (-not (Test-Path $project)) {
        Write-Warning "Project missing: $relative"
        $failures += "MISSING: $relative"
        continue
    }

    $name = [IO.Path]::GetFileNameWithoutExtension($project)
    $log = Join-Path $logDir "$name.log"
    Write-Host "`n========== BUILD $relative ==========" -ForegroundColor Cyan

    # Do not force Prefer32Bit on DLL projects: Roslyn maps that to
    # /platform:anycpu32bitpreferred, which is invalid for /target:library.
    # All recovered projects are built with their declared AnyCPU configuration;
    # the Windows x64 MSBuild host is used so x64 design-time/resource dependencies
    # (notably ImageProcessor.dll) can be loaded while processing .resx files.
    & msbuild $project /t:Rebuild /m:1 `
        /p:Configuration=$Configuration `
        /p:Platform=$Platform `
        /p:TargetFrameworkVersion=v4.8 `
        /p:LangVersion=latest `
        /v:minimal /fl "/flp:logfile=$log;verbosity=diagnostic"

    if ($LASTEXITCODE -ne 0) {
        $failures += $relative
        Write-Host "FAILED: $relative" -ForegroundColor Red
    } else {
        Write-Host "OK: $relative" -ForegroundColor Green
    }
}

if ($failures.Count -gt 0) {
    $failures | Set-Content (Join-Path $logDir 'FAILED_PROJECTS.txt')
    throw "Build failed for $($failures.Count) project(s): $($failures -join ', ')"
}

'ALL BUILDS PASSED' | Set-Content (Join-Path $logDir 'BUILD_OK.txt')
