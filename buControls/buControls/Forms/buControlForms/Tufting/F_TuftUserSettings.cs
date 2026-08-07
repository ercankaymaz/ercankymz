// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Tufting.F_TuftUserSettings
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

public class F_TuftUserSettings : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  private Timer timer_0 = new Timer();
  private IContainer icontainer_0 = (IContainer) null;
  public buGround buGround1;
  public buButton btn_closecross;
  public buButton btn_close;
  public buButton buButton10;
  public buButton btn_ok;
  public buSpin spn_cornerdistance;
  public buSpin spn_cornerangle;
  public RadioButton radio_speedred100;
  public RadioButton radio_speedred90;
  public RadioButton radio_speedred80;
  public RadioButton radio_speedred70;
  public RadioButton radio_speedred60;
  public RadioButton radioButton_0;
  public RadioButton radioButton_1;
  public RadioButton radioButton_2;
  public RadioButton radioButton_3;
  public RadioButton radioButton_4;
  public buSpin spn_autocutlooptimiing;
  public buSpin spn_extrayarnoncutexit;
  public buSpin spn_extrayarnonloopexit;
  public buSpin spn_headsensordelay;
  public buSpin spn_loopcuttingcycle;
  public buCheckBox chk_yarnsensorenable;
  public buCheckBox chk_stitcheachcorner;
  public buSpin spn_creelsensordelay;
  public buCheckBox chk_creelsensorenable;
  public RadioButton radio_dynamicveryfast;
  public RadioButton radio_dynamicfast;
  public RadioButton radio_dynamicmedium;
  public RadioButton radio_dynamicslow;
  public RadioButton radio_dynamicveryslow;
  public buCheckBox chk_Dynamicalmoda;
  public buSpin spn_desingdevidelen;
  public buSpin spn_yarntalecutstart;
  public buSpin spn_extrayarnonloopcutterexit;
  public buGroup grp_cornersmooth;
  public buGroup grp_cornerspeedchange;
  public buGroup grp_Sensorsettings;
  public buGroup grp_loopsettings;
  public buGroup grp_dynamicalmode;
  public buGroup grp_continuesmode;
  public buGroup grp_othersettings;
  public buGroup buGroup1;
  public buSpin spn_g0acc;
  public buSpin spn_maxjerk;
  public buSpin spn_g1acc;
  public buSpin spn_g1dec;
  public buSpin spn_g0dec;

  public F_TuftUserSettings()
  {
    Class39.smethod_182(this);
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.Refresh();
    this.timer_0.Interval = 500;
    this.timer_0.Enabled = true;
  }

  public void LoadLanguage()
  {
    this.buGround1.Text = F_TuftUserSettings.Captions[0];
    this.grp_Sensorsettings.Text = F_TuftUserSettings.Captions[1];
    this.chk_yarnsensorenable.Text = F_TuftUserSettings.Captions[2];
    this.chk_creelsensorenable.Text = F_TuftUserSettings.Captions[3];
    this.spn_headsensordelay.Text = F_TuftUserSettings.Captions[4];
    this.spn_creelsensordelay.Text = F_TuftUserSettings.Captions[5];
    this.grp_othersettings.Text = F_TuftUserSettings.Captions[6];
    this.spn_desingdevidelen.Text = F_TuftUserSettings.Captions[7];
    this.grp_loopsettings.Text = F_TuftUserSettings.Captions[8];
    this.spn_loopcuttingcycle.Text = F_TuftUserSettings.Captions[9];
    this.spn_extrayarnonloopexit.Text = F_TuftUserSettings.Captions[10];
    this.spn_extrayarnonloopcutterexit.Text = F_TuftUserSettings.Captions[11];
    this.spn_extrayarnoncutexit.Text = F_TuftUserSettings.Captions[12];
    this.spn_yarntalecutstart.Text = F_TuftUserSettings.Captions[13];
    this.spn_autocutlooptimiing.Text = F_TuftUserSettings.Captions[14];
    this.grp_continuesmode.Text = F_TuftUserSettings.Captions[15];
    this.grp_cornerspeedchange.Text = F_TuftUserSettings.Captions[16 /*0x10*/];
    this.spn_cornerangle.Text = F_TuftUserSettings.Captions[17];
    this.spn_cornerdistance.Text = F_TuftUserSettings.Captions[18];
    this.grp_cornersmooth.Text = F_TuftUserSettings.Captions[19];
    this.chk_stitcheachcorner.Text = F_TuftUserSettings.Captions[20];
    this.grp_dynamicalmode.Text = F_TuftUserSettings.Captions[21];
    this.radio_dynamicveryslow.Text = F_TuftUserSettings.Captions[22];
    this.radio_dynamicslow.Text = F_TuftUserSettings.Captions[23];
    this.radio_dynamicmedium.Text = F_TuftUserSettings.Captions[24];
    this.radio_dynamicfast.Text = F_TuftUserSettings.Captions[25];
    this.radio_dynamicveryfast.Text = F_TuftUserSettings.Captions[26];
    this.btn_ok.Text = F_TuftUserSettings.Captions[27];
    this.btn_close.Text = F_TuftUserSettings.Captions[28];
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.ControlsUpdate();
    this.timer_0.Enabled = false;
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

  public void ControlsUpdate()
  {
    if (!this.chk_Dynamicalmoda.Check)
      this.grp_continuesmode.Enabled = true;
    else
      this.grp_continuesmode.Enabled = false;
  }

  internal void method_3(object object_0, bool bool_0)
  {
    if (!this.PropertiesForm.Inited)
      return;
    this.ControlsUpdate();
    if (this.chk_Dynamicalmoda.Check)
      return;
    this.radio_speedred70.Checked = true;
    this.spn_cornerangle.Value = 150.0;
  }

  internal void method_4(object sender, EventArgs e)
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
