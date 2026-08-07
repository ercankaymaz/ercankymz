// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Spining.F_MetalSpinningSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Spining;

public class F_MetalSpinningSettings : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public SpinPattern varSpinPattern = new SpinPattern();
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal Panel panel_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  public Button btn_ok;
  internal ImageList imageList_0;
  public Button btn_cancel;
  internal NumericUpDown numericUpDown_3;
  internal Label label_4;
  internal NumericUpDown numericUpDown_4;
  internal Label label_5;
  internal NumericUpDown numericUpDown_5;
  internal Label label_6;
  internal Panel panel_1;
  internal NumericUpDown numericUpDown_6;
  internal Label label_7;
  internal NumericUpDown numericUpDown_7;
  internal Label label_8;
  internal Label label_9;
  internal Label label_10;
  internal NumericUpDown numericUpDown_8;
  internal NumericUpDown numericUpDown_9;
  internal Label label_11;
  internal Label label_12;
  internal NumericUpDown numericUpDown_10;
  internal NumericUpDown numericUpDown_11;
  internal Label label_13;
  internal NumericUpDown numericUpDown_12;
  internal Label label_14;

  public F_MetalSpinningSettings() => Class39.smethod_744(this);

  public event ApplyCommandWithDataEventHandler SpinValueChanged;

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.numericUpDown_1.Value = (Decimal) this.varSpinPattern.LeaveArcRadiusRatioFromHeight90To100;
    this.numericUpDown_2.Value = (Decimal) this.varSpinPattern.LeaveArcRadiusRatioFromHeight100To110;
    this.numericUpDown_0.Value = (Decimal) this.varSpinPattern.LeaveArcRadiusRatioFromHeight110To120;
    this.numericUpDown_4.Value = (Decimal) this.varSpinPattern.LeaveArcRadiusRatioFromHeight120To130;
    this.numericUpDown_3.Value = (Decimal) this.varSpinPattern.LeaveArcRadiusRatioFromHeight130To150;
    this.numericUpDown_5.Value = (Decimal) this.varSpinPattern.LeaveArcRadiusRatioFromHeight150To180;
    this.numericUpDown_8.Value = (Decimal) this.varSpinPattern.LeaveDeltaAngleRatio;
    this.numericUpDown_6.Value = (Decimal) this.varSpinPattern.CurveEndExtend;
    this.numericUpDown_9.Value = (Decimal) this.varSpinPattern.LeaveMaxAngle;
    this.numericUpDown_10.Value = (Decimal) this.varSpinPattern.LeaveMinAngle;
    this.numericUpDown_7.Value = (Decimal) this.varSpinPattern.CurveStartExtend;
    this.numericUpDown_11.Value = (Decimal) this.varSpinPattern.CurveOffset;
    this.numericUpDown_12.Value = (Decimal) this.varSpinPattern.CurveFinishOffset;
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
      if (F_MetalSpinningSettings.Captions.Count >= 9)
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
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
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
    this.varSpinPattern.LeaveArcRadiusRatioFromHeight90To100 = (double) this.numericUpDown_1.Value;
    this.varSpinPattern.LeaveArcRadiusRatioFromHeight100To110 = (double) this.numericUpDown_2.Value;
    this.varSpinPattern.LeaveArcRadiusRatioFromHeight110To120 = (double) this.numericUpDown_0.Value;
    this.varSpinPattern.LeaveArcRadiusRatioFromHeight120To130 = (double) this.numericUpDown_4.Value;
    this.varSpinPattern.LeaveArcRadiusRatioFromHeight130To150 = (double) this.numericUpDown_3.Value;
    this.varSpinPattern.LeaveArcRadiusRatioFromHeight150To180 = (double) this.numericUpDown_5.Value;
    this.varSpinPattern.LeaveDeltaAngleRatio = (double) this.numericUpDown_8.Value;
    this.varSpinPattern.CurveEndExtend = (double) this.numericUpDown_6.Value;
    this.varSpinPattern.LeaveMaxAngle = (double) this.numericUpDown_9.Value;
    this.varSpinPattern.LeaveMinAngle = (double) this.numericUpDown_10.Value;
    this.varSpinPattern.CurveStartExtend = (double) this.numericUpDown_7.Value;
    this.varSpinPattern.CurveOffset = (double) this.numericUpDown_11.Value;
    this.varSpinPattern.CurveFinishOffset = (double) this.numericUpDown_12.Value;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.applyCommandWithDataEventHandler_0((object) this.varSpinPattern);
    }
    this.PropertiesForm.Inited = true;
  }

  internal void method_3(object sender, EventArgs e)
  {
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control = new Control();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
