// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.CAM.CamItems.F_CamDistanceAll
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamDistanceAll : Form
{
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal CheckBox checkBox_0;
  internal Label label_0;
  internal Label label_1;
  internal Panel panel_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_0;
  internal Label label_3;
  internal Panel panel_2;
  internal Label label_4;
  internal NumericUpDown numericUpDown_1;
  internal Label label_5;
  internal Panel panel_3;
  internal Label label_6;
  internal NumericUpDown numericUpDown_2;
  internal Label label_7;
  internal Label label_8;
  internal ImageList imageList_0;
  internal Label label_9;
  internal Label label_10;
  internal Label label_11;
  internal Panel panel_4;
  internal Label label_12;
  internal Label label_13;
  internal NumericUpDown numericUpDown_3;
  internal Label label_14;

  public F_CamDistanceAll() => Class39.smethod_453(this);

  public F_CamDistanceAll(bool ShowExplanation, int DecimalCount)
  {
    Class39.smethod_453(this);
    this.label_5.Visible = ShowExplanation;
    this.label_7.Visible = ShowExplanation;
    this.label_1.Visible = ShowExplanation;
    this.label_3.Visible = ShowExplanation;
    if (!(DecimalCount >= 0 & DecimalCount <= 5))
      return;
    this.numericUpDown_1.DecimalPlaces = DecimalCount;
    this.numericUpDown_2.DecimalPlaces = DecimalCount;
    this.numericUpDown_0.DecimalPlaces = DecimalCount;
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
