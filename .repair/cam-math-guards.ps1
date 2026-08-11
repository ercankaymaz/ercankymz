$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/cam-math-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$marblePath = 'Decompiled/buCore/buCore/AppCalc/buMarbleCalc.cs'
if (Test-Path -LiteralPath $marblePath) {
    $text = [IO.File]::ReadAllText($marblePath)
    $original = $text

    # MarbleItemEntitiesCalculation projects both cut length and tool thickness
    # by 1/cos(TangentAngle). At 90/270 degrees that projection is undefined and
    # the decompiled code propagates Infinity into the generated CAM geometry.
    $old = @'
				if (!Perpendicular)
				{
					_ = (Items[i].Length + ToolThickness) / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
					num8 = Items[i].Length / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
					num6 = ToolThickness / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
					num7 = ToolThickness * 0.5 / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
'@
    $new = @'
				if (!Perpendicular)
				{
					double tangentCos = Math.Cos(buConversion.DegreeToRadian(TangentAngle));
					if (double.IsNaN(tangentCos) || double.IsInfinity(tangentCos) || Math.Abs(tangentCos) <= 1E-9)
					{
						return false;
					}
					_ = (Items[i].Length + ToolThickness) / tangentCos;
					num8 = Items[i].Length / tangentCos;
					num6 = ToolThickness / tangentCos;
					num7 = ToolThickness * 0.5 / tangentCos;
'@
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        "FIX MarbleItemEntitiesCalculation tangent cos singularity: $marblePath" | Tee-Object -Append $log
    }

    # Perpendicular projection uses 1/sin(TangentAngle). At 0/180 degrees the
    # projection is undefined and would otherwise inject Infinity/NaN points.
    $oldSin = @'
				_ = (Items[i].Length + ToolThickness) / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
				num8 = Items[i].Length / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
				num6 = ToolThickness / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
				num7 = ToolThickness * 0.5 / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
'@
    $newSin = @'
				double tangentSin = Math.Sin(buConversion.DegreeToRadian(TangentAngle));
				if (double.IsNaN(tangentSin) || double.IsInfinity(tangentSin) || Math.Abs(tangentSin) <= 1E-9)
				{
					return false;
				}
				_ = (Items[i].Length + ToolThickness) / tangentSin;
				num8 = Items[i].Length / tangentSin;
				num6 = ToolThickness / tangentSin;
				num7 = ToolThickness * 0.5 / tangentSin;
'@
    if ($text.Contains($oldSin)) {
        $text = $text.Replace($oldSin, $newSin)
        "FIX MarbleItemEntitiesCalculation tangent sin singularity: $marblePath" | Tee-Object -Append $log
    }

    # The selected step-down is used as a divisor and then converted to Int32.
    # Zero/non-finite values can produce Infinity and an OverflowException.
    $oldStep = @'
			num2 = Convert.ToInt32(Math.Ceiling(num4 / num5));
'@
    $newStep = @'
			if (double.IsNaN(num4) || double.IsInfinity(num4) || double.IsNaN(num5) || double.IsInfinity(num5) || num5 <= 1E-9)
			{
				return false;
			}
			num2 = Convert.ToInt32(Math.Ceiling(num4 / num5));
'@
    if ($text.Contains($oldStep)) {
        $text = $text.Replace($oldStep, $newStep)
        "FIX MarbleItemEntitiesCalculation invalid/zero step-down divisor: $marblePath" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($marblePath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
} else {
    "MISS $marblePath" | Tee-Object -Append $log
}

$routerPath = 'Decompiled/buCadCamRes/buCadCamResVer5/Router3AX/clsRouter3AX.cs'
if (Test-Path -LiteralPath $routerPath) {
    $text = [IO.File]::ReadAllText($routerPath)
    $original = $text

    # The decompiled method computes the IJK norm and discards it, then calls
    # asin(I) directly. Normalize first, reject a zero/non-finite vector and
    # clamp I to the legal asin domain. For a normalized vector atan2(J,K) is
    # algebraically equivalent to atan2(J/cos(B), K/cos(B)) whenever cos(B)>0,
    # while also avoiding the pole division.
    $old = @'
	public static void ConvertIJKToBC(double I, double J, double K, out double B_deg, out double C_deg)
	{
		Math.Sqrt(I * I + J * J + K * K);
		double num = Math.Asin(I);
		double num2 = Math.Cos(num);
		double num3 = Math.Atan2(J / num2, K / num2);
		B_deg = num * 180.0 / Math.PI;
		C_deg = num3 * 180.0 / Math.PI;
	}
'@
    $new = @'
	public static void ConvertIJKToBC(double I, double J, double K, out double B_deg, out double C_deg)
	{
		double norm = Math.Sqrt(I * I + J * J + K * K);
		if (double.IsNaN(norm) || double.IsInfinity(norm) || norm <= 1E-12)
		{
			B_deg = 0.0;
			C_deg = 0.0;
			return;
		}
		I /= norm;
		J /= norm;
		K /= norm;
		I = Math.Max(-1.0, Math.Min(1.0, I));
		double bRad = Math.Asin(I);
		double cRad = Math.Abs(Math.Cos(bRad)) <= 1E-12 ? 0.0 : Math.Atan2(J, K);
		B_deg = bRad * 180.0 / Math.PI;
		C_deg = cRad * 180.0 / Math.PI;
	}
'@
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        "FIX Router3AX ConvertIJKToBC normalization/domain/pole guards: $routerPath" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($routerPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
} else {
    "MISS $routerPath" | Tee-Object -Append $log
}

$vectorPath = 'Decompiled/buCore/buCore/buVector.cs'
if (Test-Path -LiteralPath $vectorPath) {
    $text = [IO.File]::ReadAllText($vectorPath)
    $original = $text

    # Verified against the previously repaired buCore IL. The first
    # EllipseWithCenter overload is void and receives Center, MajorRadius,
    # MinorRadius, Angle, Plane, EntResolution and Vertices. Invalid center,
    # non-finite radius/angle values and degenerate radii must return before
    # geometry generation.
    $ellipsePattern = '(?s)(public\s+void\s+EllipseWithCenter\s*\(\s*(?:buClass\.)?Pnt3D\s+Center\s*,\s*double\s+MajorRadius\s*,\s*double\s+MinorRadius\s*,\s*double\s+Angle\s*,.*?\)\s*\{\s*)(?!if\s*\(Center\s*==\s*null)'
    $ellipseGuard = "if (Center == null || double.IsNaN(MajorRadius) || double.IsInfinity(MajorRadius) ||`r`n`t`t`tdouble.IsNaN(MinorRadius) || double.IsInfinity(MinorRadius) ||`r`n`t`t`tdouble.IsNaN(Angle) || double.IsInfinity(Angle) ||`r`n`t`t`tMajorRadius <= 1E-09 || MinorRadius <= 1E-09)`r`n`t`t`treturn;`r`n`t`t"
    $ellipseRegex = [regex]::new($ellipsePattern, [Text.RegularExpressions.RegexOptions]::Singleline)
    $text = $ellipseRegex.Replace($text, ('$1' + $ellipseGuard), 1)
    if ($text -ne $original) {
        "FIX buVector EllipseWithCenter null/non-finite/degenerate geometry guard: $vectorPath" | Tee-Object -Append $log
        [IO.File]::WriteAllText($vectorPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    } else {
        "NO_MATCH_OR_ALREADY_FIXED buVector EllipseWithCenter: $vectorPath" | Tee-Object -Append $log
    }
} else {
    "MISS $vectorPath" | Tee-Object -Append $log
}

"Patched math files: $patched" | Tee-Object -Append $log
