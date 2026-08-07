param(
    [string]$Configuration = 'Release',
    [string]$Platform = 'AnyCPU'
)

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$logDir = Join-Path $root 'BUILD_LOGS'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null

# Rebuild only the source-compatible support chain required by buCadCamRes.
# Other supplied DLLs remain the known-good runtime binaries; their decompiled
# SmartAssembly/dummy_ptr pseudo-sources are audited but are not substituted for
# working binaries unless a source change is actually required.
$projects = @(
    'buClass/buClass.csproj',
    'buCore/buCore.csproj',
    'buControls/buControls.csproj',
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

# The 65 MB buEyeBase binary bundled with the Marble/MW source set corresponds
# to the recovered source generation and exposes the CAM enums/classes used by
# buCadCamRes. The smaller legacy copy in buCadCamRes/lib does not.
Copy-IfExists 'buMarble/lib/buEyeBase.dll' @(
    'buCadCamRes/lib/buEyeBase.dll',
    'CMDMarbleCNC/lib/buEyeBase.dll'
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

    switch ($relative) {
        'buClass/buClass.csproj' {
            Copy-IfExists 'buClass/bin/Release/buClass.dll' @(
                'buCore/lib/buClass.dll','buControls/lib/buClass.dll',
                'buCadCamRes/lib/buClass.dll','CMDMarbleCNC/lib/buClass.dll'
            )
        }
        'buCore/buCore.csproj' {
            Copy-IfExists 'buCore/bin/Release/buCore.dll' @(
                'buControls/lib/buCore.dll','buCadCamRes/lib/buCore.dll',
                'CMDMarbleCNC/lib/buCore.dll'
            )
        }
        'buControls/buControls.csproj' {
            Copy-IfExists 'buControls/bin/Release/buControls.dll' @(
                'buCadCamRes/lib/buControls.dll','CMDMarbleCNC/lib/buControls.dll'
            )
        }
        'buCadCamRes/buCadCamRes.csproj' {
            Copy-IfExists 'buCadCamRes/bin/Release/buCadCamRes.dll' @(
                'CMDMarbleCNC/lib/buCadCamRes.dll'
            )
        }
    }
}

if ($failures.Count -gt 0) {
    $failures | Set-Content (Join-Path $logDir 'FAILED_PROJECTS.txt')
    throw "Build failed for $($failures.Count) project(s): $($failures -join ', ')"
}

'ALL CAD SUPPORT AND CADCAM BUILDS PASSED' | Set-Content (Join-Path $logDir 'BUILD_OK.txt')
