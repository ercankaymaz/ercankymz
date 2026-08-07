// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleMachineSettingsV1
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleMachineSettingsV1 : Form
{
  public buButton btn_rightSuctionO;
  public buCheckBox chk_leftsuction;
  public buButton btn_leftsuctionI;
  public buButton btn_leftsuctionO;
  public buButton btn_rightSuction;
  public buButton btn_leftsuction;
  public buButton btn_vacuumdown;
  public buButton btn_vacuumUp;
  public buCheckBox chk_vacuumdown;
  public buButton btn_vacuumdownI;
  public buButton btn_vacuumdownO;
  public buCheckBox chk_vacuumUp;
  public buButton btn_vacuumUpI;
  public buButton btn_vacuumUpO;
  public buCheckBox buCheckBox1;
  public buButton buButton1;
  public buButton buButton4;
  public buButton btn_waermillingonoff;
  public buButton btn_sawfwd;
  public buButton btn_spindlefwd;
  public buSpin spn_VacuumMaxSawDiameter;
  public buSpin spn_MaxSpindleToolLengthForA45;
  public buSpin spn_MaterialMinThickness;
  public buSpin spn_MaterialMaxThickness;
  public static byte f0009BD;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_millinghead;
  public buButton btn_milling;
  public buButton btn_saw;
  public buTab buTab_Main;
  public TabPage tabPage_saw;
  public TabPage tabPage_milling;
  internal TabPage \u0001;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal PictureBox \u0001;
  internal buLabel \u0003;
  internal buLabel \u0004;
  internal buLabel \u0005;
  internal TabPage \u0002;
  public buButton btn_toolchange;
  public buButton btn_millingmeasure;
  public buButton btn_millingpark;
  public buButton btn_millingdata;
  public buTab buTab_milling;
  public TabPage tabPage_millinggeneral;
  public buSpin spn_MillingExtraG54OffsetX;
  public buSpin spn_MillingExtraG54OffsetZ;
  public buSpin spn_MillingExtraG54OffsetY;
  public TabPage tabPage_millingpark;
  public buSpin spn_MillingModePositionX;
  public buSpin spn_MillingModePositionC;
  public buSpin spn_MillingModePositionY;
  public buSpin spn_MillingModePositionA;
  public buSpin spn_MillingModePositionZ;
  internal TabPage \u0003;
  public buSpin spn_MillingLenMeasureMaxLength;
  public buSpin spn_MillingLenMeasureMinLength;
  public buSpin spn_MillingLenMeasurePositionX;
  public buSpin spn_MillingLenMeasureConstant;
  public buSpin spn_MillingLenMeasurePositionLimitZ;
  public buSpin spn_MillingLenMeasurePositionC;
  public buSpin spn_MillingLenMeasurePositionFastZ;
  public buSpin spn_MillingLenMeasurePositionA;
  public buSpin spn_MillingLenMeasurePositionY;
  public buButton btn_sawmeasure;
  public buButton btn_sawpark;
  public buButton btn_sawdata;
  public buTab buTab_saw;
  public TabPage tabPage_sawgeneral;
  public buSpin spn_SawExtraG54OffsetX;
  public buSpin spn_SawExtraG54OffsetZ;
  public buSpin spn_SawExtraG54OffsetY;
  public TabPage tabPage_sawpark;
  public buSpin spn_SawModePositionX;
  public buSpin spn_SawModePositionC;
  public buSpin spn_SawModePositionY;
  public buSpin spn_SawModePositionA;
  public buSpin spn_SawModePositionZ;
  internal TabPage \u0004;
  public buSpin spn_SawDiaMeasureMaxDaimeter;
  public buSpin spn_SawDiaMeasureMinDaimeter;
  public buSpin spn_SawDiaMeasurePositionX;
  public buSpin spn_SawDiaMeasureConstant;
  public buSpin spn_SawDiaMeasurePositionLimitZ;
  public buSpin spn_SawDiaMeasurePositionC;
  public buSpin spn_SawDiaMeasurePositionFastZ;
  public buSpin spn_SawDiaMeasurePositionA;
  public buSpin spn_SawDiaMeasurePositionY;
  public buButton btn_millingheadmeasure;
  public buButton btn_millingheadpark;
  public buButton btn_millingheaddata;
  public buTab buTab_millinghead;
  public TabPage tabPage_millingheadgeneral;
  public buSpin spn_MillingHeadExtraG54OffsetX;
  public buSpin spn_MillingHeadExtraG54OffsetZ;
  public buSpin spn_MillingHeadExtraG54OffsetY;
  public TabPage tabPage_millingheadpark;
  public buSpin spn_MillingHeadModePositionX;
  public buSpin spn_MillingHeadModePositionC;
  public buSpin spn_MillingHeadModePositionY;
  public buSpin spn_MillingHeadModePositionA;
  public buSpin spn_MillingHeadModePositionZ;
  internal TabPage \u0005;
  public buSpin spn_MillingHeadLenMeasureMaxLength;
  public buSpin spn_MillingHeadLenMeasureMinLength;
  public buSpin spn_MillingHeadLenMeasurePositionX;
  public buSpin spn_MillingHeadLenMeasureConstant;
  public buSpin spn_MillingHeadLenMeasurePositionLimitZ;
  public buSpin spn_MillingHeadLenMeasurePositionC;
  public buSpin spn_MillingHeadLenMeasurePositionFastZ;
  public buSpin spn_MillingHeadLenMeasurePositionA;
  public buSpin spn_MillingHeadLenMeasurePositionY;
  internal buLabel \u0006;
  internal buLabel \u0007;
  public buSpin spn_MillingModePosTimeOutSec;
  public buSpin spn_MillingMeasureTimeOutSec;
  internal TabPage \u0006;
  public buSpin spn_ToolMeasureCoverOnTimeSec;
  public buSpin spn_ToolMeasureSlowLeaveVelocity;
  public buSpin spn_ToolMeasureJerk;
  public buSpin spn_ToolMeasureFastVelocity;
  public buSpin spn_ToolMeasureAccDec;
  public buSpin spn_ToolMeasureCoverOffTimeSec;
  public buButton btn_toolmeasure;
  internal buLabel \u0008;
  public buSpin spn_ToolChangeUpPositionZ;
  public buSpin spn_ToolChangeSafePositionZ;
  public buSpin spn_ToolChangePositionX;
  public buSpin spn_ToolChangeYSafeDistance;
  public buSpin spn_ToolChangePositionA;
  public buSpin spn_ToolChangeXSafeDistance;
  public buSpin spn_ToolChangePositionZ;
  public buSpin spn_ToolChangePositionC;
  public buSpin spn_ToolChangePositionY;
  public buSpin spn_ToolChangeBeforePositionX;
  public buSpin spn_ToolMillingClampCloseTimeSec;
  public buSpin spn_ToolChangeLeaveVelocity;
  public buSpin spn_ToolMillingClampOpenTimeSec;
  public buSpin spn_ToolChangeFastVelocity;
  public buSpin spn_ToolChangeTakeVelocity;
  public buSpin spn_ToolChangeSlowVelocity;
  public buButton btn_toolchangetimes;
  public buButton btn_toolchangedata;
  public buTab buTab_toolchange;
  public TabPage tabPage_toolchangegeneral;
  public TabPage tabPage_toolchangetimes;
  public buSpin spn_ToolDoorOpenTimeSec;
  public buSpin spn_ToolDoorCloseTimeSec;
  public buSpin spn_ToolDoorOpenTimeoutSec;
  public buSpin spn_ToolMagazineOpenTimeSec;
  public buSpin spn_ToolDoorCloseTimeoutSec;
  public buSpin spn_ToolMagazineCloseTimeSec;
  public buSpin spn_ToolMagazinOpenTimeoutSec;
  public buSpin spn_ToolMagazinCloseTimeoutSec;
  public buSpin spn_SpindleUpTimeOutSec;
  public buSpin spn_SpindleDownTimeOutSec;
  public buSpin spn_SpindleUpTimeSec;
  public buSpin spn_SpindleDownTimeSec;
  public buSpin spn_SawMeasureTimeOutSec;
  public buSpin spn_MillingHeadModePosTimeOutSec;
  public buSpin spn_MillingHeadMeasureTimeOutSec;
  public buSpin spn_SawMaxSpeed;
  public buSpin spn_SawModePosTimeOutSec;
  public buSpin spn_SpindleStartTimerSec;
  public buSpin spn_SpindleStopTimerSec;
  public buSpin spn_SpindleMaxSpeed;
  internal TabPage \u0007;
  internal buLabel \u000E;
  public buSpin spn_wagonposX;
  public buSpin spn_wagonposA;
  public buSpin spn_wagonhidrostopsec;
  public buSpin spn_wagonposZ;
  public buSpin spn_wagonposC;
  public buSpin spn_wagonposY;
  internal TabPage \u0008;
  public buSpin spn_wagontimeout;
  internal buLabel \u000F;
  public buButton btn_troller;
  public buCheckBox chk_CameraPowerAvailable;
  public buCheckBox chk_CameraCoverAvailable;
  public buCheckBox chk_CameraCoverAutoCloseEnable;
  public buCheckBox chk_CameraAutoCloseEnable;
  public buSpin spn_CameraAutoCloseTimeSec;
  public buSpin spn_CameraTableYOffsetPos;
  public buSpin spn_CameraEnableTimeSec;
  public buSpin spn_CameraCoverOpenTimeSec;
  public buSpin spn_CameraPosTimeOutSec;
  public buSpin spn_CameraTableXOffsetPos;
  public buSpin spn_CameraPositionA;
  public buSpin spn_CameraPositionC;
  public buSpin spn_CameraPositionX;
  public buSpin spn_CameraPositionZ;
  public buSpin spn_CameraPositionY;
  public buButton btn_camera;
  internal TabPage \u000E;
  public buButton btn_materialmeasure;
  public buButton btn_vacuum;
  public buButton btn_axisA;
  public buButton btn_lubrication;
  public buButton btn_misc;
  public buButton btn_wagongetposition;
  public buButton btn_sawparkgetpos;
  public buButton btn_sawmeasuregetpos;
  public buButton btn_millingparkgetpos;
  public buButton btn_millingmeasuregetpos;
  public buButton btn_millingheadparkgetpos;
  public buButton btn_millingheadmeasuregetpos;
  public buButton buButton13;
  public buButton btn_cameragetposition;
  public buButton btn_park;
  internal TabPage \u000F;
  internal TabPage \u0010;
  internal TabPage \u0011;
  internal TabPage \u0012;
  internal TabPage \u0013;
  public buSpin spn_VacuumUpTimeSec;
  internal buLabel \u0010;
  internal buLabel \u0011;
  internal buLabel \u0012;
  internal buLabel \u0013;
  internal buLabel \u0014;
  internal buLabel \u0015;
  public buSpin spn_VacuumBlowerTimeSec;
  public buSpin spn_VacuumOutTimeoutSec;
  public buSpin spn_VacuumInTimeoutSec;
  public buSpin spn_VacuumFastZPosition;
  public buSpin spn_VacuumOffTimeOutSec;
  public buSpin spn_VacuumOnTimeOutSec;
  public buSpin spn_VacuumDownTimeOutSec;
  public buSpin spn_VacuumUpTimeOutSec;
  public buSpin spn_VacuumDownTimeSec;
  public buButton btn_warmup;
  public buSpin spn_MaterialMeasureFastVelocity;
  public buSpin spn_MaterialMeasurePositionFastZ;
  public buSpin spn_MaterialMeasurePositionLimitZ;
  public buSpin spn_MaterialMeasureConstant;
  public buSpin spn_MaterialMeasurePositionA;
  public buSpin spn_MaterialMeasureJerk;
  public buSpin spn_MaterialMeasureUpTimeOutSec;
  public buSpin spn_MaterialMeasurePositionC;
  public buSpin spn_MaterialMeasureMinThickness;
  public buSpin spn_MaterialMeasureAccDec;
  public buSpin spn_MaterialMeasureMaxThickness;
  public buSpin spn_MaterialMeasureSlowVelocity;
  public buCheckBox chk_SawStopdAtCheck;
  public buCheckBox chk_SawSpeedAtCheck;
  public buSpin spn_SawStopTimeoutSec;
  public buSpin spn_SawStartTimerSec;
  public buSpin spn_SawStopTimerSec;
  public buSpin spn_SawStartTimeoutSec;
  public buCheckBox chk_SpindlePersentageSinglePot;
  public buCheckBox chk_SpindlePersentageFromPLC;
  public buCheckBox chk_SpindleCoolAfterStop;
  public buCheckBox chk_SpindleStopdAtCheck;
  public buCheckBox chk_SpindleSpeedAtCheck;
  public buSpin spn_SpindleStartTimeoutSec;
  public buSpin spn_SpindleStopTimeoutSec;
  public buSpin spn_SpindleCoolAfterStopTimeSec;
  public buSpin spn_WarmUpSawTimeSec1;
  public buSpin spn_WarmUpMillingSpeed1;
  public buSpin spn_WarmUpMillingSpeed2;
  public buSpin spn_WarmUpMillingTimeSec2;
  public buSpin spn_WarmUpMillingSpeed3;
  public buSpin spn_WarmUpMillingTimeSec3;
  public buSpin spn_WarmUpMillingTimeSec1;
  public buSpin spn_WarmUpSawSpeed1;
  public buSpin spn_WarmUpSawSpeed2;
  public buSpin spn_WarmUpSawTimeSec3;
  public buSpin spn_WarmUpSawSpeed3;
  public buSpin spn_WarmUpSawTimeSec2;
  public buSpin spn_LubricationTimeSec;
  public buSpin spn_LubricationBlockOnOffTimeSec;
  public buSpin spn_LubricationPeriodWaitMin;
  public buSpin spn_LubricationLevelOnOffTimeSec;
  public buCheckBox chk_LubricationEnable;
  public buSpin spn_parkpositionA;
  public buSpin spn_parkpositionC;
  public buSpin spn_parkpositionx;
  public buSpin spn_parkpositionZ;
  public buSpin spn_parkpositionY;
  internal TabPage \u0014;
  public buCheckBox chk_ServoAAxis;
  public buSpin spn_AAxisAllowedZSafePosition;
  public buSpin spn_AAxisTimeOutSec;
  public buSpin spn_AAxisExtraTimeSec;
  internal buLabel \u0016;
  public buSpin spn_ParkPosTimeOutSec;
  public buSpin spn_WaterOnOffTimerSec;
  public buSpin spn_LaserOnOffTimerSec;
  public buSpin spn_StartPointPosTimeOutSec;
  public buCheckBox chk_GoZUpPositionWhenStart;
  public buCheckBox chk_BuzzerEnable;
  public buSpin spn_BuzzerTimeSec;
  public buSpin spn_ToolMeasureSlowApproachVelocity;
  public buButton btn_sawmeasureshowcalc;
  internal Panel \u0001;
  public buButton btn_sawmeasurecalculate;
  public buSpin spn_SawDiaMeasurecalcDiameter;
  internal Panel \u0002;
  public buButton btn_millingmeasurecalc;
  public buSpin spn_millingmeasurecalc;
  public buButton btn_millingmeasurecalcshow;
  internal Panel \u0003;
  public buButton btn_millingheadmeasurecalc;
  public buSpin spn_millingheadmeasurecalcLEn;
  public buButton btn_millingheadmeasurecalcshow;
  internal Panel \u0004;
  public buButton btn_MaterialMeasureCalc;
  public buSpin spn_MaterialMeasureCalcThickness;
  public buButton btn_MaterialMeasureCalcShow;
  internal TabPage \u0015;
  internal buLabel \u0017;
  public buSpin spn_ToolchangeX10;
  public buSpin spn_ToolchangeY10;
  public buSpin spn_ToolchangeZ10;
  internal buLabel \u0018;
  public buSpin spn_ToolchangeX9;
  public buSpin spn_ToolchangeY9;
  public buSpin spn_ToolchangeZ9;
  internal buLabel \u0019;
  public buSpin spn_ToolchangeX8;
  public buSpin spn_ToolchangeY8;
  public buSpin spn_ToolchangeZ8;
  internal buLabel \u001A;
  public buSpin spn_ToolchangeX7;
  public buSpin spn_ToolchangeY7;
  public buSpin spn_ToolchangeZ7;
  internal buLabel \u001B;
  public buSpin spn_ToolchangeX6;
  public buSpin spn_ToolchangeY6;
  public buSpin spn_ToolchangeZ6;
  internal buLabel \u001C;
  public buSpin spn_ToolchangeX5;
  public buSpin spn_ToolchangeY5;
  public buSpin spn_ToolchangeZ5;
  internal buLabel \u001D;
  public buSpin spn_ToolchangeX4;
  public buSpin spn_ToolchangeY4;
  public buSpin spn_ToolchangeZ4;
  internal buLabel \u001E;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_stop.Name && clsAppMarbleVars.cmdMarble != null)
        clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 2);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_jog.Name && clsAppMarbleItems.frmJogPageV1 != null)
      {
        clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmJogPageV1.Init();
        int num = (int) clsAppMarbleItems.frmJogPageV1.ShowDialog();
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_mdi.Name)
      {
        if (clsAppMarbleItems.frmMDIPageV1 != null)
        {
          clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
          clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
          clsAppMarbleItems.frmMDIPageV1.Init();
          int num = (int) clsAppMarbleItems.frmMDIPageV1.ShowDialog();
        }
        else if (clsAppMarbleItems.frmMDIPageV2 != null)
        {
          clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
          clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
          clsAppMarbleItems.frmMDIPageV2.Init();
          int num = (int) clsAppMarbleItems.frmMDIPageV2.ShowDialog();
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_apply.Name)
      {
        ((F_MarbleMachineSettingsV2) this).Apply();
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
        clsAppMarbleVars.cMachine.bWriteAppParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_ok.Name)
      {
        ((F_MarbleMachineSettingsV2) this).Apply();
        ((F_MarbleMachineSettingsV2) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleMachineSettingsV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMachineSettingsV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_close.Name | control2.Name == ((F_MarbleMachineSettingsV2) this).btn_cancel.Name)
      {
        ((F_MarbleMachineSettingsV2) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleMachineSettingsV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMachineSettingsV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_saw.Name)
      {
        ((F_MarbleMachineSettingsV2) this).buTab_Main.SelectedIndex = 0;
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(0);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_milling.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(1);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millinghead.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(2);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_toolchange.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(3);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_toolchangedata.Name)
      {
        ((F_MarbleMachineSettingsV2) this).buTab_toolchange.SelectedIndex = 0;
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsToolChange(0);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_toolchangetimes.Name)
      {
        ((F_MarbleMachineSettingsV2) this).buTab_toolchange.SelectedIndex = 1;
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsToolChange(1);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_toolchangepositions.Name)
      {
        ((F_MarbleMachineSettingsV2) this).buTab_toolchange.SelectedIndex = 2;
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsToolChange(2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_toolmeasure.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(4);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_camera.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(5);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_vacuum.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(6);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_materialmeasure.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(7);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_warmup.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(8);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_lubrication.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(9);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_positions.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(10);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_misc.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(11);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_calibration.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(12);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_kinematic.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(13);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_IO1.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(14);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_IO2.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(15);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_absoluteset.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(16 /*0x10*/);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_safeparameters.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColors(17);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_xaxis.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsCalibration(0);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_yaxis.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsCalibration(1);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_zaxis.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsCalibration(2);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_caxis.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsCalibration(3);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_aaxis.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsCalibration(4);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_cnc.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsCalibration(5);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_toolmeasuresaw.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsToolMeasure(0);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_toolmeasuremilling.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsToolMeasure(1);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_toolmeasuremillinghead.Name)
        ((F_MarbleMachineSettingsV2) this).MenuButtonColorsToolMeasure(2);
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitminusgetx.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " X");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitnegx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitnegx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitplusgetX.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " X");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitposx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitposx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitminusgetY.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " Y");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitnegy.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitnegy.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitplusgetY.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " Y");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitposy.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitposy.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitminusgetZ.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " Z");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitnegz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitnegz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitplusgetZ.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " Z");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitposz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitposz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitminusgetA.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " A");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitnega.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitnega.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitplusgetA.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " A");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitposa.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitposa.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitminusgetC.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " C");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitnegc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitnegc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitplusgetC.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", buLangTranslate.preSentences.DoYouWantToSetPosition + " C");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).spn_datalimitposc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1);
        ((F_MarbleMachineSettingsV2) this).spn_softlimitposc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitdisablex.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}", buLangTranslate.preSentences.DoYouWantToDisableLimit + " X");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).chk_softlimitx.Check = false;
        ((F_MarbleMachineSettingsV2) this).chk_joglimitx.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimitx.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimitx.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitenablex.Name)
      {
        ((F_MarbleMachineSettingsV2) this).chk_softlimitx.Check = true;
        ((F_MarbleMachineSettingsV2) this).chk_joglimitx.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimitx.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimitx.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitdisabley.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}", buLangTranslate.preSentences.DoYouWantToDisableLimit + " Y");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).chk_softlimity.Check = false;
        ((F_MarbleMachineSettingsV2) this).chk_joglimity.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimity.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimity.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitenabley.Name)
      {
        ((F_MarbleMachineSettingsV2) this).chk_softlimity.Check = true;
        ((F_MarbleMachineSettingsV2) this).chk_joglimity.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimity.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimity.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitdisablez.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}", buLangTranslate.preSentences.DoYouWantToDisableLimit + " Z");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).chk_softlimitz.Check = false;
        ((F_MarbleMachineSettingsV2) this).chk_joglimitz.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimitz.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimitz.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitenablez.Name)
      {
        ((F_MarbleMachineSettingsV2) this).chk_softlimitz.Check = true;
        ((F_MarbleMachineSettingsV2) this).chk_joglimitz.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimitz.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimitz.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitdisablea.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}", buLangTranslate.preSentences.DoYouWantToDisableLimit + " A");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).chk_softlimita.Check = false;
        ((F_MarbleMachineSettingsV2) this).chk_joglimita.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimita.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimita.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitenablea.Name)
      {
        ((F_MarbleMachineSettingsV2) this).chk_softlimita.Check = true;
        ((F_MarbleMachineSettingsV2) this).chk_joglimita.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimita.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimita.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitdisablec.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}", buLangTranslate.preSentences.DoYouWantToDisableLimit + " C");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        ((F_MarbleMachineSettingsV2) this).chk_softlimitc.Check = false;
        ((F_MarbleMachineSettingsV2) this).chk_joglimitc.Check = false;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimitc.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimitc.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_limitenablec.Name)
      {
        ((F_MarbleMachineSettingsV2) this).chk_softlimitc.Check = true;
        ((F_MarbleMachineSettingsV2) this).chk_joglimitc.Check = true;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineSettingsV2) this).chk_softlimitc.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineSettingsV2) this).chk_joglimitc.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_calibx.Name && clsAppMarbleVars.varRuntime.AxX >= 0 & clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = ((F_MarbleMachineSettingsV2) this).spn_calibx_unit.Value;
        double calcGearBox = ((F_MarbleMachineSettingsV2) this).spn_calibx_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(((F_MarbleMachineSettingsV2) this).spn_calibx_moveval.Value, ((F_MarbleMachineSettingsV2) this).spn_calibx_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        ((F_MarbleMachineSettingsV2) this).spn_calibx_unit.Value = calcUnit;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_caliby.Name && clsAppMarbleVars.varRuntime.AxY >= 0 & clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = ((F_MarbleMachineSettingsV2) this).spn_caliby_unit.Value;
        double calcGearBox = ((F_MarbleMachineSettingsV2) this).spn_caliby_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(((F_MarbleMachineSettingsV2) this).spn_caliby_moveval.Value, ((F_MarbleMachineSettingsV2) this).spn_caliby_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        ((F_MarbleMachineSettingsV2) this).spn_caliby_unit.Value = calcUnit;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_calibz.Name && clsAppMarbleVars.varRuntime.AxZ >= 0 & clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = ((F_MarbleMachineSettingsV2) this).spn_calibz_unit.Value;
        double calcGearBox = ((F_MarbleMachineSettingsV2) this).spn_calibz_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(((F_MarbleMachineSettingsV2) this).spn_calibz_moveval.Value, ((F_MarbleMachineSettingsV2) this).spn_calibz_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        ((F_MarbleMachineSettingsV2) this).spn_calibz_unit.Value = calcUnit;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_caliba.Name && clsAppMarbleVars.varRuntime.AxA >= 0 & clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = ((F_MarbleMachineSettingsV2) this).spn_caliba_unit.Value;
        double calcGearBox = ((F_MarbleMachineSettingsV2) this).spn_caliba_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(((F_MarbleMachineSettingsV2) this).spn_caliba_moveval.Value, ((F_MarbleMachineSettingsV2) this).spn_caliba_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        ((F_MarbleMachineSettingsV2) this).spn_caliba_unit.Value = calcUnit;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_calibc.Name && clsAppMarbleVars.varRuntime.AxC >= 0 & clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
      {
        double calcUnit = ((F_MarbleMachineSettingsV2) this).spn_calibc_unit.Value;
        double calcGearBox = ((F_MarbleMachineSettingsV2) this).spn_calibc_gear.Value;
        clsAppMarbleVars.cMachine.Commands.AxisCalibration(((F_MarbleMachineSettingsV2) this).spn_calibc_moveval.Value, ((F_MarbleMachineSettingsV2) this).spn_calibc_measuredeval.Value, true, ref calcUnit, ref calcGearBox);
        ((F_MarbleMachineSettingsV2) this).spn_calibc_unit.Value = calcUnit;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_sawmeasurecalculate.Name)
      {
        double Val = 0.0;
        clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, "AppRun.SawDiaCalcZPosition", ref Val);
        ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasureConstant.Value = ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurecalcDiameter.Value / 2.0 - Val;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_sawmeasureshowcalc.Name)
      {
        if (!((F_MarbleMachineSettingsV2) this).\u0002.Visible)
          ((F_MarbleMachineSettingsV2) this).\u0002.Visible = true;
        else
          ((F_MarbleMachineSettingsV2) this).\u0002.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingmeasurecalc.Name)
      {
        double Val = 0.0;
        clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MillingLenCalcZPosition", ref Val);
        ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasureConstant.Value = ((F_MarbleMachineSettingsV2) this).spn_millingmeasurecalc.Value - Val;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingmeasurecalcshow.Name)
      {
        if (!((F_MarbleMachineSettingsV2) this).\u0003.Visible)
          ((F_MarbleMachineSettingsV2) this).\u0003.Visible = true;
        else
          ((F_MarbleMachineSettingsV2) this).\u0003.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingheadmeasurecalc.Name)
      {
        double Val = 0.0;
        clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MillingHeadLenCalcZPosition", ref Val);
        ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasureConstant.Value = ((F_MarbleMachineSettingsV2) this).spn_millingheadmeasurecalcLEn.Value - Val;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingheadmeasurecalcshow.Name)
      {
        if (!((F_MarbleMachineSettingsV2) this).\u0004.Visible)
          ((F_MarbleMachineSettingsV2) this).\u0004.Visible = true;
        else
          ((F_MarbleMachineSettingsV2) this).\u0004.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_MaterialMeasureCalc.Name)
      {
        double Val = 0.0;
        clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcZPosition", ref Val);
        ((F_MarbleMachineSettingsV2) this).spn_MaterialMeasureConstant.Value = ((F_MarbleMachineSettingsV2) this).spn_MaterialMeasureCalcThickness.Value - Val;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_MaterialMeasureCalcShow.Name)
      {
        if (!((F_MarbleMachineSettingsV2) this).\u0001.Visible)
          ((F_MarbleMachineSettingsV2) this).\u0001.Visible = true;
        else
          ((F_MarbleMachineSettingsV2) this).\u0001.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_generalparkgo.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Park} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.Park}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val1 = ((F_MarbleMachineSettingsV2) this).spn_generalparkx.Value;
          double Val2 = ((F_MarbleMachineSettingsV2) this).spn_generalparky.Value;
          double Val3 = ((F_MarbleMachineSettingsV2) this).spn_generalparkz.Value;
          double Val4 = ((F_MarbleMachineSettingsV2) this).spn_generalparka.Value;
          double Val5 = ((F_MarbleMachineSettingsV2) this).spn_generalparkc.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val1, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val2, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val3, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val4, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val5, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_wagongo.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Table} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.Table}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val6 = ((F_MarbleMachineSettingsV2) this).spn_wagonposX.Value;
          double Val7 = ((F_MarbleMachineSettingsV2) this).spn_wagonposY.Value;
          double Val8 = ((F_MarbleMachineSettingsV2) this).spn_wagonposZ.Value;
          double Val9 = ((F_MarbleMachineSettingsV2) this).spn_wagonposA.Value;
          double Val10 = ((F_MarbleMachineSettingsV2) this).spn_wagonposC.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val6, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val7, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val8, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val9, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val10, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_camerago.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Camera} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.Camera}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val11 = ((F_MarbleMachineSettingsV2) this).spn_CameraPositionX.Value;
          double Val12 = ((F_MarbleMachineSettingsV2) this).spn_CameraPositionY.Value;
          double Val13 = ((F_MarbleMachineSettingsV2) this).spn_CameraPositionZ.Value;
          double Val14 = ((F_MarbleMachineSettingsV2) this).spn_CameraPositionA.Value;
          double Val15 = ((F_MarbleMachineSettingsV2) this).spn_CameraPositionC.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val11, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val12, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val13, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val14, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val15, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_sawmeasurego.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val16 = ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionX.Value;
          double Val17 = ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionY.Value;
          double Val18 = ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionFastZ.Value;
          double Val19 = ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionA.Value;
          double Val20 = ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionC.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val16, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val17, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val18, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val19, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val20, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingmeasurego.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val21 = ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionX.Value;
          double Val22 = ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionY.Value;
          double Val23 = ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionFastZ.Value;
          double Val24 = ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionA.Value;
          double Val25 = ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionC.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val21, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val22, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val23, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val24, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val25, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingheadmeasurego.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Measure}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val26 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionX.Value;
          double Val27 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionY.Value;
          double Val28 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionFastZ.Value;
          double Val29 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionA.Value;
          double Val30 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionC.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val26, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val27, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val28, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val29, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val30, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_sawparkgo.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Park} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Park}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val31 = ((F_MarbleMachineSettingsV2) this).spn_SawModePositionX.Value;
          double Val32 = ((F_MarbleMachineSettingsV2) this).spn_SawModePositionY.Value;
          double Val33 = ((F_MarbleMachineSettingsV2) this).spn_SawModePositionZ.Value;
          double Val34 = ((F_MarbleMachineSettingsV2) this).spn_SawModePositionA.Value;
          double Val35 = ((F_MarbleMachineSettingsV2) this).spn_SawModePositionC.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val31, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val32, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val33, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val34, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val35, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingparkgo.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Park} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Park}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val36 = ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionX.Value;
          double Val37 = ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionY.Value;
          double Val38 = ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionZ.Value;
          double Val39 = ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionA.Value;
          double Val40 = ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionC.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val36, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val37, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val38, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val39, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val40, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingheadparkgo.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Park} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Move}", $"{buLangTranslate.preSentences.DoYouWantToGoPosition} {buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Park}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          double Val41 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionX.Value;
          double Val42 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionY.Value;
          double Val43 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionZ.Value;
          double Val44 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionA.Value;
          double Val45 = ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionC.Value;
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val41, "AppRun.CommonPosX");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val42, "AppRun.CommonPosY");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val43, "AppRun.CommonPosZ");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val44, "AppRun.CommonPosA");
          clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val45, "AppRun.CommonPosC");
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.GoCommonPos");
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_generalparkgetpos.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Park} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.Park}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.varRuntime.AxX >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_generalparkx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxY >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_generalparky.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxZ >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_generalparkz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxC >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_generalparkc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxA >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_generalparka.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_wagongetposition.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Table} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.Table}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.varRuntime.AxX >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_wagonposX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxY >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_wagonposY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxZ >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_wagonposZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxC >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_wagonposC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxA >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_wagonposA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_cameragetposition.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Camera} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.Camera}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.varRuntime.AxX >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_CameraPositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxY >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_CameraPositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxZ >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_CameraPositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxC >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_CameraPositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxA >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_CameraPositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_sawmeasuregetpos.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.varRuntime.AxX >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxY >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxZ >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxC >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxA >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawDiaMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_sawparkgetpos.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Park} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Park}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.varRuntime.AxX >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxY >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxZ >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxC >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxA >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_SawModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingmeasuregetpos.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.varRuntime.AxX >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxY >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxZ >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxC >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxA >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingLenMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingparkgetpos.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Park} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Park}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.varRuntime.AxX >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxY >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxZ >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxC >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxA >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
        }
      }
      if (control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingheadmeasuregetpos.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.Init($"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Measure} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Measure}");
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        if (AppBool.Connected)
        {
          if (clsAppMarbleVars.varRuntime.AxX >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxY >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxZ >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxC >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
          if (clsAppMarbleVars.varRuntime.AxA >= 0)
            ((F_MarbleMachineSettingsV2) this).spn_MillingHeadLenMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
        }
      }
      if (!(control2.Name == ((F_MarbleMachineSettingsV2) this).btn_millingheadparkgetpos.Name))
        return;
      buDialogMessageBoxYesNo dialogMessageBoxYesNo1 = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo1.Init($"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Park} {buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}", $"{buLangTranslate.preSentences.DoYouWantToSetPosition} {buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Park}");
      int num1 = (int) dialogMessageBoxYesNo1.ShowDialog();
      if (dialogMessageBoxYesNo1.Result != DialogResult.Yes || !AppBool.Connected)
        return;
      if (clsAppMarbleVars.varRuntime.AxX >= 0)
        ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxY >= 0)
        ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxZ >= 0)
        ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxC >= 0)
        ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxA < 0)
        return;
      ((F_MarbleMachineSettingsV2) this).spn_MillingHeadModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buNumeric5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_sawbwd.Name)
    {
      clsAppMarbleVars.varInterface.SawSpeed = -((F_MarbleMachineSettingsV2) this).spn_sawspeed.Value;
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 93);
    }
    if (control.Name == this.btn_sawfwd.Name)
    {
      clsAppMarbleVars.varInterface.SawSpeed = ((F_MarbleMachineSettingsV2) this).spn_sawspeed.Value;
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 93);
    }
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_spindlebwd.Name)
    {
      clsAppMarbleVars.varInterface.SpindleSpeed = -((F_MarbleMachineSettingsV2) this).spn_millingspeed.Value;
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 92);
    }
    if (control.Name == this.btn_spindlefwd.Name)
    {
      clsAppMarbleVars.varInterface.SpindleSpeed = ((F_MarbleMachineSettingsV2) this).spn_millingspeed.Value;
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 92);
    }
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_rocketdown.Name)
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 12);
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_rocketup.Name)
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 11);
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_watersawonoff.Name)
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 21);
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_laserOnOff.Name)
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 20);
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_cameraOpenClose.Name)
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 89);
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_lubricationOnOff.Name)
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 90);
    if (control.Name == ((F_MarbleMachineSettingsV2) this).btn_toolmeasureupdown.Name)
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 91);
    if (!(control.Name == ((F_MarbleMachineSettingsV2) this).btn_materialmeasureUpDown.Name))
      return;
    clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 70);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMachineSettingsV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMachineSettingsV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMachineSettingsV1() => F_MarbleMachineSettingsV2.Captions = new List<string>();

  public F_MarbleMachineSettingsV1() => \u0005.\u0003.\u0001(this);

  public void Init(int Index)
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.buTab_Main.ItemSize = new Size(1, 1);
    this.buTab_milling.ItemSize = new Size(1, 1);
    this.buTab_saw.ItemSize = new Size(1, 1);
    this.buTab_toolchange.ItemSize = new Size(1, 1);
    this.buTab_millinghead.ItemSize = new Size(1, 1);
    if (Index >= 0)
    {
      this.buTab_Main.SelectedIndex = Index;
      this.MenuButtonColors(Index);
    }
    else
    {
      this.buTab_Main.SelectedIndex = 0;
      this.MenuButtonColors(0);
    }
    this.MenuButtonColorsMilling(0);
    this.MenuButtonColorsMillingHead(0);
    this.MenuButtonColorsSaw(0);
    ((F_MarbleCameraSettings) this).MenuButtonColorsToolChange(0);
    this.spn_SawMaxSpeed.Value = clsAppMarbleVars.varApp.SawMaxSpeed;
    this.spn_SawExtraG54OffsetX.Value = clsAppMarbleVars.varApp.SawExtraG54OffsetX;
    this.spn_SawExtraG54OffsetY.Value = clsAppMarbleVars.varApp.SawExtraG54OffsetY;
    this.spn_SawExtraG54OffsetZ.Value = clsAppMarbleVars.varApp.SawExtraG54OffsetZ;
    this.spn_SawStartTimerSec.Value = clsAppMarbleVars.varApp.SawStartTimerSec;
    this.spn_SawStopTimerSec.Value = clsAppMarbleVars.varApp.SawStopTimerSec;
    this.spn_SawStartTimeoutSec.Value = clsAppMarbleVars.varApp.SawStartTimeoutSec;
    this.spn_SawStopTimeoutSec.Value = clsAppMarbleVars.varApp.SawStopTimeoutSec;
    this.chk_SawSpeedAtCheck.Check = clsAppMarbleVars.varApp.SawSpeedAtCheck;
    this.chk_SawStopdAtCheck.Check = clsAppMarbleVars.varApp.SawSpeedAtCheck;
    this.spn_MillingExtraG54OffsetX.Value = clsAppMarbleVars.varApp.MillingExtraG54OffsetX;
    this.spn_MillingExtraG54OffsetY.Value = clsAppMarbleVars.varApp.MillingExtraG54OffsetY;
    this.spn_MillingExtraG54OffsetZ.Value = clsAppMarbleVars.varApp.MillingExtraG54OffsetZ;
    this.spn_SpindleMaxSpeed.Value = clsAppMarbleVars.varApp.SpindleMaxSpeed;
    this.spn_SpindleStartTimerSec.Value = clsAppMarbleVars.varApp.SpindleStartTimerSec;
    this.spn_SpindleStopTimerSec.Value = clsAppMarbleVars.varApp.SpindleStopTimerSec;
    this.spn_SpindleStartTimeoutSec.Value = clsAppMarbleVars.varApp.SpindleStartTimeoutSec;
    this.spn_SpindleStopTimeoutSec.Value = clsAppMarbleVars.varApp.SpindleStopTimeoutSec;
    this.spn_SpindleUpTimeSec.Value = clsAppMarbleVars.varApp.SpindleUpTimeSec;
    this.spn_SpindleDownTimeSec.Value = clsAppMarbleVars.varApp.SpindleDownTimeSec;
    this.spn_SpindleUpTimeOutSec.Value = clsAppMarbleVars.varApp.SpindleUpTimeOutSec;
    this.spn_SpindleDownTimeOutSec.Value = clsAppMarbleVars.varApp.SpindleDownTimeOutSec;
    this.spn_SpindleCoolAfterStopTimeSec.Value = clsAppMarbleVars.varApp.SpindleCoolAfterStopTimeSec;
    this.chk_SpindleSpeedAtCheck.Check = clsAppMarbleVars.varApp.SpindleSpeedAtCheck;
    this.chk_SpindleStopdAtCheck.Check = clsAppMarbleVars.varApp.SpindleStopdAtCheck;
    this.chk_SpindleCoolAfterStop.Check = clsAppMarbleVars.varApp.SpindleCoolAfterStop;
    this.chk_SpindlePersentageFromPLC.Check = clsAppMarbleVars.varApp.SpindlePersentageFromPLC;
    this.chk_SpindlePersentageSinglePot.Check = clsAppMarbleVars.varApp.SpindlePersentageSinglePot;
    this.spn_MillingHeadExtraG54OffsetX.Value = clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetX;
    this.spn_MillingHeadExtraG54OffsetY.Value = clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetY;
    this.spn_MillingHeadExtraG54OffsetZ.Value = clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetZ;
    this.spn_ToolChangePositionA.Value = clsAppMarbleVars.varApp.ToolChangePositionA;
    this.spn_ToolChangePositionC.Value = clsAppMarbleVars.varApp.ToolChangePositionC;
    this.spn_ToolChangeXSafeDistance.Value = clsAppMarbleVars.varApp.ToolChangeXSafeDistance;
    this.spn_ToolChangeYSafeDistance.Value = clsAppMarbleVars.varApp.ToolChangeYSafeDistance;
    this.spn_ToolChangeSafePositionZ.Value = clsAppMarbleVars.varApp.ToolChangeSafePositionZ;
    this.spn_ToolChangeUpPositionZ.Value = clsAppMarbleVars.varApp.ToolChangeUpPositionZ;
    this.spn_ToolChangeBeforePositionX.Value = clsAppMarbleVars.varApp.ToolChangeBeforePositionX;
    this.spn_ToolChangeSlowVelocity.Value = clsAppMarbleVars.varApp.ToolChangeSlowVelocity;
    this.spn_ToolChangeFastVelocity.Value = clsAppMarbleVars.varApp.ToolChangeFastVelocity;
    this.spn_ToolChangeLeaveVelocity.Value = clsAppMarbleVars.varApp.ToolChangeLeaveVelocity;
    this.spn_ToolChangeTakeVelocity.Value = clsAppMarbleVars.varApp.ToolChangeTakeVelocity;
    this.spn_ToolMillingClampOpenTimeSec.Value = clsAppMarbleVars.varApp.ToolMillingClampOpenTimeSec;
    this.spn_ToolMillingClampCloseTimeSec.Value = clsAppMarbleVars.varApp.ToolMillingClampCloseTimeSec;
    ((F_MarbleCameraSettings) this).spn_ToolchangeX1.Value = clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.X;
    ((F_MarbleCameraSettings) this).spn_ToolchangeY1.Value = clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.Y;
    ((F_MarbleCameraSettings) this).spn_ToolchangeZ1.Value = clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.Z;
    ((F_MarbleCameraSettings) this).spn_ToolchangeX2.Value = clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.X;
    ((F_MarbleCameraSettings) this).spn_ToolchangeY2.Value = clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.Y;
    ((F_MarbleCameraSettings) this).spn_ToolchangeZ2.Value = clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.Z;
    ((F_MarbleCameraSettings) this).spn_ToolchangeX3.Value = clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.X;
    ((F_MarbleCameraSettings) this).spn_ToolchangeY3.Value = clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.Y;
    ((F_MarbleCameraSettings) this).spn_ToolchangeZ3.Value = clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.Z;
    this.spn_ToolchangeX4.Value = clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.X;
    this.spn_ToolchangeY4.Value = clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.Y;
    this.spn_ToolchangeZ4.Value = clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.Z;
    this.spn_ToolchangeX5.Value = clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.X;
    this.spn_ToolchangeY5.Value = clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.Y;
    this.spn_ToolchangeZ5.Value = clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.Z;
    this.spn_ToolchangeX6.Value = clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.X;
    this.spn_ToolchangeY6.Value = clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.Y;
    this.spn_ToolchangeZ6.Value = clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.Z;
    this.spn_ToolchangeX7.Value = clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.X;
    this.spn_ToolchangeY7.Value = clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.Y;
    this.spn_ToolchangeZ7.Value = clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.Z;
    this.spn_ToolchangeX8.Value = clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.X;
    this.spn_ToolchangeY8.Value = clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.Y;
    this.spn_ToolchangeZ8.Value = clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.Z;
    this.spn_ToolchangeX9.Value = clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.X;
    this.spn_ToolchangeY9.Value = clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.Y;
    this.spn_ToolchangeZ9.Value = clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.Z;
    this.spn_ToolchangeX10.Value = clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.X;
    this.spn_ToolchangeY10.Value = clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.Y;
    this.spn_ToolchangeZ10.Value = clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.Z;
    this.spn_ToolDoorOpenTimeSec.Value = clsAppMarbleVars.varApp.AtcOpenTimeSec;
    this.spn_ToolDoorCloseTimeSec.Value = clsAppMarbleVars.varApp.AtcCloseTimeSec;
    this.spn_ToolMagazineOpenTimeSec.Value = clsAppMarbleVars.varApp.AtcForwardTimeSec;
    this.spn_ToolMagazineCloseTimeSec.Value = clsAppMarbleVars.varApp.AtcBackwardTimeSec;
    this.spn_ToolDoorOpenTimeoutSec.Value = clsAppMarbleVars.varApp.AtcOpenTimeoutSec;
    this.spn_ToolDoorCloseTimeoutSec.Value = clsAppMarbleVars.varApp.AtcCloseTimeoutSec;
    this.spn_ToolMagazinOpenTimeoutSec.Value = clsAppMarbleVars.varApp.AtcForwardTimeoutSec;
    this.spn_ToolMagazinCloseTimeoutSec.Value = clsAppMarbleVars.varApp.AtcBackwardTimeoutSec;
    this.spn_SawModePositionX.Value = clsAppMarbleVars.varApp.SawModePositionX;
    this.spn_SawModePositionY.Value = clsAppMarbleVars.varApp.SawModePositionY;
    this.spn_SawModePositionZ.Value = clsAppMarbleVars.varApp.SawModePositionZ;
    this.spn_SawModePositionA.Value = clsAppMarbleVars.varApp.SawModePositionA;
    this.spn_SawModePositionC.Value = clsAppMarbleVars.varApp.SawModePositionC;
    this.spn_SawModePosTimeOutSec.Value = clsAppMarbleVars.varApp.SawModePosTimeOutSec;
    this.spn_MillingModePositionX.Value = clsAppMarbleVars.varApp.MillingModePositionX;
    this.spn_MillingModePositionY.Value = clsAppMarbleVars.varApp.MillingModePositionY;
    this.spn_MillingModePositionZ.Value = clsAppMarbleVars.varApp.MillingModePositionZ;
    this.spn_MillingModePositionA.Value = clsAppMarbleVars.varApp.MillingModePositionA;
    this.spn_MillingModePositionC.Value = clsAppMarbleVars.varApp.MillingModePositionC;
    this.spn_MillingModePosTimeOutSec.Value = clsAppMarbleVars.varApp.MillingModePosTimeOutSec;
    this.spn_MillingHeadModePositionX.Value = clsAppMarbleVars.varApp.MillingHeadModePositionX;
    this.spn_MillingHeadModePositionY.Value = clsAppMarbleVars.varApp.MillingHeadModePositionY;
    this.spn_MillingHeadModePositionZ.Value = clsAppMarbleVars.varApp.MillingHeadModePositionZ;
    this.spn_MillingHeadModePositionA.Value = clsAppMarbleVars.varApp.MillingHeadModePositionA;
    this.spn_MillingHeadModePositionC.Value = clsAppMarbleVars.varApp.MillingHeadModePositionC;
    this.spn_MillingHeadModePosTimeOutSec.Value = clsAppMarbleVars.varApp.MillingHeadModePosTimeOutSec;
    this.spn_SawDiaMeasurePositionX.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionX;
    this.spn_SawDiaMeasurePositionY.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionY;
    this.spn_SawDiaMeasurePositionFastZ.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionFastZ;
    this.spn_SawDiaMeasurePositionLimitZ.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionLimitZ;
    this.spn_SawDiaMeasurePositionA.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionA;
    this.spn_SawDiaMeasurePositionC.Value = clsAppMarbleVars.varApp.SawDiaMeasurePositionC;
    this.spn_SawDiaMeasureConstant.Value = clsAppMarbleVars.varApp.SawDiaMeasureConstant;
    this.spn_SawDiaMeasureMinDaimeter.Value = clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter;
    this.spn_SawDiaMeasureMaxDaimeter.Value = clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter;
    this.spn_SawMeasureTimeOutSec.Value = clsAppMarbleVars.varApp.SawMeasureTimeOutSec;
    this.spn_MillingLenMeasurePositionX.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionX;
    this.spn_MillingLenMeasurePositionY.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionY;
    this.spn_MillingLenMeasurePositionFastZ.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ;
    this.spn_MillingLenMeasurePositionLimitZ.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionLimitZ;
    this.spn_MillingLenMeasurePositionA.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionA;
    this.spn_MillingLenMeasurePositionC.Value = clsAppMarbleVars.varApp.MillingLenMeasurePositionC;
    this.spn_MillingLenMeasureConstant.Value = clsAppMarbleVars.varApp.MillingLenMeasureConstant;
    this.spn_MillingLenMeasureMinLength.Value = clsAppMarbleVars.varApp.MillingLenMeasureMinLength;
    this.spn_MillingLenMeasureMaxLength.Value = clsAppMarbleVars.varApp.MillingLenMeasureMaxLength;
    this.spn_MillingMeasureTimeOutSec.Value = clsAppMarbleVars.varApp.MillingMeasureTimeOutSec;
    this.spn_MillingHeadLenMeasurePositionX.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX;
    this.spn_MillingHeadLenMeasurePositionY.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY;
    this.spn_MillingHeadLenMeasurePositionFastZ.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ;
    this.spn_MillingHeadLenMeasurePositionLimitZ.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionLimitZ;
    this.spn_MillingHeadLenMeasurePositionA.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA;
    this.spn_MillingHeadLenMeasurePositionC.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC;
    this.spn_MillingHeadLenMeasureConstant.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasureConstant;
    this.spn_MillingHeadLenMeasureMinLength.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength;
    this.spn_MillingHeadLenMeasureMaxLength.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength;
    this.spn_MillingHeadMeasureTimeOutSec.Value = clsAppMarbleVars.varApp.MillingHeadMeasureTimeOutSec;
    this.spn_ToolMeasureCoverOnTimeSec.Value = clsAppMarbleVars.varApp.ToolMeasureCoverOnTimeSec;
    this.spn_ToolMeasureCoverOffTimeSec.Value = clsAppMarbleVars.varApp.ToolMeasureCoverOffTimeSec;
    this.spn_ToolMeasureFastVelocity.Value = clsAppMarbleVars.varApp.ToolMeasureFastVelocity;
    this.spn_ToolMeasureSlowLeaveVelocity.Value = clsAppMarbleVars.varApp.ToolMeasureLeaveSlowVelocity;
    this.spn_ToolMeasureSlowApproachVelocity.Value = clsAppMarbleVars.varApp.ToolMeasureApproachSlowVelocity;
    this.spn_ToolMeasureAccDec.Value = clsAppMarbleVars.varApp.ToolMeasureAccDec;
    this.spn_ToolMeasureJerk.Value = clsAppMarbleVars.varApp.ToolMeasureJerk;
    this.spn_wagonposX.Value = clsAppMarbleVars.varApp.WagonUpPositionX;
    this.spn_wagonposY.Value = clsAppMarbleVars.varApp.WagonUpPositionY;
    this.spn_wagonposZ.Value = clsAppMarbleVars.varApp.WagonUpPositionZ;
    this.spn_wagonposA.Value = clsAppMarbleVars.varApp.WagonUpPositionA;
    this.spn_wagonposC.Value = clsAppMarbleVars.varApp.WagonUpPositionC;
    this.spn_wagonhidrostopsec.Value = clsAppMarbleVars.varApp.WagonHidroStopSec;
    this.spn_wagontimeout.Value = clsAppMarbleVars.varApp.WagonPosTimeOutSec;
    this.spn_VacuumBlowerTimeSec.Value = clsAppMarbleVars.varApp.VacuumBlowerTimeSec;
    this.spn_VacuumDownTimeOutSec.Value = clsAppMarbleVars.varApp.VacuumDownTimeOutSec;
    this.spn_VacuumDownTimeSec.Value = clsAppMarbleVars.varApp.VacuumDownTimeSec;
    this.spn_VacuumFastZPosition.Value = clsAppMarbleVars.varApp.VacuumFastZPosition;
    this.spn_VacuumInTimeoutSec.Value = clsAppMarbleVars.varApp.VacuumInTimeoutSec;
    this.spn_VacuumOffTimeOutSec.Value = clsAppMarbleVars.varApp.VacuumOffTimeOutSec;
    this.spn_VacuumOnTimeOutSec.Value = clsAppMarbleVars.varApp.VacuumOnTimeOutSec;
    this.spn_VacuumOutTimeoutSec.Value = clsAppMarbleVars.varApp.VacuumOutTimeoutSec;
    this.spn_VacuumUpTimeOutSec.Value = clsAppMarbleVars.varApp.VacuumUpTimeOutSec;
    this.spn_VacuumUpTimeSec.Value = clsAppMarbleVars.varApp.VacuumUpTimeSec;
    this.spn_MaterialMeasureAccDec.Value = clsAppMarbleVars.varApp.MaterialMeasureAccDec;
    this.spn_MaterialMeasureConstant.Value = clsAppMarbleVars.varApp.MaterialMeasureConstant;
    this.spn_MaterialMeasureFastVelocity.Value = clsAppMarbleVars.varApp.MaterialMeasureFastVelocity;
    this.spn_MaterialMeasureJerk.Value = clsAppMarbleVars.varApp.MaterialMeasureJerk;
    this.spn_MaterialMeasureMaxThickness.Value = clsAppMarbleVars.varApp.MaterialMeasureMaxThickness;
    this.spn_MaterialMeasureMinThickness.Value = clsAppMarbleVars.varApp.MaterialMeasureMinThickness;
    this.spn_MaterialMeasurePositionA.Value = clsAppMarbleVars.varApp.MaterialMeasurePositionA;
    this.spn_MaterialMeasurePositionC.Value = clsAppMarbleVars.varApp.MaterialMeasurePositionC;
    this.spn_MaterialMeasurePositionFastZ.Value = clsAppMarbleVars.varApp.MaterialMeasurePositionFastZ;
    this.spn_MaterialMeasurePositionLimitZ.Value = clsAppMarbleVars.varApp.MaterialMeasurePositionLimitZ;
    this.spn_MaterialMeasureSlowVelocity.Value = clsAppMarbleVars.varApp.MaterialMeasureSlowVelocity;
    this.spn_MaterialMeasureUpTimeOutSec.Value = clsAppMarbleVars.varApp.MaterialMeasureUpTimeOutSec;
    ((F_MarbleCameraSettings) this).spn_MaterialMeasureG54OffsetX.Value = clsAppMarbleVars.varApp.MaterialMeasureG54OffsetX;
    ((F_MarbleCameraSettings) this).spn_MaterialMeasureG54OffsetY.Value = clsAppMarbleVars.varApp.MaterialMeasureG54OffsetY;
    ((F_MarbleCameraSettings) this).spn_MaterialMeasureMaxSawDiameter.Value = clsAppMarbleVars.varApp.MaterialMeasureMaxSawDiameter;
    ((F_MarbleCameraSettings) this).spn_MaterialMeasureXBorderOffset.Value = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
    ((F_MarbleCameraSettings) this).spn_MaterialMeasureYBorderOffset.Value = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
    this.spn_WarmUpMillingSpeed1.Value = clsAppMarbleVars.varApp.WarmUpMillingSpeed1;
    this.spn_WarmUpMillingSpeed2.Value = clsAppMarbleVars.varApp.WarmUpMillingSpeed2;
    this.spn_WarmUpMillingSpeed3.Value = clsAppMarbleVars.varApp.WarmUpMillingSpeed3;
    this.spn_WarmUpMillingTimeSec1.Value = clsAppMarbleVars.varApp.WarmUpMillingTimeSec1;
    this.spn_WarmUpMillingTimeSec2.Value = clsAppMarbleVars.varApp.WarmUpMillingTimeSec2;
    this.spn_WarmUpMillingTimeSec3.Value = clsAppMarbleVars.varApp.WarmUpMillingTimeSec3;
    this.spn_WarmUpSawSpeed1.Value = clsAppMarbleVars.varApp.WarmUpSawSpeed1;
    this.spn_WarmUpSawSpeed2.Value = clsAppMarbleVars.varApp.WarmUpSawSpeed2;
    this.spn_WarmUpSawSpeed3.Value = clsAppMarbleVars.varApp.WarmUpSawSpeed3;
    this.spn_WarmUpSawTimeSec1.Value = clsAppMarbleVars.varApp.WarmUpSawTimeSec1;
    this.spn_WarmUpSawTimeSec2.Value = clsAppMarbleVars.varApp.WarmUpSawTimeSec2;
    this.spn_WarmUpSawTimeSec3.Value = clsAppMarbleVars.varApp.WarmUpSawTimeSec3;
    this.spn_LubricationBlockOnOffTimeSec.Value = clsAppMarbleVars.varApp.LubricationBlockOnOffTimeSec;
    this.spn_LubricationLevelOnOffTimeSec.Value = clsAppMarbleVars.varApp.LubricationLevelOnOffTimeSec;
    this.spn_LubricationPeriodWaitMin.Value = clsAppMarbleVars.varApp.LubricationPeriodWaitMin;
    this.spn_LubricationTimeSec.Value = clsAppMarbleVars.varApp.LubricationTimeSec;
    this.chk_LubricationEnable.Check = clsAppMarbleVars.varApp.LubricationEnable;
    this.spn_parkpositionx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition;
    this.spn_parkpositionY.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition;
    this.spn_parkpositionZ.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition;
    this.spn_parkpositionA.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition;
    this.spn_parkpositionC.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition;
    this.spn_ParkPosTimeOutSec.Value = clsAppMarbleVars.varApp.ParkPosTimeOutSec;
    this.chk_ServoAAxis.Check = clsAppMarbleVars.varApp.OptionServoAxisA;
    this.spn_AAxisAllowedZSafePosition.Value = clsAppMarbleVars.varApp.AAxisAllowedZSafePosition;
    this.spn_AAxisTimeOutSec.Value = clsAppMarbleVars.varApp.AAxisTimeOutSec;
    this.spn_AAxisExtraTimeSec.Value = clsAppMarbleVars.varApp.AAxisExtraTimeSec;
    this.chk_BuzzerEnable.Check = clsAppMarbleVars.varApp.BuzzerEnable;
    this.spn_BuzzerTimeSec.Value = clsAppMarbleVars.varApp.BuzzerTimeSec;
    this.chk_GoZUpPositionWhenStart.Check = clsAppMarbleVars.varApp.GoZUpPositionWhenStart;
    this.spn_StartPointPosTimeOutSec.Value = clsAppMarbleVars.varApp.StartPointPosTimeOutSec;
    this.spn_LaserOnOffTimerSec.Value = clsAppMarbleVars.varApp.LaserOnOffTimerSec;
    this.spn_WaterOnOffTimerSec.Value = clsAppMarbleVars.varApp.WaterOnOffTimerSec;
    if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == (MarbleParkModeAfterJob) 1)
      ((F_MarbleCameraSettings) this).\u0002.Checked = true;
    else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == (MarbleParkModeAfterJob) 2)
      ((F_MarbleCameraSettings) this).\u0003.Checked = true;
    else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.Saw)
      ((F_MarbleCameraSettings) this).\u0001.Checked = true;
    this.spn_CameraPosTimeOutSec.Value = clsAppMarbleVars.varApp.CameraPosTimeOutSec;
    this.spn_CameraTableXOffsetPos.Value = clsAppMarbleVars.varApp.CameraTableXOffsetPos;
    this.spn_CameraTableYOffsetPos.Value = clsAppMarbleVars.varApp.CameraTableYOffsetPos;
    this.spn_CameraPositionA.Value = clsAppMarbleVars.varApp.CameraPositionA;
    this.spn_CameraPositionC.Value = clsAppMarbleVars.varApp.CameraPositionC;
    this.spn_CameraPositionX.Value = clsAppMarbleVars.varApp.CameraPositionX;
    this.spn_CameraPositionY.Value = clsAppMarbleVars.varApp.CameraPositionY;
    this.spn_CameraPositionZ.Value = clsAppMarbleVars.varApp.CameraPositionZ;
    this.spn_CameraAutoCloseTimeSec.Value = clsAppMarbleVars.varApp.CameraAutoCloseTimeSec;
    this.spn_CameraCoverOpenTimeSec.Value = clsAppMarbleVars.varApp.CameraCoverOpenTimeSec;
    this.spn_CameraEnableTimeSec.Value = clsAppMarbleVars.varApp.CameraEnableTimeSec;
    this.chk_CameraAutoCloseEnable.Check = clsAppMarbleVars.varApp.CameraAutoCloseEnable;
    this.chk_CameraCoverAutoCloseEnable.Check = clsAppMarbleVars.varApp.CameraCoverAutoCloseEnable;
    this.chk_CameraCoverAvailable.Check = clsAppMarbleVars.varApp.CameraCoverAvailable;
    this.chk_CameraPowerAvailable.Check = clsAppMarbleVars.varApp.CameraPowerAvailable;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    clsAppMarbleVars.varApp.SawMaxSpeed = this.spn_SawMaxSpeed.Value;
    clsAppMarbleVars.varApp.SawExtraG54OffsetX = this.spn_SawExtraG54OffsetX.Value;
    clsAppMarbleVars.varApp.SawExtraG54OffsetY = this.spn_SawExtraG54OffsetY.Value;
    clsAppMarbleVars.varApp.SawExtraG54OffsetZ = this.spn_SawExtraG54OffsetZ.Value;
    clsAppMarbleVars.varApp.SawStartTimerSec = this.spn_SawStartTimerSec.Value;
    clsAppMarbleVars.varApp.SawStopTimerSec = this.spn_SawStopTimerSec.Value;
    clsAppMarbleVars.varApp.SawStartTimeoutSec = this.spn_SawStartTimeoutSec.Value;
    clsAppMarbleVars.varApp.SawStopTimeoutSec = this.spn_SawStopTimeoutSec.Value;
    clsAppMarbleVars.varApp.SawSpeedAtCheck = this.chk_SawSpeedAtCheck.Check;
    clsAppMarbleVars.varApp.SawSpeedAtCheck = this.chk_SawStopdAtCheck.Check;
    clsAppMarbleVars.varApp.MillingExtraG54OffsetX = this.spn_MillingExtraG54OffsetX.Value;
    clsAppMarbleVars.varApp.MillingExtraG54OffsetY = this.spn_MillingExtraG54OffsetY.Value;
    clsAppMarbleVars.varApp.MillingExtraG54OffsetZ = this.spn_MillingExtraG54OffsetZ.Value;
    clsAppMarbleVars.varApp.SpindleMaxSpeed = this.spn_SpindleMaxSpeed.Value;
    clsAppMarbleVars.varApp.SpindleStartTimerSec = this.spn_SpindleStartTimerSec.Value;
    clsAppMarbleVars.varApp.SpindleStopTimerSec = this.spn_SpindleStopTimerSec.Value;
    clsAppMarbleVars.varApp.SpindleStartTimeoutSec = this.spn_SpindleStartTimeoutSec.Value;
    clsAppMarbleVars.varApp.SpindleStopTimeoutSec = this.spn_SpindleStopTimeoutSec.Value;
    clsAppMarbleVars.varApp.SpindleUpTimeSec = this.spn_SpindleUpTimeSec.Value;
    clsAppMarbleVars.varApp.SpindleDownTimeSec = this.spn_SpindleDownTimeSec.Value;
    clsAppMarbleVars.varApp.SpindleUpTimeOutSec = this.spn_SpindleUpTimeOutSec.Value;
    clsAppMarbleVars.varApp.SpindleDownTimeOutSec = this.spn_SpindleDownTimeOutSec.Value;
    clsAppMarbleVars.varApp.SpindleCoolAfterStopTimeSec = this.spn_SpindleCoolAfterStopTimeSec.Value;
    clsAppMarbleVars.varApp.SpindleSpeedAtCheck = this.chk_SpindleSpeedAtCheck.Check;
    clsAppMarbleVars.varApp.SpindleStopdAtCheck = this.chk_SpindleStopdAtCheck.Check;
    clsAppMarbleVars.varApp.SpindleCoolAfterStop = this.chk_SpindleCoolAfterStop.Check;
    clsAppMarbleVars.varApp.SpindlePersentageFromPLC = this.chk_SpindlePersentageFromPLC.Check;
    clsAppMarbleVars.varApp.SpindlePersentageSinglePot = this.chk_SpindlePersentageSinglePot.Check;
    clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetX = this.spn_MillingHeadExtraG54OffsetX.Value;
    clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetY = this.spn_MillingHeadExtraG54OffsetY.Value;
    clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetZ = this.spn_MillingHeadExtraG54OffsetZ.Value;
    clsAppMarbleVars.varApp.ToolChangePositionA = this.spn_ToolChangePositionA.Value;
    clsAppMarbleVars.varApp.ToolChangePositionC = this.spn_ToolChangePositionC.Value;
    clsAppMarbleVars.varApp.ToolChangeXSafeDistance = this.spn_ToolChangeXSafeDistance.Value;
    clsAppMarbleVars.varApp.ToolChangeYSafeDistance = this.spn_ToolChangeYSafeDistance.Value;
    clsAppMarbleVars.varApp.ToolChangeSafePositionZ = this.spn_ToolChangeSafePositionZ.Value;
    clsAppMarbleVars.varApp.ToolChangeUpPositionZ = this.spn_ToolChangeUpPositionZ.Value;
    clsAppMarbleVars.varApp.ToolChangeBeforePositionX = this.spn_ToolChangeBeforePositionX.Value;
    clsAppMarbleVars.varApp.ToolChangeSlowVelocity = this.spn_ToolChangeSlowVelocity.Value;
    clsAppMarbleVars.varApp.ToolChangeFastVelocity = this.spn_ToolChangeFastVelocity.Value;
    clsAppMarbleVars.varApp.ToolChangeLeaveVelocity = this.spn_ToolChangeLeaveVelocity.Value;
    clsAppMarbleVars.varApp.ToolChangeTakeVelocity = this.spn_ToolChangeTakeVelocity.Value;
    clsAppMarbleVars.varApp.ToolMillingClampOpenTimeSec = this.spn_ToolMillingClampOpenTimeSec.Value;
    clsAppMarbleVars.varApp.ToolMillingClampCloseTimeSec = this.spn_ToolMillingClampCloseTimeSec.Value;
    clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.X = ((F_MarbleCameraSettings) this).spn_ToolchangeX1.Value;
    clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.Y = ((F_MarbleCameraSettings) this).spn_ToolchangeY1.Value;
    clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.Z = ((F_MarbleCameraSettings) this).spn_ToolchangeZ1.Value;
    clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.X = ((F_MarbleCameraSettings) this).spn_ToolchangeX2.Value;
    clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.Y = ((F_MarbleCameraSettings) this).spn_ToolchangeY2.Value;
    clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.Z = ((F_MarbleCameraSettings) this).spn_ToolchangeZ2.Value;
    clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.X = ((F_MarbleCameraSettings) this).spn_ToolchangeX3.Value;
    clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.Y = ((F_MarbleCameraSettings) this).spn_ToolchangeY3.Value;
    clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.Z = ((F_MarbleCameraSettings) this).spn_ToolchangeZ3.Value;
    clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.X = this.spn_ToolchangeX4.Value;
    clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.Y = this.spn_ToolchangeY4.Value;
    clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.Z = this.spn_ToolchangeZ4.Value;
    clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.X = this.spn_ToolchangeX5.Value;
    clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.Y = this.spn_ToolchangeY5.Value;
    clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.Z = this.spn_ToolchangeZ5.Value;
    clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.X = this.spn_ToolchangeX6.Value;
    clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.Y = this.spn_ToolchangeY6.Value;
    clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.Z = this.spn_ToolchangeZ6.Value;
    clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.X = this.spn_ToolchangeX7.Value;
    clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.Y = this.spn_ToolchangeY7.Value;
    clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.Z = this.spn_ToolchangeZ7.Value;
    clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.X = this.spn_ToolchangeX8.Value;
    clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.Y = this.spn_ToolchangeY8.Value;
    clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.Z = this.spn_ToolchangeZ8.Value;
    clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.X = this.spn_ToolchangeX9.Value;
    clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.Y = this.spn_ToolchangeY9.Value;
    clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.Z = this.spn_ToolchangeZ9.Value;
    clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.X = this.spn_ToolchangeX10.Value;
    clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.Y = this.spn_ToolchangeY10.Value;
    clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.Z = this.spn_ToolchangeZ10.Value;
    clsAppMarbleVars.varApp.AtcOpenTimeSec = this.spn_ToolDoorOpenTimeSec.Value;
    clsAppMarbleVars.varApp.AtcCloseTimeSec = this.spn_ToolDoorCloseTimeSec.Value;
    clsAppMarbleVars.varApp.AtcForwardTimeSec = this.spn_ToolMagazineOpenTimeSec.Value;
    clsAppMarbleVars.varApp.AtcBackwardTimeSec = this.spn_ToolMagazineCloseTimeSec.Value;
    clsAppMarbleVars.varApp.AtcOpenTimeoutSec = this.spn_ToolDoorOpenTimeoutSec.Value;
    clsAppMarbleVars.varApp.AtcCloseTimeoutSec = this.spn_ToolDoorCloseTimeoutSec.Value;
    clsAppMarbleVars.varApp.AtcForwardTimeoutSec = this.spn_ToolMagazinOpenTimeoutSec.Value;
    clsAppMarbleVars.varApp.AtcBackwardTimeoutSec = this.spn_ToolMagazinCloseTimeoutSec.Value;
    clsAppMarbleVars.varApp.SawModePositionX = this.spn_SawModePositionX.Value;
    clsAppMarbleVars.varApp.SawModePositionY = this.spn_SawModePositionY.Value;
    clsAppMarbleVars.varApp.SawModePositionZ = this.spn_SawModePositionZ.Value;
    clsAppMarbleVars.varApp.SawModePositionA = this.spn_SawModePositionA.Value;
    clsAppMarbleVars.varApp.SawModePositionC = this.spn_SawModePositionC.Value;
    clsAppMarbleVars.varApp.SawModePosTimeOutSec = this.spn_SawModePosTimeOutSec.Value;
    clsAppMarbleVars.varApp.MillingModePositionX = this.spn_MillingModePositionX.Value;
    clsAppMarbleVars.varApp.MillingModePositionY = this.spn_MillingModePositionY.Value;
    clsAppMarbleVars.varApp.MillingModePositionZ = this.spn_MillingModePositionZ.Value;
    clsAppMarbleVars.varApp.MillingModePositionA = this.spn_MillingModePositionA.Value;
    clsAppMarbleVars.varApp.MillingModePositionC = this.spn_MillingModePositionC.Value;
    clsAppMarbleVars.varApp.MillingModePosTimeOutSec = this.spn_MillingModePosTimeOutSec.Value;
    clsAppMarbleVars.varApp.MillingHeadModePositionX = this.spn_MillingHeadModePositionX.Value;
    clsAppMarbleVars.varApp.MillingHeadModePositionY = this.spn_MillingHeadModePositionY.Value;
    clsAppMarbleVars.varApp.MillingHeadModePositionZ = this.spn_MillingHeadModePositionZ.Value;
    clsAppMarbleVars.varApp.MillingHeadModePositionA = this.spn_MillingHeadModePositionA.Value;
    clsAppMarbleVars.varApp.MillingHeadModePositionC = this.spn_MillingHeadModePositionC.Value;
    clsAppMarbleVars.varApp.MillingHeadModePosTimeOutSec = this.spn_MillingHeadModePosTimeOutSec.Value;
    clsAppMarbleVars.varApp.SawDiaMeasurePositionX = this.spn_SawDiaMeasurePositionX.Value;
    clsAppMarbleVars.varApp.SawDiaMeasurePositionY = this.spn_SawDiaMeasurePositionY.Value;
    clsAppMarbleVars.varApp.SawDiaMeasurePositionFastZ = this.spn_SawDiaMeasurePositionFastZ.Value;
    clsAppMarbleVars.varApp.SawDiaMeasurePositionLimitZ = this.spn_SawDiaMeasurePositionLimitZ.Value;
    clsAppMarbleVars.varApp.SawDiaMeasurePositionA = this.spn_SawDiaMeasurePositionA.Value;
    clsAppMarbleVars.varApp.SawDiaMeasurePositionC = this.spn_SawDiaMeasurePositionC.Value;
    clsAppMarbleVars.varApp.SawDiaMeasureConstant = this.spn_SawDiaMeasureConstant.Value;
    clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter = this.spn_SawDiaMeasureMinDaimeter.Value;
    clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter = this.spn_SawDiaMeasureMaxDaimeter.Value;
    clsAppMarbleVars.varApp.SawMeasureTimeOutSec = this.spn_SawMeasureTimeOutSec.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionX = this.spn_MillingLenMeasurePositionX.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionY = this.spn_MillingLenMeasurePositionY.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ = this.spn_MillingLenMeasurePositionFastZ.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionLimitZ = this.spn_MillingLenMeasurePositionLimitZ.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionA = this.spn_MillingLenMeasurePositionA.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionC = this.spn_MillingLenMeasurePositionC.Value;
    clsAppMarbleVars.varApp.MillingLenMeasureConstant = this.spn_MillingLenMeasureConstant.Value;
    clsAppMarbleVars.varApp.MillingLenMeasureMinLength = this.spn_MillingLenMeasureMinLength.Value;
    clsAppMarbleVars.varApp.MillingLenMeasureMaxLength = this.spn_MillingLenMeasureMaxLength.Value;
    clsAppMarbleVars.varApp.MillingMeasureTimeOutSec = this.spn_MillingMeasureTimeOutSec.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX = this.spn_MillingHeadLenMeasurePositionX.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY = this.spn_MillingHeadLenMeasurePositionY.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ = this.spn_MillingHeadLenMeasurePositionFastZ.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionLimitZ = this.spn_MillingHeadLenMeasurePositionLimitZ.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA = this.spn_MillingHeadLenMeasurePositionA.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC = this.spn_MillingHeadLenMeasurePositionC.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasureConstant = this.spn_MillingHeadLenMeasureConstant.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength = this.spn_MillingHeadLenMeasureMinLength.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength = this.spn_MillingHeadLenMeasureMaxLength.Value;
    clsAppMarbleVars.varApp.MillingHeadMeasureTimeOutSec = this.spn_MillingHeadMeasureTimeOutSec.Value;
    clsAppMarbleVars.varApp.ToolMeasureCoverOnTimeSec = this.spn_ToolMeasureCoverOnTimeSec.Value;
    clsAppMarbleVars.varApp.ToolMeasureCoverOffTimeSec = this.spn_ToolMeasureCoverOffTimeSec.Value;
    clsAppMarbleVars.varApp.ToolMeasureFastVelocity = this.spn_ToolMeasureFastVelocity.Value;
    clsAppMarbleVars.varApp.ToolMeasureLeaveSlowVelocity = this.spn_ToolMeasureSlowLeaveVelocity.Value;
    clsAppMarbleVars.varApp.ToolMeasureApproachSlowVelocity = this.spn_ToolMeasureSlowApproachVelocity.Value;
    clsAppMarbleVars.varApp.ToolMeasureAccDec = this.spn_ToolMeasureAccDec.Value;
    clsAppMarbleVars.varApp.ToolMeasureJerk = this.spn_ToolMeasureJerk.Value;
    clsAppMarbleVars.varApp.WagonUpPositionX = this.spn_wagonposX.Value;
    clsAppMarbleVars.varApp.WagonUpPositionY = this.spn_wagonposY.Value;
    clsAppMarbleVars.varApp.WagonUpPositionZ = this.spn_wagonposZ.Value;
    clsAppMarbleVars.varApp.WagonUpPositionA = this.spn_wagonposA.Value;
    clsAppMarbleVars.varApp.WagonUpPositionC = this.spn_wagonposC.Value;
    clsAppMarbleVars.varApp.WagonHidroStopSec = this.spn_wagonhidrostopsec.Value;
    clsAppMarbleVars.varApp.WagonPosTimeOutSec = this.spn_wagontimeout.Value;
    clsAppMarbleVars.varApp.VacuumBlowerTimeSec = this.spn_VacuumBlowerTimeSec.Value;
    clsAppMarbleVars.varApp.VacuumDownTimeOutSec = this.spn_VacuumDownTimeOutSec.Value;
    clsAppMarbleVars.varApp.VacuumDownTimeSec = this.spn_VacuumDownTimeSec.Value;
    clsAppMarbleVars.varApp.VacuumFastZPosition = this.spn_VacuumFastZPosition.Value;
    clsAppMarbleVars.varApp.VacuumInTimeoutSec = this.spn_VacuumInTimeoutSec.Value;
    clsAppMarbleVars.varApp.VacuumOffTimeOutSec = this.spn_VacuumOffTimeOutSec.Value;
    clsAppMarbleVars.varApp.VacuumOnTimeOutSec = this.spn_VacuumOnTimeOutSec.Value;
    clsAppMarbleVars.varApp.VacuumOutTimeoutSec = this.spn_VacuumOutTimeoutSec.Value;
    clsAppMarbleVars.varApp.VacuumUpTimeOutSec = this.spn_VacuumUpTimeOutSec.Value;
    clsAppMarbleVars.varApp.VacuumUpTimeSec = this.spn_VacuumUpTimeSec.Value;
    clsAppMarbleVars.varApp.MaterialMeasureAccDec = this.spn_MaterialMeasureAccDec.Value;
    clsAppMarbleVars.varApp.MaterialMeasureConstant = this.spn_MaterialMeasureConstant.Value;
    clsAppMarbleVars.varApp.MaterialMeasureFastVelocity = this.spn_MaterialMeasureFastVelocity.Value;
    clsAppMarbleVars.varApp.MaterialMeasureJerk = this.spn_MaterialMeasureJerk.Value;
    clsAppMarbleVars.varApp.MaterialMeasureMaxThickness = this.spn_MaterialMeasureMaxThickness.Value;
    clsAppMarbleVars.varApp.MaterialMeasureMinThickness = this.spn_MaterialMeasureMinThickness.Value;
    clsAppMarbleVars.varApp.MaterialMeasurePositionA = this.spn_MaterialMeasurePositionA.Value;
    clsAppMarbleVars.varApp.MaterialMeasurePositionC = this.spn_MaterialMeasurePositionC.Value;
    clsAppMarbleVars.varApp.MaterialMeasurePositionFastZ = this.spn_MaterialMeasurePositionFastZ.Value;
    clsAppMarbleVars.varApp.MaterialMeasurePositionLimitZ = this.spn_MaterialMeasurePositionLimitZ.Value;
    clsAppMarbleVars.varApp.MaterialMeasureSlowVelocity = this.spn_MaterialMeasureSlowVelocity.Value;
    clsAppMarbleVars.varApp.MaterialMeasureUpTimeOutSec = this.spn_MaterialMeasureUpTimeOutSec.Value;
    clsAppMarbleVars.varApp.MaterialMeasureG54OffsetX = ((F_MarbleCameraSettings) this).spn_MaterialMeasureG54OffsetX.Value;
    clsAppMarbleVars.varApp.MaterialMeasureG54OffsetY = ((F_MarbleCameraSettings) this).spn_MaterialMeasureG54OffsetY.Value;
    clsAppMarbleVars.varApp.MaterialMeasureMaxSawDiameter = ((F_MarbleCameraSettings) this).spn_MaterialMeasureMaxSawDiameter.Value;
    clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset = ((F_MarbleCameraSettings) this).spn_MaterialMeasureXBorderOffset.Value;
    clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset = ((F_MarbleCameraSettings) this).spn_MaterialMeasureYBorderOffset.Value;
    clsAppMarbleVars.varApp.WarmUpMillingSpeed1 = this.spn_WarmUpMillingSpeed1.Value;
    clsAppMarbleVars.varApp.WarmUpMillingSpeed2 = this.spn_WarmUpMillingSpeed2.Value;
    clsAppMarbleVars.varApp.WarmUpMillingSpeed3 = this.spn_WarmUpMillingSpeed3.Value;
    clsAppMarbleVars.varApp.WarmUpMillingTimeSec1 = this.spn_WarmUpMillingTimeSec1.Value;
    clsAppMarbleVars.varApp.WarmUpMillingTimeSec2 = this.spn_WarmUpMillingTimeSec2.Value;
    clsAppMarbleVars.varApp.WarmUpMillingTimeSec3 = this.spn_WarmUpMillingTimeSec3.Value;
    clsAppMarbleVars.varApp.WarmUpSawSpeed1 = this.spn_WarmUpSawSpeed1.Value;
    clsAppMarbleVars.varApp.WarmUpSawSpeed2 = this.spn_WarmUpSawSpeed2.Value;
    clsAppMarbleVars.varApp.WarmUpSawSpeed3 = this.spn_WarmUpSawSpeed3.Value;
    clsAppMarbleVars.varApp.WarmUpSawTimeSec1 = this.spn_WarmUpSawTimeSec1.Value;
    clsAppMarbleVars.varApp.WarmUpSawTimeSec2 = this.spn_WarmUpSawTimeSec2.Value;
    clsAppMarbleVars.varApp.WarmUpSawTimeSec3 = this.spn_WarmUpSawTimeSec3.Value;
    clsAppMarbleVars.varApp.LubricationBlockOnOffTimeSec = this.spn_LubricationBlockOnOffTimeSec.Value;
    clsAppMarbleVars.varApp.LubricationLevelOnOffTimeSec = this.spn_LubricationLevelOnOffTimeSec.Value;
    clsAppMarbleVars.varApp.LubricationPeriodWaitMin = this.spn_LubricationPeriodWaitMin.Value;
    clsAppMarbleVars.varApp.LubricationTimeSec = this.spn_LubricationTimeSec.Value;
    clsAppMarbleVars.varApp.LubricationEnable = this.chk_LubricationEnable.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition = this.spn_parkpositionx.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition = this.spn_parkpositionY.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition = this.spn_parkpositionZ.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition = this.spn_parkpositionA.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition = this.spn_parkpositionC.Value;
    clsAppMarbleVars.varApp.ParkPosTimeOutSec = this.spn_ParkPosTimeOutSec.Value;
    clsAppMarbleVars.varApp.OptionServoAxisA = this.chk_ServoAAxis.Check;
    clsAppMarbleVars.varApp.AAxisAllowedZSafePosition = this.spn_AAxisAllowedZSafePosition.Value;
    clsAppMarbleVars.varApp.AAxisTimeOutSec = this.spn_AAxisTimeOutSec.Value;
    clsAppMarbleVars.varApp.AAxisExtraTimeSec = this.spn_AAxisExtraTimeSec.Value;
    clsAppMarbleVars.varApp.BuzzerEnable = this.chk_BuzzerEnable.Check;
    clsAppMarbleVars.varApp.BuzzerTimeSec = this.spn_BuzzerTimeSec.Value;
    clsAppMarbleVars.varApp.GoZUpPositionWhenStart = this.chk_GoZUpPositionWhenStart.Check;
    clsAppMarbleVars.varApp.StartPointPosTimeOutSec = this.spn_StartPointPosTimeOutSec.Value;
    clsAppMarbleVars.varApp.LaserOnOffTimerSec = this.spn_LaserOnOffTimerSec.Value;
    clsAppMarbleVars.varApp.WaterOnOffTimerSec = this.spn_WaterOnOffTimerSec.Value;
    clsAppMarbleVars.varApp.ParkPositionAfterFinishType = !((F_MarbleCameraSettings) this).\u0002.Checked ? (!((F_MarbleCameraSettings) this).\u0001.Checked ? (MarbleParkModeAfterJob) 2 : MarbleParkModeAfterJob.Saw) : (MarbleParkModeAfterJob) 1;
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
    clsAppMarbleVars.varApp.CameraPowerAvailable = this.chk_CameraPowerAvailable.Check;
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.buGround1.Controls);
    if (PageIndex == 0)
    {
      this.btn_saw.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_saw.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_milling.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_milling.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      this.btn_millinghead.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_millinghead.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 3)
    {
      this.btn_toolchange.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_toolchange.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 4)
    {
      this.btn_toolmeasure.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_toolmeasure.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 5)
    {
      this.btn_troller.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_troller.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 6)
    {
      this.btn_camera.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_camera.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 7)
    {
      this.btn_vacuum.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_vacuum.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 8)
    {
      this.btn_materialmeasure.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_materialmeasure.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 9)
    {
      this.btn_warmup.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_warmup.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 10)
    {
      this.btn_lubrication.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_lubrication.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 11)
    {
      this.btn_park.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_park.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 12)
    {
      this.btn_axisA.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_axisA.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 13)
      return;
    this.btn_misc.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_misc.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  public void MenuButtonColorsSaw(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.tabPage_saw.Controls);
    if (PageIndex == 0)
    {
      this.btn_sawdata.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_sawdata.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_sawpark.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_sawpark.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 2)
      return;
    this.btn_sawmeasure.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_sawmeasure.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  public void MenuButtonColorsMilling(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.tabPage_milling.Controls);
    if (PageIndex == 0)
    {
      this.btn_millingdata.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_millingdata.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_millingpark.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_millingpark.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 2)
      return;
    this.btn_millingmeasure.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_millingmeasure.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  public void MenuButtonColorsMillingHead(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.\u0001.Controls);
    if (PageIndex == 0)
    {
      this.btn_millingheaddata.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_millingheaddata.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_millingheadpark.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_millingheadpark.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 2)
      return;
    this.btn_millingheadmeasure.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_millingheadmeasure.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }
}
