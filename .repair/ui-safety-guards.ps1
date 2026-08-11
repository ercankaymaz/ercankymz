$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/ui-safety-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$vacuumPath = 'Decompiled/buControls/buControls/Forms/WinControlForms/Grinding/F_GrindingAddVacuum.cs'
if (Test-Path -LiteralPath $vacuumPath) {
    $text = [IO.File]::ReadAllText($vacuumPath)
    $original = $text

    # Persisted operation values may be outside the designer NumericUpDown
    # min/max range (or non-finite after a damaged/legacy data load). Direct
    # Value assignment then throws ArgumentOutOfRangeException/OverflowException.
    $oldInit = @'
		numericUpDown_1.Value = (decimal)Operation.VacuumThickness;
		numericUpDown_2.Value = (decimal)Operation.VacuumHeight;
		numericUpDown_0.Value = (decimal)Operation.VacuumDiameter;
'@
    $newInit = @'
		double vacuumThickness = double.IsNaN(Operation.VacuumThickness) || double.IsInfinity(Operation.VacuumThickness) ? (double)numericUpDown_1.Minimum : Operation.VacuumThickness;
		double vacuumHeight = double.IsNaN(Operation.VacuumHeight) || double.IsInfinity(Operation.VacuumHeight) ? (double)numericUpDown_2.Minimum : Operation.VacuumHeight;
		double vacuumDiameter = double.IsNaN(Operation.VacuumDiameter) || double.IsInfinity(Operation.VacuumDiameter) ? (double)numericUpDown_0.Minimum : Operation.VacuumDiameter;
		numericUpDown_1.Value = (decimal)Math.Min((double)numericUpDown_1.Maximum, Math.Max((double)numericUpDown_1.Minimum, vacuumThickness));
		numericUpDown_2.Value = (decimal)Math.Min((double)numericUpDown_2.Maximum, Math.Max((double)numericUpDown_2.Minimum, vacuumHeight));
		numericUpDown_0.Value = (decimal)Math.Min((double)numericUpDown_0.Maximum, Math.Max((double)numericUpDown_0.Minimum, vacuumDiameter));
'@
    if ($text.Contains($oldInit)) {
        $text = $text.Replace($oldInit, $newInit)
        "FIX Grinding vacuum persisted numeric values clamp/non-finite guard: $vacuumPath" | Tee-Object -Append $log
    }

    # ComboBox text comes from UI/presets and can be empty, localized or stale.
    # Never let an invalid selection crash the form event; keep the last valid
    # NumericUpDown value unless the text parses and fits its configured range.
    $oldCombo = @'
	internal void method_4(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
			numericUpDown_0.Value = Convert.ToDecimal(comboBox_0.Text);
		}
	}
'@
    $newCombo = @'
	internal void method_4(object sender, EventArgs e)
	{
		if (Properties.Inited && decimal.TryParse(comboBox_0.Text, out decimal diameter) && diameter >= numericUpDown_0.Minimum && diameter <= numericUpDown_0.Maximum)
		{
			numericUpDown_0.Value = diameter;
		}
	}
'@
    if ($text.Contains($oldCombo)) {
        $text = $text.Replace($oldCombo, $newCombo)
        "FIX Grinding vacuum stale/invalid preset selection parse guard: $vacuumPath" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($vacuumPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    } else {
        "NO_MATCH_OR_ALREADY_FIXED Grinding vacuum form: $vacuumPath" | Tee-Object -Append $log
    }
} else {
    "MISS $vacuumPath" | Tee-Object -Append $log
}

"Patched UI files: $patched" | Tee-Object -Append $log
