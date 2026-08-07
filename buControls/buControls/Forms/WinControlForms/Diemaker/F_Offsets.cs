// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_Offsets
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_Offsets : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public double LeftOffsetValue = 0.0;
  public double RightOffsetValue = 0.0;
  public double LeftSpecialValue1 = 2.0;
  public double LeftSpecialValue2 = 3.0;
  public double LeftSpecialValue3 = 4.0;
  public double RightSpecialValue1 = 2.0;
  public double RightSpecialValue2 = 3.0;
  public double RightSpecialValue3 = 4.0;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;
  internal Button button_9;
  internal Button button_10;
  internal Button button_11;
  internal Button button_12;
  internal Button button_13;
  internal Button button_14;
  internal Button button_15;
  internal Button button_16;
  internal Button button_17;
  internal Button button_18;
  internal Button button_19;
  internal Button button_20;
  internal Button button_21;
  internal Button button_22;
  internal Button button_23;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal Button button_24;
  internal Button button_25;
  internal Button button_26;
  internal Button button_27;
  internal Button button_28;
  internal Button button_29;
  internal Button button_30;
  internal Button button_31;
  internal Button button_32;
  internal Button button_33;
  internal Button button_34;
  internal Button button_35;
  internal Button button_36;
  internal Button button_37;
  internal Button button_38;
  internal Button button_39;
  internal Button button_40;
  internal Button button_41;
  internal Button button_42;
  internal Button button_43;
  internal Button button_44;
  internal Button button_45;
  internal Button button_46;
  internal Button button_47;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal Button button_48;
  internal Button button_49;

  public F_Offsets() => Class39.smethod_33(this);

  public event ApplyCommandWithDataEventHandler ApplyPressed;

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Init()
  {
    this.numericUpDown_0.Value = (Decimal) this.LeftOffsetValue;
    this.numericUpDown_1.Value = (Decimal) this.RightOffsetValue;
    this.button_23.Text = this.LeftSpecialValue1.ToString();
    this.button_22.Text = this.LeftSpecialValue2.ToString();
    this.button_21.Text = this.LeftSpecialValue3.ToString();
    this.button_26.Text = this.RightSpecialValue1.ToString();
    this.button_25.Text = this.RightSpecialValue2.ToString();
    this.button_24.Text = this.RightSpecialValue3.ToString();
    Class39.smethod_848(this);
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Text.Length <= 0 || !buNumeric.IsNumeric(control2.Text))
      return;
    this.numericUpDown_0.Value = Convert.ToDecimal(control2.Text);
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) new DiemakerOffsetValues()
    {
      LeftOffset = Convert.ToDouble(this.numericUpDown_0.Value),
      RightOffset = Convert.ToDouble(this.numericUpDown_1.Value),
      ApplyType = DiemakerOffsetApplyType.Left
    });
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Text.Length <= 0 || !buNumeric.IsNumeric(control2.Text))
      return;
    this.numericUpDown_1.Value = Convert.ToDecimal(control2.Text);
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) new DiemakerOffsetValues()
    {
      LeftOffset = Convert.ToDouble(this.numericUpDown_0.Value),
      RightOffset = Convert.ToDouble(this.numericUpDown_1.Value),
      ApplyType = DiemakerOffsetApplyType.Right
    });
  }

  internal void method_3(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.applyCommandWithDataEventHandler_0((object) new DiemakerOffsetValues()
      {
        LeftOffset = Convert.ToDouble(this.numericUpDown_0.Value),
        RightOffset = Convert.ToDouble(this.numericUpDown_1.Value),
        ApplyType = DiemakerOffsetApplyType.Left
      });
    }
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_4(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.applyCommandWithDataEventHandler_0((object) new DiemakerOffsetValues()
      {
        LeftOffset = Convert.ToDouble(this.numericUpDown_0.Value),
        RightOffset = Convert.ToDouble(this.numericUpDown_1.Value),
        ApplyType = DiemakerOffsetApplyType.Right
      });
    }
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
