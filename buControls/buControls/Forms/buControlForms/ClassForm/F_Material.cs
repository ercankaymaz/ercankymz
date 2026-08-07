// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.ClassForm.F_Material
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.ColorPicker;
using buControls.Controls;
using buCore;
using ns7;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.ClassForm;

public class F_Material : Form
{
  public MaterialBase varMaterial = new MaterialBase();
  public DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buTextBox buTextBox_0;
  internal buSpin buSpin_0;
  internal buLabel buLabel_0;
  internal buComboBox buComboBox_0;
  internal buSpin buSpin_1;
  internal buSpin buSpin_2;
  internal buSpin buSpin_3;
  internal buSpin buSpin_4;
  internal buColorComboBox buColorComboBox_0;
  internal buButton buButton_2;
  internal buButton buButton_3;

  public F_Material() => Class39.smethod_729(this);

  public void Init()
  {
    this.buSpin_3.Value = this.varMaterial.Size.Depth;
    this.buSpin_0.Value = this.varMaterial.Size.Depth;
    this.buSpin_4.Value = this.varMaterial.Size.Depth;
    this.buSpin_2.Value = this.varMaterial.Size.Depth;
    this.buSpin_1.Value = this.varMaterial.Size.Depth;
    this.buColorComboBox_0.Color = this.varMaterial.Display.SkinColor;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.varMaterial.Shapes, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.varMaterial.Shapes), ref this.buComboBox_0);
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!(((Control) sender).Name == this.buButton_2.Name))
      return;
    Class39.smethod_502(this);
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.buButton_1.Name | control2.Name == this.buButton_3.Name)
    {
      this.Result = DialogResult.Cancel;
      this.Dispose();
    }
    if (!(control2.Name == this.buButton_0.Name))
      return;
    this.WindowState = FormWindowState.Minimized;
  }

  internal void method_2(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.buGround_0.Controls, result, e.Shift);
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control = new Control();
    Control Ctrl = (Control) sender;
    if (!(sender.GetType() == typeof (buSpin) | sender.GetType() == typeof (buTextBox)) || !AppBool.TouchPad)
      return;
    buControlCommands.ShowKeyPad((Form) this, Ctrl);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
