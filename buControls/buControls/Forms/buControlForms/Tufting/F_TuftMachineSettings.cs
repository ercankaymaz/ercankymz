// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Tufting.F_TuftMachineSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Tufting;

public class F_TuftMachineSettings : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer icontainer_0 = (IContainer) null;
  public buGround buGround1;
  public buButton btn_closecross;
  public buButton btn_close;
  public buButton buButton10;
  public buButton btn_ok;
  public buButton btn_xabsoluteset;
  public buButton btn_yabsoluteset;
  public buSpin spn_HService;
  public buSpin spn_HUp;
  public buSpin spn_HDown;
  public buSpin spn_homeROffset;
  public buSpin spn_homeTOffset;
  public buLabel lbl_hHome;
  public buLabel lbl_rhome;
  public buLabel lbl_thome;
  public buGroup grp_xhome;
  public buGroup grp_hhome;
  public buGroup grp_rhome;
  public buGroup grp_thome;
  public buGroup grp_yhome;

  public F_TuftMachineSettings() => Class39.smethod_176(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    Class39.smethod_413(this);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.PropertiesForm.Result = DialogResult.OK;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    buSpin buSpin = sender as buSpin;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buNumeric.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
