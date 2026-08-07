// Decompiled with JetBrains decompiler
// Type: SourceGrid.ArrayRows
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public class ArrayRows(ArrayGrid grid) : RowsSimpleBase((GridVirtual) grid)
{
  private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;

  public ArrayGrid Grid => (ArrayGrid) base.Grid;

  public override int Count
  {
    get
    {
      return this.Grid.DataSource != null ? this.Grid.DataSource.GetLength(0) + this.Grid.FixedRows : this.Grid.FixedRows;
    }
  }

  public AutoSizeMode AutoSizeMode
  {
    get => this.autoSizeMode_0;
    set => this.autoSizeMode_0 = value;
  }

  public override AutoSizeMode GetAutoSizeMode(int row) => this.autoSizeMode_0;
}
