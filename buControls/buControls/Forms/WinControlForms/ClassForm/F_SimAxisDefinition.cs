// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.ClassForm.F_SimAxisDefinition
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

public class F_SimAxisDefinition : Form
{
  public SimulationMoveVar Value = new SimulationMoveVar();
  public DialogResult Result = DialogResult.None;
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal CheckBox checkBox_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal CheckBox checkBox_1;
  internal CheckBox checkBox_2;
  internal CheckBox checkBox_3;
  internal CheckBox checkBox_4;
  internal CheckBox checkBox_5;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  public Button btn_cancel;
  public Button btn_ok;

  public F_SimAxisDefinition() => Class39.smethod_253(this);

  public void Init()
  {
    this.numericUpDown_0.Value = (Decimal) this.Value.RotationPoint.X;
    this.numericUpDown_1.Value = (Decimal) this.Value.RotationPoint.Y;
    this.numericUpDown_2.Value = (Decimal) this.Value.RotationPoint.Z;
    this.checkBox_0.Checked = this.Value.Axes.X;
    this.checkBox_1.Checked = this.Value.Axes.Y;
    this.checkBox_2.Checked = this.Value.Axes.Z;
    this.checkBox_3.Checked = this.Value.Axes.A;
    this.checkBox_4.Checked = this.Value.Axes.B;
    this.checkBox_5.Checked = this.Value.Axes.C;
    Class39.smethod_511(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value.RotationPoint.X = (double) this.numericUpDown_0.Value;
    this.Value.RotationPoint.Y = (double) this.numericUpDown_1.Value;
    this.Value.RotationPoint.Z = (double) this.numericUpDown_2.Value;
    this.Value.Axes.X = this.checkBox_0.Checked;
    this.Value.Axes.Y = this.checkBox_1.Checked;
    this.Value.Axes.Z = this.checkBox_2.Checked;
    this.Value.Axes.A = this.checkBox_3.Checked;
    this.Value.Axes.B = this.checkBox_4.Checked;
    this.Value.Axes.C = this.checkBox_5.Checked;
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
