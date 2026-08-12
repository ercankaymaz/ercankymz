$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/grinding-closed-guards.txt'
Remove-Item $log -ErrorAction Ignore
$path = 'Decompiled/buControls/buControls/Forms/WinControlForms/Grinding/F_CamGrindingContourClosed.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# Closed-contour persisted CAM values were still assigned directly to
# NumericUpDown.Value. Corrupt/legacy NaN, Infinity or out-of-range values can
# throw before the form becomes usable. Add the same clamped loader used by the
# repaired open-contour/pocket forms, plus one deterministic lead-state helper.
if ($text -notmatch 'private static void SetNumericValueSafe\(NumericUpDown control, double value\)') {
    $anchor = "`tinternal void method_1(object sender, EventArgs e)"
    if (-not $text.Contains($anchor)) { throw 'Closed grinding method_1 anchor missing.' }
    $helpers = @'
	private static void SetNumericValueSafe(NumericUpDown control, double value)
	{
		if (control == null || double.IsNaN(value) || double.IsInfinity(value))
			return;
		decimal converted;
		try
		{
			converted = Convert.ToDecimal(value);
		}
		catch (OverflowException)
		{
			return;
		}
		if (converted < control.Minimum)
			converted = control.Minimum;
		else if (converted > control.Maximum)
			converted = control.Maximum;
		control.Value = converted;
	}

	private void UpdateLeadStateSafe()
	{
		bool leadInEnabled = checkBox_1.Checked;
		bool leadInTangent = comboBox_1.SelectedIndex == 1;
		comboBox_1.Enabled = leadInEnabled;
		label_14.Enabled = leadInEnabled && leadInTangent;
		label_16.Enabled = leadInEnabled && leadInTangent;
		label_4.Enabled = leadInEnabled && !leadInTangent;
		label_7.Enabled = leadInEnabled && !leadInTangent;
		numericUpDown_13.Enabled = leadInEnabled && leadInTangent;
		numericUpDown_15.Enabled = leadInEnabled && leadInTangent;
		numericUpDown_7.Enabled = leadInEnabled && !leadInTangent;
		numericUpDown_4.Enabled = leadInEnabled && !leadInTangent;

		bool leadOutEnabled = checkBox_0.Checked;
		bool leadOutTangent = comboBox_0.SelectedIndex == 1;
		comboBox_0.Enabled = leadOutEnabled;
		label_13.Enabled = leadOutEnabled && leadOutTangent;
		label_15.Enabled = leadOutEnabled && leadOutTangent;
		label_2.Enabled = leadOutEnabled && !leadOutTangent;
		label_6.Enabled = leadOutEnabled && !leadOutTangent;
		numericUpDown_12.Enabled = leadOutEnabled && leadOutTangent;
		numericUpDown_14.Enabled = leadOutEnabled && leadOutTangent;
		numericUpDown_6.Enabled = leadOutEnabled && !leadOutTangent;
		numericUpDown_2.Enabled = leadOutEnabled && !leadOutTangent;
	}

'@
    $text = $text.Replace($anchor, $helpers + $anchor)
    "FIX closed contour safe numeric loader and lead-state helper: $path" | Tee-Object -Append $log
}

$replacements = [ordered]@{
    'numericUpDown_0.Value = (decimal)camPars.Operations.TargetZ;' = 'SetNumericValueSafe(numericUpDown_0, camPars.Operations.TargetZ);'
    'numericUpDown_16.Value = (decimal)camPars.Offsets.OverlapDistance;' = 'SetNumericValueSafe(numericUpDown_16, camPars.Offsets.OverlapDistance);'
    'numericUpDown_5.Value = (decimal)camPars.Offsets.Offset;' = 'SetNumericValueSafe(numericUpDown_5, camPars.Offsets.Offset);'
    'numericUpDown_17.Value = camPars.Offsets.OffsetCount;' = 'SetNumericValueSafe(numericUpDown_17, camPars.Offsets.OffsetCount);'
    'numericUpDown_10.Value = (decimal)camPars.Speeds.Feed;' = 'SetNumericValueSafe(numericUpDown_10, camPars.Speeds.Feed);'
    'numericUpDown_8.Value = (decimal)camPars.Speeds.Leave;' = 'SetNumericValueSafe(numericUpDown_8, camPars.Speeds.Leave);'
    'numericUpDown_9.Value = (decimal)camPars.Speeds.Plunge;' = 'SetNumericValueSafe(numericUpDown_9, camPars.Speeds.Plunge);'
    'numericUpDown_11.Value = (decimal)camPars.Distances.Safe;' = 'SetNumericValueSafe(numericUpDown_11, camPars.Distances.Safe);'
    'numericUpDown_3.Value = (decimal)camPars.LeadIn.ExtendLength;' = 'SetNumericValueSafe(numericUpDown_3, camPars.LeadIn.ExtendLength);'
    'numericUpDown_4.Value = (decimal)camPars.LeadIn.ArcRadius;' = 'SetNumericValueSafe(numericUpDown_4, camPars.LeadIn.ArcRadius);'
    'numericUpDown_7.Value = (decimal)camPars.LeadIn.ArcSweepAngle;' = 'SetNumericValueSafe(numericUpDown_7, camPars.LeadIn.ArcSweepAngle);'
    'numericUpDown_13.Value = (decimal)camPars.LeadIn.TangentAngle;' = 'SetNumericValueSafe(numericUpDown_13, camPars.LeadIn.TangentAngle);'
    'numericUpDown_15.Value = (decimal)camPars.LeadIn.Length;' = 'SetNumericValueSafe(numericUpDown_15, camPars.LeadIn.Length);'
    'numericUpDown_1.Value = (decimal)camPars.LeadOut.ExtendLength;' = 'SetNumericValueSafe(numericUpDown_1, camPars.LeadOut.ExtendLength);'
    'numericUpDown_2.Value = (decimal)camPars.LeadOut.ArcRadius;' = 'SetNumericValueSafe(numericUpDown_2, camPars.LeadOut.ArcRadius);'
    'numericUpDown_6.Value = (decimal)camPars.LeadOut.ArcSweepAngle;' = 'SetNumericValueSafe(numericUpDown_6, camPars.LeadOut.ArcSweepAngle);'
    'numericUpDown_12.Value = (decimal)camPars.LeadOut.TangentAngle;' = 'SetNumericValueSafe(numericUpDown_12, camPars.LeadOut.TangentAngle);'
    'numericUpDown_14.Value = (decimal)camPars.LeadOut.Length;' = 'SetNumericValueSafe(numericUpDown_14, camPars.LeadOut.Length);'
    'numericUpDown_18.Value = (decimal)Operation.IndiseOperationHoleDistance;' = 'SetNumericValueSafe(numericUpDown_18, Operation.IndiseOperationHoleDistance);'
}
foreach ($entry in $replacements.GetEnumerator()) {
    if ($text.Contains($entry.Key)) {
        $text = $text.Replace($entry.Key, $entry.Value)
    }
}

# Apply lead enable/type state after the legacy Init type blocks have finished.
$initTail = "`t`tcheckBox_3.Checked = Operation.InsideOperationHoleEnable;`n`t`tRefresh();"
if ($text.Contains($initTail) -and -not $text.Contains("checkBox_3.Checked = Operation.InsideOperationHoleEnable;`n`t`tUpdateLeadStateSafe();")) {
    $text = $text.Replace($initTail, "`t`tcheckBox_3.Checked = Operation.InsideOperationHoleEnable;`n`t`tUpdateLeadStateSafe();`n`t`tRefresh();")
    "FIX closed contour initial LeadIn/LeadOut enable synchronization: $path" | Tee-Object -Append $log
}

# The empty method_2 is the decompiled value/check change hook. Make any lead
# enable checkbox change recalculate the complete parameter enabled state.
$oldMethod2 = @'
	internal void method_2(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
		}
	}
'@
$newMethod2 = @'
	internal void method_2(object sender, EventArgs e)
	{
		if (Properties.Inited)
			UpdateLeadStateSafe();
	}
'@
if ($text.Contains($oldMethod2)) {
    $text = $text.Replace($oldMethod2, $newMethod2)
    "FIX closed contour checkbox/value state event: $path" | Tee-Object -Append $log
}

# Type-combo changes run through method_6. Re-apply the enable gate after its
# legacy tangent/arc branching so disabled lead sections cannot be re-enabled.
$method6Tail = "`t}`n`n`tinternal void method_7(object sender, EventArgs e)"
if ($text.Contains($method6Tail) -and -not $text.Contains("`t`tUpdateLeadStateSafe();`n`t}`n`n`tinternal void method_7")) {
    $text = $text.Replace($method6Tail, "`t`tUpdateLeadStateSafe();`n`t}`n`n`tinternal void method_7(object sender, EventArgs e)")
    "FIX closed contour lead type event final enable gate: $path" | Tee-Object -Append $log
}

# Guard tool collection/index state in the reused form. The earlier decompiled
# condition dereferenced Tools.Count even when a caller supplied Tools=null.
$oldToolCondition = 'if ((SelectedTool >= 0) & (SelectedTool <= Tools.Count - 1))'
$newToolCondition = 'if (Tools != null && SelectedTool >= 0 && SelectedTool < Tools.Count && Tools[SelectedTool] != null)'
if ($text.Contains($oldToolCondition)) {
    $text = $text.Replace($oldToolCondition, $newToolCondition)
    "FIX closed contour null/out-of-range selected tool gate: $path" | Tee-Object -Append $log
}

$oldToolLoop = @'
			for (int i = 0; i <= Tools.Count - 1; i++)
			{
				listBox_0.Items.Add(Tools[i].Data.Name + " - No : " + Tools[i].Data.No);
				comboBox_3.Items.Add(Tools[i].Data.Name + " - No : " + Tools[i].Data.No);
			}
'@
$newToolLoop = @'
			for (int i = 0; i <= Tools.Count - 1; i++)
			{
				ToolBase tool = Tools[i];
				string caption = tool != null && tool.Data != null ? tool.Data.Name + " - No : " + tool.Data.No : string.Empty;
				listBox_0.Items.Add(caption);
				comboBox_3.Items.Add(caption);
			}
'@
if ($text.Contains($oldToolLoop)) {
    $text = $text.Replace($oldToolLoop, $newToolLoop)
    "FIX closed contour null tool/data list rendering: $path" | Tee-Object -Append $log
}

# Do not persist an enabled inside-hole operation with SelectedIndex=-1.
$oldHoleCommit = @'
			Operation.IndiseOperationHoleDistance = (double)numericUpDown_18.Value;
			Operation.InsideOperationHoleEnable = checkBox_3.Checked;
			Operation.IndieOperationHoleTool = comboBox_3.SelectedIndex;
'@
$newHoleCommit = @'
			Operation.IndiseOperationHoleDistance = (double)numericUpDown_18.Value;
			Operation.InsideOperationHoleEnable = checkBox_3.Checked && comboBox_3.SelectedIndex >= 0;
			if (comboBox_3.SelectedIndex >= 0)
				Operation.IndieOperationHoleTool = comboBox_3.SelectedIndex;
'@
if ($text.Contains($oldHoleCommit)) {
    $text = $text.Replace($oldHoleCommit, $newHoleCommit)
    "FIX closed contour invalid enabled hole-tool selection: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    "Patched closed grinding contour" | Tee-Object -Append $log
} else {
    "NO_MATCH_OR_ALREADY_FIXED $path" | Tee-Object -Append $log
}
