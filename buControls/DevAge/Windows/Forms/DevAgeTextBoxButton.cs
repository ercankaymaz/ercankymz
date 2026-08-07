// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.DevAgeTextBoxButton
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeTextBoxButton : EditableControlBase
{
  internal Button button_0;
  internal TextBox textBox_0;
  private System.ComponentModel.Container container_2 = (System.ComponentModel.Container) null;
  private IValidator ivalidator_0 = (IValidator) null;
  private object object_0 = (object) null;

  public DevAgeTextBoxButton()
  {
    Class39.smethod_393(this);
    this.button_0.BackColor = Color.FromKnownColor(KnownColor.Control);
    this.textBox_0.TextChanged += new EventHandler(this.textBox_0_TextChanged);
    this.SetContentAndButtonLocation((Control) this.textBox_0, (Control) this.button_0);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_2 != null)
      this.container_2.Dispose();
    base.Dispose(disposing);
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

  public virtual void ShowDialog()
  {
    this.OnDialogOpen(EventArgs.Empty);
    this.OnDialogClosed(EventArgs.Empty);
  }

  internal void method_0(object sender, EventArgs e) => this.ShowDialog();

  public Button Button => this.button_0;

  public TextBox TextBox => this.textBox_0;

  public event EventHandler DialogOpen;

  protected virtual void OnDialogOpen(EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, e);
  }

  public event EventHandler DialogClosed;

  protected virtual void OnDialogClosed(EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_1((object) this, e);
  }

  protected override void OnBorderStyleChanged(EventArgs e)
  {
    base.OnBorderStyleChanged(e);
    this.SetContentAndButtonLocation((Control) this.textBox_0, (Control) this.button_0);
  }

  protected override void OnBackColorChanged(EventArgs e)
  {
    base.OnBackColorChanged(e);
    if (this.textBox_0 == null)
      return;
    if (this.BackColor == Color.Transparent)
      this.textBox_0.BackColor = Color.FromKnownColor(KnownColor.Window);
    else
      this.textBox_0.BackColor = this.BackColor;
  }

  protected override void OnForeColorChanged(EventArgs e)
  {
    base.OnForeColorChanged(e);
    if (this.textBox_0 == null)
      return;
    this.textBox_0.ForeColor = this.ForeColor;
  }

  protected override void OnValidating(CancelEventArgs e)
  {
    base.OnValidating(e);
    if (this.IsValidValue(out object _))
      return;
    e.Cancel = true;
  }

  public bool IsValidValue(out object convertedValue)
  {
    bool flag;
    if (this.Validator != null)
    {
      if (this.object_0 != null)
      {
        convertedValue = this.object_0;
        flag = true;
      }
      else if (this.Validator.IsValidObject((object) this.TextBox.Text, out this.object_0))
      {
        convertedValue = this.object_0;
        flag = true;
      }
      else
      {
        convertedValue = (object) null;
        flag = false;
      }
    }
    else
    {
      convertedValue = (object) this.textBox_0.Text;
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
          this.TextBox.Text = this.Validator.ValueToString(value);
        else
          this.TextBox.Text = this.Validator.ValueToDisplayString(value);
      }
      else if (value == null)
        this.TextBox.Text = "";
      else
        this.TextBox.Text = value.ToString();
      this.object_0 = value;
    }
  }

  private void textBox_0_TextChanged(object sender, EventArgs e) => this.object_0 = (object) null;
}
