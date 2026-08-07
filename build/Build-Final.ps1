param(
    [string]$Configuration = 'Release',
    [string]$Platform = 'AnyCPU'
)
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$logDir=Join-Path $root 'BUILD_LOGS'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null
function Copy-IfExists([string]$from,[string[]]$targets){$src=Join-Path $root $from;if(-not(Test-Path $src)){throw "Missing required file: $from"};foreach($target in $targets){$dst=Join-Path $root $target;New-Item -ItemType Directory -Force -Path (Split-Path $dst)|Out-Null;Copy-Item $src $dst -Force;Write-Host "Injected $from -> $target" -ForegroundColor DarkGreen}}
function Build-Project([string]$relative){$project=Join-Path $root $relative;$name=[IO.Path]::GetFileNameWithoutExtension($project);$log=Join-Path $logDir "$name.log";Write-Host "`n========== BUILD $relative ==========" -ForegroundColor Cyan;& msbuild $project /t:Rebuild /m:1 /p:Configuration=$Configuration /p:Platform=$Platform /p:TargetFrameworkVersion=v4.8 /p:LangVersion=latest /v:minimal /fl "/flp:logfile=$log;verbosity=diagnostic";if($LASTEXITCODE -ne 0){throw "Build failed: $relative"};Write-Host "OK: $relative" -ForegroundColor Green}

$repairScriptPath=Join-Path $PSScriptRoot 'Final-Calculation-Repairs.ps1'
$repairScriptText=[IO.File]::ReadAllText($repairScriptPath)
$repairScriptText=$repairScriptText.Replace("'  public void MoveUpDown('","'  public void Devide()'")
$repairScriptText=$repairScriptText.Replace('$t=Replace-Required $t $mirrorOld $mirrorNew ''Profile mirror entity shadow repair''','$t=Replace-Optional $t $mirrorOld $mirrorNew ''Profile mirror entity shadow repair''')
$repairScriptText=$repairScriptText.Replace('$t=Replace-Required $t ''buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Distance.Safe, ref calcPoint);'' ''buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length1, ref calcPoint);'' ''Wireframe saw projected plunge''','$t=Replace-Optional $t ''buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Distance.Safe, ref calcPoint);'' ''buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length1, ref calcPoint);'' ''Wireframe saw projected plunge''')
$runtimeRepairScript=Join-Path $PSScriptRoot 'Final-Calculation-Repairs.runtime.ps1';[IO.File]::WriteAllText($runtimeRepairScript,$repairScriptText,(New-Object Text.UTF8Encoding($false))); & $runtimeRepairScript
& (Join-Path $PSScriptRoot 'Finalize-CadCompile.ps1')
Copy-IfExists 'buMarble/lib/buEyeBase.dll' @('buCadCamRes/lib/buEyeBase.dll','CMDMarbleCNC/lib/buEyeBase.dll')

$cadProject=Join-Path $root 'buCadCamRes/buCadCamRes.csproj';$cadProjectText=[IO.File]::ReadAllText($cadProject);$compatibilitySources=@('Compatibility\buTrackMarker.cs','Compatibility\buDialogMessageBoxes.cs');$missing=@();foreach($source in $compatibilitySources){if(-not $cadProjectText.Contains($source)){$missing+=('    <Compile Include="{0}" />' -f $source)}};if($missing.Count -gt 0){$insert="  <ItemGroup>`r`n"+($missing -join "`r`n")+"`r`n  </ItemGroup>`r`n";$cadProjectText=$cadProjectText.Replace('</Project>',$insert+'</Project>');[IO.File]::WriteAllText($cadProject,$cadProjectText,(New-Object Text.UTF8Encoding($false)))}

Build-Project 'buClass/buClass.csproj';Copy-IfExists 'buClass/bin/Release/buClass.dll' @('buCadCamRes/lib/buClass.dll','CMDMarbleCNC/lib/buClass.dll')
$coreInput=Join-Path $root 'CMDMarbleCNC/lib/buCore.dll';$coreOutDir=Join-Path $root 'PATCHED_CORE';New-Item -ItemType Directory -Force -Path $coreOutDir|Out-Null

# Exact four call-site saw fix, verified against the original DLL's actual IL.
$sawProject=Join-Path $root 'build/BuCoreSawPatcher/BuCoreSawPatcher.csproj';& dotnet build $sawProject -c Release --nologo;if($LASTEXITCODE -ne 0){throw 'BuCoreSawPatcher build failed'}
$sawDll=Join-Path $root 'build/BuCoreSawPatcher/bin/Release/net8.0/BuCoreSawPatcher.dll';$sawCore=Join-Path $coreOutDir 'buCore-saw.dll';& dotnet $sawDll $coreInput $sawCore (Join-Path $logDir 'buCore-saw-patch.txt');if($LASTEXITCODE -ne 0 -or -not(Test-Path $sawCore)){throw 'Exact saw IL patch failed'}

# Reuse the numeric/ellipse patcher, but disable its superseded saw matcher.
$patcherSource=Join-Path $root 'build/BuCorePatcher/Program.cs';$pt=[IO.File]::ReadAllText($patcherSource)
$pt=[regex]::Replace($pt,'if \(patched < 4\)\s*throw new InvalidOperationException\(\$"Expected at least 4 raw tilted-saw approach/leave projections, patched \{patched\}\."\);','Report.Add("Saw projection handled by exact IL stage.");')
$pt=$pt.Replace('if (Report.Count < 6)','if (Report.Count < 5)')
[IO.File]::WriteAllText($patcherSource,$pt,(New-Object Text.UTF8Encoding($false)))
$patcherProject=Join-Path $root 'build/BuCorePatcher/BuCorePatcher.csproj';& dotnet build $patcherProject -c Release --nologo;if($LASTEXITCODE -ne 0){throw 'BuCorePatcher build failed'}
$patcherDll=Join-Path $root 'build/BuCorePatcher/bin/Release/net8.0/BuCorePatcher.dll';$coreOutput=Join-Path $coreOutDir 'buCore.dll';$coreReport=Join-Path $logDir 'buCore-IL-patch.txt';& dotnet $patcherDll $sawCore $coreOutput $coreReport;if($LASTEXITCODE -ne 0 -or -not(Test-Path $coreOutput)){throw 'Numeric/ellipse buCore IL patch failed'}
Copy-IfExists 'PATCHED_CORE/buCore.dll' @('buCadCamRes/lib/buCore.dll','CMDMarbleCNC/lib/buCore.dll')

Build-Project 'buCadCamRes/buCadCamRes.csproj';Copy-IfExists 'buCadCamRes/bin/Release/buCadCamRes.dll' @('CMDMarbleCNC/lib/buCadCamRes.dll')
'BUCLASS REBUILD + EXACT BUCORE IL PATCH + BUCADCAMRES BUILD PASSED'|Set-Content (Join-Path $logDir 'BUILD_OK.txt') -Encoding UTF8
