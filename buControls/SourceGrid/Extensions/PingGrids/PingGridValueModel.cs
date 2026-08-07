// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.PingGridValueModel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using System;

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

public class PingGridValueModel : IValueModel, IModel
{
  public object GetValue(CellContext cellContext)
  {
    PingGrid grid = cellContext.Grid as PingGrid;
    string propertyName = grid.Columns[cellContext.Position.Column].PropertyName;
    int dataSourceIndex = grid.Rows.IndexToDataSourceIndex(cellContext.Position.Row);
    return dataSourceIndex < grid.DataSource.Count ? grid.DataSource.GetItemValue(dataSourceIndex, propertyName) : (object) null;
  }

  public void SetValue(CellContext cellContext, object value)
  {
    throw new NotImplementedException();
  }
}
