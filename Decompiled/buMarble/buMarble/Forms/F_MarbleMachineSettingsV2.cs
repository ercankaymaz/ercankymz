using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buCadCamResVer5.Marble;
using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;

namespace buMarble.Forms;

public class F_MarbleMachineSettingsV2 : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_millinghead;

	public buButton btn_milling;

	public buButton btn_saw;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal PictureBox _0001;

	internal buLabel _0001;

	internal buLabel _0002;

	internal buLabel _0003;

	public buButton btn_toolchange;

	public buButton btn_toolmeasure;

	public buButton btn_camera;

	public buButton btn_materialmeasure;

	public buButton btn_vacuum;

	public buButton btn_lubrication;

	public buButton btn_misc;

	public buButton btn_positions;

	public buButton btn_warmup;

	public ImageList IC48;

	public buButton btn_IO1;

	public buButton btn_kinematic;

	public buButton btn_calibration;

	public buButton btn_IO2;

	public buButton btn_apply;

	public buTab buTab_Main;

	public TabPage tabPage_saw;

	public buCheckBox chk_SawStopdAtCheck;

	public buCheckBox chk_SawSpeedAtCheck;

	public buSpin spn_SawStopTimeoutSec;

	public buSpin spn_SawStartTimerSec;

	public buSpin spn_SawStopTimerSec;

	public buSpin spn_SawStartTimeoutSec;

	public buSpin spn_SawMaxSpeed;

	public buSpin spn_SawExtraG54OffsetX;

	public buSpin spn_SawExtraG54OffsetZ;

	public buSpin spn_SawExtraG54OffsetY;

	internal buLabel _0004;

	public TabPage tabPage_milling;

	public buSpin spn_SpindleCoolAfterStopTimeSec;

	public buCheckBox chk_SpindlePersentageSinglePot;

	public buCheckBox chk_SpindlePersentageFromPLC;

	public buCheckBox chk_SpindleCoolAfterStop;

	public buCheckBox chk_SpindleStopdAtCheck;

	public buCheckBox chk_SpindleSpeedAtCheck;

	public buSpin spn_SpindleStartTimeoutSec;

	public buSpin spn_SpindleStopTimeoutSec;

	public buSpin spn_SpindleStartTimerSec;

	public buSpin spn_SpindleStopTimerSec;

	public buSpin spn_SpindleMaxSpeed;

	public buSpin spn_SpindleUpTimeOutSec;

	public buSpin spn_SpindleDownTimeOutSec;

	public buSpin spn_SpindleUpTimeSec;

	public buSpin spn_SpindleDownTimeSec;

	public buSpin spn_MillingExtraG54OffsetX;

	public buSpin spn_MillingExtraG54OffsetZ;

	public buSpin spn_MillingExtraG54OffsetY;

	internal buLabel _0005;

	internal TabPage _0001;

	public buSpin spn_MillingHeadExtraG54OffsetX;

	public buSpin spn_MillingHeadExtraG54OffsetZ;

	public buSpin spn_MillingHeadExtraG54OffsetY;

	internal buLabel _0006;

	internal TabPage _0002;

	public buButton btn_toolchangepositions;

	public buButton btn_toolchangetimes;

	public buButton btn_toolchangedata;

	public buTab buTab_toolchange;

	public TabPage tabPage_toolchangegeneral;

	public buSpin spn_ToolChangeBeforePositionX;

	public buSpin spn_ToolChangePositionC;

	public buSpin spn_ToolChangeLeaveVelocity;

	public buSpin spn_ToolChangeXSafeDistance;

	public buSpin spn_ToolChangePositionA;

	public buSpin spn_ToolChangeYSafeDistance;

	public buSpin spn_ToolChangeSafePositionZ;

	public buSpin spn_ToolChangeFastVelocity;

	public buSpin spn_ToolChangeUpPositionZ;

	public buSpin spn_ToolChangeSlowVelocity;

	public buSpin spn_ToolChangeTakeVelocity;

	public TabPage tabPage_toolchangetimes;

	public buSpin spn_ToolDoorOpenTimeSec;

	public buSpin spn_ToolDoorCloseTimeSec;

	public buSpin spn_ToolDoorOpenTimeoutSec;

	public buSpin spn_ToolMagazineOpenTimeSec;

	public buSpin spn_ToolDoorCloseTimeoutSec;

	public buSpin spn_ToolMagazineCloseTimeSec;

	public buSpin spn_ToolMagazinOpenTimeoutSec;

	public buSpin spn_ToolMagazinCloseTimeoutSec;

	public buSpin spn_ToolMillingClampOpenTimeSec;

	public buSpin spn_ToolMillingClampCloseTimeSec;

	internal TabPage _0003;

	internal buLabel _0007;

	public buSpin spn_ToolchangeX10;

	public buSpin spn_ToolchangeY10;

	public buSpin spn_ToolchangeZ10;

	internal buLabel _0008;

	public buSpin spn_ToolchangeX9;

	public buSpin spn_ToolchangeY9;

	public buSpin spn_ToolchangeZ9;

	internal buLabel _000E;

	public buSpin spn_ToolchangeX8;

	public buSpin spn_ToolchangeY8;

	public buSpin spn_ToolchangeZ8;

	internal buLabel _000F;

	public buSpin spn_ToolchangeX7;

	public buSpin spn_ToolchangeY7;

	public buSpin spn_ToolchangeZ7;

	internal buLabel _0010;

	public buSpin spn_ToolchangeX6;

	public buSpin spn_ToolchangeY6;

	public buSpin spn_ToolchangeZ6;

	internal buLabel _0011;

	public buSpin spn_ToolchangeX5;

	public buSpin spn_ToolchangeY5;

	public buSpin spn_ToolchangeZ5;

	internal buLabel _0012;

	public buSpin spn_ToolchangeX4;

	public buSpin spn_ToolchangeY4;

	public buSpin spn_ToolchangeZ4;

	internal buLabel _0013;

	public buSpin spn_ToolchangeX3;

	public buSpin spn_ToolchangeY3;

	public buSpin spn_ToolchangeZ3;

	internal buLabel _0014;

	public buSpin spn_ToolchangeX2;

	public buSpin spn_ToolchangeY2;

	public buSpin spn_ToolchangeZ2;

	internal buLabel _0015;

	internal buLabel _0016;

	internal buLabel _0017;

	internal buLabel _0018;

	public buSpin spn_ToolchangeX1;

	public buSpin spn_ToolchangeY1;

	public buSpin spn_ToolchangeZ1;

	internal buLabel _0019;

	internal TabPage _0004;

	public buSpin spn_ToolMeasureSlowApproachVelocity;

	internal buLabel _001A;

	public buSpin spn_ToolMeasureCoverOnTimeSec;

	public buSpin spn_ToolMeasureSlowLeaveVelocity;

	public buSpin spn_ToolMeasureJerk;

	public buSpin spn_ToolMeasureFastVelocity;

	public buSpin spn_ToolMeasureAccDec;

	public buSpin spn_ToolMeasureCoverOffTimeSec;

	internal TabPage _0005;

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

	internal buLabel _001B;

	internal TabPage _0006;

	public buSpin spn_VacuumBlowerTimeSec;

	public buSpin spn_VacuumOutTimeoutSec;

	public buSpin spn_VacuumInTimeoutSec;

	public buSpin spn_VacuumFastZPosition;

	public buSpin spn_VacuumOffTimeOutSec;

	public buSpin spn_VacuumOnTimeOutSec;

	public buSpin spn_VacuumDownTimeOutSec;

	public buSpin spn_VacuumUpTimeOutSec;

	public buSpin spn_VacuumDownTimeSec;

	public buSpin spn_VacuumUpTimeSec;

	internal buLabel _001C;

	internal TabPage _0007;

	public buSpin spn_MaterialMeasureYBorderOffset;

	public buSpin spn_MaterialMeasureXBorderOffset;

	public buSpin spn_MaterialMeasureMaxSawDiameter;

	public buSpin spn_MaterialMeasureG54OffsetY;

	public buSpin spn_MaterialMeasureG54OffsetX;

	internal Panel _0001;

	public buButton btn_MaterialMeasureCalc;

	public buSpin spn_MaterialMeasureCalcThickness;

	public buButton btn_MaterialMeasureCalcShow;

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

	internal buLabel _001D;

	internal TabPage _0008;

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

	internal buLabel _001E;

	internal TabPage _000E;

	public buCheckBox chk_LubricationEnable;

	public buSpin spn_LubricationTimeSec;

	public buSpin spn_LubricationBlockOnOffTimeSec;

	public buSpin spn_LubricationPeriodWaitMin;

	public buSpin spn_LubricationLevelOnOffTimeSec;

	internal buLabel _001F;

	internal TabPage _000F;

	internal buLabel _007F;

	internal buLabel _0080;

	public buButton btn_generalparkgo;

	public buButton btn_generalparkgetpos;

	internal buLabel _0081;

	internal buLabel _0082;

	internal buLabel _0083;

	internal buLabel _0084;

	internal buLabel _0086;

	public buSpin spn_generalparkx;

	public buSpin spn_generalparkc;

	public buSpin spn_generalparky;

	public buSpin spn_generalparka;

	public buSpin spn_generalparkz;

	public buSpin spn_ParkPosTimeOutSec;

	internal buLabel _0087;

	internal TabPage _0010;

	internal buLabel _0088;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	public buSpin spn_WaterOnOffTimerSec;

	public buSpin spn_LaserOnOffTimerSec;

	public buSpin spn_StartPointPosTimeOutSec;

	public buCheckBox chk_GoZUpPositionWhenStart;

	public buCheckBox chk_BuzzerEnable;

	public buSpin spn_BuzzerTimeSec;

	internal buLabel _0089;

	internal TabPage _0011;

	public buButton btn_cnc;

	public buButton btn_caxis;

	public buButton btn_aaxis;

	public buButton btn_zaxis;

	public buButton btn_yaxis;

	public buButton btn_xaxis;

	internal buTab _0001;

	internal TabPage _0012;

	internal buLabel _008A;

	public buCheckBox chk_hardlimitx;

	internal buLabel _008B;

	public buCheckBox chk_joglimitx;

	public buButton btn_limitplusgetX;

	public buCheckBox chk_softlimitx;

	internal buLabel _008C;

	public buButton btn_limitminusgetx;

	public buSpin spn_datalimitnegx;

	public buSpin spn_calibx_measuredeval;

	public buSpin spn_datalimitposx;

	public buSpin spn_softlimitnegx;

	public buButton btn_limitdisablex;

	public buSpin spn_softlimitposx;

	public buSpin spn_calibx_moveval;

	public buButton btn_limitenablex;

	public buButton btn_calibx;

	public buSpin spn_calibx_unit;

	public buSpin spn_calibx_gear;

	public buSpin spn_calibx_pulse;

	public buSpin spn_speedJogXjerk;

	public buSpin spn_speedJogXAccDec;

	public buSpin spn_speedJogXSpeed;

	public buSpin spn_speedMoveXJerk;

	public buSpin spn_speedJogX2SpeedTime;

	public buSpin spn_speedMoveXSpeed;

	public buSpin spn_speedJogX2SpeedPerc;

	public buSpin spn_speedMoveXAccDec;

	internal TabPage _0013;

	public buButton btn_limitplusgetY;

	public buSpin spn_softlimitposy;

	public buButton btn_limitdisabley;

	public buSpin spn_speedJogY2SpeedTime;

	public buSpin spn_softlimitnegy;

	public buSpin spn_speedJogY2SpeedPerc;

	public buCheckBox chk_softlimity;

	public buSpin spn_speedMoveYSpeed;

	public buCheckBox chk_hardlimity;

	public buSpin spn_speedMoveYJerk;

	public buSpin spn_datalimitposy;

	public buSpin spn_speedMoveYAccDec;

	public buSpin spn_datalimitnegy;

	public buSpin spn_speedJogYSpeed;

	public buButton btn_limitminusgetY;

	public buSpin spn_speedJogYJerk;

	public buCheckBox chk_joglimity;

	public buSpin spn_speedJogYAccDEc;

	public buButton btn_limitenabley;

	public buSpin spn_caliby_pulse;

	public buSpin spn_caliby_gear;

	public buSpin spn_caliby_unit;

	internal buLabel _008D;

	internal buLabel _008E;

	internal buLabel _008F;

	public buButton btn_caliby;

	public buSpin spn_caliby_measuredeval;

	public buSpin spn_caliby_moveval;

	internal TabPage _0014;

	public buButton btn_limitplusgetZ;

	public buSpin spn_speedJogZJerk;

	public buButton btn_limitminusgetZ;

	public buSpin spn_speedMoveZSpeed;

	public buButton btn_limitdisablez;

	public buSpin spn_calibz_pulse;

	public buButton btn_limitenablez;

	public buSpin spn_speedJogZ2SpeedTime;

	public buCheckBox chk_hardlimitz;

	public buSpin spn_calibz_gear;

	public buCheckBox chk_joglimitz;

	public buSpin spn_speedMoveZJerk;

	public buSpin spn_datalimitnegz;

	public buSpin spn_calibz_unit;

	public buSpin spn_datalimitposz;

	public buSpin spn_speedMoveZAccDEc;

	public buCheckBox chk_softlimitz;

	public buButton btn_calibz;

	public buSpin spn_softlimitnegz;

	public buSpin spn_speedJogZAccDEc;

	public buSpin spn_softlimitposz;

	public buSpin spn_calibz_measuredeval;

	public buSpin spn_speedJogZ2SpeedPerc;

	public buSpin spn_calibz_moveval;

	public buSpin spn_speedJogZSpeed;

	internal buLabel _0090;

	internal buLabel _0091;

	internal buLabel _0092;

	internal TabPage _0015;

	public buButton btn_limitplusgetC;

	public buSpin spn_speedJogC2SpeedTime;

	public buButton btn_limitminusgetC;

	public buButton btn_calibc;

	public buButton btn_limitdisablec;

	public buSpin spn_speedJogC2SpeedPerc;

	public buButton btn_limitenablec;

	public buSpin spn_calibc_measuredeval;

	public buCheckBox chk_hardlimitc;

	public buSpin spn_speedMoveCSpeed;

	public buCheckBox chk_joglimitc;

	public buSpin spn_calibc_moveval;

	public buSpin spn_datalimitnegc;

	public buSpin spn_speedMoveCJerk;

	public buSpin spn_datalimitposc;

	public buSpin spn_calibc_pulse;

	public buCheckBox chk_softlimitc;

	public buSpin spn_speedMoveCAccDec;

	public buSpin spn_softlimitnegc;

	public buSpin spn_calibc_gear;

	public buSpin spn_softlimitposc;

	public buSpin spn_speedJogCSpeed;

	public buSpin spn_calibc_unit;

	public buSpin spn_speedJogCJerk;

	public buSpin spn_speedJogCAccDec;

	internal buLabel _0093;

	internal buLabel _0094;

	internal buLabel _0095;

	internal TabPage _0016;

	public buButton btn_limitplusgetA;

	public buSpin spn_speedJogA2SpeedTime;

	public buButton btn_limitminusgetA;

	public buSpin spn_caliba_pulse;

	public buButton btn_limitdisablea;

	public buSpin spn_speedJogA2SpeedPerc;

	public buButton btn_limitenablea;

	public buSpin spn_caliba_gear;

	public buCheckBox chk_hardlimita;

	public buSpin spn_speedMoveASpeed;

	public buCheckBox chk_joglimita;

	public buSpin spn_caliba_unit;

	public buSpin spn_datalimitnega;

	public buSpin spn_speedMoveAJerk;

	public buSpin spn_datalimitposa;

	public buButton btn_caliba;

	public buCheckBox chk_softlimita;

	public buSpin spn_speedMoveAAccDec;

	public buSpin spn_softlimitnega;

	public buSpin spn_caliba_measuredeval;

	public buSpin spn_softlimitposa;

	public buSpin spn_speedJogASpeed;

	public buSpin spn_caliba_moveval;

	public buSpin spn_speedJogAJerk;

	public buSpin spn_speedJogAAccDEc;

	internal buLabel _0096;

	internal buLabel _0097;

	internal buLabel _0098;

	internal TabPage _0017;

	internal buLabel _0099;

	public buSpin spn_cncJerk;

	public buSpin spn_cncG1AccDec;

	public buSpin spn_cncG0AccDec;

	internal TabPage _0018;

	public buSpin spn_c270ZDisA45;

	public buSpin spn_c180ZDisA45;

	public buSpin spn_A_AxisSawDistance;

	public buSpin spn_c90ZDisA45;

	public buSpin spn_motor_A_AxisZDistance;

	public buSpin spn_c0ZDisA45;

	public buSpin spn_C_AxisSawDistance;

	public buSpin spn_c270ADisA45;

	internal buLabel _009A;

	public buSpin spn_c180ADisA45;

	public buSpin spn_c0ZDisA0;

	public buSpin spn_c90ADisA45;

	internal buLabel _009B;

	public buSpin spn_c0ADisA45;

	internal buLabel _009C;

	public buSpin spn_c270ZDisA0;

	internal buLabel _009D;

	public buSpin spn_c180ZDisA0;

	internal buLabel _009E;

	public buSpin spn_c90ZDisA0;

	internal buLabel _009F;

	internal buLabel _0001_0002;

	internal TabPage _0019;

	public buButton btn_spindlebwd;

	public buSpin spn_millingspeed;

	public buButton btn_sawbwd;

	public buSpin spn_sawspeed;

	public buCheckBox chk_laserOnOff;

	public buButton btn_laserOnOffI;

	public buButton btn_laserOnOffO;

	public buCheckBox chk_materialmeasureUp;

	public buButton btn_materialmeasureUpI;

	public buButton btn_materialmeasureUpO;

	public buCheckBox chk_toolmeasureup;

	public buButton btn_toolmeasureupI;

	public buButton btn_toolmeasureupO;

	public buButton btn_laserOnOff;

	public buButton btn_materialmeasureUpDown;

	public buButton btn_toolmeasureupdown;

	public buButton btn_rocketup;

	public buButton btn_rocketdown;

	public buCheckBox chk_spindleup;

	public buButton btn_rocketupI;

	public buButton btn_rocketupO;

	internal buLabel _0002_0002;

	internal buLabel _0003_0002;

	public buCheckBox chk_spindledown;

	public buButton btn_rocketdownI;

	public buButton btn_rocketdownO;

	internal TabPage _001A;

	public buCheckBox chk_pensopen;

	public buButton btn_pensopenI;

	public buButton btn_pensopenO;

	public buCheckBox CHK_magazinedown;

	public buButton btn_magazinedownı;

	public buButton btn_magazinedowno;

	public buCheckBox chk_magazineUp;

	public buButton btn_magazineUpI;

	public buButton btn_magazineUpO;

	public buCheckBox chk_magazineclose;

	public buButton btn_magazinecloseI;

	public buButton btn_magazinecloseO;

	internal buLabel _0004_0002;

	internal buLabel _0005_0002;

	public buCheckBox chk_magazineopen;

	public buButton btn_pensopen;

	public buButton btn_magazineopenI;

	public buButton btn_magazineopenO;

	public buButton btn_magazinedown;

	public buButton btn_magazineopen;

	public buButton btn_magazineclose;

	public buButton btn_magazineUp;

	public buSpin spn_MillingHeadLenMeasurePositionX;

	public buSpin spn_MillingHeadLenMeasurePositionC;

	public buSpin spn_MillingHeadLenMeasurePositionFastZ;

	public buSpin spn_MillingHeadLenMeasurePositionA;

	public buSpin spn_MillingHeadLenMeasurePositionY;

	public buSpin spn_MillingLenMeasurePositionX;

	public buSpin spn_MillingLenMeasurePositionC;

	public buSpin spn_MillingLenMeasurePositionFastZ;

	public buSpin spn_MillingLenMeasurePositionA;

	public buSpin spn_MillingLenMeasurePositionY;

	public buSpin spn_SawDiaMeasurePositionX;

	public buSpin spn_SawDiaMeasurePositionC;

	public buSpin spn_SawDiaMeasurePositionFastZ;

	public buSpin spn_SawDiaMeasurePositionA;

	public buSpin spn_SawDiaMeasurePositionY;

	public buSpin spn_CameraPositionA;

	public buSpin spn_CameraPositionC;

	public buSpin spn_CameraPositionX;

	public buSpin spn_CameraPositionZ;

	public buSpin spn_CameraPositionY;

	public buSpin spn_wagonposX;

	public buSpin spn_wagonposA;

	public buSpin spn_wagonposZ;

	public buSpin spn_wagonposC;

	public buSpin spn_wagonposY;

	public buSpin spn_MillingHeadModePositionX;

	public buSpin spn_MillingHeadModePositionC;

	public buSpin spn_MillingHeadModePositionY;

	public buSpin spn_MillingHeadModePositionA;

	public buSpin spn_MillingHeadModePositionZ;

	public buSpin spn_MillingModePositionA;

	public buSpin spn_MillingModePositionX;

	public buSpin spn_MillingModePositionC;

	public buSpin spn_MillingModePositionY;

	public buSpin spn_MillingModePositionZ;

	public buSpin spn_SawModePositionX;

	public buSpin spn_SawModePositionC;

	public buSpin spn_SawModePositionY;

	public buSpin spn_SawModePositionA;

	public buSpin spn_SawModePositionZ;

	public buButton btn_millingheadmeasurego;

	public buButton btn_sawmeasurego;

	public buButton btn_millingmeasurego;

	public buButton btn_wagongo;

	public buButton btn_camerago;

	public buButton btn_millingparkgo;

	public buButton btn_millingheadparkgo;

	public buButton btn_sawparkgo;

	public buButton btn_millingheadmeasuregetpos;

	public buButton btn_sawmeasuregetpos;

	public buButton btn_millingmeasuregetpos;

	public buButton btn_wagongetposition;

	public buButton btn_cameragetposition;

	public buButton btn_millingparkgetpos;

	public buButton btn_millingheadparkgetpos;

	public buButton btn_sawparkgetpos;

	public buSpin spn_SawModePosTimeOutSec;

	public buSpin spn_MillingModePosTimeOutSec;

	public buSpin spn_MillingHeadModePosTimeOutSec;

	public buSpin spn_wagontimeout;

	public buSpin spn_wagonhidrostopsec;

	public buButton btn_toolmeasuremillinghead;

	public buButton btn_toolmeasuremilling;

	public buButton btn_toolmeasuresaw;

	public buTab buTab_toolmeasure;

	public TabPage tabPage_toolmeasuresaw;

	public TabPage tabPage_toolmeasuremilling;

	internal TabPage _001B;

	internal Panel _0002;

	public buButton btn_sawmeasurecalculate;

	public buSpin spn_SawDiaMeasurecalcDiameter;

	public buButton btn_sawmeasureshowcalc;

	public buSpin spn_SawMeasureTimeOutSec;

	public buSpin spn_SawDiaMeasureConstant;

	public buSpin spn_SawDiaMeasurePositionLimitZ;

	internal Panel _0003;

	public buButton btn_millingmeasurecalc;

	public buSpin spn_millingmeasurecalc;

	public buButton btn_millingmeasurecalcshow;

	public buSpin spn_MillingMeasureTimeOutSec;

	public buSpin spn_MillingLenMeasureConstant;

	public buSpin spn_MillingLenMeasurePositionLimitZ;

	internal Panel _0004;

	public buButton btn_millingheadmeasurecalc;

	public buSpin spn_millingheadmeasurecalcLEn;

	public buButton btn_millingheadmeasurecalcshow;

	public buSpin spn_MillingHeadMeasureTimeOutSec;

	public buSpin spn_MillingHeadLenMeasureConstant;

	public buSpin spn_MillingHeadLenMeasurePositionLimitZ;

	public buCheckBox chk_ServoAAxis;

	public buSpin spn_AAxisAllowedZSafePosition;

	public buSpin spn_AAxisTimeOutSec;

	public buSpin spn_AAxisExtraTimeSec;

	internal buLabel _0006_0002;

	internal buLabel _0007_0002;

	internal buLabel _0008_0002;

	internal buLabel _000E_0002;

	internal TabPage _001C;

	public buButton btn_cabsolutereset;

	public buButton btn_aabsolutereset;

	public buButton btn_zabsolutereset;

	public buButton btn_yabsolutereset;

	public buButton btn_xrabsoluteeset;

	internal buLabel _000F_0002;

	internal buLabel _0010_0002;

	public buSpin spn_absolutesetC;

	public buSpin spn_absolutesetA;

	public buSpin spn_absolutesetZ;

	public buSpin spn_absolutesetY;

	public buSpin spn_absolutesetX;

	internal TabPage _001D;

	public buButton btn_safeparameters;

	public buButton btn_absoluteset;

	public buSpin spn_MillingLenMeasureMaxLength;

	public buSpin spn_MillingLenMeasureMinLength;

	public buSpin spn_SawDiaMeasureMinDaimeter;

	public buSpin spn_SawDiaMeasureMaxDaimeter;

	internal buLabel _0011_0002;

	public buSpin spn_MillingHeadLenMeasureMaxLength;

	public buSpin spn_MillingHeadLenMeasureMinLength;

	public buButton btn_jog;

	public buButton btn_mdi;

	public buButton btn_stop;

	public buLabel lbl_warning;

	public buCheckBox chk_lubricationOnOff;

	public buButton btn_lubricationOnOffI;

	public buButton btn_lubricationOnOffO;

	public buCheckBox chk_cameraOpenClose;

	public buButton btn_cameraOpenCloseI;

	public buButton btn_cameraOpenCloseO;

	public buCheckBox chk_wateronoff;

	public buButton btn_wateronoffI;

	public buButton btn_wateronoffO;

	public buButton btn_cameraOpenClose;

	public buButton btn_watersawonoff;

	public buButton btn_lubricationOnOff;

	public buCheckBox chk_toolblowOnOff;

	public buButton btn_toolblowOnOffI;

	public buButton btn_toolblowOnOffO;

	public buButton btn_toolblowOnOff;

	public buCheckBox chk_suctionCubAirOnOff;

	public buButton btn_suctionCubAirOnOffI;

	public buButton btn_suctionCubAirOnOffO;

	public buCheckBox chk_rightvacuuminOk;

	public buButton btn_rightvacuuminOkI;

	public buButton btn_rightvacuuminOkO;

	public buCheckBox chk_rightvacuumoutOk;

	public buButton btn_rightvacuumoutOkI;

	public buButton btn_rightvacuumoutOkO;

	public buCheckBox chk_leftvacuuminOk;

	public buButton btn_leftvacuuminOkI;

	public buButton btn_leftvacuuminOkO;

	public buCheckBox chk_leftvacuumoutOk;

	public buButton btn_leftvacuumoutOkI;

	public buButton btn_leftvacuumoutOkO;

	public buButton btn_suctionCubAirOnOff;

	public buButton btn_rightvacuuminOk;

	public buButton btn_rightvacuumoutOk;

	public buButton btn_leftvacuuminOk;

	public buButton btn_leftvacuumoutOk;

	public buCheckBox chk_rightSuction;

	public buButton btn_rightSuctionI;

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

	[NonSerialized]
	internal static GetString _0015;

	public F_MarbleMachineSettingsV2()
	{
		global::_0005._0003._0001(this);
	}

	public void Init(int Index)
	{
		PropertiesForm.Inited = false;
		bool num = PropertiesForm.Height > 10;
		bool flag = default(bool);
		if (0 == 0)
		{
			flag = num;
		}
		if (flag)
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
		global::_008C._007E_0002_0007(buTab_toolchange, new Size(1, 1));
		global::_008C._007E_0002_0007(this._0001, new Size(1, 1));
		global::_008C._007E_0002_0007(buTab_toolmeasure, new Size(1, 1));
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
		MenuButtonColorsToolMeasure(0);
		MenuButtonColorsToolChange(0);
		MenuButtonColorsCalibration(0);
		global::_0095._007E_0008_0008(spn_SawMaxSpeed, clsAppMarbleVars.varApp.SawMaxSpeed);
		while (true)
		{
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
			global::_0095._007E_0008_0008(spn_ToolchangeX1, buMarbleCalc.ToolInMagazine[1].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY1, buMarbleCalc.ToolInMagazine[1].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ1, buMarbleCalc.ToolInMagazine[1].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX2, buMarbleCalc.ToolInMagazine[2].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY2, buMarbleCalc.ToolInMagazine[2].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ2, buMarbleCalc.ToolInMagazine[2].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX3, buMarbleCalc.ToolInMagazine[3].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY3, buMarbleCalc.ToolInMagazine[3].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ3, buMarbleCalc.ToolInMagazine[3].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX4, buMarbleCalc.ToolInMagazine[4].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY4, buMarbleCalc.ToolInMagazine[4].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ4, buMarbleCalc.ToolInMagazine[4].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX5, buMarbleCalc.ToolInMagazine[5].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY5, buMarbleCalc.ToolInMagazine[5].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ5, buMarbleCalc.ToolInMagazine[5].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX6, buMarbleCalc.ToolInMagazine[6].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY6, buMarbleCalc.ToolInMagazine[6].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ6, buMarbleCalc.ToolInMagazine[6].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX7, buMarbleCalc.ToolInMagazine[7].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY7, buMarbleCalc.ToolInMagazine[7].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ7, buMarbleCalc.ToolInMagazine[7].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX8, buMarbleCalc.ToolInMagazine[8].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY8, buMarbleCalc.ToolInMagazine[8].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ8, buMarbleCalc.ToolInMagazine[8].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX9, buMarbleCalc.ToolInMagazine[9].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY9, buMarbleCalc.ToolInMagazine[9].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ9, buMarbleCalc.ToolInMagazine[9].Positions.Position.Z);
			global::_0095._007E_0008_0008(spn_ToolchangeX10, buMarbleCalc.ToolInMagazine[10].Positions.Position.X);
			global::_0095._007E_0008_0008(spn_ToolchangeY10, buMarbleCalc.ToolInMagazine[10].Positions.Position.Y);
			global::_0095._007E_0008_0008(spn_ToolchangeZ10, buMarbleCalc.ToolInMagazine[10].Positions.Position.Z);
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
			if (6u != 0)
			{
				global::_0095._007E_0008_0008(spn_MillingHeadMeasureTimeOutSec, clsAppMarbleVars.varApp.MillingHeadMeasureTimeOutSec);
				global::_0095._007E_0008_0008(spn_ToolMeasureCoverOnTimeSec, clsAppMarbleVars.varApp.ToolMeasureCoverOnTimeSec);
				global::_0095._007E_0008_0008(spn_ToolMeasureCoverOffTimeSec, clsAppMarbleVars.varApp.ToolMeasureCoverOffTimeSec);
			}
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
			while (true)
			{
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
				do
				{
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
				}
				while (6 == 0);
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
				global::_0095._007E_0008_0008(spn_generalparkx, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition);
				global::_0095._007E_0008_0008(spn_generalparky, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition);
				global::_0095._007E_0008_0008(spn_generalparkz, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition);
				global::_0095._007E_0008_0008(spn_generalparka, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition);
				global::_0095._007E_0008_0008(spn_generalparkc, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition);
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
					global::_0082._007E_009E_0005(this._0001, true);
				}
				else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.SafeDistance)
				{
					global::_0082._007E_009E_0005(this._0003, true);
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
				global::_0095._007E_0008_0008(spn_SawDiaMeasureMinDaimeter, clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter);
				global::_0095._007E_0008_0008(spn_SawDiaMeasureMaxDaimeter, clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter);
				global::_0095._007E_0008_0008(spn_MillingLenMeasureMinLength, clsAppMarbleVars.varApp.MillingLenMeasureMinLength);
				global::_0095._007E_0008_0008(spn_MillingLenMeasureMaxLength, clsAppMarbleVars.varApp.MillingLenMeasureMaxLength);
				global::_0095._007E_0008_0008(spn_MillingHeadLenMeasureMinLength, clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength);
				global::_0095._007E_0008_0008(spn_MillingHeadLenMeasureMaxLength, clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength);
				global::_0095._007E_0008_0008(spn_VacuumMaxSawDiameter, clsAppMarbleVars.varApp.VacuumMaxSawDiameter);
				global::_0095._007E_0008_0008(spn_MaxSpindleToolLengthForA45, clsAppMarbleVars.varApp.MaxSpindleToolLengthForA45);
				global::_0095._007E_0008_0008(spn_sawspeed, clsAppMarbleVars.varInterface.SawSpeed);
				global::_0095._007E_0008_0008(spn_millingspeed, clsAppMarbleVars.varInterface.SpindleSpeed);
				global::_0095._007E_0008_0008(spn_A_AxisSawDistance, clsMarble.activeKinematic.RotateCenterOffsetOfA.Y);
				global::_0095._007E_0008_0008(spn_motor_A_AxisZDistance, clsMarble.activeKinematic.RotateCenterOffsetOfA.Z);
				global::_0095._007E_0008_0008(spn_C_AxisSawDistance, clsMarble.activeKinematic.RotateCenterOffsetOfC.Y);
				global::_0095._007E_0008_0008(spn_c0ZDisA0, clsMarble.activeKinematic.ZDistanceForA0AtC0);
				global::_0095._007E_0008_0008(spn_c90ZDisA0, clsMarble.activeKinematic.ZDistanceForA0AtC90);
				global::_0095._007E_0008_0008(spn_c180ZDisA0, clsMarble.activeKinematic.ZDistanceForA0AtC180);
				global::_0095._007E_0008_0008(spn_c270ZDisA0, clsMarble.activeKinematic.ZDistanceForA0AtC270);
				global::_0095._007E_0008_0008(spn_c0ZDisA45, clsMarble.activeKinematic.ZDistanceForA45AtC0);
				global::_0095._007E_0008_0008(spn_c90ZDisA45, clsMarble.activeKinematic.ZDistanceForA45AtC90);
				global::_0095._007E_0008_0008(spn_c180ZDisA45, clsMarble.activeKinematic.ZDistanceForA45AtC180);
				global::_0095._007E_0008_0008(spn_c270ZDisA45, clsMarble.activeKinematic.ZDistanceForA45AtC270);
				global::_0095._007E_0008_0008(spn_c0ADisA45, clsMarble.activeKinematic.ADistanceForA45AtC0);
				global::_0095._007E_0008_0008(spn_c90ADisA45, clsMarble.activeKinematic.ADistanceForA45AtC90);
				global::_0095._007E_0008_0008(spn_c180ADisA45, clsMarble.activeKinematic.ADistanceForA45AtC180);
				global::_0095._007E_0008_0008(spn_c270ADisA45, clsMarble.activeKinematic.ADistanceForA45AtC270);
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
				bool num2 = clsAppMarbleVars.varRuntime.AxY >= 0;
				do
				{
					if (num2 & (clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
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
					num2 = clsAppMarbleVars.varRuntime.AxZ >= 0;
				}
				while (8 == 0);
				if (num2 & (clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
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
					if (false)
					{
						break;
					}
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
				PropertiesForm.Result = DialogResult.None;
				PropertiesForm.Inited = true;
				global::_0005._0003._0001(this);
				if (7u != 0)
				{
					return;
				}
			}
		}
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
		buMarbleCalc.ToolInMagazine[1].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX1);
		buMarbleCalc.ToolInMagazine[1].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY1);
		buMarbleCalc.ToolInMagazine[1].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ1);
		buMarbleCalc.ToolInMagazine[2].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX2);
		buMarbleCalc.ToolInMagazine[2].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY2);
		buMarbleCalc.ToolInMagazine[2].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ2);
		buMarbleCalc.ToolInMagazine[3].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX3);
		buMarbleCalc.ToolInMagazine[3].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY3);
		buMarbleCalc.ToolInMagazine[3].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ3);
		buMarbleCalc.ToolInMagazine[4].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX4);
		buMarbleCalc.ToolInMagazine[4].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY4);
		buMarbleCalc.ToolInMagazine[4].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ4);
		buMarbleCalc.ToolInMagazine[5].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX5);
		buMarbleCalc.ToolInMagazine[5].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY5);
		buMarbleCalc.ToolInMagazine[5].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ5);
		buMarbleCalc.ToolInMagazine[6].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX6);
		buMarbleCalc.ToolInMagazine[6].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY6);
		buMarbleCalc.ToolInMagazine[6].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ6);
		buMarbleCalc.ToolInMagazine[7].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX7);
		buMarbleCalc.ToolInMagazine[7].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY7);
		buMarbleCalc.ToolInMagazine[7].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ7);
		buMarbleCalc.ToolInMagazine[8].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX8);
		buMarbleCalc.ToolInMagazine[8].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY8);
		buMarbleCalc.ToolInMagazine[8].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ8);
		buMarbleCalc.ToolInMagazine[9].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX9);
		buMarbleCalc.ToolInMagazine[9].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY9);
		buMarbleCalc.ToolInMagazine[9].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ9);
		buMarbleCalc.ToolInMagazine[10].Positions.Position.X = global::_0007._007E_0094(spn_ToolchangeX10);
		buMarbleCalc.ToolInMagazine[10].Positions.Position.Y = global::_0007._007E_0094(spn_ToolchangeY10);
		buMarbleCalc.ToolInMagazine[10].Positions.Position.Z = global::_0007._007E_0094(spn_ToolchangeZ10);
		clsAppMarbleVars.varApp.AtcOpenTimeSec = global::_0007._007E_0094(spn_ToolDoorOpenTimeSec);
		clsAppMarbleVars.varApp.AtcCloseTimeSec = global::_0007._007E_0094(spn_ToolDoorCloseTimeSec);
		clsAppMarbleVars.varApp.AtcForwardTimeSec = global::_0007._007E_0094(spn_ToolMagazineOpenTimeSec);
		clsAppMarbleVars.varApp.AtcBackwardTimeSec = global::_0007._007E_0094(spn_ToolMagazineCloseTimeSec);
		clsAppMarbleVars.varApp.AtcOpenTimeoutSec = global::_0007._007E_0094(spn_ToolDoorOpenTimeoutSec);
		clsAppMarbleVars.varApp.AtcCloseTimeoutSec = global::_0007._007E_0094(spn_ToolDoorCloseTimeoutSec);
		clsAppMarbleVars.varApp.AtcForwardTimeoutSec = global::_0007._007E_0094(spn_ToolMagazinOpenTimeoutSec);
		clsAppMarbleVars.varApp.AtcBackwardTimeoutSec = global::_0007._007E_0094(spn_ToolMagazinCloseTimeoutSec);
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
		clsAppMarbleVars.varApp.SawMeasureTimeOutSec = global::_0007._007E_0094(spn_SawMeasureTimeOutSec);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionX = global::_0007._007E_0094(spn_MillingLenMeasurePositionX);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionY = global::_0007._007E_0094(spn_MillingLenMeasurePositionY);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ = global::_0007._007E_0094(spn_MillingLenMeasurePositionFastZ);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionLimitZ = global::_0007._007E_0094(spn_MillingLenMeasurePositionLimitZ);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionA = global::_0007._007E_0094(spn_MillingLenMeasurePositionA);
		clsAppMarbleVars.varApp.MillingLenMeasurePositionC = global::_0007._007E_0094(spn_MillingLenMeasurePositionC);
		clsAppMarbleVars.varApp.MillingLenMeasureConstant = global::_0007._007E_0094(spn_MillingLenMeasureConstant);
		clsAppMarbleVars.varApp.MillingMeasureTimeOutSec = global::_0007._007E_0094(spn_MillingMeasureTimeOutSec);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionX);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionY);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionFastZ);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionLimitZ = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionLimitZ);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionA);
		clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionC);
		clsAppMarbleVars.varApp.MillingHeadLenMeasureConstant = global::_0007._007E_0094(spn_MillingHeadLenMeasureConstant);
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
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparkx);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparky);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparkz);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparka);
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition = global::_0007._007E_0094(spn_generalparkc);
		clsAppMarbleVars.varApp.ParkPosTimeOutSec = global::_0007._007E_0094(spn_ParkPosTimeOutSec);
		clsAppMarbleVars.varApp.OptionServoAxisA = global::_0003._007E_0010(chk_ServoAAxis);
		clsAppMarbleVars.varApp.AAxisAllowedZSafePosition = global::_0007._007E_0094(spn_AAxisAllowedZSafePosition);
		clsAppMarbleVars.varApp.AAxisTimeOutSec = global::_0007._007E_0094(spn_AAxisTimeOutSec);
		clsAppMarbleVars.varApp.AAxisExtraTimeSec = global::_0007._007E_0094(spn_AAxisExtraTimeSec);
		clsAppMarbleVars.varApp.BuzzerEnable = global::_0003._007E_0010(chk_BuzzerEnable);
		clsAppMarbleVars.varApp.BuzzerTimeSec = global::_0007._007E_0094(spn_BuzzerTimeSec);
		clsAppMarbleVars.varApp.GoZUpPositionWhenStart = global::_0003._007E_0010(chk_GoZUpPositionWhenStart);
		clsAppMarbleVars.varApp.StartPointPosTimeOutSec = global::_0007._007E_0094(spn_StartPointPosTimeOutSec);
		while (true)
		{
			clsAppMarbleVars.varApp.LaserOnOffTimerSec = global::_0007._007E_0094(spn_LaserOnOffTimerSec);
			clsAppMarbleVars.varApp.WaterOnOffTimerSec = global::_0007._007E_0094(spn_WaterOnOffTimerSec);
			if (global::_0003._007E_0017(this._0002))
			{
				clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.ParkPosition;
			}
			else if (global::_0003._007E_0017(this._0003))
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
			clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter = global::_0007._007E_0094(spn_SawDiaMeasureMinDaimeter);
			clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter = global::_0007._007E_0094(spn_SawDiaMeasureMaxDaimeter);
			clsAppMarbleVars.varApp.MillingLenMeasureMinLength = global::_0007._007E_0094(spn_MillingLenMeasureMinLength);
			clsAppMarbleVars.varApp.MillingLenMeasureMaxLength = global::_0007._007E_0094(spn_MillingLenMeasureMaxLength);
			clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength = global::_0007._007E_0094(spn_MillingHeadLenMeasureMinLength);
			clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength = global::_0007._007E_0094(spn_MillingHeadLenMeasureMaxLength);
			clsAppMarbleVars.varApp.VacuumMaxSawDiameter = global::_0007._007E_0094(spn_VacuumMaxSawDiameter);
			clsAppMarbleVars.varApp.MaxSpindleToolLengthForA45 = global::_0007._007E_0094(spn_MaxSpindleToolLengthForA45);
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
			if (!((clsAppMarbleVars.varRuntime.AxA >= 0) & (clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)))
			{
				break;
			}
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_caliba_unit);
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_caliba_pulse);
			if (0 == 0)
			{
				clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_caliba_gear);
				break;
			}
		}
		if ((clsAppMarbleVars.varRuntime.AxC >= 0) & (clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
		{
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit = global::_0007._007E_0094(spn_calibc_unit);
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse = global::_0007._007E_0094(spn_calibc_pulse);
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio = global::_0007._007E_0094(spn_calibc_gear);
		}
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
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(buGround1);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		global::_008D._007E_000F_0007(buTab_Main, PageIndex);
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
		bool flag = PageIndex == 2;
		if (4u != 0)
		{
			if (flag)
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
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_camera)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_camera)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 6)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_vacuum)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_vacuum)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 7)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_materialmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_materialmeasure)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 8)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_warmup)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_warmup)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 9)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_lubrication)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_lubrication)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 10)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_positions)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_positions)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 11)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_misc)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_misc)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 12)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_calibration)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_calibration)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 13)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_kinematic)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_kinematic)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 14)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_IO1)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_IO1)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 15)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_IO2)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_IO2)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			if (PageIndex == 16)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_absoluteset)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_absoluteset)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
		}
		if (PageIndex == 17)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_safeparameters)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_safeparameters)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
	}

	public void MenuButtonColorsToolMeasure(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(this._0004);
		while (true)
		{
			controlCollection = _0099_0006._001D_0013(controlCollection);
			global::_008D._007E_000F_0007(buTab_toolmeasure, PageIndex);
			int num;
			if (0 == 0)
			{
				num = PageIndex;
				if (7u != 0)
				{
					if (3u != 0)
					{
						num = ((num == 0) ? 1 : 0);
					}
					if (false)
					{
						goto IL_00e1;
					}
					bool flag = (byte)num != 0;
					num = (flag ? 1 : 0);
				}
				if (num == 0)
				{
					goto IL_00dd;
				}
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolmeasuresaw)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolmeasuresaw)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			goto IL_00dd;
			IL_00de:
			int num2;
			num = ((num2 == 1) ? 1 : 0);
			goto IL_00e1;
			IL_00e1:
			if (num != 0)
			{
				if (false)
				{
					continue;
				}
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolmeasuremilling)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolmeasuremilling)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				if (3 == 0)
				{
					break;
				}
			}
			num2 = PageIndex;
			if (true)
			{
				if (num2 == 2)
				{
					global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolmeasuremillinghead)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
					global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_toolmeasuremillinghead)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				}
				break;
			}
			goto IL_00de;
			IL_00dd:
			num2 = PageIndex;
			goto IL_00de;
		}
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

	public void MenuButtonColorsCalibration(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(_0011);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		global::_008D._007E_000F_0007(this._0001, PageIndex);
		if (PageIndex == 0)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_xaxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_xaxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 1)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_yaxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_yaxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_zaxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_zaxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 3)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_caxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_caxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 4)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_aaxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_aaxis)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 5)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_cnc)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_cnc)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_jog)) && clsAppMarbleItems.frmJogPageV1 != null)
			{
				clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				clsAppMarbleItems.frmJogPageV1.Init();
				_0008_0004._007E_0008_0010(clsAppMarbleItems.frmJogPageV1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_mdi)))
			{
				if (clsAppMarbleItems.frmMDIPageV1 != null)
				{
					clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
					clsAppMarbleItems.frmMDIPageV1.Init();
					_0008_0004._007E_0008_0010(clsAppMarbleItems.frmMDIPageV1);
				}
				else if (clsAppMarbleItems.frmMDIPageV2 != null)
				{
					clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
					clsAppMarbleItems.frmMDIPageV2.Init();
					_0008_0004._007E_0008_0010(clsAppMarbleItems.frmMDIPageV2);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_apply)))
			{
				Apply();
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
				clsAppMarbleVars.cMachine.bWriteAppParameter = true;
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_milling)))
			{
				MenuButtonColors(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millinghead)))
			{
				MenuButtonColors(2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolchange)))
			{
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
				MenuButtonColors(4);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_camera)))
			{
				MenuButtonColors(5);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_vacuum)))
			{
				MenuButtonColors(6);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_materialmeasure)))
			{
				MenuButtonColors(7);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_warmup)))
			{
				MenuButtonColors(8);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_lubrication)))
			{
				MenuButtonColors(9);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_positions)))
			{
				MenuButtonColors(10);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_misc)))
			{
				MenuButtonColors(11);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_calibration)))
			{
				MenuButtonColors(12);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_kinematic)))
			{
				MenuButtonColors(13);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_IO1)))
			{
				MenuButtonColors(14);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_IO2)))
			{
				MenuButtonColors(15);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_absoluteset)))
			{
				MenuButtonColors(16);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_safeparameters)))
			{
				MenuButtonColors(17);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_xaxis)))
			{
				MenuButtonColorsCalibration(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_yaxis)))
			{
				MenuButtonColorsCalibration(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_zaxis)))
			{
				MenuButtonColorsCalibration(2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_caxis)))
			{
				MenuButtonColorsCalibration(3);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_aaxis)))
			{
				MenuButtonColorsCalibration(4);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cnc)))
			{
				MenuButtonColorsCalibration(5);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolmeasuresaw)))
			{
				MenuButtonColorsToolMeasure(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolmeasuremilling)))
			{
				MenuButtonColorsToolMeasure(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolmeasuremillinghead)))
			{
				MenuButtonColorsToolMeasure(2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetx)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo2 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo2, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367467)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo2);
				if (buDialogMessageBoxYesNo2.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitnegx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnegx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetX)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo3 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo3, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367467)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo3);
				if (buDialogMessageBoxYesNo3.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitposx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetY)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo4 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo4, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367365)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo4);
				if (buDialogMessageBoxYesNo4.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitnegy, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnegy, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetY)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo5 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo5, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367365)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo5);
				if (buDialogMessageBoxYesNo5.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitposy, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposy, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetZ)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo6 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo6, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367821)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo6);
				if (buDialogMessageBoxYesNo6.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitnegz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnegz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetZ)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo7 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo7, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367821)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo7);
				if (buDialogMessageBoxYesNo7.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitposz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposz, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetA)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo8 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo8, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367733)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo8);
				if (buDialogMessageBoxYesNo8.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitnega, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnega, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetA)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo9 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo9, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367733)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo9);
				if (buDialogMessageBoxYesNo9.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitposa, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposa, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitminusgetC)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo10 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo10, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367613)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo10);
				if (buDialogMessageBoxYesNo10.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitnegc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitnegc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1) - clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitplusgetC)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo11 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo11, global::_0014._009F_0003(buLangTranslate.preDef.Position, _0015(107397773), buLangTranslate.preDef.Set), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107367613)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo11);
				if (buDialogMessageBoxYesNo11.Result != DialogResult.Yes)
				{
					return;
				}
				global::_0095._007E_0008_0008(spn_datalimitposc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1));
				global::_0095._007E_0008_0008(spn_softlimitposc, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 1) + clsAppMarbleVars.varInterface.DataLimitSoftLimitDiff);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitdisablex)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo12 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo12, global::_0014._009F_0003(buLangTranslate.preDef.Limit, _0015(107397773), buLangTranslate.preDef.Disable), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToDisableLimit, _0015(107367467)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo12);
				if (buDialogMessageBoxYesNo12.Result != DialogResult.Yes)
				{
					return;
				}
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
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo13 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo13, global::_0014._009F_0003(buLangTranslate.preDef.Limit, _0015(107397773), buLangTranslate.preDef.Disable), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToDisableLimit, _0015(107367365)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo13);
				if (buDialogMessageBoxYesNo13.Result != DialogResult.Yes)
				{
					return;
				}
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
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo14 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo14, global::_0014._009F_0003(buLangTranslate.preDef.Limit, _0015(107397773), buLangTranslate.preDef.Disable), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToDisableLimit, _0015(107367821)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo14);
				if (buDialogMessageBoxYesNo14.Result != DialogResult.Yes)
				{
					return;
				}
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
				if (false)
				{
					goto IL_2574;
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_limitdisablea)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo15 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo15, global::_0014._009F_0003(buLangTranslate.preDef.Limit, _0015(107397773), buLangTranslate.preDef.Disable), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToDisableLimit, _0015(107367733)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo15);
				if (buDialogMessageBoxYesNo15.Result != DialogResult.Yes)
				{
					if (0 == 0)
					{
						return;
					}
					goto IL_4f24;
				}
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
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo16 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo16, global::_0014._009F_0003(buLangTranslate.preDef.Limit, _0015(107397773), buLangTranslate.preDef.Disable), global::_0002._0003(buLangTranslate.preSentences.DoYouWantToDisableLimit, _0015(107367613)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo16);
				if (buDialogMessageBoxYesNo16.Result != DialogResult.Yes)
				{
					return;
				}
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_calibx)) && ((clsAppMarbleVars.varRuntime.AxX >= 0) & (clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)))
			{
				double num = global::_0007._007E_0094(spn_calibx_unit);
				double num2 = global::_0007._007E_0094(spn_calibx_gear);
				_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_calibx_moveval), global::_0007._007E_0094(spn_calibx_measuredeval), true, ref num, ref num2);
				global::_0095._007E_0008_0008(spn_calibx_unit, num);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_caliby)) && ((clsAppMarbleVars.varRuntime.AxY >= 0) & (clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)))
			{
				double num3 = global::_0007._007E_0094(spn_caliby_unit);
				double num4 = global::_0007._007E_0094(spn_caliby_gear);
				_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_caliby_moveval), global::_0007._007E_0094(spn_caliby_measuredeval), true, ref num3, ref num4);
				global::_0095._007E_0008_0008(spn_caliby_unit, num3);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_calibz)) && ((clsAppMarbleVars.varRuntime.AxZ >= 0) & (clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)))
			{
				double num5 = global::_0007._007E_0094(spn_calibz_unit);
				double num6 = global::_0007._007E_0094(spn_calibz_gear);
				_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_calibz_moveval), global::_0007._007E_0094(spn_calibz_measuredeval), true, ref num5, ref num6);
				global::_0095._007E_0008_0008(spn_calibz_unit, num5);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_caliba)) && ((clsAppMarbleVars.varRuntime.AxA >= 0) & (clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)))
			{
				double num7 = global::_0007._007E_0094(spn_caliba_unit);
				double num8 = global::_0007._007E_0094(spn_caliba_gear);
				_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_caliba_moveval), global::_0007._007E_0094(spn_caliba_measuredeval), true, ref num7, ref num8);
				global::_0095._007E_0008_0008(spn_caliba_unit, num7);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_calibc)))
			{
				goto IL_2574;
			}
			goto IL_2620;
			IL_2620:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasurecalculate)))
			{
				double Val = 0.0;
				clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, _0015(107451271), ref Val);
				double num9 = global::_0007._007E_0094(spn_SawDiaMeasurecalcDiameter) / 2.0 - Val;
				global::_0095._007E_0008_0008(spn_SawDiaMeasureConstant, num9);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasureshowcalc)))
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasurecalc)))
			{
				double Val2 = 0.0;
				clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, _0015(107451234), ref Val2);
				double num10 = global::_0007._007E_0094(spn_millingmeasurecalc) - Val2;
				global::_0095._007E_0008_0008(spn_MillingLenMeasureConstant, num10);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasurecalcshow)))
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasurecalc)))
			{
				double Val3 = 0.0;
				clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, _0015(107451225), ref Val3);
				double num11 = global::_0007._007E_0094(spn_millingheadmeasurecalcLEn) - Val3;
				global::_0095._007E_0008_0008(spn_MillingHeadLenMeasureConstant, num11);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasurecalcshow)))
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_MaterialMeasureCalc)))
			{
				double Val4 = 0.0;
				clsAppMarbleVars.cmdMarble.readLREALVar(CodesysVariableBaseType.Global, _0015(107451144), ref Val4);
				double num12 = global::_0007._007E_0094(spn_MaterialMeasureCalcThickness) - Val4;
				global::_0095._007E_0008_0008(spn_MaterialMeasureConstant, num12);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_MaterialMeasureCalcShow)))
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_generalparkgo)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo17 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo17, global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preDef.Park,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0014._009F_0003(buLangTranslate.preSentences.DoYouWantToGoPosition, _0015(107397773), buLangTranslate.preDef.Park));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo17);
				if (buDialogMessageBoxYesNo17.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val = global::_0007._007E_0094(spn_generalparkx);
					double val2 = global::_0007._007E_0094(spn_generalparky);
					double val3 = global::_0007._007E_0094(spn_generalparkz);
					double val4 = global::_0007._007E_0094(spn_generalparka);
					double val5 = global::_0007._007E_0094(spn_generalparkc);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val2, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val3, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val4, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val5, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_wagongo)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo18 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo18, global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preDef.Table,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0014._009F_0003(buLangTranslate.preSentences.DoYouWantToGoPosition, _0015(107397773), buLangTranslate.preDef.Table));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo18);
				if (buDialogMessageBoxYesNo18.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val6 = global::_0007._007E_0094(spn_wagonposX);
					double val7 = global::_0007._007E_0094(spn_wagonposY);
					double val8 = global::_0007._007E_0094(spn_wagonposZ);
					double val9 = global::_0007._007E_0094(spn_wagonposA);
					double val10 = global::_0007._007E_0094(spn_wagonposC);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val6, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val7, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val8, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val9, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val10, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_camerago)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo19 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo19, global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preDef.Camera,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0014._009F_0003(buLangTranslate.preSentences.DoYouWantToGoPosition, _0015(107397773), buLangTranslate.preDef.Camera));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo19);
				if (buDialogMessageBoxYesNo19.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val11 = global::_0007._007E_0094(spn_CameraPositionX);
					double val12 = global::_0007._007E_0094(spn_CameraPositionY);
					double val13 = global::_0007._007E_0094(spn_CameraPositionZ);
					double val14 = global::_0007._007E_0094(spn_CameraPositionA);
					double val15 = global::_0007._007E_0094(spn_CameraPositionC);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val11, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val12, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val13, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val14, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val15, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasurego)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo20 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo20, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.Saw,
					_0015(107397773),
					buLangTranslate.preDef.Measure,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToGoPosition,
					_0015(107397773),
					buLangTranslate.preDef.Saw,
					_0015(107397773),
					buLangTranslate.preDef.Measure
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo20);
				if (buDialogMessageBoxYesNo20.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val16 = global::_0007._007E_0094(spn_SawDiaMeasurePositionX);
					double val17 = global::_0007._007E_0094(spn_SawDiaMeasurePositionY);
					double val18 = global::_0007._007E_0094(spn_SawDiaMeasurePositionFastZ);
					double val19 = global::_0007._007E_0094(spn_SawDiaMeasurePositionA);
					double val20 = global::_0007._007E_0094(spn_SawDiaMeasurePositionC);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val16, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val17, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val18, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val19, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val20, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasurego)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo21 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo21, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.Milling,
					_0015(107397773),
					buLangTranslate.preDef.Measure,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToGoPosition,
					_0015(107397773),
					buLangTranslate.preDef.Milling,
					_0015(107397773),
					buLangTranslate.preDef.Measure
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo21);
				if (buDialogMessageBoxYesNo21.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val21 = global::_0007._007E_0094(spn_MillingLenMeasurePositionX);
					double val22 = global::_0007._007E_0094(spn_MillingLenMeasurePositionY);
					double val23 = global::_0007._007E_0094(spn_MillingLenMeasurePositionFastZ);
					double val24 = global::_0007._007E_0094(spn_MillingLenMeasurePositionA);
					double val25 = global::_0007._007E_0094(spn_MillingLenMeasurePositionC);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val21, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val22, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val23, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val24, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val25, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasurego)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo22 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo22, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.MillingHead,
					_0015(107397773),
					buLangTranslate.preDef.Measure,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToGoPosition,
					_0015(107397773),
					buLangTranslate.preDef.MillingHead,
					_0015(107397773),
					buLangTranslate.preDef.Measure
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo22);
				if (buDialogMessageBoxYesNo22.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val26 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionX);
					double val27 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionY);
					double val28 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionFastZ);
					double val29 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionA);
					double val30 = global::_0007._007E_0094(spn_MillingHeadLenMeasurePositionC);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val26, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val27, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val28, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val29, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val30, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawparkgo)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo23 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo23, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.Saw,
					_0015(107397773),
					buLangTranslate.preDef.Park,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToGoPosition,
					_0015(107397773),
					buLangTranslate.preDef.Saw,
					_0015(107397773),
					buLangTranslate.preDef.Park
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo23);
				if (buDialogMessageBoxYesNo23.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val31 = global::_0007._007E_0094(spn_SawModePositionX);
					double val32 = global::_0007._007E_0094(spn_SawModePositionY);
					double val33 = global::_0007._007E_0094(spn_SawModePositionZ);
					double val34 = global::_0007._007E_0094(spn_SawModePositionA);
					double val35 = global::_0007._007E_0094(spn_SawModePositionC);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val31, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val32, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val33, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val34, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val35, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingparkgo)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo24 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo24, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.Milling,
					_0015(107397773),
					buLangTranslate.preDef.Park,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToGoPosition,
					_0015(107397773),
					buLangTranslate.preDef.Milling,
					_0015(107397773),
					buLangTranslate.preDef.Park
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo24);
				if (buDialogMessageBoxYesNo24.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val36 = global::_0007._007E_0094(spn_MillingModePositionX);
					double val37 = global::_0007._007E_0094(spn_MillingModePositionY);
					double val38 = global::_0007._007E_0094(spn_MillingModePositionZ);
					double val39 = global::_0007._007E_0094(spn_MillingModePositionA);
					double val40 = global::_0007._007E_0094(spn_MillingModePositionC);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val36, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val37, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val38, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val39, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val40, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadparkgo)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo25 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo25, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.MillingHead,
					_0015(107397773),
					buLangTranslate.preDef.Park,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Move
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToGoPosition,
					_0015(107397773),
					buLangTranslate.preDef.MillingHead,
					_0015(107397773),
					buLangTranslate.preDef.Park
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo25);
				if (buDialogMessageBoxYesNo25.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					double val41 = global::_0007._007E_0094(spn_MillingHeadModePositionX);
					double val42 = global::_0007._007E_0094(spn_MillingHeadModePositionY);
					double val43 = global::_0007._007E_0094(spn_MillingHeadModePositionZ);
					double val44 = global::_0007._007E_0094(spn_MillingHeadModePositionA);
					double val45 = global::_0007._007E_0094(spn_MillingHeadModePositionC);
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val41, _0015(107451103));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val42, _0015(107451078));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val43, _0015(107451085));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val44, _0015(107450548));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val45, _0015(107450523));
					clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0015(107450466));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_generalparkgetpos)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo26 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo26, global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preDef.Park,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Set
				}), global::_0014._009F_0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107397773), buLangTranslate.preDef.Park));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo26);
				if (buDialogMessageBoxYesNo26.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					if (clsAppMarbleVars.varRuntime.AxX >= 0)
					{
						global::_0095._007E_0008_0008(spn_generalparkx, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
					}
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
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_wagongetposition)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo27 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo27, global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preDef.Table,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Set
				}), global::_0014._009F_0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107397773), buLangTranslate.preDef.Table));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo27);
				if (buDialogMessageBoxYesNo27.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
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
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cameragetposition)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo28 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo28, global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preDef.Camera,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Set
				}), global::_0014._009F_0003(buLangTranslate.preSentences.DoYouWantToSetPosition, _0015(107397773), buLangTranslate.preDef.Camera));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo28);
				if (buDialogMessageBoxYesNo28.Result != DialogResult.Yes)
				{
					return;
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
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawmeasuregetpos)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo29 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo29, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.Saw,
					_0015(107397773),
					buLangTranslate.preDef.Measure,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Set
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToSetPosition,
					_0015(107397773),
					buLangTranslate.preDef.Saw,
					_0015(107397773),
					buLangTranslate.preDef.Measure
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo29);
				if (buDialogMessageBoxYesNo29.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
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
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawparkgetpos)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo30 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo30, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.Saw,
					_0015(107397773),
					buLangTranslate.preDef.Park,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Set
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToSetPosition,
					_0015(107397773),
					buLangTranslate.preDef.Saw,
					_0015(107397773),
					buLangTranslate.preDef.Park
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo30);
				if (buDialogMessageBoxYesNo30.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
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
					if (clsAppMarbleVars.varRuntime.AxA >= 0)
					{
						global::_0095._007E_0008_0008(spn_SawModePositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
					}
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingmeasuregetpos)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo31 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo31, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.Milling,
					_0015(107397773),
					buLangTranslate.preDef.Measure,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Set
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToSetPosition,
					_0015(107397773),
					buLangTranslate.preDef.Milling,
					_0015(107397773),
					buLangTranslate.preDef.Measure
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo31);
				if (buDialogMessageBoxYesNo31.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
				{
					if (clsAppMarbleVars.varRuntime.AxX >= 0)
					{
						global::_0095._007E_0008_0008(spn_MillingLenMeasurePositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
					}
					goto IL_4f24;
				}
			}
			goto IL_50ca;
			IL_4f24:
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
			goto IL_50ca;
			IL_50ca:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingparkgetpos)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo32 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo32, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.Milling,
					_0015(107397773),
					buLangTranslate.preDef.Park,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Set
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToSetPosition,
					_0015(107397773),
					buLangTranslate.preDef.Milling,
					_0015(107397773),
					buLangTranslate.preDef.Park
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo32);
				if (buDialogMessageBoxYesNo32.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
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
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadmeasuregetpos)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo33 = new buDialogMessageBoxYesNo();
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo33, global::_0013_0002._0090_0008(new string[7]
				{
					buLangTranslate.preDef.MillingHead,
					_0015(107397773),
					buLangTranslate.preDef.Measure,
					_0015(107397773),
					buLangTranslate.preDef.Position,
					_0015(107397773),
					buLangTranslate.preDef.Set
				}), global::_0013_0002._0090_0008(new string[5]
				{
					buLangTranslate.preSentences.DoYouWantToSetPosition,
					_0015(107397773),
					buLangTranslate.preDef.MillingHead,
					_0015(107397773),
					buLangTranslate.preDef.Measure
				}));
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo33);
				if (buDialogMessageBoxYesNo33.Result != DialogResult.Yes)
				{
					return;
				}
				if (AppBool.Connected)
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
			}
			if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadparkgetpos)))
			{
				return;
			}
			buDialogMessageBoxYesNo buDialogMessageBoxYesNo34 = new buDialogMessageBoxYesNo();
			_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo34, global::_0013_0002._0090_0008(new string[7]
			{
				buLangTranslate.preDef.MillingHead,
				_0015(107397773),
				buLangTranslate.preDef.Park,
				_0015(107397773),
				buLangTranslate.preDef.Position,
				_0015(107397773),
				buLangTranslate.preDef.Set
			}), global::_0013_0002._0090_0008(new string[5]
			{
				buLangTranslate.preSentences.DoYouWantToSetPosition,
				_0015(107397773),
				buLangTranslate.preDef.MillingHead,
				_0015(107397773),
				buLangTranslate.preDef.Park
			}));
			_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo34);
			if (buDialogMessageBoxYesNo34.Result == DialogResult.Yes && AppBool.Connected)
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
			return;
			IL_2574:
			if ((clsAppMarbleVars.varRuntime.AxC >= 0) & (clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1))
			{
				double num13 = global::_0007._007E_0094(spn_calibc_unit);
				double num14 = global::_0007._007E_0094(spn_calibc_gear);
				_0005_0007._007E_0088_0013(clsAppMarbleVars.cMachine.Commands, global::_0007._007E_0094(spn_calibc_moveval), global::_0007._007E_0094(spn_calibc_measuredeval), true, ref num13, ref num14);
				global::_0095._007E_0008_0008(spn_calibc_unit, num13);
			}
			goto IL_2620;
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

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = P_0 as Control;
		bool flag2;
		while (true)
		{
			IL_0010:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawbwd)))
			{
				goto IL_0049;
			}
			goto IL_0077;
			IL_0077:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawfwd)))
			{
				if (false)
				{
					break;
				}
				clsAppMarbleVars.varInterface.SawSpeed = global::_0007._007E_0094(spn_sawspeed);
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawStartWithSpeed);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_spindlebwd)))
			{
				clsAppMarbleVars.varInterface.SpindleSpeed = 0.0 - global::_0007._007E_0094(spn_millingspeed);
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleStartWithSpeed);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_spindlefwd)))
			{
				clsAppMarbleVars.varInterface.SpindleSpeed = global::_0007._007E_0094(spn_millingspeed);
				do
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleStartWithSpeed);
				}
				while (false);
			}
			bool num;
			while (true)
			{
				num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_rocketdown));
				if (false)
				{
					break;
				}
				if (num)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonDown);
					if (7 == 0)
					{
						goto IL_0049;
					}
					if (-1 == 0)
					{
						goto IL_0010;
					}
				}
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_rocketup)))
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonUp);
				}
				bool num2 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_watersawonoff));
				do
				{
					if (num2)
					{
						clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Water);
					}
					bool flag = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_laserOnOff));
					num2 = flag;
				}
				while (false);
				if (num2)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Laser);
				}
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cameraOpenClose)))
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCover);
				}
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_lubricationOnOff)))
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Lubrication);
					if (4 == 0)
					{
						continue;
					}
				}
				goto IL_0314;
			}
			goto IL_037d;
			IL_0065:
			clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawStartWithSpeed);
			goto IL_0077;
			IL_037d:
			flag2 = num;
			break;
			IL_0314:
			if (2 == 0)
			{
				goto IL_0065;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolmeasureupdown)))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.ToolMeasureValf);
			}
			num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_materialmeasureUpDown));
			goto IL_037d;
			IL_0049:
			clsAppMarbleVars.varInterface.SawSpeed = 0.0 - global::_0007._007E_0094(spn_sawspeed);
			goto IL_0065;
		}
		if (flag2)
		{
			clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.MaterialPiston);
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
			int num = ((this._0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_001A_0002(this._0001);
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

	static F_MarbleMachineSettingsV2()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleMachineSettingsV2));
		Captions = new List<string>();
	}
}
