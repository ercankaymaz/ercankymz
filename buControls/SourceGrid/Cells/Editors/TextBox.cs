// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.TextBox
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
public class TextBox(System.Type p_Type) : EditorControlBase(p_Type)
{
  protected override System.Windows.Forms.Control CreateControl()
  {
    DevAgeTextBox control = new DevAgeTextBox();
    control.BorderStyle = BorderStyle.None;
    control.AutoSize = false;
    control.Validator = (IValidator) this;
    return (System.Windows.Forms.Control) control;
  }

  public DevAgeTextBox Control => (DevAgeTextBox) base.Control;

  protected override void OnStartingEdit(CellContext cellContext, System.Windows.Forms.Control editorControl)
  {
    base.OnStartingEdit(cellContext, editorControl);
    DevAgeTextBox devAgeTextBox = (DevAgeTextBox) editorControl;
    devAgeTextBox.WordWrap = cellContext.Cell.View.WordWrap;
    devAgeTextBox.TextAlign = Utilities.ContentToHorizontalAlignment(cellContext.Cell.View.TextAlignment);
    devAgeTextBox.SelectionStart = 0;
    devAgeTextBox.SelectionLength = 0;
  }

  public override void SetEditValue(object editValue)
  {
    this.Control.Value = editValue;
    this.Control.SelectAll();
  }

  public override object GetEditedValue() => this.Control.Value;

  protected override void OnSendCharToEditor(char key)
  {
    this.Control.Text = key.ToString();
    if (this.Control.Text == null)
      return;
    this.Control.SelectionStart = this.Control.Text.Length;
  }
}
