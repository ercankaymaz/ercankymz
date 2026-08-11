$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/grinding-ui-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buControls/buControls/Forms/WinControlForms/Grinding/F_CamGrindingContourClosed.cs'
if (Test-Path -LiteralPath $path) {
    $text = [IO.File]::ReadAllText($path)
    $original = $text

    # Invisible/reused forms kept old list/text/combo contents when SelectedTool
    # became invalid. Clear state on every Init and explicitly synchronize the
    # LeadIn/LeadOut length controls that the original Init forgot to update.
    if ($text -notmatch 'CADCAM_REPAIR_GRINDING_CLOSED_TOOL_STATE') {
        $pattern = '(?m)^(\s*)if \(\(SelectedTool >= 0\) & \(SelectedTool <= Tools\.Count - 1\)\)'
        $replacement = @'
$1// CADCAM_REPAIR_GRINDING_CLOSED_TOOL_STATE
$1listBox_0.Items.Clear();
$1listBox_0.SelectedIndex = -1;
$1comboBox_3.Items.Clear();
$1comboBox_3.SelectedIndex = -1;
$1textBox_0.Clear();
$1label_16.Enabled = comboBox_1.SelectedIndex == 1;
$1numericUpDown_15.Enabled = comboBox_1.SelectedIndex == 1;
$1label_15.Enabled = comboBox_0.SelectedIndex == 1;
$1numericUpDown_14.Enabled = comboBox_0.SelectedIndex == 1;
$1if ((SelectedTool >= 0) & (SelectedTool <= Tools.Count - 1))
'@
        $rx = [regex]::new($pattern)
        $updated = $rx.Replace($text, $replacement, 1)
        if ($updated -ne $text) {
            $text = $updated
            "FIX closed contour stale tool/hole combo and initial lead state: $path" | Tee-Object -Append $log
        }
    }

    # SelectionChanged can fire with SelectedIndex=-1 while Items are cleared or
    # rebound. The decompiled handler indexed Tools[-1] immediately.
    $selectionPattern = '(?s)\tinternal void method_4\(object sender, EventArgs e\)\s*\{.*?\n\t\}\s*\n\s*\tinternal void method_5'
    $selectionReplacement = @'
	internal void method_4(object sender, EventArgs e)
	{
		if (!Properties.Inited)
		{
			return;
		}
		int index = listBox_0.SelectedIndex;
		if (Tools == null || index < 0 || index >= Tools.Count || Tools[index] == null)
		{
			SelectedTool = -1;
			textBox_0.Clear();
			return;
		}
		SelectedTool = index;
		textBox_0.Text = buGeneral.GetToolExplanation(Tools[index]);
	}

	internal void method_5
'@
    $rxSelection = [regex]::new($selectionPattern, [Text.RegularExpressions.RegexOptions]::Singleline)
    $updated = $rxSelection.Replace($text, $selectionReplacement, 1)
    if ($updated -ne $text) {
        $text = $updated
        "FIX closed contour SelectedIndex -1/out-of-range tool access: $path" | Tee-Object -Append $log
    }

    # Touch-pad and button/combo handlers should ignore a miswired sender rather
    # than throw InvalidCastException.
    $touchPattern = '(?s)\tinternal void method_3\(object sender, EventArgs e\)\s*\{.*?\n\t\}\s*\n\s*\tinternal void method_4'
    $touchReplacement = @'
	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.TouchPad && sender is NumericUpDown numericUpDown)
		{
			buControlCommands.ShowKeyPadWinControl(this, numericUpDown);
		}
	}

	internal void method_4
'@
    $rxTouch = [regex]::new($touchPattern, [Text.RegularExpressions.RegexOptions]::Singleline)
    $updated = $rxTouch.Replace($text, $touchReplacement, 1)
    if ($updated -ne $text) {
        $text = $updated
        "FIX closed contour touch-pad sender cast: $path" | Tee-Object -Append $log
    }

    $castPattern = '(?m)^\t\tControl control = new Control\(\);\r?\n\t\tcontrol = \(Control\)sender;'
    $castReplacement = "`t`tif (!(sender is Control control))`r`n`t`t{`r`n`t`t`treturn;`r`n`t`t}"
    $updated = [regex]::Replace($text, $castPattern, $castReplacement)
    if ($updated -ne $text) {
        $text = $updated
        "FIX closed contour button/combo sender casts: $path" | Tee-Object -Append $log
    }

    # Opening nested hole CAM with a null tool collection previously dereferenced
    # Tools.Count. Invalid selected-tool indices are safe in the repaired hole form.
    if ($text -notmatch 'CADCAM_REPAIR_GRINDING_CLOSED_HOLE_TOOLS') {
        $holePattern = '(?s)(\t\tif \(control\.Name == btn_holecamdata\.Name\)\s*\{\s*)'
        $holeReplacement = @'
$1			// CADCAM_REPAIR_GRINDING_CLOSED_HOLE_TOOLS
			if (Tools == null)
			{
				return;
			}
'@
        $rxHole = [regex]::new($holePattern, [Text.RegularExpressions.RegexOptions]::Singleline)
        $updated = $rxHole.Replace($text, $holeReplacement, 1)
        if ($updated -ne $text) {
            $text = $updated
            "FIX closed contour null Tools before nested hole CAM: $path" | Tee-Object -Append $log
        }
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
} else {
    "MISS $path" | Tee-Object -Append $log
}

"Patched grinding UI files: $patched" | Tee-Object -Append $log
