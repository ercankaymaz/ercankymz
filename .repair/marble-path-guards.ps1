$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/marble-path-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCore/buCore/AppCalc/buMarbleCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

function Replace-Literal([string]$name, [string]$old, [string]$new) {
    if ($script:text.Contains($old)) {
        $script:text = $script:text.Replace($old, $new)
        "FIX $name" | Tee-Object -Append $script:log
        return
    }
    "NO_MATCH_OR_ALREADY_FIXED $name" | Tee-Object -Append $script:log
}

# Both edge profiles must have the same number of Z steps. The original loop
# indexes CalcPoints2 by CalcPoints.Count and can overrun when the two generated
# lists diverge because of invalid step parameters or degenerate geometry.
$oldMatchedEdges = @'
		MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, LastUpPnt, LastDownPnt, ref CalcPoints2);
		list = new List<eEntities>();
		for (int i = 0; i <= CalcPoints.Count - 1; i++)
'@
$newMatchedEdges = @'
		MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, LastUpPnt, LastDownPnt, ref CalcPoints2);
		if (CalcPoints.Count != CalcPoints2.Count)
		{
			return;
		}
		list = new List<eEntities>();
		for (int i = 0; i <= CalcPoints.Count - 1; i++)
'@
Replace-Literal 'MarblecalcItemLines mismatched edge step counts' $oldMatchedEdges $newMatchedEdges

# Horizontal Trapezoid3D results are immediately indexed at 5 and 3. Reject an
# incomplete result instead of allowing an IndexOutOfRangeException in CAM path generation.
$oldHorizontalQuads = @'
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num8, varOperation.MaterialThickness - varOperation.TargetZ, num6 + 90.0, num7 + 90.0, new Vec3D(1.0, 0.0, 0.0), CutLength, num5, ref Quads, ref SurfaceEntity);
			if (num4 < 0.0)
'@
$newHorizontalQuads = @'
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num8, varOperation.MaterialThickness - varOperation.TargetZ, num6 + 90.0, num7 + 90.0, new Vec3D(1.0, 0.0, 0.0), CutLength, num5, ref Quads, ref SurfaceEntity);
			if (Quads == null || Quads.Count < 6 || SurfaceEntity == null)
			{
				return;
			}
			if (num4 < 0.0)
'@
Replace-Literal 'HorizontalItemsCalc Trapezoid3D quad-count guard' $oldHorizontalQuads $newHorizontalQuads

$oldHorizontalDivisors = @'
				double num13 = Math.Abs(Items[i].Length) / Math.Cos(buConversion.DegreeToRadian(num5));
				double num14 = 0.0;
				double num15 = 0.0;
				_ = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num6)));
				double num16 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				num11 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num6)));
				num12 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
'@
$newHorizontalDivisors = @'
				double positionCos = Math.Cos(buConversion.DegreeToRadian(num5));
				double startCos = Math.Cos(buConversion.DegreeToRadian(Math.Abs(num6)));
				double endCos = Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				if (double.IsNaN(positionCos) || double.IsInfinity(positionCos) || Math.Abs(positionCos) <= 1E-9 ||
					double.IsNaN(startCos) || double.IsInfinity(startCos) || Math.Abs(startCos) <= 1E-9 ||
					double.IsNaN(endCos) || double.IsInfinity(endCos) || Math.Abs(endCos) <= 1E-9)
				{
					return;
				}
				double num13 = Math.Abs(Items[i].Length) / positionCos;
				double num14 = 0.0;
				double num15 = 0.0;
				_ = Tool.Geometry.Thickness / startCos;
				double num16 = Tool.Geometry.Thickness / endCos;
				num11 = Tool.Geometry.Thickness / 2.0 / startCos;
				num12 = Tool.Geometry.Thickness / 2.0 / endCos;
'@
Replace-Literal 'HorizontalItemsCalc finite cosine divisors' $oldHorizontalDivisors $newHorizontalDivisors

# Vertical Trapezoid3D has the same fixed [5]/[3] accesses.
$oldVerticalQuads = @'
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num9, varOperation.MaterialThickness, num11 + 90.0, num12 + 90.0, new Vec3D(0.0, 1.0, 0.0), CutLength, Math.Abs(Position.C) - 90.0, ref Quads, ref SurfaceEntity);
			if (num6 < 0.0)
'@
$newVerticalQuads = @'
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num9, varOperation.MaterialThickness, num11 + 90.0, num12 + 90.0, new Vec3D(0.0, 1.0, 0.0), CutLength, Math.Abs(Position.C) - 90.0, ref Quads, ref SurfaceEntity);
			if (Quads == null || Quads.Count < 6 || SurfaceEntity == null)
			{
				return;
			}
			if (num6 < 0.0)
'@
Replace-Literal 'VerticalItemsCalc Trapezoid3D quad-count guard' $oldVerticalQuads $newVerticalQuads

$oldVerticalDivisors = @'
				double num16 = Math.Abs(Items[i].Length) / Math.Sin(buConversion.DegreeToRadian(Math.Abs(num6)));
				double num17 = 0.0;
				double num18 = 0.0;
				double num19 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				double num20 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num8)));
				num14 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				num15 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num8)));
'@
$newVerticalDivisors = @'
				double positionSin = Math.Sin(buConversion.DegreeToRadian(Math.Abs(num6)));
				double startCos = Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				double endCos = Math.Cos(buConversion.DegreeToRadian(Math.Abs(num8)));
				if (double.IsNaN(positionSin) || double.IsInfinity(positionSin) || Math.Abs(positionSin) <= 1E-9 ||
					double.IsNaN(startCos) || double.IsInfinity(startCos) || Math.Abs(startCos) <= 1E-9 ||
					double.IsNaN(endCos) || double.IsInfinity(endCos) || Math.Abs(endCos) <= 1E-9)
				{
					return;
				}
				double num16 = Math.Abs(Items[i].Length) / positionSin;
				double num17 = 0.0;
				double num18 = 0.0;
				double num19 = Tool.Geometry.Thickness / startCos;
				double num20 = Tool.Geometry.Thickness / endCos;
				num14 = Tool.Geometry.Thickness / 2.0 / startCos;
				num15 = Tool.Geometry.Thickness / 2.0 / endCos;
'@
Replace-Literal 'VerticalItemsCalc finite sine/cosine divisors' $oldVerticalDivisors $newVerticalDivisors

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    'PATCHED buMarbleCalc multi-cut path guards' | Tee-Object -Append $log
} else {
    'NO_SOURCE_CHANGE' | Tee-Object -Append $log
}
