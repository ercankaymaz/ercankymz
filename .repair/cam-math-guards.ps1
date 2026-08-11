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

"Patched math files: $patched" | Tee-Object -Append $log
