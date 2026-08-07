// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Machine.F_MachineSelect
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

public class F_MachineSelect : Form
{
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public List<MachineType> Machines = new List<MachineType>();
  public int SelectedMachineIndex = 0;
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal ListBox listBox_0;

  public F_MachineSelect() => Class39.smethod_411(this);

  public void Init()
  {
    this.Result = DialogResult.Cancel;
    this.listBox_0.Items.Clear();
    for (int index = 0; index <= this.Machines.Count - 1; ++index)
      this.listBox_0.Items.Add((object) $"{this.Machines[index].Name} - ID: {this.Machines[index].ID.ToString()}");
    if (this.SelectedMachineIndex >= 0 & this.SelectedMachineIndex <= this.Machines.Count - 1)
      this.listBox_0.SelectedIndex = this.SelectedMachineIndex;
    Class39.smethod_449(this);
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
    this.SelectedMachineIndex = this.listBox_0.SelectedIndex;
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
