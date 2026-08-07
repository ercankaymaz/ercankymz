// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleCameraSettings
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleCameraSettings : Form
{
  public buSpin spn_ToolchangeX3;
  public buSpin spn_ToolchangeY3;
  public buSpin spn_ToolchangeZ3;
  internal buLabel \u001F;
  public buSpin spn_ToolchangeX2;
  public buSpin spn_ToolchangeY2;
  public buSpin spn_ToolchangeZ2;
  internal buLabel \u007F;
  internal buLabel \u0080;
  internal buLabel \u0081;
  internal buLabel \u0082;
  public buSpin spn_ToolchangeX1;
  public buSpin spn_ToolchangeY1;
  public buSpin spn_ToolchangeZ1;
  public buButton btn_toolchangepositions;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal buLabel \u0083;
  public buSpin spn_MaterialMeasureG54OffsetX;
  public buSpin spn_MaterialMeasureMaxSawDiameter;
  public buSpin spn_MaterialMeasureG54OffsetY;
  public buSpin spn_MaterialMeasureYBorderOffset;
  public buSpin spn_MaterialMeasureXBorderOffset;
  public buButton btn_stop;
  public static byte f000B19;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal PictureBox \u0001;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  public buCheckBox chk_CameraPowerAvailable;
  public buTab buTab_tools;
  public TabPage tabPage_motion;
  public TabPage tabPage_progra;
  public buButton btn_Programsettings;
  public buButton btn_motionSetting;

  public void MenuButtonColorsToolChange(int PageIndex)
  {
    hmiUICommands.SetVisualItem(((F_MarbleMachineSettingsV1) this).\u0002.Controls);
    if (PageIndex == 0)
    {
      ((F_MarbleMachineSettingsV1) this).btn_toolchangedata.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleMachineSettingsV1) this).btn_toolchangedata.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      ((F_MarbleMachineSettingsV1) this).btn_toolchangetimes.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleMachineSettingsV1) this).btn_toolchangetimes.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 2)
      return;
    this.btn_toolchangepositions.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_toolchangepositions.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == this.btn_stop.Name && clsAppMarbleVars.cmdMarble != null)
        clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 2);
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_ok.Name)
      {
        ((F_MarbleMachineSettingsV1) this).Apply();
        ((F_MarbleMachineSettingsV1) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleMachineSettingsV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMachineSettingsV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_close.Name | control2.Name == ((F_MarbleMachineSettingsV1) this).btn_cancel.Name)
      {
        ((F_MarbleMachineSettingsV1) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleMachineSettingsV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMachineSettingsV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_saw.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 0;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(0);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_sawdata.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_saw.SelectedIndex = 0;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsSaw(0);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_sawpark.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_saw.SelectedIndex = 1;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsSaw(1);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_sawmeasure.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_saw.SelectedIndex = 2;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsSaw(2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_milling.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 1;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(1);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingdata.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_milling.SelectedIndex = 0;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsMilling(0);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingpark.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_milling.SelectedIndex = 1;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsMilling(1);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingmeasure.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_milling.SelectedIndex = 2;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsMilling(2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millinghead.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 2;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingheaddata.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_millinghead.SelectedIndex = 0;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsMillingHead(0);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingheadpark.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_millinghead.SelectedIndex = 1;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsMillingHead(1);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingheadmeasure.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_millinghead.SelectedIndex = 2;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColorsMillingHead(2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_toolchange.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 3;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(3);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_toolchangedata.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_toolchange.SelectedIndex = 0;
        this.MenuButtonColorsToolChange(0);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_toolchangetimes.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_toolchange.SelectedIndex = 1;
        this.MenuButtonColorsToolChange(1);
      }
      if (control2.Name == this.btn_toolchangepositions.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_toolchange.SelectedIndex = 2;
        this.MenuButtonColorsToolChange(2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_toolmeasure.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 4;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(4);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_troller.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 5;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(6);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_camera.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 6;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(6);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_vacuum.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 7;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(7);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_materialmeasure.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 8;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(8);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_warmup.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 9;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(9);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_lubrication.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 10;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(10);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_park.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 11;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(11);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_axisA.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 12;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(12);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_misc.Name)
      {
        ((F_MarbleMachineSettingsV1) this).buTab_Main.SelectedIndex = 13;
        ((F_MarbleMachineSettingsV1) this).MenuButtonColors(13);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_sawmeasurecalculate.Name)
      {
        double Val = 0.0;
        clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, "AppRun.SawDiaCalcZPosition", ref Val);
        ((F_MarbleMachineSettingsV1) this).spn_SawDiaMeasureConstant.Value = ((F_MarbleMachineSettingsV1) this).spn_SawDiaMeasurecalcDiameter.Value / 2.0 - Val;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_sawmeasureshowcalc.Name)
      {
        if (!((F_MarbleMachineSettingsV1) this).\u0001.Visible)
          ((F_MarbleMachineSettingsV1) this).\u0001.Visible = true;
        else
          ((F_MarbleMachineSettingsV1) this).\u0001.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingmeasurecalc.Name)
      {
        double Val = 0.0;
        clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MillingLenCalcZPosition", ref Val);
        ((F_MarbleMachineSettingsV1) this).spn_MillingLenMeasureConstant.Value = ((F_MarbleMachineSettingsV1) this).spn_millingmeasurecalc.Value - Val;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingmeasurecalcshow.Name)
      {
        if (!((F_MarbleMachineSettingsV1) this).\u0002.Visible)
          ((F_MarbleMachineSettingsV1) this).\u0002.Visible = true;
        else
          ((F_MarbleMachineSettingsV1) this).\u0002.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingheadmeasurecalc.Name)
      {
        double Val = 0.0;
        clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MillingHeadLenCalcZPosition", ref Val);
        ((F_MarbleMachineSettingsV1) this).spn_MillingHeadLenMeasureConstant.Value = ((F_MarbleMachineSettingsV1) this).spn_millingheadmeasurecalcLEn.Value - Val;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingheadmeasurecalcshow.Name)
      {
        if (!((F_MarbleMachineSettingsV1) this).\u0003.Visible)
          ((F_MarbleMachineSettingsV1) this).\u0003.Visible = true;
        else
          ((F_MarbleMachineSettingsV1) this).\u0003.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_MaterialMeasureCalc.Name)
      {
        double Val = 0.0;
        clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, "AppRun.MaterialCalcZPosition", ref Val);
        ((F_MarbleMachineSettingsV1) this).spn_MaterialMeasureConstant.Value = ((F_MarbleMachineSettingsV1) this).spn_MaterialMeasureCalcThickness.Value - Val;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_MaterialMeasureCalcShow.Name)
      {
        if (!((F_MarbleMachineSettingsV1) this).\u0004.Visible)
          ((F_MarbleMachineSettingsV1) this).\u0004.Visible = true;
        else
          ((F_MarbleMachineSettingsV1) this).\u0004.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_wagongetposition.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_wagonposX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_wagonposY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_wagonposZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_wagonposC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_wagonposA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_cameragetposition.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_CameraPositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_CameraPositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_CameraPositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_CameraPositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_CameraPositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_sawmeasuregetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawDiaMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawDiaMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawDiaMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawDiaMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawDiaMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_sawparkgetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_SawModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingmeasuregetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingLenMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingLenMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingLenMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingLenMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingLenMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingparkgetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingheadmeasuregetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingHeadLenMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingHeadLenMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingHeadLenMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingHeadLenMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineSettingsV1) this).spn_MillingHeadLenMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (!(control2.Name == ((F_MarbleMachineSettingsV1) this).btn_millingheadparkgetpos.Name) || !AppBool.Connected)
        return;
      if (clsAppMarbleVars.varRuntime.AxX >= 0)
        ((F_MarbleMachineSettingsV1) this).spn_MillingHeadModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxY >= 0)
        ((F_MarbleMachineSettingsV1) this).spn_MillingHeadModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxZ >= 0)
        ((F_MarbleMachineSettingsV1) this).spn_MillingHeadModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxC >= 0)
        ((F_MarbleMachineSettingsV1) this).spn_MillingHeadModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxA < 0)
        return;
      ((F_MarbleMachineSettingsV1) this).spn_MillingHeadModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMachineSettingsV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMachineSettingsV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCameraSettings() => F_MarbleMachineSettingsV1.Captions = new List<string>();

  public F_MarbleCameraSettings() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.buTab_tools.ItemSize = new Size(1, 1);
    this.tabPage_motion.Text = "";
    this.tabPage_progra.Text = "";
    ((F_MarbleStartOptions) this).spn_CameraPosTimeOutSec.Value = clsAppMarbleVars.varApp.CameraPosTimeOutSec;
    ((F_MarbleStartOptions) this).spn_CameraTableXOffsetPos.Value = clsAppMarbleVars.varApp.CameraTableXOffsetPos;
    ((F_MarbleStartOptions) this).spn_CameraTableYOffsetPos.Value = clsAppMarbleVars.varApp.CameraTableYOffsetPos;
    ((F_MarbleStartOptions) this).spn_CameraPositionA.Value = clsAppMarbleVars.varApp.CameraPositionA;
    ((F_MarbleStartOptions) this).spn_CameraPositionC.Value = clsAppMarbleVars.varApp.CameraPositionC;
    ((F_MarbleStartOptions) this).spn_CameraPositionX.Value = clsAppMarbleVars.varApp.CameraPositionX;
    ((F_MarbleStartOptions) this).spn_CameraPositionY.Value = clsAppMarbleVars.varApp.CameraPositionY;
    ((F_MarbleStartOptions) this).spn_CameraPositionZ.Value = clsAppMarbleVars.varApp.CameraPositionZ;
    ((F_MarbleStartOptions) this).spn_CameraAutoCloseTimeSec.Value = clsAppMarbleVars.varApp.CameraAutoCloseTimeSec;
    ((F_MarbleStartOptions) this).spn_CameraCoverOpenTimeSec.Value = clsAppMarbleVars.varApp.CameraCoverOpenTimeSec;
    ((F_MarbleStartOptions) this).spn_CameraEnableTimeSec.Value = clsAppMarbleVars.varApp.CameraEnableTimeSec;
    ((F_MarbleStartOptions) this).chk_CameraAutoCloseEnable.Check = clsAppMarbleVars.varApp.CameraAutoCloseEnable;
    ((F_MarbleStartOptions) this).chk_CameraCoverAutoCloseEnable.Check = clsAppMarbleVars.varApp.CameraCoverAutoCloseEnable;
    ((F_MarbleStartOptions) this).chk_CameraCoverAvailable.Check = clsAppMarbleVars.varApp.CameraCoverAvailable;
    this.chk_CameraPowerAvailable.Check = clsAppMarbleVars.varApp.CameraPowerAvailable;
    ((F_MarbleStartOptions) this).spn_cropx.Value = (double) buMarbleCalc.varMarbleSettings.CameraCropX;
    ((F_MarbleStartOptions) this).spn_cropy.Value = (double) buMarbleCalc.varMarbleSettings.CameraCropY;
    ((F_MarbleStartOptions) this).spn_cropWidth.Value = (double) buMarbleCalc.varMarbleSettings.CameraCropWidth;
    ((F_MarbleStartOptions) this).spn_cropHeight.Value = (double) buMarbleCalc.varMarbleSettings.CameraCropHeight;
    ((F_MarbleToolTypes) this).spn_imagewidth.Value = buMarbleCalc.varMarbleSettings.CameraImageWidth;
    ((F_MarbleToolTypes) this).spn_imageheight.Value = buMarbleCalc.varMarbleSettings.CameraImageHeight;
    ((F_MarbleToolTypes) this).spn_imageoffsetX.Value = buMarbleCalc.varMarbleSettings.CameraImageOffsetX;
    ((F_MarbleToolTypes) this).spn_imageoffsety.Value = buMarbleCalc.varMarbleSettings.CameraImageOffsetY;
    ((F_MarbleStartOptions) this).spn_cameraexposure.Value = (double) buMarbleCalc.varMarbleSettings.CameraExposure;
    ((F_MarbleToolTypes) this).chk_sameimagetoArchive.Check = buMarbleCalc.varMarbleSettings.CopyImageToArchive;
    ((F_MarbleToolTypes) this).chk_autolenscalibrationfromslabthickness.Check = buMarbleCalc.varMarbleSettings.AutoLensCalibrationFromMaterialHeight;
    \u0005.\u0003.\u0001(this);
    if (!this.PropertiesForm.VisualUpdated)
      this.InitVisual();
    ((F_MarbleStartOptions) this).MenuButtonColors(0);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = hmiUICommands.SetVisualItem(this.buGround1.Controls);
      controlCollection = this.tabPage_motion.Controls;
      controlCollection = hmiUICommands.SetVisualItem(this.tabPage_motion.Controls);
      controlCollection = hmiUICommands.SetVisualItem(this.tabPage_progra.Controls);
    }
    this.PropertiesForm.VisualUpdated = true;
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
}
