// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Marble.F_MarbleProfileCut
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
namespace buControls.Forms.WinControlForms.Marble;

public class F_MarbleProfileCut : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public marbleProfileCut varProfileCut = new marbleProfileCut();
  public string strMessageRoughtFinish = "Rought and  Finish Both Can't be Enabled";
  public string strMessageRoughtFinishSelect = "Rought or Finish One of them must be Selected";
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal Panel panel_0;
  internal RadioButton radioButton_0;
  internal Panel panel_1;
  internal RadioButton radioButton_1;
  internal RadioButton radioButton_2;
  internal Label label_3;
  internal Panel panel_2;
  internal CheckBox checkBox_0;
  internal Label label_4;
  internal Panel panel_3;
  internal CheckBox checkBox_1;
  internal Label label_5;
  internal Panel panel_4;
  internal RadioButton radioButton_3;
  internal RadioButton radioButton_4;
  internal Label label_6;
  internal Panel panel_5;
  internal Label label_7;
  internal Label label_8;
  internal NumericUpDown numericUpDown_2;
  internal Label label_9;
  internal NumericUpDown numericUpDown_3;
  internal Label label_10;
  internal NumericUpDown numericUpDown_4;
  internal CheckBox checkBox_2;
  internal Label label_11;
  internal NumericUpDown numericUpDown_5;
  internal CheckBox checkBox_3;
  internal CheckBox checkBox_4;
  internal Label label_12;
  internal NumericUpDown numericUpDown_6;
  internal Label label_13;
  internal NumericUpDown numericUpDown_7;
  internal Label label_14;
  internal NumericUpDown numericUpDown_8;
  internal CheckBox checkBox_5;
  internal Label label_15;
  internal NumericUpDown numericUpDown_9;

  public F_MarbleProfileCut() => Class39.smethod_289(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.checkBox_1.Checked = this.varProfileCut.FinishEnable;
    this.checkBox_0.Checked = this.varProfileCut.RoughEnable;
    this.checkBox_2.Checked = this.varProfileCut.MaxToMinDirection;
    this.checkBox_4.Checked = this.varProfileCut.SmoothZigzagMode;
    this.checkBox_3.Checked = this.varProfileCut.RoughZigzagMode;
    this.checkBox_5.Checked = this.varProfileCut.MoveSafeDistanceForFinishZigzagMode;
    this.numericUpDown_9.Value = (Decimal) this.varProfileCut.RotationAngle;
    this.numericUpDown_5.Value = (Decimal) this.varProfileCut.StartPosition;
    this.numericUpDown_1.Value = (Decimal) this.varProfileCut.BaseHeight;
    this.numericUpDown_0.Value = (Decimal) this.varProfileCut.Length;
    this.numericUpDown_2.Value = (Decimal) this.varProfileCut.FinishStep;
    this.numericUpDown_3.Value = (Decimal) this.varProfileCut.RoughtOffset;
    this.numericUpDown_4.Value = (Decimal) this.varProfileCut.FinishOffset;
    this.numericUpDown_8.Value = (Decimal) this.varProfileCut.RoughtDevideLen;
    this.numericUpDown_7.Value = (Decimal) this.varProfileCut.FinishDevideLen;
    this.numericUpDown_6.Value = (Decimal) this.varProfileCut.DownDevideLen;
    this.radioButton_0.Checked = true;
    if (this.varProfileCut.CamTypeRough == CamAxisCountType.Axis3)
      this.radioButton_2.Checked = true;
    else
      this.radioButton_1.Checked = true;
    if (this.varProfileCut.CamTypeFinish == CamAxisCountType.Axis3)
      this.radioButton_4.Checked = true;
    else
      this.radioButton_3.Checked = true;
    Class39.smethod_669(this);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.btn_ok.Name)
      {
        if (this.checkBox_1.Checked & this.checkBox_0.Checked)
        {
          buString.MessageBoxWarning(this.strMessageRoughtFinish);
          return;
        }
        if (!this.checkBox_1.Checked & !this.checkBox_0.Checked)
        {
          buString.MessageBoxWarning(this.strMessageRoughtFinishSelect);
          return;
        }
        Class39.smethod_646(this);
        this.Properties.Result = DialogResult.OK;
        if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == this.btn_cancel.Name))
        return;
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!this.Properties.Inited)
      ;
  }

  internal void method_3(object sender, PaintEventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
