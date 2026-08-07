// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_RuleSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_RuleSettings : Form
{
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public double RuleHeight = 15.0;
  public Color colorActive = Color.DarkGray;
  public Color colorPassive = Color.WhiteSmoke;
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;

  public F_RuleSettings() => Class39.smethod_454(this);

  public void Init()
  {
    this.Result = DialogResult.None;
    this.numericUpDown_0.Value = (Decimal) this.RuleHeight;
    Class39.smethod_694(this);
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
    this.RuleHeight = (double) this.numericUpDown_0.Value;
    this.Result = DialogResult.OK;
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
