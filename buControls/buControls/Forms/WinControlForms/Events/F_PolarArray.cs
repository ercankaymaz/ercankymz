// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Events.F_PolarArray
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
namespace buControls.Forms.WinControlForms.Events;

public class F_PolarArray : Form
{
  public FormProperties Properties = new FormProperties();
  public PolarArrayEventVar Data = new PolarArrayEventVar();
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal Label label_3;
  internal NumericUpDown numericUpDown_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal Label label_5;
  internal Label label_6;
  internal CheckBox checkBox_0;

  public F_PolarArray() => Class39.smethod_160(this);

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;

  public void Init(PolarArrayEventVar data)
  {
    this.Data = new PolarArrayEventVar(data);
    this.Init();
  }

  public void Init()
  {
    this.Properties.Inited = false;
    this.Properties.Result = DialogResult.None;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.numericUpDown_0.Value = (Decimal) this.Data.ItemAngle;
    this.numericUpDown_1.Value = (Decimal) this.Data.ItemCount;
    if (this.Data.Direction == ClockDirectionType.CW)
    {
      this.radioButton_1.Checked = true;
      this.radioButton_0.Checked = false;
    }
    if (this.Data.Direction == ClockDirectionType.CCW)
    {
      this.radioButton_1.Checked = false;
      this.radioButton_0.Checked = true;
    }
    this.Properties.Inited = true;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.Data);
    Class39.smethod_693(this);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithDataEventHandler_0((object) this.Data);
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  public void Apply()
  {
    if (!this.Properties.Inited)
      return;
    this.Data.ItemAngle = (double) this.numericUpDown_0.Value;
    this.Data.ItemCount = (int) this.numericUpDown_1.Value;
    if (this.radioButton_0.Checked)
      this.Data.Direction = ClockDirectionType.CCW;
    else
      this.Data.Direction = ClockDirectionType.CW;
  }

  internal void method_3(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!this.Properties.Inited || this.applyCommandWithDataEventHandler_0 == null)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.Data);
  }

  internal void method_4(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!this.Properties.Inited || this.applyCommandWithDataEventHandler_0 == null)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.Data);
  }

  internal void method_5(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!this.Properties.Inited || this.applyCommandWithDataEventHandler_0 == null)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.Data);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
