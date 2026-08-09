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
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Flexo;
using buMW;

namespace buCadCamResVer5;

public class clsInit
{
	public static clsFiles appFiles = null;

	public static clsCommand appCommand = null;

	public static clsSystem appSystem = null;

	public static clsMW appMW = null;

	public static clsJewel appJewel = null;

	public static clsSpinning appSpinning = null;

	public static clsDiemaker appDiemaker = null;

	public static clsLaserRouter appLaserRouter = null;

	public static clsPipeBending appPipeBending = null;

	public static clsRobotic appRobotic = null;

	public static clsCutter appCutter = null;

	public static clsTufting appTufting = null;

	public static clsQuilting appQuilting = null;

	public static clsMarble appMarble = null;

	public static clsProfile appProfile = null;

	public static clsDrill appDrill = null;

	public static clsFlexo appFlexo = null;

	public static clsSewing appSewing = null;

	public static clsFoamCutting appFoamCutting = null;

	public static clsPanelCut appPanelCut = null;

	public static clsPrinter3D appPrinter3D = null;

	public static clsWood appWood = null;

	public static clsDoor appDoor = null;

	public static clsEditor appEditor = new clsEditor();

	public static clsEditorV2 appEditor2 = null;

	public static clsRouter3AX appRouter3AX = null;

	public static clsRollerBend appRollerBend = null;

	public static clsToolGrinding appToolGrind = null;

	public static clsNesting appNesting = null;

	public static clsPowerNest appNestingPower = null;

	public static clsNestOpaline appNestingPanel = null;

	public static clsLibrary appLibrary = new clsLibrary();

	public static buMWCalcs cMwCalc = null;

	public static buConversion cConv = null;

	public static buFile cFile = null;

	public static buVector cVector = null;

	public static buCamCalc cCam = null;

	public static buKinematic cKinematic = null;

	public static buCall cCall = null;

	public static buTuftingCalc cTuft = null;

	public static buQuiltingCalc cQuilt = null;

	public static buCutterCalc cCutter = null;

	public static buEyeBaseVer5.Apps.Marble.buMarbleCalc cMarble = null;

	public static buJewelCalc cJewel = null;

	public static buProfileCalc cProfile = null;

	public static buFlexoCalc cFlexo = null;

	public static buNestingCalc cNesting = null;

	public static buDrillCalc cDrill = null;

	public static buSewingCalc cSewing = null;

	public static buFoamCalc cFoamCut = null;

	public static buPipeBendCalc cPipeBend = null;

	public static buPrinter3D cPrinter3D = null;

	public static buRouter3AX cRouter3AX = null;

	public static buRollerBendCalc cRollerBend = null;

	public static buToolGrindingCalc cToolGrind = null;

	public static buWood cWood = null;

	public static buDoor cDoor = null;

	public static buRoboticCalc cRobotic = null;

	public static buPanelCutCalc cPanelCut = null;

	public static buDiamakerCalc cDiamaker = null;

	public static buAppCalc cAppCalc = null;

	public static buSort cSort = null;

	public static buNet cNet = null;

	public static buString cString = null;

	public static buGeneral cGeneral = null;

	public static buNumeric cNumeric = null;

	public static buImage cImage = null;

	public static buMatrix cMatrix = null;

	public static buGCodeCreate cGcodeCreate = null;

	public static buCam5 cCam5 = null;

	public static buVector5 cVector5 = null;

	public static buFile5 cFile5 = null;

	public static buKinematic5 cKinematic5 = null;

	public static buMatrix5 cMatrix5 = null;

	public static buControlCommands cControl = null;

	public static void Init()
	{
		appFiles = new clsFiles();
		appCommand = new clsCommand();
		appSystem = new clsSystem();
		new buControlCommands();
	}
}
