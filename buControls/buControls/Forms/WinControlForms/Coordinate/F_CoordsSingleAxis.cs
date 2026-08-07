// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Coordinate.F_CoordsSingleAxis
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

public class F_CoordsSingleAxis : Form
{
  public static List<string> Captions = new List<string>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;
  public DialogResult Result = DialogResult.None;
  public double Value = 1.0;
  public bool Inited = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal ImageList imageList_0;
  public NumericUpDown spn_z;
  internal Button button_1;
  internal Button button_2;

  public F_CoordsSingleAxis() => Class39.smethod_48(this);

  public event OkCommandEventHandler OkExecuted;

  public event CancelCommandEventHandler CancelExecuted;

  public event ValueChangedWithDataEventHandler ValueChanged;

  public void Init()
  {
    this.Inited = false;
    this.spn_z.Value = (Decimal) this.Value;
    this.Inited = true;
    Class39.smethod_181(this);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (!this.Inited)
      return;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.cancelCommandEventHandler_0();
    }
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Value = (double) this.spn_z.Value;
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.valueChangedWithDataEventHandler_0(Math.Abs((double) this.spn_z.Value), (object) ValueChangesMode.Up);
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Value = (double) this.spn_z.Value;
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.valueChangedWithDataEventHandler_0(-1.0 * Math.Abs((double) this.spn_z.Value), (object) ValueChangesMode.Down);
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.Value = (double) this.spn_z.Value;
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.valueChangedWithDataEventHandler_0((double) this.spn_z.Value, (object) ValueChangesMode.Contant);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
