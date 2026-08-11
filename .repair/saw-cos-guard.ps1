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

# Verified PR #1 source/IL repair: these call sites calculated angle-compensated
# lengths (num21/num22/Length1) but then passed raw vertical deltas to the move.
# At 45 degrees that shortens approach/leave travel by cos(A) and can clip stock.
$moveRepairs = @(
    @(
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe1 - pnt3D5.Z, ref calcPoint1);',
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), num21, ref calcPoint1);',
        'first projected approach'
    ),
    @(
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe1 - pnt3D5.Z, ref calcPoint2);',
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), num21, ref calcPoint2);',
        'second projected approach'
    ),
    @(
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe2 - pnt3D6.Z, ref calcPoint3);',
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), num22, ref calcPoint3);',
        'projected step-up leave'
    ),
    @(
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe2 - pnt3D6.Z, ref calcPoint4);',
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), num21, ref calcPoint4);',
        'projected safe leave'
    ),
    @(
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Distance.Safe, ref calcPoint);',
        'buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length1, ref calcPoint);',
        'wireframe projected plunge'
    )
)
foreach ($repair in $moveRepairs) {
    $old = $repair[0]
    $new = $repair[1]
    $name = $repair[2]
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        "FIX Grinding saw $name" | Tee-Object -Append $log
    } elseif ($text.Contains($new)) {
        "OK Grinding saw $name already fixed" | Tee-Object -Append $log
    } else {
        "NO_MATCH Grinding saw $name" | Tee-Object -Append $log
    }
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    "PATCHED $path" | Tee-Object -Append $log
} else {
    "NO_MATCH_OR_ALREADY_FIXED $path" | Tee-Object -Append $log
}
