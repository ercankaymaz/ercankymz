// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.clsInit
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Cutter;
using buCadCamResVer5.Diemaker;
using buCadCamResVer5.Door;
using buCadCamResVer5.Drill;
using buCadCamResVer5.Editor;
using buCadCamResVer5.Flexo;
using buCadCamResVer5.FoamCutting;
using buCadCamResVer5.Jewel;
using buCadCamResVer5.LaserRouter;
using buCadCamResVer5.Library;
using buCadCamResVer5.Marble;
using buCadCamResVer5.Nesting;
using buCadCamResVer5.PanelCut;
using buCadCamResVer5.PipeBending;
using buCadCamResVer5.Printer3D;
using buCadCamResVer5.Profile;
using buCadCamResVer5.Quilting;
using buCadCamResVer5.Robotic;
using buCadCamResVer5.RollerBend;
using buCadCamResVer5.Router3AX;
using buCadCamResVer5.Sewing;
using buCadCamResVer5.Spinning;
using buCadCamResVer5.ToolGrinding;
using buCadCamResVer5.Tufting;
using buCadCamResVer5.Wood;
using buControls;
using buCore;
using buCore.AppCalc;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Flexo;
using buMW;

#nullable disable
namespace buCadCamResVer5;

public class clsInit
{
  public static clsFiles appFiles = (clsFiles) null;
  public static clsCommand appCommand = (clsCommand) null;
  public static clsSystem appSystem = (clsSystem) null;
  public static clsMW appMW = (clsMW) null;
  public static clsJewel appJewel = (clsJewel) null;
  public static clsSpinning appSpinning = (clsSpinning) null;
  public static clsDiemaker appDiemaker = (clsDiemaker) null;
  public static clsLaserRouter appLaserRouter = (clsLaserRouter) null;
  public static clsPipeBending appPipeBending = (clsPipeBending) null;
  public static clsRobotic appRobotic = (clsRobotic) null;
  public static clsCutter appCutter = (clsCutter) null;
  public static clsTufting appTufting = (clsTufting) null;
  public static clsQuilting appQuilting = (clsQuilting) null;
  public static clsMarble appMarble = (clsMarble) null;
  public static clsProfile appProfile = (clsProfile) null;
  public static clsDrill appDrill = (clsDrill) null;
  public static clsFlexo appFlexo = (clsFlexo) null;
  public static clsSewing appSewing = (clsSewing) null;
  public static clsFoamCutting appFoamCutting = (clsFoamCutting) null;
  public static clsPanelCut appPanelCut = (clsPanelCut) null;
  public static clsPrinter3D appPrinter3D = (clsPrinter3D) null;
  public static clsWood appWood = (clsWood) null;
  public static clsDoor appDoor = (clsDoor) null;
  public static clsEditor appEditor = new clsEditor();
  public static clsEditorV2 appEditor2 = new clsEditorV2();
  public static clsRouter3AX appRouter3AX = (clsRouter3AX) null;
  public static clsRollerBend appRollerBend = (clsRollerBend) null;
  public static clsToolGrinding appToolGrind = (clsToolGrinding) null;
  public static clsNesting appNesting = (clsNesting) null;
  public static clsPowerNest appNestingPower = (clsPowerNest) null;
  public static clsNestOpaline appNestingPanel = (clsNestOpaline) null;
  public static clsLibrary appLibrary = new clsLibrary();
  public static buMWCalcs cMwCalc = (buMWCalcs) null;
  public static buConversion cConv = (buConversion) null;
  public static buFile cFile = (buFile) null;
  public static buVector cVector = (buVector) null;
  public static buCamCalc cCam = (buCamCalc) null;
  public static buKinematic cKinematic = (buKinematic) null;
  public static buCall cCall = (buCall) null;
  public static buTuftingCalc cTuft = (buTuftingCalc) null;
  public static buQuiltingCalc cQuilt = (buQuiltingCalc) null;
  public static buCutterCalc cCutter = (buCutterCalc) null;
  public static buEyeBaseVer5.Apps.Marble.buMarbleCalc cMarble = (buEyeBaseVer5.Apps.Marble.buMarbleCalc) null;
  public static buJewelCalc cJewel = (buJewelCalc) null;
  public static buEyeBaseVer5.Apps.buProfileCalc cProfile = (buEyeBaseVer5.Apps.buProfileCalc) null;
  public static buFlexoCalc cFlexo = (buFlexoCalc) null;
  public static buNestingCalc cNesting = (buNestingCalc) null;
  public static buDrillCalc cDrill = (buDrillCalc) null;
  public static buSewingCalc cSewing = (buSewingCalc) null;
  public static buFoamCalc cFoamCut = (buFoamCalc) null;
  public static buPipeBendCalc cPipeBend = (buPipeBendCalc) null;
  public static buPrinter3D cPrinter3D = (buPrinter3D) null;
  public static buRouter3AX cRouter3AX = (buRouter3AX) null;
  public static buRollerBendCalc cRollerBend = (buRollerBendCalc) null;
  public static buToolGrindingCalc cToolGrind = (buToolGrindingCalc) null;
  public static buWood cWood = (buWood) null;
  public static buDoor cDoor = (buDoor) null;
  public static buRoboticCalc cRobotic = (buRoboticCalc) null;
  public static buPanelCutCalc cPanelCut = (buPanelCutCalc) null;
  public static buDiamakerCalc cDiamaker = (buDiamakerCalc) null;
  public static buAppCalc cAppCalc = (buAppCalc) null;
  public static buSort cSort = (buSort) null;
  public static buNet cNet = (buNet) null;
  public static buString cString = (buString) null;
  public static buGeneral cGeneral = (buGeneral) null;
  public static buNumeric cNumeric = (buNumeric) null;
  public static buImage cImage = (buImage) null;
  public static buMatrix cMatrix = (buMatrix) null;
  public static buGCodeCreate cGcodeCreate = (buGCodeCreate) null;
  public static buCam5 cCam5 = (buCam5) null;
  public static buVector5 cVector5 = (buVector5) null;
  public static buFile5 cFile5 = (buFile5) null;
  public static buKinematic5 cKinematic5 = (buKinematic5) null;
  public static buMatrix5 cMatrix5 = (buMatrix5) null;
  public static buControlCommands cControl = (buControlCommands) null;

  public static void Init()
  {
    clsInit.appFiles = new clsFiles();
    clsInit.appCommand = new clsCommand();
    clsInit.appSystem = new clsSystem();
    buControlCommands buControlCommands = new buControlCommands();
  }
}
