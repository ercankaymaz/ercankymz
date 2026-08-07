// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tufting.F_TuftingSpiralSettings
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

public class F_TuftingSpiralSettings : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  public TuftingSettings Settings = new TuftingSettings();
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  internal Panel panel_0;
  internal Label label_0;
  public Button btn_ok;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal Panel panel_1;
  internal Label label_4;
  internal Panel panel_2;
  internal RadioButton radioButton_2;
  internal RadioButton radioButton_3;
  internal Label label_5;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;

  public F_TuftingSpiralSettings() => Class39.smethod_718(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Settings.SpiralFillDirection == ClockDirectionType.CW)
      this.radioButton_1.Checked = true;
    else if (this.Settings.SpiralFillDirection == ClockDirectionType.CCW)
      this.radioButton_0.Checked = true;
    if (this.Settings.SpiralInOutDirection == InOutDirection.InsideToOutside)
      this.radioButton_3.Checked = true;
    else if (this.Settings.SpiralInOutDirection == InOutDirection.OutsideToInside)
      this.radioButton_2.Checked = true;
    this.numericUpDown_1.Value = (Decimal) this.Settings.SpiralInnerOffset;
    this.numericUpDown_0.Value = (Decimal) this.Settings.SpiralOutterOffset;
    this.numericUpDown_2.Value = (Decimal) this.Settings.SpiralRowSpace;
    this.checkBox_0.Checked = this.Settings.SpiralInnerEnable;
    this.checkBox_1.Checked = this.Settings.SpiralOutterEnable;
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
      if (F_TuftingSpiralSettings.Captions.Count >= 9)
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
      this.Settings.SpiralInnerOffset = (double) this.numericUpDown_1.Value;
      this.Settings.SpiralOutterOffset = (double) this.numericUpDown_0.Value;
      this.Settings.SpiralRowSpace = (double) this.numericUpDown_2.Value;
      this.Settings.SpiralInnerEnable = this.checkBox_0.Checked;
      this.Settings.SpiralOutterEnable = this.checkBox_1.Checked;
      if (this.radioButton_0.Checked)
        this.Settings.SpiralFillDirection = ClockDirectionType.CCW;
      else if (this.radioButton_1.Checked)
        this.Settings.SpiralFillDirection = ClockDirectionType.CW;
      if (this.radioButton_3.Checked)
        this.Settings.SpiralInOutDirection = InOutDirection.InsideToOutside;
      else if (this.radioButton_2.Checked)
        this.Settings.SpiralInOutDirection = InOutDirection.OutsideToInside;
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
