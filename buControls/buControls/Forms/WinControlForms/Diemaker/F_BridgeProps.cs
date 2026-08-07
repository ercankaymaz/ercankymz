// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_BridgeProps
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

public class F_BridgeProps : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public double BridgeHeight = 15.0;
  public Color colorActive = Color.DarkGray;
  public Color colorPassive = Color.WhiteSmoke;
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Button button_0;
  internal Label label_0;
  internal Button button_1;
  internal Button button_2;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;

  public F_BridgeProps() => Class39.smethod_623(this);

  public void Init()
  {
    this.Result = DialogResult.None;
    this.button_0.BackColor = this.colorPassive;
    this.button_2.BackColor = this.colorPassive;
    this.button_1.BackColor = this.colorPassive;
    if (this.BridgeHeight <= 12.0)
      this.button_0.BackColor = this.colorActive;
    if (this.BridgeHeight > 12.0 & this.BridgeHeight <= 15.0)
      this.button_2.BackColor = this.colorActive;
    if (this.BridgeHeight > 15.0)
      this.button_1.BackColor = this.colorActive;
    Class39.smethod_556(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Result = DialogResult.OK;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.button_0.BackColor = this.colorActive;
    this.button_2.BackColor = this.colorPassive;
    this.button_1.BackColor = this.colorPassive;
    this.BridgeHeight = 12.0;
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.button_0.BackColor = this.colorPassive;
    this.button_2.BackColor = this.colorActive;
    this.button_1.BackColor = this.colorPassive;
    this.BridgeHeight = 15.0;
  }

  internal void method_4(object sender, EventArgs e)
  {
    this.button_0.BackColor = this.colorPassive;
    this.button_2.BackColor = this.colorPassive;
    this.button_1.BackColor = this.colorActive;
    this.BridgeHeight = 18.0;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
