// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_DepthParameter
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Profile;

public class F_DepthParameter : Form
{
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public ProfileDepth Depth = new ProfileDepth();
  private bool bool_0 = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal ImageList imageList_0;
  internal Panel panel_0;
  internal Label label_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;

  public F_DepthParameter() => Class39.smethod_191(this);

  public void Init()
  {
    this.numericUpDown_1.Value = (Decimal) this.Depth.SafeMoveAbsolute;
    this.numericUpDown_0.Value = (Decimal) this.Depth.SafeMoveRelative;
    this.checkBox_1.Checked = this.Depth.SaveMoveAbsouluteEnable;
    this.checkBox_0.Checked = this.Depth.SaveMoveRelativeEnable;
    if (this.Depth.Type == ProfileDepthModeType.EachLayerStep)
    {
      this.radioButton_0.Checked = true;
      this.radioButton_1.Checked = false;
    }
    if (this.Depth.Type == ProfileDepthModeType.SelectedLayer)
    {
      this.radioButton_0.Checked = false;
      this.radioButton_1.Checked = true;
    }
    this.bool_0 = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    if (!this.bool_0 || this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Apply();
    this.Result = DialogResult.OK;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    this.Depth.SafeMoveAbsolute = (double) this.numericUpDown_1.Value;
    this.Depth.SafeMoveRelative = (double) this.numericUpDown_0.Value;
    this.Depth.SaveMoveAbsouluteEnable = this.checkBox_1.Checked;
    this.Depth.SaveMoveRelativeEnable = this.checkBox_0.Checked;
    if (this.radioButton_0.Checked)
      this.Depth.Type = ProfileDepthModeType.EachLayerStep;
    if (!this.radioButton_1.Checked)
      return;
    this.Depth.Type = ProfileDepthModeType.SelectedLayer;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
