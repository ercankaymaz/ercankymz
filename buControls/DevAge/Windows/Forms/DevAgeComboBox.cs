// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.DevAgeComboBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeComboBox : ComboBox
{
  private bool bool_0 = false;
  private IValidator ivalidator_0 = (IValidator) null;

  protected override void OnValidating(CancelEventArgs e)
  {
    base.OnValidating(e);
    object convertedValue;
    if (!this.IsValidValue(out convertedValue))
    {
      e.Cancel = true;
    }
    else
    {
      if ((!this.FormatValue ? 0 : (this.Validator != null ? 1 : 0)) == 0)
        return;
      this.Text = this.Validator.ValueToDisplayString(convertedValue);
    }
  }

  [DefaultValue(false)]
  public bool FormatValue
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  [DefaultValue(null)]
  public IValidator Validator
  {
    get => this.ivalidator_0;
    set
    {
      if (this.ivalidator_0 == value)
        return;
      if (this.ivalidator_0 != null)
        this.ivalidator_0.Changed -= new EventHandler(this.ivalidator_0_Changed);
      this.ivalidator_0 = value;
      this.ivalidator_0.Changed += new EventHandler(this.ivalidator_0_Changed);
      this.ApplyValidatorRules();
    }
  }

  private void ivalidator_0_Changed(object sender, EventArgs e) => this.ApplyValidatorRules();

  public bool IsValidValue(out object convertedValue)
  {
    object p_Object = this.SelectedValue == null ? (this.SelectedItem == null ? (object) this.Text : this.SelectedItem) : this.SelectedValue;
    bool flag;
    if (this.Validator != null)
    {
      flag = this.Validator.IsValidObject(p_Object, out convertedValue);
    }
    else
    {
      convertedValue = p_Object;
      flag = true;
    }
    return flag;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object Value
  {
    get
    {
      object convertedValue;
      if (!this.IsValidValue(out convertedValue))
        throw new ArgumentOutOfRangeException("Text");
      return convertedValue;
    }
    set
    {
      if (this.Validator != null)
        this.Text = this.Validator.ValueToDisplayString(value);
      else if (value == null)
        this.Text = "";
      else
        this.Text = value.ToString();
    }
  }

  protected virtual void ApplyValidatorRules()
  {
    this.Items.Clear();
    if ((this.Validator == null ? 0 : (this.Validator.StandardValues != null ? 1 : 0)) == 0)
      return;
    foreach (object standardValue in (IEnumerable) this.Validator.StandardValues)
      this.Items.Add(standardValue);
    if (this.Validator.IsStringConversionSupported())
      this.DropDownStyle = ComboBoxStyle.DropDown;
    else
      this.DropDownStyle = ComboBoxStyle.DropDownList;
  }

  protected override void OnFormat(ListControlConvertEventArgs e)
  {
    base.OnFormat(e);
    if ((e.DesiredType != typeof (string) ? 1 : (this.Validator == null ? 1 : 0)) != 0)
      return;
    e.Value = (object) this.Validator.ValueToDisplayString(e.ListItem);
  }
}
