// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleControls
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buControls.Controls;
using buControls.Forms.buControlForms.AlarmWarning;
using buControls.Forms.buControlForms.Commands;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Settings;
using buEyeBaseVer5.Forms.Controls;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Password;
using buEyeBaseVer5.Forms.Watch;
using buMarble.Forms;
using System.Windows.Forms;

#nullable disable
namespace buMarble;

public class clsAppMarbleControls
{
  public static buSeparator spr_camerapos4;
  public static buLabel lblPart;
  public static buLabel lblPartX;
  public static buLabel lblPartY;
  public static buLabel lblPartZ;
  public static buLabel lblPartA;
  public static buLabel lblPartC;
  public static buLabel lblMachine;
  public static buLabel lblMachineX;
  public static buLabel lblMachineY;
  public static buLabel lblMachineZ;
  public static buLabel lblMachineA;
  public static buLabel lblMachineC;
  public static buLabel lblStatus;
  public static buLabel lblWarning;
  public static buLabel lblSawSpeed;
  public static buLabel lblMillingSpeed;
  public static buLabel lblOperationSpeed;
  public static buLabel lblQuickSpeed;
  public static buLabel lblMillingDia;
  public static buLabel lblMillingLen;
  public static buLabel lblMillingHeadDia;
  public static buLabel lblMillingHeadLen;
  public static buLabel lblSawDia;
  public static buLabel lblSawThickness;
  public static buButton btnInformation;
  public static buButton btnHoming;
  public static buButton btnWater;
  public static buButton btnLaser;
  public static buButton btnStart;
  public static buButton btnPause;
  public static buButton btnSemiAuto;
  public static buButton btnCruise;
  public static buButton btnRTCP;
  public static buButton btnSawTool;
  public static buButton btnMillingTool;
  public static buButton btnSawSet;
  public static buButton btnMillingSet;
  public static buButton btnMillingHeadSet;
  public static buButton btnLight;
  public static buButton btnStop;
  public static buTrack trackOperation;
  public static buTrack trackQuick;
  public static buTrack trackSawSpeed;
  public static buTrack trackMillingSpeed;
  public static buCheckBox chkConnected;
  public static buCheckBox chkInited;
  public static buCheckBox chkRTCP;
  public static buCheckBox chkRun;
  public static buCheckBox chkHome;
  public static buProgressBar progressCurrentX;
  public static buProgressBar progressCurrentY;
  public static buProgressBar progressCurrentZ;
  public static buProgressBar progressCurrentA;
  public static buProgressBar progressCurrentC;
  public static buProgressBar progressCurrentSaw;
  public static buProgressBar progressCurrentMilling;

  static clsAppMarbleControls()
  {
    clsAppMarbleItems.frmMain = (Form) null;
    clsAppMarbleItems.frmToolList = (F_MarbleToolList) null;
    clsAppMarbleItems.frmToolTabList = (F_MarbleToolListTab) null;
    clsAppMarbleItems.frmToolType = (F_MarbleToolTypes) null;
    clsAppMarbleItems.frmToolSawType = (F_MarbleToolSawTypes) null;
    clsAppMarbleItems.frmToolCurrent = (F_MarbleToolCurrentAll) null;
    clsAppMarbleItems.frmG54List = (F_MarbleG54List) null;
    clsAppMarbleItems.frmParkList = (F_MarbleParkList) null;
    clsAppMarbleItems.frmImageThicknessList = (F_MarbleImageThicknessList) null;
    clsAppMarbleItems.frmCameraCalibration = (F_MarblePhotoCalibration) null;
    clsAppMarbleItems.frmStartOption = (F_MarbleStartOptions) null;
    clsAppMarbleItems.frmInfoList = (F_MarbleInfoList) null;
    clsAppMarbleItems.frmJogPageV1 = (F_MarbleJogs) null;
    clsAppMarbleItems.frmMDIPageV1 = (F_MarbleMDIV1) null;
    clsAppMarbleItems.frmMDIPageV2 = (F_MarbleMDIV2) null;
    clsAppMarbleItems.frmUserPageV1 = (F_MarbleUserList) null;
    clsAppMarbleItems.frmTechnicianPageV1 = (F_MarbleTechnicianList) null;
    clsAppMarbleItems.frmGantryMoveV1 = (F_MarbleGantryMove) null;
    clsAppMarbleItems.frmBackupV1 = (F_MarbleBackupLoad) null;
    clsAppMarbleItems.frmIOConfig = (F_MarbleIOConfig) null;
    clsAppMarbleItems.frmPartZero = (F_MarblePartZero) null;
    clsAppMarbleItems.frmKinematic = new F_MarbleKinematic();
    clsAppMarbleItems.frmUISettings = (F_ControlUISettings) null;
    clsAppMarbleItems.frmTempCode = new F_MarbleTempCodes();
    clsAppMarbleItems.frmTempMovement = new F_MarbleTempMovements();
    clsAppMarbleItems.frmTempWaterjet = new F_MarbleTempWaterjet();
    clsAppMarbleItems.frmAxesMenu = new F_MarbleAxesSettings();
    clsAppMarbleItems.frmCoordsV1 = (F_MarbleCoordinatesV1) null;
    clsAppMarbleItems.frmCoordsV2 = (F_MarbleCoordinatesV2) null;
    clsAppMarbleItems.frmBottomPanelV1 = (F_MarbleBottomPanelV1) null;
    clsAppMarbleItems.frmSpeedsV1 = (F_MarbleSpeedsV1) null;
    clsAppMarbleItems.frmViewsV1 = (F_MarbleViewV1) null;
    clsAppMarbleItems.frmCommandsV1 = (F_MarbleCommandsV1) null;
    clsAppMarbleItems.frmDrawingV1 = (F_MarbleDrawV1) null;
    clsAppMarbleItems.frmGCodeViewV1 = (F_MarbleGCodeViewV1) null;
    clsAppMarbleItems.frmJobOPListV1 = (F_MarbleJobOPListV1) null;
    clsAppMarbleItems.frmJobOPListV2 = (F_MarbleJobOPListV2) null;
    clsAppMarbleItems.frmJobList = (F_MarbleJobList) null;
    clsAppMarbleItems.frmMove = (F_MarbleEventMove) null;
    clsAppMarbleItems.frmCopy = (F_MarbleEventCopy) null;
    clsAppMarbleItems.frmMirror = (F_MarbleEventMirror) null;
    clsAppMarbleItems.frmScale = (F_MarbleEventScale) null;
    clsAppMarbleItems.frmCopyMulti = (F_MarbleEventCopyMulti) null;
    clsAppMarbleItems.frmRotate = (F_MarbleEventRotate) null;
    clsAppMarbleItems.frmAbsoluteSet = (F_MarbleAbsoluteSet) null;
    clsAppMarbleItems.frmStartLine = (F_MarbleStartLine) null;
    clsAppMarbleItems.frmG54Set = (F_MarbleG54Set) null;
    clsAppMarbleItems.frmDigitalInput = (F_MarbleDigitalInput) null;
    clsAppMarbleItems.frmDigitalOutput = (F_MarbleDigitalOutput) null;
    clsAppMarbleItems.frmDigitalInputOutput = (F_MarbleDigitalInputOutput) null;
    clsAppMarbleItems.frmMaterialSize = (F_MarbleMaterialSize) null;
    clsAppMarbleItems.frmMachineCalibration = (F_MarbleMachineInstall) null;
    clsAppMarbleItems.frmMachineSettingsV1 = (F_MarbleMachineSettingsV1) null;
    clsAppMarbleItems.frmMachineSettingsV2 = (F_MarbleMachineSettingsV2) null;
    clsAppMarbleItems.frmWagonSettings = (F_MarbleWagonSettings) null;
    clsAppMarbleItems.frmCameraSettings = (F_MarbleCameraSettings) null;
    clsAppMarbleItems.frmMachineDefination = (F_MarbleMachineDef) null;
    clsAppMarbleItems.frmDebug = (F_DebugV2) null;
    clsAppMarbleItems.frmCalculator = (F_MarbleCalculators) null;
    clsAppMarbleItems.frmMaintanance = (F_MarbleMaintanance) null;
    clsAppMarbleItems.frmCounters = (F_MarbleCounters) null;
    clsAppMarbleItems.frmWarmUp = (F_MarbleMotorWarmUp) null;
    clsAppMarbleItems.frmMaterialMeasure = (F_MarbleMaterialMeasurement) null;
    clsAppMarbleItems.frmWatchVars = (F_WatchByGrid) null;
    clsAppMarbleItems.frmPassword = (F_PasswordV1) null;
    clsAppMarbleItems.frmNotepad = (F_Notepad) null;
    clsAppMarbleItems.frmSettings = (F_SettingsTreeView) null;
    clsAppMarbleItems.frmSettingsMisc = (F_SettingsTreeView) null;
    clsAppMarbleItems.FrmAlarm = (F_Alarm) null;
    clsAppMarbleItems.FrmWarning = (F_Warning) null;
    clsAppMarbleItems.timPlcHandlerRelease = new Timer();
    clsAppMarbleItems.timGeneral = (Timer) null;
    clsAppMarbleItems.spr_camerapos1 = (buSeparator) null;
    clsAppMarbleItems.spr_camerapos2 = (buSeparator) null;
    clsAppMarbleItems.spr_camerapos3 = (buSeparator) null;
    clsAppMarbleControls.spr_camerapos4 = (buSeparator) null;
  }
}
