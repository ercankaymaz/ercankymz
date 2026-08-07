// Decompiled with JetBrains decompiler
// Type: SourceGrid.DataGridValueModel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using System;
using System.ComponentModel;

#nullable disable
namespace SourceGrid;

public class DataGridValueModel : IValueModel, IModel
{
  public object GetValue(CellContext cellContext)
  {
    DataGrid grid = (DataGrid) cellContext.Grid;
    PropertyDescriptor propertyColumn = grid.Columns[cellContext.Position.Column].PropertyColumn;
    int dataSourceIndex = grid.Rows.IndexToDataSourceIndex(cellContext.Position.Row);
    return dataSourceIndex < grid.DataSource.Count ? grid.DataSource.GetItemValue(dataSourceIndex, propertyColumn) : (object) null;
  }

  public void SetValue(CellContext cellContext, object value)
  {
    DataGrid grid = (DataGrid) cellContext.Grid;
    PropertyDescriptor propertyColumn = grid.Columns[cellContext.Position.Column].PropertyColumn;
    ValueChangeEventArgs e = new ValueChangeEventArgs(this.GetValue(cellContext), value);
    if (cellContext.Grid != null)
      cellContext.Grid.Controller.OnValueChanging(cellContext, e);
    grid.DataSource.SetEditValue(propertyColumn, e.NewValue);
    if (cellContext.Grid == null)
      return;
    cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
  }
}
