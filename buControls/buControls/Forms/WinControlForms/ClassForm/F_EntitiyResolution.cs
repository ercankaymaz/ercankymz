// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.ClassForm.F_EntitiyResolution
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.ClassForm;

public class F_EntitiyResolution : Form
{
  public EntityResolution Value = new EntityResolution();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  public Button btn_ok;
  internal ComboBox comboBox_0;
  internal Label label_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal Label label_4;
  internal NumericUpDown numericUpDown_3;

  public F_EntitiyResolution() => Class39.smethod_274(this);

  public void Init()
  {
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Value.ResolutionTypes, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Value.ResolutionTypes), ref this.comboBox_0);
    this.numericUpDown_1.Value = (Decimal) this.Value.GeometricCount;
    this.numericUpDown_3.Value = (Decimal) this.Value.dt;
    this.numericUpDown_0.Value = (Decimal) this.Value.GeometricLength;
    this.numericUpDown_2.Value = (Decimal) this.Value.LnRatio;
    this.comboBox_0.SelectedIndex = Convert.ToInt32((object) this.Value.ResolutionTypes);
    Class39.smethod_110(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value.ResolutionTypes = (EntityResolutionType) new EnumConverter(this.Value.ResolutionTypes.GetType()).ConvertFromString(this.comboBox_0.Text);
    this.Value.dt = (double) this.numericUpDown_3.Value;
    this.Value.GeometricCount = (int) this.numericUpDown_1.Value;
    this.Value.GeometricLength = (double) this.numericUpDown_0.Value;
    this.Value.LnRatio = (double) this.numericUpDown_2.Value;
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
