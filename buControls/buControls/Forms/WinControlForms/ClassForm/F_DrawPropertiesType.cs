// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.ClassForm.F_DrawPropertiesType
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

public class F_DrawPropertiesType : Form
{
  public drawPropertiesType Value = new drawPropertiesType();
  public List<drawingPattern> Patterns = new List<drawingPattern>();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  public Button btn_ok;
  internal buColorComboBox buColorComboBox_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal Label label_1;
  internal ComboBox comboBox_0;

  public F_DrawPropertiesType() => Class39.smethod_570(this);

  public void Init()
  {
    this.buColorComboBox_0.Color = this.Value.Color;
    this.numericUpDown_0.Value = (Decimal) this.Value.Thickness;
    this.comboBox_0.Items.Clear();
    for (int index = 0; index <= this.Patterns.Count - 1; ++index)
      this.comboBox_0.Items.Add((object) this.Patterns[index].Name);
    Class39.smethod_156(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (this.numericUpDown_0.Value > 0M)
      this.Value.Thickness = (float) this.numericUpDown_0.Value;
    this.Value.Color = this.buColorComboBox_0.Color;
    for (int index = 0; index <= this.Patterns.Count - 1; ++index)
    {
      if (this.Patterns[index].Name == this.comboBox_0.Text)
        this.Value.Pattern = new drawingPattern(this.Patterns[index]);
    }
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
