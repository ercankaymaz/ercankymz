// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.ClassForm.F_Pnt3D
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
namespace buControls.Forms.WinControlForms.ClassForm;

public class F_Pnt3D : Form
{
  public Pnt3D Value = new Pnt3D();
  public bool Mode2D = false;
  public bool IntergerMode = false;
  public DialogResult Result = DialogResult.None;
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;

  public F_Pnt3D() => Class39.smethod_719(this);

  public void Init()
  {
    this.Result = DialogResult.None;
    this.numericUpDown_0.Value = (Decimal) this.Value.X;
    this.numericUpDown_1.Value = (Decimal) this.Value.Y;
    this.numericUpDown_2.Value = (Decimal) this.Value.Z;
    if (this.Mode2D)
    {
      this.numericUpDown_2.Visible = false;
      this.label_2.Visible = false;
    }
    else
    {
      this.numericUpDown_2.Visible = true;
      this.label_2.Visible = true;
    }
    if (this.IntergerMode)
    {
      this.numericUpDown_0.DecimalPlaces = 0;
      this.numericUpDown_1.DecimalPlaces = 0;
      this.numericUpDown_2.DecimalPlaces = 0;
    }
    else
    {
      this.numericUpDown_0.DecimalPlaces = 3;
      this.numericUpDown_1.DecimalPlaces = 3;
      this.numericUpDown_2.DecimalPlaces = 3;
    }
    Class39.smethod_456(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value.X = (double) this.numericUpDown_0.Value;
    this.Value.Y = (double) this.numericUpDown_1.Value;
    this.Value.Z = (double) this.numericUpDown_2.Value;
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e) => this.Dispose();

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
