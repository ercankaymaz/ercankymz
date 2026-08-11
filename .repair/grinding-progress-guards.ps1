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
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    "FIX CalculateGrindingContourSaw single-contour progress NaN" | Tee-Object -Append $log
} elseif ($text.Contains('double progressPercent = list.Count <= 1 ? 100.0')) {
    "ALREADY_FIXED CalculateGrindingContourSaw single-contour progress NaN" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateGrindingContourSaw progress block" | Tee-Object -Append $log
}
