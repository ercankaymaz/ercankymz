// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.ClassForm.F_Size
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.ClassForm;

public class F_Size : Form
{
  public SizeF Value = new SizeF();
  public bool IntergerMode = false;
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  public Button btn_cancel;
  public Button btn_ok;

  public F_Size() => Class39.smethod_737(this);

  public void Init()
  {
    this.numericUpDown_1.Value = (Decimal) this.Value.Width;
    this.numericUpDown_0.Value = (Decimal) this.Value.Height;
    if (this.IntergerMode)
    {
      this.numericUpDown_1.DecimalPlaces = 0;
      this.numericUpDown_0.DecimalPlaces = 0;
    }
    else
    {
      this.numericUpDown_1.DecimalPlaces = 3;
      this.numericUpDown_0.DecimalPlaces = 3;
    }
    Class39.smethod_403(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value.Width = (float) this.numericUpDown_1.Value;
    this.Value.Height = (float) this.numericUpDown_0.Value;
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
