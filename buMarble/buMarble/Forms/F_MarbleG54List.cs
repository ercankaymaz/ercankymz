// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleG54List
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buCadCamResVer5.Marble;
using buClass;
using buControls.Controls;
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

public class F_MarbleG54List : Form
{
  public buCheckBox chk_SpindleSpeedAtCheck;
  public buSpin spn_SpindleStartTimerSec;
  public buSpin spn_SpindleStopTimerSec;
  public buSpin spn_SpindleMaxSpeed;
  public buCheckBox chk_hardlimita;
  public buCheckBox chk_hardlimitz;
  public buCheckBox chk_hardlimity;
  public buCheckBox chk_hardlimitx;
  public buCheckBox chk_hardlimitc;
  public buButton btn_jog;
  public buButton btn_stop;
  public buButton btn_millingheadmeasurego;
  public buButton btn_sawmeasurego;
  public buButton btn_millingmeasurego;
  public buButton btn_wagongo;
  public buButton btn_camerago;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex == 0)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0 & clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setUnit = ((F_MarbleMachineInstall) this).spn_calibx_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setPulse = ((F_MarbleMachineInstall) this).spn_calibx_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setGearRatio = ((F_MarbleMachineInstall) this).spn_calibx_gear.Value;
        }
        if (clsAppMarbleVars.varRuntime.AxY >= 0 & clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit = ((F_MarbleMachineInstall) this).spn_caliby_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setPulse = ((F_MarbleMachineInstall) this).spn_caliby_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setGearRatio = ((F_MarbleMachineInstall) this).spn_caliby_gear.Value;
          if (clsAppMarbleVars.varRuntime.AxY2 >= 0 & clsAppMarbleVars.varRuntime.AxY2 <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
            clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = !(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit > 0.0 & clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit > 0.0) ? (!(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit < 0.0 & clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit < 0.0) ? -clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit : clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit) : clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
        }
        if (clsAppMarbleVars.varRuntime.AxZ >= 0 & clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setUnit = ((F_MarbleMachineInstall) this).spn_calibz_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setPulse = ((F_MarbleMachineInstall) this).spn_calibz_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setGearRatio = ((F_MarbleMachineInstall) this).spn_calibz_gear.Value;
        }
        if (clsAppMarbleVars.varRuntime.AxA >= 0 & clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = ((F_MarbleMachineInstall) this).spn_caliba_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = ((F_MarbleMachineInstall) this).spn_caliba_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = ((F_MarbleMachineInstall) this).spn_caliba_gear.Value;
        }
        if (clsAppMarbleVars.varRuntime.AxC >= 0 & clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        {
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit = ((F_MarbleMachineInstall) this).spn_calibc_unit.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse = ((F_MarbleMachineInstall) this).spn_calibc_pulse.Value;
          clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio = ((F_MarbleMachineInstall) this).spn_calibc_gear.Value;
        }
        clsAppMarbleVars.varInterface.MachineInstallationAxesCalib = true;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
      }
      if (((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex == 1)
      {
        clsMarble.activeKinematic.RotateCenterOffsetOfC.Y = ((F_MarbleMachineInstall) this).spn_kinematicCDistance.Value;
        clsMarble.activeKinematic.RotateCenterOffsetOfA.Y = ((F_MarbleMachineInstall) this).spn_kinematicAYDistance.Value;
        clsMarble.activeKinematic.RotateCenterOffsetOfA.Z = ((F_MarbleMachineInstall) this).spn_kinematicAZDistance.Value;
        clsAppMarbleVars.varInterface.MachineInstallationKinematic = true;
      }
      if (((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex == 2)
      {
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogVelocity = ((F_MarbleMachineInstall) this).spn_speedJogXSpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogAcc = ((F_MarbleMachineInstall) this).spn_speedJogXAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogDec = ((F_MarbleMachineInstall) this).spn_speedJogXAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogJerk = ((F_MarbleMachineInstall) this).spn_speedJogXjerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedPersentage = ((F_MarbleMachineInstall) this).spn_speedJogX2SpeedPerc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedTimeSec = ((F_MarbleMachineInstall) this).spn_speedJogX2SpeedTime.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveVelocity = ((F_MarbleMachineInstall) this).spn_speedMoveXSpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveAcc = ((F_MarbleMachineInstall) this).spn_speedMoveXAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveDec = ((F_MarbleMachineInstall) this).spn_speedMoveXAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveJerk = ((F_MarbleMachineInstall) this).spn_speedMoveXJerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogVelocity = ((F_MarbleMachineInstall) this).spn_speedJogYSpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogAcc = ((F_MarbleMachineInstall) this).spn_speedJogYAccDEc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogDec = ((F_MarbleMachineInstall) this).spn_speedJogYAccDEc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogJerk = ((F_MarbleMachineInstall) this).spn_speedJogYJerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedPersentage = ((F_MarbleMachineInstall) this).spn_speedJogY2SpeedPerc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedTimeSec = ((F_MarbleMachineInstall) this).spn_speedJogY2SpeedTime.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveVelocity = ((F_MarbleMachineInstall) this).spn_speedMoveYSpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveAcc = ((F_MarbleMachineInstall) this).spn_speedMoveYAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveDec = ((F_MarbleMachineInstall) this).spn_speedMoveYAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveJerk = ((F_MarbleMachineInstall) this).spn_speedMoveYJerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogVelocity = ((F_MarbleMachineInstall) this).spn_speedJogZSpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogAcc = ((F_MarbleMachineInstall) this).spn_speedJogZAccDEc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogDec = ((F_MarbleMachineInstall) this).spn_speedJogZAccDEc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogJerk = ((F_MarbleMachineInstall) this).spn_speedJogZJerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedPersentage = ((F_MarbleMachineInstall) this).spn_speedJogZ2SpeedPerc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedTimeSec = ((F_MarbleMachineInstall) this).spn_speedJogZ2SpeedTime.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveVelocity = ((F_MarbleMachineInstall) this).spn_speedMoveZSpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveAcc = ((F_MarbleMachineInstall) this).spn_speedMoveZAccDEc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveDec = ((F_MarbleMachineInstall) this).spn_speedMoveZAccDEc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveJerk = ((F_MarbleMachineInstall) this).spn_speedMoveZJerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = ((F_MarbleMachineInstall) this).spn_caliba_unit.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = ((F_MarbleMachineInstall) this).spn_caliba_pulse.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = ((F_MarbleMachineInstall) this).spn_caliba_gear.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogVelocity = ((F_MarbleMachineInstall) this).spn_speedJogASpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogAcc = ((F_MarbleMachineInstall) this).spn_speedJogAAccDEc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogDec = ((F_MarbleMachineInstall) this).spn_speedJogAAccDEc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogJerk = ((F_MarbleMachineInstall) this).spn_speedJogAJerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedPersentage = ((F_MarbleMachineInstall) this).spn_speedJogA2SpeedPerc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedTimeSec = ((F_MarbleMachineInstall) this).spn_speedJogA2SpeedTime.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveVelocity = ((F_MarbleMachineInstall) this).spn_speedMoveASpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveAcc = ((F_MarbleMachineInstall) this).spn_speedMoveAAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveDec = ((F_MarbleMachineInstall) this).spn_speedMoveAAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveJerk = ((F_MarbleMachineInstall) this).spn_speedMoveAJerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogVelocity = ((F_MarbleMachineInstall) this).spn_speedJogCSpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogAcc = ((F_MarbleMachineInstall) this).spn_speedJogCAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogDec = ((F_MarbleMachineInstall) this).spn_speedJogCAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogJerk = ((F_MarbleMachineInstall) this).spn_speedJogCJerk.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedPersentage = ((F_MarbleMachineInstall) this).spn_speedJogC2SpeedPerc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedTimeSec = ((F_MarbleMachineInstall) this).spn_speedJogC2SpeedTime.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveVelocity = ((F_MarbleMachineInstall) this).spn_speedMoveCSpeed.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveAcc = ((F_MarbleMachineInstall) this).spn_speedMoveCAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveDec = ((F_MarbleMachineInstall) this).spn_speedMoveCAccDec.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveJerk = ((F_MarbleMachineInstall) this).spn_speedMoveCJerk.Value;
        clsAppMarbleVars.cMachine.varCNC.setG0Acc = ((F_MarbleMachineInstall) this).spn_cncG0AccDec.Value;
        clsAppMarbleVars.cMachine.varCNC.setG0Dec = ((F_MarbleMachineInstall) this).spn_cncG0AccDec.Value;
        clsAppMarbleVars.cMachine.varCNC.setG1Acc = ((F_MarbleMachineInstall) this).spn_cncG1AccDec.Value;
        clsAppMarbleVars.cMachine.varCNC.setG1Dec = ((F_MarbleMachineInstall) this).spn_cncG1AccDec.Value;
        clsAppMarbleVars.cMachine.varCNC.setMaxJerk = ((F_MarbleMachineInstall) this).spn_cncJerk.Value;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
        clsAppMarbleVars.varInterface.MachineInstallationSpeeds = true;
      }
      if (((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex == 3)
      {
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitPositive = ((F_MarbleMachineInstall) this).spn_softlimitposx.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitNegative = ((F_MarbleMachineInstall) this).spn_softlimitnegx.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitPositive = ((F_MarbleMachineInstall) this).spn_datalimitposx.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitNegative = ((F_MarbleMachineInstall) this).spn_datalimitnegx.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineInstall) this).chk_softlimitx.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineInstall) this).chk_joglimitx.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimitx.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitPositive = ((F_MarbleMachineInstall) this).spn_softlimitposy.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitNegative = ((F_MarbleMachineInstall) this).spn_softlimitnegy.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitPositive = ((F_MarbleMachineInstall) this).spn_datalimitposy.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitNegative = ((F_MarbleMachineInstall) this).spn_datalimitnegy.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineInstall) this).chk_softlimity.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineInstall) this).chk_joglimity.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimity.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitPositive = ((F_MarbleMachineInstall) this).spn_softlimitposz.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitNegative = ((F_MarbleMachineInstall) this).spn_softlimitnegz.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitPositive = ((F_MarbleMachineInstall) this).spn_datalimitposz.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitNegative = ((F_MarbleMachineInstall) this).spn_datalimitnegz.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineInstall) this).chk_softlimitz.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineInstall) this).chk_joglimitz.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimitz.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitPositive = ((F_MarbleMachineInstall) this).spn_softlimitposa.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitNegative = ((F_MarbleMachineInstall) this).spn_softlimitnega.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitPositive = ((F_MarbleMachineInstall) this).spn_datalimitposa.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitNegative = ((F_MarbleMachineInstall) this).spn_datalimitnega.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineInstall) this).chk_softlimita.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineInstall) this).chk_joglimita.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimita.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitPositive = ((F_MarbleMachineInstall) this).spn_softlimitposc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitNegative = ((F_MarbleMachineInstall) this).spn_softlimitnegc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitPositive = ((F_MarbleMachineInstall) this).spn_datalimitposc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitNegative = ((F_MarbleMachineInstall) this).spn_datalimitnegc.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = ((F_MarbleMachineInstall) this).chk_softlimitc.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = ((F_MarbleMachineInstall) this).chk_joglimitc.Check;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimitc.Check;
        clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
        clsAppMarbleVars.varInterface.MachineInstallationLimits = true;
      }
      if (((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex == 4)
      {
        clsAppMarbleVars.varApp.SawModePositionX = ((F_MarbleMachineInstall) this).spn_SawModePositionX.Value;
        clsAppMarbleVars.varApp.SawModePositionY = ((F_MarbleMachineInstall) this).spn_SawModePositionY.Value;
        clsAppMarbleVars.varApp.SawModePositionZ = ((F_MarbleMachineInstall) this).spn_SawModePositionZ.Value;
        clsAppMarbleVars.varApp.SawModePositionA = ((F_MarbleMachineInstall) this).spn_SawModePositionA.Value;
        clsAppMarbleVars.varApp.SawModePositionC = ((F_MarbleMachineInstall) this).spn_SawModePositionC.Value;
        clsAppMarbleVars.varApp.MillingModePositionX = ((F_MarbleMachineInstall) this).spn_MillingModePositionX.Value;
        clsAppMarbleVars.varApp.MillingModePositionY = ((F_MarbleMachineInstall) this).spn_MillingModePositionY.Value;
        clsAppMarbleVars.varApp.MillingModePositionZ = ((F_MarbleMachineInstall) this).spn_MillingModePositionZ.Value;
        clsAppMarbleVars.varApp.MillingModePositionA = ((F_MarbleMachineInstall) this).spn_MillingModePositionA.Value;
        clsAppMarbleVars.varApp.MillingModePositionC = ((F_MarbleMachineInstall) this).spn_MillingModePositionC.Value;
        clsAppMarbleVars.varApp.MillingHeadModePositionX = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionX.Value;
        clsAppMarbleVars.varApp.MillingHeadModePositionY = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionY.Value;
        clsAppMarbleVars.varApp.MillingHeadModePositionZ = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionZ.Value;
        clsAppMarbleVars.varApp.MillingHeadModePositionA = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionA.Value;
        clsAppMarbleVars.varApp.MillingHeadModePositionC = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionC.Value;
        clsAppMarbleVars.varApp.SawDiaMeasurePositionX = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionX.Value;
        clsAppMarbleVars.varApp.SawDiaMeasurePositionY = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionY.Value;
        clsAppMarbleVars.varApp.SawDiaMeasurePositionFastZ = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionFastZ.Value;
        clsAppMarbleVars.varApp.SawDiaMeasurePositionA = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionA.Value;
        clsAppMarbleVars.varApp.SawDiaMeasurePositionC = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionC.Value;
        clsAppMarbleVars.varApp.MillingLenMeasurePositionX = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionX.Value;
        clsAppMarbleVars.varApp.MillingLenMeasurePositionY = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionY.Value;
        clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionFastZ.Value;
        clsAppMarbleVars.varApp.MillingLenMeasurePositionA = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionA.Value;
        clsAppMarbleVars.varApp.MillingLenMeasurePositionC = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionC.Value;
        clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionX.Value;
        clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionY.Value;
        clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionFastZ.Value;
        clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionA.Value;
        clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionC.Value;
        clsAppMarbleVars.varApp.WagonUpPositionX = ((F_MarbleMachineInstall) this).spn_wagonposX.Value;
        clsAppMarbleVars.varApp.WagonUpPositionY = ((F_MarbleMachineInstall) this).spn_wagonposY.Value;
        clsAppMarbleVars.varApp.WagonUpPositionZ = ((F_MarbleMachineInstall) this).spn_wagonposZ.Value;
        clsAppMarbleVars.varApp.WagonUpPositionA = ((F_MarbleMachineInstall) this).spn_wagonposA.Value;
        clsAppMarbleVars.varApp.WagonUpPositionC = ((F_MarbleMachineInstall) this).spn_wagonposC.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition = ((F_MarbleMachineInstall) this).spn_generalparkx.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition = ((F_MarbleMachineInstall) this).spn_generalparky.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition = ((F_MarbleMachineInstall) this).spn_generalparkz.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition = ((F_MarbleMachineInstall) this).spn_generalparka.Value;
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition = ((F_MarbleMachineInstall) this).spn_generalparkc.Value;
        clsAppMarbleVars.varInterface.MachineInstallationPositions = true;
      }
      if (((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex != 5)
        return;
      clsAppMarbleVars.varApp.SawMaxSpeed = ((F_MarbleMachineInstall) this).spn_SawMaxSpeed.Value;
      clsAppMarbleVars.varApp.SawStartTimerSec = ((F_MarbleMachineInstall) this).spn_SawStartTimerSec.Value;
      clsAppMarbleVars.varApp.SawStopTimerSec = ((F_MarbleMachineInstall) this).spn_SawStopTimerSec.Value;
      clsAppMarbleVars.varApp.SawSpeedAtCheck = ((F_MarbleMachineInstall) this).chk_SawSpeedAtCheck.Check;
      clsAppMarbleVars.varApp.SawSpeedAtCheck = ((F_MarbleMachineInstall) this).chk_SawStopdAtCheck.Check;
      clsAppMarbleVars.varApp.SpindleMaxSpeed = this.spn_SpindleMaxSpeed.Value;
      clsAppMarbleVars.varApp.SpindleStartTimerSec = this.spn_SpindleStartTimerSec.Value;
      clsAppMarbleVars.varApp.SpindleStopTimerSec = this.spn_SpindleStopTimerSec.Value;
      clsAppMarbleVars.varApp.SpindleCoolAfterStopTimeSec = ((F_MarbleMachineInstall) this).spn_SpindleCoolAfterStopTimeSec.Value;
      clsAppMarbleVars.varApp.SpindleSpeedAtCheck = this.chk_SpindleSpeedAtCheck.Check;
      clsAppMarbleVars.varApp.SpindleStopdAtCheck = ((F_MarbleMachineInstall) this).chk_SpindleStopdAtCheck.Check;
      clsAppMarbleVars.varApp.SpindleCoolAfterStop = ((F_MarbleMachineInstall) this).chk_SpindleCoolAfterStop.Check;
      clsAppMarbleVars.varApp.SpindlePersentageFromPLC = ((F_MarbleMachineInstall) this).chk_SpindlePersentageFromPLC.Check;
      clsAppMarbleVars.varApp.SpindlePersentageSinglePot = ((F_MarbleMachineInstall) this).chk_SpindlePersentageSinglePot.Check;
      clsAppMarbleVars.varInterface.MachineInstallationSpindle = true;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == this.btn_stop.Name && clsAppMarbleVars.cmdMarble != null)
        clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 2);
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_ok.Name)
      {
        ((F_MarbleMachineInstall) this).Apply();
        ((F_MarbleMachineInstall) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleMachineInstall) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMachineInstall) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_close.Name | control2.Name == ((F_MarbleMachineInstall) this).btn_cancel.Name)
      {
        ((F_MarbleMachineInstall) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleMachineInstall) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMachineInstall) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == this.btn_jog.Name && clsAppMarbleItems.frmJogPageV1 != null)
      {
        clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmJogPageV1.Init();
        int num = (int) clsAppMarbleItems.frmJogPageV1.ShowDialog();
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_main.Name)
      {
        ((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex = 0;
        ((F_MarbleMachineInstall) this).MenuButtonColors(0);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_manuel.Name)
      {
        ((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex = 1;
        ((F_MarbleMachineInstall) this).MenuButtonColors(1);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_horizontal.Name)
      {
        ((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex = 2;
        ((F_MarbleMachineInstall) this).MenuButtonColors(2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_vertical.Name)
      {
        ((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex = 3;
        ((F_MarbleMachineInstall) this).MenuButtonColors(3);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_positions.Name)
      {
        ((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex = 4;
        ((F_MarbleMachineInstall) this).MenuButtonColors(4);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_spindles.Name)
      {
        ((F_MarbleMachineInstall) this).buTab_Main.SelectedIndex = 5;
        ((F_MarbleMachineInstall) this).MenuButtonColors(5);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_generalparkgetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_generalparkx.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_generalparky.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_generalparkz.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_generalparkc.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_generalparka.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_wagongetposition.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_wagonposX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_wagonposY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_wagonposZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_wagonposC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_wagonposA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_cameragetposition.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_CameraPositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_CameraPositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_CameraPositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_CameraPositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_CameraPositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_sawmeasuregetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_sawparkgetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_SawModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_SawModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_SawModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_SawModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_SawModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_millingmeasuregetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_millingparkgetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_millingheadmeasuregetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionFastZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleMachineInstall) this).btn_millingheadparkgetpos.Name && AppBool.Connected)
      {
        if (clsAppMarbleVars.varRuntime.AxX >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxY >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxZ >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxC >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
        if (clsAppMarbleVars.varRuntime.AxA >= 0)
          ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
      }
      if (control2.Name == ((F_MarbleToolListTab) this).btn_generalparkgo.Name && AppBool.Connected)
      {
        double XPos = ((F_MarbleMachineInstall) this).spn_generalparkx.Value;
        double YPos = ((F_MarbleMachineInstall) this).spn_generalparky.Value;
        double ZPos = ((F_MarbleMachineInstall) this).spn_generalparkz.Value;
        double CPos = ((F_MarbleMachineInstall) this).spn_generalparkc.Value;
        double APos = ((F_MarbleMachineInstall) this).spn_generalparka.Value;
        clsAppMarbleVars.cmdMarble.GoPosition(XPos, YPos, ZPos, CPos, APos, 500, 500, 10);
      }
      if (control2.Name == this.btn_wagongo.Name && AppBool.Connected)
      {
        double XPos = ((F_MarbleMachineInstall) this).spn_wagonposX.Value;
        double YPos = ((F_MarbleMachineInstall) this).spn_wagonposY.Value;
        double ZPos = ((F_MarbleMachineInstall) this).spn_wagonposZ.Value;
        double CPos = ((F_MarbleMachineInstall) this).spn_wagonposC.Value;
        double APos = ((F_MarbleMachineInstall) this).spn_wagonposA.Value;
        clsAppMarbleVars.cmdMarble.GoPosition(XPos, YPos, ZPos, CPos, APos, 500, 500, 10);
      }
      if (control2.Name == this.btn_camerago.Name && AppBool.Connected)
      {
        double XPos = ((F_MarbleMachineInstall) this).spn_CameraPositionX.Value;
        double YPos = ((F_MarbleMachineInstall) this).spn_CameraPositionY.Value;
        double ZPos = ((F_MarbleMachineInstall) this).spn_CameraPositionZ.Value;
        double CPos = ((F_MarbleMachineInstall) this).spn_CameraPositionC.Value;
        double APos = ((F_MarbleMachineInstall) this).spn_CameraPositionA.Value;
        clsAppMarbleVars.cmdMarble.GoPosition(XPos, YPos, ZPos, CPos, APos, 500, 500, 10);
      }
      if (control2.Name == this.btn_sawmeasurego.Name && AppBool.Connected)
      {
        double XPos = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionX.Value;
        double YPos = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionY.Value;
        double ZPos = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionFastZ.Value;
        double CPos = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionC.Value;
        double APos = ((F_MarbleMachineInstall) this).spn_SawDiaMeasurePositionA.Value;
        clsAppMarbleVars.cmdMarble.GoPosition(XPos, YPos, ZPos, CPos, APos, 500, 500, 10);
      }
      if (control2.Name == ((F_MarbleToolListTab) this).btn_sawparkgo.Name && AppBool.Connected)
      {
        double XPos = ((F_MarbleMachineInstall) this).spn_SawModePositionX.Value;
        double YPos = ((F_MarbleMachineInstall) this).spn_SawModePositionY.Value;
        double ZPos = ((F_MarbleMachineInstall) this).spn_SawModePositionZ.Value;
        double CPos = ((F_MarbleMachineInstall) this).spn_SawModePositionC.Value;
        double APos = ((F_MarbleMachineInstall) this).spn_SawModePositionA.Value;
        clsAppMarbleVars.cmdMarble.GoPosition(XPos, YPos, ZPos, CPos, APos, 500, 500, 10);
      }
      if (control2.Name == this.btn_millingmeasurego.Name && AppBool.Connected)
      {
        double XPos = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionX.Value;
        double YPos = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionX.Value;
        double ZPos = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionFastZ.Value;
        double CPos = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionC.Value;
        double APos = ((F_MarbleMachineInstall) this).spn_MillingLenMeasurePositionA.Value;
        clsAppMarbleVars.cmdMarble.GoPosition(XPos, YPos, ZPos, CPos, APos, 500, 500, 10);
      }
      if (control2.Name == ((F_MarbleToolListTab) this).btn_millingparkgo.Name && AppBool.Connected)
      {
        double XPos = ((F_MarbleMachineInstall) this).spn_MillingModePositionX.Value;
        double YPos = ((F_MarbleMachineInstall) this).spn_MillingModePositionY.Value;
        double ZPos = ((F_MarbleMachineInstall) this).spn_MillingModePositionZ.Value;
        double CPos = ((F_MarbleMachineInstall) this).spn_MillingModePositionC.Value;
        double APos = ((F_MarbleMachineInstall) this).spn_MillingModePositionA.Value;
        clsAppMarbleVars.cmdMarble.GoPosition(XPos, YPos, ZPos, CPos, APos, 500, 500, 10);
      }
      if (control2.Name == this.btn_millingheadmeasurego.Name && AppBool.Connected)
      {
        double XPos = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionX.Value;
        double YPos = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionY.Value;
        double ZPos = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionFastZ.Value;
        double CPos = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionC.Value;
        double APos = ((F_MarbleMachineInstall) this).spn_MillingHeadLenMeasurePositionA.Value;
        clsAppMarbleVars.cmdMarble.GoPosition(XPos, YPos, ZPos, CPos, APos, 500, 500, 10);
      }
      if (!(control2.Name == ((F_MarbleToolListTab) this).btn_millingheadparkgo.Name) || !AppBool.Connected)
        return;
      double XPos1 = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionX.Value;
      double YPos1 = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionY.Value;
      double ZPos1 = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionZ.Value;
      double CPos1 = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionC.Value;
      double APos1 = ((F_MarbleMachineInstall) this).spn_MillingHeadModePositionA.Value;
      clsAppMarbleVars.cmdMarble.GoPosition(XPos1, YPos1, ZPos1, CPos1, APos1, 500, 500, 10);
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
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
    if ((!disposing ? 0 : (((F_MarbleMachineInstall) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMachineInstall) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleG54List() => F_MarbleMachineInstall.Captions = new List<string>();

  public F_MarbleG54List()
  {
    ((F_MarbleToolListTab) this).PropertiesForm = new FormProperties();
    ((F_MarbleToolListTab) this).G54s = new List<Pnt9DS>();
    ((F_MarbleToolListTab) this).indexG54 = -1;
    ((F_MarbleToolListTab) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0005.\u0003.\u0001(this);
  }

  public void Init()
  {
    ((F_MarbleToolListTab) this).PropertiesForm.Inited = false;
    if (((F_MarbleToolListTab) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleToolListTab) this).PropertiesForm.Height;
    if (((F_MarbleToolListTab) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleToolListTab) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleToolListTab) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleToolListTab) this).PropertiesForm.FormPosition;
    if (((F_MarbleToolListTab) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 35;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.Number;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolListTab) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 60;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Image;
      dataGridViewColumn2.Name = "Image";
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolListTab) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 90;
      dataGridViewColumn3.HeaderText = buLangTranslate.preChar.X;
      dataGridViewColumn3.Name = "X";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolListTab) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 90;
      dataGridViewColumn4.HeaderText = buLangTranslate.preChar.Y;
      dataGridViewColumn4.Name = "Y";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolListTab) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 90;
      dataGridViewColumn5.HeaderText = buLangTranslate.preChar.Z;
      dataGridViewColumn5.Name = "Z";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolListTab) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 90;
      dataGridViewColumn6.HeaderText = buLangTranslate.preChar.C;
      dataGridViewColumn6.Name = "C";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolListTab) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 90;
      dataGridViewColumn7.HeaderText = buLangTranslate.preChar.A;
      dataGridViewColumn7.Name = "A";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolListTab) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 240 /*0xF0*/;
      dataGridViewColumn8.HeaderText = buLangTranslate.preDef.Explanation;
      dataGridViewColumn8.Name = "Name";
      dataGridViewColumn8.ReadOnly = false;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn8.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleToolListTab) this).\u0001.Columns.Add(dataGridViewColumn8);
      ((F_MarbleToolListTab) this).\u0001.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
    }
    ((F_MarbleToolListTab) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleToolListTab) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleToolListTab) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleToolListTab) this).\u0001.ColumnHeadersVisible = true;
    ((F_MarbleToolListTab) this).FillG54();
    ((F_MarbleToolListTab) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleToolListTab) this).PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolListTab) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleToolListTab) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolListTab) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolListTab) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    for (int index = 0; index <= ((F_MarbleToolListTab) this).G54s.Count - 1; ++index)
    {
      ((F_MarbleToolListTab) this).G54s[index].X = double.Parse(((F_MarbleToolListTab) this).\u0001.Rows[index].Cells[2].Value.ToString());
      ((F_MarbleToolListTab) this).G54s[index].Y = double.Parse(((F_MarbleToolListTab) this).\u0001.Rows[index].Cells[3].Value.ToString());
      ((F_MarbleToolListTab) this).G54s[index].Z = double.Parse(((F_MarbleToolListTab) this).\u0001.Rows[index].Cells[4].Value.ToString());
      ((F_MarbleToolListTab) this).G54s[index].C = double.Parse(((F_MarbleToolListTab) this).\u0001.Rows[index].Cells[5].Value.ToString());
      ((F_MarbleToolListTab) this).G54s[index].A = double.Parse(((F_MarbleToolListTab) this).\u0001.Rows[index].Cells[6].Value.ToString());
      ((F_MarbleToolListTab) this).G54s[index].S = ((F_MarbleToolListTab) this).\u0001.Rows[index].Cells[7].Value.ToString();
    }
  }
}
