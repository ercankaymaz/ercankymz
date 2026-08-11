$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/five-axis-professional-guards.txt'
Remove-Item $log -ErrorAction Ignore

$sourcePath = 'Decompiled/buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs'
$validatorPath = 'Decompiled/buCadCamRes/buCadCamResVer5/Marble/FiveAxisPathSafety.cs'
$toolFormPath = 'Decompiled/buCadCamRes/buCadCamResVer5/Forms/F_Tool.cs'
$filesPath = 'Decompiled/buCadCamRes/buCadCamResVer5/clsFiles.cs'

if (-not (Test-Path -LiteralPath $sourcePath -PathType Leaf)) {
    "FAIL missing 5-axis marble source: $sourcePath" | Tee-Object $log
    exit 2
}
if ((Get-Item -LiteralPath $sourcePath).Length -eq 0) {
    "FAIL empty 5-axis marble source: $sourcePath" | Tee-Object $log
    exit 2
}
if (-not (Test-Path -LiteralPath $validatorPath -PathType Leaf)) {
    "FAIL missing final path validator: $validatorPath" | Tee-Object $log
    exit 2
}
if (-not (Test-Path -LiteralPath $toolFormPath -PathType Leaf)) {
    "FAIL missing XYZ/ABC limits UI: $toolFormPath" | Tee-Object $log
    exit 2
}
if (-not (Test-Path -LiteralPath $filesPath -PathType Leaf)) {
    "FAIL missing machine-profile startup loader: $filesPath" | Tee-Object $log
    exit 2
}

$text = [IO.File]::ReadAllText($sourcePath)
$original = $text
$methodPattern = '(?s)public int doEngrave5DCamCalc\s*\(.*?(?=\r?\n\s*public void doAddItemSawMilling\s*\()'
$methodMatch = [regex]::Match($text, $methodPattern)
if (-not $methodMatch.Success) {
    "FAIL doEngrave5DCamCalc method was not found" | Tee-Object $log
    exit 3
}
$method = $methodMatch.Value

function Replace-RequiredLiteral {
    param(
        [string]$Value,
        [string]$OldValue,
        [string]$NewValue,
        [string]$Label
    )

    if ($Value.Contains($NewValue)) {
        "OK already repaired: $Label" | Tee-Object -Append $log | Out-Null
        return $Value
    }
    if (-not $Value.Contains($OldValue)) {
        throw "Required 5-axis repair anchor not found: $Label"
    }
    "FIX $Label" | Tee-Object -Append $log | Out-Null
    return $Value.Replace($OldValue, $NewValue)
}

# Five-axis link moves must use the operation's configured clearance rather than zero.
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamMeshParalel5AXPars.MachParam.LinkParams.AirMoveSafetyDistance = 0.0;' `
    'clsMW.varMWCamMeshParalel5AXPars.MachParam.LinkParams.AirMoveSafetyDistance = Math.Max(marbleCam.setCam.Distances.Safe, marbleCam.setCam.Distances.Rapid);' `
    '5AX parallel clearance distance'
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamMeshContantZ5AXPars.MachParam.LinkParams.AirMoveSafetyDistance = 0.0;' `
    'clsMW.varMWCamMeshContantZ5AXPars.MachParam.LinkParams.AirMoveSafetyDistance = Math.Max(marbleCam.setCam.Distances.Safe, marbleCam.setCam.Distances.Rapid);' `
    '5AX constant-Z clearance distance'
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamGeodesicPars.MachParam.LinkParams.AirMoveSafetyDistance = 0.0;' `
    'clsMW.varMWCamGeodesicPars.MachParam.LinkParams.AirMoveSafetyDistance = Math.Max(marbleCam.setCam.Distances.Safe, marbleCam.setCam.Distances.Rapid);' `
    '5AX geodesic clearance distance'

$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamMeshParalel5AXPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;' `
    'clsMW.varMWCamMeshParalel5AXPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = true;' `
    '5AX parallel clearance enforcement'
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamMeshContantZ5AXPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;' `
    'clsMW.varMWCamMeshContantZ5AXPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = true;' `
    '5AX constant-Z clearance enforcement'
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamGeodesicPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;' `
    'clsMW.varMWCamGeodesicPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = true;' `
    '5AX geodesic clearance enforcement'

# The recovered method selected CamTriMesh5AXType but read the 3-axis field later.
$method = Replace-RequiredLiteral $method `
    'MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts' `
    'MWCalcoptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ParallelCuts' `
    '5AX parallel strategy result selector'
$method = Replace-RequiredLiteral $method `
    'MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ' `
    'MWCalcoptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ConstantZ' `
    '5AX constant-Z strategy result selector'
$method = Replace-RequiredLiteral $method `
    'MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Geodesic' `
    'MWCalcoptions.CamTriMesh5AXType == CamTriangularMesh5AxType.Geodesic' `
    '5AX geodesic strategy result selector'

# Remove the decompiler-produced duplicate ModuleWorks error-dialog block.
$resultErrorPattern = '(?s)if\s*\(\(Result\s*==\s*null\s*\?\s*0\s*:\s*\(Result\.Errors\.Count\s*>\s*0\s*\?\s*1\s*:\s*0\)\)\s*!=\s*0\)\s*\{\s*F_ErrorList\s+fErrorList\s*=\s*new F_ErrorList\(\);\s*fErrorList\.Init\(Result\.Errors\);\s*int\s+num\d+\s*=\s*\(int\)\s*fErrorList\.ShowDialog\(\);\s*clsInit\.appCommand\.Reset\(\);\s*return\s+-2;\s*\}'
$resultErrorMatches = [regex]::Matches($method, $resultErrorPattern)
if ($resultErrorMatches.Count -gt 1) {
    for ($i = $resultErrorMatches.Count - 1; $i -ge 1; --$i) {
        $duplicate = $resultErrorMatches[$i]
        $method = $method.Remove($duplicate.Index, $duplicate.Length)
    }
    "FIX duplicate 5AX ModuleWorks error blocks: removed $($resultErrorMatches.Count - 1)" | Tee-Object -Append $log
} else {
    "OK single 5AX ModuleWorks error block" | Tee-Object -Append $log
}

# Replace the empty C-axis envelope check with an equivalent-angle resolver that
# preserves continuity and stays inside the recovered machine's +/-370 degree range.
$emptyCEnvelopePattern = 'if\s*\(point\.P9\.C\s*>\s*370\.0\s*\|\|\s*point\.P9\.C\s*<\s*-370\.0\)\s*;'
if ([regex]::IsMatch($method, $emptyCEnvelopePattern)) {
    $cEnvelopeReplacement = @'
if (point.P9.C > 370.0 || point.P9.C < -370.0)
          {
            double normalizedC = point.P9.C % 360.0;
            double bestC = normalizedC;
            double bestCDelta = Math.Abs(bestC - num7);
            for (int turn = -1; turn <= 1; ++turn)
            {
              double candidateC = normalizedC + turn * 360.0;
              if (candidateC < -370.0 || candidateC > 370.0)
                continue;
              double candidateDelta = Math.Abs(candidateC - num7);
              if (candidateDelta < bestCDelta)
              {
                bestC = candidateC;
                bestCDelta = candidateDelta;
              }
            }
            point.P9.C = bestC;
          }
'@
    $method = [regex]::Replace($method, $emptyCEnvelopePattern, $cEnvelopeReplacement, 1)
    "FIX empty C-axis envelope check" | Tee-Object -Append $log
} elseif ($method -notmatch 'double\s+normalizedC\s*=\s*point\.P9\.C\s*%\s*360\.0') {
    throw 'Required C-axis envelope repair anchor was not found.'
} else {
    "OK C-axis envelope resolver already present" | Tee-Object -Append $log
}

$text = $text.Remove($methodMatch.Index, $methodMatch.Length).Insert($methodMatch.Index, $method)

# Make the final path validator a mandatory gate immediately before postprocessing.
if ($text -notmatch 'FiveAxisPathSafety\.ValidateAndNormalize\(Job\.Cams\);') {
    $gcodePattern = '(?m)^(?<indent>\s*)strGCodes\s*=\s*"";\s*\r?\n(?<callindent>\s*)clsInit\.cGcodeCreate\.CreatGCode\(Job\.Cams,\s*Post,\s*ref\s+strGCodes\);'
    $gcodeMatch = [regex]::Match($text, $gcodePattern)
    if (-not $gcodeMatch.Success) {
        throw 'G-code final validation insertion point was not found.'
    }
    $replacement = $gcodeMatch.Groups['indent'].Value + 'strGCodes = "";' + [Environment]::NewLine +
        $gcodeMatch.Groups['callindent'].Value + 'FiveAxisPathSafety.ValidateAndNormalize(Job.Cams);' + [Environment]::NewLine +
        $gcodeMatch.Groups['callindent'].Value + 'clsInit.cGcodeCreate.CreatGCode(Job.Cams, Post, ref strGCodes);' + [Environment]::NewLine +
        $gcodeMatch.Groups['callindent'].Value + 'FiveAxisPathSafety.ValidateGCode(strGCodes);'
    $text = $text.Remove($gcodeMatch.Index, $gcodeMatch.Length).Insert($gcodeMatch.Index, $replacement)
    "FIX mandatory final 5AX path validation gate" | Tee-Object -Append $log
} else {
    "OK final 5AX path validation gate already present" | Tee-Object -Append $log
    if ($text -notmatch 'FiveAxisPathSafety\.ValidateGCode\(strGCodes\);') {
        $postPattern = '(?m)^(?<indent>\s*)clsInit\.cGcodeCreate\.CreatGCode\(Job\.Cams,\s*Post,\s*ref\s+strGCodes\);'
        $postMatch = [regex]::Match($text, $postPattern)
        if (-not $postMatch.Success) {
            throw 'G-code text validation insertion point was not found.'
        }
        $postReplacement = $postMatch.Value + [Environment]::NewLine +
            $postMatch.Groups['indent'].Value + 'FiveAxisPathSafety.ValidateGCode(strGCodes);'
        $text = $text.Remove($postMatch.Index, $postMatch.Length).Insert($postMatch.Index, $postReplacement)
        "FIX final postprocessor text validation gate" | Tee-Object -Append $log
    }
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($sourcePath, $text, [Text.UTF8Encoding]::new($false))
}

# Fail the build if any repaired critical signature regresses.
$finalMethod = [regex]::Match($text, $methodPattern).Value
$regressions = New-Object System.Collections.Generic.List[string]
$validatorText = [IO.File]::ReadAllText($validatorPath)
$toolFormText = [IO.File]::ReadAllText($toolFormPath)
$filesText = [IO.File]::ReadAllText($filesPath)
if ($finalMethod -match '5AXPars\.MachParam\.LinkParams\.AirMoveSafetyDistance\s*=\s*0\.0') { $regressions.Add('zero 5AX clearance') }
if ($finalMethod -match '5AXPars\.MachParam\..*UseAirMoveSafetyDistanceFlg\s*=\s*false') { $regressions.Add('disabled 5AX clearance') }
if ($finalMethod -match 'CamTriMeshType\s*==\s*CamTriangularMeshType\.(ParallelCuts|ConstantZ|Geodesic)') { $regressions.Add('3-axis enum used in 5-axis method') }
if ($finalMethod -match $emptyCEnvelopePattern) { $regressions.Add('empty C-axis envelope check') }
if ($text -notmatch 'FiveAxisPathSafety\.ValidateAndNormalize\(Job\.Cams\);') { $regressions.Add('missing final path gate') }
if ($text -notmatch 'FiveAxisPathSafety\.ValidateGCode\(strGCodes\);') { $regressions.Add('missing postprocessor text gate') }
if ($validatorText -notmatch 'HasConfiguredMachineEnvelope') { $regressions.Add('machine envelope is not fail-closed') }
if ($validatorText -notmatch 'CreateEffectiveProfile') { $regressions.Add('per-tool XYZ/ABC envelope is not enforced') }
if ($validatorText -notmatch 'ValidateGCodeAxisRange') { $regressions.Add('G-code XYZ/ABC envelope is not enforced') }
if ($validatorText -notmatch 'class\s+FiveAxisSafetyProfileStore') { $regressions.Add('machine envelope persistence is missing') }
if ($toolFormText -notmatch 'TryValidateAxisLimits') { $regressions.Add('XYZ/ABC UI min-max validation is missing') }
if ($toolFormText -notmatch 'SaveMachineLimitsClick') { $regressions.Add('XYZ/ABC machine-profile save UI is missing') }
if ($toolFormText -notmatch 'LoadMachineLimitsClick') { $regressions.Add('XYZ/ABC machine-profile load UI is missing') }
if ($toolFormText -notmatch 'SetAxisLimitValue') { $regressions.Add('safe legacy axis-limit loading is missing') }
if ($filesText -notmatch 'FiveAxisSafetyProfileStore\.TryLoad') { $regressions.Add('machine profile is not loaded at startup') }

"5-axis regression count: $($regressions.Count)" | Tee-Object -Append $log
$regressions | ForEach-Object { "FAIL $_" | Tee-Object -Append $log }
if ($regressions.Count -gt 0) { exit 4 }

"PASS professional 5-axis source guards" | Tee-Object -Append $log
