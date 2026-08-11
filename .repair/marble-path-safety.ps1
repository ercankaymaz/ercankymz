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

# ItemEntities is auxiliary metadata and may be empty/null. Do not let AddRange
# turn a valid generated CAM path into an ArgumentNullException.
$oldItems = @'
		Cam.ItemEntities.AddRange(ItemEntities);
		Cam.Name = CamName;
		for (int k = 0; k <= Items.Count - 1; k++)
'@
$newItems = @'
		if (ItemEntities != null)
		{
			Cam.ItemEntities.AddRange(ItemEntities);
		}
		Cam.Name = CamName;
		if (Items == null)
		{
			Items = new List<marbleCutItems>();
		}
		for (int k = 0; k <= Items.Count - 1; k++)
'@
if ($text.Contains($oldItems)) {
    $text = $text.Replace($oldItems, $newItems)
    "FIX MarblecalcItemCam null metadata/item collections: $path" | Tee-Object -Append $log
}

# Guard generated point collections before dereferencing Points/P9. A failed or
# intentionally empty CAM segment should be skipped rather than aborting all output.
$oldCamPoints = @'
		for (int l = 0; l <= Cam.CamPoints.Count - 1; l++)
		{
			for (int m = 0; m <= Cam.CamPoints[l].Points.Count - 1; m++)
			{
'@
$newCamPoints = @'
		for (int l = 0; l <= Cam.CamPoints.Count - 1; l++)
		{
			if (Cam.CamPoints[l] == null || Cam.CamPoints[l].Points == null)
			{
				continue;
			}
			for (int m = 0; m <= Cam.CamPoints[l].Points.Count - 1; m++)
			{
'@
if ($text.Contains($oldCamPoints)) {
    $text = $text.Replace($oldCamPoints, $newCamPoints)
    "FIX MarblecalcItemCam null CAM point collection guard: $path" | Tee-Object -Append $log
}

# The decompiled code adjusts a temporary Pnt6DSim copy and discards it, so the
# simulation path never receives the same tool-radius Z correction as CAM points.
# Also guard optional simulation collections before iterating them.
$oldSimBlock = @'
		for (int n = 0; n <= Cam.CamPoints.Count - 1; n++)
		{
			for (int num = 0; num <= Cam.CamPoints[n].SimilationPoint.SimDetailedPoints.Count - 1; num++)
			{
				Pnt6DSim pnt6DSim = new Pnt6DSim(Cam.CamPoints[n].SimilationPoint.SimDetailedPoints[num]);
				pnt6DSim.Z -= Tool.Geometry.Diameter / 2.0;
			}
		}
'@
$newSimBlock = @'
		for (int n = 0; n <= Cam.CamPoints.Count - 1; n++)
		{
			if (Cam.CamPoints[n] == null || Cam.CamPoints[n].SimilationPoint == null || Cam.CamPoints[n].SimilationPoint.SimDetailedPoints == null)
			{
				continue;
			}
			for (int num = 0; num <= Cam.CamPoints[n].SimilationPoint.SimDetailedPoints.Count - 1; num++)
			{
				if (Cam.CamPoints[n].SimilationPoint.SimDetailedPoints[num] == null)
				{
					continue;
				}
				Cam.CamPoints[n].SimilationPoint.SimDetailedPoints[num].Z -= Tool.Geometry.Diameter / 2.0;
			}
		}
'@
if ($text.Contains($oldSimBlock)) {
    $text = $text.Replace($oldSimBlock, $newSimBlock)
    "FIX MarblecalcItemCam persist simulation Z and null simulation guards: $path" | Tee-Object -Append $log
}

# BackwardStep/deltaZ was evaluated before the branch that actually needs it.
# Moving the division to the else branch prevents non-finite intermediate values
# for repeated Z points while preserving every valid generated coordinate.
$oldDelta = @'
				double num2 = num - CalculatedHeight[k];
				double num3 = BackwardStep / num2;
				if (!(num2 >= ForwardStep + BackwardStep))
				{
					list.Add(CalculatedHeight[k]);
				}
				else
				{
					list.Add(num2 * num3 + CalculatedHeight[k]);
'@
$newDelta = @'
				double num2 = num - CalculatedHeight[k];
				if (!(num2 >= ForwardStep + BackwardStep))
				{
					list.Add(CalculatedHeight[k]);
				}
				else
				{
					double num3 = BackwardStep / num2;
					list.Add(num2 * num3 + CalculatedHeight[k]);
'@
if ($text.Contains($oldDelta)) {
    $text = $text.Replace($oldDelta, $newDelta)
    "FIX MarbleItemHeightByDirection deferred zero-delta division: $path" | Tee-Object -Append $log
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
