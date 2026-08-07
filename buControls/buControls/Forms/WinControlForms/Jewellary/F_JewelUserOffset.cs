// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_JewelUserOffset
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelUserOffset : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public Pnt3D SpindleUserOffset = new Pnt3D();
  public Pnt3D DiaCut1UserOffset = new Pnt3D();
  public Pnt3D DiaCut2UserOffset = new Pnt3D();
  public Pnt3D EngraveUserOffset = new Pnt3D();
  public Pnt3D LaserUserOffset = new Pnt3D();
  public Pnt3D LatheUserOffset = new Pnt3D();
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  internal Label label_8;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal NumericUpDown numericUpDown_4;
  internal NumericUpDown numericUpDown_5;
  internal NumericUpDown numericUpDown_6;
  internal NumericUpDown numericUpDown_7;
  internal NumericUpDown numericUpDown_8;
  internal NumericUpDown numericUpDown_9;
  internal NumericUpDown numericUpDown_10;
  internal NumericUpDown numericUpDown_11;
  internal NumericUpDown numericUpDown_12;
  internal NumericUpDown numericUpDown_13;
  internal NumericUpDown numericUpDown_14;
  internal NumericUpDown numericUpDown_15;
  internal NumericUpDown numericUpDown_16;
  internal NumericUpDown numericUpDown_17;
  public Button btn_cancel;
  public Button btn_save;

  public F_JewelUserOffset() => Class39.smethod_534(this);

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
    try
    {
      this.Properties.Inited = false;
      if (this.Properties.Height > 10)
        this.Height = this.Properties.Height;
      if (this.Properties.Width > 10)
        this.Width = this.Properties.Width;
      this.TopMost = this.Properties.TopMost;
      this.StartPosition = this.Properties.FormPosition;
      this.AutoScaleMode = this.Properties.ScaleFromMode;
      this.numericUpDown_0.Value = (Decimal) this.SpindleUserOffset.X;
      this.numericUpDown_1.Value = (Decimal) this.SpindleUserOffset.Y;
      this.numericUpDown_2.Value = (Decimal) this.SpindleUserOffset.Z;
      this.numericUpDown_5.Value = (Decimal) this.DiaCut1UserOffset.X;
      this.numericUpDown_4.Value = (Decimal) this.DiaCut1UserOffset.Y;
      this.numericUpDown_3.Value = (Decimal) this.DiaCut1UserOffset.Z;
      this.numericUpDown_11.Value = (Decimal) this.DiaCut2UserOffset.X;
      this.numericUpDown_10.Value = (Decimal) this.DiaCut2UserOffset.Y;
      this.numericUpDown_9.Value = (Decimal) this.DiaCut2UserOffset.Z;
      this.numericUpDown_8.Value = (Decimal) this.EngraveUserOffset.X;
      this.numericUpDown_7.Value = (Decimal) this.EngraveUserOffset.Y;
      this.numericUpDown_6.Value = (Decimal) this.EngraveUserOffset.Z;
      this.numericUpDown_17.Value = (Decimal) this.LaserUserOffset.X;
      this.numericUpDown_16.Value = (Decimal) this.LaserUserOffset.Y;
      this.numericUpDown_15.Value = (Decimal) this.LaserUserOffset.Z;
      this.numericUpDown_14.Value = (Decimal) this.LatheUserOffset.X;
      this.numericUpDown_13.Value = (Decimal) this.LatheUserOffset.Y;
      this.numericUpDown_12.Value = (Decimal) this.LatheUserOffset.Z;
      this.Properties.Result = DialogResult.None;
      this.Properties.Inited = true;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.OK;
    Class39.smethod_755(this);
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
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
