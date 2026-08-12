$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/grinding-progress-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCore/buCore/buCamCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

$old = @'
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double)num26 / (double)(list.Count - 1)) * 100.0, Convert.ToDouble((double)num26 / (double)(list.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
'@
$new = @'
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					double progressPercent = list.Count <= 1 ? 100.0 : Convert.ToDouble((double)num26 / (double)(list.Count - 1)) * 100.0;
					calculationEventHandler_0(new CalculationEventArg(progressPercent, progressPercent, 0, "Calculate Marble Code", ""));
				}
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new)
    "FIX CalculateGrindingContourSaw single-contour progress NaN" | Tee-Object -Append $log
} elseif ($text.Contains('double progressPercent = list.Count <= 1 ? 100.0')) {
    "ALREADY_FIXED CalculateGrindingContourSaw single-contour progress NaN" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateGrindingContourSaw progress block" | Tee-Object -Append $log
}

# CalculateGrindingHole decrements the UpDownByStep loop by Abs(DownStep).
# With DownStep==0 the loop condition never changes, freezing CAM calculation.
# Normalize the value once and reject zero/non-finite steps before entering it.
$oldHoleStep = @'
			if (camPars.Hole.HoleType == grindingHoleType.UpDownByStep)
			{
				for (double num4 = camPars.Hole.StartHeight - Math.Abs(camPars.Hole.DownStep); num4 >= camPars.Hole.EndHeight; num4 -= Math.Abs(camPars.Hole.DownStep))
				{
'@
$newHoleStep = @'
			if (camPars.Hole.HoleType == grindingHoleType.UpDownByStep)
			{
				double holeDownStep = Math.Abs(camPars.Hole.DownStep);
				if (double.IsNaN(holeDownStep) || double.IsInfinity(holeDownStep) || holeDownStep <= 1E-9)
				{
					throw new InvalidOperationException("Grinding hole down-step must be a finite value greater than zero.");
				}
				for (double num4 = camPars.Hole.StartHeight - holeDownStep; num4 >= camPars.Hole.EndHeight; num4 -= holeDownStep)
				{
'@
if ($text.Contains($oldHoleStep)) {
    $text = $text.Replace($oldHoleStep, $newHoleStep)
    "FIX CalculateGrindingHole zero/non-finite DownStep infinite-loop guard" | Tee-Object -Append $log
} elseif ($text.Contains('double holeDownStep = Math.Abs(camPars.Hole.DownStep);')) {
    "ALREADY_FIXED CalculateGrindingHole DownStep loop guard" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateGrindingHole UpDownByStep loop" | Tee-Object -Append $log
}

# CalculateMarbleItem projects the safe Z delta along the current A-axis angle.
# At A=90/270 degrees cos(A) is zero and the old code sends Infinity into the
# kinematic path. Reject only that undefined projection.
$oldMarbleCos = @'
					safe2 = (safe - pnt3D3.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle.A));
					Pnt6D CalcPoint = new Pnt6D();
'@
$newMarbleCos = @'
					double marbleItemCosA = Math.Cos(buConversion.DegreeToRadian(orientationAngle.A));
					if (double.IsNaN(marbleItemCosA) || double.IsInfinity(marbleItemCosA) || Math.Abs(marbleItemCosA) <= 1E-9)
					{
						throw new InvalidOperationException("Marble item A-axis safe projection is undefined because cos(A) is zero.");
					}
					safe2 = (safe - pnt3D3.Z) / marbleItemCosA;
					Pnt6D CalcPoint = new Pnt6D();
'@
if ($text.Contains($oldMarbleCos)) {
    $text = $text.Replace($oldMarbleCos, $newMarbleCos)
    "FIX CalculateMarbleItem safe projection cos(A) singularity" | Tee-Object -Append $log
} elseif ($text.Contains('double marbleItemCosA = Math.Cos')) {
    "ALREADY_FIXED CalculateMarbleItem safe projection cos(A)" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateMarbleItem safe projection" | Tee-Object -Append $log
}

# Several CAM methods report i/(Entities.Count-1). For a one-group job this is
# 0/0. Replace every remaining identical progress block globally; the local
# variable is scoped to the block and therefore safe across methods.
$oldMarbleProgress = @'
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double)i / (double)(Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
'@
$newMarbleProgress = @'
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					double marbleItemProgress = Entities.Count <= 1 ? 100.0 : Convert.ToDouble((double)i / (double)(Entities.Count - 1)) * 100.0;
					calculationEventHandler_0(new CalculationEventArg(50.0, marbleItemProgress, 0, "Calculate Marble Code", ""));
				}
'@
if ($text.Contains($oldMarbleProgress)) {
    $text = $text.Replace($oldMarbleProgress, $newMarbleProgress)
    "FIX all matching single-entity CAM progress NaN blocks" | Tee-Object -Append $log
} elseif ($text.Contains('double marbleItemProgress = Entities.Count <= 1 ? 100.0')) {
    "ALREADY_FIXED single-entity CAM progress NaN" | Tee-Object -Append $log
}

# Other methods use different collection/index variables but have the same
# denominator defect. Inline finite fallbacks avoid introducing scope conflicts.
$progressExpressions = [ordered]@{
    'Convert.ToDouble((double)k / (double)(CopiedEnt.Count - 1)) * 100.0' = '(CopiedEnt.Count <= 1 ? 100.0 : Convert.ToDouble((double)k / (double)(CopiedEnt.Count - 1)) * 100.0)'
    'Convert.ToDouble((double)num33 / (double)(list2.Count - 1)) * 100.0' = '(list2.Count <= 1 ? 100.0 : Convert.ToDouble((double)num33 / (double)(list2.Count - 1)) * 100.0)'
    'Convert.ToDouble((double)k / (double)(ContinousPoints.Count - 1)) * 100.0' = '(ContinousPoints.Count <= 1 ? 100.0 : Convert.ToDouble((double)k / (double)(ContinousPoints.Count - 1)) * 100.0)'
    'Convert.ToDouble((double)num25 / (double)(ContinousPoints.Count - 1)) * 100.0' = '(ContinousPoints.Count <= 1 ? 100.0 : Convert.ToDouble((double)num25 / (double)(ContinousPoints.Count - 1)) * 100.0)'
}
foreach ($entry in $progressExpressions.GetEnumerator()) {
    if ($text.Contains($entry.Key)) {
        $text = $text.Replace($entry.Key, $entry.Value)
        "FIX CAM progress denominator: $($entry.Key)" | Tee-Object -Append $log
    }
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
}
