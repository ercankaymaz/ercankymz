$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/grinding-saw-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCore/buCore/buCamCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text
$patched = 0

# CalculateGrindingContourSaw projects the safe-Z delta along the tilted A axis.
# The previously repaired 45-degree geometry is correct, but at A=90/270 the
# projection is undefined. Reject the singularity before an Infinity/NaN point
# reaches kinematics or simulation.
$oldApproach = @'
				safe = (num13 - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
'@
$newApproach = @'
				double sawApproachCos = Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				if (double.IsNaN(sawApproachCos) || double.IsInfinity(sawApproachCos) || Math.Abs(sawApproachCos) <= 1E-9)
				{
					throw new InvalidOperationException("Grinding saw safe approach projection is undefined for the current A axis angle.");
				}
				safe = (num13 - pnt6D2.Z) / sawApproachCos;
'@
if ($text.Contains($oldApproach)) {
    $text = $text.Replace($oldApproach, $newApproach)
    $patched++
    "FIX CalculateGrindingContourSaw approach cos singularity: $path" | Tee-Object -Append $log
} elseif ($text.Contains('sawApproachCos')) {
    "ALREADY_FIXED CalculateGrindingContourSaw approach cos singularity: $path" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateGrindingContourSaw approach projection: $path" | Tee-Object -Append $log
}

$oldLeave = @'
				safe = (camPars.Distances.Safe - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
'@
$newLeave = @'
				double sawLeaveCos = Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				if (double.IsNaN(sawLeaveCos) || double.IsInfinity(sawLeaveCos) || Math.Abs(sawLeaveCos) <= 1E-9)
				{
					throw new InvalidOperationException("Grinding saw safe leave projection is undefined for the current A axis angle.");
				}
				safe = (camPars.Distances.Safe - pnt6D2.Z) / sawLeaveCos;
'@
if ($text.Contains($oldLeave)) {
    $text = $text.Replace($oldLeave, $newLeave)
    $patched++
    "FIX CalculateGrindingContourSaw leave cos singularity: $path" | Tee-Object -Append $log
} elseif ($text.Contains('sawLeaveCos')) {
    "ALREADY_FIXED CalculateGrindingContourSaw leave cos singularity: $path" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateGrindingContourSaw leave projection: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
}

"Patched grinding saw guards: $patched" | Tee-Object -Append $log
