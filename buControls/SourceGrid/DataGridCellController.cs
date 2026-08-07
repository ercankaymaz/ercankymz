// Decompiled with JetBrains decompiler
// Type: SourceGrid.DataGridCellController
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using System.ComponentModel;

#nullable disable
namespace SourceGrid;

public class DataGridCellController : ControllerBase
{
  public override void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
  {
    base.OnValueChanging(sender, e);
    if (!((DataGrid) sender.Grid).BeginEditRow(sender.Position.Row))
      throw new SourceGridException("Failed to editing row " + sender.Position.Row.ToString());
  }

  public override void OnEditStarting(CellContext sender, CancelEventArgs e)
  {
    base.OnEditStarting(sender, e);
    bool flag = ((DataGrid) sender.Grid).BeginEditRow(sender.Position.Row);
    e.Cancel = !flag;
  }
}
