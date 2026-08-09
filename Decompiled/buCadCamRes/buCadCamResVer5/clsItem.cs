using System.Windows.Forms;
using buCadCamResVer5.Drill;
using buCadCamResVer5.Editor;
using buCadCamResVer5.Forms;
using buCadCamResVer5.Library.Forms;
using buControls.Forms.WinControlForms.CAD;
using buControls.Forms.WinControlForms.Command;
using buControls.Forms.WinControlForms.File;
using buControls.Forms.WinControlForms.Progress;
using buControls.Forms.WinControlForms.Settings;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.Shape;
using devDept.Eyeshot.Control;

namespace buCadCamResVer5;

public class clsItem
{
	public static Form FrmMain = null;

	public static Form FrmIntro = null;

	public static F_ToolPanel FrmTempTools = null;

	public static F_PagesPanel FrmTempPages = null;

	public static F_LayerPanel FrmTempLayers = null;

	public static F_CamPanel FrmTempCams = null;

	public static F_MaterialPanel FrmTempMaterial = null;

	public static F_MiscPanel FrmTempMisc = null;

	public static F_Tool FrmTool = null;

	public static F_SettingsMenu FrmSettingsMenu = null;

	public static F_DrillJob FrmDrillJob = null;

	public static F_ProfileJob FrmProfileJob = null;

	public static F_ProfilePlanes FrmProfilePlanes = null;

	public static F_ProfileDepths FrmProfileDepths = null;

	public static F_FoamJob FrmFoamJob = null;

	public static F_PipeBendJob FrmPipeBendJob = null;

	public static F_PanelCutJob FrmPanelCutJob = null;

	public static F_ToolListDetail FrmToolList = null;

	public static F_Printer3DJob FrmPrinter3DJob = null;

	public static F_WoodJob FrmWoodJob = null;

	public static F_DoorJob FrmDoorJob = null;

	public static F_Router3AXJob FrmRouter3AXJob = null;

	public static F_CutterJob FrmCutterJob = null;

	public static F_MarbleJob FrmMarbleJob = null;

	public static F_RollerBendJob FrmRollerBendJob = null;

	public static F_ToolGrinding FrmToolGrindingJob = null;

	public static F_AnalyseResult FrmDrawingAnalayseResult = null;

	public static Control tabcontrolLeft = null;

	public static Control tabcontrolRight = null;

	public static Design ModelOpenPreview = new Design();

	public static Design ModelOpenInsert = new Design();

	public static Design ModelToolPreview = new Design();

	public static Design ModelMainPreview = null;

	public static Panel pnlSettings = null;

	public static F_Editor frmEditor = null;

	public static F_EditorV2 frmEditorV2 = null;

	public static F_SettingsTreeView FrmSettings = new F_SettingsTreeView();

	public static F_Measure FrmMeasure = new F_Measure();

	public static F_ProgressCalculation FrmProgress = new F_ProgressCalculation();

	public static FWin_Debug FrmDebug = new FWin_Debug();

	public static F_Cf2PropertiesList FrmCf2Properties = new F_Cf2PropertiesList();

	public static F_DxfPropertiesList FrmDxfProperties = new F_DxfPropertiesList();

	public static F_Preview FrmPreview = null;

	public static F_PreviewMulti FrmPreviewMulti = null;

	public static F_DataClass FrmActionData = new F_DataClass();

	public static F_NestSheetPartList FrmNestSheetPart = null;

	public static F_NestExecute FrmNestExecute = null;

	public static F_NestSheetAdd FrmNestSheetAdd = null;

	public static F_NestSheetShapeAdd FrmNestSheetShapeAdd = null;

	public static F_NestRectPartAdd FrmNestRectPartAdd = null;

	public static F_NestPartAdd FrmNestPartAdd = null;

	public static F_NestPartAddV2 FrmNestPartAddV2 = null;

	public static F_NestOnlineCalc FrmNestOnlineCalc = null;

	public static F_NestedResults FrmNestedResult = null;

	public static F_NestOldResult FrmOldNestedResult = null;

	public static F_ParametricLibrary FrmLibraryDraw = null;

	public static F_Material FrmMaterial = null;

	public static F_Material3D FrmMaterial3D = null;

	public static F_ShapeList FrmShapeList = null;

	public static F_DrillList FrmDrillList = null;

	public static F_CutList FrmSlotList = null;

	public static F_ProfilingList FrmProfilingList = null;

	public static F_EngraveList FrmEngraveList = null;

	public static F_JunctionList FrmJunctionList = null;

	public static F_HoleMenu FrmHoleMenu = null;

	public static F_CutMenu FrmCutMenu = null;

	public static F_DrawingMenu FrmDrawingMenu = null;

	public static F_ProfilingMenu FrmProfilingMenu = null;

	public static F_Holes3D FrmHole3D = null;

	public static F_AddFromFile FrmFromFile = null;

	public static F_AddImageFromFile FrmImageFromFile = null;

	public static Timer timInformation = new Timer();

	public static Timer timSim = new Timer();

	public static Timer timBackgroud = new Timer();

	public static Timer timTrack = new Timer();

	public static Timer timToolTip = new Timer();

	public static Timer timAutoPan = new Timer();

	public static Timer timOpenAfter = new Timer();

	public static Timer timRecord = new Timer();
}
