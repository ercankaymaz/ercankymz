// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.PingGridColumns
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using System;
using System.ComponentModel;

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

public class PingGridColumns(PingGrid grid) : ColumnInfoCollection((GridVirtual) grid)
{
  public PingGrid Grid => (PingGrid) base.Grid;

  public PingGridColumn this[int index] => base[index] as PingGridColumn;

  [Obsolete]
  public PropertyDescriptor IndexToPropertyColumn(int gridColumnIndex)
  {
    return this.Grid.Columns[gridColumnIndex].PropertyColumn;
  }

  [Obsolete]
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

  public PingGridColumn Add(string property, string caption, Type propertyType)
  {
    ICellVirtual cell = SourceGrid.Extensions.PingGrids.Cells.Cell.Create(propertyType, true);
    return this.Add(property, caption, cell);
  }

  public PingGridColumn Add(string property, string caption, EditorBase editor)
  {
    SourceGrid.Extensions.PingGrids.Cells.Cell cell = new SourceGrid.Extensions.PingGrids.Cells.Cell();
    cell.Editor = editor;
    return this.Add(property, caption, (ICellVirtual) cell);
  }

  public PingGridColumn Add(string property, string caption, ICellVirtual cell)
  {
    PingGridColumn dataGridColumn = new PingGridColumn(this.Grid, (ICellVirtual) new SourceGrid.Extensions.PingGrids.Cells.ColumnHeader(caption), cell, property);
    this.Insert(this.Count, (ColumnInfo) dataGridColumn);
    return dataGridColumn;
  }
}
