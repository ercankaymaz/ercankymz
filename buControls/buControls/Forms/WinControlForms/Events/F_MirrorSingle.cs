// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Events.F_MirrorSingle
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

public class F_MirrorSingle : Form
{
  public FormProperties Properties = new FormProperties();
  public MirrorSingleEventVar Data = new MirrorSingleEventVar();
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal ImageList imageList_0;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  public Button btn_cancel;
  public Button btn_ok;
  internal RadioButton radioButton_2;
  internal CheckBox checkBox_0;
  internal Panel panel_0;

  public F_MirrorSingle() => Class39.smethod_37(this);

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;

  public void Init(MirrorSingleEventVar data)
  {
    this.Data = new MirrorSingleEventVar(data);
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
    this.checkBox_0.Checked = this.Data.MaterialCenter;
    this.numericUpDown_0.Value = (Decimal) this.Data.Offset;
    if (this.Data.Catch == MinCenterMaxType.Min)
    {
      this.radioButton_1.Checked = true;
      this.radioButton_0.Checked = false;
      this.radioButton_2.Checked = false;
    }
    else if (this.Data.Catch == MinCenterMaxType.Center)
    {
      this.radioButton_1.Checked = false;
      this.radioButton_0.Checked = true;
      this.radioButton_2.Checked = false;
    }
    else if (this.Data.Catch == MinCenterMaxType.Max)
    {
      this.radioButton_1.Checked = false;
      this.radioButton_0.Checked = false;
      this.radioButton_2.Checked = true;
    }
    if (this.checkBox_0.Checked)
      this.panel_0.Enabled = false;
    else
      this.panel_0.Enabled = true;
    this.Properties.Inited = true;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.Data);
    Class39.smethod_108(this);
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
    this.Data.Offset = (double) this.numericUpDown_0.Value;
    this.Data.Catch = !this.radioButton_1.Checked ? (!this.radioButton_0.Checked ? MinCenterMaxType.Max : MinCenterMaxType.Center) : MinCenterMaxType.Min;
    this.Data.MaterialCenter = this.checkBox_0.Checked;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (this.checkBox_0.Checked)
      this.panel_0.Enabled = false;
    else
      this.panel_0.Enabled = true;
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
