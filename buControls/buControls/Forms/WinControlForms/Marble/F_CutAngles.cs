// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Marble.F_CutAngles
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Marble;

public class F_CutAngles : Form
{
  public DialogResult Result = DialogResult.None;
  public double Value = 0.0;
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  public Button btn_0;
  public Button btn_3;
  public Button btn_5;
  public Button btn_47;
  public Button btn_46;
  public Button btn_45;
  public Button btn_40;
  public Button btn_30;
  public Button btn_15;

  public F_CutAngles() => Class39.smethod_203(this);

  public void Init(double value)
  {
    this.Value = value;
    this.numericUpDown_0.Value = (Decimal) this.Value;
    Class39.smethod_3(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value = (double) this.numericUpDown_0.Value;
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_0.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_0.Text);
    if (control2.Name == this.btn_3.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_3.Text);
    if (control2.Name == this.btn_5.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_5.Text);
    if (control2.Name == this.btn_15.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_15.Text);
    if (control2.Name == this.btn_30.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_30.Text);
    if (control2.Name == this.btn_40.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_40.Text);
    if (control2.Name == this.btn_45.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_45.Text);
    if (control2.Name == this.btn_46.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_46.Text);
    if (control2.Name == this.btn_47.Name)
      this.numericUpDown_0.Value = Decimal.Parse(this.btn_47.Text);
    this.method_0((object) this.btn_ok, e);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
