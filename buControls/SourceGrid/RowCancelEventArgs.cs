// Decompiled with JetBrains decompiler
// Type: SourceGrid.RowCancelEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public class RowCancelEventArgs : RowEventArgs
{
  private bool bool_0 = false;
  private int proposedFocusedRow;

  public bool Cancel
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  public int ProposedRow => this.proposedFocusedRow;

  public RowCancelEventArgs(int currentFocusedRow, int proposedFocusedRow)
    : base(currentFocusedRow)
  {
    this.proposedFocusedRow = proposedFocusedRow;
  }
}
