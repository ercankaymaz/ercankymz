// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Drawings.F_Line
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

public class F_Line : Form
{
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public LineData Line = new LineData();
  public static List<string> Captions = new List<string>();
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal PictureBox pictureBox_0;
  internal ImageList imageList_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal Button button_0;
  internal Button button_1;

  public F_Line() => Class39.smethod_731(this);

  public void Init()
  {
    this.bool_0 = false;
    this.numericUpDown_2.Value = (Decimal) this.Line.Length;
    this.numericUpDown_3.Value = (Decimal) this.Line.Angle;
    this.numericUpDown_1.Value = (Decimal) this.Line.StartPoint.X;
    this.numericUpDown_0.Value = (Decimal) this.Line.StartPoint.Y;
    this.Result = DialogResult.None;
    this.bool_0 = true;
    Class39.smethod_223(this);
  }

  public void Init(ShapeData line)
  {
    this.bool_0 = false;
    if (line.GetType() == typeof (LineData))
      this.Line = new LineData((LineData) line);
    this.numericUpDown_2.Value = (Decimal) this.Line.Length;
    this.numericUpDown_3.Value = (Decimal) this.Line.Angle;
    this.numericUpDown_1.Value = (Decimal) this.Line.StartPoint.X;
    this.numericUpDown_0.Value = (Decimal) this.Line.StartPoint.Y;
    this.Result = DialogResult.None;
    this.bool_0 = true;
  }

  public void Apply()
  {
    this.Line.Length = (double) this.numericUpDown_2.Value;
    this.Line.Angle = (double) this.numericUpDown_3.Value;
    this.Line.StartPoint = new Pnt3D((double) this.numericUpDown_1.Value, (double) this.numericUpDown_0.Value, 0.0);
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
