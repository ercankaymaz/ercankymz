// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.DevAgeTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeTextBox : TextBox
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
      if (this.Validator.IsStringConversionSupported())
        this.Text = this.Validator.ValueToString(convertedValue);
      else
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

  protected virtual void ApplyValidatorRules()
  {
  }

  public bool IsValidValue(out object convertedValue)
  {
    bool flag;
    if (this.Validator != null)
    {
      flag = this.Validator.IsValidObject((object) this.Text, out convertedValue);
    }
    else
    {
      convertedValue = (object) this.Text;
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
      {
        if (this.Validator.IsStringConversionSupported())
          this.Text = this.Validator.ValueToString(value);
        else
          this.Text = this.Validator.ValueToDisplayString(value);
      }
      else if (value == null)
        this.Text = "";
      else
        this.Text = value.ToString();
    }
  }
}
