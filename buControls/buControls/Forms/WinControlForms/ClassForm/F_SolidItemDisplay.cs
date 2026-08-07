// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.ClassForm.F_SolidItemDisplay
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.ColorPicker;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.ClassForm;

public class F_SolidItemDisplay : Form
{
  public static List<string> Captions = new List<string>();
  public SolidItemDisplay Value = new SolidItemDisplay();
  public DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal buColorComboBox buColorComboBox_0;
  internal Label label_3;
  internal buColorComboBox buColorComboBox_1;
  public Button btn_cancel;
  public Button btn_ok;

  public F_SolidItemDisplay() => Class39.smethod_353(this);

  public void Init()
  {
    this.buColorComboBox_1.Color = this.Value.BorderColor;
    this.buColorComboBox_0.Color = this.Value.SkinColor;
    this.numericUpDown_1.Value = (Decimal) this.Value.SkinTransperancy;
    this.numericUpDown_0.Value = (Decimal) this.Value.BorderTransperancy;
    Class39.smethod_610(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value.SkinColor = this.buColorComboBox_0.Color;
    this.Value.BorderColor = this.buColorComboBox_1.Color;
    this.Value.SkinTransperancy = (int) this.numericUpDown_1.Value;
    this.Value.BorderTransperancy = (int) this.numericUpDown_1.Value;
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
