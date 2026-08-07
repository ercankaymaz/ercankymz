// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_NotchCamSettings
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
namespace buControls.Forms.WinControlForms.Profile;

public class F_NotchCamSettings : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public ProfileOperationData OperationData = new ProfileOperationData();
  public camParameters CamPar = new camParameters();
  private IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList imageList_0;
  public Button btn_ok;
  internal Panel panel_0;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal PictureBox pictureBox_2;
  internal Label label_0;
  internal Panel panel_1;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Label label_1;
  public NumericUpDown spn_vellfeed;
  internal Label label_2;
  public NumericUpDown spn_velplunge;
  internal Label label_3;
  internal Label label_4;
  public NumericUpDown spn_disair;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  public NumericUpDown spn_dissafe;
  internal Panel panel_2;
  internal RadioButton radioButton_2;
  internal RadioButton radioButton_3;

  public F_NotchCamSettings() => Class39.smethod_12(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.spn_vellfeed.Value = (Decimal) this.CamPar.Speeds.Feed;
    this.spn_velplunge.Value = (Decimal) this.CamPar.Speeds.Plunge;
    this.spn_disair.Value = (Decimal) this.CamPar.Distances.Air;
    this.spn_dissafe.Value = (Decimal) this.CamPar.Distances.Safe;
    if (this.OperationData.NotchData.NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
    {
      this.radioButton_3.Checked = true;
      this.radioButton_2.Checked = false;
    }
    if (this.OperationData.NotchData.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
    {
      this.radioButton_3.Checked = false;
      this.radioButton_2.Checked = true;
    }
    if (this.OperationData.NotchData.NotchCutType == ProfileNotchCutType.BySawAndMilling)
    {
      this.radioButton_0.Checked = false;
      this.radioButton_1.Checked = true;
    }
    if (this.OperationData.NotchData.NotchCutType == ProfileNotchCutType.BySaw)
    {
      this.radioButton_0.Checked = true;
      this.radioButton_1.Checked = false;
    }
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_NotchCamSettings.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
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
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_16(this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
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
