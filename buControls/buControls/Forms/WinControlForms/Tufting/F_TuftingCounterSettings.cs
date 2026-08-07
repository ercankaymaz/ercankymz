// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tufting.F_TuftingCounterSettings
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

public class F_TuftingCounterSettings : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  public TuftingSettings Settings = new TuftingSettings();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Panel panel_0;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Label label_2;
  internal Panel panel_1;
  internal RadioButton radioButton_2;
  internal RadioButton radioButton_3;
  internal Label label_3;
  internal Panel panel_2;
  internal Label label_4;
  internal NumericUpDown numericUpDown_2;
  internal Label label_5;
  internal Panel panel_3;
  internal Label label_6;
  internal NumericUpDown numericUpDown_3;
  internal Panel panel_4;
  internal RadioButton radioButton_4;
  internal RadioButton radioButton_5;
  internal Label label_7;
  internal Label label_8;
  internal Panel panel_5;
  internal RadioButton radioButton_6;
  internal RadioButton radioButton_7;
  internal Label label_9;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal CheckBox checkBox_2;
  internal CheckBox checkBox_3;

  public F_TuftingCounterSettings() => Class39.smethod_200(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Settings.ContourOutBorderType == tuftingBorderOffsetType.Contour)
      this.radioButton_2.Checked = true;
    else if (this.Settings.ContourOutBorderType == tuftingBorderOffsetType.Spiral)
      this.radioButton_3.Checked = true;
    if (this.Settings.ContourOutBorderFillDirection == ClockDirectionType.CCW)
      this.radioButton_0.Checked = true;
    else if (this.Settings.ContourOutBorderFillDirection == ClockDirectionType.CW)
      this.radioButton_1.Checked = true;
    this.numericUpDown_2.Value = (Decimal) this.Settings.ContourOutBorderCount;
    if (this.Settings.ContourInBorderType == tuftingBorderOffsetType.Contour)
      this.radioButton_4.Checked = true;
    else if (this.Settings.ContourInBorderType == tuftingBorderOffsetType.Spiral)
      this.radioButton_5.Checked = true;
    if (this.Settings.ContourInBorderFillDirection == ClockDirectionType.CCW)
      this.radioButton_6.Checked = true;
    else if (this.Settings.ContourInBorderFillDirection == ClockDirectionType.CW)
      this.radioButton_7.Checked = true;
    this.numericUpDown_3.Value = (Decimal) this.Settings.ContourInBorderCount;
    this.numericUpDown_2.Value = (Decimal) this.Settings.ContourOutBorderCount;
    this.numericUpDown_1.Value = (Decimal) this.Settings.ContourInnerOffset;
    this.numericUpDown_0.Value = (Decimal) this.Settings.ContourOutterOffset;
    this.checkBox_1.Checked = this.Settings.ContourOutBorderConnect;
    this.checkBox_0.Checked = this.Settings.ContourInBorderConenct;
    this.checkBox_3.Checked = this.Settings.ContourOutBorderEnable;
    this.checkBox_2.Checked = this.Settings.ContourInBorderEnable;
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
      if (F_TuftingCounterSettings.Captions.Count >= 9)
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
      this.Settings.ContourInBorderCount = (int) this.numericUpDown_3.Value;
      this.Settings.ContourInnerOffset = (double) this.numericUpDown_1.Value;
      this.Settings.ContourOutterOffset = (double) this.numericUpDown_0.Value;
      this.Settings.ContourOutBorderCount = (int) this.numericUpDown_2.Value;
      this.Settings.ContourOutBorderConnect = this.checkBox_1.Checked;
      this.Settings.ContourInBorderConenct = this.checkBox_0.Checked;
      this.Settings.ContourOutBorderEnable = this.checkBox_3.Checked;
      this.Settings.ContourInBorderEnable = this.checkBox_2.Checked;
      if (this.radioButton_2.Checked)
        this.Settings.ContourOutBorderType = tuftingBorderOffsetType.Contour;
      else if (this.radioButton_3.Checked)
        this.Settings.ContourOutBorderType = tuftingBorderOffsetType.Spiral;
      if (this.radioButton_0.Checked)
        this.Settings.ContourOutBorderFillDirection = ClockDirectionType.CCW;
      else if (this.radioButton_1.Checked)
        this.Settings.ContourOutBorderFillDirection = ClockDirectionType.CW;
      if (this.radioButton_4.Checked)
        this.Settings.ContourInBorderType = tuftingBorderOffsetType.Contour;
      else if (this.radioButton_5.Checked)
        this.Settings.ContourInBorderType = tuftingBorderOffsetType.Spiral;
      if (this.radioButton_6.Checked)
        this.Settings.ContourInBorderFillDirection = ClockDirectionType.CCW;
      else if (this.radioButton_7.Checked)
        this.Settings.ContourInBorderFillDirection = ClockDirectionType.CW;
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
