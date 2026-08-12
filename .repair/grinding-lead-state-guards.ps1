$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/grinding-lead-state-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

function Patch-LeadStateForm {
    param(
        [string]$Path,
        [string]$LeadInCombo,
        [string]$LeadInCheck,
        [string]$LeadOutCombo,
        [string]$LeadOutCheck,
        [string]$LeadInBodyOld,
        [string]$LeadInBodyNew,
        [string]$LeadOutBodyOld,
        [string]$LeadOutBodyNew
    )

    if (-not (Test-Path -LiteralPath $Path)) {
        "MISS $Path" | Tee-Object -Append $log
        return $false
    }

    $text = [IO.File]::ReadAllText($Path)
    $original = $text
    if ($text.Contains($LeadInBodyOld)) {
        $text = $text.Replace($LeadInBodyOld, $LeadInBodyNew)
        "FIX LeadIn enable/type UI state: $Path" | Tee-Object -Append $log
    }
    if ($text.Contains($LeadOutBodyOld)) {
        $text = $text.Replace($LeadOutBodyOld, $LeadOutBodyNew)
        "FIX LeadOut enable/type UI state: $Path" | Tee-Object -Append $log
    }

    $oldLeadInHandler = "`t`tif (control.Name == $LeadInCombo.Name)`n`t`t{`n`t`t`tUpdateLeadInState();`n`t`t}"
    $newLeadInHandler = "`t`tif (control.Name == $LeadInCombo.Name || control.Name == $LeadInCheck.Name)`n`t`t{`n`t`t`tUpdateLeadInState();`n`t`t}"
    if ($text.Contains($oldLeadInHandler)) {
        $text = $text.Replace($oldLeadInHandler, $newLeadInHandler)
        "FIX LeadIn checkbox event state synchronization: $Path" | Tee-Object -Append $log
    }

    $oldLeadOutHandler = "`t`tif (control.Name == $LeadOutCombo.Name)`n`t`t{`n`t`t`tUpdateLeadOutState();`n`t`t}"
    $newLeadOutHandler = "`t`tif (control.Name == $LeadOutCombo.Name || control.Name == $LeadOutCheck.Name)`n`t`t{`n`t`t`tUpdateLeadOutState();`n`t`t}"
    if ($text.Contains($oldLeadOutHandler)) {
        $text = $text.Replace($oldLeadOutHandler, $newLeadOutHandler)
        "FIX LeadOut checkbox event state synchronization: $Path" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($Path, $text, [Text.UTF8Encoding]::new($false))
        return $true
    }
    "NO_MATCH_OR_ALREADY_FIXED lead state: $Path" | Tee-Object -Append $log
    return $false
}

$openPath = 'Decompiled/buControls/buControls/Forms/WinControlForms/Grinding/F_CamGrindingContourOpen.cs'
$openLeadInOld = @'
	private void UpdateLeadInState()
	{
		bool tangent = comboBox_2.SelectedIndex == 1;
		label_11.Enabled = tangent;
		label_9.Enabled = tangent;
		label_17.Enabled = !tangent;
		label_13.Enabled = !tangent;
		numericUpDown_9.Enabled = tangent;
		numericUpDown_7.Enabled = tangent;
		numericUpDown_11.Enabled = !tangent;
		numericUpDown_15.Enabled = !tangent;
	}
'@
$openLeadInNew = @'
	private void UpdateLeadInState()
	{
		bool enabled = checkBox_2.Checked;
		bool tangent = comboBox_2.SelectedIndex == 1;
		comboBox_2.Enabled = enabled;
		label_11.Enabled = enabled && tangent;
		label_9.Enabled = enabled && tangent;
		label_17.Enabled = enabled && !tangent;
		label_13.Enabled = enabled && !tangent;
		numericUpDown_9.Enabled = enabled && tangent;
		numericUpDown_7.Enabled = enabled && tangent;
		numericUpDown_11.Enabled = enabled && !tangent;
		numericUpDown_15.Enabled = enabled && !tangent;
	}
'@
$openLeadOutOld = @'
	private void UpdateLeadOutState()
	{
		bool tangent = comboBox_1.SelectedIndex == 1;
		label_10.Enabled = tangent;
		label_8.Enabled = tangent;
		label_15.Enabled = !tangent;
		label_12.Enabled = !tangent;
		numericUpDown_8.Enabled = tangent;
		numericUpDown_6.Enabled = tangent;
		numericUpDown_10.Enabled = !tangent;
		numericUpDown_13.Enabled = !tangent;
	}
'@
$openLeadOutNew = @'
	private void UpdateLeadOutState()
	{
		bool enabled = checkBox_1.Checked;
		bool tangent = comboBox_1.SelectedIndex == 1;
		comboBox_1.Enabled = enabled;
		label_10.Enabled = enabled && tangent;
		label_8.Enabled = enabled && tangent;
		label_15.Enabled = enabled && !tangent;
		label_12.Enabled = enabled && !tangent;
		numericUpDown_8.Enabled = enabled && tangent;
		numericUpDown_6.Enabled = enabled && tangent;
		numericUpDown_10.Enabled = enabled && !tangent;
		numericUpDown_13.Enabled = enabled && !tangent;
	}
'@
if (Patch-LeadStateForm $openPath 'comboBox_2' 'checkBox_2' 'comboBox_1' 'checkBox_1' $openLeadInOld $openLeadInNew $openLeadOutOld $openLeadOutNew) { $patched++ }

$pocketPath = 'Decompiled/buControls/buControls/Forms/WinControlForms/Grinding/F_CamGrindingPocket.cs'
$pocketLeadInOld = @'
	private void UpdateLeadInState()
	{
		bool tangent = comboBox_1.SelectedIndex == 1;
		label_14.Enabled = tangent;
		label_16.Enabled = tangent;
		label_4.Enabled = !tangent;
		label_7.Enabled = !tangent;
		numericUpDown_13.Enabled = tangent;
		numericUpDown_15.Enabled = tangent;
		numericUpDown_7.Enabled = !tangent;
		numericUpDown_4.Enabled = !tangent;
	}
'@
$pocketLeadInNew = @'
	private void UpdateLeadInState()
	{
		bool enabled = checkBox_1.Checked;
		bool tangent = comboBox_1.SelectedIndex == 1;
		comboBox_1.Enabled = enabled;
		label_14.Enabled = enabled && tangent;
		label_16.Enabled = enabled && tangent;
		label_4.Enabled = enabled && !tangent;
		label_7.Enabled = enabled && !tangent;
		numericUpDown_13.Enabled = enabled && tangent;
		numericUpDown_15.Enabled = enabled && tangent;
		numericUpDown_7.Enabled = enabled && !tangent;
		numericUpDown_4.Enabled = enabled && !tangent;
	}
'@
$pocketLeadOutOld = @'
	private void UpdateLeadOutState()
	{
		bool tangent = comboBox_0.SelectedIndex == 1;
		label_13.Enabled = tangent;
		label_15.Enabled = tangent;
		label_2.Enabled = !tangent;
		label_6.Enabled = !tangent;
		numericUpDown_12.Enabled = tangent;
		numericUpDown_14.Enabled = tangent;
		numericUpDown_6.Enabled = !tangent;
		numericUpDown_2.Enabled = !tangent;
	}
'@
$pocketLeadOutNew = @'
	private void UpdateLeadOutState()
	{
		bool enabled = checkBox_0.Checked;
		bool tangent = comboBox_0.SelectedIndex == 1;
		comboBox_0.Enabled = enabled;
		label_13.Enabled = enabled && tangent;
		label_15.Enabled = enabled && tangent;
		label_2.Enabled = enabled && !tangent;
		label_6.Enabled = enabled && !tangent;
		numericUpDown_12.Enabled = enabled && tangent;
		numericUpDown_14.Enabled = enabled && tangent;
		numericUpDown_6.Enabled = enabled && !tangent;
		numericUpDown_2.Enabled = enabled && !tangent;
	}
'@
if (Patch-LeadStateForm $pocketPath 'comboBox_1' 'checkBox_1' 'comboBox_0' 'checkBox_0' $pocketLeadInOld $pocketLeadInNew $pocketLeadOutOld $pocketLeadOutNew) { $patched++ }

# Add-pin/vacuum button handlers inherited a decompiler direct cast. A future or
# accidental event rewire with a non-Control sender must not crash the form.
foreach ($eventPath in @(
    'Decompiled/buControls/buControls/Forms/WinControlForms/Grinding/F_GrindingAddPin.cs',
    'Decompiled/buControls/buControls/Forms/WinControlForms/Grinding/F_GrindingAddVacuum.cs')) {
    if (-not (Test-Path -LiteralPath $eventPath)) {
        "MISS $eventPath" | Tee-Object -Append $log
        continue
    }
    $eventText = [IO.File]::ReadAllText($eventPath)
    $eventOriginal = $eventText
    $oldCast = "`t`tControl control = new Control();`n`t`tcontrol = (Control)sender;"
    $newCast = "`t`tif (!(sender is Control control))`n`t`t{`n`t`t`treturn;`n`t`t}"
    if ($eventText.Contains($oldCast)) {
        $eventText = $eventText.Replace($oldCast, $newCast)
        "FIX safe button sender cast: $eventPath" | Tee-Object -Append $log
    }
    if ($eventText -ne $eventOriginal) {
        [IO.File]::WriteAllText($eventPath, $eventText, [Text.UTF8Encoding]::new($false))
        $patched++
    }
}

"Patched grinding lead/runtime files: $patched" | Tee-Object -Append $log
