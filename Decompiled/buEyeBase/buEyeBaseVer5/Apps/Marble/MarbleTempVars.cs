using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

public static class MarbleTempVars
{
	public static string MarbleReleaseVer = "01";

	public static int HMIStyle = 1;

	public static MarbleCommands Commands = MarbleCommands.None;

	public static MarbleCountertopEdgeCommandTypes CountertopEdgeType = MarbleCountertopEdgeCommandTypes.Edge;

	public static MarbleCountertopCornerTypes CountertopCornerType = MarbleCountertopCornerTypes.Rectangle;

	public static MarbleOperationPageMode OperationageMode = MarbleOperationPageMode.Operation;

	public static int ItemID = 1;

	public static int MarbleCamID = 1;

	public static int MarbleEdgeID = 1;

	public static int MarbleStripID = 1;

	public static int LastSelectedTabPage = -1;

	public static int AxesNumber = 3;

	public static bool isDialogItem = false;

	public static bool DontChangeValuesAtOperations = false;

	public static bool HorizontalSetStartPositionDone = false;

	public static bool VerticalSetStartPositionDone = false;

	public static bool isHorizontal = false;

	public static bool AddedOrChanged = false;

	public static bool isSolidMove = false;

	public static bool Editing = false;

	public static bool SetAngle = false;

	public static bool SimSpindlePistonDown = false;

	public static bool UndoDont = false;

	public static bool selectableOperation = false;

	public static bool selectableEdge = false;

	public static bool selectableCollapse = false;

	public static bool selectableVacuum = false;

	public static bool selectableSlat = false;

	public static bool DontDrawSaw = false;

	public static bool DontDrawMilling = false;

	public static bool DontDrawMillingHead = false;

	public static bool DontDrawWaterJet = false;

	public static bool DontDrawAirDry = false;

	public static bool DontDrawLaserPointer = false;

	public static bool DockBottomEnable = false;

	public static bool DockLeftEnable = false;

	public static bool DockRightEnable = false;

	public static bool MachineCoordShowModeChanged = false;

	public static bool PartCoordShowModeChanged = false;

	public static bool SavingMachine = false;

	public static bool UndoApplying = false;

	public static bool SavingUser = false;

	public static bool SavingInterface = false;

	public static bool SavingMarble = false;

	public static bool SavingUserLog = false;

	public static bool SavingCriticalLog = false;

	public static bool SavingLog = false;

	public static bool SavingExceptionsLog = false;

	public static bool CheckingLogSize = false;

	public static double Length = 0.0;

	public static bool CameraFrameShowed = false;

	public static int HorizontalItemIndex = 0;

	public static int VerticalItemIndex = 0;

	public static int HorVerHorizontalItemIndex = 0;

	public static int HorVerVerticalItemIndex = 0;

	public static int HorizontalItemSelectedRowIndex = -1;

	public static int VerticalItemSelectedRowIndex = -1;

	public static int HorVerHorizontalItemSelectedRowIndex = -1;

	public static int HorVerVerticalItemSelectedRowIndex = -1;

	public static int HorizontalItemSelectedColIndex = -1;

	public static int VerticalItemSelectedColIndex = -1;

	public static int HorVerHorizontalItemSelectedColIndex = -1;

	public static int HorVerVerticalItemSelectedColIndex = -1;

	public static Pnt6D HorizontalStartPos = new Pnt6D();

	public static Pnt6D HorizontalEndPos = new Pnt6D();

	public static Pnt6D VerticalStartPos = new Pnt6D();

	public static Pnt6D VerticalEndPos = new Pnt6D();

	public static Pnt6D SingleCutPos = new Pnt6D();

	public static Pnt6DSimMove SimulationPoint = new Pnt6DSimMove();

	public static LayerDefination layerWood = new LayerDefination("LayerWood", 2.0, Color.BurlyWood, 0);

	public static LayerDefination layerMarbleSheet = new LayerDefination("LayerMarbleSheet", 2.0, Color.LightCyan, 1, 120);

	public static LayerDefination layerMarblePart = new LayerDefination("LayerMarblePart", 2.0, Color.White, 2, 180);

	public static LayerDefination layerDrawing = new LayerDefination("Drawing", 2.0, Color.Black, 3);

	public static LayerDefination layerCutting = new LayerDefination("Cutting", 2.0, Color.Red, 4);

	public static LayerDefination layerMachine = new LayerDefination("Machine", 2.0, Color.Gray, 5);

	public static LayerDefination layerShape = new LayerDefination("Shape", 2.0, Color.Cyan, 6);

	public static LayerDefination layer3D = new LayerDefination("3D", 2.0, Color.DimGray, 7);

	public static LayerDefination layerCam = new LayerDefination("Cam", 2.0, Color.Blue, 8);

	public static LayerDefination layerCamG1 = new LayerDefination("CamG1", 2.0, Color.Red, 9);

	public static LayerDefination layerCamPlunge = new LayerDefination("CamPlunge", 2.0, Color.Lime, 10);

	public static LayerDefination layerCamLeave = new LayerDefination("CamLeave", 2.0, Color.Cyan, 11);

	public static LayerDefination layerCamConnection = new LayerDefination("CamConnection", 2.0, Color.Purple, 12);

	public static LayerDefination layerCamLeadInOut = new LayerDefination("CamLeadInOut", 2.0, Color.Orange, 13);

	public static LayerDefination layerCamDraw = new LayerDefination("CamG1", 2.0, Color.DarkOliveGreen, 14);

	public static LayerDefination layerAngle = new LayerDefination("Angle", 2.0, Color.Purple, 15);

	public static LayerDefination layerEngrave = new LayerDefination("Engrave", 2.0, Color.Green, 16);

	public static string pathWood = Application.StartupPath;

	public static string pathMarble = Application.StartupPath;

	public static string fileNameWood = "BaseMaterial.png";

	public static string fileNameMarble = "MarbleBlackAndWhile.png";

	public static List<MaterialBase5> tempMaterials = null;

	public static List<Entity> ImportedEntitites = new List<Entity>();

	public static marbleCuttingItems SlicesItem = null;

	public static List<marbleCuttingItems> listHorizontalItems = null;

	public static List<marbleCuttingItems> listVerticalItems = null;

	public static marbleCuttingItems[] cutItemsHor = null;

	public static marbleCuttingItems[] cutItemsVer = null;

	public static marbleCuttingItems[] cutItemsHorVerHor = null;

	public static marbleCuttingItems[] cutItemsHorVerVer = null;

	public static List<MarbleItem> ItemsSlice = null;

	public static List<MarbleItem> ItemsContour = null;

	public static List<MarbleItem> ItemsProfile = null;

	public static List<MarbleItem> ItemsSweep = null;

	public static List<MarbleItem> ItemsDrill = null;

	public static List<MarbleItem> ItemsColumns = null;

	public static List<MarbleItem> ItemsLathe = null;

	public static List<MarbleItem> ItemsCavity = null;

	public static List<MarbleItem> ItemsTap = null;

	public static Entity CameraImage = null;

	public static List<Point3D> MaterialLimits = null;

	public static List<int> LastSelectedEntitiesList = null;

	public static List<buEntity> SweepZFormEntities = null;

	public static MarbleCountertopModes CountertopMode = MarbleCountertopModes.None;

	public static MarbleToolType ActiveSimulationToolType = MarbleToolType.Saw;

	public static int CountertopItemindex = -1;

	public static int EdgeIndex = -1;

	public static int EdgeInsideItemIndex = -1;

	public static string EdgeOutsideInside = "Outside";

	public static int CornerIndex = -1;

	public static int VacuumIndex = -1;

	public static bool VacuumEnable = false;

	public static bool DrawIsArc = false;

	public static bool DrawIsInside = false;
}
