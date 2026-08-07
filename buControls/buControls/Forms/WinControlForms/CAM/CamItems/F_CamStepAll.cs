// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.CAM.CamItems.F_CamStepAll
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamStepAll : Form
{
  public static List<string> Captions = new List<string>();
  public int DecimalCount = 2;
  public bool ShowExplanation = false;
  public bool ShowImages = true;
  public bool ShowOkButton = true;
  public bool ShowCancelButton = true;
  public Size FormSize = new Size();
  public camStep Data = new camStep();
  public camStepEnable DataEnable = new camStepEnable();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Label label_0;
  internal ImageList imageList_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal Label label_2;
  internal Label label_3;
  internal CheckBox checkBox_0;
  internal Label label_4;
  internal NumericUpDown numericUpDown_1;
  internal Panel panel_1;
  internal Label label_5;
  internal CheckBox checkBox_1;
  internal Label label_6;
  internal Label label_7;
  internal NumericUpDown numericUpDown_2;
  internal Label label_8;
  internal Label label_9;
  internal NumericUpDown numericUpDown_3;
  internal Label label_10;
  internal Label label_11;
  internal Panel panel_2;
  internal Panel panel_3;
  internal Panel panel_4;
  internal Label label_12;
  internal Label label_13;
  internal NumericUpDown numericUpDown_4;
  internal Label label_14;
  internal Panel panel_5;
  internal Label label_15;
  internal Label label_16;
  internal NumericUpDown numericUpDown_5;
  internal Label label_17;
  internal Panel panel_6;
  internal RadioButton radioButton_0;
  internal Label label_18;
  internal RadioButton radioButton_1;
  internal Label label_19;
  internal Label label_20;
  internal Panel panel_7;
  internal RadioButton radioButton_2;
  internal Label label_21;
  internal RadioButton radioButton_3;
  internal Label label_22;
  internal Label label_23;
  internal ImageList imageList_1;
  public Button btn_cancel;
  public Button btn_ok;
  internal Panel panel_8;

  public event OkCommandWithDataEventHandler OkPressed;

  public event CancelCommandEventHandler CancelPressed;

  public event ApplyCommandWithDataEventHandler ApplyPressed;

  public F_CamStepAll() => Class39.smethod_763(this);

  public F_CamStepAll(bool ShowExplanation, int DecimalCount)
  {
    Class39.smethod_763(this);
    this.label_2.Visible = ShowExplanation;
    this.label_8.Visible = ShowExplanation;
    this.label_14.Visible = ShowExplanation;
    this.label_5.Visible = ShowExplanation;
    this.label_23.Visible = ShowExplanation;
    this.label_20.Visible = ShowExplanation;
    this.label_10.Visible = ShowExplanation;
    this.label_17.Visible = ShowExplanation;
    if (!(DecimalCount >= 0 & DecimalCount <= 5))
      return;
    this.numericUpDown_2.DecimalPlaces = DecimalCount;
    this.numericUpDown_4.DecimalPlaces = DecimalCount;
    this.numericUpDown_1.DecimalPlaces = DecimalCount;
    this.numericUpDown_3.DecimalPlaces = DecimalCount;
    this.numericUpDown_5.DecimalPlaces = DecimalCount;
  }

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
    int num1 = 0;
    this.numericUpDown_0.DecimalPlaces = 0;
    this.numericUpDown_2.DecimalPlaces = this.DecimalCount;
    this.numericUpDown_4.DecimalPlaces = this.DecimalCount;
    this.numericUpDown_1.DecimalPlaces = this.DecimalCount;
    this.numericUpDown_3.DecimalPlaces = this.DecimalCount;
    this.numericUpDown_5.DecimalPlaces = this.DecimalCount;
    this.panel_2.Visible = this.DataEnable.StartValue;
    if (this.DataEnable.StartValue)
    {
      this.panel_2.Top = 40 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_4.Visible = this.DataEnable.EndValue;
    if (this.DataEnable.EndValue)
    {
      this.panel_4.Top = 40 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_5.Visible = this.DataEnable.Step;
    if (this.DataEnable.Step)
    {
      this.panel_5.Top = 40 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_0.Visible = this.DataEnable.Count;
    if (this.DataEnable.Count)
    {
      this.panel_0.Top = 40 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_3.Visible = this.DataEnable.Distance;
    if (this.DataEnable.Distance)
    {
      this.panel_3.Top = 40 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_1.Visible = this.DataEnable.MoveUp;
    if (this.DataEnable.MoveUp)
    {
      this.panel_1.Top = 40 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_7.Visible = this.DataEnable.MoveUpType;
    if (this.DataEnable.MoveUpType)
    {
      this.panel_7.Top = 40 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.panel_6.Visible = this.DataEnable.Sequence;
    if (this.DataEnable.Sequence)
    {
      this.panel_6.Top = 40 + num1 * 32 /*0x20*/;
      ++num1;
    }
    if (num1 > 0)
    {
      int num2 = 0;
      int num3 = 0;
      int num4 = 385;
      int num5 = 0;
      if (this.ShowCancelButton | this.ShowOkButton)
        num5 = 50;
      if (this.ShowExplanation)
        num2 = this.label_2.Width;
      if (this.ShowImages)
        num3 = this.label_0.Width;
      this.Height = num1 * 32 /*0x20*/ + 80 /*0x50*/ + num5;
      this.Width = num4 + num2 + num3;
    }
    this.label_2.Visible = this.ShowExplanation;
    this.label_8.Visible = this.ShowExplanation;
    this.label_14.Visible = this.ShowExplanation;
    this.label_5.Visible = this.ShowExplanation;
    this.label_23.Visible = this.ShowExplanation;
    this.label_20.Visible = this.ShowExplanation;
    this.label_10.Visible = this.ShowExplanation;
    this.label_17.Visible = this.ShowExplanation;
    this.label_0.Visible = this.ShowImages;
    this.label_6.Visible = this.ShowImages;
    this.label_12.Visible = this.ShowImages;
    this.label_3.Visible = this.ShowImages;
    this.label_21.Visible = this.ShowImages;
    this.label_11.Visible = this.ShowImages;
    this.label_15.Visible = this.ShowImages;
    this.btn_ok.Visible = this.ShowOkButton;
    this.btn_cancel.Visible = this.ShowCancelButton;
    this.checkBox_1.Checked = this.Data.Enable;
    this.numericUpDown_0.Value = (Decimal) this.Data.Count;
    this.numericUpDown_2.Value = (Decimal) this.Data.Distance;
    this.numericUpDown_4.Value = (Decimal) this.Data.EndValue;
    this.numericUpDown_3.Value = (Decimal) this.Data.StartValue;
    this.numericUpDown_5.Value = (Decimal) this.Data.Step;
    this.numericUpDown_1.Value = (Decimal) this.Data.MoveUp;
    this.checkBox_0.Checked = this.Data.MoveUpEnable;
    this.radioButton_3.Checked = false;
    this.radioButton_2.Checked = false;
    if (this.Data.MoveUpType == CamMoveUpType.Absolute)
      this.radioButton_3.Checked = true;
    if (this.Data.MoveUpType == CamMoveUpType.Incremental)
      this.radioButton_2.Checked = true;
    this.radioButton_1.Checked = false;
    this.radioButton_0.Checked = false;
    if (this.Data.Sequence == CamMachiningSequenceType.Level)
      this.radioButton_1.Checked = true;
    if (this.Data.Sequence == CamMachiningSequenceType.Region)
      this.radioButton_0.Checked = true;
    if (this.FormSize.Width > 1)
      this.Width = this.FormSize.Width;
    if (this.FormSize.Height > 1)
      this.Height = this.FormSize.Height;
    Class39.smethod_312(this);
    this.Result = DialogResult.None;
  }

  public void Apply()
  {
    this.Data.Enable = this.checkBox_1.Checked;
    this.Data.Count = (int) this.numericUpDown_0.Value;
    this.Data.Distance = (double) this.numericUpDown_2.Value;
    this.Data.EndValue = (double) this.numericUpDown_4.Value;
    this.Data.StartValue = (double) this.numericUpDown_3.Value;
    this.Data.Step = (double) this.numericUpDown_5.Value;
    this.Data.MoveUp = (double) this.numericUpDown_1.Value;
    this.Data.MoveUpEnable = this.checkBox_0.Checked;
    if (this.radioButton_3.Checked)
      this.Data.MoveUpType = CamMoveUpType.Absolute;
    if (this.radioButton_2.Checked)
      this.Data.MoveUpType = CamMoveUpType.Incremental;
    if (this.radioButton_1.Checked)
      this.Data.Sequence = CamMachiningSequenceType.Level;
    if (!this.radioButton_0.Checked)
      return;
    this.Data.Sequence = CamMachiningSequenceType.Region;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Apply();
    this.Result = DialogResult.OK;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithDataEventHandler_0((object) this.Data);
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  internal void method_3(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.Controls, result, e.Shift);
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      buSpin buSpin = new buSpin();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
