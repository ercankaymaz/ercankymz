// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.clsItem
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

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
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5;

public class clsItem
{
  public static Form FrmMain = (Form) null;
  public static Form FrmIntro = (Form) null;
  public static F_ToolPanel FrmTempTools = (F_ToolPanel) null;
  public static F_PagesPanel FrmTempPages = (F_PagesPanel) null;
  public static F_LayerPanel FrmTempLayers = (F_LayerPanel) null;
  public static F_CamPanel FrmTempCams = (F_CamPanel) null;
  public static F_MaterialPanel FrmTempMaterial = (F_MaterialPanel) null;
  public static F_MiscPanel FrmTempMisc = (F_MiscPanel) null;
  public static F_Tool FrmTool = (F_Tool) null;
  public static F_SettingsMenu FrmSettingsMenu = (F_SettingsMenu) null;
  public static F_DrillJob FrmDrillJob = (F_DrillJob) null;
  public static F_ProfileJob FrmProfileJob = (F_ProfileJob) null;
  public static F_ProfilePlanes FrmProfilePlanes = (F_ProfilePlanes) null;
  public static F_ProfileDepths FrmProfileDepths = (F_ProfileDepths) null;
  public static F_FoamJob FrmFoamJob = (F_FoamJob) null;
  public static F_PipeBendJob FrmPipeBendJob = (F_PipeBendJob) null;
  public static F_PanelCutJob FrmPanelCutJob = (F_PanelCutJob) null;
  public static F_ToolListDetail FrmToolList = (F_ToolListDetail) null;
  public static F_Printer3DJob FrmPrinter3DJob = (F_Printer3DJob) null;
  public static F_WoodJob FrmWoodJob = (F_WoodJob) null;
  public static F_DoorJob FrmDoorJob = (F_DoorJob) null;
  public static F_Router3AXJob FrmRouter3AXJob = (F_Router3AXJob) null;
  public static F_CutterJob FrmCutterJob = (F_CutterJob) null;
  public static F_MarbleJob FrmMarbleJob = (F_MarbleJob) null;
  public static F_RollerBendJob FrmRollerBendJob = (F_RollerBendJob) null;
  public static F_ToolGrinding FrmToolGrindingJob = (F_ToolGrinding) null;
  public static F_AnalyseResult FrmDrawingAnalayseResult = (F_AnalyseResult) null;
  public static System.Windows.Forms.Control tabcontrolLeft = (System.Windows.Forms.Control) null;
  public static System.Windows.Forms.Control tabcontrolRight = (System.Windows.Forms.Control) null;
  public static Design ModelOpenPreview = new Design();
  public static Design ModelOpenInsert = new Design();
  public static Design ModelToolPreview = new Design();
  public static Design ModelMainPreview = (Design) null;
  public static Panel pnlSettings = (Panel) null;
  public static F_Editor frmEditor = (F_Editor) null;
  public static F_EditorV2 frmEditorV2 = (F_EditorV2) null;
  public static F_SettingsTreeView FrmSettings = new F_SettingsTreeView();
  public static F_Measure FrmMeasure = new F_Measure();
  public static F_ProgressCalculation FrmProgress = new F_ProgressCalculation();
  public static FWin_Debug FrmDebug = new FWin_Debug();
  public static F_Cf2PropertiesList FrmCf2Properties = new F_Cf2PropertiesList();
  public static F_DxfPropertiesList FrmDxfProperties = new F_DxfPropertiesList();
  public static F_Preview FrmPreview = (F_Preview) null;
  public static F_PreviewMulti FrmPreviewMulti = (F_PreviewMulti) null;
  public static F_DataClass FrmActionData = new F_DataClass();
  public static F_NestSheetPartList FrmNestSheetPart = (F_NestSheetPartList) null;
  public static F_NestExecute FrmNestExecute = (F_NestExecute) null;
  public static F_NestSheetAdd FrmNestSheetAdd = (F_NestSheetAdd) null;
  public static F_NestSheetShapeAdd FrmNestSheetShapeAdd = (F_NestSheetShapeAdd) null;
  public static F_NestRectPartAdd FrmNestRectPartAdd = (F_NestRectPartAdd) null;
  public static F_NestPartAdd FrmNestPartAdd = (F_NestPartAdd) null;
  public static F_NestPartAddV2 FrmNestPartAddV2 = (F_NestPartAddV2) null;
  public static F_NestOnlineCalc FrmNestOnlineCalc = (F_NestOnlineCalc) null;
  public static F_NestedResults FrmNestedResult = (F_NestedResults) null;
  public static F_NestOldResult FrmOldNestedResult = (F_NestOldResult) null;
  public static F_ParametricLibrary FrmLibraryDraw = (F_ParametricLibrary) null;
  public static F_Material FrmMaterial = (F_Material) null;
  public static F_Material3D FrmMaterial3D = (F_Material3D) null;
  public static F_ShapeList FrmShapeList = (F_ShapeList) null;
  public static F_DrillList FrmDrillList = (F_DrillList) null;
  public static F_CutList FrmSlotList = (F_CutList) null;
  public static F_ProfilingList FrmProfilingList = (F_ProfilingList) null;
  public static F_EngraveList FrmEngraveList = (F_EngraveList) null;
  public static F_JunctionList FrmJunctionList = (F_JunctionList) null;
  public static F_HoleMenu FrmHoleMenu = (F_HoleMenu) null;
  public static F_CutMenu FrmCutMenu = (F_CutMenu) null;
  public static F_DrawingMenu FrmDrawingMenu = (F_DrawingMenu) null;
  public static F_ProfilingMenu FrmProfilingMenu = (F_ProfilingMenu) null;
  public static F_Holes3D FrmHole3D = (F_Holes3D) null;
  public static F_AddFromFile FrmFromFile = (F_AddFromFile) null;
  public static F_AddImageFromFile FrmImageFromFile = (F_AddImageFromFile) null;
  public static Timer timInformation = new Timer();
  public static Timer timSim = new Timer();
  public static Timer timBackgroud = new Timer();
  public static Timer timTrack = new Timer();
  public static Timer timToolTip = new Timer();
  public static Timer timAutoPan = new Timer();
  public static Timer timOpenAfter = new Timer();
  public static Timer timRecord = new Timer();
}
