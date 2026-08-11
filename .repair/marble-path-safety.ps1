$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/marble-path-safety.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCore/buCore/AppCalc/buMarbleCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# MarblecalcItemLines builds two independently calculated point lists but indexes
# CalcPoints2 with CalcPoints.Count. If either calculation returns fewer points the
# old code throws IndexOutOfRangeException. Pair only the common valid prefix.
$oldPairs = @'
		list = new List<eEntities>();
		for (int i = 0; i <= CalcPoints.Count - 1; i++)
		{
			eLine eLine2 = new eLine(CalcPoints[i], CalcPoints2[i], (float)Tool.Geometry.Thickness, Color.Lime);
'@
$newPairs = @'
		list = new List<eEntities>();
		int calcPointPairCount = Math.Min(CalcPoints.Count, CalcPoints2.Count);
		for (int i = 0; i < calcPointPairCount; i++)
		{
			eLine eLine2 = new eLine(CalcPoints[i], CalcPoints2[i], (float)Tool.Geometry.Thickness, Color.Lime);
'@
if ($text.Contains($oldPairs)) {
    $text = $text.Replace($oldPairs, $newPairs)
    "FIX MarblecalcItemLines paired-list bounds: $path" | Tee-Object -Append $log
}

# The decompiled code adjusts a temporary Pnt6DSim copy and discards it, so the
# simulation path never receives the same tool-radius Z correction as CAM points.
$oldSim = @'
				Pnt6DSim pnt6DSim = new Pnt6DSim(Cam.CamPoints[n].SimilationPoint.SimDetailedPoints[num]);
				pnt6DSim.Z -= Tool.Geometry.Diameter / 2.0;
'@
$newSim = @'
				Cam.CamPoints[n].SimilationPoint.SimDetailedPoints[num].Z -= Tool.Geometry.Diameter / 2.0;
'@
if ($text.Contains($oldSim)) {
    $text = $text.Replace($oldSim, $newSim)
    "FIX MarblecalcItemCam persist simulation Z tool-radius correction: $path" | Tee-Object -Append $log
}

# doSingleCut projects material thickness by 1/sin(A+90). Around A=90/270 the
# denominator is zero and height becomes Infinity. Reject undefined geometry before
# Plane3D is called.
$oldHeight = @'
		double height = varOperation.MaterialThickness / Math.Sin(buConversion.DegreeToRadian(pnt6D.A + 90.0));
		buAppCalc.cVector.Plane3D(new Pnt3D(pnt6D.X, pnt6D.Y, varOperation.MaterialThickness), new Vec3D(1.0, 0.0, 0.0), new OrientationAngle(pnt6D.A - 90.0, 0.0, pnt6D.C), varOperation.CutLength, height, ref Vertices);
'@
$newHeight = @'
		double singleCutProjectionSin = Math.Sin(buConversion.DegreeToRadian(pnt6D.A + 90.0));
		if (double.IsNaN(singleCutProjectionSin) || double.IsInfinity(singleCutProjectionSin) || Math.Abs(singleCutProjectionSin) <= 1E-9)
		{
			return;
		}
		double height = varOperation.MaterialThickness / singleCutProjectionSin;
		if (double.IsNaN(height) || double.IsInfinity(height))
		{
			return;
		}
		buAppCalc.cVector.Plane3D(new Pnt3D(pnt6D.X, pnt6D.Y, varOperation.MaterialThickness), new Vec3D(1.0, 0.0, 0.0), new OrientationAngle(pnt6D.A - 90.0, 0.0, pnt6D.C), varOperation.CutLength, height, ref Vertices);
		if (Vertices == null || Vertices.Count < 4)
		{
			return;
		}
'@
if ($text.Contains($oldHeight)) {
    $text = $text.Replace($oldHeight, $newHeight)
    "FIX doSingleCut projection singularity and Plane3D vertex bounds: $path" | Tee-Object -Append $log
}

# LeadInOutCalculation can legally fail to create one side. The old code indexes
# Vertice[0] and Count-1 unconditionally. Skip the current generated line if either
# lead geometry is empty instead of throwing.
$oldLead = @'
			buAppCalc.cCam.LeadInOutCalculation(eLine2, eLine2, leadIn, leadOut, new WorkPlane(), ClockDirectionType.CW, ref LeadInEntitiy, ref LeadOutEntitiy);
			eLine2.StartPoint = new Pnt3D(LeadInEntitiy.Vertice[0]);
			eLine2.EndPoint = new Pnt3D(LeadOutEntitiy.Vertice[LeadOutEntitiy.Vertice.Count - 1]);
'@
$newLead = @'
			buAppCalc.cCam.LeadInOutCalculation(eLine2, eLine2, leadIn, leadOut, new WorkPlane(), ClockDirectionType.CW, ref LeadInEntitiy, ref LeadOutEntitiy);
			if (LeadInEntitiy == null || LeadOutEntitiy == null || LeadInEntitiy.Vertice == null || LeadOutEntitiy.Vertice == null || LeadInEntitiy.Vertice.Count == 0 || LeadOutEntitiy.Vertice.Count == 0)
			{
				continue;
			}
			eLine2.StartPoint = new Pnt3D(LeadInEntitiy.Vertice[0]);
			eLine2.EndPoint = new Pnt3D(LeadOutEntitiy.Vertice[LeadOutEntitiy.Vertice.Count - 1]);
'@
if ($text.Contains($oldLead)) {
    $text = $text.Replace($oldLead, $newLead)
    "FIX doSingleCut lead-in/out empty geometry bounds: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched++
}

"Patched marble path files: $patched" | Tee-Object -Append $log
