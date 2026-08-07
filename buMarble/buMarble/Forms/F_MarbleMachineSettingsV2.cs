// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleMachineSettingsV2
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buCadCamResVer5.Marble;
using buClass;
using buControls;
using buControls.Controls;
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

public class F_MarbleMachineSettingsV2 : Form
{
  public buButton btn_toolmag8;
  public buButton btn_toolmag7;
  public buButton btn_toolmag6;
  public buButton btn_toolmag5;
  public buButton btn_toolmag4;
  public buButton btn_toolmag3;
  public buButton btn_toolmag2;
  public buSpin spn_sawsocket;
  public buButton btn_saw_gozeroposition;
  public buButton btn_milling_gozeroposition;
  public buButton btn_millinghead_gozeroposition;
  internal ImageList \u0002;
  internal PictureBox \u0004;
  internal PictureBox \u0005;
  internal ImageList \u0003;
  public buButton btn_spindledowndown;
  public buButton btn_spindledownup;
  public buButton btn_mdi;
  public buButton btn_jog;
  internal buTextBox \u0001;
  internal buTextBox \u0002;
  internal buTextBox \u0003;
  public buSpin spn_sawshoulderthickness;
  public static byte f000725;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_millinghead;
  public buButton btn_milling;
  public buButton btn_saw;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal PictureBox \u0001;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
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
  internal buLabel \u0004;
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
  internal buLabel \u0005;
  internal TabPage \u0001;
  public buSpin spn_MillingHeadExtraG54OffsetX;
  public buSpin spn_MillingHeadExtraG54OffsetZ;
  public buSpin spn_MillingHeadExtraG54OffsetY;
  internal buLabel \u0006;
  internal TabPage \u0002;
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
  internal TabPage \u0003;
  internal buLabel \u0007;
  public buSpin spn_ToolchangeX10;
  public buSpin spn_ToolchangeY10;
  public buSpin spn_ToolchangeZ10;
  internal buLabel \u0008;
  public buSpin spn_ToolchangeX9;
  public buSpin spn_ToolchangeY9;
  public buSpin spn_ToolchangeZ9;
  internal buLabel \u000E;
  public buSpin spn_ToolchangeX8;
  public buSpin spn_ToolchangeY8;
  public buSpin spn_ToolchangeZ8;
  internal buLabel \u000F;
  public buSpin spn_ToolchangeX7;
  public buSpin spn_ToolchangeY7;
  public buSpin spn_ToolchangeZ7;
  internal buLabel \u0010;
  public buSpin spn_ToolchangeX6;
  public buSpin spn_ToolchangeY6;
  public buSpin spn_ToolchangeZ6;
  internal buLabel \u0011;
  public buSpin spn_ToolchangeX5;
  public buSpin spn_ToolchangeY5;
  public buSpin spn_ToolchangeZ5;
  internal buLabel \u0012;
  public buSpin spn_ToolchangeX4;
  public buSpin spn_ToolchangeY4;
  public buSpin spn_ToolchangeZ4;
  internal buLabel \u0013;
  public buSpin spn_ToolchangeX3;
  public buSpin spn_ToolchangeY3;
  public buSpin spn_ToolchangeZ3;
  internal buLabel \u0014;
  public buSpin spn_ToolchangeX2;
  public buSpin spn_ToolchangeY2;
  public buSpin spn_ToolchangeZ2;
  internal buLabel \u0015;
  internal buLabel \u0016;
  internal buLabel \u0017;
  internal buLabel \u0018;
  public buSpin spn_ToolchangeX1;
  public buSpin spn_ToolchangeY1;
  public buSpin spn_ToolchangeZ1;
  internal buLabel \u0019;
  internal TabPage \u0004;
  public buSpin spn_ToolMeasureSlowApproachVelocity;
  internal buLabel \u001A;
  public buSpin spn_ToolMeasureCoverOnTimeSec;
  public buSpin spn_ToolMeasureSlowLeaveVelocity;
  public buSpin spn_ToolMeasureJerk;
  public buSpin spn_ToolMeasureFastVelocity;
  public buSpin spn_ToolMeasureAccDec;
  public buSpin spn_ToolMeasureCoverOffTimeSec;
  internal TabPage \u0005;
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
  internal buLabel \u001B;
  internal TabPage \u0006;
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
  internal buLabel \u001C;
  internal TabPage \u0007;
  public buSpin spn_MaterialMeasureYBorderOffset;
  public buSpin spn_MaterialMeasureXBorderOffset;
  public buSpin spn_MaterialMeasureMaxSawDiameter;
  public buSpin spn_MaterialMeasureG54OffsetY;
  public buSpin spn_MaterialMeasureG54OffsetX;
  internal Panel \u0001;
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
  internal buLabel \u001D;
  internal TabPage \u0008;
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
  internal buLabel \u001E;
  internal TabPage \u000E;
  public buCheckBox chk_LubricationEnable;
  public buSpin spn_LubricationTimeSec;
  public buSpin spn_LubricationBlockOnOffTimeSec;
  public buSpin spn_LubricationPeriodWaitMin;
  public buSpin spn_LubricationLevelOnOffTimeSec;
  internal buLabel \u001F;
  internal TabPage \u000F;
  internal buLabel \u007F;
  internal buLabel \u0080;
  public buButton btn_generalparkgo;
  public buButton btn_generalparkgetpos;
  internal buLabel \u0081;
  internal buLabel \u0082;
  internal buLabel \u0083;
  internal buLabel \u0084;
  internal buLabel \u0086;
  public buSpin spn_generalparkx;
  public buSpin spn_generalparkc;
  public buSpin spn_generalparky;
  public buSpin spn_generalparka;
  public buSpin spn_generalparkz;
  public buSpin spn_ParkPosTimeOutSec;
  internal buLabel \u0087;
  internal TabPage \u0010;
  internal buLabel \u0088;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  public buSpin spn_WaterOnOffTimerSec;
  public buSpin spn_LaserOnOffTimerSec;
  public buSpin spn_StartPointPosTimeOutSec;
  public buCheckBox chk_GoZUpPositionWhenStart;
  public buCheckBox chk_BuzzerEnable;
  public buSpin spn_BuzzerTimeSec;
  internal buLabel \u0089;
  internal TabPage \u0011;
  public buButton btn_cnc;
  public buButton btn_caxis;
  public buButton btn_aaxis;
  public buButton btn_zaxis;
  public buButton btn_yaxis;
  public buButton btn_xaxis;
  internal buTab \u0001;
  internal TabPage \u0012;
  internal buLabel \u008A;
  public buCheckBox chk_hardlimitx;
  internal buLabel \u008B;
  public buCheckBox chk_joglimitx;
  public buButton btn_limitplusgetX;
  public buCheckBox chk_softlimitx;
  internal buLabel \u008C;
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
  internal TabPage \u0013;
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
  internal buLabel \u008D;
  internal buLabel \u008E;
  internal buLabel \u008F;
  public buButton btn_caliby;
  public buSpin spn_caliby_measuredeval;
  public buSpin spn_caliby_moveval;
  internal TabPage \u0014;
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
  internal buLabel \u0090;
  internal buLabel \u0091;
  internal buLabel \u0092;
  internal TabPage \u0015;
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
  internal buLabel \u0093;
  internal buLabel \u0094;
  internal buLabel \u0095;
  internal TabPage \u0016;
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
  internal buLabel \u0096;
  internal buLabel \u0097;
  internal buLabel \u0098;
  internal TabPage \u0017;
  internal buLabel \u0099;
  public buSpin spn_cncJerk;
  public buSpin spn_cncG1AccDec;
  public buSpin spn_cncG0AccDec;
  internal TabPage \u0018;
  public buSpin spn_c270ZDisA45;
  public buSpin spn_c180ZDisA45;
  public buSpin spn_A_AxisSawDistance;
  public buSpin spn_c90ZDisA45;
  public buSpin spn_motor_A_AxisZDistance;
  public buSpin spn_c0ZDisA45;
  public buSpin spn_C_AxisSawDistance;
  public buSpin spn_c270ADisA45;
  internal buLabel \u009A;
  public buSpin spn_c180ADisA45;
  public buSpin spn_c0ZDisA0;
  public buSpin spn_c90ADisA45;
  internal buLabel \u009B;
  public buSpin spn_c0ADisA45;
  internal buLabel \u009C;
  public buSpin spn_c270ZDisA0;
  internal buLabel \u009D;
  public buSpin spn_c180ZDisA0;
  internal buLabel \u009E;
  public buSpin spn_c90ZDisA0;
  internal buLabel \u009F;
  internal buLabel \u0001\u0002;
  internal TabPage \u0019;
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
  internal buLabel \u0002\u0002;
  internal buLabel \u0003\u0002;
  public buCheckBox chk_spindledown;
  public buButton btn_rocketdownI;
  public buButton btn_rocketdownO;
  internal TabPage \u001A;
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
  internal buLabel \u0004\u0002;
  internal buLabel \u0005\u0002;
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
  internal TabPage \u001B;
  internal Panel \u0002;
  public buButton btn_sawmeasurecalculate;
  public buSpin spn_SawDiaMeasurecalcDiameter;
  public buButton btn_sawmeasureshowcalc;
  public buSpin spn_SawMeasureTimeOutSec;
  public buSpin spn_SawDiaMeasureConstant;
  public buSpin spn_SawDiaMeasurePositionLimitZ;
  internal Panel \u0003;
  public buButton btn_millingmeasurecalc;
  public buSpin spn_millingmeasurecalc;
  public buButton btn_millingmeasurecalcshow;
  public buSpin spn_MillingMeasureTimeOutSec;
  public buSpin spn_MillingLenMeasureConstant;
  public buSpin spn_MillingLenMeasurePositionLimitZ;
  internal Panel \u0004;
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
  internal buLabel \u0006\u0002;
  internal buLabel \u0007\u0002;
  internal buLabel \u0008\u0002;
  internal buLabel \u000E\u0002;
  internal TabPage \u001C;
  public buButton btn_cabsolutereset;
  public buButton btn_aabsolutereset;
  public buButton btn_zabsolutereset;
  public buButton btn_yabsolutereset;
  public buButton btn_xrabsoluteeset;
  internal buLabel \u000F\u0002;
  internal buLabel \u0010\u0002;
  public buSpin spn_absolutesetC;
  public buSpin spn_absolutesetA;
  public buSpin spn_absolutesetZ;
  public buSpin spn_absolutesetY;
  public buSpin spn_absolutesetX;
  internal TabPage \u001D;
  public buButton btn_safeparameters;
  public buButton btn_absoluteset;
  public buSpin spn_MillingLenMeasureMaxLength;
  public buSpin spn_MillingLenMeasureMinLength;
  public buSpin spn_SawDiaMeasureMinDaimeter;
  public buSpin spn_SawDiaMeasureMaxDaimeter;
  internal buLabel \u0011\u0002;
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

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(((F_MarbleToolCurrentAll) this).\u0001.Controls);
    if (PageIndex == 0)
      ((F_MarbleToolCurrentAll) this).btn_sawtool = buControlCommands.SetButtonColorAll(((F_MarbleToolCurrentAll) this).btn_sawtool, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex == 1)
      ((F_MarbleToolCurrentAll) this).btn_millingtool = buControlCommands.SetButtonColorAll(((F_MarbleToolCurrentAll) this).btn_millingtool, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex == 2)
      ((F_MarbleToolCurrentAll) this).btn_millingheadtool = buControlCommands.SetButtonColorAll(((F_MarbleToolCurrentAll) this).btn_millingheadtool, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    if (PageIndex == 3)
      ((F_MarbleToolCurrentAll) this).btn_magazine = buControlCommands.SetButtonColorAll(((F_MarbleToolCurrentAll) this).btn_magazine, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    ((F_MarbleToolCurrentAll) this).SelectedTab = PageIndex;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  public int ToolTypeToImageIndex(ToolType T)
  {
    int imageIndex;
    switch (T)
    {
      case ToolType.Flat:
        imageIndex = 0;
        break;
      case ToolType.Sphere:
        imageIndex = 1;
        break;
      case ToolType.Bullnose:
        imageIndex = 2;
        break;
      case ToolType.Taper:
        imageIndex = 3;
        break;
      case ToolType.Lollipop:
        imageIndex = 8;
        break;
      case ToolType.Dove:
        imageIndex = 7;
        break;
      case ToolType.Chamfer:
        imageIndex = 5;
        break;
      case ToolType.Barrel:
        imageIndex = 4;
        break;
      case ToolType.ConvexTip:
        imageIndex = 6;
        break;
      default:
        imageIndex = 0;
        break;
    }
    return imageIndex;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    if (!obj1.Control || obj1.KeyCode == Keys.S)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolCurrentAll) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolCurrentAll) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMachineSettingsV2() => F_MarbleToolCurrentAll.Captions = new List<string>();

  public F_MarbleMachineSettingsV2() => \u0005.\u0003.\u0001(this);

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
    this.buTab_toolchange.ItemSize = new Size(1, 1);
    this.\u0001.ItemSize = new Size(1, 1);
    this.buTab_toolmeasure.ItemSize = new Size(1, 1);
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
    this.MenuButtonColorsToolMeasure(0);
    this.MenuButtonColorsToolChange(0);
    this.MenuButtonColorsCalibration(0);
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
    this.spn_ToolchangeX1.Value = buMarbleCalc.ToolInMagazine[1].Positions.Position.X;
    this.spn_ToolchangeY1.Value = buMarbleCalc.ToolInMagazine[1].Positions.Position.Y;
    this.spn_ToolchangeZ1.Value = buMarbleCalc.ToolInMagazine[1].Positions.Position.Z;
    this.spn_ToolchangeX2.Value = buMarbleCalc.ToolInMagazine[2].Positions.Position.X;
    this.spn_ToolchangeY2.Value = buMarbleCalc.ToolInMagazine[2].Positions.Position.Y;
    this.spn_ToolchangeZ2.Value = buMarbleCalc.ToolInMagazine[2].Positions.Position.Z;
    this.spn_ToolchangeX3.Value = buMarbleCalc.ToolInMagazine[3].Positions.Position.X;
    this.spn_ToolchangeY3.Value = buMarbleCalc.ToolInMagazine[3].Positions.Position.Y;
    this.spn_ToolchangeZ3.Value = buMarbleCalc.ToolInMagazine[3].Positions.Position.Z;
    this.spn_ToolchangeX4.Value = buMarbleCalc.ToolInMagazine[4].Positions.Position.X;
    this.spn_ToolchangeY4.Value = buMarbleCalc.ToolInMagazine[4].Positions.Position.Y;
    this.spn_ToolchangeZ4.Value = buMarbleCalc.ToolInMagazine[4].Positions.Position.Z;
    this.spn_ToolchangeX5.Value = buMarbleCalc.ToolInMagazine[5].Positions.Position.X;
    this.spn_ToolchangeY5.Value = buMarbleCalc.ToolInMagazine[5].Positions.Position.Y;
    this.spn_ToolchangeZ5.Value = buMarbleCalc.ToolInMagazine[5].Positions.Position.Z;
    this.spn_ToolchangeX6.Value = buMarbleCalc.ToolInMagazine[6].Positions.Position.X;
    this.spn_ToolchangeY6.Value = buMarbleCalc.ToolInMagazine[6].Positions.Position.Y;
    this.spn_ToolchangeZ6.Value = buMarbleCalc.ToolInMagazine[6].Positions.Position.Z;
    this.spn_ToolchangeX7.Value = buMarbleCalc.ToolInMagazine[7].Positions.Position.X;
    this.spn_ToolchangeY7.Value = buMarbleCalc.ToolInMagazine[7].Positions.Position.Y;
    this.spn_ToolchangeZ7.Value = buMarbleCalc.ToolInMagazine[7].Positions.Position.Z;
    this.spn_ToolchangeX8.Value = buMarbleCalc.ToolInMagazine[8].Positions.Position.X;
    this.spn_ToolchangeY8.Value = buMarbleCalc.ToolInMagazine[8].Positions.Position.Y;
    this.spn_ToolchangeZ8.Value = buMarbleCalc.ToolInMagazine[8].Positions.Position.Z;
    this.spn_ToolchangeX9.Value = buMarbleCalc.ToolInMagazine[9].Positions.Position.X;
    this.spn_ToolchangeY9.Value = buMarbleCalc.ToolInMagazine[9].Positions.Position.Y;
    this.spn_ToolchangeZ9.Value = buMarbleCalc.ToolInMagazine[9].Positions.Position.Z;
    this.spn_ToolchangeX10.Value = buMarbleCalc.ToolInMagazine[10].Positions.Position.X;
    this.spn_ToolchangeY10.Value = buMarbleCalc.ToolInMagazine[10].Positions.Position.Y;
    this.spn_ToolchangeZ10.Value = buMarbleCalc.ToolInMagazine[10].Positions.Position.Z;
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
    this.spn_MaterialMeasureG54OffsetX.Value = clsAppMarbleVars.varApp.MaterialMeasureG54OffsetX;
    this.spn_MaterialMeasureG54OffsetY.Value = clsAppMarbleVars.varApp.MaterialMeasureG54OffsetY;
    this.spn_MaterialMeasureMaxSawDiameter.Value = clsAppMarbleVars.varApp.MaterialMeasureMaxSawDiameter;
    this.spn_MaterialMeasureXBorderOffset.Value = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
    this.spn_MaterialMeasureYBorderOffset.Value = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
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
    this.spn_generalparkx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition;
    this.spn_generalparky.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition;
    this.spn_generalparkz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition;
    this.spn_generalparka.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition;
    this.spn_generalparkc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition;
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
      this.\u0002.Checked = true;
    else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == (MarbleParkModeAfterJob) 2)
      this.\u0001.Checked = true;
    else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.Saw)
      this.\u0003.Checked = true;
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
    this.spn_SawDiaMeasureMinDaimeter.Value = clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter;
    this.spn_SawDiaMeasureMaxDaimeter.Value = clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter;
    this.spn_MillingLenMeasureMinLength.Value = clsAppMarbleVars.varApp.MillingLenMeasureMinLength;
    this.spn_MillingLenMeasureMaxLength.Value = clsAppMarbleVars.varApp.MillingLenMeasureMaxLength;
    this.spn_MillingHeadLenMeasureMinLength.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength;
    this.spn_MillingHeadLenMeasureMaxLength.Value = clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength;
    ((F_MarbleMachineSettingsV1) this).spn_VacuumMaxSawDiameter.Value = clsAppMarbleVars.varApp.VacuumMaxSawDiameter;
    ((F_MarbleMachineSettingsV1) this).spn_MaxSpindleToolLengthForA45.Value = clsAppMarbleVars.varApp.MaxSpindleToolLengthForA45;
    this.spn_sawspeed.Value = clsAppMarbleVars.varInterface.SawSpeed;
    this.spn_millingspeed.Value = clsAppMarbleVars.varInterface.SpindleSpeed;
    this.spn_A_AxisSawDistance.Value = clsMarble.activeKinematic.RotateCenterOffsetOfA.Y;
    this.spn_motor_A_AxisZDistance.Value = clsMarble.activeKinematic.RotateCenterOffsetOfA.Z;
    this.spn_C_AxisSawDistance.Value = clsMarble.activeKinematic.RotateCenterOffsetOfC.Y;
    this.spn_c0ZDisA0.Value = clsMarble.activeKinematic.ZDistanceForA0AtC0;
    this.spn_c90ZDisA0.Value = clsMarble.activeKinematic.ZDistanceForA0AtC90;
    this.spn_c180ZDisA0.Value = clsMarble.activeKinematic.ZDistanceForA0AtC180;
    this.spn_c270ZDisA0.Value = clsMarble.activeKinematic.ZDistanceForA0AtC270;
    this.spn_c0ZDisA45.Value = clsMarble.activeKinematic.ZDistanceForA45AtC0;
    this.spn_c90ZDisA45.Value = clsMarble.activeKinematic.ZDistanceForA45AtC90;
    this.spn_c180ZDisA45.Value = clsMarble.activeKinematic.ZDistanceForA45AtC180;
    this.spn_c270ZDisA45.Value = clsMarble.activeKinematic.ZDistanceForA45AtC270;
    this.spn_c0ADisA45.Value = clsMarble.activeKinematic.ADistanceForA45AtC0;
    this.spn_c90ADisA45.Value = clsMarble.activeKinematic.ADistanceForA45AtC90;
    this.spn_c180ADisA45.Value = clsMarble.activeKinematic.ADistanceForA45AtC180;
    this.spn_c270ADisA45.Value = clsMarble.activeKinematic.ADistanceForA45AtC270;
    if (clsAppMarbleVars.varRuntime.AxX >= 0 & clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_calibx_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setUnit;
      this.spn_calibx_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setPulse;
      this.spn_calibx_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setGearRatio;
      this.spn_speedJogXSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogXAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogAcc;
      this.spn_speedJogXjerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveXSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveXAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveAcc;
      this.spn_speedMoveXJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveJerk;
      this.spn_speedJogX2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogX2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnegx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnegx.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimitx.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimitx.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove;
      this.chk_hardlimitx.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setHardLimitEnable;
    }
    if (clsAppMarbleVars.varRuntime.AxY >= 0 & clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_caliby_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
      this.spn_caliby_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setPulse;
      this.spn_caliby_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setGearRatio;
      this.spn_speedJogYSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogYAccDEc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogAcc;
      this.spn_speedJogYJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveYSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveYAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveAcc;
      this.spn_speedMoveYJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveJerk;
      this.spn_speedJogY2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogY2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposy.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnegy.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposy.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnegy.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimity.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimity.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove;
      this.chk_hardlimity.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setHardLimitEnable;
    }
    if (clsAppMarbleVars.varRuntime.AxZ >= 0 & clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_calibz_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setUnit;
      this.spn_calibz_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setPulse;
      this.spn_calibz_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setGearRatio;
      this.spn_speedJogZSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogZAccDEc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogAcc;
      this.spn_speedJogZJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveZSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveZAccDEc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveAcc;
      this.spn_speedMoveZJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveJerk;
      this.spn_speedJogZ2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogZ2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnegz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnegz.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimitz.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimitz.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove;
      this.chk_hardlimitz.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setHardLimitEnable;
    }
    if (clsAppMarbleVars.varRuntime.AxA >= 0 & clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_caliba_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit;
      this.spn_caliba_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse;
      this.spn_caliba_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio;
      this.spn_speedJogASpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogAAccDEc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogAcc;
      this.spn_speedJogAJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveASpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveAAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveAcc;
      this.spn_speedMoveAJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveJerk;
      this.spn_speedJogA2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogA2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposa.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnega.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposa.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnega.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimita.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimita.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove;
      this.chk_hardlimita.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setHardLimitEnable;
    }
    if (clsAppMarbleVars.varRuntime.AxC >= 0 & clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      this.spn_calibc_unit.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit;
      this.spn_calibc_pulse.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse;
      this.spn_calibc_gear.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio;
      this.spn_speedJogCSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogVelocity;
      this.spn_speedJogCAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogAcc;
      this.spn_speedJogCJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogJerk;
      this.spn_speedMoveCSpeed.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveVelocity;
      this.spn_speedMoveCAccDec.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveAcc;
      this.spn_speedMoveCJerk.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveJerk;
      this.spn_speedJogC2SpeedPerc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedPersentage;
      this.spn_speedJogC2SpeedTime.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedTimeSec;
      this.spn_softlimitposc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitPositive;
      this.spn_softlimitnegc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitNegative;
      this.spn_datalimitposc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitPositive;
      this.spn_datalimitnegc.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitNegative;
      this.chk_softlimitc.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable;
      this.chk_joglimitc.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove;
      this.chk_hardlimitc.Check = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setHardLimitEnable;
    }
    this.spn_cncG0AccDec.Value = clsAppMarbleVars.cMachine.varCNC.setG0Acc;
    this.spn_cncG1AccDec.Value = clsAppMarbleVars.cMachine.varCNC.setG1Acc;
    this.spn_cncJerk.Value = clsAppMarbleVars.cMachine.varCNC.setMaxJerk;
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
    buMarbleCalc.ToolInMagazine[1].Positions.Position.X = this.spn_ToolchangeX1.Value;
    buMarbleCalc.ToolInMagazine[1].Positions.Position.Y = this.spn_ToolchangeY1.Value;
    buMarbleCalc.ToolInMagazine[1].Positions.Position.Z = this.spn_ToolchangeZ1.Value;
    buMarbleCalc.ToolInMagazine[2].Positions.Position.X = this.spn_ToolchangeX2.Value;
    buMarbleCalc.ToolInMagazine[2].Positions.Position.Y = this.spn_ToolchangeY2.Value;
    buMarbleCalc.ToolInMagazine[2].Positions.Position.Z = this.spn_ToolchangeZ2.Value;
    buMarbleCalc.ToolInMagazine[3].Positions.Position.X = this.spn_ToolchangeX3.Value;
    buMarbleCalc.ToolInMagazine[3].Positions.Position.Y = this.spn_ToolchangeY3.Value;
    buMarbleCalc.ToolInMagazine[3].Positions.Position.Z = this.spn_ToolchangeZ3.Value;
    buMarbleCalc.ToolInMagazine[4].Positions.Position.X = this.spn_ToolchangeX4.Value;
    buMarbleCalc.ToolInMagazine[4].Positions.Position.Y = this.spn_ToolchangeY4.Value;
    buMarbleCalc.ToolInMagazine[4].Positions.Position.Z = this.spn_ToolchangeZ4.Value;
    buMarbleCalc.ToolInMagazine[5].Positions.Position.X = this.spn_ToolchangeX5.Value;
    buMarbleCalc.ToolInMagazine[5].Positions.Position.Y = this.spn_ToolchangeY5.Value;
    buMarbleCalc.ToolInMagazine[5].Positions.Position.Z = this.spn_ToolchangeZ5.Value;
    buMarbleCalc.ToolInMagazine[6].Positions.Position.X = this.spn_ToolchangeX6.Value;
    buMarbleCalc.ToolInMagazine[6].Positions.Position.Y = this.spn_ToolchangeY6.Value;
    buMarbleCalc.ToolInMagazine[6].Positions.Position.Z = this.spn_ToolchangeZ6.Value;
    buMarbleCalc.ToolInMagazine[7].Positions.Position.X = this.spn_ToolchangeX7.Value;
    buMarbleCalc.ToolInMagazine[7].Positions.Position.Y = this.spn_ToolchangeY7.Value;
    buMarbleCalc.ToolInMagazine[7].Positions.Position.Z = this.spn_ToolchangeZ7.Value;
    buMarbleCalc.ToolInMagazine[8].Positions.Position.X = this.spn_ToolchangeX8.Value;
    buMarbleCalc.ToolInMagazine[8].Positions.Position.Y = this.spn_ToolchangeY8.Value;
    buMarbleCalc.ToolInMagazine[8].Positions.Position.Z = this.spn_ToolchangeZ8.Value;
    buMarbleCalc.ToolInMagazine[9].Positions.Position.X = this.spn_ToolchangeX9.Value;
    buMarbleCalc.ToolInMagazine[9].Positions.Position.Y = this.spn_ToolchangeY9.Value;
    buMarbleCalc.ToolInMagazine[9].Positions.Position.Z = this.spn_ToolchangeZ9.Value;
    buMarbleCalc.ToolInMagazine[10].Positions.Position.X = this.spn_ToolchangeX10.Value;
    buMarbleCalc.ToolInMagazine[10].Positions.Position.Y = this.spn_ToolchangeY10.Value;
    buMarbleCalc.ToolInMagazine[10].Positions.Position.Z = this.spn_ToolchangeZ10.Value;
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
    clsAppMarbleVars.varApp.SawMeasureTimeOutSec = this.spn_SawMeasureTimeOutSec.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionX = this.spn_MillingLenMeasurePositionX.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionY = this.spn_MillingLenMeasurePositionY.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionFastZ = this.spn_MillingLenMeasurePositionFastZ.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionLimitZ = this.spn_MillingLenMeasurePositionLimitZ.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionA = this.spn_MillingLenMeasurePositionA.Value;
    clsAppMarbleVars.varApp.MillingLenMeasurePositionC = this.spn_MillingLenMeasurePositionC.Value;
    clsAppMarbleVars.varApp.MillingLenMeasureConstant = this.spn_MillingLenMeasureConstant.Value;
    clsAppMarbleVars.varApp.MillingMeasureTimeOutSec = this.spn_MillingMeasureTimeOutSec.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionX = this.spn_MillingHeadLenMeasurePositionX.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionY = this.spn_MillingHeadLenMeasurePositionY.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionFastZ = this.spn_MillingHeadLenMeasurePositionFastZ.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionLimitZ = this.spn_MillingHeadLenMeasurePositionLimitZ.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionA = this.spn_MillingHeadLenMeasurePositionA.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasurePositionC = this.spn_MillingHeadLenMeasurePositionC.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasureConstant = this.spn_MillingHeadLenMeasureConstant.Value;
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
    clsAppMarbleVars.varApp.MaterialMeasureG54OffsetX = this.spn_MaterialMeasureG54OffsetX.Value;
    clsAppMarbleVars.varApp.MaterialMeasureG54OffsetY = this.spn_MaterialMeasureG54OffsetY.Value;
    clsAppMarbleVars.varApp.MaterialMeasureMaxSawDiameter = this.spn_MaterialMeasureMaxSawDiameter.Value;
    clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset = this.spn_MaterialMeasureXBorderOffset.Value;
    clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset = this.spn_MaterialMeasureYBorderOffset.Value;
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
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition = this.spn_generalparkx.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition = this.spn_generalparky.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition = this.spn_generalparkz.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition = this.spn_generalparka.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition = this.spn_generalparkc.Value;
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
    clsAppMarbleVars.varApp.ParkPositionAfterFinishType = !this.\u0002.Checked ? (!this.\u0003.Checked ? (MarbleParkModeAfterJob) 2 : MarbleParkModeAfterJob.Saw) : (MarbleParkModeAfterJob) 1;
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
    clsAppMarbleVars.varApp.SawDiaMeasureMinDaimeter = this.spn_SawDiaMeasureMinDaimeter.Value;
    clsAppMarbleVars.varApp.SawDiaMeasureMaxDaimeter = this.spn_SawDiaMeasureMaxDaimeter.Value;
    clsAppMarbleVars.varApp.MillingLenMeasureMinLength = this.spn_MillingLenMeasureMinLength.Value;
    clsAppMarbleVars.varApp.MillingLenMeasureMaxLength = this.spn_MillingLenMeasureMaxLength.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasureMinLength = this.spn_MillingHeadLenMeasureMinLength.Value;
    clsAppMarbleVars.varApp.MillingHeadLenMeasureMaxLength = this.spn_MillingHeadLenMeasureMaxLength.Value;
    clsAppMarbleVars.varApp.VacuumMaxSawDiameter = ((F_MarbleMachineSettingsV1) this).spn_VacuumMaxSawDiameter.Value;
    clsAppMarbleVars.varApp.MaxSpindleToolLengthForA45 = ((F_MarbleMachineSettingsV1) this).spn_MaxSpindleToolLengthForA45.Value;
    if (clsAppMarbleVars.varRuntime.AxX >= 0 & clsAppMarbleVars.varRuntime.AxX <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setUnit = this.spn_calibx_unit.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setPulse = this.spn_calibx_pulse.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setGearRatio = this.spn_calibx_gear.Value;
    }
    if (clsAppMarbleVars.varRuntime.AxY >= 0 & clsAppMarbleVars.varRuntime.AxY <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit = this.spn_caliby_unit.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setPulse = this.spn_caliby_pulse.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setGearRatio = this.spn_caliby_gear.Value;
      if (clsAppMarbleVars.varRuntime.AxY2 >= 0 & clsAppMarbleVars.varRuntime.AxY2 <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
        clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit = !(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit > 0.0 & clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit > 0.0) ? (!(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit < 0.0 & clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY2].AxisPar.Sets.setUnit < 0.0) ? -clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit : clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit) : clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setUnit;
    }
    if (clsAppMarbleVars.varRuntime.AxZ >= 0 & clsAppMarbleVars.varRuntime.AxZ <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setUnit = this.spn_calibz_unit.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setPulse = this.spn_calibz_pulse.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setGearRatio = this.spn_calibz_gear.Value;
    }
    if (clsAppMarbleVars.varRuntime.AxA >= 0 & clsAppMarbleVars.varRuntime.AxA <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = this.spn_caliba_unit.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = this.spn_caliba_pulse.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = this.spn_caliba_gear.Value;
    }
    if (clsAppMarbleVars.varRuntime.AxC >= 0 & clsAppMarbleVars.varRuntime.AxC <= clsAppMarbleVars.cMachine.AppAxis.Count - 1)
    {
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setUnit = this.spn_calibc_unit.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setPulse = this.spn_calibc_pulse.Value;
      clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setGearRatio = this.spn_calibc_gear.Value;
    }
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogVelocity = this.spn_speedJogXSpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogAcc = this.spn_speedJogXAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogDec = this.spn_speedJogXAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogJerk = this.spn_speedJogXjerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedPersentage = this.spn_speedJogX2SpeedPerc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogFirstSpeedTimeSec = this.spn_speedJogX2SpeedTime.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveVelocity = this.spn_speedMoveXSpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveAcc = this.spn_speedMoveXAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveDec = this.spn_speedMoveXAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Moves.moveJerk = this.spn_speedMoveXJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogVelocity = this.spn_speedJogYSpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogAcc = this.spn_speedJogYAccDEc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogDec = this.spn_speedJogYAccDEc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogJerk = this.spn_speedJogYJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedPersentage = this.spn_speedJogY2SpeedPerc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogFirstSpeedTimeSec = this.spn_speedJogY2SpeedTime.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveVelocity = this.spn_speedMoveYSpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveAcc = this.spn_speedMoveYAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveDec = this.spn_speedMoveYAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Moves.moveJerk = this.spn_speedMoveYJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogVelocity = this.spn_speedJogZSpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogAcc = this.spn_speedJogZAccDEc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogDec = this.spn_speedJogZAccDEc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogJerk = this.spn_speedJogZJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedPersentage = this.spn_speedJogZ2SpeedPerc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogFirstSpeedTimeSec = this.spn_speedJogZ2SpeedTime.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveVelocity = this.spn_speedMoveZSpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveAcc = this.spn_speedMoveZAccDEc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveDec = this.spn_speedMoveZAccDEc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Moves.moveJerk = this.spn_speedMoveZJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setUnit = this.spn_caliba_unit.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setPulse = this.spn_caliba_pulse.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setGearRatio = this.spn_caliba_gear.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogVelocity = this.spn_speedJogASpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogAcc = this.spn_speedJogAAccDEc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogDec = this.spn_speedJogAAccDEc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogJerk = this.spn_speedJogAJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedPersentage = this.spn_speedJogA2SpeedPerc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogFirstSpeedTimeSec = this.spn_speedJogA2SpeedTime.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveVelocity = this.spn_speedMoveASpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveAcc = this.spn_speedMoveAAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveDec = this.spn_speedMoveAAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Moves.moveJerk = this.spn_speedMoveAJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogVelocity = this.spn_speedJogCSpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogAcc = this.spn_speedJogCAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogDec = this.spn_speedJogCAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogJerk = this.spn_speedJogCJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedPersentage = this.spn_speedJogC2SpeedPerc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogFirstSpeedTimeSec = this.spn_speedJogC2SpeedTime.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveVelocity = this.spn_speedMoveCSpeed.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveAcc = this.spn_speedMoveCAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveDec = this.spn_speedMoveCAccDec.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Moves.moveJerk = this.spn_speedMoveCJerk.Value;
    clsAppMarbleVars.cMachine.varCNC.setG0Acc = this.spn_cncG0AccDec.Value;
    clsAppMarbleVars.cMachine.varCNC.setG0Dec = this.spn_cncG0AccDec.Value;
    clsAppMarbleVars.cMachine.varCNC.setG1Acc = this.spn_cncG1AccDec.Value;
    clsAppMarbleVars.cMachine.varCNC.setG1Dec = this.spn_cncG1AccDec.Value;
    clsAppMarbleVars.cMachine.varCNC.setMaxJerk = this.spn_cncJerk.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitPositive = this.spn_softlimitposx.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitNegative = this.spn_softlimitnegx.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitPositive = this.spn_datalimitposx.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setDataLimitNegative = this.spn_datalimitnegx.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitx.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitx.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimitx.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitPositive = this.spn_softlimitposy.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitNegative = this.spn_softlimitnegy.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitPositive = this.spn_datalimitposy.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setDataLimitNegative = this.spn_datalimitnegy.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimity.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimity.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimity.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitPositive = this.spn_softlimitposz.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitNegative = this.spn_softlimitnegz.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitPositive = this.spn_datalimitposz.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setDataLimitNegative = this.spn_datalimitnegz.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitz.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitz.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimitz.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitPositive = this.spn_softlimitposa.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitNegative = this.spn_softlimitnega.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitPositive = this.spn_datalimitposa.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setDataLimitNegative = this.spn_datalimitnega.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimita.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimita.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimita.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitPositive = this.spn_softlimitposc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitNegative = this.spn_softlimitnegc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitPositive = this.spn_datalimitposc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setDataLimitNegative = this.spn_datalimitnegc.Value;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setSoftLimitEnable = this.chk_softlimitc.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Jogs.jogWithAbsoluteMove = this.chk_joglimitc.Check;
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setHardLimitEnable = this.chk_hardlimitc.Check;
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.buGround1.Controls);
    this.buTab_Main.SelectedIndex = PageIndex;
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
      this.btn_camera.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_camera.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 6)
    {
      this.btn_vacuum.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_vacuum.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 7)
    {
      this.btn_materialmeasure.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_materialmeasure.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 8)
    {
      this.btn_warmup.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_warmup.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 9)
    {
      this.btn_lubrication.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_lubrication.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 10)
    {
      this.btn_positions.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_positions.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 11)
    {
      this.btn_misc.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_misc.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 12)
    {
      this.btn_calibration.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_calibration.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 13)
    {
      this.btn_kinematic.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_kinematic.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 14)
    {
      this.btn_IO1.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_IO1.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 15)
    {
      this.btn_IO2.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_IO2.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 16 /*0x10*/)
    {
      this.btn_absoluteset.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_absoluteset.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 17)
      return;
    this.btn_safeparameters.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_safeparameters.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  public void MenuButtonColorsToolMeasure(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.\u0004.Controls);
    this.buTab_toolmeasure.SelectedIndex = PageIndex;
    if (PageIndex == 0)
    {
      this.btn_toolmeasuresaw.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_toolmeasuresaw.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_toolmeasuremilling.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_toolmeasuremilling.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 2)
      return;
    this.btn_toolmeasuremillinghead.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_toolmeasuremillinghead.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  public void MenuButtonColorsToolChange(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.\u0002.Controls);
    if (PageIndex == 0)
    {
      this.btn_toolchangedata.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_toolchangedata.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_toolchangetimes.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_toolchangetimes.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 2)
      return;
    this.btn_toolchangepositions.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_toolchangepositions.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }

  public void MenuButtonColorsCalibration(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.\u0011.Controls);
    this.\u0001.SelectedIndex = PageIndex;
    if (PageIndex == 0)
    {
      this.btn_xaxis.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_xaxis.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_yaxis.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_yaxis.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      this.btn_zaxis.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_zaxis.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 3)
    {
      this.btn_caxis.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_caxis.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 4)
    {
      this.btn_aaxis.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      this.btn_aaxis.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 5)
      return;
    this.btn_cnc.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    this.btn_cnc.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }
}
