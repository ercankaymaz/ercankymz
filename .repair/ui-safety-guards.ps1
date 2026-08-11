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

# Metric single-cut validates varOperations.TargetZ before the decompiled form
# helper copies the current spinner values into varOperations. This can approve
# a newly-entered invalid depth because the comparison sees the previous value.
$singleCutPath = 'Decompiled/buControls/buControls/Forms/buControlForms/Marble/F_SingleCut.cs'
if (Test-Path -LiteralPath $singleCutPath) {
    $text = [IO.File]::ReadAllText($singleCutPath)
    $original = $text
    $old = @'
		if (control.Name == buButton_3.Name)
		{
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
			Class76.smethod_825(this);
'@
    $new = @'
		if (control.Name == buButton_3.Name)
		{
			Class76.smethod_825(this);
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
'@
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        "FIX F_SingleCut synchronize input model before TargetZ validation: $singleCutPath" | Tee-Object -Append $log
    }
    if ($text -ne $original) {
        [IO.File]::WriteAllText($singleCutPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
} else {
    "MISS $singleCutPath" | Tee-Object -Append $log
}

# Inch form has the identical ordering bug; smethod_803 also performs the inch
# conversion, so it must run before validating the converted operation value.
$singleCutInchPath = 'Decompiled/buControls/buControls/Forms/buControlForms/Marble/F_SingleCutInch.cs'
if (Test-Path -LiteralPath $singleCutInchPath) {
    $text = [IO.File]::ReadAllText($singleCutInchPath)
    $original = $text
    $old = @'
		if (control.Name == buButton_3.Name)
		{
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
			Class76.smethod_803(this);
'@
    $new = @'
		if (control.Name == buButton_3.Name)
		{
			Class76.smethod_803(this);
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
'@
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        "FIX F_SingleCutInch synchronize/convert input before TargetZ validation: $singleCutInchPath" | Tee-Object -Append $log
    }
    if ($text -ne $original) {
        [IO.File]::WriteAllText($singleCutInchPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
} else {
    "MISS $singleCutInchPath" | Tee-Object -Append $log
}

# Vertical end-position event checks handler_1 but invokes handler_3. If only the
# intended vertical handler is attached the event is silently skipped; if handler_1
# is attached while handler_3 is null the click can throw NullReferenceException.
$perpendicularPath = 'Decompiled/buControls/buControls/Forms/buControlForms/Marble/F_PerpendicularCut.cs'
if (Test-Path -LiteralPath $perpendicularPath) {
    $text = [IO.File]::ReadAllText($perpendicularPath)
    $original = $text
    $old = @'
			if (marbleSetStartPositionHandler_1 != null)
			{
				marbleSetStartPositionHandler_3(EndPosVer);
			}
'@
    $new = @'
			if (marbleSetStartPositionHandler_3 != null)
			{
				marbleSetStartPositionHandler_3(EndPosVer);
			}
'@
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        "FIX F_PerpendicularCut vertical end-position event null-check wiring: $perpendicularPath" | Tee-Object -Append $log
    }
    if ($text -ne $original) {
        [IO.File]::WriteAllText($perpendicularPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
} else {
    "MISS $perpendicularPath" | Tee-Object -Append $log
}

"Patched UI files: $patched" | Tee-Object -Append $log
