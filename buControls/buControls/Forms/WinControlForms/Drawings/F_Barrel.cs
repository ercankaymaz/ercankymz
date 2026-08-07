// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Drawings.F_Barrel
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
namespace buControls.Forms.WinControlForms.Drawings;

public class F_Barrel : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  public BarrelData Barrel = new BarrelData();
  public bool VisibleRotate = true;
  public bool VisibleCoordinate = true;
  internal IContainer icontainer_0 = (IContainer) null;
  internal NumericUpDown numericUpDown_0;
  internal ImageList imageList_0;
  internal Label label_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal PictureBox pictureBox_0;
  internal NumericUpDown numericUpDown_5;
  internal Label label_5;
  internal Button button_0;
  internal Button button_1;
  internal PictureBox pictureBox_1;

  public F_Barrel() => Class39.smethod_201(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    this.numericUpDown_3.Value = (Decimal) this.Barrel.Height;
    this.numericUpDown_4.Value = (Decimal) this.Barrel.Width;
    this.numericUpDown_0.Value = (Decimal) this.Barrel.HeadRadius;
    this.numericUpDown_2.Value = (Decimal) this.Barrel.HeadCenterPoint.X;
    this.numericUpDown_1.Value = (Decimal) this.Barrel.HeadCenterPoint.Y;
    this.numericUpDown_5.Value = (Decimal) this.Barrel.Rotation;
    this.PropertiesForm.Result = DialogResult.None;
    this.label_5.Visible = this.VisibleRotate;
    this.numericUpDown_5.Visible = this.VisibleRotate;
    this.pictureBox_0.Visible = this.VisibleRotate;
    this.label_2.Visible = this.VisibleCoordinate;
    this.label_1.Visible = this.VisibleCoordinate;
    this.numericUpDown_2.Visible = this.VisibleCoordinate;
    this.numericUpDown_1.Visible = this.VisibleCoordinate;
    this.PropertiesForm.Inited = true;
    Class39.smethod_31(this);
  }

  public void Init(ShapeData barrel)
  {
    this.PropertiesForm.Inited = false;
    if (barrel.GetType() == typeof (BarrelData))
      this.Barrel = new BarrelData((BarrelData) barrel);
    this.numericUpDown_3.Value = (Decimal) this.Barrel.Height;
    this.numericUpDown_4.Value = (Decimal) this.Barrel.Width;
    this.numericUpDown_0.Value = (Decimal) this.Barrel.HeadRadius;
    this.numericUpDown_2.Value = (Decimal) this.Barrel.HeadCenterPoint.X;
    this.numericUpDown_1.Value = (Decimal) this.Barrel.HeadCenterPoint.Y;
    this.numericUpDown_5.Value = (Decimal) this.Barrel.Rotation;
    this.PropertiesForm.Result = DialogResult.None;
    this.label_5.Visible = this.VisibleRotate;
    this.numericUpDown_5.Visible = this.VisibleRotate;
    this.pictureBox_0.Visible = this.VisibleRotate;
    this.PropertiesForm.Inited = true;
  }

  public void Apply()
  {
    this.Barrel.Height = (double) this.numericUpDown_3.Value;
    this.Barrel.Width = (double) this.numericUpDown_4.Value;
    this.Barrel.Rotation = (double) this.numericUpDown_5.Value;
    this.Barrel.HeadRadius = (double) this.numericUpDown_0.Value;
    this.Barrel.HeadCenterPoint = new Pnt3D((double) this.numericUpDown_2.Value, (double) this.numericUpDown_1.Value, 0.0);
  }

  internal void method_0(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.Controls, result, e.Shift);
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (sender.GetType() == typeof (TextBox))
      {
        TextBox textBox = new TextBox();
        buControlCommands.ShowKeyPad((Form) this, (Control) sender);
      }
      if (!(sender.GetType() == typeof (NumericUpDown)))
        return;
      NumericUpDown numericUpDown = new NumericUpDown();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Apply();
    this.PropertiesForm.Result = DialogResult.OK;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_4(object sender, FormClosingEventArgs e)
  {
    if (!this.PropertiesForm.Inited || this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
