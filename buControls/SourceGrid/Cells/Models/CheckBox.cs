// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.CheckBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;

#nullable disable
namespace SourceGrid.Cells.Models;

public class CheckBox : IModel, ICheckBox
{
  private string string_0 = (string) null;

  public CheckBoxStatus GetCheckBoxStatus(CellContext cellContext)
  {
    bool checkEnable = false;
    if ((cellContext.Cell.Editor == null ? 0 : (cellContext.Cell.Editor.EnableEdit ? 1 : 0)) != 0)
      checkEnable = true;
    object obj = cellContext.Cell.Model.ValueModel.GetValue(cellContext);
    if (obj == null)
      return new CheckBoxStatus(checkEnable, CheckBoxState.Undefined, this.string_0);
    if (obj is bool flag)
      return new CheckBoxStatus(checkEnable, new bool?(flag), this.string_0);
    throw new SourceGridException("Cell value not supported for this cell. Expected bool value or null.");
  }

  public void SetCheckedValue(CellContext cellContext, bool? pChecked)
  {
    if ((cellContext.Cell.Editor == null ? 0 : (cellContext.Cell.Editor.EnableEdit ? 1 : 0)) == 0)
      return;
    cellContext.Cell.Editor.SetCellValue(cellContext, (object) pChecked);
  }

  public string Caption
  {
    get => this.string_0;
    set => this.string_0 = value;
  }
}
