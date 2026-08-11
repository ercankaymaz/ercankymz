$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/marble-geometry-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCore/buCore/AppCalc/buMarbleCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# doSingleCut: A+90 is projected through sin(). A=+/-90 can make the cutting
# plane height undefined. Reject non-finite/pole values before Plane3D.
$old = @'
		double height = varOperation.MaterialThickness / Math.Sin(buConversion.DegreeToRadian(pnt6D.A + 90.0));
		buAppCalc.cVector.Plane3D(new Pnt3D(pnt6D.X, pnt6D.Y, varOperation.MaterialThickness), new Vec3D(1.0, 0.0, 0.0), new OrientationAngle(pnt6D.A - 90.0, 0.0, pnt6D.C), varOperation.CutLength, height, ref Vertices);
'@
$new = @'
		double sawPlaneSin = Math.Sin(buConversion.DegreeToRadian(pnt6D.A + 90.0));
		if (double.IsNaN(sawPlaneSin) || double.IsInfinity(sawPlaneSin) || Math.Abs(sawPlaneSin) <= 1E-9)
		{
			return;
		}
		double height = varOperation.MaterialThickness / sawPlaneSin;
		buAppCalc.cVector.Plane3D(new Pnt3D(pnt6D.X, pnt6D.Y, varOperation.MaterialThickness), new Vec3D(1.0, 0.0, 0.0), new OrientationAngle(pnt6D.A - 90.0, 0.0, pnt6D.C), varOperation.CutLength, height, ref Vertices);
		if (Vertices.Count < 4)
		{
			return;
		}
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new)
    "FIX doSingleCut plane singularity and Vertices[0..3] guard" | Tee-Object -Append $log
}

# Both point lists are independently calculated. Never index the second list
# by the first list's count if a geometry/interpolation branch returned fewer points.
$old = @'
		for (int i = 0; i <= CalcPoints.Count - 1; i++)
		{
			eLine eLine2 = new eLine(CalcPoints[i], CalcPoints2[i], 4f, Color.Lime);
'@
$new = @'
		int safePointCount = Math.Min(CalcPoints.Count, CalcPoints2.Count);
		for (int i = 0; i < safePointCount; i++)
		{
			eLine eLine2 = new eLine(CalcPoints[i], CalcPoints2[i], 4f, Color.Lime);
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new)
    "FIX doSingleCut mismatched calculated-point list index guard" | Tee-Object -Append $log
}

$old = @'
			buAppCalc.cCam.LeadInOutCalculation(eLine2, eLine2, leadIn, leadOut, new WorkPlane(), ClockDirectionType.CW, ref LeadInEntitiy, ref LeadOutEntitiy);
			eLine2.StartPoint = new Pnt3D(LeadInEntitiy.Vertice[0]);
			eLine2.EndPoint = new Pnt3D(LeadOutEntitiy.Vertice[LeadOutEntitiy.Vertice.Count - 1]);
'@
$new = @'
			buAppCalc.cCam.LeadInOutCalculation(eLine2, eLine2, leadIn, leadOut, new WorkPlane(), ClockDirectionType.CW, ref LeadInEntitiy, ref LeadOutEntitiy);
			if (LeadInEntitiy == null || LeadOutEntitiy == null || LeadInEntitiy.Vertice == null || LeadOutEntitiy.Vertice == null || LeadInEntitiy.Vertice.Count == 0 || LeadOutEntitiy.Vertice.Count == 0)
			{
				continue;
			}
			eLine2.StartPoint = new Pnt3D(LeadInEntitiy.Vertice[0]);
			eLine2.EndPoint = new Pnt3D(LeadOutEntitiy.Vertice[LeadOutEntitiy.Vertice.Count - 1]);
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new)
    "FIX doSingleCut empty LeadIn/LeadOut vertex guard" | Tee-Object -Append $log
}

# MarblecalcItemLines has the same independently produced-list assumption.
$old = @'
		for (int i = 0; i <= CalcPoints.Count - 1; i++)
		{
			eLine eLine2 = new eLine(CalcPoints[i], CalcPoints2[i], (float)Tool.Geometry.Thickness, Color.Lime);
'@
$new = @'
		int safeLinePointCount = Math.Min(CalcPoints.Count, CalcPoints2.Count);
		for (int i = 0; i < safeLinePointCount; i++)
		{
			eLine eLine2 = new eLine(CalcPoints[i], CalcPoints2[i], (float)Tool.Geometry.Thickness, Color.Lime);
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new)
    "FIX MarblecalcItemLines mismatched point-list index guard" | Tee-Object -Append $log
}

# HorizontalItemsCalc: C-axis projection divides by cos(C), while bevel tool
# offsets divide by cos(Start/EndAngle). Guard poles/non-finite values before
# any tan/cos use and verify Trapezoid3D actually returned indexes 3 and 5.
$old = @'
		num5 = Math.Round(Position.C);
		if (Items.Count == 0)
		{
			return;
		}
'@
$new = @'
		num5 = Math.Round(Position.C);
		if (Items == null || Items.Count == 0)
		{
			return;
		}
		double horizontalPositionCos = Math.Cos(buConversion.DegreeToRadian(num5));
		if (double.IsNaN(horizontalPositionCos) || double.IsInfinity(horizontalPositionCos) || Math.Abs(horizontalPositionCos) <= 1E-9)
		{
			return;
		}
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new, 1)
    "FIX HorizontalItemsCalc C-axis cosine singularity/null item guard" | Tee-Object -Append $log
}

$old = @'
			double num6 = Items[i].StartAngle;
			double num7 = Items[i].EndAngle;
			double num8 = Math.Abs(Items[i].Length);
'@
$new = @'
			double num6 = Items[i].StartAngle;
			double num7 = Items[i].EndAngle;
			double startAngleCos = Math.Cos(buConversion.DegreeToRadian(Math.Abs(num6)));
			double endAngleCos = Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
			if (double.IsNaN(startAngleCos) || double.IsInfinity(startAngleCos) || Math.Abs(startAngleCos) <= 1E-9 || double.IsNaN(endAngleCos) || double.IsInfinity(endAngleCos) || Math.Abs(endAngleCos) <= 1E-9)
			{
				continue;
			}
			double num8 = Math.Abs(Items[i].Length);
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new, 1)
    "FIX HorizontalItemsCalc bevel cosine/tangent singularity guard" | Tee-Object -Append $log
}

$old = @'
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num8, varOperation.MaterialThickness - varOperation.TargetZ, num6 + 90.0, num7 + 90.0, new Vec3D(1.0, 0.0, 0.0), CutLength, num5, ref Quads, ref SurfaceEntity);
'@
$new = @'
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num8, varOperation.MaterialThickness - varOperation.TargetZ, num6 + 90.0, num7 + 90.0, new Vec3D(1.0, 0.0, 0.0), CutLength, num5, ref Quads, ref SurfaceEntity);
			if (Quads == null || Quads.Count < 6)
			{
				continue;
			}
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new, 1)
    "FIX HorizontalItemsCalc Quads[3]/Quads[5] result-count guard" | Tee-Object -Append $log
}

# VerticalItemsCalc projects item spacing by sin(|C|) and bevel offsets by
# cos(Start/EndAngle). Apply the symmetric guards and result-count validation.
$old = @'
		num6 = Math.Round(Position.C);
		if (Items.Count == 0)
		{
			return;
		}
'@
$new = @'
		num6 = Math.Round(Position.C);
		if (Items == null || Items.Count == 0)
		{
			return;
		}
		double verticalPositionSin = Math.Sin(buConversion.DegreeToRadian(Math.Abs(num6)));
		if (double.IsNaN(verticalPositionSin) || double.IsInfinity(verticalPositionSin) || Math.Abs(verticalPositionSin) <= 1E-9)
		{
			return;
		}
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new, 1)
    "FIX VerticalItemsCalc C-axis sine singularity/null item guard" | Tee-Object -Append $log
}

$old = @'
			double num7 = Items[i].StartAngle;
			double num8 = Items[i].EndAngle;
			double num9 = Math.Abs(Items[i].Length);
'@
$new = @'
			double num7 = Items[i].StartAngle;
			double num8 = Items[i].EndAngle;
			double startAngleCos = Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
			double endAngleCos = Math.Cos(buConversion.DegreeToRadian(Math.Abs(num8)));
			if (double.IsNaN(startAngleCos) || double.IsInfinity(startAngleCos) || Math.Abs(startAngleCos) <= 1E-9 || double.IsNaN(endAngleCos) || double.IsInfinity(endAngleCos) || Math.Abs(endAngleCos) <= 1E-9)
			{
				continue;
			}
			double num9 = Math.Abs(Items[i].Length);
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new, 1)
    "FIX VerticalItemsCalc bevel cosine/tangent singularity guard" | Tee-Object -Append $log
}

$old = @'
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num9, varOperation.MaterialThickness, num11 + 90.0, num12 + 90.0, new Vec3D(0.0, 1.0, 0.0), CutLength, Math.Abs(Position.C) - 90.0, ref Quads, ref SurfaceEntity);
'@
$new = @'
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num9, varOperation.MaterialThickness, num11 + 90.0, num12 + 90.0, new Vec3D(0.0, 1.0, 0.0), CutLength, Math.Abs(Position.C) - 90.0, ref Quads, ref SurfaceEntity);
			if (Quads == null || Quads.Count < 6)
			{
				continue;
			}
'@
if ($text.Contains($old)) {
    $text = $text.Replace($old, $new, 1)
    "FIX VerticalItemsCalc Quads[3]/Quads[5] result-count guard" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched = 1
} else {
    "NO_MATCH_OR_ALREADY_FIXED $path" | Tee-Object -Append $log
}

"Patched marble geometry files: $patched" | Tee-Object -Append $log
