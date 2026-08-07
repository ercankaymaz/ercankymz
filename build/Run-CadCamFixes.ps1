$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$patchScript = Join-Path $PSScriptRoot 'Apply-CadCamFixes-v2.ps1'
if (-not (Test-Path $patchScript)) { throw 'Apply-CadCamFixes-v2.ps1 is missing.' }

# PowerShell interpolation repair for the generated deterministic patch script.
$text = [IO.File]::ReadAllText($patchScript)
$text = $text.Replace('$name:', '${name}:')
[IO.File]::WriteAllText($patchScript, $text, (New-Object Text.UTF8Encoding($false)))
& $patchScript

# JetBrains decompiler emitted escaped explicit-interface member access and
# __nonvirtual pseudo-syntax in FileDialogControlBase. Restore equivalent C#.
$dialog = Join-Path $root 'buCadCamRes/buDialogExtenders/FileDialogControlBase.cs'
if (-not (Test-Path $dialog)) { throw 'FileDialogControlBase.cs is missing.' }
$d = [IO.File]::ReadAllText($dialog)
$repairs = [ordered]@{
  'this.System\u002EIDisposable\u002EDispose();' = '((IDisposable)this).Dispose();'
  'this.class1_0.System\u002EIDisposable\u002EDispose();' = '((IDisposable)this.class1_0).Dispose();'
  'virtual void NativeWindow.WndProc(ref Message m)' = 'protected override void WndProc(ref Message m)'
  '__nonvirtual (((NativeWindow) this).WndProc(ref m));' = 'base.WndProc(ref m);'
}
foreach ($old in $repairs.Keys) {
  $count = ([regex]::Matches($d, [regex]::Escape($old))).Count
  if ($count -lt 1) { throw "FileDialog repair pattern not found: $old" }
  $d = $d.Replace($old, $repairs[$old])
  Write-Host "FileDialog repair: $old ($count occurrence(s))" -ForegroundColor Green
}
[IO.File]::WriteAllText($dialog, $d, (New-Object Text.UTF8Encoding($false)))
