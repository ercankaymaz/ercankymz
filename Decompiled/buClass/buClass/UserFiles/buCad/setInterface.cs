using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass.Apps;

namespace buClass.UserFiles.buCad;

public class setInterface : buSerilization
{
	public Color DrawingColor = Color.Black;

	public double DrawingThickness = 1.0;

	public int PatternIndex = 0;

	public int indexFileEditor = 1;

	public string PostName = "";

	public string pathImage = Application.StartupPath;

	public string pathChar = Application.StartupPath;

	public string pathGCode = Application.StartupPath;

	public string pathData = Application.StartupPath;

	public string pathEditor = Application.StartupPath;

	public string pathLibrary = Application.StartupPath;

	public string pathKinematic = Application.StartupPath;

	public string pathProfile = Application.StartupPath;

	public string pathPost = Application.StartupPath;

	public string pathReport = Application.StartupPath;

	public string pathProfileMacro = Application.StartupPath;

	public string pathStl = Application.StartupPath;

	public string pathImageProcess = Application.StartupPath;

	public string pathMisc = Application.StartupPath;

	public string pathNestingAddPart = Application.StartupPath;

	public string pathNestingCreatCode = Application.StartupPath;

	public string pathNestingFiles = Application.StartupPath;

	public string pathNestingOutputs = Application.StartupPath;

	public string pathCf2Settings = Application.StartupPath;

	public string pathDiemakerCodes = Application.StartupPath;

	public string pathJewelModes = Application.StartupPath;

	public string pathToolHolder = Application.StartupPath;

	public string pathTool = Application.StartupPath;

	public string FileNameImageProcess = Application.StartupPath;

	public string fileNameKinematic = "";

	public string fileCf2SettingsName = Application.StartupPath;

	public string fileTexture = Application.StartupPath;

	public int ToolGroupIndex = 0;

	public int ToolIndex = 0;

	public int MaterialIndex = 0;

	public int CamSimulationStep = 1;

	public bool DynamicSelectionX = true;

	public bool DynamicSelectionY = true;

	public bool DynamicSelectionZ = true;

	public double FatWireframeDistance = 2.5;

	public RasterToVectorVar RasterVectorVar = new RasterToVectorVar();

	public RectangleDraw RectangleVar = new RectangleDraw();

	public RectangleRoundDraw RectangleRoundVar = new RectangleRoundDraw();

	public RectangleChamferDraw RectangleChamferVar = new RectangleChamferDraw();

	public PolygonDraw PolygonVar = new PolygonDraw();

	public FreeDraw FreeDrawVar = new FreeDraw();

	public SplineDrawVar SplineVar = new SplineDrawVar();

	public BarrelDrawVar BarrelVar = new BarrelDrawVar();

	public SlotDrawVar SlotVar = new SlotDrawVar();

	public ImageDrawVar ImageVar = new ImageDrawVar();

	public InsertFromFileVar InsertFileVar = new InsertFromFileVar();

	public TextDrawVar TextVar = new TextDrawVar();

	public TextVectorData VectorTextVar = new TextVectorData();

	public TextCustomData CustomTextVar = new TextCustomData();

	public OrdinateDimVar OrdinateVar = new OrdinateDimVar();

	public LeaderVarType LeaderVar = new LeaderVarType();

	public LibraryDraw LibraryVar = new LibraryDraw();

	public ExchangeEventVar ExchangeVar = new ExchangeEventVar();

	public LineerArrayEventVar ArrayLineerVar = new LineerArrayEventVar();

	public PolarArrayEventVar ArrayPolarVar = new PolarArrayEventVar();

	public MirrorSingleEventVar MirrorSingleVar = new MirrorSingleEventVar();

	public MirrorEventVar MirrorVar = new MirrorEventVar();

	public RotateEventVar RotateVar = new RotateEventVar();

	public RotateVectorEventVar RotateVectorVar = new RotateVectorEventVar();

	public RotateClickEventVar RotateClickVar = new RotateClickEventVar();

	public ScaleEventVar ScaleVar = new ScaleEventVar();

	public OffsetEventVar OffsetVar = new OffsetEventVar();

	public ExtendEventVar ExtendVar = new ExtendEventVar();

	public ChamferEventVar ChamferVar = new ChamferEventVar();

	public FilletEventVar FilletVar = new FilletEventVar();

	public MoveHeightEventVar MoveHeightVar = new MoveHeightEventVar();

	public BreakEventVar BreakVar = new BreakEventVar();

	public TangentEventVar TangentVar = new TangentEventVar();

	public ParalelEventVar ParalelVar = new ParalelEventVar();

	public PerpendicularEventVar PerpendicularVar = new PerpendicularEventVar();

	public LineerHatchVar HatchVar = new LineerHatchVar();

	public ExplodeEventVar ExplodeVar = new ExplodeEventVar();

	public QuickDimensionVar QuickDimVar = new QuickDimensionVar();

	public MarbleSetAngleVar MarbleSetAngleVar = new MarbleSetAngleVar();

	public MarbleMoveRotateVar MarbleMoveRotateVar = new MarbleMoveRotateVar();

	public SurfaceFromXYPlane surfacePlaneVar = new SurfaceFromXYPlane();

	public SurfaceByVector surfaceByVector = new SurfaceByVector();

	public cam5AxisSettingsXYZAC Cam5AxisSettingsXYZAC = new cam5AxisSettingsXYZAC();

	public AreaSelectBrush AreaBrush = new AreaSelectBrush();

	public ArrayList LastLoadedFiles = new ArrayList();

	public ArrayList LastImportedFiles = new ArrayList();

	public int MaterialSkinIndex = 0;

	public ZHeightAdjustmentByDistance ZHeightAdjustmentDistVar = new ZHeightAdjustmentByDistance();

	public MoveScaleRotateStretchVar MoveScaleRotateExtentVar = new MoveScaleRotateStretchVar();

	public int NestingAddPartFromFileExtensionIndex = 1;

	public BackupModes BackupMode = new BackupModes();

	public bool ConstantDistanceEnable = false;

	public double ConstantDistanceValue = 0.0;

	public camOffset CamInsideOffset = new camOffset();

	public camStep CamInsideStep = new camStep();

	public camDistances CamInsideDistance = new camDistances();

	public camSpeeds CamInsideVelocity = new camSpeeds();

	public camStrategy CamInsideStrategy = new camStrategy();

	public camOptions CamInsideOptions = new camOptions();

	public camOperation CamInsideOperation = new camOperation();

	public bool MaterialShow = true;

	public XRayData XrayDataVar = new XRayData();

	public bool SelectOnlyCamEntities = false;

	public int LineCommandIndex = 0;

	public int RectangleCommandIndex = 0;

	public int PolygonCommandIndex = 0;

	public int CircleCommandIndex = 0;

	public int ArcCommandIndex = 0;

	public int EllipseCommandIndex = 0;

	public int CurveCommandIndex = 0;

	public int ObjectCommandIndex = 0;

	public int SpecialCommandIndex = 0;

	public int DimensionCommandIndex = 0;

	public int InsertCommandIndex = 0;

	public double MinDistanceForEntity = 0.0;

	public setInterface()
	{
	}

	public setInterface(setInterface data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
