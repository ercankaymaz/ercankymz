// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Machine.F_MachineTypeAdd
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
namespace buControls.Forms.WinControlForms.Machine;

public class F_MachineTypeAdd : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public MachineType Machine = new MachineType();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal Label label_1;
  internal TextBox textBox_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;

  public F_MachineTypeAdd() => Class39.smethod_606(this);

  public void Init()
  {
    this.Result = DialogResult.Cancel;
    this.numericUpDown_0.Value = (Decimal) this.Machine.ID;
    this.numericUpDown_1.Value = (Decimal) this.Machine.ToolCount;
    this.textBox_0.Text = this.Machine.Name;
    Class39.smethod_178(this);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.OK;
    this.Machine.ID = Convert.ToInt32(this.numericUpDown_0.Value);
    this.Machine.ToolCount = Convert.ToInt32(this.numericUpDown_1.Value);
    this.Machine.Name = this.textBox_0.Text;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
