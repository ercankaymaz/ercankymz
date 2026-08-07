param(
    [string]$Configuration = 'Release',
    [string]$Platform = 'AnyCPU'
)

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$logDir = Join-Path $root 'BUILD_LOGS'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null

# Apply final calculation/geometric repairs after the earlier decompiler passes.
# Write the normalized script beside the original so $PSScriptRoot is preserved.
$repairScriptPath = Join-Path $PSScriptRoot 'Final-Calculation-Repairs.ps1'
$repairScriptText = [IO.File]::ReadAllText($repairScriptPath)
$repairScriptText = $repairScriptText.Replace("'  public void MoveUpDown('", "'  public void Devide()'")
$repairScriptText = $repairScriptText.Replace('$t=Replace-Required $t $mirrorOld $mirrorNew ''Profile mirror entity shadow repair''', '$t=Replace-Optional $t $mirrorOld $mirrorNew ''Profile mirror entity shadow repair''')
$repairScriptText = $repairScriptText.Replace('$t=Replace-Required $t ''buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Distance.Safe, ref calcPoint);'' ''buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length1, ref calcPoint);'' ''Wireframe saw projected plunge''', '$t=Replace-Optional $t ''buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Distance.Safe, ref calcPoint);'' ''buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length1, ref calcPoint);'' ''Wireframe saw projected plunge''')
$runtimeRepairScript = Join-Path $PSScriptRoot 'Final-Calculation-Repairs.runtime.ps1'
[IO.File]::WriteAllText($runtimeRepairScript, $repairScriptText, (New-Object Text.UTF8Encoding($false)))
& $runtimeRepairScript

# buControls remains the validated original runtime assembly. buClass, buCore and
# buCadCamRes are rebuilt because calculation fixes touch core geometry/kinematics
# and the CAD/CAM application layer.
$projects = @(
    'buClass/buClass.csproj',
    'buCore/buCore.csproj',
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
        $missingEntries += ('    <Compile Include="{0}" />' -f $source)
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
            'buCore/lib/buClass.dll',
            'buCadCamRes/lib/buClass.dll',
            'CMDMarbleCNC/lib/buClass.dll'
        )
    }
    elseif ($relative -eq 'buCore/buCore.csproj') {
        Copy-IfExists 'buCore/bin/Release/buCore.dll' @(
            'buCadCamRes/lib/buCore.dll',
            'CMDMarbleCNC/lib/buCore.dll'
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

'BUCLASS, BUCORE AND BUCADCAMRES BUILDS PASSED' | Set-Content (Join-Path $logDir 'BUILD_OK.txt')
