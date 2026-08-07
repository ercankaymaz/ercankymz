// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.RichTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Converter;
using DevAge.ComponentModel.Validator;
using DevAge.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class RichTextBox : EditorControlBase
{
  public RichTextBox()
    : base(typeof (RichText))
  {
    this.TypeConverter = (TypeConverter) new RichTextTypeConverter();
  }

  protected override System.Windows.Forms.Control CreateControl()
  {
    DevAgeRichTextBox control = new DevAgeRichTextBox();
    control.BorderStyle = BorderStyle.None;
    control.AutoSize = false;
    control.Validator = (IValidator) this;
    return (System.Windows.Forms.Control) control;
  }

  public DevAgeRichTextBox Control => (DevAgeRichTextBox) base.Control;

  protected override void OnStartingEdit(CellContext cellContext, System.Windows.Forms.Control editorControl)
  {
    base.OnStartingEdit(cellContext, editorControl);
    DevAgeRichTextBox devAgeRichTextBox = (DevAgeRichTextBox) editorControl;
    devAgeRichTextBox.WordWrap = cellContext.Cell.View.WordWrap;
    devAgeRichTextBox.SelectionStart = 0;
    devAgeRichTextBox.SelectionLength = 0;
  }

  public override void SetEditValue(object editValue)
  {
    this.Control.Value = editValue as RichText;
    this.Control.SelectAll();
  }

  public override object GetEditedValue() => (object) this.Control.Value;

  protected override void OnSendCharToEditor(char key)
  {
    this.Control.Text = key.ToString();
    if (this.Control.Text == null)
      return;
    this.Control.SelectionStart = this.Control.Text.Length;
  }
}
