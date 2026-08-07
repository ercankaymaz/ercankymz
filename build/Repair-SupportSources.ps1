$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$utf8 = New-Object Text.UTF8Encoding($false)

function ReadText([string]$rel) {
  $p = Join-Path $root $rel
  if (-not (Test-Path $p)) { throw "Missing source: $rel" }
  [IO.File]::ReadAllText($p)
}
function WriteText([string]$rel,[string]$text) {
  [IO.File]::WriteAllText((Join-Path $root $rel),$text,$utf8)
}
function ReplaceRequired([string]$text,[string]$old,[string]$new,[string]$name,[int]$min=1) {
  $count = ([regex]::Matches($text,[regex]::Escape($old))).Count
  if ($count -lt $min) { throw "${name}: pattern not found" }
  Write-Host "$name ($count occurrence(s))" -ForegroundColor Green
  $text.Replace($old,$new)
}

# buClass: the decompiler emitted the compiler-generated assembly ExtensionAttribute.
# C# emits ExtensionAttribute automatically for extension methods and rejects an explicit
# assembly-level use (CS1112), so remove only that synthetic declaration.
$rel='buClass/AssemblyInfo.cs'
$t=ReadText $rel
$t=ReplaceRequired $t '[assembly: Extension]' '' 'buClass ExtensionAttribute repair'
WriteText $rel $t

# buCore: restore normal value-type overrides from decompiler pseudo explicit ValueType calls.
$rel='buCore/ns0/Struct0.cs'
$t=ReadText $rel
$old=@'
  [SpecialName]
  public static bool smethod_0(Struct0 struct0_0, Struct0 struct0_1)
  {
    return (ValueType) struct0_0 == (ValueType) struct0_1 || ((ValueType) struct0_0 == null ? 1 : ((ValueType) struct0_1 == null ? 1 : 0)) == 0 && struct0_0.long_0 == struct0_1.long_0 && (long) struct0_0.ulong_0 == (long) struct0_1.ulong_0;
  }
'@
$new=@'
  [SpecialName]
  public static bool smethod_0(Struct0 struct0_0, Struct0 struct0_1)
  {
    return struct0_0.long_0 == struct0_1.long_0 && struct0_0.ulong_0 == struct0_1.ulong_0;
  }
'@
$t=ReplaceRequired $t $old $new 'buCore Struct0 equality repair'
$t=ReplaceRequired $t '  virtual bool ValueType.Equals(object obj)' '  public override bool Equals(object obj)' 'buCore Struct0 Equals override'
$t=ReplaceRequired $t '  virtual int ValueType.GetHashCode()' '  public override int GetHashCode()' 'buCore Struct0 GetHashCode override'
WriteText $rel $t

# buControls FileDialogControlBase: escaped explicit-interface and __nonvirtual pseudo syntax.
$rel='buControls/buDialogExtenders/FileDialogControlBase.cs'
$t=ReadText $rel
$t=ReplaceRequired $t 'this.System\u002EIDisposable\u002EDispose();' '((IDisposable)this).Dispose();' 'buControls dialog IDisposable self'
$t=ReplaceRequired $t 'this.class42_0.System\u002EIDisposable\u002EDispose();' '((IDisposable)this.class42_0).Dispose();' 'buControls dialog IDisposable nested'
$t=ReplaceRequired $t 'virtual void NativeWindow.WndProc(ref Message m)' 'protected override void WndProc(ref Message m)' 'buControls dialog WndProc override' 2
$t=ReplaceRequired $t '__nonvirtual (((NativeWindow) this).WndProc(ref m));' 'base.WndProc(ref m);' 'buControls dialog base WndProc' 2
WriteText $rel $t

# SourceGrid row coordinator: reconstruct the compiler-generated closure as ordinary C#.
# When rows are removed, hidden row indices at/after the removed range must be discarded
# or shifted so scrollbar conversion remains consistent.
$rel='buControls/SourceGrid/RowInfoCollectoinHiddenRowCoordinator.cs'
$row=@'
using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public class RowInfoCollectoinHiddenRowCoordinator : StandardHiddenRowCoordinator
{
  public RowInfoCollectoinHiddenRowCoordinator(RowInfoCollection rows)
    : base((RowsBase) rows)
  {
    rows.RowsRemoving += new IndexRangeEventHandler(this.RowsRemoving);
  }

  private void RowsRemoving(object sender, IndexRangeEventArgs e)
  {
    List<int> hiddenRows = new List<int>(this.m_rowMerger.GetRowsIndex());
    this.m_rowMerger.Clear();
    this.m_totalHiddenRows = 0;

    int end = e.StartIndex + e.Count;
    foreach (int row in hiddenRows)
    {
      if (row >= e.StartIndex && row < end)
        continue;

      int mapped = row >= end ? row - e.Count : row;
      this.m_rowMerger.AddRange(new Range(mapped, 0, mapped, 1));
      ++this.m_totalHiddenRows;
    }
  }
}
'@
WriteText $rel $row
Write-Host 'buControls SourceGrid row-removal coordinator reconstructed' -ForegroundColor Green

# PensCache: restore normal IEquatable implementation and invocation.
$rel='buControls/DevAge/Drawing/PensCache.cs'
$t=ReadText $rel
$t=ReplaceRequired $t 'this.struct1_0[index].System\u002EIEquatable\u003CDevAge\u002EDrawing\u002EPensCache\u002EStruct1\u003E\u002EEquals(other)' 'this.struct1_0[index].Equals(other)' 'buControls PensCache Equals call'
$t=ReplaceRequired $t 'public bool System\u002EIEquatable\u003CDevAge\u002EDrawing\u002EPensCache\u002EStruct1\u003E\u002EEquals(' 'public bool Equals(' 'buControls PensCache IEquatable method'
WriteText $rel $t

# buMultiTextBox: restore normal IComparer<LineInfo>.Compare method name.
$rel='buControls/buMutliTextbox/buMultiTextBox.cs'
$t=ReadText $rel
$t=ReplaceRequired $t 'public int System\u002ECollections\u002EGeneric\u002EIComparer\u003CbuMutliTextbox\u002ELineInfo\u003E\u002ECompare(' 'public int Compare(' 'buControls LineInfo comparer'
WriteText $rel $t

Write-Host 'Support-source repairs completed.' -ForegroundColor Green
