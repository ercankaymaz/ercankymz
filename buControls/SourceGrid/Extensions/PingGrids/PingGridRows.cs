// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.PingGridRows
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

public class PingGridRows : RowsSimpleBase
{
  private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;
  private int int_2;
  [Obsolete]
  private Dictionary<int, int> dictionary_0 = new Dictionary<int, int>();

  public PingGridRows(PingGrid grid)
    : base((GridVirtual) grid)
  {
    this.int_2 = grid.DefaultHeight;
  }

  public PingGrid Grid => (PingGrid) base.Grid;

  public override int Count
  {
    get
    {
      return this.Grid.DataSource != null ? this.Grid.DataSource.Count + this.Grid.FixedRows : this.Grid.FixedRows;
    }
  }

  public int IndexToDataSourceIndex(int gridRowIndex) => gridRowIndex - this.Grid.FixedRows;

  [Obsolete]
  public int DataSourceIndexToGridRowIndex(int dataSourceIndex)
  {
    return dataSourceIndex + this.Grid.FixedRows;
  }

  [Obsolete]
  public object IndexToDataSourceRow(int gridRowIndex)
  {
    this.IndexToDataSourceIndex(gridRowIndex);
    return (object) null;
  }

  [Obsolete]
  public int DataSourceRowToIndex(object row)
  {
    if (this.Grid.DataSource != null)
      ;
    return -1;
  }

  public AutoSizeMode AutoSizeMode
  {
    get => this.autoSizeMode_0;
    set => this.autoSizeMode_0 = value;
  }

  public override AutoSizeMode GetAutoSizeMode(int row) => this.autoSizeMode_0;

  public int HeaderHeight
  {
    get => this.int_2;
    set
    {
      if (this.int_2 == value)
        return;
      this.int_2 = value;
      this.PerformLayout();
    }
  }

  [Obsolete]
  public void ResetRowHeigth() => this.dictionary_0.Clear();

  [Obsolete]
  public void RowDeleted(object row)
  {
    if ((row == null ? 0 : (this.dictionary_0.ContainsKey(row.GetHashCode()) ? 1 : 0)) == 0)
      return;
    this.dictionary_0.Remove(row.GetHashCode());
  }

  public override int GetHeight(int row) => row != 0 ? base.GetHeight(row) : this.HeaderHeight;

  public override void SetHeight(int row, int height)
  {
    if (row == 0)
      this.HeaderHeight = height;
    base.SetHeight(row, height);
  }
}
