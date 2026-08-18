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

# Add one reusable status/permission refresher. Keep the helper self-contained;
# do not replace its own status block later (that previously created recursion).
if ($text -notmatch 'private\s+void\s+RefreshMachineEnvelopeUiState\s*\(') {
  $anchorPattern = '(?m)^\s*private\s+void\s+InitializeMachineEnvelopeControls\s*\(\s*\)'
  $match = [regex]::Match($text, $anchorPattern)
  if (-not $match.Success) { throw 'Machine-envelope initialization anchor not found.' }
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
  $text = $text.Insert($match.Index, $helper)
  "FIX add machine-limit permission/status refresh helper" | Tee-Object -Append $log
}

# Repeated Init must refresh authorization/status instead of returning with stale UI.
$earlyPattern = '(?s)(private\s+void\s+InitializeMachineEnvelopeControls\s*\(\s*\)\s*\{\s*)if\s*\(this\.saveMachineLimitsButton\s*!=\s*null\)\s*(?:\{\s*)?return;\s*(?:\}\s*)?'
$earlyReplacement = '$1if (this.saveMachineLimitsButton != null)' + "`r`n    {`r`n      this.RefreshMachineEnvelopeUiState();`r`n      return;`r`n    }`r`n"
$newText = [regex]::Replace($text, $earlyPattern, $earlyReplacement, 1)
if ($newText -ne $text) {
  $text = $newText
  "FIX refresh machine-limit permission/status on repeated Init" | Tee-Object -Append $log
}

# On first initialization, use the same refresher after controls are created.
$tailPattern = '(?s)(this\.maxCuttingTiltDeltaControl\.BringToFront\(\);)\s*string\s+profileFile\s*=\s*this\.GetMachineProfileFilePath\(\);\s*bool\s+profileIsActive\s*=\s*FiveAxisPathSafety\.HasConfiguredMachineEnvelope;\s*bool\s+profileFileExists\s*=\s*File\.Exists\(profileFile\);\s*this\.machineLimitsStatusLabel\.Text\s*=\s*profileIsActive\s*\?\s*"Machine profile: active"\s*:\s*\(profileFileExists\s*\?\s*"Machine profile: saved, review required"\s*:\s*"Machine profile: not configured"\);\s*this\.machineLimitsStatusLabel\.ForeColor\s*=\s*profileIsActive\s*\?\s*Color\.DarkGreen\s*:\s*Color\.DarkOrange;'
$tailReplacement = '$1' + "`r`n`r`n    this.RefreshMachineEnvelopeUiState();"
$text = [regex]::Replace($text, $tailPattern, $tailReplacement, 1)

if ($text -ne $original) {
  [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
}

$verified = [IO.File]::ReadAllText($path)
if ($verified -notmatch 'private\s+void\s+RefreshMachineEnvelopeUiState\s*\(') { throw 'Machine-envelope UI refresh helper missing.' }
if ($verified -notmatch 'this\.saveMachineLimitsButton\.Enabled\s*=\s*AppSecurity\.PasswordLevel\s*>=\s*2;') { throw 'Permission-state refresh missing.' }
if ($verified -notmatch 'if\s*\(this\.saveMachineLimitsButton\s*!=\s*null\)\s*\{\s*this\.RefreshMachineEnvelopeUiState\(\);\s*return;\s*\}') { throw 'Repeated-Init refresh path missing.' }
if (($verified | Select-String -Pattern 'private\s+void\s+RefreshMachineEnvelopeUiState\s*\(' -AllMatches).Matches.Count -ne 1) { throw 'Machine-envelope UI refresh helper duplicated.' }

"Tool machine UI synchronization guard audit OK" | Tee-Object -Append $log