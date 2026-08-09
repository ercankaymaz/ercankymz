using System.Collections.Generic;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5;

public class ccVars
{
	public static ViewportCC activeViewport = null;

	public static actionTypeBU Action = actionTypeBU.None;

	public static List<Pages> Pages = new List<Pages>();

	public static List<ToolGroup5> Tools = new List<ToolGroup5>();

	public static List<MaterialBase5> MaterialList = new List<MaterialBase5>();

	public static List<LayerOverride> LayerOptions = new List<LayerOverride>();

	public static MaterialBase5 activeMaterial = new MaterialBase5();

	public static List<Material> Textures = new List<Material>();

	public static MachineDef SimMachine = null;

	public static KinematicBase5 KinematicOrjinal = null;

	public static List<PointsList> fontPoints = new List<PointsList>();

	public static List<EntitiesList> entitiesContour = new List<EntitiesList>();

	public static List<CharLibrary5> CharLibList = new List<CharLibrary5>();

	public static List<List<MeasureItem>> SelectedMeasureObjects = new List<List<MeasureItem>>();

	public static List<MeasureItem> MeasureObjects = new List<MeasureItem>();

	public static SelectionOperation SelectionOP = new SelectionOperation();

	public static int PageIndex = 0;

	public static int ToolGroupIndex = 0;

	public static int ToolIndex = 0;

	public static int stpDrawing = 0;

	public static int AngularDimType = 0;

	public static int LastMeasured = -1;

	public static int SelectedIndex = -1;

	public static int SimCamBaseIndex = -1;

	public static int SimCamPointIndex = 0;

	public static int SimToolEntityIndex = -1;

	public static int libSelectedEntityIndex = -1;

	public static int indexSelected1 = -1;

	public static int indexSelected2 = -1;

	public static int numberOfUnderEntity = 0;

	public static int numberOfUnderSelectedEntity = 0;

	public static int numberOfSelectedEntity = 0;

	public static List<int> libReletedEntityIndex = new List<int>();

	public static bool SimStopAfterExecute = false;

	public static bool selectionProcess = false;

	public static bool selectionOnlyPick = false;

	public static bool UndoDont = false;

	public static bool OsnapDont = false;

	public static bool MainFormClosing = false;

	public static double WidthHeightRatio = 1.0;

	public static double DPIScale = 1.0;

	public static double lastRotatedAngle = 0.0;

	public static bool HelpMe = false;

	public static SortAskMe AskMe = new SortAskMe();

	public static bool enableViewPortCurrentLineArrow = false;

	public static bool enableViewportCross = false;

	public static bool enableViewportDrawCurrentLine = false;

	public static bool enableViewportTextForCommand = false;

	public static bool enableDynamicalSpins = false;

	public static bool ShowCoordinates = false;

	public static bool disableOrtho = false;

	public static bool disableSmartSelection = false;

	public static bool RealDrawMode = false;

	public static bool Moved = false;

	public static bool MoveEntityPointPressed = false;

	public static bool DrawPointer = false;

	public static string dynamicTextOnMouse = "";

	public static string dynamicTextOnPosition = "";

	public static Brep.Face selectedFace = null;

	public static Plane planeActive = new Plane();

	public static Plane planeTemp = new Plane();

	public static Plane planePreview = new Plane();

	public static PostProcessor PostActive = new PostProcessor();

	public static ToolBase5 toolActive = new ToolBase5();

	public static PageSelectedItem SelectedPageItem = new PageSelectedItem();

	public static Point3D pntActive = new Point3D();

	public static Point3D pntBase = new Point3D();

	public static Point3D pntStart = new Point3D();

	public static Point3D pntEnd = new Point3D();

	public static Point3D pntTip = new Point3D();

	public static Point3D pntText = new Point3D();

	public static Point3D pntMin = new Point3D();

	public static Point3D pntMid = new Point3D();

	public static Point3D pntMax = new Point3D();

	public static Point3D pntMouseDownFirst = new Point3D();

	public static Point3D pntMouseDown = new Point3D();

	public static Point3D pntMouseMove = new Point3D();

	public static Point3D pntMouseUp = new Point3D();

	public static Point3D pntMinViewport = new Point3D();

	public static Point3D pntMaxViewport = new Point3D();

	public static Point3D pntSelectedMin = new Point3D();

	public static Point3D pntSelectedMid = new Point3D();

	public static Point3D pntSelectedMax = new Point3D();

	public static Pnt6DSimMove pntSimulation = new Pnt6DSimMove();

	public static AxesEnableXYZ ConstantCoordinateEnable = new AxesEnableXYZ(x: false, y: false, z: false);

	public static Point3D ConstantCoordinate = new Point3D();

	public static OsnapCoordinateCatch OsnapCatchPoint = new OsnapCoordinateCatch();

	public static TextVectorRuntimeData VectorTextRunVar = new TextVectorRuntimeData();

	public static TextCustomRuntimeData CustomTextRunVar = new TextCustomRuntimeData();

	public static List<Entity> tempEntities = new List<Entity>();

	public static List<Entity> SortedEntities = new List<Entity>();

	public static List<HighLights> HighLightPoints = new List<HighLights>();

	public static List<PointRGB> pntMark = new List<PointRGB>();

	public static List<Point3D> pntBuffered = new List<Point3D>();

	public static List<Point3D> pntDrawDynamicLines = new List<Point3D>();

	public static List<List<Point3D>> pntDrawDynamicLinesArr = new List<List<Point3D>>();

	public static List<List<PointRGB>> pntDrawDynamicLinesArrColored = new List<List<PointRGB>>();

	public static List<MeasureData> pntDrawDynamicMeasure = new List<MeasureData>();

	public static Point3D[] pntDrawDynamicArr = null;

	public static List<ContourPoints> ContourPoints = new List<ContourPoints>();

	public static List<ContourPoints5> ContourPoints5 = new List<ContourPoints5>();

	public static List<Point3D> pntDrawDynamicMarkers = new List<Point3D>();

	public static List<buCircle> DrawCircle = new List<buCircle>();

	public static List<List<Entity>> entityEdges = null;

	public static List<DirectionArrow> SortArrow = new List<DirectionArrow>();

	public static List<Entity> entCalculations = new List<Entity>();

	public static List<Point4D> pntDynamicCompositeCurve = new List<Point4D>();

	public static spnDynamicProp Spin1Prop = new spnDynamicProp();

	public static spnDynamicProp Spin2Prop = new spnDynamicProp();

	public static spnDynamicProp Spin3Prop = new spnDynamicProp();

	public static spnDynamicProp Spin4Prop = new spnDynamicProp();
}
