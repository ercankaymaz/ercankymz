$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$utf8 = New-Object Text.UTF8Encoding($false)
$patchScript = Join-Path $PSScriptRoot 'Apply-CadCamFixes-v2.ps1'
if (-not (Test-Path $patchScript)) { throw 'Apply-CadCamFixes-v2.ps1 is missing.' }

# PowerShell interpolation repair for the deterministic CAD logic patch script.
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

function ReplaceOptional([string]$relative, [hashtable]$repairs) {
  $path = Join-Path $root $relative
  if (-not (Test-Path $path)) { throw "Missing repair target: $relative" }
  $s = [IO.File]::ReadAllText($path)
  foreach ($old in $repairs.Keys) {
    $count = ([regex]::Matches($s, [regex]::Escape($old))).Count
    if ($count -gt 0) {
      $s = $s.Replace($old, $repairs[$old])
      Write-Host "$relative repair ($count): $old" -ForegroundColor Green
    }
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

# Compiler-generated attributes/ValueType overrides represented as invalid C#.
RepairFile 'buCadCamRes/AssemblyInfo.cs' ([ordered]@{
  '[assembly: Extension]' = ''
})
RepairFile 'buCadCamRes/ns5/Struct2.cs' ([ordered]@{
  'virtual string ValueType.ToString()' = 'public override string ToString()'
})
RepairFile 'buCadCamRes/ns4/Struct1.cs' ([ordered]@{
  'virtual string ValueType.ToString()' = 'public override string ToString()'
})

# Keep Class5 intact. Fix the two invalid decompiler signatures and restore the
# assembly-level accessibility that the original call graph requires. JetBrains
# omitted access modifiers on hundreds of helper methods, which C# interprets as
# private even though other classes in this assembly call them.
$class5Path = Join-Path $root 'buCadCamRes/ns8/Class5.cs'
$c5 = [IO.File]::ReadAllText($class5Path)
$c5 = $c5.Replace('ICurve icurve_1 = true,', 'ICurve icurve_1,')
$c5 = [regex]::Replace($c5, '(?m)^  static ', '  internal static ')
[IO.File]::WriteAllText($class5Path, $c5, $utf8)
Write-Host 'Class5 helper accessibility restored to internal static.' -ForegroundColor Green

# Event backing-field names are compiler implementation details. The decompiler
# preserved calls to those names but emitted only the public event declarations.
# Replace them with the actual event names inside their declaring classes.
ReplaceOptional 'buCadCamRes/buCadCamResVer5/clsCommand.cs' ([ordered]@{
  'formXYZUpdate_0' = 'MainFormXYZUpdate'
  'formStatusUpdate_0' = 'MainFormStatusUpdate'
  'pageEntityAdd_0' = 'EntityAddToPage'
  'formUpdate_0' = 'MainFormUpdate'
  'runCommands_0' = 'RunCommand'
  'generalCommands_0' = 'GeneralCommand'
  'drawingFinisedEvent_0' = 'DrawingFinished'
  'calculationEventHandler_0' = 'ProgressUpdate'
  'calculationEventHandler_1' = 'ProgressReset'
  'mouseDownViewport_0' = 'ViewMouseDown'
  'mouseDownViewport_1' = 'ViewMouseUp'
  'mouseDownViewport_2' = 'ViewtMouseMove'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs' ([ordered]@{
  'marbleSimCoordinateUpdated_0' = 'SimUpdated'
  'okCommandWithFiveDataEventHandler_0' = 'MarbleCoreHMICommand'
  'okCommandWithFiveDataEventHandler_1' = 'MarbleCoreAppMarbleCommand'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/Sewing/clsSewing.cs' ([ordered]@{
  'okCommandWithThreeDataEventHandler_0' = 'SewingExternalCommand'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/FoamCutting/clsFoamCutting.cs' ([ordered]@{
  'okCommandWithTwoDataEventHandler_0' = 'CommandFoam'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/Profile/clsProfile.cs' ([ordered]@{
  'okCommandWithTwoDataEventHandler_0' = 'CommandProfile'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/Flexo/clsFlexo.cs' ([ordered]@{
  'okCommandWithTwoDataEventHandler_0' = 'ObjectSelected'
})
ReplaceOptional 'buCadCamRes/buDialogExtenders/FileDialogControlBase.cs' ([ordered]@{
  'pathChangedEventHandler_0' = 'EventFileNameChanged'
  'pathChangedEventHandler_1' = 'EventFolderNameChanged'
  'filterChangedEventHandler_0' = 'EventFilterChanged'
  'cancelEventHandler_0' = 'EventClosingDialog'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/DialogBoxx/SaveFileDialogBoxOptions.cs' ([ordered]@{
  'selectFile_0' = 'FileSelect'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/DialogBoxx/OpenFileDialogBoxPreview.cs' ([ordered]@{
  'selectFile_0' = 'FileSelect'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/PipeBending/clsPipeBending.cs' ([ordered]@{
  'okCommandWithThreeDataEventHandler_0' = 'SimulationUpdate'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/PanelCut/clsNestOpaline.cs' ([ordered]@{
  'okCommandWithDataEventHandler_0' = 'CalculationDone'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/Drill/F_Holes3D.cs' ([ordered]@{
  'cancelCommandEventHandler_0' = 'DataCancel'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/Drill/F_DrillMachSim.cs' ([ordered]@{
  'valueChangedWithDataEventHandler_0' = 'ValueChanged'
})
ReplaceOptional 'buCadCamRes/buCadCamResVer5/PanelCut/F_PanelCutMachSim.cs' ([ordered]@{
  'valueChangedWithDataEventHandler_0' = 'ValueChanged'
})

# Duplicate field name produced by decompiler in a small Printer3D work unit.
$sim = Join-Path $root 'buCadCamRes/buCadCamResVer5/Printer3D/Simulation.cs'
$s = [IO.File]::ReadAllText($sim)
$needle = "  private readonly double NozzleDiameter;`r`n  private readonly double NozzleDiameter;"
if (-not $s.Contains($needle)) { throw 'Printer3D Simulation duplicate-field pattern not found.' }
$s = $s.Replace($needle, '  private readonly double NozzleDiameter;')
[IO.File]::WriteAllText($sim, $s, $utf8)
Write-Host 'Printer3D Simulation duplicate field repaired.' -ForegroundColor Green
