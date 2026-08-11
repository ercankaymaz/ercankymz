$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/grinding-saw-ramp-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCore/buCore/buCamCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text
$patched = 0

# Saw-ramp subdivision is indexed immediately by both linear and circular paths.
# A too-short/degenerate contour may legally produce no derived start/end points;
# do not let those empty lists become an IndexOutOfRangeException later.
$oldDivide = @'
					buAppCalc.cVector.DevidePointList(CopiedPnt, Operation.SawDevideLength, Operation.SawRampLenght, Operation.SawRampLenght, DevideMiddlePoints: true, DevideTipType.StartAndEnd, ref calcStartPoints, ref calcMiddlePoints, ref calcEndPoints);
					if (Operation.SawRampType == CamZRampType.Linear)
'@
$newDivide = @'
					buAppCalc.cVector.DevidePointList(CopiedPnt, Operation.SawDevideLength, Operation.SawRampLenght, Operation.SawRampLenght, DevideMiddlePoints: true, DevideTipType.StartAndEnd, ref calcStartPoints, ref calcMiddlePoints, ref calcEndPoints);
					if (calcStartPoints == null || calcEndPoints == null || calcStartPoints.Count == 0 || calcEndPoints.Count == 0)
					{
						throw new InvalidOperationException("Grinding saw ramp did not produce valid start/end point collections.");
					}
					if (Operation.SawRampType == CamZRampType.Linear)
'@
if ($text.Contains($oldDivide)) {
    $text = $text.Replace($oldDivide, $newDivide)
    $patched++
    "FIX CalculateGrindingContourSaw empty ramp start/end collections" | Tee-Object -Append $log
} elseif ($text.Contains('Grinding saw ramp did not produce valid start/end point collections.')) {
    "ALREADY_FIXED CalculateGrindingContourSaw empty ramp start/end collections" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateGrindingContourSaw ramp subdivision" | Tee-Object -Append $log
}

# Circular ramp maps point-list indices directly into the generated Z list. Verify
# both collections before [0], [num18] or [last] are accessed.
$oldCircularStart = @'
						buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.SawRampHeight, camPars.Operations.TargetZ, 1.0, 200, ref list3, ref Points2);
						double num14 = 0.0;
						calcStartPoints[0] = new Pnt6D(calcStartPoints[0].X, calcStartPoints[0].Y, list3[0], calcStartPoints[0].A, calcStartPoints[0].B, calcStartPoints[0].C);
'@
$newCircularStart = @'
						buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.SawRampHeight, camPars.Operations.TargetZ, 1.0, 200, ref list3, ref Points2);
						if (list3 == null || Points2 == null || list3.Count == 0 || Points2.Count == 0 || list3.Count < Points2.Count)
						{
							throw new InvalidOperationException("Grinding saw circular start ramp returned an empty or inconsistent interpolation result.");
						}
						double num14 = 0.0;
						calcStartPoints[0] = new Pnt6D(calcStartPoints[0].X, calcStartPoints[0].Y, list3[0], calcStartPoints[0].A, calcStartPoints[0].B, calcStartPoints[0].C);
'@
if ($text.Contains($oldCircularStart)) {
    $text = $text.Replace($oldCircularStart, $newCircularStart)
    $patched++
    "FIX CalculateGrindingContourSaw circular start-ramp result bounds" | Tee-Object -Append $log
} elseif ($text.Contains('Grinding saw circular start ramp returned an empty or inconsistent interpolation result.')) {
    "ALREADY_FIXED CalculateGrindingContourSaw circular start-ramp result bounds" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateGrindingContourSaw circular start ramp" | Tee-Object -Append $log
}

$oldCircularEnd = @'
						buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, camPars.Operations.TargetZ, Operation.SawRampHeight, 1.0, 200, ref list3, ref Points2);
						num14 = 0.0;
						calcEndPoints[0] = new Pnt6D(calcEndPoints[0].X, calcEndPoints[0].Y, list3[0], calcEndPoints[0].A, calcEndPoints[0].B, calcEndPoints[0].C);
'@
$newCircularEnd = @'
						buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, camPars.Operations.TargetZ, Operation.SawRampHeight, 1.0, 200, ref list3, ref Points2);
						if (list3 == null || Points2 == null || list3.Count == 0 || Points2.Count == 0 || list3.Count < Points2.Count)
						{
							throw new InvalidOperationException("Grinding saw circular end ramp returned an empty or inconsistent interpolation result.");
						}
						num14 = 0.0;
						calcEndPoints[0] = new Pnt6D(calcEndPoints[0].X, calcEndPoints[0].Y, list3[0], calcEndPoints[0].A, calcEndPoints[0].B, calcEndPoints[0].C);
'@
if ($text.Contains($oldCircularEnd)) {
    $text = $text.Replace($oldCircularEnd, $newCircularEnd)
    $patched++
    "FIX CalculateGrindingContourSaw circular end-ramp result bounds" | Tee-Object -Append $log
} elseif ($text.Contains('Grinding saw circular end ramp returned an empty or inconsistent interpolation result.')) {
    "ALREADY_FIXED CalculateGrindingContourSaw circular end-ramp result bounds" | Tee-Object -Append $log
} else {
    "NO_MATCH CalculateGrindingContourSaw circular end ramp" | Tee-Object -Append $log
}

# The generated contour list is consumed through list[num26][0] and, for the next
# orientation, list[num26+1][0]. Skip an empty current contour and only read a
# non-empty next contour.
$oldLoop = @'
			for (int num26 = 0; num26 <= list.Count - 1; num26++)
			{
				double toolLength = Tool.Geometry.Diameter / 2.0;
'@
$newLoop = @'
			for (int num26 = 0; num26 <= list.Count - 1; num26++)
			{
				if (list[num26] == null || list[num26].Count == 0)
				{
					continue;
				}
				double toolLength = Tool.Geometry.Diameter / 2.0;
'@
if ($text.Contains($oldLoop)) {
    $text = $text.Replace($oldLoop, $newLoop)
    $patched++
    "FIX CalculateGrindingContourSaw empty generated contour guard" | Tee-Object -Append $log
}

$oldNext = @'
				if (num26 <= list.Count - 2)
				{
					orientationAngle3 = new OrientationAngle(new Pnt6D(list[num26 + 1][0]));
				}
'@
$newNext = @'
				if (num26 <= list.Count - 2 && list[num26 + 1] != null && list[num26 + 1].Count > 0)
				{
					orientationAngle3 = new OrientationAngle(new Pnt6D(list[num26 + 1][0]));
				}
'@
if ($text.Contains($oldNext)) {
    $text = $text.Replace($oldNext, $newNext)
    $patched++
    "FIX CalculateGrindingContourSaw next-contour [0] guard" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
}

"Patched grinding saw ramp guards: $patched" | Tee-Object -Append $log
