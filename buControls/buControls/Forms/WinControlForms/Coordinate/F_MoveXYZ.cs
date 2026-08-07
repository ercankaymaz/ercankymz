// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Coordinate.F_MoveXYZ
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
namespace buControls.Forms.WinControlForms.Coordinate;

public class F_MoveXYZ : Form
{
  public Pnt3D Point = new Pnt3D();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;
  public DialogResult Result = DialogResult.None;
  public double Increament = 0.1;
  public static List<string> Captions = new List<string>();
  private bool bool_0 = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal ImageList imageList_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  public NumericUpDown spn_x;
  public NumericUpDown spn_y;
  public NumericUpDown spn_z;
  internal ImageList imageList_1;
  public Button btn_cancel;
  public Button btn_ok;

  public F_MoveXYZ() => Class39.smethod_642(this);

  internal void method_0(object sender, EventArgs e)
  {
  }

  public event ValueChangedEventHandler XValueChanged;

  public event ValueChangedEventHandler YValueChanged;

  public event ValueChangedEventHandler ZValueChanged;

  public event Pnt3DValueChangedEventHandler PointValueChanged;

  public event OkCommandEventHandler OkPressed;

  public void Init(Pnt3D Pnt)
  {
    this.bool_0 = false;
    this.Point = new Pnt3D(Pnt);
    this.spn_x.Value = (Decimal) this.Point.X;
    this.spn_y.Value = (Decimal) this.Point.Y;
    this.spn_z.Value = (Decimal) this.Point.Z;
    this.bool_0 = true;
    Class39.smethod_431(this);
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
    if (!this.bool_0)
      return;
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.valueChangedEventHandler_0((double) this.spn_x.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.pnt3DValueChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.pnt3DValueChangedEventHandler_0(new Pnt3DValueChangedEventArg()
    {
      Enable = new AxesEnableXYZ(true, false, false),
      X = (double) this.spn_x.Value,
      Point = new Pnt3D((double) this.spn_x.Value, (double) this.spn_y.Value, (double) this.spn_z.Value)
    });
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!this.bool_0)
      return;
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.valueChangedEventHandler_1((double) this.spn_y.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.pnt3DValueChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.pnt3DValueChangedEventHandler_0(new Pnt3DValueChangedEventArg()
    {
      Enable = new AxesEnableXYZ(false, true, false),
      Y = (double) this.spn_y.Value,
      Point = new Pnt3D((double) this.spn_x.Value, (double) this.spn_y.Value, (double) this.spn_z.Value)
    });
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!this.bool_0)
      return;
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedEventHandler_2 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.valueChangedEventHandler_2((double) this.spn_z.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.pnt3DValueChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.pnt3DValueChangedEventHandler_0(new Pnt3DValueChangedEventArg()
    {
      Enable = new AxesEnableXYZ(false, false, true),
      Z = (double) this.spn_z.Value,
      Point = new Pnt3D((double) this.spn_x.Value, (double) this.spn_y.Value, (double) this.spn_z.Value)
    });
  }

  internal void method_5(object sender, EventArgs e)
  {
    this.spn_x.Value -= (Decimal) this.Increament;
  }

  internal void method_6(object sender, EventArgs e)
  {
    this.spn_y.Value -= (Decimal) this.Increament;
  }

  internal void method_7(object sender, EventArgs e)
  {
    this.spn_z.Value -= (Decimal) this.Increament;
  }

  internal void method_8(object sender, EventArgs e)
  {
    this.spn_x.Value += (Decimal) this.Increament;
  }

  internal void method_9(object sender, EventArgs e)
  {
    this.spn_y.Value += (Decimal) this.Increament;
  }

  internal void method_10(object sender, EventArgs e)
  {
    this.spn_z.Value += (Decimal) this.Increament;
  }

  internal void method_11(object sender, EventArgs e)
  {
    this.Result = DialogResult.OK;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandEventHandler_0();
    }
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_12(object sender, EventArgs e)
  {
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
