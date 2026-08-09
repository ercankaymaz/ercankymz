using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.UserFiles.buCad;
using buEyeBaseVer5;
using buEyeBaseVer5.Variables;
using buMW;

namespace buCadCamResVer5;

public class clsVar
{
	public static appModes UserMode = new appModes();

	internal static appModes appModes_0 = new appModes();

	public static AppDefination appDefination = new AppDefination();

	public static List<FileEventArg> PostAvailableNames = new List<FileEventArg>();

	public static List<ShortCutKey> ShortKeyList = new List<ShortCutKey>();

	public static List<Color> ColorList = new List<Color>();

	public static List<Cf2FileProperties> Cf2Properties = new List<Cf2FileProperties>();

	public static List<string> OsnapDeleteList = new List<string>();

	public static bool CancelFromQuit = false;

	public static bool PreviewLoaded = false;

	public static bool ContextMenuCancel = false;

	public static List<Bitmap> RecordScreens = new List<Bitmap>();

	public static ReportProgram Report = new ReportProgram();

	public static int AskLicenseCount = 0;

	public static int ReportCount = 0;

	public static int BackGroundTickCount = 0;

	public static int OpenedFileCount = 0;

	public static int RunCount = 0;

	public static int NewCount = 0;

	public static bool SingleNewPage = false;

	public static string OpeningFileName = "";

	internal static bool bool_0 = false;

	public static bool NewPageViewportMode = false;

	public static string SelectedRibbonMenuName = "";

	public static string ImageFileName = Application.StartupPath;

	public static Thread threadCalculations = null;

	public static ThreadCommands ThreadCommand = new ThreadCommands();

	public static string UnlockKey = "";

	public static List<MacroBase> macroNewPage = new List<MacroBase>();

	public static List<MacroBase> macroNewScene = new List<MacroBase>();

	public static List<MacroBase> macroInit = new List<MacroBase>();

	public static List<MacroBase> macroStartUp = new List<MacroBase>();

	public static List<MacroBase> macroOpen = new List<MacroBase>();

	public static List<MacroBase> macroImport = new List<MacroBase>();

	public static varRuntimePar5 varInterface5 = new varRuntimePar5();

	public static setInterface varInterface = new setInterface();

	public static setRuntime varRuntime = new setRuntime();

	public static setMainForm varMainForm = new setMainForm();

	public static setProgram varProgram = new setProgram();

	public static setDisplay varDisplay = new setDisplay();

	public static setView varView = new setView();

	public static setScreen varScreen = new setScreen();

	public static setViewportSet varPreviewViewport = new setViewportSet();

	public static setViewportSet varToolViewport = new setViewportSet();

	public static setEntities varEntities = new setEntities();

	public static setGeometry varGeometry = new setGeometry();

	public static setSelection varSelection = new setSelection();

	public static setFile varFile = new setFile();

	public static setMouse varMouse = new setMouse();

	public static setSimulation varSimulation = new setSimulation();

	public static setLayer varLayer = new setLayer();

	public static setCam varCam = new setCam();

	public static setCommunication varCommunication = new setCommunication();

	public static setLibrary varLibrary = new setLibrary();

	public static setChar varChar = new setChar();

	public static EntitiesResolution varCadEntResolution = new EntitiesResolution();

	public static EntitiesResolution varCamCalcResolution = new EntitiesResolution();

	public static WriteDxfDwgPropeties varAutoCadFileProps = new WriteDxfDwgPropeties();

	public static MachineGCodeConfigrasyon varMachineGCodeConfig = new MachineGCodeConfigrasyon();

	public static EditorSettings varEditorSet = new EditorSettings();

	public static EditorRuntimeSettings varEditorRuntimeSet = new EditorRuntimeSettings();

	public static MWParameters varCamMeshRoughPars = null;

	public static MWParameters varCamMeshParallelPars = null;

	public static MWParameters varCamMeshConstantZPars = null;

	public static MWParameters varCamMeshPencilPars = null;

	public static MWParameters varCamMeshProjectionPars = null;

	public static MWParameters varCamMeshFlatlandsPars = null;

	public static MWParameters varCamMeshConstantCuspPars = null;

	public static MWParameters varCamWFPocketPars = null;

	public static MWParameters varCamWFContourPars = null;

	public static MWParameters varCamWFContour4XPars = null;

	public static MWParameters varCamDrillPars = null;

	public static MWParameters varCamDrill4XPars = null;
}
