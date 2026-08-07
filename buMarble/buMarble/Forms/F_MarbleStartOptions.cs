// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleStartOptions
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleStartOptions : Form
{
  public buSpin spn_CameraPositionX;
  public buButton btn_camreraparkgetpos;
  public buCheckBox chk_CameraCoverAvailable;
  public buSpin spn_CameraPositionY;
  public buCheckBox chk_CameraCoverAutoCloseEnable;
  public buSpin spn_CameraPositionZ;
  public buCheckBox chk_CameraAutoCloseEnable;
  public buSpin spn_CameraPositionC;
  public buSpin spn_CameraAutoCloseTimeSec;
  public buSpin spn_CameraPositionA;
  public buSpin spn_CameraTableYOffsetPos;
  public buSpin spn_CameraPosTimeOutSec;
  public buSpin spn_CameraEnableTimeSec;
  public buSpin spn_CameraTableXOffsetPos;
  public buSpin spn_CameraCoverOpenTimeSec;
  public buSpin spn_cropx;
  public buSpin spn_cropy;
  public buSpin spn_cropWidth;
  public buSpin spn_cropHeight;
  public buSpin spn_cameraexposure;

  public void Apply()
  {
    clsAppMarbleVars.varApp.CameraPosTimeOutSec = this.spn_CameraPosTimeOutSec.Value;
    clsAppMarbleVars.varApp.CameraTableXOffsetPos = this.spn_CameraTableXOffsetPos.Value;
    clsAppMarbleVars.varApp.CameraTableYOffsetPos = this.spn_CameraTableYOffsetPos.Value;
    clsAppMarbleVars.varApp.CameraPositionA = this.spn_CameraPositionA.Value;
    clsAppMarbleVars.varApp.CameraPositionC = this.spn_CameraPositionC.Value;
    clsAppMarbleVars.varApp.CameraPositionX = this.spn_CameraPositionX.Value;
    clsAppMarbleVars.varApp.CameraPositionY = this.spn_CameraPositionY.Value;
    clsAppMarbleVars.varApp.CameraPositionZ = this.spn_CameraPositionZ.Value;
    clsAppMarbleVars.varApp.CameraAutoCloseTimeSec = this.spn_CameraAutoCloseTimeSec.Value;
    clsAppMarbleVars.varApp.CameraCoverOpenTimeSec = this.spn_CameraCoverOpenTimeSec.Value;
    clsAppMarbleVars.varApp.CameraEnableTimeSec = this.spn_CameraEnableTimeSec.Value;
    clsAppMarbleVars.varApp.CameraAutoCloseEnable = this.chk_CameraAutoCloseEnable.Check;
    clsAppMarbleVars.varApp.CameraCoverAutoCloseEnable = this.chk_CameraCoverAutoCloseEnable.Check;
    clsAppMarbleVars.varApp.CameraCoverAvailable = this.chk_CameraCoverAvailable.Check;
    clsAppMarbleVars.varApp.CameraPowerAvailable = ((F_MarbleCameraSettings) this).chk_CameraPowerAvailable.Check;
    buMarbleCalc.varMarbleSettings.CameraCropX = (int) this.spn_cropx.Value;
    buMarbleCalc.varMarbleSettings.CameraCropY = (int) this.spn_cropy.Value;
    buMarbleCalc.varMarbleSettings.CameraCropWidth = (int) this.spn_cropWidth.Value;
    buMarbleCalc.varMarbleSettings.CameraCropHeight = (int) this.spn_cropHeight.Value;
    buMarbleCalc.varMarbleSettings.CameraImageWidth = ((F_MarbleToolTypes) this).spn_imagewidth.Value;
    buMarbleCalc.varMarbleSettings.CameraImageHeight = ((F_MarbleToolTypes) this).spn_imageheight.Value;
    buMarbleCalc.varMarbleSettings.CameraImageOffsetX = ((F_MarbleToolTypes) this).spn_imageoffsetX.Value;
    buMarbleCalc.varMarbleSettings.CameraImageOffsetY = ((F_MarbleToolTypes) this).spn_imageoffsety.Value;
    buMarbleCalc.varMarbleSettings.CameraExposure = (int) this.spn_cameraexposure.Value;
    buMarbleCalc.varMarbleSettings.CopyImageToArchive = ((F_MarbleToolTypes) this).chk_sameimagetoArchive.Check;
    buMarbleCalc.varMarbleSettings.AutoLensCalibrationFromMaterialHeight = ((F_MarbleToolTypes) this).chk_autolenscalibrationfromslabthickness.Check;
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(((F_MarbleCameraSettings) this).buGround1.Controls);
    ((F_MarbleCameraSettings) this).buTab_tools.SelectedIndex = PageIndex;
    if (PageIndex == 0)
      ((F_MarbleCameraSettings) this).btn_motionSetting = buControlCommands.SetButtonColorAll(((F_MarbleCameraSettings) this).btn_motionSetting, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex != 1)
      return;
    ((F_MarbleCameraSettings) this).btn_Programsettings = buControlCommands.SetButtonColorAll(((F_MarbleCameraSettings) this).btn_Programsettings, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleCameraSettings) this).btn_ok.Name)
      {
        this.Apply();
        ((F_MarbleCameraSettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleCameraSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleCameraSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleCameraSettings) this).btn_close.Name | control2.Name == ((F_MarbleCameraSettings) this).btn_cancel.Name)
      {
        ((F_MarbleCameraSettings) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleCameraSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleCameraSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleCameraSettings) this).btn_motionSetting.Name)
        this.MenuButtonColors(0);
      if (control2.Name == ((F_MarbleCameraSettings) this).btn_Programsettings.Name)
        this.MenuButtonColors(1);
      if (!(control2.Name == this.btn_camreraparkgetpos.Name) || !AppBool.Connected)
        return;
      if (clsAppMarbleVars.varRuntime.AxX >= 0)
        this.spn_CameraPositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxY >= 0)
        this.spn_CameraPositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxZ >= 0)
        this.spn_CameraPositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxC >= 0)
        this.spn_CameraPositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxA < 0)
        return;
      this.spn_CameraPositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCameraSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCameraSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleStartOptions() => F_MarbleCameraSettings.Captions = new List<string>();

  public F_MarbleStartOptions()
  {
    ((F_MarbleToolTypes) this).PropertiesForm = new FormProperties();
    ((F_MarbleToolTypes) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0005.\u0003.\u0001(this);
  }

  public void Init()
  {
    ((F_MarbleToolTypes) this).PropertiesForm.Inited = false;
    if (((F_MarbleToolTypes) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleToolTypes) this).PropertiesForm.Height;
    if (((F_MarbleToolTypes) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleToolTypes) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleToolTypes) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleToolTypes) this).PropertiesForm.FormPosition;
    if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == (MarbleParkModeAfterJob) 1)
      ((F_MarbleToolTypes) this).\u0002.Checked = true;
    else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == (MarbleParkModeAfterJob) 2)
      ((F_MarbleToolTypes) this).\u0001.Checked = true;
    else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.Saw)
      ((F_MarbleToolTypes) this).\u0003.Checked = true;
    ((F_MarbleToolTypes) this).chk_dryrun.Check = clsAppMarbleVars.varRuntime.isDryRunActivated;
    ((F_MarbleToolTypes) this).chk_pointanglecorrection.Check = clsAppMarbleVars.varApp.PointAngleCorrection;
    ((F_MarbleToolTypes) this).chk_startsafedistance.Check = clsAppMarbleVars.varApp.GoZUpPositionWhenStart;
    ((F_MarbleToolTypes) this).chk_washbeforevacuum.Check = clsAppMarbleVars.varApp.VacuumWashBeforeMaterialTake;
    \u0005.\u0003.\u0001(this);
    ((F_MarbleToolTypes) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleToolTypes) this).PropertiesForm.Inited = true;
  }
}
