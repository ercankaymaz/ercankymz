// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_HalfBridgeItems
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_HalfBridgeItems : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public HalfBridgeItem HalfBridge = new HalfBridgeItem();
  public string strHalfBridge = "Half Bridge";
  public string strRemove = "Do You Want to Remove";
  public bool ShowAddRemove = true;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal CheckBox checkBox_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal CheckBox checkBox_1;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal Label label_4;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal NumericUpDown numericUpDown_3;
  internal Label label_5;
  internal Button button_2;
  internal Button button_3;

  public F_HalfBridgeItems() => Class39.smethod_92(this);

  public event ApplyCommandWithBoolEventHandler ApplyPressed;

  public void Init()
  {
    this.Result = DialogResult.Cancel;
    this.numericUpDown_2.Value = (Decimal) this.HalfBridge.LeftHeight;
    this.numericUpDown_3.Value = (Decimal) this.HalfBridge.LeftWidth;
    this.numericUpDown_0.Value = (Decimal) this.HalfBridge.RightHeight;
    this.numericUpDown_1.Value = (Decimal) this.HalfBridge.RightWidth;
    this.checkBox_1.Checked = this.HalfBridge.LeftEnable;
    this.checkBox_0.Checked = this.HalfBridge.RightEnable;
    Class39.smethod_51(this);
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
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Result = DialogResult.OK;
    this.HalfBridge.LeftHeight = (double) this.numericUpDown_2.Value;
    this.HalfBridge.LeftWidth = (double) this.numericUpDown_3.Value;
    this.HalfBridge.RightHeight = (double) this.numericUpDown_0.Value;
    this.HalfBridge.RightWidth = (double) this.numericUpDown_1.Value;
    this.HalfBridge.LeftEnable = this.checkBox_1.Checked;
    this.HalfBridge.RightEnable = this.checkBox_0.Checked;
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.applyCommandWithBoolEventHandler_0(false);
    }
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.HalfBridge.LeftHeight = (double) this.numericUpDown_2.Value;
    this.HalfBridge.LeftWidth = (double) this.numericUpDown_3.Value;
    this.HalfBridge.RightHeight = (double) this.numericUpDown_0.Value;
    this.HalfBridge.RightWidth = (double) this.numericUpDown_1.Value;
    this.HalfBridge.LeftEnable = this.checkBox_1.Checked;
    this.HalfBridge.RightEnable = this.checkBox_0.Checked;
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithBoolEventHandler_0(false);
  }

  internal void method_4(object sender, EventArgs e)
  {
    this.HalfBridge.LeftHeight = (double) this.numericUpDown_2.Value;
    this.HalfBridge.LeftWidth = (double) this.numericUpDown_3.Value;
    this.HalfBridge.RightHeight = (double) this.numericUpDown_0.Value;
    this.HalfBridge.RightWidth = (double) this.numericUpDown_1.Value;
    this.HalfBridge.LeftEnable = this.checkBox_1.Checked;
    this.HalfBridge.RightEnable = this.checkBox_0.Checked;
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithBoolEventHandler_0(true);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
