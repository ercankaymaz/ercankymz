using System;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillRuntimeSettings : buSerilization5
{
	public double NewSheetWidth = 1000.0;

	public double NewSheetLength = 1500.0;

	public double NewSheetHeight = 10.0;

	public ClockDirectionType RotateClockType = ClockDirectionType.CW;

	public double RotateDegree = 180.0;

	public MirrorBoxType MirrorType = MirrorBoxType.Plane;

	public bool MirrorCopyAsNew = true;

	public planeBoxNames lastDrillPlaneNames = planeBoxNames.Top;

	public planeBoxNames lastContourPlaneNames = planeBoxNames.Top;

	public planeBoxNames lastShapePlaneNames = planeBoxNames.Top;

	public planeBoxNames lastProfilingPlaneNames = planeBoxNames.Top;

	public planeBoxNames lastTextPlaneNames = planeBoxNames.Top;

	public CornerLocation Corner = CornerLocation.LeftBottom;

	public Point3D drillPoint = new Point3D();

	public double drillDepth = 2.0;

	public double drillDiameter = 4.0;

	public double drillStartDistance = 0.0;

	public double drillEndDistance = 0.0;

	public double drillHeight = 0.0;

	public bool drillUseMilling = false;

	public Point3D drillGroupEndPoint = new Point3D();

	public Point3D slotPoint = new Point3D();

	public double slotDepth = 2.0;

	public double slotLength = 4.0;

	public double slotWidth = 4.0;

	public double slotStartDistance = 0.0;

	public double slotEndDistance = 0.0;

	public double slotHeight = 0.0;

	public double slotAngle = 0.0;

	public bool slotUseMilling = false;

	public Point3D slotGroupEndPoint = new Point3D();

	public Point3D rectanglePoint = new Point3D();

	public double rectangleDepth = 2.0;

	public double rectangleWidth = 100.0;

	public double rectangleHeigth = 100.0;

	public double rectangleAngle = 100.0;

	public bool rectangleFromCenter = true;

	public bool rectanglePocket = false;

	public Point3D polygonPoint = new Point3D();

	public double polygonDepth = 2.0;

	public double polygonDiameter = 50.0;

	public int polygonSides = 6;

	public double polygonAngle = 0.0;

	public bool polygonPocket = false;

	public Point3D slotShapePoint = new Point3D();

	public double slotShapeDepth = 2.0;

	public double slotShapeWidth = 50.0;

	public double slotShapeHeight = 6.0;

	public double slotShapeAngle = 0.0;

	public bool slotShapePocket = false;

	public Point3D ellipsePoint = new Point3D();

	public double ellipseDepth = 2.0;

	public double ellipseWidth = 100.0;

	public double ellipseHeigth = 100.0;

	public double ellipseAngle = 100.0;

	public bool ellipseFromCenter = true;

	public bool ellipsePocket = false;

	public Point3D circlePoint = new Point3D();

	public double circleDepth = 2.0;

	public double circleDiameter = 20.0;

	public bool circleFromCenter = true;

	public bool circlePocket = false;

	public bool shapeDrill = false;

	public double singleCornerWidth = 50.0;

	public double singleCornerHeight = 50.0;

	public double singleCornerDepth = 4.0;

	public bool singleCornerPocket = false;

	public bool singleCornerStepEnable = false;

	public double singleCornerStepValue = 1.0;

	public double VerticalDistance = 100.0;

	public int VerticalCount = 1;

	public double HorizontalDistance = 100.0;

	public int HorizontalCount = 1;

	public bool CopyEnable = false;

	public bool CollisionCheck = false;

	public bool StepRun = true;

	public bool EngravingKeepRatio = true;

	public bool SimStopAtMatReady = true;

	public int SimStep = 1;

	public double ContourOffset = -1.0;

	public double ContourDepth = 0.0;

	public drillCommands DrillCommand = drillCommands.SingleHole;

	public drillCommandBase DrillBaseCommand = drillCommandBase.None;

	public drillErpFileType ErpFileType = drillErpFileType.Cabinet;

	public DrillItemType ItemType = DrillItemType.Drill;

	public string pathSaveCode = Application.StartupPath;

	public string pathOpenCode = Application.StartupPath;

	public string pathTool = Application.StartupPath;

	public string pathEngraving = Application.StartupPath;

	public string path3DJob = Application.StartupPath;

	public Point3D engravingPoint = new Point3D();

	public bool engravingRough = true;

	public bool engravingFinish = false;

	public bool shapeStepEnable = false;

	public double shapeStepValue = 1.0;

	public string CabinetpathImport = Application.StartupPath;

	public string CabinetpathExport = Application.StartupPath;

	public string CabinetpathDeleted = Application.StartupPath;

	public string CabinetReferanceKey = Application.StartupPath;

	public bool CabinetSubFolder = false;

	public bool CabinetShowInfo = false;

	public bool CabinetMirrorIfSlotClamperSide = false;

	public bool CabinetMirrorIfNoClamperSideAvailable = false;

	public string CabinetAutoFileExtension = "txt";

	public int CabinetAutoCycleTickMs = 5000;

	public int CabinetAutoCycleTickDelayMs = 3000;

	public bool CabinetAutoCycleDeleteAndMove = true;

	public bool ToolExpertMode = false;

	public string RecentSaveFile1 = "-";

	public string RecentSaveFile2 = "-";

	public string RecentSaveFile3 = "-";

	public string RecentSaveFile4 = "-";

	public string RecentSaveFile5 = "-";

	public string RecentSaveFile6 = "-";

	public string RecentOpenFile1 = "-";

	public string RecentOpenFile2 = "-";

	public string RecentOpenFile3 = "-";

	public string RecentOpenFile4 = "-";

	public string RecentOpenFile5 = "-";

	public string RecentOpenFile6 = "-";

	public DrillRuntimeSettings()
	{
	}

	public DrillRuntimeSettings(DrillRuntimeSettings data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		drillPoint = new Point3D(data.drillPoint.X, data.drillPoint.Y, data.drillPoint.Z);
		drillGroupEndPoint = new Point3D(data.drillGroupEndPoint.X, data.drillGroupEndPoint.Y, data.drillGroupEndPoint.Z);
		slotPoint = new Point3D(data.slotPoint.X, data.slotPoint.Y, data.slotPoint.Z);
		circlePoint = new Point3D(data.circlePoint.X, data.circlePoint.Y, data.circlePoint.Z);
		rectanglePoint = new Point3D(data.rectanglePoint.X, data.rectanglePoint.Y, data.rectanglePoint.Z);
		ellipsePoint = new Point3D(data.ellipsePoint.X, data.ellipsePoint.Y, data.ellipsePoint.Z);
		polygonPoint = new Point3D(data.polygonPoint.X, data.polygonPoint.Y, data.polygonPoint.Z);
		slotShapePoint = new Point3D(data.slotShapePoint.X, data.slotShapePoint.Y, data.slotShapePoint.Z);
		engravingPoint = new Point3D(data.engravingPoint.X, data.engravingPoint.Y, data.engravingPoint.Z);
	}
}
