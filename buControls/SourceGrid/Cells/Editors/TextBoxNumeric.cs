// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.TextBoxNumeric
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using DevAge.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBoxNumeric(System.Type p_Type) : TextBox(p_Type)
{
  protected override System.Windows.Forms.Control CreateControl()
  {
    DevAgeTextBox control = new DevAgeTextBox();
    control.BorderStyle = BorderStyle.None;
    control.AutoSize = false;
    control.Validator = (IValidator) this;
    return (System.Windows.Forms.Control) control;
  }

  public new DevAgeTextBox Control => base.Control;
}
