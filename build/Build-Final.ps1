param(
    [string]$Configuration = 'Release',
    [string]$Platform = 'AnyCPU'
)

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$logDir = Join-Path $root 'BUILD_LOGS'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null

# buClass contains the recovered CAM enums/data types required by buCadCamRes and
# now compiles cleanly after the targeted decompiler repairs. buCore and buControls
# are intentionally kept as the validated original runtime DLLs: their recovered
# trees contain unrelated SmartAssembly/compiler-generated pseudo-source, while
# buCadCamRes compiles against the originals once buClass is rebuilt. The single
# newer control needed by Profile simulation is supplied by the local compatibility
# source in buCadCamRes/Compatibility/buTrackMarker.cs.
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

# Use the source-generation-compatible Eyeshot support binary shipped with Marble.
Copy-IfExists 'buMarble/lib/buEyeBase.dll' @(
    'buCadCamRes/lib/buEyeBase.dll',
    'CMDMarbleCNC/lib/buEyeBase.dll'
)

# Include the local profile-simulation compatibility control without modifying the
# validated buControls runtime DLL.
$cadProject = Join-Path $root 'buCadCamRes/buCadCamRes.csproj'
$cadProjectText = [IO.File]::ReadAllText($cadProject)
$compileEntry = '    <Compile Include="Compatibility\buTrackMarker.cs" />'
if (-not $cadProjectText.Contains('Compatibility\buTrackMarker.cs')) {
    $insert = "  <ItemGroup>`r`n$compileEntry`r`n  </ItemGroup>`r`n"
    $cadProjectText = $cadProjectText.Replace('</Project>', $insert + '</Project>')
    [IO.File]::WriteAllText($cadProject, $cadProjectText, (New-Object Text.UTF8Encoding($false)))
    Write-Host 'Added Compatibility\buTrackMarker.cs to buCadCamRes.csproj' -ForegroundColor Green
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
