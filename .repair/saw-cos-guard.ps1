$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/saw-cos-guard.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCore/buCore/buCamCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

$oldStart = @'
				safe = (num13 - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
'@
$newStart = @'
				double sawCosA = Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				if (double.IsNaN(sawCosA) || double.IsInfinity(sawCosA) || Math.Abs(sawCosA) <= 1E-09)
				{
					throw new InvalidOperationException("Grinding saw A-axis projection is undefined because cos(A) is zero.");
				}
				safe = (num13 - pnt6D2.Z) / sawCosA;
'@
if ($text.Contains($oldStart)) {
    $text = $text.Replace($oldStart, $newStart)
    "FIX CalculateGrindingContourSaw initial safe projection cos(A) guard" | Tee-Object -Append $log
}

$oldLeave = @'
				safe = (camPars.Distances.Safe - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				double length = (camPars.Material.Thickness + camPars.Distances.StepUp - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
'@
$newLeave = @'
				sawCosA = Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				if (double.IsNaN(sawCosA) || double.IsInfinity(sawCosA) || Math.Abs(sawCosA) <= 1E-09)
				{
					throw new InvalidOperationException("Grinding saw A-axis leave projection is undefined because cos(A) is zero.");
				}
				safe = (camPars.Distances.Safe - pnt6D2.Z) / sawCosA;
				double length = (camPars.Material.Thickness + camPars.Distances.StepUp - pnt6D2.Z) / sawCosA;
'@
if ($text.Contains($oldLeave)) {
    $text = $text.Replace($oldLeave, $newLeave)
    "FIX CalculateGrindingContourSaw leave/step-up projection cos(A) guard" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    "PATCHED $path" | Tee-Object -Append $log
} else {
    "NO_MATCH_OR_ALREADY_FIXED $path" | Tee-Object -Append $log
}
