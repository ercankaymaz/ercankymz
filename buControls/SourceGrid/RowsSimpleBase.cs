// Decompiled with JetBrains decompiler
// Type: SourceGrid.RowsSimpleBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public abstract class RowsSimpleBase : RowsBase
{
  private int int_1;

  public RowsSimpleBase(GridVirtual grid)
    : base(grid)
  {
    this.int_1 = grid.DefaultHeight;
  }

  public int RowHeight
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

  public override int GetHeight(int row) => this.RowHeight;

  public override void SetHeight(int row, int height) => this.RowHeight = height;
}
