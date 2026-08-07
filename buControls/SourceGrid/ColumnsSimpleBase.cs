// Decompiled with JetBrains decompiler
// Type: SourceGrid.ColumnsSimpleBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public abstract class ColumnsSimpleBase : ColumnsBase
{
  private int int_1;

  public ColumnsSimpleBase(GridVirtual grid)
    : base(grid)
  {
    this.int_1 = grid.DefaultWidth;
  }

  public int ColumnWidth
  {
    get => this.int_1;
    set
    {
      if (this.int_1 == value)
        return;
      this.int_1 = value;
      this.PerformLayout();
    }
  }

  public override int GetWidth(int column) => this.ColumnWidth;

  public override void SetWidth(int column, int width) => this.ColumnWidth = width;

  public override bool IsColumnVisible(int column) => true;

  public override void HideColumn(int column)
  {
    throw new NotSupportedException("ColumnsSimpleBase does not support column hiding");
  }

  public override void ShowColumn(int column)
  {
  }
}
