// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.CAM.CamItems.F_CamOperationAll
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamOperationAll : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Label label_0;
  internal Label label_1;
  internal Panel panel_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_0;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Panel panel_2;
  internal Label label_6;
  internal Label label_7;
  internal Label label_8;
  public RadioButton radio_right;
  public RadioButton radio_left;
  public RadioButton radioButton1;

  public F_CamOperationAll() => Class39.smethod_684(this);

  public F_CamOperationAll(bool ShowExplanation, int DecimalCount)
  {
    Class39.smethod_684(this);
    this.label_3.Visible = ShowExplanation;
    this.label_1.Visible = ShowExplanation;
    if (!(DecimalCount >= 0 & DecimalCount <= 5))
      return;
    this.numericUpDown_0.DecimalPlaces = DecimalCount;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
