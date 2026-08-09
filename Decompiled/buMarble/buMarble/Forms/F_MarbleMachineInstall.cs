using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using _0005;
using buCadCamResVer5;
using buCadCamResVer5.Marble;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;

namespace buMarble.Forms;

public class F_MarbleMachineInstall : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer m__0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_vertical;

	public buButton btn_horizontal;

	public buButton btn_manuel;

	public buButton btn_main;

	public buTab buTab_Main;

	public TabPage tabPage_mainpage;

	public TabPage tabPage_horizontal;

	public TabPage tabPage_vertical;

	internal TabPage _0001;

	internal buLabel _0001;

	internal buLabel _0002;

	internal buLabel _0003;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal PictureBox _0001;

	internal buLabel _0004;

	internal buLabel _0005;

	internal buLabel _0006;

	public buButton btn_calibx;

	public buSpin spn_calibx_measuredeval;

	public buSpin spn_calibx_moveval;

	internal buLabel _0007;

	internal buLabel _0008;

	internal buLabel _000E;

	internal buLabel _000F;

	internal buLabel _0010;

	internal buLabel _0011;

	public buSpin spn_calibx_gear;

	public buSpin spn_calibx_unit;

	public buSpin spn_calibx_pulse;

	public buSpin spn_calibc_pulse;

	public buSpin spn_calibc_gear;

	public buSpin spn_calibc_unit;

	public buButton btn_calibc;

	public buSpin spn_calibc_measuredeval;

	public buSpin spn_calibc_moveval;

	public buSpin spn_caliba_pulse;

	public buSpin spn_caliba_gear;

	public buSpin spn_caliba_unit;

	public buButton btn_caliba;

	public buSpin spn_caliba_measuredeval;

	public buSpin spn_caliba_moveval;

	public buSpin spn_calibz_pulse;

	public buSpin spn_calibz_gear;

	public buSpin spn_calibz_unit;

	public buButton btn_calibz;

	public buSpin spn_calibz_measuredeval;

	public buSpin spn_calibz_moveval;

	public buSpin spn_caliby_pulse;

	public buSpin spn_caliby_gear;

	public buSpin spn_caliby_unit;

	public buButton btn_caliby;

	public buSpin spn_caliby_measuredeval;

	public buSpin spn_caliby_moveval;

	public buSpin spn_kinematicsawdiameter;

	public buSpin spn_kinematicmaterialthickness;

	public buSpin spn_kinematicCDistance;

	internal buLabel _0012;

	public buButton btn_kinematicccalculate;

	public buSpin spn_kinematicCMeasuredHeight;

	public buSpin spn_kinematicCMeasuredWidth;

	public buSpin spn_kinematicrectheight;

	public buSpin spn_kinematicrectwidth;

	public buSpin spn_kinematicsawthickness;

	public buSpin spn_kinematicoperationZ;

	public buButton btn_kinematiccodecreate;

	public buSpin spn_kinematicrectang;

	public buSpin spn_kinematicAZDistance;

	public buSpin spn_kinematicAMeasuredTargetZ;

	public buSpin spn_kinematicAYDistance;

	internal buLabel _0013;

	public buButton btn_kinematicAcalculate;

	public buSpin spn_kinematicAMeasuredHeight;

	public buSpin spn_kinematicAMeasuredWidth;

	public buButton btn_apply;

	public buSpin spn_speedMoveXSpeed;

	public buSpin spn_speedMoveXJerk;

	public buSpin spn_speedMoveXAccDec;

	public buSpin spn_speedJogXSpeed;

	public buSpin spn_speedJogXjerk;

	public buSpin spn_speedJogXAccDec;

	internal buLabel _0014;

	internal buLabel _0015;

	internal buLabel _0016;

	internal buLabel _0017;

	internal buLabel _0018;

	public buSpin spn_speedMoveCSpeed;

	public buSpin spn_speedMoveCJerk;

	public buSpin spn_speedMoveCAccDec;

	public buSpin spn_speedJogCSpeed;

	public buSpin spn_speedJogCJerk;

	public buSpin spn_speedJogCAccDec;

	public buSpin spn_speedMoveASpeed;

	public buSpin spn_speedMoveAJerk;

	public buSpin spn_speedMoveAAccDec;

	public buSpin spn_speedJogASpeed;

	public buSpin spn_speedJogAJerk;

	public buSpin spn_speedJogAAccDEc;

	public buSpin spn_speedMoveZSpeed;

	public buSpin spn_speedMoveZJerk;

	public buSpin spn_speedMoveZAccDEc;

	public buSpin spn_speedJogZSpeed;

	public buSpin spn_speedJogZJerk;

	public buSpin spn_speedJogZAccDEc;

	public buSpin spn_speedMoveYSpeed;

	public buSpin spn_speedMoveYJerk;

	public buSpin spn_speedMoveYAccDec;

	public buSpin spn_speedJogYSpeed;

	public buSpin spn_speedJogYJerk;

	public buSpin spn_speedJogYAccDEc;

	public buSpin spn_cncG1AccDec;

	public buSpin spn_cncG0AccDec;

	internal buLabel _0019;

	public buSpin spn_cncJerk;

	public buSpin spn_softlimitnegx;

	public buSpin spn_softlimitposx;

	internal buLabel _001A;

	public buButton btn_limitenablex;

	public buCheckBox chk_joglimitx;

	public buSpin spn_datalimitnegx;

	public buSpin spn_datalimitposx;

	public buCheckBox chk_softlimitx;

	internal buLabel _001B;

	internal buLabel _001C;

	internal buLabel _001D;

	public buButton btn_limitdisablex;

	internal buLabel _001E;

	public buButton btn_limitdisabley;

	public buButton btn_limitenabley;

	public buCheckBox chk_joglimity;

	public buSpin spn_datalimitnegy;

	public buSpin spn_datalimitposy;

	public buCheckBox chk_softlimity;

	public buSpin spn_softlimitnegy;

	public buSpin spn_softlimitposy;

	internal buSeparator _0001;

	internal buSeparator _0002;

	internal buSeparator _0003;

	internal buSeparator _0004;

	public buButton btn_limitdisablec;

	public buButton btn_limitenablec;

	public buCheckBox chk_joglimitc;

	public buSpin spn_datalimitnegc;

	public buSpin spn_datalimitposc;

	public buCheckBox chk_softlimitc;

	public buSpin spn_softlimitnegc;

	public buSpin spn_softlimitposc;

	public buButton btn_limitdisablea;

	public buButton btn_limitenablea;

	public buCheckBox chk_joglimita;

	public buSpin spn_datalimitnega;

	public buSpin spn_datalimitposa;

	public buCheckBox chk_softlimita;

	public buSpin spn_softlimitnega;

	public buSpin spn_softlimitposa;

	public buButton btn_limitdisablez;

	public buButton btn_limitenablez;

	public buCheckBox chk_joglimitz;

	public buSpin spn_datalimitnegz;

	public buSpin spn_datalimitposz;

	public buCheckBox chk_softlimitz;

	public buSpin spn_softlimitnegz;

	public buSpin spn_softlimitposz;

	internal buSeparator _0005;

	internal buSeparator _0006;

	internal buSeparator _0007;

	internal buSeparator _0008;

	internal buSeparator _000E;

	internal buSeparator _000F;

	internal buSeparator _0010;

	internal buSeparator _0011;

	internal buSeparator _0012;

	public buButton btn_limitminusgetx;

	public buButton btn_limitplusgetX;

	public buButton btn_limitplusgetC;

	public buButton btn_limitminusgetC;

	public buButton btn_limitplusgetA;

	public buButton btn_limitminusgetA;

	public buButton btn_limitplusgetZ;

	public buButton btn_limitminusgetZ;

	public buButton btn_limitplusgetY;

	public buButton btn_limitminusgetY;

	public buSpin spn_speedJogX2SpeedTime;

	public buSpin spn_speedJogX2SpeedPerc;

	public buSpin spn_speedJogC2SpeedTime;

	public buSpin spn_speedJogC2SpeedPerc;

	public buSpin spn_speedJogA2SpeedTime;

	public buSpin spn_speedJogA2SpeedPerc;

	public buSpin spn_speedJogZ2SpeedTime;

	public buSpin spn_speedJogZ2SpeedPerc;

	public buSpin spn_speedJogY2SpeedTime;

	public buSpin spn_speedJogY2SpeedPerc;

	public buButton btn_positions;

	internal TabPage _0002;

	public buButton btn_sawparkgetpos;

	public buSpin spn_SawModePositionX;

	public buSpin spn_SawModePositionC;

	public buSpin spn_SawModePositionY;

	public buSpin spn_SawModePositionA;

	public buSpin spn_SawModePositionZ;

	internal buLabel _001F;

	internal buLabel _007F;

	internal buLabel _0080;

	internal buLabel _0081;

	internal buLabel _0082;

	internal buLabel _0083;

	public buButton btn_generalparkgetpos;

	public buSpin spn_generalparkx;

	public buSpin spn_generalparkc;

	public buSpin spn_generalparky;

	public buSpin spn_generalparka;

	public buSpin spn_generalparkz;

	internal buLabel _0084;

	public buSpin spn_MillingModePositionX;

	public buSpin spn_MillingModePositionC;

	public buSpin spn_MillingModePositionY;

	public buSpin spn_MillingModePositionZ;

	public buSpin spn_MillingModePositionA;

	public buSpin spn_MillingHeadModePositionX;

	public buSpin spn_MillingHeadModePositionC;

	public buSpin spn_MillingHeadModePositionY;

	public buSpin spn_MillingHeadModePositionA;

	public buSpin spn_MillingHeadModePositionZ;

	public buSpin spn_wagonposX;

	public buSpin spn_wagonposA;

	public buSpin spn_wagonposZ;

	public buSpin spn_wagonposC;

	public buSpin spn_wagonposY;

	public buSpin spn_CameraPositionA;

	public buSpin spn_CameraPositionC;

	public buSpin spn_CameraPositionX;

	public buSpin spn_CameraPositionZ;

	public buSpin spn_CameraPositionY;

	public buSpin spn_SawDiaMeasurePositionX;

	public buSpin spn_SawDiaMeasurePositionC;

	public buSpin spn_SawDiaMeasurePositionFastZ;

	public buSpin spn_SawDiaMeasurePositionA;

	public buSpin spn_SawDiaMeasurePositionY;

	public buSpin spn_MillingLenMeasurePositionX;

	public buSpin spn_MillingLenMeasurePositionC;

	public buSpin spn_MillingLenMeasurePositionFastZ;

	public buSpin spn_MillingLenMeasurePositionA;

	public buSpin spn_MillingLenMeasurePositionY;

	public buSpin spn_MillingHeadLenMeasurePositionX;

	public buSpin spn_MillingHeadLenMeasurePositionC;

	public buSpin spn_MillingHeadLenMeasurePositionFastZ;

	public buSpin spn_MillingHeadLenMeasurePositionA;

	public buSpin spn_MillingHeadLenMeasurePositionY;

	public buButton btn_millingheadmeasuregetpos;

	public buButton btn_sawmeasuregetpos;

	public buButton btn_millingmeasuregetpos;

	public buButton btn_wagongetposition;

	public buButton btn_cameragetposition;

	public buButton btn_millingparkgetpos;

	public buButton btn_millingheadparkgetpos;

	internal TabPage _0003;

	public buButton btn_spindles;

	public buCheckBox chk_SawStopdAtCheck;

	public buCheckBox chk_SawSpeedAtCheck;

	public buSpin spn_SawStartTimerSec;

	public buSpin spn_SawStopTimerSec;

	public buSpin spn_SawMaxSpeed;

	internal buLabel _0086;

	internal buLabel _0087;

	public buSpin spn_SpindleCoolAfterStopTimeSec;

	public buCheckBox chk_SpindlePersentageSinglePot;

	public buCheckBox chk_SpindlePersentageFromPLC;

	public buCheckBox chk_SpindleCoolAfterStop;

	public buCheckBox chk_SpindleStopdAtCheck;

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

	public buButton btn_millingparkgo;

	public buButton btn_millingheadparkgo;

	public buButton btn_generalparkgo;

	public buButton btn_sawparkgo;

	public F_MarbleMachineInstall()
	{
		global::_0005._0003._0001(this);
	}

	public void Init(int Index)
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			global::_008D._008F_0007(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		global::_009C._001A_0008(this, PropertiesForm.FormPosition);
		global::_008C._007E_0002_0007(buTab_Main, new Size(1, 1));
		if ((clsAppMarbleVars.varRuntime.AxX >= 0) & (clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
		{
			global::_0095._007E_0008_0008(spn_calibx_unit, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setUnit);
			global::_0095._007E_0008_0008(spn_calibx_pulse, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setPulse);
			global::_0095._007E_0008_0008(spn_calibx_gear, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setGearRatio);
			global::_0095._007E_0008_0008(spn_speedJogXSpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogVelocity);
			global::_0095._007E_0008_0008(spn_speedJogXAccDec, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogAcc);
			global::_0095._007E_0008_0008(spn_speedJogXjerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogJerk);
			global::_0095._007E_0008_0008(spn_speedMoveXSpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveVelocity);
			global::_0095._007E_0008_0008(spn_speedMoveXAccDec, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveAcc);
			global::_0095._007E_0008_0008(spn_speedMoveXJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveJerk);
			global::_0095._007E_0008_0008(spn_speedJogX2SpeedPerc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedPersentage);
			global::_0095._007E_0008_0008(spn_speedJogX2SpeedTime, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedTimeSec);
			global::_0095._007E_0008_0008(spn_softlimitposx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitPositive);
			global::_0095._007E_0008_0008(spn_softlimitnegx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitNegative);
			global::_0095._007E_0008_0008(spn_datalimitposx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitPositive);
			global::_0095._007E_0008_0008(spn_datalimitnegx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitNegative);
			global::_0082._007E_0089_0005(chk_softlimitx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable);
			global::_0082._007E_0089_0005(chk_joglimitx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove);
			global::_0082._007E_0089_0005(chk_hardlimitx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setHardLimitEnable);
		}
		if ((clsAppMarbleVars.varRuntime.AxY >= 0) & (clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
		{
			global::_0095._007E_0008_0008(spn_caliby_unit, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit);
			global::_0095._007E_0008_0008(spn_caliby_pulse, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setPulse);
			global::_0095._007E_0008_0008(spn_caliby_gear, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setGearRatio);
			global::_0095._007E_0008_0008(spn_speedJogYSpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogVelocity);
			global::_0095._007E_0008_0008(spn_speedJogYAccDEc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogAcc);
			global::_0095._007E_0008_0008(spn_speedJogYJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogJerk);
			global::_0095._007E_0008_0008(spn_speedMoveYSpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveVelocity);
			global::_0095._007E_0008_0008(spn_speedMoveYAccDec, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveAcc);
			global::_0095._007E_0008_0008(spn_speedMoveYJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveJerk);
			global::_0095._007E_0008_0008(spn_speedJogY2SpeedPerc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedPersentage);
			global::_0095._007E_0008_0008(spn_speedJogY2SpeedTime, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedTimeSec);
			global::_0095._007E_0008_0008(spn_softlimitposy, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitPositive);
			global::_0095._007E_0008_0008(spn_softlimitnegy, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitNegative);
			global::_0095._007E_0008_0008(spn_datalimitposy, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitPositive);
			global::_0095._007E_0008_0008(spn_datalimitnegy, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitNegative);
			global::_0082._007E_0089_0005(chk_softlimity, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable);
			global::_0082._007E_0089_0005(chk_joglimity, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove);
			global::_0082._007E_0089_0005(chk_hardlimity, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setHardLimitEnable);
		}
		if ((clsAppMarbleVars.varRuntime.AxZ >= 0) & (clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
		{
			global::_0095._007E_0008_0008(spn_calibz_unit, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setUnit);
			global::_0095._007E_0008_0008(spn_calibz_pulse, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setPulse);
			global::_0095._007E_0008_0008(spn_calibz_gear, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setGearRatio);
			global::_0095._007E_0008_0008(spn_speedJogZSpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogVelocity);
			global::_0095._007E_0008_0008(spn_speedJogZAccDEc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogAcc);
			global::_0095._007E_0008_0008(spn_speedJogZJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogJerk);
			global::_0095._007E_0008_0008(spn_speedMoveZSpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveVelocity);
			global::_0095._007E_0008_0008(spn_speedMoveZAccDEc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveAcc);
			global::_0095._007E_0008_0008(spn_speedMoveZJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveJerk);
			global::_0095._007E_0008_0008(spn_speedJogZ2SpeedPerc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedPersentage);
			global::_0095._007E_0008_0008(spn_speedJogZ2SpeedTime, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedTimeSec);
			global::_0095._007E_0008_0008(spn_softlimitposz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitPositive);
			global::_0095._007E_0008_0008(spn_softlimitnegz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitNegative);
			global::_0095._007E_0008_0008(spn_datalimitposz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitPositive);
			global::_0095._007E_0008_0008(spn_datalimitnegz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitNegative);
			global::_0082._007E_0089_0005(chk_softlimitz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable);
			global::_0082._007E_0089_0005(chk_joglimitz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove);
			global::_0082._007E_0089_0005(chk_hardlimitz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setHardLimitEnable);
		}
		if ((clsAppMarbleVars.varRuntime.AxA >= 0) & (clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
		{
			global::_0095._007E_0008_0008(spn_caliba_unit, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit);
			global::_0095._007E_0008_0008(spn_caliba_pulse, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse);
			global::_0095._007E_0008_0008(spn_caliba_gear, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio);
			global::_0095._007E_0008_0008(spn_speedJogASpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogVelocity);
			global::_0095._007E_0008_0008(spn_speedJogAAccDEc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogAcc);
			global::_0095._007E_0008_0008(spn_speedJogAJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogJerk);
			global::_0095._007E_0008_0008(spn_speedMoveASpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveVelocity);
			global::_0095._007E_0008_0008(spn_speedMoveAAccDec, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveAcc);
			if (4 == 0)
			{
				goto IL_1b73;
			}
			global::_0095._007E_0008_0008(spn_speedMoveAJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveJerk);
			global::_0095._007E_0008_0008(spn_speedJogA2SpeedPerc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedPersentage);
			global::_0095._007E_0008_0008(spn_speedJogA2SpeedTime, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedTimeSec);
			global::_0095._007E_0008_0008(spn_softlimitposa, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitPositive);
			global::_0095._007E_0008_0008(spn_softlimitnega, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitNegative);
			global::_0095._007E_0008_0008(spn_datalimitposa, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitPositive);
			global::_0095._007E_0008_0008(spn_datalimitnega, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitNegative);
			global::_0082._007E_0089_0005(chk_softlimita, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable);
			global::_0082._007E_0089_0005(chk_joglimita, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove);
			global::_0082._007E_0089_0005(chk_hardlimita, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setHardLimitEnable);
		}
		if ((clsAppMarbleVars.varRuntime.AxC >= 0) & (clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
		{
			global::_0095._007E_0008_0008(spn_calibc_unit, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit);
			global::_0095._007E_0008_0008(spn_calibc_pulse, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse);
			global::_0095._007E_0008_0008(spn_calibc_gear, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio);
			global::_0095._007E_0008_0008(spn_speedJogCSpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogVelocity);
			global::_0095._007E_0008_0008(spn_speedJogCAccDec, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogAcc);
			global::_0095._007E_0008_0008(spn_speedJogCJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogJerk);
			global::_0095._007E_0008_0008(spn_speedMoveCSpeed, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveVelocity);
			global::_0095._007E_0008_0008(spn_speedMoveCAccDec, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveAcc);
			global::_0095._007E_0008_0008(spn_speedMoveCJerk, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveJerk);
			global::_0095._007E_0008_0008(spn_speedJogC2SpeedPerc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedPersentage);
			global::_0095._007E_0008_0008(spn_speedJogC2SpeedTime, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedTimeSec);
			global::_0095._007E_0008_0008(spn_softlimitposc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitPositive);
			global::_0095._007E_0008_0008(spn_softlimitnegc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitNegative);
			global::_0095._007E_0008_0008(spn_datalimitposc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitPositive);
			global::_0095._007E_0008_0008(spn_datalimitnegc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitNegative);
			global::_0082._007E_0089_0005(chk_softlimitc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable);
			global::_0082._007E_0089_0005(chk_joglimitc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove);
			global::_0082._007E_0089_0005(chk_hardlimitc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setHardLimitEnable);
		}
		global::_0095._007E_0008_0008(spn_cncG0AccDec, clsAppMarbleVars.cMachine.varCNC.setG0Acc);
		global::_0095._007E_0008_0008(spn_cncG1AccDec, clsAppMarbleVars.cMachine.varCNC.setG1Acc);
		global::_0095._007E_0008_0008(spn_cncJerk, clsAppMarbleVars.cMachine.varCNC.setMaxJerk);
		global::_0095._007E_0008_0008(spn_kinematicCDistance, clsMarble.activeKinematic.RotateCenterOffsetOfC.Y);
		global::_0095._007E_0008_0008(spn_kinematicAYDistance, clsMarble.activeKinematic.RotateCenterOffsetOfA.Y);
		global::_0095._007E_0008_0008(spn_kinematicAZDistance, clsMarble.activeKinematic.RotateCenterOffsetOfA.Z);
		global::_0095._007E_0008_0008(spn_kinematicmaterialthickness, clsAppMarbleVars.varInterface.KinCalcMatThickness);
		global::_0095._007E_0008_0008(spn_kinematicoperationZ, clsAppMarbleVars.varInterface.KinCalcOperationZ);
		global::_0095._007E_0008_0008(spn_kinematicrectang, clsAppMarbleVars.varInterface.KinCalcRectAngle);
		global::_0095._007E_0008_0008(spn_kinematicrectwidth, clsAppMarbleVars.varInterface.KinCalcRectWidth);
		global::_0095._007E_0008_0008(spn_kinematicrectheight, clsAppMarbleVars.varInterface.KinCalcRectHeight);
		global::_0095._007E_0008_0008(spn_kinematicsawdiameter, buMarbleCalc.activeToolSaw.Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_kinematicsawthickness, buMarbleCalc.activeToolSaw.Geometry.Thickness);
		global::_0095._007E_0008_0008(spn_SawModePositionX, clsAppMarbleVars.varApp.SawModePositionX);
		global::_0095._007E_0008_0008(spn_SawModePositionY, clsAppMarbleVars.varApp.SawModePositionY);
		global::_0095._007E_0008_0008(spn_SawModePositionZ, clsAppMarbleVars.varApp.SawModePositionZ);
		global::_0095._007E_0008_0008(spn_SawModePositionA, clsAppMarbleVars.varApp.SawModePositionA);
		global::_0095._007E_0008_0008(spn_SawModePositionC, clsAppMarbleVars.varApp.SawModePositionC);
		global::_0095._007E_0008_0008(spn_MillingModePositionX, clsAppMarbleVars.varApp.MillingModePositionX);
		global::_0095._007E_0008_0008(spn_MillingModePositionY, clsAppMarbleVars.varApp.MillingModePositionY);
		global::_0095._007E_0008_0008(spn_MillingModePositionZ, clsAppMarbleVars.varApp.MillingModePositionZ);
		global::_0095._007E_0008_0008(spn_MillingModePositionA, clsAppMarbleVars.varApp.MillingModePositionA);
		global::_0095._007E_0008_0008(spn_MillingModePositionC, clsAppMarbleVars.varApp.MillingModePositionC);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionX, clsAppMarbleVars.varApp.MillingHeadModePositionX);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionY, clsAppMarbleVars.varApp.MillingHeadModePositionY);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionZ, clsAppMarbleVars.varApp.MillingHeadModePositionZ);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionA, clsAppMarbleVars.varApp.MillingHeadModePositionA);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionC, clsAppMarbleVars.varApp.MillingHeadModePositionC);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionX, clsAppMarbleVars.varApp.SawDiaMeasurePositionX);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionY, clsAppMarbleVars.varApp.SawDiaMeasurePositionY);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionFastZ, clsAppMarbleVars.varApp.SawDiaMeasurePositionFastZ);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionA, clsAppMarbleVars.varApp.SawDiaMeasurePositionA);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionC, clsAppMarbleVars.varApp.SawDiaMeasurePositionC);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionX, clsAppMarbleVars.varApp.MillingLenMeasurePositionX);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionY, clsAppMarbleVars.varApp.MillingLenMeasurePositionY);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionFastZ, clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionA, clsAppMarbleVars.varApp.MillingLenMeasurePositionA);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionC, clsAppMarbleVars.varApp.MillingLenMeasurePositionC);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionX, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionY, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionFastZ, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionA, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionC, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC);
		global::_0095._007E_0008_0008(spn_wagonposX, clsAppMarbleVars.varApp.WagonUpPositionX);
		global::_0095._007E_0008_0008(spn_wagonposY, clsAppMarbleVars.varApp.WagonUpPositionY);
		global::_0095._007E_0008_0008(spn_wagonposZ, clsAppMarbleVars.varApp.WagonUpPositionZ);
		global::_0095._007E_0008_0008(spn_wagonposA, clsAppMarbleVars.varApp.WagonUpPositionA);
		global::_0095._007E_0008_0008(spn_wagonposC, clsAppMarbleVars.varApp.WagonUpPositionC);
		global::_0095._007E_0008_0008(spn_generalparkx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition);
		goto IL_1b73;
		IL_1b73:
		global::_0095._007E_0008_0008(spn_generalparky, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_generalparkz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_generalparka, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_generalparkc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_SawMaxSpeed, clsAppMarbleVars.varApp.SawMaxSpeed);
		global::_0095._007E_0008_0008(spn_SawStartTimerSec, clsAppMarbleVars.varApp.SawStartTimerSec);
		global::_0095._007E_0008_0008(spn_SawStopTimerSec, clsAppMarbleVars.varApp.SawStopTimerSec);
		global::_0082._007E_0089_0005(chk_SawSpeedAtCheck, clsAppMarbleVars.varApp.SawSpeedAtCheck);
		global::_0082._007E_0089_0005(chk_SawStopdAtCheck, clsAppMarbleVars.varApp.SawSpeedAtCheck);
		global::_0095._007E_0008_0008(spn_SpindleMaxSpeed, clsAppMarbleVars.varApp.SpindleMaxSpeed);
		global::_0095._007E_0008_0008(spn_SpindleStartTimerSec, clsAppMarbleVars.varApp.SpindleStartTimerSec);
		global::_0095._007E_0008_0008(spn_SpindleStopTimerSec, clsAppMarbleVars.varApp.SpindleStopTimerSec);
		global::_0095._007E_0008_0008(spn_SpindleCoolAfterStopTimeSec, clsAppMarbleVars.varApp.SpindleCoolAfterStopTimeSec);
		global::_0082._007E_0089_0005(chk_SpindleSpeedAtCheck, clsAppMarbleVars.varApp.SpindleSpeedAtCheck);
		global::_0082._007E_0089_0005(chk_SpindleStopdAtCheck, clsAppMarbleVars.varApp.SpindleStopdAtCheck);
		global::_0082._007E_0089_0005(chk_SpindleCoolAfterStop, clsAppMarbleVars.varApp.SpindleCoolAfterStop);
		global::_0082._007E_0089_0005(chk_SpindlePersentageFromPLC, clsAppMarbleVars.varApp.SpindlePersentageFromPLC);
		global::_0082._007E_0089_0005(chk_SpindlePersentageSinglePot, clsAppMarbleVars.varApp.SpindlePersentageSinglePot);
		MenuButtonColors(Index);
		global::_008D._007E_000F_0007(buTab_Main, Index);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0003._0001(this);
	}

	internal void _0001(object P_0, FormClosingEventArgs P_1)
	{
		while (true)
		{
			bool num = PropertiesForm.Result == DialogResult.OK;
			if (-1 == 0)
			{
				goto IL_0069;
			}
			bool num2 = !num;
			goto IL_00ab;
			IL_00ab:
			bool flag = num2;
			num = flag;
			if (0 == 0)
			{
				if (!num)
				{
					break;
				}
				if (false)
				{
					continue;
				}
				global::_0082._007E_009C_0005(P_1, true);
				PropertiesForm.Result = DialogResult.Cancel;
				bool flag2;
				do
				{
					flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
				}
				while (6 == 0);
				num = flag2;
			}
			goto IL_0069;
			IL_0069:
			if (num)
			{
				global::_0011._001D_0003(this);
				if (8 == 0)
				{
					break;
				}
			}
			num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			if (8 == 0)
			{
				goto IL_00ab;
			}
			if (num2)
			{
				global::_0082._0086_0005(this, false);
			}
			break;
		}
	}

	public void Apply()
	{
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(buGround1);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		if (PageIndex == 0)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_main)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_main)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 1)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_manuel)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_manuel)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_horizontal)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_horizontal)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 3)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_vertical)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_vertical)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 4)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_positions)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_positions)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 5)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_spindles)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_spindles)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			bool flag = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_apply));
			int num = (flag ? 1 : 0);
			int num6;
			double num10 = default(double);
			while (true)
			{
				bool num2;
				bool num3;
				if (num != 0)
				{
					num2 = clsAppMarbleVars.varRuntime.AxX >= 0;
					num3 = clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1;
					goto IL_007e;
				}
				goto IL_0701;
				IL_0774:
				double num4 = global::_0007._007E_0094(spn_calibx_unit);
				double num5 = global::_0007._007E_0094(spn_calibx_gear);
				_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_calibx_moveval), global::_0007._007E_0094(spn_calibx_measuredeval), true, ref num4, ref num5);
				global::_0095._007E_0008_0008(spn_calibx_unit, num4);
				goto IL_07e7;
				IL_0701:
				bool flag2 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_calibx));
				if (0 == 0)
				{
					if (flag2)
					{
						num2 = clsAppMarbleVars.varRuntime.AxX >= 0;
						num3 = clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1;
						if (false)
						{
							goto IL_007e;
						}
						if (num2 && num3)
						{
							goto IL_0774;
						}
					}
					goto IL_07e7;
				}
				goto IL_09a1;
				IL_0432:
				num6 = clsAppMarbleVars.varRuntime.AxZ;
				goto IL_043c;
				IL_08b2:
				double num7;
				global::_0095._007E_0008_0008(spn_caliby_unit, num7);
				goto IL_08c7;
				IL_0a30:
				double num9;
				double num8 = num9;
				_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_caliba_moveval), global::_0007._007E_0094(spn_caliba_measuredeval), true, ref num10, ref num8);
				global::_0095._007E_0008_0008(spn_caliba_unit, num10);
				goto IL_0a81;
				IL_007e:
				if (num2 && num3)
				{
					goto IL_0087;
				}
				goto IL_0130;
				IL_09a1:
				if (false)
				{
					goto IL_08b2;
				}
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_caliba)) && ((clsAppMarbleVars.varRuntime.AxA >= 0) & (clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)))
				{
					num10 = global::_0007._007E_0094(spn_caliba_unit);
					num9 = global::_0007._007E_0094(spn_caliba_gear);
					goto IL_0a30;
				}
				goto IL_0a81;
				IL_0087:
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_calibx_unit);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_calibx_pulse);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_calibx_gear);
				goto IL_0130;
				IL_08c7:
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_calibz)) && ((clsAppMarbleVars.varRuntime.AxZ >= 0) & (clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)))
				{
					double num11 = global::_0007._007E_0094(spn_calibz_unit);
					double num12 = global::_0007._007E_0094(spn_calibz_gear);
					_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_calibz_moveval), global::_0007._007E_0094(spn_calibz_measuredeval), true, ref num11, ref num12);
					global::_0095._007E_0008_0008(spn_calibz_unit, num11);
				}
				goto IL_09a1;
				IL_0130:
				if ((clsAppMarbleVars.varRuntime.AxY >= 0) & (clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
				{
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_caliby_unit);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_caliby_pulse);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_caliby_gear);
					if ((clsAppMarbleVars.varRuntime.AxY2 >= 0) & (clsAppMarbleVars.varRuntime.AxY2 <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
					{
						bool num13 = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit > 0.0;
						double setUnit = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit;
						if (0 == 0)
						{
							if (num13 && setUnit > 0.0)
							{
								clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
								goto IL_0432;
							}
							num9 = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
							if (1 == 0)
							{
								goto IL_0a30;
							}
							num13 = num9 < 0.0;
							setUnit = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit;
						}
						if (num13 && setUnit < 0.0)
						{
							clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
						}
						else
						{
							clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = 0.0 - clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
						}
					}
				}
				goto IL_0432;
				IL_0a81:
				bool flag3 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_calibc));
				num6 = (flag3 ? 1 : 0);
				if (0 == 0)
				{
					break;
				}
				goto IL_043c;
				IL_043c:
				if ((num6 >= 0) & (clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
				{
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_calibz_unit);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_calibz_pulse);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_calibz_gear);
				}
				bool flag4 = (clsAppMarbleVars.varRuntime.AxA >= 0) & (clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1);
				if (false)
				{
					goto IL_0087;
				}
				if (flag4)
				{
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_caliba_unit);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_caliba_pulse);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_caliba_gear);
				}
				if (0 == 0)
				{
					if ((clsAppMarbleVars.varRuntime.AxC >= 0) & (clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
					{
						clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_calibc_unit);
						clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_calibc_pulse);
						clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_calibc_gear);
					}
					clsAppMarbleVars.varInterface.MachineInstallationAxesCalib = true;
					clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
					goto IL_0701;
				}
				goto IL_0774;
				IL_07e7:
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_caliby)))
				{
					num = clsAppMarbleVars.varRuntime.AxY;
					if (2 == 0)
					{
						continue;
					}
					if ((num >= 0) & (clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
					{
						num7 = global::_0007._007E_0094(spn_caliby_unit);
						double num14 = global::_0007._007E_0094(spn_caliby_gear);
						_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_caliby_moveval), global::_0007._007E_0094(spn_caliby_measuredeval), true, ref num7, ref num14);
						goto IL_08b2;
					}
				}
				goto IL_08c7;
			}
			if (num6 != 0 && ((clsAppMarbleVars.varRuntime.AxC >= 0) & (clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)))
			{
				double num15 = global::_0007._007E_0094(spn_calibc_unit);
				double num16 = global::_0007._007E_0094(spn_calibc_gear);
				_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_calibc_moveval), global::_0007._007E_0094(spn_calibc_measuredeval), true, ref num15, ref num16);
				global::_0095._007E_0008_0008(spn_calibc_unit, num15);
			}
		}
		catch (Exception)
		{
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		try
		{
			Control control;
			KinematicBase5 kinematicBase = default(KinematicBase5);
			MarbleItem marbleItem = default(MarbleItem);
			MarbleItemCam marbleItemCam = default(MarbleItemCam);
			double num2 = default(double);
			double z = default(double);
			double num5 = default(double);
			double num6 = default(double);
			double num7 = default(double);
			while (true)
			{
				control = P_0 as Control;
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_kinematicccalculate)))
				{
					double num = global::_0007._007E_0094(spn_kinematicCMeasuredHeight) - global::_0007._007E_0094(spn_kinematicrectwidth);
					global::_0095._007E_0008_0008(spn_kinematicCDistance, global::_0007._007E_0094(spn_kinematicCDistance) - num / 2.0);
					if (-1 == 0)
					{
						goto IL_032f;
					}
				}
				if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_kinematicAcalculate)))
				{
					break;
				}
				kinematicBase = new KinematicBase5(clsMarble.activeKinematic);
				kinematicBase.RotateCenterOffsetOfC.Y = global::_0007._007E_0094(spn_kinematicCDistance);
				kinematicBase.RotateCenterOffsetOfA.Y = global::_0007._007E_0094(spn_kinematicAYDistance);
				kinematicBase.RotateCenterOffsetOfA.Z = global::_0007._007E_0094(spn_kinematicAZDistance);
				MarbleTempVars.listHorizontalItems.Clear();
				MarbleTempVars.listVerticalItems.Clear();
				MarbleTempVars.ItemsSlice.Clear();
				MarbleTempVars.listHorizontalItems.Add(new marbleCuttingItems(global::_0007._007E_0094(spn_kinematicrectwidth), 1, global::_0007._007E_0094(spn_kinematicrectang), global::_0007._007E_0094(spn_kinematicrectang)));
				_0006_0007._007E_0089_0013(clsInit.cMarble, new Pnt6D(), new Pnt6D(), buMarbleCalc.activeToolSaw, MarbleTempVars.listHorizontalItems, MarbleTempVars.listVerticalItems, buMarbleCalc.varOperation, kinematicBase, new EntitiesResolution(), ref MarbleTempVars.ItemsSlice, MarbleSliceType.Horizontal, global::_0007._007E_0094(spn_kinematicrectwidth), global::_0007._007E_0094(spn_kinematicrectwidth), true);
				marbleItem = new MarbleItem(MarbleTempVars.ItemsSlice[0]);
				marbleItemCam = new MarbleItemCam();
				_0007_0007._008A_0013(marbleItem.ItemEntities.WireEntities, ref marbleItemCam.WireEntities);
				_0008_0007._007E_008B_0013(clsInit.cMarble, buMarbleCalc.activeToolSaw, kinematicBase, null, 0, false, new TpPnt9D(), marbleItem, ref marbleItemCam);
				num2 = _0010_0004._0016_0010(marbleItemCam.CamBase.CamPoints[0].Points[2].P9.Y - marbleItemCam.CamBase.CamPoints[1].Points[2].P9.Y);
				z = marbleItemCam.CamBase.CamPoints[0].Points[3].P9.Z;
				do
				{
					double num3 = global::_0007._007E_0094(spn_kinematicAMeasuredWidth);
					double num4 = global::_0007._007E_0094(spn_kinematicrectwidth);
					if (0 == 0)
					{
						num5 = num3 - num4;
						num3 = global::_0007._007E_0094(spn_kinematicAMeasuredTargetZ);
						num4 = global::_0007._007E_0094(spn_kinematicoperationZ);
					}
					num6 = num3 - num4;
				}
				while (3 == 0);
				num7 = 999999.0;
				double z2 = kinematicBase.RotateCenterOffsetOfA.Z;
				goto IL_032f;
				IL_04c6:
				double num9;
				double num8 = num9;
				double num10 = kinematicBase.RotateCenterOffsetOfA.Y + 5.0;
				goto IL_04de;
				IL_032f:
				double num11 = kinematicBase.RotateCenterOffsetOfA.Y;
				double num12 = kinematicBase.RotateCenterOffsetOfA.Z;
				double num13 = 2.0;
				if (8 == 0)
				{
					goto IL_04fe;
				}
				double num14 = num12 - num13;
				goto IL_0501;
				IL_04fe:
				num14 = num12 + num13;
				goto IL_0501;
				IL_0501:
				num8 = num14;
				num10 = kinematicBase.RotateCenterOffsetOfA.Z + 2.0;
				if (6u != 0)
				{
					if (!(num8 <= num10))
					{
						break;
					}
					num9 = kinematicBase.RotateCenterOffsetOfA.Y - 5.0;
					goto IL_04c6;
				}
				goto IL_04de;
				IL_04de:
				if (num8 <= num10)
				{
					marbleItemCam.CamBase = null;
					KinematicBase5 kinematicBase2 = new KinematicBase5(clsMarble.activeKinematic);
					kinematicBase2.RotateCenterOffsetOfC.Y = global::_0007._007E_0094(spn_kinematicCDistance);
					kinematicBase2.RotateCenterOffsetOfA.Y = num9;
					kinematicBase2.RotateCenterOffsetOfA.Z = num14;
					_0008_0007._007E_008B_0013(clsInit.cMarble, buMarbleCalc.activeToolSaw, kinematicBase2, null, 0, false, new TpPnt9D(), marbleItem, ref marbleItemCam);
					double num15 = _0010_0004._0016_0010(marbleItemCam.CamBase.CamPoints[0].Points[2].P9.Y - marbleItemCam.CamBase.CamPoints[1].Points[2].P9.Y);
					double z3 = marbleItemCam.CamBase.CamPoints[0].Points[3].P9.Z;
					double num16 = num15 - (num2 + num5);
					double num17 = z3;
					while (true)
					{
						double num18 = num17 - (z + num6);
						double num19 = _0010_0004._0016_0010(num16 + num18);
						if (!(num19 < num7))
						{
							break;
						}
						if (0 == 0)
						{
							num17 = num19;
							if (false)
							{
								continue;
							}
							num7 = num17;
						}
						num11 = num9;
						z2 = num14;
						break;
					}
					num9 += 0.5;
					goto IL_04c6;
				}
				if (false)
				{
					continue;
				}
				num12 = num14;
				num13 = 0.5;
				goto IL_04fe;
			}
			if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_kinematiccodecreate)))
			{
			}
		}
		catch (Exception)
		{
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetx)))
			{
				global::_0095._007E_0008_0008(spn_datalimitnegx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnegx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetX)))
			{
				global::_0095._007E_0008_0008(spn_datalimitposx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
				if (2 == 0)
				{
					goto IL_0355;
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetY)))
			{
				global::_0095._007E_0008_0008(spn_datalimitnegy, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnegy, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetY)))
			{
				global::_0095._007E_0008_0008(spn_datalimitposy, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposy, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			goto IL_0355;
			IL_0355:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetZ)))
			{
				global::_0095._007E_0008_0008(spn_datalimitnegz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnegz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetZ)))
			{
				global::_0095._007E_0008_0008(spn_datalimitposz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetA)))
			{
				global::_0095._007E_0008_0008(spn_datalimitnega, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnega, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetA)))
			{
				global::_0095._007E_0008_0008(spn_datalimitposa, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposa, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetC)))
			{
				global::_0095._007E_0008_0008(spn_datalimitnegc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnegc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetC)))
			{
				global::_0095._007E_0008_0008(spn_datalimitposc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitdisablex)))
			{
				global::_0082._007E_0089_0005(chk_softlimitx, false);
				global::_0082._007E_0089_0005(chk_joglimitx, false);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitx);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitenablex)))
			{
				global::_0082._007E_0089_0005(chk_softlimitx, true);
				global::_0082._007E_0089_0005(chk_joglimitx, true);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitx);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitdisabley)))
			{
				global::_0082._007E_0089_0005(chk_softlimity, false);
				global::_0082._007E_0089_0005(chk_joglimity, false);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimity);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimity);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitenabley)))
			{
				global::_0082._007E_0089_0005(chk_softlimity, true);
				global::_0082._007E_0089_0005(chk_joglimity, true);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimity);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimity);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitdisablez)))
			{
				global::_0082._007E_0089_0005(chk_softlimitz, false);
				global::_0082._007E_0089_0005(chk_joglimitz, false);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitz);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitenablez)))
			{
				global::_0082._007E_0089_0005(chk_softlimitz, true);
				global::_0082._007E_0089_0005(chk_joglimitz, true);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitz);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitdisablea)))
			{
				global::_0082._007E_0089_0005(chk_softlimita, false);
				global::_0082._007E_0089_0005(chk_joglimita, false);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimita);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimita);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitenablea)))
			{
				global::_0082._007E_0089_0005(chk_softlimita, true);
				global::_0082._007E_0089_0005(chk_joglimita, true);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimita);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimita);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitdisablec)))
			{
				global::_0082._007E_0089_0005(chk_softlimitc, false);
				global::_0082._007E_0089_0005(chk_joglimitc, false);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitc);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitenablec)))
			{
				global::_0082._007E_0089_0005(chk_softlimitc, true);
				global::_0082._007E_0089_0005(chk_joglimitc, true);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitc);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
		}
		catch (Exception)
		{
		}
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			if (global::_000E._007E_0003_0002(buTab_Main) == 0)
			{
				if ((clsAppMarbleVars.varRuntime.AxX >= 0) & (clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
				{
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_calibx_unit);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_calibx_pulse);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_calibx_gear);
				}
				if ((clsAppMarbleVars.varRuntime.AxY >= 0) & (clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
				{
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_caliby_unit);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_caliby_pulse);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_caliby_gear);
					if ((clsAppMarbleVars.varRuntime.AxY2 >= 0) & (clsAppMarbleVars.varRuntime.AxY2 <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
					{
						if ((clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit > 0.0) & (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit > 0.0))
						{
							clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
						}
						else if ((clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit < 0.0) & (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit < 0.0))
						{
							clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
						}
						else
						{
							clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = 0.0 - clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
						}
					}
				}
				if ((clsAppMarbleVars.varRuntime.AxZ >= 0) & (clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
				{
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_calibz_unit);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_calibz_pulse);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_calibz_gear);
				}
				if ((clsAppMarbleVars.varRuntime.AxA >= 0) & (clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
				{
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_caliba_unit);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_caliba_pulse);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_caliba_gear);
				}
				if ((clsAppMarbleVars.varRuntime.AxC >= 0) & (clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
				{
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_calibc_unit);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_calibc_pulse);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_calibc_gear);
				}
				clsAppMarbleVars.varInterface.MachineInstallationAxesCalib = true;
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
			}
			if (global::_000E._007E_0003_0002(buTab_Main) == 1)
			{
				clsMarble.activeKinematic.RotateCenterOffsetOfC.Y = global::_0007._007E_0094(spn_kinematicCDistance);
				clsMarble.activeKinematic.RotateCenterOffsetOfA.Y = global::_0007._007E_0094(spn_kinematicAYDistance);
				clsMarble.activeKinematic.RotateCenterOffsetOfA.Z = global::_0007._007E_0094(spn_kinematicAZDistance);
				clsAppMarbleVars.varInterface.MachineInstallationKinematic = true;
			}
			if (global::_000E._007E_0003_0002(buTab_Main) == 2)
			{
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogVelocity = global::_0007._007E_0094(spn_speedJogXSpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogAcc = global::_0007._007E_0094(spn_speedJogXAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogDec = global::_0007._007E_0094(spn_speedJogXAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogJerk = global::_0007._007E_0094(spn_speedJogXjerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedPersentage = global::_0007._007E_0094(spn_speedJogX2SpeedPerc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedTimeSec = global::_0007._007E_0094(spn_speedJogX2SpeedTime);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveVelocity = global::_0007._007E_0094(spn_speedMoveXSpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveAcc = global::_0007._007E_0094(spn_speedMoveXAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveDec = global::_0007._007E_0094(spn_speedMoveXAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveJerk = global::_0007._007E_0094(spn_speedMoveXJerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogVelocity = global::_0007._007E_0094(spn_speedJogYSpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogAcc = global::_0007._007E_0094(spn_speedJogYAccDEc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogDec = global::_0007._007E_0094(spn_speedJogYAccDEc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogJerk = global::_0007._007E_0094(spn_speedJogYJerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedPersentage = global::_0007._007E_0094(spn_speedJogY2SpeedPerc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedTimeSec = global::_0007._007E_0094(spn_speedJogY2SpeedTime);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveVelocity = global::_0007._007E_0094(spn_speedMoveYSpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveAcc = global::_0007._007E_0094(spn_speedMoveYAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveDec = global::_0007._007E_0094(spn_speedMoveYAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveJerk = global::_0007._007E_0094(spn_speedMoveYJerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogVelocity = global::_0007._007E_0094(spn_speedJogZSpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogAcc = global::_0007._007E_0094(spn_speedJogZAccDEc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogDec = global::_0007._007E_0094(spn_speedJogZAccDEc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogJerk = global::_0007._007E_0094(spn_speedJogZJerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedPersentage = global::_0007._007E_0094(spn_speedJogZ2SpeedPerc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedTimeSec = global::_0007._007E_0094(spn_speedJogZ2SpeedTime);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveVelocity = global::_0007._007E_0094(spn_speedMoveZSpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveAcc = global::_0007._007E_0094(spn_speedMoveZAccDEc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveDec = global::_0007._007E_0094(spn_speedMoveZAccDEc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveJerk = global::_0007._007E_0094(spn_speedMoveZJerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_caliba_unit);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_caliba_pulse);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_caliba_gear);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogVelocity = global::_0007._007E_0094(spn_speedJogASpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogAcc = global::_0007._007E_0094(spn_speedJogAAccDEc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogDec = global::_0007._007E_0094(spn_speedJogAAccDEc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogJerk = global::_0007._007E_0094(spn_speedJogAJerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedPersentage = global::_0007._007E_0094(spn_speedJogA2SpeedPerc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedTimeSec = global::_0007._007E_0094(spn_speedJogA2SpeedTime);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveVelocity = global::_0007._007E_0094(spn_speedMoveASpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveAcc = global::_0007._007E_0094(spn_speedMoveAAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveDec = global::_0007._007E_0094(spn_speedMoveAAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveJerk = global::_0007._007E_0094(spn_speedMoveAJerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogVelocity = global::_0007._007E_0094(spn_speedJogCSpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogAcc = global::_0007._007E_0094(spn_speedJogCAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogDec = global::_0007._007E_0094(spn_speedJogCAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogJerk = global::_0007._007E_0094(spn_speedJogCJerk);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedPersentage = global::_0007._007E_0094(spn_speedJogC2SpeedPerc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedTimeSec = global::_0007._007E_0094(spn_speedJogC2SpeedTime);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveVelocity = global::_0007._007E_0094(spn_speedMoveCSpeed);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveAcc = global::_0007._007E_0094(spn_speedMoveCAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveDec = global::_0007._007E_0094(spn_speedMoveCAccDec);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveJerk = global::_0007._007E_0094(spn_speedMoveCJerk);
				clsAppMarbleVars.cMachine.varCNC.setG0Acc = global::_0007._007E_0094(spn_cncG0AccDec);
				clsAppMarbleVars.cMachine.varCNC.setG0Dec = global::_0007._007E_0094(spn_cncG0AccDec);
				clsAppMarbleVars.cMachine.varCNC.setG1Acc = global::_0007._007E_0094(spn_cncG1AccDec);
				clsAppMarbleVars.cMachine.varCNC.setG1Dec = global::_0007._007E_0094(spn_cncG1AccDec);
				clsAppMarbleVars.cMachine.varCNC.setMaxJerk = global::_0007._007E_0094(spn_cncJerk);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
				clsAppMarbleVars.varInterface.MachineInstallationSpeeds = true;
			}
			if (global::_000E._007E_0003_0002(buTab_Main) == 3)
			{
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitPositive = global::_0007._007E_0094(spn_softlimitposx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitNegative = global::_0007._007E_0094(spn_softlimitnegx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitPositive = global::_0007._007E_0094(spn_datalimitposx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitNegative = global::_0007._007E_0094(spn_datalimitnegx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setHardLimitEnable = global::_0003._007E_0010(chk_hardlimitx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitPositive = global::_0007._007E_0094(spn_softlimitposy);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitNegative = global::_0007._007E_0094(spn_softlimitnegy);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitPositive = global::_0007._007E_0094(spn_datalimitposy);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitNegative = global::_0007._007E_0094(spn_datalimitnegy);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimity);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimity);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setHardLimitEnable = global::_0003._007E_0010(chk_hardlimity);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitPositive = global::_0007._007E_0094(spn_softlimitposz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitNegative = global::_0007._007E_0094(spn_softlimitnegz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitPositive = global::_0007._007E_0094(spn_datalimitposz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitNegative = global::_0007._007E_0094(spn_datalimitnegz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setHardLimitEnable = global::_0003._007E_0010(chk_hardlimitz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitPositive = global::_0007._007E_0094(spn_softlimitposa);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitNegative = global::_0007._007E_0094(spn_softlimitnega);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitPositive = global::_0007._007E_0094(spn_datalimitposa);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitNegative = global::_0007._007E_0094(spn_datalimitnega);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimita);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimita);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setHardLimitEnable = global::_0003._007E_0010(chk_hardlimita);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitPositive = global::_0007._007E_0094(spn_softlimitposc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitNegative = global::_0007._007E_0094(spn_softlimitnegc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitPositive = global::_0007._007E_0094(spn_datalimitposc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitNegative = global::_0007._007E_0094(spn_datalimitnegc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = global::_0003._007E_0010(chk_softlimitc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = global::_0003._007E_0010(chk_joglimitc);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setHardLimitEnable = global::_0003._007E_0010(chk_hardlimitc);
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
				clsAppMarbleVars.varInterface.MachineInstallationLimits = true;
			}
			if (global::_000E._007E_0003_0002(buTab_Main) == 4)
			{
				clsAppMarbleVars.varApp.SawModePositionX = global::_0007._007E_0094(spn_SawModePositionX);
				clsAppMarbleVars.varApp.SawModePositionY = global::_0007._007E_0094(spn_SawModePositionY);
				clsAppMarbleVars.varApp.SawModePositionZ = global::_0007._007E_0094(spn_SawModePositionZ);
				clsAppMarbleVars.varApp.SawModePositionA = global::_0007._007E_0094(spn_SawModePositionA);
				clsAppMarbleVars.varApp.SawModePositionC = global::_0007._007E_0094(spn_SawModePositionC);
				clsAppMarbleVars.varApp.MillingModePositionX = global::_0007._007E_0094(spn_MillingModePositionX);
				clsAppMarbleVars.varApp.MillingModePositionY = global::_0007._007E_0094(spn_MillingModePositionY);
				clsAppMarbleVars.varApp.MillingModePositionZ = global::_0007._007E_0094(spn_MillingModePositionZ);
				clsAppMarbleVars.varApp.MillingModePositionA = global::_0007._007E_0094(spn_MillingModePositionA);
				clsAppMarbleVars.varApp.MillingModePositionC = global::_0007._007E_0094(spn_MillingModePositionC);
				clsAppMarbleVars.varApp.MillingHeadModePositionX = global::_0007._007E_0094(spn_MillingHeadModePositionX);
				clsAppMarbleVars.varApp.MillingHeadModePositionY = global::_0007._007E_0094(spn_MillingHeadModePositionY);
				clsAppMarbleVars.varApp.MillingHeadModePositionZ = global::_0007._007E_0094(spn_MillingHeadModePositionZ);
				clsAppMarbleVars.varApp.MillingHeadModePositionA = global::_0007._007E_0094(spn_MillingHeadModePositionA);
				clsAppMarbleVars.varApp.MillingHeadModePositionC = global::_0007._007E_0094(spn_MillingHeadModePositionC);
				clsAppMarbleVars.varApp.SawDiaMeasurePositionX = global::_0007._007E_0094(spn_SawDiaMeasurePositionX);
				clsAppMarbleVars.varApp.SawDiaMeasurePositionY = global::_0007._007E_0094(spn_SawDiaMeasurePositionY);
				clsAppMarbleVars.varApp.SawDiaMeasurePositionFastZ = global::_0007._007E_0094(spn_SawDiaMeasurePositionFastZ);
				clsAppMarbleVars.varApp.SawDiaMeasurePositionA = global::_0007._007E_0094(spn_SawDiaMeasurePositionA);
				clsAppMarbleVars.varApp.SawDiaMeasurePositionC = global::_0007._007E_0094(spn_SawDiaMeasurePositionC);
				clsAppMarbleVars.varApp.MillingLenMeasurePositionX = global::_0007._007E_0094(spn_MillingLenMeasurePositionX);
				clsAppMarbleVars.varApp.MillingLenMeasurePositionY = global::_0007._007E_0094(spn_MillingLenMeasurePositionY);
				clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ = global::_0007._007E_0094(spn_MillingLenMeasurePositionFastZ);
				clsAppMarbleVars.varApp.MillingLenMeasurePositionA = global::_0007._007E_0094(spn_MillingLenMeasurePositionA);
				clsAppMarbleVars.varApp.MillingLenMeasurePositionC = global::_0007._007E_0094(spn_MillingLenMeasurePositionC);
				clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionX);
				clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionY);
				clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionFastZ);
				clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionA);
				clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionC);
				clsAppMarbleVars.varApp.WagonUpPositionX = global::_0007._007E_0094(spn_wagonposX);
				clsAppMarbleVars.varApp.WagonUpPositionY = global::_0007._007E_0094(spn_wagonposY);
				clsAppMarbleVars.varApp.WagonUpPositionZ = global::_0007._007E_0094(spn_wagonposZ);
				clsAppMarbleVars.varApp.WagonUpPositionA = global::_0007._007E_0094(spn_wagonposA);
				clsAppMarbleVars.varApp.WagonUpPositionC = global::_0007._007E_0094(spn_wagonposC);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparkx);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparky);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparkz);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparka);
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparkc);
				clsAppMarbleVars.varInterface.MachineInstallationPositions = true;
			}
			if (global::_000E._007E_0003_0002(buTab_Main) == 5)
			{
				clsAppMarbleVars.varApp.SawMaxSpeed = global::_0007._007E_0094(spn_SawMaxSpeed);
				clsAppMarbleVars.varApp.SawStartTimerSec = global::_0007._007E_0094(spn_SawStartTimerSec);
				clsAppMarbleVars.varApp.SawStopTimerSec = global::_0007._007E_0094(spn_SawStopTimerSec);
				clsAppMarbleVars.varApp.SawSpeedAtCheck = global::_0003._007E_0010(chk_SawSpeedAtCheck);
				clsAppMarbleVars.varApp.SawSpeedAtCheck = global::_0003._007E_0010(chk_SawStopdAtCheck);
				clsAppMarbleVars.varApp.SpindleMaxSpeed = global::_0007._007E_0094(spn_SpindleMaxSpeed);
				clsAppMarbleVars.varApp.SpindleStartTimerSec = global::_0007._007E_0094(spn_SpindleStartTimerSec);
				clsAppMarbleVars.varApp.SpindleStopTimerSec = global::_0007._007E_0094(spn_SpindleStopTimerSec);
				clsAppMarbleVars.varApp.SpindleCoolAfterStopTimeSec = global::_0007._007E_0094(spn_SpindleCoolAfterStopTimeSec);
				clsAppMarbleVars.varApp.SpindleSpeedAtCheck = global::_0003._007E_0010(chk_SpindleSpeedAtCheck);
				clsAppMarbleVars.varApp.SpindleStopdAtCheck = global::_0003._007E_0010(chk_SpindleStopdAtCheck);
				clsAppMarbleVars.varApp.SpindleCoolAfterStop = global::_0003._007E_0010(chk_SpindleCoolAfterStop);
				clsAppMarbleVars.varApp.SpindlePersentageFromPLC = global::_0003._007E_0010(chk_SpindlePersentageFromPLC);
				clsAppMarbleVars.varApp.SpindlePersentageSinglePot = global::_0003._007E_0010(chk_SpindlePersentageSinglePot);
				clsAppMarbleVars.varInterface.MachineInstallationSpindle = true;
			}
		}
		catch (Exception)
		{
		}
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = new Control();
			control = (Control)P_0;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_stop)) && clsAppMarbleVars.cmdMarble != null)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)))
			{
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				goto IL_00cb;
			}
			goto IL_00ef;
			IL_00e0:
			global::_0082._0086_0005(this, false);
			goto IL_00ef;
			IL_00ef:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close)) | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel)))
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
			}
			bool flag;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_jog)))
			{
				flag = clsAppMarbleItems.frmJogPageV1 != null;
				goto IL_01c9;
			}
			goto IL_020b;
			IL_00cb:
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				goto IL_00e0;
			}
			goto IL_00ef;
			IL_01c9:
			if (flag)
			{
				clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				clsAppMarbleItems.frmJogPageV1.Init();
				_0008_0004._007E_0008_0010(clsAppMarbleItems.frmJogPageV1);
			}
			goto IL_020b;
			IL_020b:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_main)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 0);
				MenuButtonColors(0);
			}
			while (true)
			{
				IL_0252:
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_manuel)))
				{
					global::_008D._007E_000F_0007(buTab_Main, 1);
					MenuButtonColors(1);
				}
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_horizontal)))
				{
					global::_008D._007E_000F_0007(buTab_Main, 2);
					MenuButtonColors(2);
				}
				while (true)
				{
					IL_02e0:
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_vertical)))
					{
						global::_008D._007E_000F_0007(buTab_Main, 3);
						MenuButtonColors(3);
					}
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_positions)))
					{
						global::_008D._007E_000F_0007(buTab_Main, 4);
						MenuButtonColors(4);
					}
					bool flag2 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_spindles));
					int num = (flag2 ? 1 : 0);
					while (true)
					{
						IL_0397:
						if (num != 0)
						{
							global::_008D._007E_000F_0007(buTab_Main, 5);
							MenuButtonColors(5);
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_generalparkgetpos)) && AppBool.Connected)
						{
							if (clsAppMarbleVars.varRuntime.AxX >= 0)
							{
								global::_0095._007E_0008_0008(spn_generalparkx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							goto IL_0454;
						}
						goto IL_05da;
						IL_1b27:
						double num2;
						double xPos = num2;
						double yPos = global::_0007._007E_0094(spn_MillingLenMeasurePositionX);
						double zPos = global::_0007._007E_0094(spn_MillingLenMeasurePositionFastZ);
						double cPos = global::_0007._007E_0094(spn_MillingLenMeasurePositionC);
						if (false)
						{
							goto IL_0454;
						}
						double aPos = global::_0007._007E_0094(spn_MillingLenMeasurePositionA);
						clsAppMarbleVars.cmdMarble.GoPosition(xPos, yPos, zPos, cPos, aPos, 500, 500, 10);
						goto IL_1b9a;
						IL_1b9a:
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingparkgo)) && AppBool.Connected)
						{
							double xPos2 = global::_0007._007E_0094(spn_MillingModePositionX);
							double yPos2 = global::_0007._007E_0094(spn_MillingModePositionY);
							double zPos2 = global::_0007._007E_0094(spn_MillingModePositionZ);
							double cPos2 = global::_0007._007E_0094(spn_MillingModePositionC);
							double aPos2 = global::_0007._007E_0094(spn_MillingModePositionA);
							clsAppMarbleVars.cmdMarble.GoPosition(xPos2, yPos2, zPos2, cPos2, aPos2, 500, 500, 10);
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasurego)) && AppBool.Connected)
						{
							double xPos3 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionX);
							double yPos3 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionY);
							double zPos3 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionFastZ);
							double cPos3 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionC);
							double aPos3 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionA);
							clsAppMarbleVars.cmdMarble.GoPosition(xPos3, yPos3, zPos3, cPos3, aPos3, 500, 500, 10);
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadparkgo)) && AppBool.Connected)
						{
							double xPos4 = global::_0007._007E_0094(spn_MillingHeadModePositionX);
							double yPos4 = global::_0007._007E_0094(spn_MillingHeadModePositionY);
							double zPos4 = global::_0007._007E_0094(spn_MillingHeadModePositionZ);
							double cPos4 = global::_0007._007E_0094(spn_MillingHeadModePositionC);
							double aPos4 = global::_0007._007E_0094(spn_MillingHeadModePositionA);
							clsAppMarbleVars.cmdMarble.GoPosition(xPos4, yPos4, zPos4, cPos4, aPos4, 500, 500, 10);
						}
						return;
						IL_1150:
						if (clsAppMarbleVars.varRuntime.AxY >= 0)
						{
							global::_0095._007E_0008_0008(spn_MillingModePositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						if (clsAppMarbleVars.varRuntime.AxZ >= 0)
						{
							global::_0095._007E_0008_0008(spn_MillingModePositionZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						if (clsAppMarbleVars.varRuntime.AxC >= 0)
						{
							global::_0095._007E_0008_0008(spn_MillingModePositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						if (clsAppMarbleVars.varRuntime.AxA >= 0)
						{
							global::_0095._007E_0008_0008(spn_MillingModePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						goto IL_12d6;
						IL_0454:
						if (clsAppMarbleVars.varRuntime.AxY >= 0)
						{
							global::_0095._007E_0008_0008(spn_generalparky, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						if (clsAppMarbleVars.varRuntime.AxZ >= 0)
						{
							global::_0095._007E_0008_0008(spn_generalparkz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						if (clsAppMarbleVars.varRuntime.AxC >= 0)
						{
							global::_0095._007E_0008_0008(spn_generalparkc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						if (clsAppMarbleVars.varRuntime.AxA >= 0)
						{
							global::_0095._007E_0008_0008(spn_generalparka, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						goto IL_05da;
						IL_0d55:
						if (clsAppMarbleVars.varRuntime.AxZ >= 0)
						{
							global::_0095._007E_0008_0008(spn_SawModePositionZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						if (clsAppMarbleVars.varRuntime.AxC >= 0)
						{
							global::_0095._007E_0008_0008(spn_SawModePositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						if (clsAppMarbleVars.varRuntime.AxA >= 0)
						{
							global::_0095._007E_0008_0008(spn_SawModePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
						}
						goto IL_0e7a;
						IL_05da:
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_wagongetposition)) && AppBool.Connected)
						{
							if (clsAppMarbleVars.varRuntime.AxX >= 0)
							{
								global::_0095._007E_0008_0008(spn_wagonposX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxY >= 0)
							{
								global::_0095._007E_0008_0008(spn_wagonposY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxZ >= 0)
							{
								global::_0095._007E_0008_0008(spn_wagonposZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxC >= 0)
							{
								global::_0095._007E_0008_0008(spn_wagonposC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxA >= 0)
							{
								global::_0095._007E_0008_0008(spn_wagonposA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
							}
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cameragetposition)))
						{
							if (false)
							{
								goto IL_1150;
							}
							if (AppBool.Connected)
							{
								if (clsAppMarbleVars.varRuntime.AxX >= 0)
								{
									global::_0095._007E_0008_0008(spn_CameraPositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxY >= 0)
								{
									global::_0095._007E_0008_0008(spn_CameraPositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxZ >= 0)
								{
									global::_0095._007E_0008_0008(spn_CameraPositionZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxC >= 0)
								{
									global::_0095._007E_0008_0008(spn_CameraPositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxA >= 0)
								{
									global::_0095._007E_0008_0008(spn_CameraPositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
								}
							}
							if (false)
							{
								goto IL_0d55;
							}
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasuregetpos)) && AppBool.Connected)
						{
							if (clsAppMarbleVars.varRuntime.AxX >= 0)
							{
								global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxY >= 0)
							{
								global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxZ >= 0)
							{
								global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionFastZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxC >= 0)
							{
								global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxA >= 0)
							{
								global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
							}
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawparkgetpos)) && AppBool.Connected)
						{
							if (clsAppMarbleVars.varRuntime.AxX >= 0)
							{
								global::_0095._007E_0008_0008(spn_SawModePositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxY >= 0)
							{
								global::_0095._007E_0008_0008(spn_SawModePositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							goto IL_0d55;
						}
						goto IL_0e7a;
						IL_1732:
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_generalparkgo)))
						{
							if (false)
							{
								goto IL_00cb;
							}
							if (AppBool.Connected)
							{
								double xPos5 = global::_0007._007E_0094(spn_generalparkx);
								num2 = global::_0007._007E_0094(spn_generalparky);
								if (2 == 0)
								{
									goto IL_1b27;
								}
								double yPos5 = num2;
								double zPos5 = global::_0007._007E_0094(spn_generalparkz);
								double cPos5 = global::_0007._007E_0094(spn_generalparkc);
								double aPos5 = global::_0007._007E_0094(spn_generalparka);
								clsAppMarbleVars.cmdMarble.GoPosition(xPos5, yPos5, zPos5, cPos5, aPos5, 500, 500, 10);
							}
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_wagongo)) && AppBool.Connected)
						{
							double xPos6 = global::_0007._007E_0094(spn_wagonposX);
							double yPos6 = global::_0007._007E_0094(spn_wagonposY);
							double zPos6 = global::_0007._007E_0094(spn_wagonposZ);
							double cPos6 = global::_0007._007E_0094(spn_wagonposC);
							double aPos6 = global::_0007._007E_0094(spn_wagonposA);
							clsAppMarbleVars.cmdMarble.GoPosition(xPos6, yPos6, zPos6, cPos6, aPos6, 500, 500, 10);
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_camerago)) && AppBool.Connected)
						{
							double xPos7 = global::_0007._007E_0094(spn_CameraPositionX);
							double yPos7 = global::_0007._007E_0094(spn_CameraPositionY);
							double zPos7 = global::_0007._007E_0094(spn_CameraPositionZ);
							double cPos7 = global::_0007._007E_0094(spn_CameraPositionC);
							double aPos7 = global::_0007._007E_0094(spn_CameraPositionA);
							clsAppMarbleVars.cmdMarble.GoPosition(xPos7, yPos7, zPos7, cPos7, aPos7, 500, 500, 10);
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasurego)) && AppBool.Connected)
						{
							double xPos8 = global::_0007._007E_0094(spn_SawDiaMeasurePositionX);
							double yPos8 = global::_0007._007E_0094(spn_SawDiaMeasurePositionY);
							double zPos8 = global::_0007._007E_0094(spn_SawDiaMeasurePositionFastZ);
							double cPos8 = global::_0007._007E_0094(spn_SawDiaMeasurePositionC);
							double aPos8 = global::_0007._007E_0094(spn_SawDiaMeasurePositionA);
							clsAppMarbleVars.cmdMarble.GoPosition(xPos8, yPos8, zPos8, cPos8, aPos8, 500, 500, 10);
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawparkgo)) && AppBool.Connected)
						{
							double xPos9 = global::_0007._007E_0094(spn_SawModePositionX);
							double yPos9 = global::_0007._007E_0094(spn_SawModePositionY);
							double zPos9 = global::_0007._007E_0094(spn_SawModePositionZ);
							double cPos9 = global::_0007._007E_0094(spn_SawModePositionC);
							double aPos9 = global::_0007._007E_0094(spn_SawModePositionA);
							clsAppMarbleVars.cmdMarble.GoPosition(xPos9, yPos9, zPos9, cPos9, aPos9, 500, 500, 10);
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasurego)) && AppBool.Connected)
						{
							num2 = global::_0007._007E_0094(spn_MillingLenMeasurePositionX);
							goto IL_1b27;
						}
						goto IL_1b9a;
						IL_0e7a:
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasuregetpos)) && AppBool.Connected)
						{
							if (clsAppMarbleVars.varRuntime.AxX >= 0)
							{
								global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxY >= 0)
							{
								global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxZ >= 0)
							{
								if (false)
								{
									break;
								}
								global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionFastZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
							}
							if (clsAppMarbleVars.varRuntime.AxC >= 0)
							{
								global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
								if (false)
								{
									goto IL_01c9;
								}
							}
							if (clsAppMarbleVars.varRuntime.AxA >= 0)
							{
								global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
							}
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingparkgetpos)))
						{
							if (false)
							{
								goto IL_0252;
							}
							if (AppBool.Connected)
							{
								if (clsAppMarbleVars.varRuntime.AxX >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingModePositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								goto IL_1150;
							}
						}
						goto IL_12d6;
						IL_12d6:
						while (true)
						{
							if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasuregetpos)) && AppBool.Connected)
							{
								if (clsAppMarbleVars.varRuntime.AxX >= 0)
								{
									if (3 == 0)
									{
										break;
									}
									global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxY >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxZ >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionFastZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								num = clsAppMarbleVars.varRuntime.AxC;
								if (false)
								{
									goto IL_0397;
								}
								if (num >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxA >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
								}
							}
							if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadparkgetpos)) && AppBool.Connected)
							{
								if (clsAppMarbleVars.varRuntime.AxX >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingHeadModePositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxY >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingHeadModePositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxZ >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingHeadModePositionZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxC >= 0)
								{
									global::_0095._007E_0008_0008(spn_MillingHeadModePositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
								}
								if (clsAppMarbleVars.varRuntime.AxA >= 0)
								{
									if (3 == 0)
									{
										continue;
									}
									global::_0095._007E_0008_0008(spn_MillingHeadModePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
								}
							}
							goto IL_1732;
						}
						goto IL_02e0;
					}
					break;
				}
				break;
			}
			goto IL_00e0;
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	internal void _0006(object P_0, EventArgs P_1)
	{
		buSpin buSpin2 = P_0 as buSpin;
		bool num = AppBool.TouchPad;
		while (true)
		{
			bool flag = num;
			if (uint.MaxValue != 0)
			{
				num = flag;
				goto IL_0025;
			}
			goto IL_00a7;
			IL_0025:
			if (!num)
			{
				break;
			}
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			F_KeyPadNumV1 f_KeyPadNumV2;
			if (7u != 0)
			{
				f_KeyPadNumV2 = f_KeyPadNumV;
			}
			goto IL_0037;
			IL_00a7:
			bool flag2;
			if (flag2 && 8u != 0)
			{
				global::_0095._007E_0008_0008(buSpin2, _0008_0005._007F_0011(f_KeyPadNumV2.Value));
				if (0 == 0)
				{
					break;
				}
				goto IL_0037;
			}
			break;
			IL_0037:
			global::_009C._007E_001A_0008(f_KeyPadNumV2, FormStartPosition.CenterParent);
			f_KeyPadNumV2.Caption = global::_0005._007E_008A(global::_0096._007E_0012_0008(buSpin2));
			if (0 == 0)
			{
				global::_008B._007E_009B_0006(f_KeyPadNumV2, global::_0007._007E_0094(buSpin2).ToString());
			}
			num = _0007_0005._001D_0011(f_KeyPadNumV2.Value);
			if (false)
			{
				continue;
			}
			if (1 == 0)
			{
				goto IL_0025;
			}
			flag2 = num;
			goto IL_00a7;
		}
	}

	protected override void Dispose(bool disposing)
	{
		do
		{
			if (8 == 0)
			{
				goto IL_0025;
			}
			if (!disposing)
			{
				goto IL_0014;
			}
			int num = ((this.m__0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_001A_0002(this.m__0001);
			continue;
			IL_0014:
			num = 0;
			goto IL_004b;
			IL_004b:
			while (true)
			{
				bool flag = (byte)num != 0;
				while (true)
				{
					num = (flag ? 1 : 0);
					if (3 == 0)
					{
						break;
					}
					if (num == 0)
					{
						goto end_IL_004b;
					}
					if (false)
					{
						continue;
					}
					goto IL_0021;
				}
				continue;
				end_IL_004b:
				break;
			}
			continue;
			IL_0021:
			if (1 == 0)
			{
				goto IL_0014;
			}
			goto IL_0025;
		}
		while (false);
		global::_0082._009D_0005(this, disposing);
	}
}
