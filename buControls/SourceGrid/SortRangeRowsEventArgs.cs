// Decompiled with JetBrains decompiler
// Type: SourceGrid.SortRangeRowsEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;

#nullable disable
namespace SourceGrid;

public class SortRangeRowsEventArgs : EventArgs
{
  private Range p_Range;
  private int keyColumn;
  private bool p_bAscending;
  private IComparer p_CellComparer;

  public SortRangeRowsEventArgs(
    Range p_Range,
    int keyColumn,
    bool p_bAscending,
    IComparer p_CellComparer)
  {
    this.p_Range = p_Range;
    this.keyColumn = keyColumn;
    this.p_bAscending = p_bAscending;
    this.p_CellComparer = p_CellComparer;
  }

  public Range Range => this.p_Range;

  public int KeyColumn => this.keyColumn;

  public bool Ascending => this.p_bAscending;

  public IComparer CellComparer => this.p_CellComparer;
}
