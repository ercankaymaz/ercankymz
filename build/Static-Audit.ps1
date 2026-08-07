$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$out = Join-Path $root 'BUILD_LOGS/STATIC_AUDIT.txt'
New-Item -ItemType Directory -Force -Path (Split-Path $out) | Out-Null

$projectRoots = @(
  'CMDMarbleCNC','CmdLangAPI','buCadCamRes','buCamera','buCameraSolutions','buClass','buComm',
  'buControls','buCore','buEyeBase','buFile','buImages','buMW','buMarble','buMotion','buOpcDlls',
  'buOpcUA','buPowerNest','PPInterface-Wrapper'
)
$files = foreach ($dir in $projectRoots) {
  $p = Join-Path $root $dir
  if (Test-Path $p) { Get-ChildItem $p -Recurse -Filter *.cs -File }
}

$lineCount = 0L
$patterns = [ordered]@{
  'mouse_precedence_right_or_left' = '&& e.Button == MouseButtons.Right | e.Button == MouseButtons.Left'
  'bezeir_typo' = 'bezeir'
  'quick_offset_calls' = 'QuickOffset('
  'register_exception_sites' = 'throw new RegisterException('
  'decompiler_issue_markers' = '// ISSUE:'
  'empty_exception_catches' = 'catch (Exception ex)'
}
$counts = @{}
foreach ($k in $patterns.Keys) { $counts[$k] = 0 }

foreach ($file in $files) {
  $text = [IO.File]::ReadAllText($file.FullName)
  $lineCount += ([regex]::Matches($text, "`n")).Count + 1
  foreach ($k in $patterns.Keys) {
    $counts[$k] += ([regex]::Matches($text, [regex]::Escape($patterns[$k]))).Count
  }
}

$lines = New-Object System.Collections.Generic.List[string]
$lines.Add('CMDMarbleCNC STATIC SOURCE AUDIT')
$lines.Add('================================')
$lines.Add("C# files scanned: $($files.Count)")
$lines.Add("Approx. source lines: $lineCount")
$lines.Add('')
foreach ($k in $patterns.Keys) { $lines.Add("$k = $($counts[$k])") }
$lines.Add('')
$lines.Add('Notes:')
$lines.Add('- Audit counts are review signals, not automatic proof of a defect.')
$lines.Add('- License/RegisterException sites are counted only; this workflow does not remove or bypass them.')
$lines.Add('- Build/compiler diagnostics are authoritative for syntax/type/reference failures.')
$lines | Set-Content $out -Encoding UTF8
$lines | ForEach-Object { Write-Host $_ }
