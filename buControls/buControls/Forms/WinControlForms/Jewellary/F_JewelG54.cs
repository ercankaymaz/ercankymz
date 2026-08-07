// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_JewelG54
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
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelG54 : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public Pnt9D[] G54List = new Pnt9D[10];
  private int int_0 = 0;
  private IContainer icontainer_0 = (IContainer) null;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  internal Label label_8;
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
  internal Button button_0;
  internal Button button_1;
  public Button btn_xassing;
  public Button btn_yassingn;
  public Button btn_zassign;

  public event OkCommandEventHandler OkPressed;

  public event OkCommandWithValueEventHandler SelectHead;

  public F_JewelG54() => Class39.smethod_150(this);

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
    this.numericUpDown_0.Value = (Decimal) this.G54List[0].X;
    this.numericUpDown_1.Value = (Decimal) this.G54List[0].Y;
    this.numericUpDown_2.Value = (Decimal) this.G54List[0].Z;
    this.numericUpDown_5.Value = (Decimal) this.G54List[1].X;
    this.numericUpDown_4.Value = (Decimal) this.G54List[1].Y;
    this.numericUpDown_3.Value = (Decimal) this.G54List[1].Z;
    this.numericUpDown_11.Value = (Decimal) this.G54List[2].X;
    this.numericUpDown_10.Value = (Decimal) this.G54List[2].Y;
    this.numericUpDown_9.Value = (Decimal) this.G54List[2].Z;
    this.numericUpDown_8.Value = (Decimal) this.G54List[3].X;
    this.numericUpDown_7.Value = (Decimal) this.G54List[3].Y;
    this.numericUpDown_6.Value = (Decimal) this.G54List[3].Z;
    this.numericUpDown_17.Value = (Decimal) this.G54List[4].X;
    this.numericUpDown_16.Value = (Decimal) this.G54List[4].Y;
    this.numericUpDown_15.Value = (Decimal) this.G54List[4].Z;
    this.numericUpDown_14.Value = (Decimal) this.G54List[5].X;
    this.numericUpDown_13.Value = (Decimal) this.G54List[5].Y;
    this.numericUpDown_12.Value = (Decimal) this.G54List[5].Z;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  public void Assign(string Axis, Pnt9D Position)
  {
    if (Axis == "X")
    {
      if (this.int_0 == 1)
        this.numericUpDown_0.Value = (Decimal) Position.X;
      if (this.int_0 == 2)
        this.numericUpDown_5.Value = (Decimal) Position.X;
      if (this.int_0 == 3)
        this.numericUpDown_11.Value = (Decimal) Position.X;
      if (this.int_0 == 4)
        this.numericUpDown_8.Value = (Decimal) Position.X;
      if (this.int_0 == 5)
        this.numericUpDown_17.Value = (Decimal) Position.X;
      if (this.int_0 == 6)
        this.numericUpDown_14.Value = (Decimal) Position.X;
    }
    if (Axis == "Y")
    {
      if (this.int_0 == 11)
        this.numericUpDown_1.Value = (Decimal) Position.Y;
      if (this.int_0 == 12)
        this.numericUpDown_4.Value = (Decimal) Position.Y;
      if (this.int_0 == 13)
        this.numericUpDown_10.Value = (Decimal) Position.Y;
      if (this.int_0 == 14)
        this.numericUpDown_7.Value = (Decimal) Position.Y;
      if (this.int_0 == 15)
        this.numericUpDown_16.Value = (Decimal) Position.Y;
      if (this.int_0 == 16 /*0x10*/)
        this.numericUpDown_13.Value = (Decimal) Position.Y;
    }
    if (!(Axis == "Z"))
      return;
    if (this.int_0 == 21)
      this.numericUpDown_2.Value = (Decimal) Position.Z;
    if (this.int_0 == 22)
      this.numericUpDown_3.Value = (Decimal) Position.W;
    if (this.int_0 == 23)
      this.numericUpDown_9.Value = (Decimal) Position.Z;
    if (this.int_0 == 24)
      this.numericUpDown_6.Value = (Decimal) Position.Z;
    if (this.int_0 == 25)
      this.numericUpDown_15.Value = (Decimal) Position.W;
    if (this.int_0 != 26)
      return;
    this.numericUpDown_12.Value = (Decimal) Position.W;
  }

  public void Assign(string Axis, Pnt12D Position)
  {
    if (Axis == "X")
    {
      if (this.int_0 == 1)
        this.numericUpDown_0.Value = (Decimal) Position.X;
      if (this.int_0 == 2)
        this.numericUpDown_5.Value = (Decimal) Position.X;
      if (this.int_0 == 3)
        this.numericUpDown_11.Value = (Decimal) Position.X;
      if (this.int_0 == 4)
        this.numericUpDown_8.Value = (Decimal) Position.X;
      if (this.int_0 == 5)
        this.numericUpDown_17.Value = (Decimal) Position.X;
      if (this.int_0 == 6)
        this.numericUpDown_14.Value = (Decimal) Position.X;
    }
    if (Axis == "Y")
    {
      if (this.int_0 == 11)
        this.numericUpDown_1.Value = (Decimal) Position.Y;
      if (this.int_0 == 12)
        this.numericUpDown_4.Value = (Decimal) Position.Y;
      if (this.int_0 == 13)
        this.numericUpDown_10.Value = (Decimal) Position.Y;
      if (this.int_0 == 14)
        this.numericUpDown_7.Value = (Decimal) Position.Y;
      if (this.int_0 == 15)
        this.numericUpDown_16.Value = (Decimal) Position.Y;
      if (this.int_0 == 16 /*0x10*/)
        this.numericUpDown_13.Value = (Decimal) Position.Y;
    }
    if (!(Axis == "Z"))
      return;
    if (this.int_0 == 21)
      this.numericUpDown_2.Value = (Decimal) Position.Z;
    if (this.int_0 == 22)
      this.numericUpDown_3.Value = (Decimal) Position.W;
    if (this.int_0 == 23)
      this.numericUpDown_9.Value = (Decimal) Position.Z;
    if (this.int_0 == 24)
      this.numericUpDown_6.Value = (Decimal) Position.Z;
    if (this.int_0 == 25)
      this.numericUpDown_15.Value = (Decimal) Position.W;
    if (this.int_0 != 26)
      return;
    this.numericUpDown_12.Value = (Decimal) Position.W;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.OK;
    Class39.smethod_687(this);
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandEventHandler_0();
    }
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

  internal void method_3(object sender, EventArgs e)
  {
    NumericUpDown numericUpDown = new NumericUpDown();
    this.int_0 = Convert.ToInt32(((Control) sender).Tag);
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.label_3.Name && this.okCommandWithValueEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithValueEventHandler_0(1.0);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.label_4.Name && this.okCommandWithValueEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithValueEventHandler_0(2.0);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.label_5.Name && this.okCommandWithValueEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithValueEventHandler_0(3.0);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.label_6.Name && this.okCommandWithValueEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithValueEventHandler_0(4.0);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.label_7.Name && this.okCommandWithValueEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithValueEventHandler_0(5.0);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.label_8.Name) || this.okCommandWithValueEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithValueEventHandler_0(6.0);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
