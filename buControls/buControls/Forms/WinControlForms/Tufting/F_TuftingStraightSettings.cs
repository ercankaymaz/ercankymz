// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tufting.F_TuftingStraightSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Tufting;

public class F_TuftingStraightSettings : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  public TuftingSettings Settings = new TuftingSettings();
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Panel panel_0;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal RadioButton radioButton_2;
  internal Label label_0;
  internal Panel panel_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_6;
  internal NumericUpDown numericUpDown_4;
  internal Panel panel_2;
  internal RadioButton radioButton_3;
  internal RadioButton radioButton_4;
  internal Label label_7;
  internal Panel panel_3;
  internal RadioButton radioButton_5;
  internal RadioButton radioButton_6;
  internal Label label_8;
  internal Panel panel_4;
  internal Label label_9;
  internal NumericUpDown numericUpDown_5;
  internal CheckBox checkBox_0;
  internal Label label_10;
  internal Panel panel_5;
  internal Label label_11;
  internal NumericUpDown numericUpDown_6;
  internal CheckBox checkBox_1;
  internal Panel panel_6;
  internal RadioButton radioButton_7;
  internal RadioButton radioButton_8;
  internal Label label_12;
  internal Label label_13;
  internal Panel panel_7;
  internal RadioButton radioButton_9;
  internal RadioButton radioButton_10;
  internal Label label_14;
  internal CheckBox checkBox_2;
  internal CheckBox checkBox_3;
  internal CheckBox checkBox_4;

  public F_TuftingStraightSettings() => Class39.smethod_501(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Settings.StraightOutBorderType == tuftingBorderOffsetType.Contour)
      this.radioButton_5.Checked = true;
    else if (this.Settings.StraightOutBorderType == tuftingBorderOffsetType.Spiral)
      this.radioButton_6.Checked = true;
    if (this.Settings.StraightOutBorderFillDirection == ClockDirectionType.CCW)
      this.radioButton_3.Checked = true;
    else if (this.Settings.StraightOutBorderFillDirection == ClockDirectionType.CW)
      this.radioButton_4.Checked = true;
    this.checkBox_0.Checked = this.Settings.StraightOutBorderEnable;
    this.numericUpDown_5.Value = (Decimal) this.Settings.StraightOutBorderCount;
    if (this.Settings.StraightInBorderType == tuftingBorderOffsetType.Contour)
      this.radioButton_7.Checked = true;
    else if (this.Settings.StraightInBorderType == tuftingBorderOffsetType.Spiral)
      this.radioButton_8.Checked = true;
    if (this.Settings.StraightInBorderFillDirection == ClockDirectionType.CCW)
      this.radioButton_9.Checked = true;
    else if (this.Settings.StraightInBorderFillDirection == ClockDirectionType.CW)
      this.radioButton_10.Checked = true;
    this.checkBox_1.Checked = this.Settings.StraightInBorderEnable;
    this.numericUpDown_6.Value = (Decimal) this.Settings.StraightInBorderCount;
    this.checkBox_0.Checked = this.Settings.StraightOutBorderEnable;
    this.numericUpDown_5.Value = (Decimal) this.Settings.StraightOutBorderCount;
    this.checkBox_4.Checked = this.Settings.StraightRowLink;
    this.numericUpDown_1.Value = (Decimal) this.Settings.StraightDirection;
    this.numericUpDown_0.Value = (Decimal) this.Settings.StraightAngle;
    this.numericUpDown_2.Value = (Decimal) this.Settings.StraightRowSpace;
    this.numericUpDown_4.Value = (Decimal) this.Settings.StraightInnerOffset;
    this.numericUpDown_3.Value = (Decimal) this.Settings.StraightOutterOffset;
    this.checkBox_2.Checked = this.Settings.StraightOutBorderConnect;
    this.checkBox_3.Checked = this.Settings.StraightInBorderConenct;
    this.ControlUpdate();
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_TuftingStraightSettings.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      this.Settings.StraightInBorderEnable = this.checkBox_1.Checked;
      this.Settings.StraightInBorderCount = (int) this.numericUpDown_6.Value;
      this.Settings.StraightDirection = (double) this.numericUpDown_1.Value;
      this.Settings.StraightAngle = (double) this.numericUpDown_0.Value;
      this.Settings.StraightRowSpace = (double) this.numericUpDown_2.Value;
      this.Settings.StraightInnerOffset = (double) this.numericUpDown_4.Value;
      this.Settings.StraightOutterOffset = (double) this.numericUpDown_3.Value;
      this.Settings.StraightOutBorderEnable = this.checkBox_0.Checked;
      this.Settings.StraightOutBorderCount = (int) this.numericUpDown_5.Value;
      this.Settings.StraightOutBorderConnect = this.checkBox_2.Checked;
      this.Settings.StraightInBorderConenct = this.checkBox_3.Checked;
      this.Settings.StraightRowLink = this.checkBox_4.Checked;
      if (this.radioButton_5.Checked)
        this.Settings.StraightOutBorderType = tuftingBorderOffsetType.Contour;
      else if (this.radioButton_6.Checked)
        this.Settings.StraightOutBorderType = tuftingBorderOffsetType.Spiral;
      if (this.radioButton_3.Checked)
        this.Settings.StraightOutBorderFillDirection = ClockDirectionType.CCW;
      else if (this.radioButton_4.Checked)
        this.Settings.StraightOutBorderFillDirection = ClockDirectionType.CW;
      if (this.radioButton_7.Checked)
        this.Settings.StraightInBorderType = tuftingBorderOffsetType.Contour;
      else if (this.radioButton_8.Checked)
        this.Settings.StraightInBorderType = tuftingBorderOffsetType.Spiral;
      if (this.radioButton_9.Checked)
        this.Settings.StraightInBorderFillDirection = ClockDirectionType.CCW;
      else if (this.radioButton_10.Checked)
        this.Settings.StraightInBorderFillDirection = ClockDirectionType.CW;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
