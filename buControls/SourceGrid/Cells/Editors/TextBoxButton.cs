// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.TextBoxButton
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using DevAge.Windows.Forms;
using System.ComponentModel;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBoxButton(System.Type p_Type) : EditorControlBase(p_Type)
{
  protected override System.Windows.Forms.Control CreateControl()
  {
    DevAgeTextBoxButton control = new DevAgeTextBoxButton();
    control.BorderStyle = DevAge.Drawing.BorderStyle.None;
    control.Validator = (IValidator) this;
    return (System.Windows.Forms.Control) control;
  }

  public DevAgeTextBoxButton Control => (DevAgeTextBoxButton) base.Control;

  protected override void OnStartingEdit(CellContext cellContext, System.Windows.Forms.Control editorControl)
  {
    base.OnStartingEdit(cellContext, editorControl);
    DevAgeTextBoxButton ageTextBoxButton = (DevAgeTextBoxButton) editorControl;
    ageTextBoxButton.TextBox.SelectionStart = 0;
    ageTextBoxButton.TextBox.SelectionLength = 0;
  }

  public override void SetEditValue(object editValue)
  {
    this.Control.Value = editValue;
    this.Control.TextBox.SelectAll();
  }

  public override object GetEditedValue() => this.Control.Value;

  protected override void OnSendCharToEditor(char key)
  {
    this.Control.TextBox.Text = key.ToString();
    if (this.Control.TextBox.Text == null)
      return;
    this.Control.TextBox.SelectionStart = this.Control.TextBox.Text.Length;
  }
}
