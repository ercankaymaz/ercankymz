$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/tool-machine-ui-sync-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Forms/F_Tool.cs'
if (-not (Test-Path -LiteralPath $path)) {
  "FAIL missing tool form: $path" | Tee-Object $log
  exit 2
}

$text = [IO.File]::ReadAllText($path)
$original = $text

if ($text -notmatch 'private void RefreshMachineEnvelopeUiState\(') {
  $anchor = '  private void InitializeMachineEnvelopeControls()'
  if (-not $text.Contains($anchor)) { throw 'Machine-envelope initialization anchor not found.' }
  $helper = @'
  private void RefreshMachineEnvelopeUiState()
  {
    if (this.saveMachineLimitsButton != null)
      this.saveMachineLimitsButton.Enabled = AppSecurity.PasswordLevel >= 2;
    if (this.machineLimitsStatusLabel == null)
      return;
    string profileFile = this.GetMachineProfileFilePath();
    bool profileIsActive = FiveAxisPathSafety.HasConfiguredMachineEnvelope;
    bool profileFileExists = File.Exists(profileFile);
    this.machineLimitsStatusLabel.Text = profileIsActive
      ? "Machine profile: active"
      : (profileFileExists ? "Machine profile: saved, review required" : "Machine profile: not configured");
    this.machineLimitsStatusLabel.ForeColor = profileIsActive ? Color.DarkGreen : Color.DarkOrange;
  }

'@
  $text = $text.Replace($anchor, $helper + $anchor)
}

$oldEarly = @'
  private void InitializeMachineEnvelopeControls()
  {
    if (this.saveMachineLimitsButton != null)
      return;
'@
$newEarly = @'
  private void InitializeMachineEnvelopeControls()
  {
    if (this.saveMachineLimitsButton != null)
    {
      this.RefreshMachineEnvelopeUiState();
      return;
    }
'@
if ($text.Contains($oldEarly)) {
  $text = $text.Replace($oldEarly, $newEarly)
  "FIX refresh machine-limit permission/status on repeated Init" | Tee-Object -Append $log
}

$status = @'
    string profileFile = this.GetMachineProfileFilePath();
    bool profileIsActive = FiveAxisPathSafety.HasConfiguredMachineEnvelope;
    bool profileFileExists = File.Exists(profileFile);
    this.machineLimitsStatusLabel.Text = profileIsActive
      ? "Machine profile: active"
      : (profileFileExists ? "Machine profile: saved, review required" : "Machine profile: not configured");
    this.machineLimitsStatusLabel.ForeColor = profileIsActive ? Color.DarkGreen : Color.DarkOrange;
'@
if ($text.Contains($status)) {
  $text = $text.Replace($status, '    this.RefreshMachineEnvelopeUiState();')
}

if ($text -ne $original) {
  [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
}

$verified = [IO.File]::ReadAllText($path)
if ($verified -notmatch 'private void RefreshMachineEnvelopeUiState\(') { throw 'Machine-envelope UI refresh helper missing.' }
if ($verified -notmatch 'this\.saveMachineLimitsButton\.Enabled = AppSecurity\.PasswordLevel >= 2;') { throw 'Permission-state refresh missing.' }
if ($verified -notmatch 'this\.RefreshMachineEnvelopeUiState\(\);\s*\r?\n\s*return;') { throw 'Repeated-Init refresh path missing.' }

"Tool machine UI synchronization guard audit OK" | Tee-Object -Append $log
