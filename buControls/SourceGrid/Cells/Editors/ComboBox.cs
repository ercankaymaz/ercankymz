// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.ComboBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using DevAge.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class ComboBox : EditorControlBase
{
  public ComboBox(System.Type p_Type)
    : base(p_Type)
  {
  }

  public ComboBox(System.Type p_Type, ICollection p_StandardValues, bool p_StandardValueExclusive)
    : base(p_Type)
  {
    this.StandardValues = p_StandardValues;
    this.StandardValuesExclusive = p_StandardValueExclusive;
  }

  protected override System.Windows.Forms.Control CreateControl()
  {
    return (System.Windows.Forms.Control) new DevAgeComboBox()
    {
      Validator = (IValidator) this
    };
  }

  public DevAgeComboBox Control => (DevAgeComboBox) base.Control;

  public override void SetEditValue(object editValue)
  {
    if ((!(editValue is string) || !this.IsStringConversionSupported() ? 0 : (this.Control.DropDownStyle == ComboBoxStyle.DropDown ? 1 : 0)) != 0)
    {
      this.Control.SelectedIndex = -1;
      this.Control.Text = (string) editValue;
      this.Control.SelectionLength = 0;
      if (this.Control.Text != null)
        this.Control.SelectionStart = this.Control.Text.Length;
      else
        this.Control.SelectionStart = 0;
    }
    else
    {
      this.Control.SelectedIndex = -1;
      this.Control.Value = editValue;
      this.Control.SelectAll();
    }
  }

  public override object GetEditedValue() => this.Control.Value;

  protected override void OnSendCharToEditor(char key)
  {
    if (this.Control.DropDownStyle != ComboBoxStyle.DropDown)
      return;
    this.Control.Text = key.ToString();
    if (this.Control.Text == null)
      return;
    this.Control.SelectionStart = this.Control.Text.Length;
  }
}
