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

"Patched math files: $patched" | Tee-Object -Append $log
