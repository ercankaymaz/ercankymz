$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$utf8 = New-Object Text.UTF8Encoding($false)
$patchScript = Join-Path $PSScriptRoot 'Apply-CadCamFixes-v2.ps1'
if (-not (Test-Path $patchScript)) { throw 'Apply-CadCamFixes-v2.ps1 is missing.' }

# PowerShell interpolation repair for the generated deterministic patch script.
$text = [IO.File]::ReadAllText($patchScript)
$text = $text.Replace('$name:', '${name}:')
[IO.File]::WriteAllText($patchScript, $text, $utf8)
& $patchScript

function RepairFile([string]$relative, [hashtable]$repairs) {
  $path = Join-Path $root $relative
  if (-not (Test-Path $path)) { throw "Missing repair target: $relative" }
  $s = [IO.File]::ReadAllText($path)
  foreach ($old in $repairs.Keys) {
    $count = ([regex]::Matches($s, [regex]::Escape($old))).Count
    if ($count -lt 1) { throw "Repair pattern not found in ${relative}: $old" }
    $s = $s.Replace($old, $repairs[$old])
    Write-Host "$relative repair ($count): $old" -ForegroundColor Green
  }
  [IO.File]::WriteAllText($path, $s, $utf8)
}

# FileDialogControlBase pseudo-syntax emitted by decompiler.
RepairFile 'buCadCamRes/buDialogExtenders/FileDialogControlBase.cs' ([ordered]@{
  'this.System\u002EIDisposable\u002EDispose();' = '((IDisposable)this).Dispose();'
  'this.class1_0.System\u002EIDisposable\u002EDispose();' = '((IDisposable)this.class1_0).Dispose();'
  'virtual void NativeWindow.WndProc(ref Message m)' = 'protected override void WndProc(ref Message m)'
  '__nonvirtual (((NativeWindow) this).WndProc(ref m));' = 'base.WndProc(ref m);'
})

# Compiler-generated attributes/ValueType overrides were represented as invalid C#.
RepairFile 'buCadCamRes/AssemblyInfo.cs' ([ordered]@{
  '[assembly: Extension]' = ''
})
RepairFile 'buCadCamRes/ns5/Struct2.cs' ([ordered]@{
  'virtual string ValueType.ToString()' = 'public override string ToString()'
})
RepairFile 'buCadCamRes/ns4/Struct1.cs' ([ordered]@{
  'virtual string ValueType.ToString()' = 'public override string ToString()'
})

# Class5 is retained intact. Only two invalid decompiler signatures are restored:
# every call site supplies all four arguments, so the bogus "= true" on ICurve
# is not an actual optional parameter and can be removed without changing behavior.
RepairFile 'buCadCamRes/ns8/Class5.cs' ([ordered]@{
  'ICurve icurve_1 = true,' = 'ICurve icurve_1,'
})

# Duplicate field name produced by decompiler in a small Printer3D work unit.
$sim = Join-Path $root 'buCadCamRes/buCadCamResVer5/Printer3D/Simulation.cs'
$s = [IO.File]::ReadAllText($sim)
$needle = "  private readonly double NozzleDiameter;`r`n  private readonly double NozzleDiameter;"
if (-not $s.Contains($needle)) { throw 'Printer3D Simulation duplicate-field pattern not found.' }
$s = $s.Replace($needle, '  private readonly double NozzleDiameter;')
[IO.File]::WriteAllText($sim, $s, $utf8)
Write-Host 'Printer3D Simulation duplicate field repaired.' -ForegroundColor Green
