// Decompiled with JetBrains decompiler
// Type: SourceGrid.DataGridColumns
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using System;
using System.ComponentModel;

#nullable disable
namespace SourceGrid;

public class DataGridColumns(SourceGrid.DataGrid grid) : ColumnInfoCollection((GridVirtual) grid)
{
  public SourceGrid.DataGrid Grid => (SourceGrid.DataGrid) base.Grid;

  public DataGridColumn this[int index] => base[index] as DataGridColumn;

  public PropertyDescriptor IndexToPropertyColumn(int gridColumnIndex)
  {
    return this.Grid.Columns[gridColumnIndex].PropertyColumn;
  }

  public int DataSourceColumnToIndex(PropertyDescriptor propertyColumn)
  {
    int index1;
    for (int index2 = 0; index2 < this.Grid.Columns.Count; ++index2)
    {
      if (this.Grid.Columns[index2].PropertyColumn == propertyColumn)
      {
        index1 = index2;
        goto label_6;
      }
    }
    index1 = -1;
label_6:
    return index1;
  }

  public DataGridColumn Add(string property, string caption, Type propertyType)
  {
    ICellVirtual cell = SourceGrid.Cells.DataGrid.Cell.Create(propertyType, true);
    return this.Add(property, caption, cell);
  }

  public DataGridColumn Add(string property, string caption, EditorBase editor)
  {
    SourceGrid.Cells.DataGrid.Cell cell = new SourceGrid.Cells.DataGrid.Cell();
    cell.Editor = editor;
    return this.Add(property, caption, (ICellVirtual) cell);
  }

  public DataGridColumn Add(string property, string caption, ICellVirtual cell)
  {
    DataGridColumn dataGridColumn = new DataGridColumn(this.Grid, (ICellVirtual) new SourceGrid.Cells.DataGrid.ColumnHeader(caption), cell, property);
    this.Insert(this.Count, (ColumnInfo) dataGridColumn);
    return dataGridColumn;
  }
}
