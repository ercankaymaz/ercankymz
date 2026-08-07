// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.ValueModel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid.Cells.Models;

public class ValueModel : IValueModel, IModel
{
  private object val;

  public ValueModel()
  {
  }

  public ValueModel(object val) => this.val = val;

  public object GetValue(CellContext cellContext) => this.val;

  public void SetValue(CellContext cellContext, object newValue)
  {
    if (this.IsNewValueEqual(newValue))
      return;
    ValueChangeEventArgs e = new ValueChangeEventArgs(this.val, newValue);
    if (cellContext.Grid != null)
      cellContext.Grid.Controller.OnValueChanging(cellContext, e);
    this.val = e.NewValue;
    if (cellContext.Grid == null)
      return;
    cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
  }

  public bool IsNewValueEqual(object newValue)
  {
    bool flag;
    if (newValue == this.val)
    {
      flag = true;
    }
    else
    {
      object obj = this.val ?? (object) string.Empty;
      if (newValue == null)
        newValue = (object) string.Empty;
      flag = newValue.Equals(obj);
    }
    return flag;
  }
}
