// Decompiled with JetBrains decompiler
// Type: SourceGrid.ArrayValueModel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using System;

#nullable disable
namespace SourceGrid;

public class ArrayValueModel : IValueModel, IModel
{
  public virtual object GetValue(CellContext cellContext)
  {
    return ((ArrayGrid) cellContext.Grid).DataSource.GetValue(cellContext.Position.Row - cellContext.Grid.FixedRows, cellContext.Position.Column - cellContext.Grid.FixedColumns);
  }

  public virtual void SetValue(CellContext cellContext, object p_Value)
  {
    Array dataSource = ((ArrayGrid) cellContext.Grid).DataSource;
    ValueChangeEventArgs e = new ValueChangeEventArgs(dataSource.GetValue(cellContext.Position.Row - cellContext.Grid.FixedRows, cellContext.Position.Column - cellContext.Grid.FixedColumns), p_Value);
    if (cellContext.Grid != null)
      cellContext.Grid.Controller.OnValueChanging(cellContext, e);
    dataSource.SetValue(p_Value, cellContext.Position.Row - cellContext.Grid.FixedRows, cellContext.Position.Column - cellContext.Grid.FixedColumns);
    if (cellContext.Grid == null)
      return;
    cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
  }
}
