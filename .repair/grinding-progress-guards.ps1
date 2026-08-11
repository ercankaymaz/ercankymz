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

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
}
