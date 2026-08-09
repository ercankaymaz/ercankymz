using System.Windows.Forms;
using buControls.Controls;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Settings;
using buControls.Forms.buControlForms.AlarmWarning;
using buControls.Forms.buControlForms.Commands;
using buEyeBaseVer5.Forms.Controls;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Password;
using buEyeBaseVer5.Forms.Watch;
using buMarble.Forms;

namespace buMarble;

public class clsAppMarbleItems
{
	public static Form frmMain = null;

	public static F_MarbleToolList frmToolList = null;

	public static F_MarbleToolListTab frmToolTabList = null;

	public static F_MarbleToolTypes frmToolType = null;

	public static F_MarbleToolSawTypes frmToolSawType = null;

	public static F_MarbleToolCurrentAll frmToolCurrent = null;

	public static F_MarbleG54List frmG54List = null;

	public static F_MarbleParkList frmParkList = null;

	public static F_MarbleImageThicknessList frmImageThicknessList = null;

	public static F_MarblePhotoCalibration frmCameraCalibration = null;

	public static F_MarbleStartOptions frmStartOption = null;

	public static F_MarbleInfoList frmInfoList = null;

	public static F_MarbleJogs frmJogPageV1 = null;

	public static F_MarbleMDIV1 frmMDIPageV1 = null;

	public static F_MarbleMDIV2 frmMDIPageV2 = null;

	public static F_MarbleUserList frmUserPageV1 = null;

	public static F_MarbleTechnicianList frmTechnicianPageV1 = null;

	public static F_MarbleGantryMove frmGantryMoveV1 = null;

	public static F_MarbleBackupLoad frmBackupV1 = null;

	public static F_MarbleIOConfig frmIOConfig = null;

	public static F_MarblePartZero frmPartZero;

	public static F_MarbleKinematic frmKinematic;

	public static F_ControlUISettings frmUISettings;

	public static F_MarbleTempCodes frmTempCode;

	public static F_MarbleTempMovements frmTempMovement;

	public static F_MarbleTempWaterjet frmTempWaterjet;

	public static F_MarbleAxesSettings frmAxesMenu;

	public static F_MarbleCoordinatesV1 frmCoordsV1;

	public static F_MarbleCoordinatesV2 frmCoordsV2;

	public static F_MarbleBottomPanelV1 frmBottomPanelV1;

	public static F_MarbleSpeedsV1 frmSpeedsV1;

	public static F_MarbleViewV1 frmViewsV1;

	public static F_MarbleCommandsV1 frmCommandsV1;

	public static F_MarbleDrawV1 frmDrawingV1;

	public static F_MarbleGCodeViewV1 frmGCodeViewV1;

	public static F_MarbleJobOPListV1 frmJobOPListV1;

	public static F_MarbleJobOPListV2 frmJobOPListV2;

	public static F_MarbleJobList frmJobList;

	public static F_MarbleEventMove frmMove;

	public static F_MarbleEventCopy frmCopy;

	public static F_MarbleEventMirror frmMirror;

	public static F_MarbleEventScale frmScale;

	public static F_MarbleEventCopyMulti frmCopyMulti;

	public static F_MarbleEventRotate frmRotate;

	public static F_MarbleAbsoluteSet frmAbsoluteSet;

	public static F_MarbleStartLine frmStartLine;

	public static F_MarbleG54Set frmG54Set;

	public static F_MarbleDigitalInput frmDigitalInput;

	public static F_MarbleDigitalOutput frmDigitalOutput;

	public static F_MarbleDigitalInputOutput frmDigitalInputOutput;

	public static F_MarbleMaterialSize frmMaterialSize;

	public static F_MarbleMachineInstall frmMachineCalibration;

	public static F_MarbleMachineSettingsV1 frmMachineSettingsV1;

	public static F_MarbleMachineSettingsV2 frmMachineSettingsV2;

	public static F_MarbleWagonSettings frmWagonSettings;

	public static F_MarbleCameraSettings frmCameraSettings;

	public static F_MarbleMachineDef frmMachineDefination;

	public static F_DebugV2 frmDebug;

	public static F_MarbleCalculators frmCalculator;

	public static F_MarbleMaintanance frmMaintanance;

	public static F_MarbleCounters frmCounters;

	public static F_MarbleMotorWarmUp frmWarmUp;

	public static F_MarbleMaterialMeasurement frmMaterialMeasure;

	public static F_WatchByGrid frmWatchVars;

	public static F_PasswordV1 frmPassword;

	public static F_Notepad frmNotepad;

	public static F_SettingsTreeView frmSettings;

	public static F_SettingsTreeView frmSettingsMisc;

	public static F_Alarm FrmAlarm;

	public static F_Warning FrmWarning;

	public static Timer timPlcHandlerRelease;

	public static Timer timGeneral;

	public static buSeparator spr_camerapos1;

	public static buSeparator spr_camerapos2;

	public static buSeparator spr_camerapos3;

	public static buSeparator spr_camerapos4;

	static clsAppMarbleItems()
	{
		if (0 == 0)
		{
			frmPartZero = null;
			frmKinematic = new F_MarbleKinematic();
			frmUISettings = null;
			if (7 == 0)
			{
				goto IL_015e;
			}
			frmTempCode = new F_MarbleTempCodes();
			frmTempMovement = new F_MarbleTempMovements();
			frmTempWaterjet = new F_MarbleTempWaterjet();
			frmAxesMenu = new F_MarbleAxesSettings();
			frmCoordsV1 = null;
			frmCoordsV2 = null;
			if (false)
			{
				goto IL_01ac;
			}
			frmBottomPanelV1 = null;
			frmSpeedsV1 = null;
			frmViewsV1 = null;
			frmCommandsV1 = null;
			frmDrawingV1 = null;
			frmGCodeViewV1 = null;
		}
		frmJobOPListV1 = null;
		goto IL_00fb;
		IL_016a:
		frmWagonSettings = null;
		frmCameraSettings = null;
		frmMachineDefination = null;
		frmDebug = null;
		frmCalculator = null;
		frmMaintanance = null;
		frmCounters = null;
		goto IL_0194;
		IL_0194:
		frmWarmUp = null;
		goto IL_019a;
		IL_019a:
		frmMaterialMeasure = null;
		frmWatchVars = null;
		frmPassword = null;
		goto IL_01ac;
		IL_015e:
		frmMachineSettingsV1 = null;
		frmMachineSettingsV2 = null;
		goto IL_016a;
		IL_00fb:
		frmJobOPListV2 = null;
		frmJobList = null;
		frmMove = null;
		frmCopy = null;
		frmMirror = null;
		frmScale = null;
		frmCopyMulti = null;
		frmRotate = null;
		frmAbsoluteSet = null;
		frmStartLine = null;
		frmG54Set = null;
		frmDigitalInput = null;
		frmDigitalOutput = null;
		frmDigitalInputOutput = null;
		if (true)
		{
			frmMaterialSize = null;
			frmMachineCalibration = null;
			goto IL_015e;
		}
		goto IL_016a;
		IL_01ac:
		if (true)
		{
			frmNotepad = null;
			frmSettings = null;
			frmSettingsMisc = null;
			FrmAlarm = null;
			FrmWarning = null;
			if (0 == 0)
			{
				timPlcHandlerRelease = new Timer();
				if (0 == 0)
				{
					timGeneral = null;
					spr_camerapos1 = null;
					spr_camerapos2 = null;
					spr_camerapos3 = null;
					spr_camerapos4 = null;
					return;
				}
				goto IL_00fb;
			}
			goto IL_0194;
		}
		goto IL_019a;
	}
}
