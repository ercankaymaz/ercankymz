// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfilePatternCopy
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfilePatternCopy : Form
{
  internal Label \u0080;
  internal PictureBox \u0007;
  internal Panel \u0006;
  internal RadioButton \u0010;
  internal RadioButton \u0011;
  internal RadioButton \u0012;
  internal Label \u0081;
  public NumericUpDown spn_overlap;
  internal Label \u0082;
  internal PictureBox \u0008;
  internal Label \u0083;
  public NumericUpDown spn_depthup;
  internal Label \u0084;
  public static byte f001672;
  public ProfileClamperSettings varProfileClamperSettings;
  public FormProperties Properties;

  static F_ProfilePatternCopy() => F_CamSettings.Captions = new List<string>();

  public F_ProfilePatternCopy()
  {
    ((F_Clampers) this).Properties = new FormProperties();
    ((F_Clampers) this).CamPar = new camParameters5();
    ((F_Clampers) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_NotchCamSettings) this);
  }

  public void Init()
  {
    ((F_Clampers) this).Properties.Inited = false;
    if (((F_Clampers) this).Properties.Height > 10)
      this.Height = ((F_Clampers) this).Properties.Height;
    if (((F_Clampers) this).Properties.Width > 10)
      this.Width = ((F_Clampers) this).Properties.Width;
    this.TopMost = ((F_Clampers) this).Properties.TopMost;
    this.StartPosition = ((F_Clampers) this).Properties.FormPosition;
    ((F_PlaneSettings) this).spn_vellfeed.Value = (Decimal) ((F_Clampers) this).CamPar.Speeds.Feed;
    ((F_PlaneSettings) this).spn_velplunge.Value = (Decimal) ((F_Clampers) this).CamPar.Speeds.Plunge;
    ((F_PlaneMoveRotate) this).spn_toolpersentage.Value = (Decimal) ((MWCalculationOptions) ((camOffset5) ((F_Clampers) this).CamPar).Notch).NotchCutPersentage;
    ((F_PlaneSettings) this).spn_dissafe.Value = (Decimal) ((F_Clampers) this).CamPar.Distances.Safe;
    ((F_PlaneMoveRotate) this).spn_spindlespeed.Value = (Decimal) ((buEyeBaseVer5.camSpeedsEnable) ((F_Clampers) this).CamPar.Speeds).SpindleSpeed;
    ((F_PlaneMoveRotate) this).\u0001.Checked = ((buEyeBaseVer5.camSpeedsEnable) ((F_Clampers) this).CamPar.Speeds).SpindleEnable;
    if (((MWCalculationOptions) ((camOffset5) ((F_Clampers) this).CamPar).Notch).NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
    {
      ((F_PlaneSettings) this).\u0004.Checked = true;
      ((F_PlaneSettings) this).\u0003.Checked = false;
    }
    if (((MWCalculationOptions) ((camOffset5) ((F_Clampers) this).CamPar).Notch).NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
    {
      ((F_PlaneSettings) this).\u0004.Checked = false;
      ((F_PlaneSettings) this).\u0003.Checked = true;
    }
    if (((MWCalculationOptions) ((camOffset5) ((F_Clampers) this).CamPar).Notch).NotchCutType == ProfileNotchCutType.BySawAndMilling)
    {
      ((F_PlaneSettings) this).\u0001.Checked = false;
      ((F_PlaneSettings) this).\u0002.Checked = true;
    }
    if (((MWCalculationOptions) ((camOffset5) ((F_Clampers) this).CamPar).Notch).NotchCutType == ProfileNotchCutType.BySaw)
    {
      ((F_PlaneSettings) this).\u0001.Checked = true;
      ((F_PlaneSettings) this).\u0002.Checked = false;
    }
    if (((MWCalculationOptions) ((camOffset5) ((F_Clampers) this).CamPar).Notch).CutDirection == UpDownDirectionType.UpToDown)
    {
      ((F_PlaneMoveRotate) this).\u0006.Checked = true;
      ((F_PlaneSettings) this).\u0005.Checked = false;
    }
    if (((MWCalculationOptions) ((camOffset5) ((F_Clampers) this).CamPar).Notch).CutDirection == UpDownDirectionType.DownToUp)
    {
      ((F_PlaneMoveRotate) this).\u0006.Checked = false;
      ((F_PlaneSettings) this).\u0005.Checked = true;
    }
    ((F_Clampers) this).Properties.Result = DialogResult.None;
    ((F_Clampers) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_Clampers.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Clampers) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Clampers) this).Properties.Result = DialogResult.Cancel;
    if (((F_Clampers) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Clampers) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Clampers) this).btn_ok.Name)
    {
      if (!((F_Clampers) this).Properties.Inited)
        return;
      if (((F_Clampers) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_NotchCamSettings) this);
      ((F_Clampers) this).Properties.Result = DialogResult.OK;
      if (((F_Clampers) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Clampers) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Clampers) this).btn_cancel.Name))
      return;
    ((F_Clampers) this).Properties.Result = DialogResult.Cancel;
    if (((F_Clampers) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Clampers) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Clampers) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Clampers) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
