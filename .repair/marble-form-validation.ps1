$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/marble-form-validation.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buControls/buControls/Forms/buControlForms/Marble/F_ItemCutCamParameters.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

$old = @'
	internal void method_1(object sender, EventArgs e)
	{
		Value.CamParameters.BackwardCuttingVelocity = spn_bwdvel.Value;
		Value.CamParameters.ForwardCuttingVelocity = spn_fwdvel.Value;
		Value.CamParameters.FirstEnterDistance = spn_leadin.Value;
		Value.CamParameters.LastOutDistance = spn_leadout.Value;
		Value.CamParameters.PlungeVelocity = spn_plungevel.Value;
		Value.CamParameters.LeaveVelocity = spn_leavevel.Value;
		Value.MaterialThickness = spn_matthickness.Value;
		Value.CamParameters.ForwardStepDownDistance = spn_forwardcutstep.Value;
		Value.CamParameters.BackwardStepDownDistance = spn_backwardcutstep.Value;
		Value.CamParameters.SafeDistance = spn_safedistance.Value;
		Value.CamParameters.StepUpDistance = spn_stepupdistance.Value;
		Value.CamParameters.CuttingDirection = (CamCuttingDirectionType)buGeneral.EnumValueFromInt(Value.CamParameters.CuttingDirection, cmb_cutdir.SelectedIndex);
'@
$new = @'
	internal void method_1(object sender, EventArgs e)
	{
		if (Value == null || Value.CamParameters == null)
		{
			return;
		}
		if (cmb_cutdir.SelectedIndex < 0)
		{
			buString.MessageBoxWarning(cmb_cutdir.Caption.Caption);
			return;
		}
		if (double.IsNaN(spn_matthickness.Value) || double.IsInfinity(spn_matthickness.Value) || spn_matthickness.Value <= 0.0)
		{
			buString.MessageBoxWarning(spn_matthickness.Caption.Caption + " > 0");
			return;
		}
		CamCuttingDirectionType selectedDirection = (CamCuttingDirectionType)buGeneral.EnumValueFromInt(Value.CamParameters.CuttingDirection, cmb_cutdir.SelectedIndex);
		if ((selectedDirection == CamCuttingDirectionType.Forward || selectedDirection == CamCuttingDirectionType.ForwardBackward) &&
			(double.IsNaN(spn_forwardcutstep.Value) || double.IsInfinity(spn_forwardcutstep.Value) || spn_forwardcutstep.Value <= 0.0))
		{
			buString.MessageBoxWarning(spn_forwardcutstep.Caption.Caption + " > 0");
			return;
		}
		if ((selectedDirection == CamCuttingDirectionType.Backward || selectedDirection == CamCuttingDirectionType.ForwardBackward) &&
			(double.IsNaN(spn_backwardcutstep.Value) || double.IsInfinity(spn_backwardcutstep.Value) || spn_backwardcutstep.Value <= 0.0))
		{
			buString.MessageBoxWarning(spn_backwardcutstep.Caption.Caption + " > 0");
			return;
		}
		Value.CamParameters.BackwardCuttingVelocity = spn_bwdvel.Value;
		Value.CamParameters.ForwardCuttingVelocity = spn_fwdvel.Value;
		Value.CamParameters.FirstEnterDistance = spn_leadin.Value;
		Value.CamParameters.LastOutDistance = spn_leadout.Value;
		Value.CamParameters.PlungeVelocity = spn_plungevel.Value;
		Value.CamParameters.LeaveVelocity = spn_leavevel.Value;
		Value.MaterialThickness = spn_matthickness.Value;
		Value.CamParameters.ForwardStepDownDistance = spn_forwardcutstep.Value;
		Value.CamParameters.BackwardStepDownDistance = spn_backwardcutstep.Value;
		Value.CamParameters.SafeDistance = spn_safedistance.Value;
		Value.CamParameters.StepUpDistance = spn_stepupdistance.Value;
		Value.CamParameters.CuttingDirection = selectedDirection;
'@

if ($text.Contains($old)) {
    $text = $text.Replace($old, $new)
    "FIX F_ItemCutCamParameters direction/material/step-down validation before OK: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    'PATCHED marble CAM parameter form validation' | Tee-Object -Append $log
} else {
    'NO_MATCH_OR_ALREADY_FIXED' | Tee-Object -Append $log
}
