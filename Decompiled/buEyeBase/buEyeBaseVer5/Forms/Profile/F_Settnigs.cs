using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_Settnigs : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public ProfileSettings varSettings = new ProfileSettings();

	internal List<cParameter5> list_0 = new List<cParameter5>();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	internal TabPage tabPage_5;

	internal Label label_0;

	public NumericUpDown spn_MaterialTranspancy;

	public NumericUpDown spn_EachLayerSafeDistance;

	public NumericUpDown spn_AutoPeckingUpDefaultDistance;

	public NumericUpDown spn_EachLayerAreaDevideCount;

	public NumericUpDown spn_EachLayerMaxThickness;

	public NumericUpDown spn_EachLayerMinThickness;

	internal Label label_1;

	public NumericUpDown spn_ProfileMaxClamper;

	internal Label label_2;

	public NumericUpDown numericUpDown2;

	internal Label label_3;

	public NumericUpDown spn_CutQuality;

	internal Label label_4;

	public NumericUpDown spn_MinXMove;

	internal Label label_5;

	internal Label label_6;

	public Label lbl_EachLayerSafeDistance;

	public Label lbl_AutoPeckingUpDefaultDistance;

	public Label lbl_AutoPeckingAddDefault;

	public Label lbl_EachLayerConnectGap;

	public Label lbl_EachLayerAreaDevideCount;

	public Label lbl_EachLayerMaxThickness;

	public Label lbl_EachLayerMinThickness;

	public CheckBox chk_EachLayerFromArea;

	public Button btn_SupportBlockZColor;

	public Button btn_ProfileColor;

	public CheckBox chk_FindToolAuto;

	public Label lbl_FindToolAuto;

	public CheckBox chk_FindToolAutoFromDepth;

	public Label lbl_FindToolAutoFromDepth;

	internal Label label_7;

	public NumericUpDown spn_MaxAMove;

	internal Label label_8;

	public NumericUpDown spn_MaxZMove;

	internal Label label_9;

	public NumericUpDown spn_MaxYMove;

	internal Label label_10;

	public NumericUpDown spn_MaxXMove;

	internal Label label_11;

	public NumericUpDown spn_MinAMove;

	internal Label label_12;

	public NumericUpDown spn_MinZMove;

	internal Label label_13;

	public NumericUpDown spn_MinYMove;

	internal TabPage tabPage_6;

	public CheckBox chk_ShowToolChangeInSimulation;

	public Label lbl_ShowToolChangeInSimulation;

	public Label lbl_ToolChangeX;

	public NumericUpDown spn_ToolChangeX;

	public Label lbl_ToolChangeA;

	public NumericUpDown spn_ToolChangeA;

	public Label lbl_ToolChangeZ;

	public NumericUpDown spn_ToolChangeZ;

	public Label lbl_ToolChangeY;

	public NumericUpDown spn_ToolChangeY;

	internal Label label_14;

	public NumericUpDown spn_NotchToolNo;

	internal Label label_15;

	public NumericUpDown spn_ToolPensDiameter;

	internal Label label_16;

	public NumericUpDown spn_ToolHolderLength;

	internal Label label_17;

	public NumericUpDown spn_MachineLength;

	internal Label label_18;

	internal Label label_19;

	public NumericUpDown spn_ProfileSizeExceedDepthLimit;

	internal Label label_20;

	internal Label label_21;

	internal Label label_22;

	public NumericUpDown spn_MinProfileFilterLength;

	internal Label label_23;

	public NumericUpDown spn_ProfileSortResolution;

	internal Label label_24;

	public NumericUpDown spn_GapConnectionForProfile;

	internal Label label_25;

	internal Label label_26;

	internal Label label_27;

	internal Label label_28;

	public NumericUpDown spn_FirstPositionOffset;

	internal Label label_29;

	public NumericUpDown spn_ParkPositionZ;

	internal Label label_30;

	public NumericUpDown spn_ParkPositionY;

	internal Label label_31;

	public NumericUpDown spn_ParkPositionX;

	internal Label label_32;

	internal Label label_33;

	internal Label label_34;

	internal Label label_35;

	internal Label label_36;

	internal Label label_37;

	internal Label label_38;

	internal Label label_39;

	internal Label label_40;

	public NumericUpDown spn_SimilasyonClamperOpenDistance;

	internal Label label_41;

	internal Label label_42;

	public NumericUpDown spn_SimYAxisDirection;

	internal Label label_43;

	public NumericUpDown spn_SimAAxisDirection;

	internal Label label_44;

	public NumericUpDown spn_CollisionControlMinStep;

	internal Label label_45;

	public CheckBox chk_ConnectSmallGap;

	public Label lbl_ConnectSmallGap;

	public ComboBox cmb_IntersectionRules;

	internal TabPage tabPage_7;

	internal Label label_46;

	public NumericUpDown spn_TopOperationClamperMoveZValue;

	internal Label label_47;

	internal Label label_48;

	internal Label label_49;

	internal Label label_50;

	public CheckBox chk_ManuelClamperSet;

	public CheckBox chk_CalculateClamperEveryTime;

	public CheckBox chk_NoClampedOutput;

	public CheckBox chk_GoFirstPosition;

	internal TabPage tabPage_8;

	public CheckBox chk_AutoOpenLastLoadedProfileAndOperations;

	public CheckBox chk_AutoOpenLastLoadedProfile;

	internal Label label_51;

	internal Label label_52;

	internal Label label_53;

	public NumericUpDown spn_AutoSaveMaxCount;

	internal Label label_54;

	public NumericUpDown spn_AutoSaveTimeSec;

	internal Label label_55;

	internal Label label_56;

	internal Label label_57;

	internal Label label_58;

	public CheckBox chk_SaveCurrentProfilesWhileProgramClosing;

	public CheckBox chkAutoCloseWater;

	public CheckBox chk_ToolDistanceDataToOperationDistanceData;

	public CheckBox chk_ToolSpeedDataToOperationSpeedData;

	public CheckBox chk_DontAddLineFromExternalFile;

	public CheckBox chk_ClamperCanMoveInsideProfileLength;

	public CheckBox chk_MultipleEdit;

	internal Label label_59;

	internal Label label_60;

	public CheckBox chk_OperationFrontBackMirrorYDirToAnotherPlane;

	internal Label label_61;

	internal Label label_62;

	public CheckBox chk_RightProfileMakeAsMirror;

	internal Label label_63;

	internal Label label_64;

	internal TabPage tabPage_9;

	internal Label label_65;

	internal Label label_66;

	internal Label label_67;

	internal Label label_68;

	internal Label label_69;

	internal Label label_70;

	internal Label label_71;

	internal Label label_72;

	internal Label label_73;

	internal Label label_74;

	internal Label label_75;

	internal Label label_76;

	internal Label label_77;

	internal Label label_78;

	internal Label label_79;

	internal Label label_80;

	internal Label label_81;

	internal Label label_82;

	public ComboBox cmb_ProfileOutsizeClamperMode;

	public ComboBox cmb_ProfileSafeDistanceForPlanes;

	public ComboBox cmb_ProfilePositionCalculation;

	internal Label label_83;

	internal Label label_84;

	internal Label label_85;

	internal Label label_86;

	internal Label label_87;

	internal Label label_88;

	internal Label label_89;

	internal Label label_90;

	internal Label label_91;

	public Label lbl_OperationWindowClose;

	public NumericUpDown spn_RegenDeviation;

	public Label lbl_OperationWindow;

	public ComboBox cmb_OperationWindow;

	public ComboBox cmb_OperationWindowClose;

	public ComboBox cmb_GoFirstPositionMode;

	public ComboBox spn_FindToolType;

	public ComboBox cmb_YDirection;

	public ComboBox cmb_XDirection;

	public ComboBox cmb_XDirRefType;

	public CheckBox chk_ShowCabinet;

	internal Label label_92;

	internal Label label_93;

	internal Label label_94;

	internal Label label_95;

	internal Label label_96;

	public ComboBox cmb_PreviewViewType;

	public CheckBox chk_ShowOperationButton;

	public CheckBox chk_ShowPreviewSides;

	public Button btn_GhostClamperColor;

	public Button btn_PreviewActiveOperationColor;

	public Button btn_PreviewDoneOperationColor;

	public Button btn_PreviewSideColor;

	public NumericUpDown spn_ProfileMaxWidth;

	public NumericUpDown spn_ProfileMaxLength;

	public NumericUpDown spn_GhostClamperTransparency;

	public NumericUpDown spn_MillingToolMaxSpeed;

	public NumericUpDown spn_NotchMaxSpeed;

	public NumericUpDown spn_NotchMinSpeed;

	public NumericUpDown spn_ProfileMaxHeight;

	public NumericUpDown spn_PlaneMoveSafeDistance;

	public CheckBox chk_ProfileAddWidthHeightReadOnly;

	internal Label label_97;

	internal Label label_98;

	internal Label label_99;

	public CheckBox chk_ChangeAAxisWhileMoveBetweenPlanes;

	public CheckBox chk_AutoPeckingAddDefault;

	public CheckBox chk_AllGCodeAsG1;

	public CheckBox chk_UseUndoBuffer;

	public CheckBox chk_ShowProfileAngleDrawing;

	internal Label label_100;

	public CheckBox chk_RemoveProfileAngle;

	public CheckBox chk_JobOpenClearAllProfiles;

	public CheckBox chk_UseAlwaysInsideContourForCam;

	internal Label label_101;

	internal Label label_102;

	internal Label label_103;

	internal Label label_104;

	internal Label label_105;

	public CheckBox chk_UseAlwaysPocketForCam;

	internal TabPage tabPage_10;

	public CheckBox chk_ShowProfileInfoAtGCode;

	public CheckBox chk_ShowOperationInfoAtGCode;

	public CheckBox chk_ShowSupportBlockInfoAtGCode;

	internal Label label_106;

	internal Label label_107;

	internal Label label_108;

	public CheckBox chk_ChangeCwCCWDirForRightRefProfile;

	public CheckBox chk_ChangeG2G3DirForLeftRefProfile;

	public CheckBox chk_ChangeG2G3DirForRightRefProfile;

	public CheckBox chk_RightProfileActive;

	internal TabPage tabPage_11;

	public CheckBox chk_NotchHorizontalUseMilling;

	public CheckBox chk_NotchOperationAlwaysFirst;

	internal Label label_109;

	internal Label label_110;

	public CheckBox chk_OperationEditChangeWithoutOk;

	public CheckBox chk_InsertOperationIfSamePositionAndSmallSize;

	public CheckBox chk_ShowBackReferanceEntity;

	public CheckBox chk_ShowBottomReferanceEntity;

	public CheckBox chk_LeftToRightCopyChangeCamDirection;

	public CheckBox chk_LeftToRightCopyRotateKeyHole;

	public CheckBox chk_NotchAlwaysSafeZ;

	internal Label label_111;

	internal Label label_112;

	internal Label label_113;

	internal Label label_114;

	internal Label label_115;

	internal Label label_116;

	internal Label label_117;

	internal Label label_118;

	internal Label label_119;

	internal Label label_120;

	internal Label label_121;

	internal Label label_122;

	internal Label label_123;

	public ComboBox cmb_SortType;

	internal Label label_124;

	internal Label label_125;

	internal Label label_126;

	public CheckBox chk_ParabolicMoveBetweenPlanes;

	public ComboBox cmb_ParabolicAllowedAxes;

	public NumericUpDown spn_ParabolicMoveFeed;

	public NumericUpDown spn_ParabolicSafeDistance;

	public CheckBox chk_AutoSaveWithTimeFileName;

	public CheckBox chk_AutoSave;

	public CheckBox chk_UseDrillToolForDrill;

	public CheckBox chk_SimAddZAxisKinematicAndToolLength;

	public NumericUpDown spn_ProfilePreviewRefDrawingExtraHeight;

	public NumericUpDown spn_ProfilePreviewRefDrawingThickness;

	internal Label label_127;

	internal Label label_128;

	public NumericUpDown spn_ProfileEndAllowedPositiveDistance;

	public NumericUpDown spn_ProfileStartAllowedNegativeDistance;

	internal Label label_129;

	internal Label label_130;

	public NumericUpDown spn_ProfileDrawingRefThickness;

	internal Label label_131;

	public CheckBox chk_SimulationCanStartFromRightProfile;

	public CheckBox chk_SaveImageFileWhileCreatingCode;

	public CheckBox chk_SaveStlFileWhileCreatingCode;

	public NumericUpDown spn_ImageScaleFactor;

	internal Label label_132;

	public NumericUpDown spn_SimulasyonGCodeWindowHeight;

	internal Label label_133;

	public NumericUpDown spn_SimulasyonGCodeWindowWidth;

	public NumericUpDown spn_MinSpindleSpeed;

	public NumericUpDown spn_PlaneThickness;

	public TextBox txt_LongBottomProfileMCode;

	public TextBox txt_BottomProfileMCode;

	public TextBox txt_LongProfileMCode;

	internal Label label_134;

	internal Label label_135;

	public TextBox txt_ClamperChar;

	public TextBox txt_PriorityChar;

	public Label lbl_EachLayerFromArea;

	public NumericUpDown spn_EachLayerConnectGap;

	public NumericUpDown spn_PlaneToPlaneSafeDisance;

	internal Label label_136;

	public CheckBox chk_NotchVerticalSafeAtXAxis;

	public CheckBox chk_NotchSideSafeAtXAxis;

	public CheckBox chk_G91Mode;

	internal Label label_137;

	public CheckBox chk_NotchVerticalForbiddenAtSide;

	internal TabPage tabPage_12;

	public CheckBox chk_alarmIfToolDiaDifferentThenHoleDia;

	internal Label label_138;

	public F_Settnigs()
	{
		Class186.smethod_27(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		Class186.smethod_636(this);
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 1)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class186.smethod_1(this);
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
