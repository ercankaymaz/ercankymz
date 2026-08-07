// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.CAM.F_CamSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.UserFiles.buCad;
using buControls.DialogBox;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.CAM;

public class F_CamSettings : Form
{
  public FormProperties Properties = new FormProperties();
  public setCam varCam = new setCam();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal CheckBox checkBox_2;
  internal CheckBox checkBox_3;
  internal CheckBox checkBox_4;
  internal CheckBox checkBox_5;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal CheckBox checkBox_6;
  internal Button button_7;
  internal CheckBox checkBox_7;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal NumericUpDown numericUpDown_4;
  internal NumericUpDown numericUpDown_5;
  internal NumericUpDown numericUpDown_6;
  internal NumericUpDown numericUpDown_7;

  public F_CamSettings() => Class39.smethod_677(this);

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

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    this.checkBox_0.Checked = this.varCam.ShowCamG0Drawings;
    this.checkBox_1.Checked = this.varCam.ShowCamG1Drawings;
    this.checkBox_6.Checked = this.varCam.ShowCamLeadinDrawings;
    this.checkBox_7.Checked = this.varCam.ShowCamLeadOutDrawings;
    this.checkBox_4.Checked = this.varCam.ShowCamLeaveDrawings;
    this.checkBox_2.Checked = this.varCam.ShowCamMarkDrawings;
    this.checkBox_3.Checked = this.varCam.ShowCamOtherDrawings;
    this.checkBox_5.Checked = this.varCam.ShowCamPlungeDrawings;
    this.button_0.BackColor = this.varCam.CamG0Draw.Color;
    this.button_1.BackColor = this.varCam.CamG1Draw.Color;
    this.button_6.BackColor = this.varCam.CamLeadinDraw.Color;
    this.button_7.BackColor = this.varCam.CamLeadOutDraw.Color;
    this.button_4.BackColor = this.varCam.CamLeaveDraw.Color;
    this.button_2.BackColor = this.varCam.CamMarkDraw.Color;
    this.button_5.BackColor = this.varCam.CamOtherDraw.Color;
    this.button_3.BackColor = this.varCam.CamPlungeDraw.Color;
    this.numericUpDown_0.Value = (Decimal) this.varCam.CamG0Draw.Thickness;
    this.numericUpDown_1.Value = (Decimal) this.varCam.CamG1Draw.Thickness;
    this.numericUpDown_6.Value = (Decimal) this.varCam.CamLeadinDraw.Thickness;
    this.numericUpDown_5.Value = (Decimal) this.varCam.CamLeadOutDraw.Thickness;
    this.numericUpDown_7.Value = (Decimal) this.varCam.CamLeaveDraw.Thickness;
    this.numericUpDown_3.Value = (Decimal) this.varCam.CamMarkDraw.Thickness;
    this.numericUpDown_4.Value = (Decimal) this.varCam.CamOtherDraw.Thickness;
    this.numericUpDown_2.Value = (Decimal) this.varCam.CamPlungeDraw.Thickness;
    this.Refresh();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    Class39.smethod_387(this);
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_0(this);
      this.Properties.Result = DialogResult.OK;
      this.Dispose();
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

  internal void method_2(object sender, EventArgs e)
  {
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!(((Control) sender).Name == this.button_0.Name))
      return;
    ColorDialogBox.ShowDialog(this.button_0.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    this.button_0.BackColor = ColorDialogBox.Color;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
