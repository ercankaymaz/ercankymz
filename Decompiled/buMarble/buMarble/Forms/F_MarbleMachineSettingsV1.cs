using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;

namespace buMarble.Forms;

public class F_MarbleMachineSettingsV1 : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer m__0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_millinghead;

	public buButton btn_milling;

	public buButton btn_saw;

	public buTab buTab_Main;

	public TabPage tabPage_saw;

	public TabPage tabPage_milling;

	internal TabPage _0001;

	internal buLabel _0001;

	internal buLabel _0002;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal PictureBox _0001;

	internal buLabel _0003;

	internal buLabel _0004;

	internal buLabel _0005;

	internal TabPage _0002;

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

	internal TabPage _0003;

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

	internal TabPage _0004;

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

	internal TabPage _0005;

	public buSpin spn_MillingHeadLenMeasureMaxLength;

	public buSpin spn_MillingHeadLenMeasureMinLength;

	public buSpin spn_MillingHeadLenMeasurePositionX;

	public buSpin spn_MillingHeadLenMeasureConstant;

	public buSpin spn_MillingHeadLenMeasurePositionLimitZ;

	public buSpin spn_MillingHeadLenMeasurePositionC;

	public buSpin spn_MillingHeadLenMeasurePositionFastZ;

	public buSpin spn_MillingHeadLenMeasurePositionA;

	public buSpin spn_MillingHeadLenMeasurePositionY;

	internal buLabel _0006;

	internal buLabel _0007;

	public buSpin spn_MillingModePosTimeOutSec;

	public buSpin spn_MillingMeasureTimeOutSec;

	internal TabPage _0006;

	public buSpin spn_ToolMeasureCoverOnTimeSec;

	public buSpin spn_ToolMeasureSlowLeaveVelocity;

	public buSpin spn_ToolMeasureJerk;

	public buSpin spn_ToolMeasureFastVelocity;

	public buSpin spn_ToolMeasureAccDec;

	public buSpin spn_ToolMeasureCoverOffTimeSec;

	public buButton btn_toolmeasure;

	internal buLabel _0008;

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

	internal TabPage _0007;

	internal buLabel _000E;

	public buSpin spn_wagonposX;

	public buSpin spn_wagonposA;

	public buSpin spn_wagonhidrostopsec;

	public buSpin spn_wagonposZ;

	public buSpin spn_wagonposC;

	public buSpin spn_wagonposY;

	internal TabPage _0008;

	public buSpin spn_wagontimeout;

	internal buLabel _000F;

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

	internal TabPage _000E;

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

	internal TabPage _000F;

	internal TabPage _0010;

	internal TabPage _0011;

	internal TabPage _0012;

	internal TabPage _0013;

	public buSpin spn_VacuumUpTimeSec;

	internal buLabel _0010;

	internal buLabel _0011;

	internal buLabel _0012;

	internal buLabel _0013;

	internal buLabel _0014;

	internal buLabel _0015;

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

	internal TabPage _0014;

	public buCheckBox chk_ServoAAxis;

	public buSpin spn_AAxisAllowedZSafePosition;

	public buSpin spn_AAxisTimeOutSec;

	public buSpin spn_AAxisExtraTimeSec;

	internal buLabel _0016;

	public buSpin spn_ParkPosTimeOutSec;

	public buSpin spn_WaterOnOffTimerSec;

	public buSpin spn_LaserOnOffTimerSec;

	public buSpin spn_StartPointPosTimeOutSec;

	public buCheckBox chk_GoZUpPositionWhenStart;

	public buCheckBox chk_BuzzerEnable;

	public buSpin spn_BuzzerTimeSec;

	public buSpin spn_ToolMeasureSlowApproachVelocity;

	public buButton btn_sawmeasureshowcalc;

	internal Panel _0001;

	public buButton btn_sawmeasurecalculate;

	public buSpin spn_SawDiaMeasurecalcDiameter;

	internal Panel _0002;

	public buButton btn_millingmeasurecalc;

	public buSpin spn_millingmeasurecalc;

	public buButton btn_millingmeasurecalcshow;

	internal Panel _0003;

	public buButton btn_millingheadmeasurecalc;

	public buSpin spn_millingheadmeasurecalcLEn;

	public buButton btn_millingheadmeasurecalcshow;

	internal Panel _0004;

	public buButton btn_MaterialMeasureCalc;

	public buSpin spn_MaterialMeasureCalcThickness;

	public buButton btn_MaterialMeasureCalcShow;

	internal TabPage _0015;

	internal buLabel _0017;

	public buSpin spn_ToolchangeX10;

	public buSpin spn_ToolchangeY10;

	public buSpin spn_ToolchangeZ10;

	internal buLabel _0018;

	public buSpin spn_ToolchangeX9;

	public buSpin spn_ToolchangeY9;

	public buSpin spn_ToolchangeZ9;

	internal buLabel _0019;

	public buSpin spn_ToolchangeX8;

	public buSpin spn_ToolchangeY8;

	public buSpin spn_ToolchangeZ8;

	internal buLabel _001A;

	public buSpin spn_ToolchangeX7;

	public buSpin spn_ToolchangeY7;

	public buSpin spn_ToolchangeZ7;

	internal buLabel _001B;

	public buSpin spn_ToolchangeX6;

	public buSpin spn_ToolchangeY6;

	public buSpin spn_ToolchangeZ6;

	internal buLabel _001C;

	public buSpin spn_ToolchangeX5;

	public buSpin spn_ToolchangeY5;

	public buSpin spn_ToolchangeZ5;

	internal buLabel _001D;

	public buSpin spn_ToolchangeX4;

	public buSpin spn_ToolchangeY4;

	public buSpin spn_ToolchangeZ4;

	internal buLabel _001E;

	public buSpin spn_ToolchangeX3;

	public buSpin spn_ToolchangeY3;

	public buSpin spn_ToolchangeZ3;

	internal buLabel _001F;

	public buSpin spn_ToolchangeX2;

	public buSpin spn_ToolchangeY2;

	public buSpin spn_ToolchangeZ2;

	internal buLabel _007F;

	internal buLabel _0080;

	internal buLabel _0081;

	internal buLabel _0082;

	public buSpin spn_ToolchangeX1;

	public buSpin spn_ToolchangeY1;

	public buSpin spn_ToolchangeZ1;

	public buButton btn_toolchangepositions;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal buLabel _0083;

	public buSpin spn_MaterialMeasureG54OffsetX;

	public buSpin spn_MaterialMeasureMaxSawDiameter;

	public buSpin spn_MaterialMeasureG54OffsetY;

	public buSpin spn_MaterialMeasureYBorderOffset;

	public buSpin spn_MaterialMeasureXBorderOffset;

	public buButton btn_stop;

	[NonSerialized]
	internal static GetString _001E;

	public F_MarbleMachineSettingsV1()
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
		global::_008C._007E_0002_0007(buTab_milling, new Size(1, 1));
		global::_008C._007E_0002_0007(buTab_saw, new Size(1, 1));
		global::_008C._007E_0002_0007(buTab_toolchange, new Size(1, 1));
		global::_008C._007E_0002_0007(buTab_millinghead, new Size(1, 1));
		if (Index >= 0)
		{
			global::_008D._007E_000F_0007(buTab_Main, Index);
			MenuButtonColors(Index);
		}
		else
		{
			global::_008D._007E_000F_0007(buTab_Main, 0);
			MenuButtonColors(0);
		}
		MenuButtonColorsMilling(0);
		MenuButtonColorsMillingHead(0);
		MenuButtonColorsSaw(0);
		MenuButtonColorsToolChange(0);
		global::_0095._007E_0008_0008(spn_SawMaxSpeed, clsAppMarbleVars.varApp.SawMaxSpeed);
		global::_0095._007E_0008_0008(spn_SawExtraG54OffsetX, clsAppMarbleVars.varApp.SawExtraG54OffsetX);
		global::_0095._007E_0008_0008(spn_SawExtraG54OffsetY, clsAppMarbleVars.varApp.SawExtraG54OffsetY);
		global::_0095._007E_0008_0008(spn_SawExtraG54OffsetZ, clsAppMarbleVars.varApp.SawExtraG54OffsetZ);
		global::_0095._007E_0008_0008(spn_SawStartTimerSec, clsAppMarbleVars.varApp.SawStartTimerSec);
		global::_0095._007E_0008_0008(spn_SawStopTimerSec, clsAppMarbleVars.varApp.SawStopTimerSec);
		global::_0095._007E_0008_0008(spn_SawStartTimeoutSec, clsAppMarbleVars.varApp.SawStartTimeoutSec);
		global::_0095._007E_0008_0008(spn_SawStopTimeoutSec, clsAppMarbleVars.varApp.SawStopTimeoutSec);
		global::_0082._007E_0089_0005(chk_SawSpeedAtCheck, clsAppMarbleVars.varApp.SawSpeedAtCheck);
		global::_0082._007E_0089_0005(chk_SawStopdAtCheck, clsAppMarbleVars.varApp.SawSpeedAtCheck);
		global::_0095._007E_0008_0008(spn_MillingExtraG54OffsetX, clsAppMarbleVars.varApp.MillingExtraG54OffsetX);
		global::_0095._007E_0008_0008(spn_MillingExtraG54OffsetY, clsAppMarbleVars.varApp.MillingExtraG54OffsetY);
		global::_0095._007E_0008_0008(spn_MillingExtraG54OffsetZ, clsAppMarbleVars.varApp.MillingExtraG54OffsetZ);
		global::_0095._007E_0008_0008(spn_SpindleMaxSpeed, clsAppMarbleVars.varApp.SpindleMaxSpeed);
		global::_0095._007E_0008_0008(spn_SpindleStartTimerSec, clsAppMarbleVars.varApp.SpindleStartTimerSec);
		global::_0095._007E_0008_0008(spn_SpindleStopTimerSec, clsAppMarbleVars.varApp.SpindleStopTimerSec);
		global::_0095._007E_0008_0008(spn_SpindleStartTimeoutSec, clsAppMarbleVars.varApp.SpindleStartTimeoutSec);
		global::_0095._007E_0008_0008(spn_SpindleStopTimeoutSec, clsAppMarbleVars.varApp.SpindleStopTimeoutSec);
		global::_0095._007E_0008_0008(spn_SpindleUpTimeSec, clsAppMarbleVars.varApp.SpindleUpTimeSec);
		global::_0095._007E_0008_0008(spn_SpindleDownTimeSec, clsAppMarbleVars.varApp.SpindleDownTimeSec);
		global::_0095._007E_0008_0008(spn_SpindleUpTimeOutSec, clsAppMarbleVars.varApp.SpindleUpTimeOutSec);
		global::_0095._007E_0008_0008(spn_SpindleDownTimeOutSec, clsAppMarbleVars.varApp.SpindleDownTimeOutSec);
		global::_0095._007E_0008_0008(spn_SpindleCoolAfterStopTimeSec, clsAppMarbleVars.varApp.SpindleCoolAfterStopTimeSec);
		global::_0082._007E_0089_0005(chk_SpindleSpeedAtCheck, clsAppMarbleVars.varApp.SpindleSpeedAtCheck);
		global::_0082._007E_0089_0005(chk_SpindleStopdAtCheck, clsAppMarbleVars.varApp.SpindleStopdAtCheck);
		global::_0082._007E_0089_0005(chk_SpindleCoolAfterStop, clsAppMarbleVars.varApp.SpindleCoolAfterStop);
		global::_0082._007E_0089_0005(chk_SpindlePersentageFromPLC, clsAppMarbleVars.varApp.SpindlePersentageFromPLC);
		global::_0082._007E_0089_0005(chk_SpindlePersentageSinglePot, clsAppMarbleVars.varApp.SpindlePersentageSinglePot);
		global::_0095._007E_0008_0008(spn_MillingHeadExtraG54OffsetX, clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetX);
		global::_0095._007E_0008_0008(spn_MillingHeadExtraG54OffsetY, clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetY);
		global::_0095._007E_0008_0008(spn_MillingHeadExtraG54OffsetZ, clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetZ);
		global::_0095._007E_0008_0008(spn_ToolChangePositionA, clsAppMarbleVars.varApp.ToolChangePositionA);
		global::_0095._007E_0008_0008(spn_ToolChangePositionC, clsAppMarbleVars.varApp.ToolChangePositionC);
		global::_0095._007E_0008_0008(spn_ToolChangeXSafeDistance, clsAppMarbleVars.varApp.ToolChangeXSafeDistance);
		global::_0095._007E_0008_0008(spn_ToolChangeYSafeDistance, clsAppMarbleVars.varApp.ToolChangeYSafeDistance);
		global::_0095._007E_0008_0008(spn_ToolChangeSafePositionZ, clsAppMarbleVars.varApp.ToolChangeSafePositionZ);
		global::_0095._007E_0008_0008(spn_ToolChangeUpPositionZ, clsAppMarbleVars.varApp.ToolChangeUpPositionZ);
		global::_0095._007E_0008_0008(spn_ToolChangeBeforePositionX, clsAppMarbleVars.varApp.ToolChangeBeforePositionX);
		global::_0095._007E_0008_0008(spn_ToolChangeSlowVelocity, clsAppMarbleVars.varApp.ToolChangeSlowVelocity);
		global::_0095._007E_0008_0008(spn_ToolChangeFastVelocity, clsAppMarbleVars.varApp.ToolChangeFastVelocity);
		global::_0095._007E_0008_0008(spn_ToolChangeLeaveVelocity, clsAppMarbleVars.varApp.ToolChangeLeaveVelocity);
		global::_0095._007E_0008_0008(spn_ToolChangeTakeVelocity, clsAppMarbleVars.varApp.ToolChangeTakeVelocity);
		global::_0095._007E_0008_0008(spn_ToolMillingClampOpenTimeSec, clsAppMarbleVars.varApp.ToolMillingClampOpenTimeSec);
		global::_0095._007E_0008_0008(spn_ToolMillingClampCloseTimeSec, clsAppMarbleVars.varApp.ToolMillingClampCloseTimeSec);
		global::_0095._007E_0008_0008(spn_ToolchangeX1, clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY1, clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ1, clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX2, clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY2, clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ2, clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX3, clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY3, clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ3, clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX4, clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY4, clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ4, clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX5, clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY5, clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ5, clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX6, clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY6, clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ6, clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX7, clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY7, clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ7, clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX8, clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY8, clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ8, clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX9, clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY9, clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ9, clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolchangeX10, clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.X);
		global::_0095._007E_0008_0008(spn_ToolchangeY10, clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.Y);
		global::_0095._007E_0008_0008(spn_ToolchangeZ10, clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.Z);
		global::_0095._007E_0008_0008(spn_ToolDoorOpenTimeSec, clsAppMarbleVars.varApp.AtcOpenTimeSec);
		global::_0095._007E_0008_0008(spn_ToolDoorCloseTimeSec, clsAppMarbleVars.varApp.AtcCloseTimeSec);
		global::_0095._007E_0008_0008(spn_ToolMagazineOpenTimeSec, clsAppMarbleVars.varApp.AtcForwardTimeSec);
		global::_0095._007E_0008_0008(spn_ToolMagazineCloseTimeSec, clsAppMarbleVars.varApp.AtcBackwardTimeSec);
		global::_0095._007E_0008_0008(spn_ToolDoorOpenTimeoutSec, clsAppMarbleVars.varApp.AtcOpenTimeoutSec);
		global::_0095._007E_0008_0008(spn_ToolDoorCloseTimeoutSec, clsAppMarbleVars.varApp.AtcCloseTimeoutSec);
		global::_0095._007E_0008_0008(spn_ToolMagazinOpenTimeoutSec, clsAppMarbleVars.varApp.AtcForwardTimeoutSec);
		global::_0095._007E_0008_0008(spn_ToolMagazinCloseTimeoutSec, clsAppMarbleVars.varApp.AtcBackwardTimeoutSec);
		global::_0095._007E_0008_0008(spn_SawModePositionX, clsAppMarbleVars.varApp.SawModePositionX);
		global::_0095._007E_0008_0008(spn_SawModePositionY, clsAppMarbleVars.varApp.SawModePositionY);
		global::_0095._007E_0008_0008(spn_SawModePositionZ, clsAppMarbleVars.varApp.SawModePositionZ);
		global::_0095._007E_0008_0008(spn_SawModePositionA, clsAppMarbleVars.varApp.SawModePositionA);
		global::_0095._007E_0008_0008(spn_SawModePositionC, clsAppMarbleVars.varApp.SawModePositionC);
		global::_0095._007E_0008_0008(spn_SawModePosTimeOutSec, clsAppMarbleVars.varApp.SawModePosTimeOutSec);
		global::_0095._007E_0008_0008(spn_MillingModePositionX, clsAppMarbleVars.varApp.MillingModePositionX);
		global::_0095._007E_0008_0008(spn_MillingModePositionY, clsAppMarbleVars.varApp.MillingModePositionY);
		global::_0095._007E_0008_0008(spn_MillingModePositionZ, clsAppMarbleVars.varApp.MillingModePositionZ);
		global::_0095._007E_0008_0008(spn_MillingModePositionA, clsAppMarbleVars.varApp.MillingModePositionA);
		global::_0095._007E_0008_0008(spn_MillingModePositionC, clsAppMarbleVars.varApp.MillingModePositionC);
		global::_0095._007E_0008_0008(spn_MillingModePosTimeOutSec, clsAppMarbleVars.varApp.MillingModePosTimeOutSec);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionX, clsAppMarbleVars.varApp.MillingHeadModePositionX);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionY, clsAppMarbleVars.varApp.MillingHeadModePositionY);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionZ, clsAppMarbleVars.varApp.MillingHeadModePositionZ);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionA, clsAppMarbleVars.varApp.MillingHeadModePositionA);
		global::_0095._007E_0008_0008(spn_MillingHeadModePositionC, clsAppMarbleVars.varApp.MillingHeadModePositionC);
		global::_0095._007E_0008_0008(spn_MillingHeadModePosTimeOutSec, clsAppMarbleVars.varApp.MillingHeadModePosTimeOutSec);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionX, clsAppMarbleVars.varApp.SawDiaMeasurePositionX);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionY, clsAppMarbleVars.varApp.SawDiaMeasurePositionY);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionFastZ, clsAppMarbleVars.varApp.SawDiaMeasurePositionFastZ);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionLimitZ, clsAppMarbleVars.varApp.SawDiaMeasurePositionLimitZ);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionA, clsAppMarbleVars.varApp.SawDiaMeasurePositionA);
		global::_0095._007E_0008_0008(spn_SawDiaMeasurePositionC, clsAppMarbleVars.varApp.SawDiaMeasurePositionC);
		global::_0095._007E_0008_0008(spn_SawDiaMeasureConstant, clsAppMarbleVars.varApp.SawDiaMeasureConstant);
		global::_0095._007E_0008_0008(spn_SawDiaMeasureMinDaimeter, clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter);
		global::_0095._007E_0008_0008(spn_SawDiaMeasureMaxDaimeter, clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter);
		global::_0095._007E_0008_0008(spn_SawMeasureTimeOutSec, clsAppMarbleVars.varApp.SawMeasureTimeOutSec);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionX, clsAppMarbleVars.varApp.MillingLenMeasurePositionX);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionY, clsAppMarbleVars.varApp.MillingLenMeasurePositionY);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionFastZ, clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionLimitZ, clsAppMarbleVars.varApp.MillingLenMeasurePositionLimitZ);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionA, clsAppMarbleVars.varApp.MillingLenMeasurePositionA);
		global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionC, clsAppMarbleVars.varApp.MillingLenMeasurePositionC);
		global::_0095._007E_0008_0008(spn_MillingLenMeasureConstant, clsAppMarbleVars.varApp.MillingLenMeasureConstant);
		global::_0095._007E_0008_0008(spn_MillingLenMeasureMinLength, clsAppMarbleVars.varApp.MillingLenMeasureMinLength);
		global::_0095._007E_0008_0008(spn_MillingLenMeasureMaxLength, clsAppMarbleVars.varApp.MillingLenMeasureMaxLength);
		global::_0095._007E_0008_0008(spn_MillingMeasureTimeOutSec, clsAppMarbleVars.varApp.MillingMeasureTimeOutSec);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionX, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionY, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionFastZ, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionLimitZ, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionLimitZ);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionA, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasurePositionC, clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasureConstant, clsAppMarbleVars.varApp.MillingHeadLenMeasureConstant);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasureMinLength, clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength);
		global::_0095._007E_0008_0008(spn_MillingHeadLenMeasureMaxLength, clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength);
		global::_0095._007E_0008_0008(spn_MillingHeadMeasureTimeOutSec, clsAppMarbleVars.varApp.MillingHeadMeasureTimeOutSec);
		global::_0095._007E_0008_0008(spn_ToolMeasureCoverOnTimeSec, clsAppMarbleVars.varApp.ToolMeasureCoverOnTimeSec);
		global::_0095._007E_0008_0008(spn_ToolMeasureCoverOffTimeSec, clsAppMarbleVars.varApp.ToolMeasureCoverOffTimeSec);
		global::_0095._007E_0008_0008(spn_ToolMeasureFastVelocity, clsAppMarbleVars.varApp.ToolMeasureFastVelocity);
		global::_0095._007E_0008_0008(spn_ToolMeasureSlowLeaveVelocity, clsAppMarbleVars.varApp.ToolMeasureLeaveSlowVelocity);
		global::_0095._007E_0008_0008(spn_ToolMeasureSlowApproachVelocity, clsAppMarbleVars.varApp.ToolMeasureApproachSlowVelocity);
		global::_0095._007E_0008_0008(spn_ToolMeasureAccDec, clsAppMarbleVars.varApp.ToolMeasureAccDec);
		global::_0095._007E_0008_0008(spn_ToolMeasureJerk, clsAppMarbleVars.varApp.ToolMeasureJerk);
		global::_0095._007E_0008_0008(spn_wagonposX, clsAppMarbleVars.varApp.WagonUpPositionX);
		global::_0095._007E_0008_0008(spn_wagonposY, clsAppMarbleVars.varApp.WagonUpPositionY);
		global::_0095._007E_0008_0008(spn_wagonposZ, clsAppMarbleVars.varApp.WagonUpPositionZ);
		global::_0095._007E_0008_0008(spn_wagonposA, clsAppMarbleVars.varApp.WagonUpPositionA);
		global::_0095._007E_0008_0008(spn_wagonposC, clsAppMarbleVars.varApp.WagonUpPositionC);
		global::_0095._007E_0008_0008(spn_wagonhidrostopsec, clsAppMarbleVars.varApp.WagonHidroStopSec);
		global::_0095._007E_0008_0008(spn_wagontimeout, clsAppMarbleVars.varApp.WagonPosTimeOutSec);
		global::_0095._007E_0008_0008(spn_VacuumBlowerTimeSec, clsAppMarbleVars.varApp.VacuumBlowerTimeSec);
		global::_0095._007E_0008_0008(spn_VacuumDownTimeOutSec, clsAppMarbleVars.varApp.VacuumDownTimeOutSec);
		global::_0095._007E_0008_0008(spn_VacuumDownTimeSec, clsAppMarbleVars.varApp.VacuumDownTimeSec);
		global::_0095._007E_0008_0008(spn_VacuumFastZPosition, clsAppMarbleVars.varApp.VacuumFastZPosition);
		global::_0095._007E_0008_0008(spn_VacuumInTimeoutSec, clsAppMarbleVars.varApp.VacuumInTimeoutSec);
		global::_0095._007E_0008_0008(spn_VacuumOffTimeOutSec, clsAppMarbleVars.varApp.VacuumOffTimeOutSec);
		global::_0095._007E_0008_0008(spn_VacuumOnTimeOutSec, clsAppMarbleVars.varApp.VacuumOnTimeOutSec);
		global::_0095._007E_0008_0008(spn_VacuumOutTimeoutSec, clsAppMarbleVars.varApp.VacuumOutTimeoutSec);
		global::_0095._007E_0008_0008(spn_VacuumUpTimeOutSec, clsAppMarbleVars.varApp.VacuumUpTimeOutSec);
		global::_0095._007E_0008_0008(spn_VacuumUpTimeSec, clsAppMarbleVars.varApp.VacuumUpTimeSec);
		global::_0095._007E_0008_0008(spn_MaterialMeasureAccDec, clsAppMarbleVars.varApp.MaterialMeasureAccDec);
		global::_0095._007E_0008_0008(spn_MaterialMeasureConstant, clsAppMarbleVars.varApp.MaterialMeasureConstant);
		global::_0095._007E_0008_0008(spn_MaterialMeasureFastVelocity, clsAppMarbleVars.varApp.MaterialMeasureFastVelocity);
		global::_0095._007E_0008_0008(spn_MaterialMeasureJerk, clsAppMarbleVars.varApp.MaterialMeasureJerk);
		global::_0095._007E_0008_0008(spn_MaterialMeasureMaxThickness, clsAppMarbleVars.varApp.MaterialMeasureMaxThickness);
		global::_0095._007E_0008_0008(spn_MaterialMeasureMinThickness, clsAppMarbleVars.varApp.MaterialMeasureMinThickness);
		global::_0095._007E_0008_0008(spn_MaterialMeasurePositionA, clsAppMarbleVars.varApp.MaterialMeasurePositionA);
		global::_0095._007E_0008_0008(spn_MaterialMeasurePositionC, clsAppMarbleVars.varApp.MaterialMeasurePositionC);
		global::_0095._007E_0008_0008(spn_MaterialMeasurePositionFastZ, clsAppMarbleVars.varApp.MaterialMeasurePositionFastZ);
		global::_0095._007E_0008_0008(spn_MaterialMeasurePositionLimitZ, clsAppMarbleVars.varApp.MaterialMeasurePositionLimitZ);
		global::_0095._007E_0008_0008(spn_MaterialMeasureSlowVelocity, clsAppMarbleVars.varApp.MaterialMeasureSlowVelocity);
		global::_0095._007E_0008_0008(spn_MaterialMeasureUpTimeOutSec, clsAppMarbleVars.varApp.MaterialMeasureUpTimeOutSec);
		global::_0095._007E_0008_0008(spn_MaterialMeasureG54OffsetX, clsAppMarbleVars.varApp.MaterialMeasureG54OffsetX);
		global::_0095._007E_0008_0008(spn_MaterialMeasureG54OffsetY, clsAppMarbleVars.varApp.MaterialMeasureG54OffsetY);
		global::_0095._007E_0008_0008(spn_MaterialMeasureMaxSawDiameter, clsAppMarbleVars.varApp.MaterialMeasureMaxSawDiameter);
		global::_0095._007E_0008_0008(spn_MaterialMeasureXBorderOffset, clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset);
		global::_0095._007E_0008_0008(spn_MaterialMeasureYBorderOffset, clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset);
		global::_0095._007E_0008_0008(spn_WarmUpMillingSpeed1, clsAppMarbleVars.varApp.WarmUpMillingSpeed1);
		global::_0095._007E_0008_0008(spn_WarmUpMillingSpeed2, clsAppMarbleVars.varApp.WarmUpMillingSpeed2);
		global::_0095._007E_0008_0008(spn_WarmUpMillingSpeed3, clsAppMarbleVars.varApp.WarmUpMillingSpeed3);
		global::_0095._007E_0008_0008(spn_WarmUpMillingTimeSec1, clsAppMarbleVars.varApp.WarmUpMillingTimeSec1);
		global::_0095._007E_0008_0008(spn_WarmUpMillingTimeSec2, clsAppMarbleVars.varApp.WarmUpMillingTimeSec2);
		global::_0095._007E_0008_0008(spn_WarmUpMillingTimeSec3, clsAppMarbleVars.varApp.WarmUpMillingTimeSec3);
		global::_0095._007E_0008_0008(spn_WarmUpSawSpeed1, clsAppMarbleVars.varApp.WarmUpSawSpeed1);
		global::_0095._007E_0008_0008(spn_WarmUpSawSpeed2, clsAppMarbleVars.varApp.WarmUpSawSpeed2);
		global::_0095._007E_0008_0008(spn_WarmUpSawSpeed3, clsAppMarbleVars.varApp.WarmUpSawSpeed3);
		global::_0095._007E_0008_0008(spn_WarmUpSawTimeSec1, clsAppMarbleVars.varApp.WarmUpSawTimeSec1);
		global::_0095._007E_0008_0008(spn_WarmUpSawTimeSec2, clsAppMarbleVars.varApp.WarmUpSawTimeSec2);
		global::_0095._007E_0008_0008(spn_WarmUpSawTimeSec3, clsAppMarbleVars.varApp.WarmUpSawTimeSec3);
		global::_0095._007E_0008_0008(spn_LubricationBlockOnOffTimeSec, clsAppMarbleVars.varApp.LubricationBlockOnOffTimeSec);
		global::_0095._007E_0008_0008(spn_LubricationLevelOnOffTimeSec, clsAppMarbleVars.varApp.LubricationLevelOnOffTimeSec);
		global::_0095._007E_0008_0008(spn_LubricationPeriodWaitMin, clsAppMarbleVars.varApp.LubricationPeriodWaitMin);
		global::_0095._007E_0008_0008(spn_LubricationTimeSec, clsAppMarbleVars.varApp.LubricationTimeSec);
		global::_0082._007E_0089_0005(chk_LubricationEnable, clsAppMarbleVars.varApp.LubricationEnable);
		global::_0095._007E_0008_0008(spn_parkpositionx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_parkpositionY, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_parkpositionZ, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_parkpositionA, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_parkpositionC, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition);
		global::_0095._007E_0008_0008(spn_ParkPosTimeOutSec, clsAppMarbleVars.varApp.ParkPosTimeOutSec);
		global::_0082._007E_0089_0005(chk_ServoAAxis, clsAppMarbleVars.varApp.OptionServoAxisA);
		global::_0095._007E_0008_0008(spn_AAxisAllowedZSafePosition, clsAppMarbleVars.varApp.AAxisAllowedZSafePosition);
		global::_0095._007E_0008_0008(spn_AAxisTimeOutSec, clsAppMarbleVars.varApp.AAxisTimeOutSec);
		global::_0095._007E_0008_0008(spn_AAxisExtraTimeSec, clsAppMarbleVars.varApp.AAxisExtraTimeSec);
		global::_0082._007E_0089_0005(chk_BuzzerEnable, clsAppMarbleVars.varApp.BuzzerEnable);
		global::_0095._007E_0008_0008(spn_BuzzerTimeSec, clsAppMarbleVars.varApp.BuzzerTimeSec);
		global::_0082._007E_0089_0005(chk_GoZUpPositionWhenStart, clsAppMarbleVars.varApp.GoZUpPositionWhenStart);
		global::_0095._007E_0008_0008(spn_StartPointPosTimeOutSec, clsAppMarbleVars.varApp.StartPointPosTimeOutSec);
		global::_0095._007E_0008_0008(spn_LaserOnOffTimerSec, clsAppMarbleVars.varApp.LaserOnOffTimerSec);
		global::_0095._007E_0008_0008(spn_WaterOnOffTimerSec, clsAppMarbleVars.varApp.WaterOnOffTimerSec);
		if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.ParkPosition)
		{
			global::_0082._007E_009E_0005(this._0002, true);
		}
		else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.UserParkPosition)
		{
			global::_0082._007E_009E_0005(_0003, true);
		}
		else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.SafeDistance)
		{
			global::_0082._007E_009E_0005(this._0001, true);
		}
		global::_0095._007E_0008_0008(spn_CameraPosTimeOutSec, clsAppMarbleVars.varApp.CameraPosTimeOutSec);
		global::_0095._007E_0008_0008(spn_CameraTableXOffsetPos, clsAppMarbleVars.varApp.CameraTableXOffsetPos);
		global::_0095._007E_0008_0008(spn_CameraTableYOffsetPos, clsAppMarbleVars.varApp.CameraTableYOffsetPos);
		global::_0095._007E_0008_0008(spn_CameraPositionA, clsAppMarbleVars.varApp.CameraPositionA);
		global::_0095._007E_0008_0008(spn_CameraPositionC, clsAppMarbleVars.varApp.CameraPositionC);
		global::_0095._007E_0008_0008(spn_CameraPositionX, clsAppMarbleVars.varApp.CameraPositionX);
		global::_0095._007E_0008_0008(spn_CameraPositionY, clsAppMarbleVars.varApp.CameraPositionY);
		global::_0095._007E_0008_0008(spn_CameraPositionZ, clsAppMarbleVars.varApp.CameraPositionZ);
		global::_0095._007E_0008_0008(spn_CameraAutoCloseTimeSec, clsAppMarbleVars.varApp.CameraAutoCloseTimeSec);
		global::_0095._007E_0008_0008(spn_CameraCoverOpenTimeSec, clsAppMarbleVars.varApp.CameraCoverOpenTimeSec);
		global::_0095._007E_0008_0008(spn_CameraEnableTimeSec, clsAppMarbleVars.varApp.CameraEnableTimeSec);
		global::_0082._007E_0089_0005(chk_CameraAutoCloseEnable, clsAppMarbleVars.varApp.CameraAutoCloseEnable);
		global::_0082._007E_0089_0005(chk_CameraCoverAutoCloseEnable, clsAppMarbleVars.varApp.CameraCoverAutoCloseEnable);
		global::_0082._007E_0089_0005(chk_CameraCoverAvailable, clsAppMarbleVars.varApp.CameraCoverAvailable);
		global::_0082._007E_0089_0005(chk_CameraPowerAvailable, clsAppMarbleVars.varApp.CameraPowerAvailable);
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
		clsAppMarbleVars.varApp.SawMaxSpeed = global::_0007._007E_0094(spn_SawMaxSpeed);
		clsAppMarbleVars.varApp.SawExtraG54OffsetX = global::_0007._007E_0094(spn_SawExtraG54OffsetX);
		clsAppMarbleVars.varApp.SawExtraG54OffsetY = global::_0007._007E_0094(spn_SawExtraG54OffsetY);
		clsAppMarbleVars.varApp.SawExtraG54OffsetZ = global::_0007._007E_0094(spn_SawExtraG54OffsetZ);
		clsAppMarbleVars.varApp.SawStartTimerSec = global::_0007._007E_0094(spn_SawStartTimerSec);
		clsAppMarbleVars.varApp.SawStopTimerSec = global::_0007._007E_0094(spn_SawStopTimerSec);
		clsAppMarbleVars.varApp.SawStartTimeoutSec = global::_0007._007E_0094(spn_SawStartTimeoutSec);
		clsAppMarbleVars.varApp.SawStopTimeoutSec = global::_0007._007E_0094(spn_SawStopTimeoutSec);
		clsAppMarbleVars.varApp.SawSpeedAtCheck = global::_0003._007E_0010(chk_SawSpeedAtCheck);
		clsAppMarbleVars.varApp.SawSpeedAtCheck = global::_0003._007E_0010(chk_SawStopdAtCheck);
		clsAppMarbleVars.varApp.MillingExtraG54OffsetX = global::_0007._007E_0094(spn_MillingExtraG54OffsetX);
		clsAppMarbleVars.varApp.MillingExtraG54OffsetY = global::_0007._007E_0094(spn_MillingExtraG54OffsetY);
		clsAppMarbleVars.varApp.MillingExtraG54OffsetZ = global::_0007._007E_0094(spn_MillingExtraG54OffsetZ);
		clsAppMarbleVars.varApp.SpindleMaxSpeed = global::_0007._007E_0094(spn_SpindleMaxSpeed);
		clsAppMarbleVars.varApp.SpindleStartTimerSec = global::_0007._007E_0094(spn_SpindleStartTimerSec);
		clsAppMarbleVars.varApp.SpindleStopTimerSec = global::_0007._007E_0094(spn_SpindleStopTimerSec);
		clsAppMarbleVars.varApp.SpindleStartTimeoutSec = global::_0007._007E_0094(spn_SpindleStartTimeoutSec);
		clsAppMarbleVars.varApp.SpindleStopTimeoutSec = global::_0007._007E_0094(spn_SpindleStopTimeoutSec);
		clsAppMarbleVars.varApp.SpindleUpTimeSec = global::_0007._007E_0094(spn_SpindleUpTimeSec);
		clsAppMarbleVars.varApp.SpindleDownTimeSec = global::_0007._007E_0094(spn_SpindleDownTimeSec);
		clsAppMarbleVars.varApp.SpindleUpTimeOutSec = global::_0007._007E_0094(spn_SpindleUpTimeOutSec);
		clsAppMarbleVars.varApp.SpindleDownTimeOutSec = global::_0007._007E_0094(spn_SpindleDownTimeOutSec);
		clsAppMarbleVars.varApp.SpindleCoolAfterStopTimeSec = global::_0007._007E_0094(spn_SpindleCoolAfterStopTimeSec);
		clsAppMarbleVars.varApp.SpindleSpeedAtCheck = global::_0003._007E_0010(chk_SpindleSpeedAtCheck);
		clsAppMarbleVars.varApp.SpindleStopdAtCheck = global::_0003._007E_0010(chk_SpindleStopdAtCheck);
		clsAppMarbleVars.varApp.SpindleCoolAfterStop = global::_0003._007E_0010(chk_SpindleCoolAfterStop);
		clsAppMarbleVars.varApp.SpindlePersentageFromPLC = global::_0003._007E_0010(chk_SpindlePersentageFromPLC);
		clsAppMarbleVars.varApp.SpindlePersentageSinglePot = global::_0003._007E_0010(chk_SpindlePersentageSinglePot);
		clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetX = global::_0007._007E_0094(spn_MillingHeadExtraG54OffsetX);
		clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetY = global::_0007._007E_0094(spn_MillingHeadExtraG54OffsetY);
		clsAppMarbleVars.varApp.MillingHeadExtraG54OffsetZ = global::_0007._007E_0094(spn_MillingHeadExtraG54OffsetZ);
		if (uint.MaxValue != 0)
		{
			clsAppMarbleVars.varApp.ToolChangePositionA = global::_0007._007E_0094(spn_ToolChangePositionA);
			clsAppMarbleVars.varApp.ToolChangePositionC = global::_0007._007E_0094(spn_ToolChangePositionC);
			clsAppMarbleVars.varApp.ToolChangeXSafeDistance = global::_0007._007E_0094(spn_ToolChangeXSafeDistance);
			clsAppMarbleVars.varApp.ToolChangeYSafeDistance = global::_0007._007E_0094(spn_ToolChangeYSafeDistance);
			clsAppMarbleVars.varApp.ToolChangeSafePositionZ = global::_0007._007E_0094(spn_ToolChangeSafePositionZ);
			clsAppMarbleVars.varApp.ToolChangeUpPositionZ = global::_0007._007E_0094(spn_ToolChangeUpPositionZ);
			clsAppMarbleVars.varApp.ToolChangeBeforePositionX = global::_0007._007E_0094(spn_ToolChangeBeforePositionX);
			clsAppMarbleVars.varApp.ToolChangeSlowVelocity = global::_0007._007E_0094(spn_ToolChangeSlowVelocity);
			clsAppMarbleVars.varApp.ToolChangeFastVelocity = global::_0007._007E_0094(spn_ToolChangeFastVelocity);
			clsAppMarbleVars.varApp.ToolChangeLeaveVelocity = global::_0007._007E_0094(spn_ToolChangeLeaveVelocity);
			clsAppMarbleVars.varApp.ToolChangeTakeVelocity = global::_0007._007E_0094(spn_ToolChangeTakeVelocity);
			clsAppMarbleVars.varApp.ToolMillingClampOpenTimeSec = global::_0007._007E_0094(spn_ToolMillingClampOpenTimeSec);
			clsAppMarbleVars.varApp.ToolMillingClampCloseTimeSec = global::_0007._007E_0094(spn_ToolMillingClampCloseTimeSec);
			clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX1);
			clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY1);
			clsAppMarbleVars.cMachine.ToolList[1].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ1);
			clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX2);
			clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY2);
			clsAppMarbleVars.cMachine.ToolList[2].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ2);
			clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX3);
			clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY3);
			clsAppMarbleVars.cMachine.ToolList[3].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ3);
			clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX4);
			clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY4);
			clsAppMarbleVars.cMachine.ToolList[4].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ4);
			clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX5);
			clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY5);
			clsAppMarbleVars.cMachine.ToolList[5].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ5);
			clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX6);
			clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY6);
			clsAppMarbleVars.cMachine.ToolList[6].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ6);
			clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX7);
			clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY7);
			clsAppMarbleVars.cMachine.ToolList[7].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ7);
			clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX8);
			clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY8);
			clsAppMarbleVars.cMachine.ToolList[8].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ8);
			clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX9);
			clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY9);
			clsAppMarbleVars.cMachine.ToolList[9].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ9);
			clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX10);
			clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY10);
			clsAppMarbleVars.cMachine.ToolList[10].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ10);
			clsAppMarbleVars.varApp.AtcOpenTimeSec = global::_0007._007E_0094(spn_ToolDoorOpenTimeSec);
			clsAppMarbleVars.varApp.AtcCloseTimeSec = global::_0007._007E_0094(spn_ToolDoorCloseTimeSec);
			clsAppMarbleVars.varApp.AtcForwardTimeSec = global::_0007._007E_0094(spn_ToolMagazineOpenTimeSec);
			clsAppMarbleVars.varApp.AtcBackwardTimeSec = global::_0007._007E_0094(spn_ToolMagazineCloseTimeSec);
			clsAppMarbleVars.varApp.AtcOpenTimeoutSec = global::_0007._007E_0094(spn_ToolDoorOpenTimeoutSec);
			clsAppMarbleVars.varApp.AtcCloseTimeoutSec = global::_0007._007E_0094(spn_ToolDoorCloseTimeoutSec);
			clsAppMarbleVars.varApp.AtcForwardTimeoutSec = global::_0007._007E_0094(spn_ToolMagazinOpenTimeoutSec);
			clsAppMarbleVars.varApp.AtcBackwardTimeoutSec = global::_0007._007E_0094(spn_ToolMagazinCloseTimeoutSec);
			goto IL_0a73;
		}
		goto IL_0db3;
		IL_0db3:
		clsAppMarbleVars.varApp.MillingLenMeasurePositionA = global::_0007._007E_0094(spn_MillingLenMeasurePositionA);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionC = global::_0007._007E_0094(spn_MillingLenMeasurePositionC);
		clsAppMarbleVars.varApp.MillingLenMeasureConstant = global::_0007._007E_0094(spn_MillingLenMeasureConstant);
		clsAppMarbleVars.varApp.MillingLenMeasureMinLength = global::_0007._007E_0094(spn_MillingLenMeasureMinLength);
		clsAppMarbleVars.varApp.MillingLenMeasureMaxLength = global::_0007._007E_0094(spn_MillingLenMeasureMaxLength);
		clsAppMarbleVars.varApp.MillingMeasureTimeOutSec = global::_0007._007E_0094(spn_MillingMeasureTimeOutSec);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionX);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionY);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionFastZ);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionLimitZ = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionLimitZ);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionA);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionC);
		clsAppMarbleVars.varApp.MillingHeadLenMeasureConstant = global::_0007._007E_0094(spn_MillingHeadLenMeasureConstant);
		clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength = global::_0007._007E_0094(spn_MillingHeadLenMeasureMinLength);
		clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength = global::_0007._007E_0094(spn_MillingHeadLenMeasureMaxLength);
		clsAppMarbleVars.varApp.MillingHeadMeasureTimeOutSec = global::_0007._007E_0094(spn_MillingHeadMeasureTimeOutSec);
		clsAppMarbleVars.varApp.ToolMeasureCoverOnTimeSec = global::_0007._007E_0094(spn_ToolMeasureCoverOnTimeSec);
		clsAppMarbleVars.varApp.ToolMeasureCoverOffTimeSec = global::_0007._007E_0094(spn_ToolMeasureCoverOffTimeSec);
		clsAppMarbleVars.varApp.ToolMeasureFastVelocity = global::_0007._007E_0094(spn_ToolMeasureFastVelocity);
		clsAppMarbleVars.varApp.ToolMeasureLeaveSlowVelocity = global::_0007._007E_0094(spn_ToolMeasureSlowLeaveVelocity);
		clsAppMarbleVars.varApp.ToolMeasureApproachSlowVelocity = global::_0007._007E_0094(spn_ToolMeasureSlowApproachVelocity);
		clsAppMarbleVars.varApp.ToolMeasureAccDec = global::_0007._007E_0094(spn_ToolMeasureAccDec);
		clsAppMarbleVars.varApp.ToolMeasureJerk = global::_0007._007E_0094(spn_ToolMeasureJerk);
		clsAppMarbleVars.varApp.WagonUpPositionX = global::_0007._007E_0094(spn_wagonposX);
		clsAppMarbleVars.varApp.WagonUpPositionY = global::_0007._007E_0094(spn_wagonposY);
		clsAppMarbleVars.varApp.WagonUpPositionZ = global::_0007._007E_0094(spn_wagonposZ);
		clsAppMarbleVars.varApp.WagonUpPositionA = global::_0007._007E_0094(spn_wagonposA);
		clsAppMarbleVars.varApp.WagonUpPositionC = global::_0007._007E_0094(spn_wagonposC);
		clsAppMarbleVars.varApp.WagonHidroStopSec = global::_0007._007E_0094(spn_wagonhidrostopsec);
		clsAppMarbleVars.varApp.WagonPosTimeOutSec = global::_0007._007E_0094(spn_wagontimeout);
		clsAppMarbleVars.varApp.VacuumBlowerTimeSec = global::_0007._007E_0094(spn_VacuumBlowerTimeSec);
		clsAppMarbleVars.varApp.VacuumDownTimeOutSec = global::_0007._007E_0094(spn_VacuumDownTimeOutSec);
		clsAppMarbleVars.varApp.VacuumDownTimeSec = global::_0007._007E_0094(spn_VacuumDownTimeSec);
		clsAppMarbleVars.varApp.VacuumFastZPosition = global::_0007._007E_0094(spn_VacuumFastZPosition);
		clsAppMarbleVars.varApp.VacuumInTimeoutSec = global::_0007._007E_0094(spn_VacuumInTimeoutSec);
		clsAppMarbleVars.varApp.VacuumOffTimeOutSec = global::_0007._007E_0094(spn_VacuumOffTimeOutSec);
		clsAppMarbleVars.varApp.VacuumOnTimeOutSec = global::_0007._007E_0094(spn_VacuumOnTimeOutSec);
		clsAppMarbleVars.varApp.VacuumOutTimeoutSec = global::_0007._007E_0094(spn_VacuumOutTimeoutSec);
		clsAppMarbleVars.varApp.VacuumUpTimeOutSec = global::_0007._007E_0094(spn_VacuumUpTimeOutSec);
		clsAppMarbleVars.varApp.VacuumUpTimeSec = global::_0007._007E_0094(spn_VacuumUpTimeSec);
		clsAppMarbleVars.varApp.MaterialMeasureAccDec = global::_0007._007E_0094(spn_MaterialMeasureAccDec);
		clsAppMarbleVars.varApp.MaterialMeasureConstant = global::_0007._007E_0094(spn_MaterialMeasureConstant);
		clsAppMarbleVars.varApp.MaterialMeasureFastVelocity = global::_0007._007E_0094(spn_MaterialMeasureFastVelocity);
		clsAppMarbleVars.varApp.MaterialMeasureJerk = global::_0007._007E_0094(spn_MaterialMeasureJerk);
		clsAppMarbleVars.varApp.MaterialMeasureMaxThickness = global::_0007._007E_0094(spn_MaterialMeasureMaxThickness);
		clsAppMarbleVars.varApp.MaterialMeasureMinThickness = global::_0007._007E_0094(spn_MaterialMeasureMinThickness);
		clsAppMarbleVars.varApp.MaterialMeasurePositionA = global::_0007._007E_0094(spn_MaterialMeasurePositionA);
		clsAppMarbleVars.varApp.MaterialMeasurePositionC = global::_0007._007E_0094(spn_MaterialMeasurePositionC);
		clsAppMarbleVars.varApp.MaterialMeasurePositionFastZ = global::_0007._007E_0094(spn_MaterialMeasurePositionFastZ);
		clsAppMarbleVars.varApp.MaterialMeasurePositionLimitZ = global::_0007._007E_0094(spn_MaterialMeasurePositionLimitZ);
		clsAppMarbleVars.varApp.MaterialMeasureSlowVelocity = global::_0007._007E_0094(spn_MaterialMeasureSlowVelocity);
		clsAppMarbleVars.varApp.MaterialMeasureUpTimeOutSec = global::_0007._007E_0094(spn_MaterialMeasureUpTimeOutSec);
		clsAppMarbleVars.varApp.MaterialMeasureG54OffsetX = global::_0007._007E_0094(spn_MaterialMeasureG54OffsetX);
		clsAppMarbleVars.varApp.MaterialMeasureG54OffsetY = global::_0007._007E_0094(spn_MaterialMeasureG54OffsetY);
		clsAppMarbleVars.varApp.MaterialMeasureMaxSawDiameter = global::_0007._007E_0094(spn_MaterialMeasureMaxSawDiameter);
		clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset = global::_0007._007E_0094(spn_MaterialMeasureXBorderOffset);
		clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset = global::_0007._007E_0094(spn_MaterialMeasureYBorderOffset);
		clsAppMarbleVars.varApp.WarmUpMillingSpeed1 = global::_0007._007E_0094(spn_WarmUpMillingSpeed1);
		clsAppMarbleVars.varApp.WarmUpMillingSpeed2 = global::_0007._007E_0094(spn_WarmUpMillingSpeed2);
		clsAppMarbleVars.varApp.WarmUpMillingSpeed3 = global::_0007._007E_0094(spn_WarmUpMillingSpeed3);
		clsAppMarbleVars.varApp.WarmUpMillingTimeSec1 = global::_0007._007E_0094(spn_WarmUpMillingTimeSec1);
		clsAppMarbleVars.varApp.WarmUpMillingTimeSec2 = global::_0007._007E_0094(spn_WarmUpMillingTimeSec2);
		clsAppMarbleVars.varApp.WarmUpMillingTimeSec3 = global::_0007._007E_0094(spn_WarmUpMillingTimeSec3);
		clsAppMarbleVars.varApp.WarmUpSawSpeed1 = global::_0007._007E_0094(spn_WarmUpSawSpeed1);
		clsAppMarbleVars.varApp.WarmUpSawSpeed2 = global::_0007._007E_0094(spn_WarmUpSawSpeed2);
		clsAppMarbleVars.varApp.WarmUpSawSpeed3 = global::_0007._007E_0094(spn_WarmUpSawSpeed3);
		clsAppMarbleVars.varApp.WarmUpSawTimeSec1 = global::_0007._007E_0094(spn_WarmUpSawTimeSec1);
		clsAppMarbleVars.varApp.WarmUpSawTimeSec2 = global::_0007._007E_0094(spn_WarmUpSawTimeSec2);
		clsAppMarbleVars.varApp.WarmUpSawTimeSec3 = global::_0007._007E_0094(spn_WarmUpSawTimeSec3);
		clsAppMarbleVars.varApp.LubricationBlockOnOffTimeSec = global::_0007._007E_0094(spn_LubricationBlockOnOffTimeSec);
		clsAppMarbleVars.varApp.LubricationLevelOnOffTimeSec = global::_0007._007E_0094(spn_LubricationLevelOnOffTimeSec);
		clsAppMarbleVars.varApp.LubricationPeriodWaitMin = global::_0007._007E_0094(spn_LubricationPeriodWaitMin);
		clsAppMarbleVars.varApp.LubricationTimeSec = global::_0007._007E_0094(spn_LubricationTimeSec);
		clsAppMarbleVars.varApp.LubricationEnable = global::_0003._007E_0010(chk_LubricationEnable);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_parkpositionx);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_parkpositionY);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_parkpositionZ);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_parkpositionA);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_parkpositionC);
		clsAppMarbleVars.varApp.ParkPosTimeOutSec = global::_0007._007E_0094(spn_ParkPosTimeOutSec);
		clsAppMarbleVars.varApp.OptionServoAxisA = global::_0003._007E_0010(chk_ServoAAxis);
		clsAppMarbleVars.varApp.AAxisAllowedZSafePosition = global::_0007._007E_0094(spn_AAxisAllowedZSafePosition);
		clsAppMarbleVars.varApp.AAxisTimeOutSec = global::_0007._007E_0094(spn_AAxisTimeOutSec);
		if (0 == 0)
		{
			clsAppMarbleVars.varApp.AAxisExtraTimeSec = global::_0007._007E_0094(spn_AAxisExtraTimeSec);
			clsAppMarbleVars.varApp.BuzzerEnable = global::_0003._007E_0010(chk_BuzzerEnable);
			clsAppMarbleVars.varApp.BuzzerTimeSec = global::_0007._007E_0094(spn_BuzzerTimeSec);
			clsAppMarbleVars.varApp.GoZUpPositionWhenStart = global::_0003._007E_0010(chk_GoZUpPositionWhenStart);
			clsAppMarbleVars.varApp.StartPointPosTimeOutSec = global::_0007._007E_0094(spn_StartPointPosTimeOutSec);
			clsAppMarbleVars.varApp.LaserOnOffTimerSec = global::_0007._007E_0094(spn_LaserOnOffTimerSec);
			clsAppMarbleVars.varApp.WaterOnOffTimerSec = global::_0007._007E_0094(spn_WaterOnOffTimerSec);
			if (global::_0003._007E_0017(this._0002))
			{
				clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.ParkPosition;
			}
			else if (global::_0003._007E_0017(this._0001))
			{
				clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.SafeDistance;
			}
			else
			{
				clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.UserParkPosition;
			}
			clsAppMarbleVars.varApp.CameraPosTimeOutSec = global::_0007._007E_0094(spn_CameraPosTimeOutSec);
			clsAppMarbleVars.varApp.CameraTableXOffsetPos = global::_0007._007E_0094(spn_CameraTableXOffsetPos);
			clsAppMarbleVars.varApp.CameraTableYOffsetPos = global::_0007._007E_0094(spn_CameraTableYOffsetPos);
			clsAppMarbleVars.varApp.CameraPositionA = global::_0007._007E_0094(spn_CameraPositionA);
			clsAppMarbleVars.varApp.CameraPositionC = global::_0007._007E_0094(spn_CameraPositionC);
			clsAppMarbleVars.varApp.CameraPositionX = global::_0007._007E_0094(spn_CameraPositionX);
			clsAppMarbleVars.varApp.CameraPositionY = global::_0007._007E_0094(spn_CameraPositionY);
			clsAppMarbleVars.varApp.CameraPositionZ = global::_0007._007E_0094(spn_CameraPositionZ);
			clsAppMarbleVars.varApp.CameraAutoCloseTimeSec = global::_0007._007E_0094(spn_CameraAutoCloseTimeSec);
			clsAppMarbleVars.varApp.CameraCoverOpenTimeSec = global::_0007._007E_0094(spn_CameraCoverOpenTimeSec);
			clsAppMarbleVars.varApp.CameraEnableTimeSec = global::_0007._007E_0094(spn_CameraEnableTimeSec);
			clsAppMarbleVars.varApp.CameraAutoCloseEnable = global::_0003._007E_0010(chk_CameraAutoCloseEnable);
			clsAppMarbleVars.varApp.CameraCoverAutoCloseEnable = global::_0003._007E_0010(chk_CameraCoverAutoCloseEnable);
			clsAppMarbleVars.varApp.CameraCoverAvailable = global::_0003._007E_0010(chk_CameraCoverAvailable);
			clsAppMarbleVars.varApp.CameraPowerAvailable = global::_0003._007E_0010(chk_CameraPowerAvailable);
			return;
		}
		goto IL_0a73;
		IL_0a73:
		clsAppMarbleVars.varApp.SawModePositionX = global::_0007._007E_0094(spn_SawModePositionX);
		clsAppMarbleVars.varApp.SawModePositionY = global::_0007._007E_0094(spn_SawModePositionY);
		clsAppMarbleVars.varApp.SawModePositionZ = global::_0007._007E_0094(spn_SawModePositionZ);
		clsAppMarbleVars.varApp.SawModePositionA = global::_0007._007E_0094(spn_SawModePositionA);
		clsAppMarbleVars.varApp.SawModePositionC = global::_0007._007E_0094(spn_SawModePositionC);
		clsAppMarbleVars.varApp.SawModePosTimeOutSec = global::_0007._007E_0094(spn_SawModePosTimeOutSec);
		clsAppMarbleVars.varApp.MillingModePositionX = global::_0007._007E_0094(spn_MillingModePositionX);
		clsAppMarbleVars.varApp.MillingModePositionY = global::_0007._007E_0094(spn_MillingModePositionY);
		clsAppMarbleVars.varApp.MillingModePositionZ = global::_0007._007E_0094(spn_MillingModePositionZ);
		clsAppMarbleVars.varApp.MillingModePositionA = global::_0007._007E_0094(spn_MillingModePositionA);
		clsAppMarbleVars.varApp.MillingModePositionC = global::_0007._007E_0094(spn_MillingModePositionC);
		clsAppMarbleVars.varApp.MillingModePosTimeOutSec = global::_0007._007E_0094(spn_MillingModePosTimeOutSec);
		clsAppMarbleVars.varApp.MillingHeadModePositionX = global::_0007._007E_0094(spn_MillingHeadModePositionX);
		clsAppMarbleVars.varApp.MillingHeadModePositionY = global::_0007._007E_0094(spn_MillingHeadModePositionY);
		clsAppMarbleVars.varApp.MillingHeadModePositionZ = global::_0007._007E_0094(spn_MillingHeadModePositionZ);
		clsAppMarbleVars.varApp.MillingHeadModePositionA = global::_0007._007E_0094(spn_MillingHeadModePositionA);
		clsAppMarbleVars.varApp.MillingHeadModePositionC = global::_0007._007E_0094(spn_MillingHeadModePositionC);
		clsAppMarbleVars.varApp.MillingHeadModePosTimeOutSec = global::_0007._007E_0094(spn_MillingHeadModePosTimeOutSec);
		clsAppMarbleVars.varApp.SawDiaMeasurePositionX = global::_0007._007E_0094(spn_SawDiaMeasurePositionX);
		clsAppMarbleVars.varApp.SawDiaMeasurePositionY = global::_0007._007E_0094(spn_SawDiaMeasurePositionY);
		clsAppMarbleVars.varApp.SawDiaMeasurePositionFastZ = global::_0007._007E_0094(spn_SawDiaMeasurePositionFastZ);
		clsAppMarbleVars.varApp.SawDiaMeasurePositionLimitZ = global::_0007._007E_0094(spn_SawDiaMeasurePositionLimitZ);
		clsAppMarbleVars.varApp.SawDiaMeasurePositionA = global::_0007._007E_0094(spn_SawDiaMeasurePositionA);
		clsAppMarbleVars.varApp.SawDiaMeasurePositionC = global::_0007._007E_0094(spn_SawDiaMeasurePositionC);
		clsAppMarbleVars.varApp.SawDiaMeasureConstant = global::_0007._007E_0094(spn_SawDiaMeasureConstant);
		clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter = global::_0007._007E_0094(spn_SawDiaMeasureMinDaimeter);
		clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter = global::_0007._007E_0094(spn_SawDiaMeasureMaxDaimeter);
		clsAppMarbleVars.varApp.SawMeasureTimeOutSec = global::_0007._007E_0094(spn_SawMeasureTimeOutSec);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionX = global::_0007._007E_0094(spn_MillingLenMeasurePositionX);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionY = global::_0007._007E_0094(spn_MillingLenMeasurePositionY);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ = global::_0007._007E_0094(spn_MillingLenMeasurePositionFastZ);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionLimitZ = global::_0007._007E_0094(spn_MillingLenMeasurePositionLimitZ);
		goto IL_0db3;
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(buGround1);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		if (PageIndex == 0)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_saw)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_saw)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 1)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_milling)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_milling)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millinghead)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millinghead)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 3)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolchange)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolchange)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 4)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 5)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_troller)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_troller)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 6)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_camera)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_camera)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 7)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_vacuum)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_vacuum)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 8)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_materialmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_materialmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		bool num = PageIndex == 9;
		if (true)
		{
			if (num)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_warmup)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_warmup)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 10)
			{
				goto IL_0596;
			}
			goto IL_0614;
		}
		goto IL_0619;
		IL_0614:
		num = PageIndex == 11;
		goto IL_0619;
		IL_0619:
		if (num)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_park)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_park)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 12)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_axisA)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_axisA)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			if (false)
			{
				goto IL_0596;
			}
		}
		if (PageIndex == 13)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_misc)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_misc)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		return;
		IL_0596:
		global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_lubrication)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_lubrication)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		goto IL_0614;
	}

	public void MenuButtonColorsSaw(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(tabPage_saw);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		bool num = PageIndex == 0;
		bool flag;
		if (5u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			if (false)
			{
				goto IL_0154;
			}
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawdata)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawdata)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			if (false)
			{
				goto IL_00d3;
			}
		}
		bool flag2 = PageIndex == 1;
		goto IL_00d3;
		IL_0154:
		bool num2 = PageIndex == 2;
		do
		{
			bool flag3 = num2;
			num2 = flag3;
		}
		while (8 == 0);
		if (num2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		return;
		IL_00d3:
		if (flag2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawpark)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawpark)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		goto IL_0154;
	}

	public void MenuButtonColorsMilling(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(tabPage_milling);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		bool num = PageIndex == 0;
		bool flag;
		if (5u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			if (false)
			{
				goto IL_0154;
			}
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingdata)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingdata)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			if (false)
			{
				goto IL_00d3;
			}
		}
		bool flag2 = PageIndex == 1;
		goto IL_00d3;
		IL_0154:
		bool num2 = PageIndex == 2;
		do
		{
			bool flag3 = num2;
			num2 = flag3;
		}
		while (8 == 0);
		if (num2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		return;
		IL_00d3:
		if (flag2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingpark)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingpark)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		goto IL_0154;
	}

	public void MenuButtonColorsMillingHead(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(this._0001);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		bool num = PageIndex == 0;
		bool flag;
		if (5u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			if (false)
			{
				goto IL_0154;
			}
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingheaddata)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingheaddata)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			if (false)
			{
				goto IL_00d3;
			}
		}
		bool flag2 = PageIndex == 1;
		goto IL_00d3;
		IL_0154:
		bool num2 = PageIndex == 2;
		do
		{
			bool flag3 = num2;
			num2 = flag3;
		}
		while (8 == 0);
		if (num2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingheadmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingheadmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		return;
		IL_00d3:
		if (flag2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingheadpark)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingheadpark)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		goto IL_0154;
	}

	public void MenuButtonColorsToolChange(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(this._0002);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		bool num = PageIndex == 0;
		bool flag;
		if (5u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			if (false)
			{
				goto IL_0154;
			}
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolchangedata)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolchangedata)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			if (false)
			{
				goto IL_00d3;
			}
		}
		bool flag2 = PageIndex == 1;
		goto IL_00d3;
		IL_0154:
		bool num2 = PageIndex == 2;
		do
		{
			bool flag3 = num2;
			num2 = flag3;
		}
		while (8 == 0);
		if (num2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolchangepositions)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolchangepositions)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		return;
		IL_00d3:
		if (flag2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolchangetimes)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolchangetimes)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		goto IL_0154;
	}

	internal void _0001(object P_0, EventArgs P_1)
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
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
			}
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_saw)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 0);
				MenuButtonColors(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawdata)))
			{
				global::_008D._007E_000F_0007(buTab_saw, 0);
				MenuButtonColorsSaw(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawpark)))
			{
				global::_008D._007E_000F_0007(buTab_saw, 1);
				MenuButtonColorsSaw(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasure)))
			{
				global::_008D._007E_000F_0007(buTab_saw, 2);
				MenuButtonColorsSaw(2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_milling)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 1);
				MenuButtonColors(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingdata)))
			{
				global::_008D._007E_000F_0007(buTab_milling, 0);
				MenuButtonColorsMilling(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingpark)))
			{
				global::_008D._007E_000F_0007(buTab_milling, 1);
				MenuButtonColorsMilling(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasure)))
			{
				global::_008D._007E_000F_0007(buTab_milling, 2);
				MenuButtonColorsMilling(2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millinghead)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 2);
				MenuButtonColors(2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheaddata)))
			{
				global::_008D._007E_000F_0007(buTab_millinghead, 0);
				MenuButtonColorsMillingHead(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadpark)))
			{
				global::_008D._007E_000F_0007(buTab_millinghead, 1);
				MenuButtonColorsMillingHead(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasure)))
			{
				global::_008D._007E_000F_0007(buTab_millinghead, 2);
				MenuButtonColorsMillingHead(2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolchange)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 3);
				MenuButtonColors(3);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolchangedata)))
			{
				global::_008D._007E_000F_0007(buTab_toolchange, 0);
				MenuButtonColorsToolChange(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolchangetimes)))
			{
				global::_008D._007E_000F_0007(buTab_toolchange, 1);
				MenuButtonColorsToolChange(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolchangepositions)))
			{
				global::_008D._007E_000F_0007(buTab_toolchange, 2);
				MenuButtonColorsToolChange(2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolmeasure)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 4);
				MenuButtonColors(4);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_troller)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 5);
				MenuButtonColors(6);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_camera)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 6);
				MenuButtonColors(6);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_vacuum)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 7);
				if (3 == 0)
				{
					goto IL_14c8;
				}
				MenuButtonColors(7);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_materialmeasure)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 8);
				MenuButtonColors(8);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_warmup)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 9);
				MenuButtonColors(9);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_lubrication)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 10);
				MenuButtonColors(10);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_park)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 11);
				MenuButtonColors(11);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_axisA)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 12);
				MenuButtonColors(12);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_misc)))
			{
				global::_008D._007E_000F_0007(buTab_Main, 13);
				MenuButtonColors(13);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasurecalculate)))
			{
				double Val = 0.0;
				clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, _001E(107451619), ref Val);
				double num = global::_0007._007E_0094(spn_SawDiaMeasurecalcDiameter) / 2.0 - Val;
				global::_0095._007E_0008_0008(spn_SawDiaMeasureConstant, num);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasureshowcalc)))
			{
				if (!global::_0003._007E_0008(this._0001))
				{
					global::_0082._007E_0086_0005(this._0001, true);
				}
				else
				{
					global::_0082._007E_0086_0005(this._0001, false);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasurecalc)))
			{
				double Val2 = 0.0;
				clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, _001E(107451582), ref Val2);
				double num2 = global::_0007._007E_0094(spn_millingmeasurecalc) - Val2;
				global::_0095._007E_0008_0008(spn_MillingLenMeasureConstant, num2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasurecalcshow)))
			{
				if (!global::_0003._007E_0008(this._0002))
				{
					global::_0082._007E_0086_0005(this._0002, true);
				}
				else
				{
					global::_0082._007E_0086_0005(this._0002, false);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasurecalc)))
			{
				double Val3 = 0.0;
				clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, _001E(107451573), ref Val3);
				double num3 = global::_0007._007E_0094(spn_millingheadmeasurecalcLEn) - Val3;
				global::_0095._007E_0008_0008(spn_MillingHeadLenMeasureConstant, num3);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasurecalcshow)))
			{
				if (!global::_0003._007E_0008(this._0003))
				{
					global::_0082._007E_0086_0005(this._0003, true);
				}
				else
				{
					global::_0082._007E_0086_0005(this._0003, false);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_MaterialMeasureCalc)))
			{
				double Val4 = 0.0;
				clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, _001E(107451492), ref Val4);
				double num4 = global::_0007._007E_0094(spn_MaterialMeasureCalcThickness) - Val4;
				global::_0095._007E_0008_0008(spn_MaterialMeasureConstant, num4);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_MaterialMeasureCalcShow)))
			{
				if (!global::_0003._007E_0008(_0004))
				{
					global::_0082._007E_0086_0005(_0004, true);
				}
				else
				{
					global::_0082._007E_0086_0005(_0004, false);
				}
			}
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cameragetposition)) && AppBool.Connected)
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
				if (clsAppMarbleVars.varRuntime.AxZ >= 0)
				{
					global::_0095._007E_0008_0008(spn_SawModePositionZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxC >= 0)
				{
					global::_0095._007E_0008_0008(spn_SawModePositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				goto IL_14c8;
			}
			goto IL_152b;
			IL_14c8:
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				global::_0095._007E_0008_0008(spn_SawModePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			goto IL_152b;
			IL_152b:
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
					global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionFastZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxC >= 0)
				{
					global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxA >= 0)
				{
					global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingparkgetpos)) && AppBool.Connected)
			{
				if (clsAppMarbleVars.varRuntime.AxX >= 0)
				{
					global::_0095._007E_0008_0008(spn_MillingModePositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
				}
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
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasuregetpos)) && AppBool.Connected)
			{
				if (clsAppMarbleVars.varRuntime.AxX >= 0)
				{
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
				if (clsAppMarbleVars.varRuntime.AxC >= 0)
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
					global::_0095._007E_0008_0008(spn_MillingHeadModePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	internal void _0002(object P_0, EventArgs P_1)
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

	static F_MarbleMachineSettingsV1()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleMachineSettingsV1));
		Captions = new List<string>();
	}
}
