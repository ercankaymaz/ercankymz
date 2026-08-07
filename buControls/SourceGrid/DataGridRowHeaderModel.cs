// Decompiled with JetBrains decompiler
// Type: SourceGrid.DataGridRowHeaderModel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using System;

#nullable disable
namespace SourceGrid;

public class DataGridRowHeaderModel : IValueModel, IModel
{
  public object GetValue(CellContext cellContext)
  {
    DataGrid grid = (DataGrid) cellContext.Grid;
    return (grid.DataSource == null || !grid.DataSource.AllowNew ? 0 : (cellContext.Position.Row == grid.Rows.Count - 1 ? 1 : 0)) == 0 ? (object) null : (object) "*";
  }

  public void SetValue(CellContext cellContext, object p_Value)
  {
    throw new ApplicationException("Not supported");
  }
}
