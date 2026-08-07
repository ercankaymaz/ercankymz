// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Events.F_LinearArray
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

public class F_LinearArray : Form
{
  public FormProperties Properties = new FormProperties();
  public LineerArrayEventVar Data = new LineerArrayEventVar();
  public bool ShowOffsetValues = false;
  public bool ShowZValues = false;
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal Label label_2;
  internal Panel panel_0;
  internal Panel panel_1;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal Label label_4;
  internal NumericUpDown numericUpDown_3;
  internal Label label_5;
  internal Panel panel_2;
  internal Label label_6;
  internal NumericUpDown numericUpDown_4;
  internal Label label_7;
  internal NumericUpDown numericUpDown_5;
  internal Label label_8;
  public NumericUpDown spn_xoffset;
  public Label lbl_xoffset;
  public Label lbl_yoffset;
  public NumericUpDown spn_yoffset;
  public Label lbl_zoffset;
  public NumericUpDown spn_zoffset;

  public F_LinearArray() => Class39.smethod_35(this);

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;

  public void Init(LineerArrayEventVar data)
  {
    this.Data = new LineerArrayEventVar(data);
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
    this.numericUpDown_0.Value = (Decimal) this.Data.ColomnsDistanceX;
    this.numericUpDown_1.Value = (Decimal) this.Data.ColomnsCountX;
    this.numericUpDown_2.Value = (Decimal) this.Data.RowDistanceY;
    this.numericUpDown_3.Value = (Decimal) this.Data.RowsCountY;
    this.numericUpDown_4.Value = (Decimal) this.Data.LevelDistanceZ;
    this.numericUpDown_5.Value = (Decimal) this.Data.LevelCountZ;
    this.spn_zoffset.Value = 0M;
    this.spn_xoffset.Visible = this.ShowOffsetValues;
    this.spn_yoffset.Visible = this.ShowOffsetValues;
    this.spn_zoffset.Visible = this.ShowOffsetValues;
    this.lbl_xoffset.Visible = this.ShowOffsetValues;
    this.lbl_yoffset.Visible = this.ShowOffsetValues;
    this.lbl_zoffset.Visible = this.ShowOffsetValues;
    if (!this.ShowOffsetValues)
      this.Width -= 120;
    this.panel_2.Visible = this.ShowZValues;
    if (!this.ShowZValues)
      this.Height -= 80 /*0x50*/;
    this.Properties.Inited = true;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.Data);
    Class39.smethod_341(this);
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
    this.Data.ColomnsDistanceX = (double) this.numericUpDown_0.Value;
    this.Data.ColomnsCountX = (int) this.numericUpDown_1.Value;
    this.Data.RowDistanceY = (double) this.numericUpDown_2.Value;
    this.Data.RowsCountY = (int) this.numericUpDown_3.Value;
    this.Data.LevelDistanceZ = (double) this.numericUpDown_4.Value;
    this.Data.LevelCountZ = (int) this.numericUpDown_5.Value;
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
