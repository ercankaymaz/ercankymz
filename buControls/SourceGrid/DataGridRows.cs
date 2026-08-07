// Decompiled with JetBrains decompiler
// Type: SourceGrid.DataGridRows
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public class DataGridRows : RowsSimpleBase
{
  private AutoSizeMode autoSizeMode_0 = AutoSizeMode.Default;
  private int int_2;
  private Dictionary<int, int> dictionary_0 = new Dictionary<int, int>();

  public DataGridRows(DataGrid grid)
    : base((GridVirtual) grid)
  {
    this.int_2 = grid.DefaultHeight;
  }

  public DataGrid Grid => (DataGrid) base.Grid;

  public override int Count
  {
    get
    {
      return this.Grid.DataSource == null ? this.Grid.FixedRows : (!this.Grid.DataSource.AllowNew ? this.Grid.DataSource.Count + this.Grid.FixedRows : this.Grid.DataSource.Count + this.Grid.FixedRows + 1);
    }
  }

  public int IndexToDataSourceIndex(int gridRowIndex) => gridRowIndex - this.Grid.FixedRows;

  public int DataSourceIndexToGridRowIndex(int dataSourceIndex)
  {
    return dataSourceIndex + this.Grid.FixedRows;
  }

  public object IndexToDataSourceRow(int gridRowIndex)
  {
    int dataSourceIndex = this.IndexToDataSourceIndex(gridRowIndex);
    return (this.Grid.DataSource == null || dataSourceIndex < 0 ? 0 : (dataSourceIndex < this.Grid.DataSource.Count ? 1 : 0)) == 0 ? (object) null : this.Grid.DataSource[dataSourceIndex];
  }

  public int DataSourceRowToIndex(object row)
  {
    return this.Grid.DataSource == null ? -1 : this.Grid.DataSource.IndexOf(row);
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

  public void ResetRowHeigth() => this.dictionary_0.Clear();

  public void RowDeleted(object row)
  {
    if ((row == null ? 0 : (this.dictionary_0.ContainsKey(row.GetHashCode()) ? 1 : 0)) == 0)
      return;
    this.dictionary_0.Remove(row.GetHashCode());
  }

  public override int GetHeight(int row)
  {
    int height;
    if (row == 0)
    {
      height = this.HeaderHeight;
    }
    else
    {
      object dataSourceRow = this.IndexToDataSourceRow(row);
      height = (dataSourceRow == null ? 0 : (this.dictionary_0.ContainsKey(dataSourceRow.GetHashCode()) ? 1 : 0)) == 0 ? base.GetHeight(row) : this.dictionary_0[dataSourceRow.GetHashCode()];
    }
    return height;
  }

  public override void SetHeight(int row, int height)
  {
    if (row == 0)
      this.HeaderHeight = height;
    else if (this.IndexToDataSourceRow(row) != null)
    {
      int hashCode = this.IndexToDataSourceRow(row).GetHashCode();
      if ((!this.dictionary_0.ContainsKey(hashCode) ? 1 : (this.dictionary_0[hashCode] != height ? 1 : 0)) == 0)
        return;
      this.dictionary_0[hashCode] = height;
      this.PerformLayout();
    }
    else
      base.SetHeight(row, height);
  }
}
