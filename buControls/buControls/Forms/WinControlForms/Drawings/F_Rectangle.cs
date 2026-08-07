// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Drawings.F_Rectangle
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

public class F_Rectangle : Form
{
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public RectangleCornerData Rect = new RectangleCornerData();
  public bool VisibleRotate = true;
  public static List<string> Captions = new List<string>();
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal PictureBox pictureBox_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal ImageList imageList_0;
  internal Button button_0;
  internal Button button_1;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal PictureBox pictureBox_1;

  public F_Rectangle() => Class39.smethod_67(this);

  public void Init()
  {
    this.bool_0 = false;
    this.numericUpDown_1.Value = (Decimal) this.Rect.Height;
    this.numericUpDown_0.Value = (Decimal) this.Rect.Width;
    this.numericUpDown_2.Value = (Decimal) this.Rect.CornerPoint.X;
    this.numericUpDown_3.Value = (Decimal) this.Rect.CornerPoint.Y;
    this.numericUpDown_4.Value = (Decimal) this.Rect.Rotation;
    this.Result = DialogResult.None;
    this.label_4.Visible = this.VisibleRotate;
    this.numericUpDown_4.Visible = this.VisibleRotate;
    this.pictureBox_1.Visible = this.VisibleRotate;
    this.bool_0 = true;
    Class39.smethod_212(this);
  }

  public void Init(ShapeData rect)
  {
    this.bool_0 = false;
    if (rect.GetType() == typeof (RectangleCornerData))
      this.Rect = new RectangleCornerData((RectangleCornerData) rect);
    this.numericUpDown_1.Value = (Decimal) this.Rect.Height;
    this.numericUpDown_0.Value = (Decimal) this.Rect.Width;
    this.numericUpDown_2.Value = (Decimal) this.Rect.CornerPoint.X;
    this.numericUpDown_4.Value = (Decimal) this.Rect.Rotation;
    this.numericUpDown_3.Value = (Decimal) this.Rect.CornerPoint.Y;
    this.Result = DialogResult.None;
    this.label_4.Visible = this.VisibleRotate;
    this.numericUpDown_4.Visible = this.VisibleRotate;
    this.pictureBox_1.Visible = this.VisibleRotate;
    this.bool_0 = true;
  }

  public void Apply()
  {
    this.Rect.Height = (double) this.numericUpDown_1.Value;
    this.Rect.Width = (double) this.numericUpDown_0.Value;
    this.Rect.Rotation = (double) this.numericUpDown_4.Value;
    this.Rect.CornerPoint = new Pnt3D((double) this.numericUpDown_2.Value, (double) this.numericUpDown_3.Value, 0.0);
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

  internal void method_4(object sender, FormClosingEventArgs e)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
