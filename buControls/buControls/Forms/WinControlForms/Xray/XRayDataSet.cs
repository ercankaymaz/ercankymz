// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Xray.XRayDataSet
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
namespace buControls.Forms.WinControlForms.Xray;

public class XRayDataSet : Form
{
  public XRayData XRayVar = new XRayData();
  public FormProperties Properties = new FormProperties();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal NumericUpDown numericUpDown_5;
  internal Label label_5;
  internal NumericUpDown numericUpDown_6;
  internal Label label_6;
  internal NumericUpDown numericUpDown_7;
  internal Label label_7;
  internal NumericUpDown numericUpDown_8;
  internal Label label_8;
  internal NumericUpDown numericUpDown_9;
  internal Label label_9;
  internal NumericUpDown numericUpDown_10;
  internal Label label_10;
  internal CheckBox checkBox_0;
  internal RadioButton radioButton_0;
  internal CheckBox checkBox_1;
  internal CheckBox checkBox_2;
  internal RadioButton radioButton_1;
  internal Panel panel_0;
  internal ImageList imageList_0;
  internal Button button_0;
  internal Button button_1;
  internal NumericUpDown numericUpDown_11;
  internal Label label_11;
  internal NumericUpDown numericUpDown_12;
  internal Label label_12;

  public XRayDataSet() => Class39.smethod_785(this);

  public void Init()
  {
    try
    {
      this.numericUpDown_10.Value = (Decimal) this.XRayVar.Bottom;
      this.numericUpDown_3.Value = (Decimal) this.XRayVar.FlipH;
      this.numericUpDown_6.Value = (Decimal) this.XRayVar.FlipV;
      this.numericUpDown_5.Value = (Decimal) this.XRayVar.Frames;
      this.numericUpDown_0.Value = (Decimal) this.XRayVar.Kv;
      this.numericUpDown_9.Value = (Decimal) this.XRayVar.Left;
      this.numericUpDown_1.Value = (Decimal) this.XRayVar.Ma;
      this.numericUpDown_7.Value = (Decimal) this.XRayVar.Right;
      this.numericUpDown_4.Value = (Decimal) this.XRayVar.Rot;
      this.numericUpDown_2.Value = (Decimal) this.XRayVar.Time;
      this.numericUpDown_8.Value = (Decimal) this.XRayVar.Top;
      this.numericUpDown_11.Value = (Decimal) this.XRayVar.GrayAuto;
      this.numericUpDown_12.Value = (Decimal) this.XRayVar.FeedVel;
      if (this.XRayVar.Focus == XRayFocus.Large)
      {
        this.radioButton_0.Checked = true;
        this.radioButton_1.Checked = false;
      }
      else
      {
        this.radioButton_0.Checked = false;
        this.radioButton_1.Checked = true;
      }
      this.checkBox_1.Checked = this.XRayVar.Image;
      this.checkBox_2.Checked = this.XRayVar.Video;
      this.checkBox_0.Checked = this.XRayVar.XRay;
    }
    catch (Exception ex)
    {
    }
  }

  public void Apply()
  {
    this.XRayVar.Bottom = (double) this.numericUpDown_10.Value;
    this.XRayVar.FlipH = (double) this.numericUpDown_3.Value;
    this.XRayVar.FlipV = (double) this.numericUpDown_6.Value;
    this.XRayVar.Frames = (double) this.numericUpDown_5.Value;
    this.XRayVar.Kv = (double) this.numericUpDown_0.Value;
    this.XRayVar.Left = (double) this.numericUpDown_9.Value;
    this.XRayVar.Ma = (double) this.numericUpDown_1.Value;
    this.XRayVar.Right = (double) this.numericUpDown_7.Value;
    this.XRayVar.Rot = (double) this.numericUpDown_4.Value;
    this.XRayVar.Time = (double) this.numericUpDown_2.Value;
    this.XRayVar.Top = (double) this.numericUpDown_8.Value;
    this.XRayVar.GrayAuto = (double) this.numericUpDown_11.Value;
    this.XRayVar.FeedVel = (double) this.numericUpDown_12.Value;
    this.XRayVar.Image = this.checkBox_1.Checked;
    this.XRayVar.Video = this.checkBox_2.Checked;
    this.XRayVar.XRay = this.checkBox_0.Checked;
    if (this.radioButton_0.Checked)
      this.XRayVar.Focus = XRayFocus.Large;
    else
      this.XRayVar.Focus = XRayFocus.Small;
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
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
