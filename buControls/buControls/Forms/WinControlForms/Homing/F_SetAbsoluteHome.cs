// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Homing.F_SetAbsoluteHome
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
namespace buControls.Forms.WinControlForms.Homing;

public class F_SetAbsoluteHome : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public int SelectedAxis = 0;
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  public NumericUpDown spn_sethome;
  internal Button button_0;
  internal Button button_1;
  public ListBox lst_axis;

  public event AbsoluteHomeSetEventHandle SetAbsoluteHome;

  public F_SetAbsoluteHome() => Class39.smethod_73(this);

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

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_1(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.absoluteHomeSetEventHandle_0 == null)
      return;
    this.SelectedAxis = this.lst_axis.SelectedIndex;
    // ISSUE: reference to a compiler-generated field
    this.absoluteHomeSetEventHandle_0(this.SelectedAxis, (double) this.spn_sethome.Value);
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
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
