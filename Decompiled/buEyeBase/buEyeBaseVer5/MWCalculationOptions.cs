using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class MWCalculationOptions : buSerilization5
{
	public bool AddToCamListInMWCalculation = false;

	public bool AddToCamListInLocalCalculation = false;

	public bool DontApplyReset = false;

	public bool UseStartPoint = false;

	public bool HeightFromEntities = true;

	public bool UseConstantStartPoint = false;

	public bool UseEachCurveStartPoint = false;

	public bool Editing = false;

	public bool is5AxisWireframe = false;

	public bool isAllG1 = false;

	public double StartPointX = 0.0;

	public double StartPointY = 0.0;

	public double StartZ = 0.0;

	public double Height = 0.0;

	public double Depth = 0.0;

	public double WireframeRoughtStepOverParaelelOverride = 0.0;

	public double CurveEntityRegenDeviation = 0.01;

	public double SolidEntityRegenDeviation = 0.01;

	public double RapidDistance = 0.0;

	public double SafeDistance = 0.0;

	public bool isPointDistrubition = false;

	public bool isClosed = false;

	public bool isRough = false;

	public bool isBuWireframeCalculation = false;

	public bool isTriangularMeshAdvanced = false;

	public bool isSpinCalculation = false;

	public bool isSpinConstantCalculation = false;

	public bool isBuSort = true;

	public bool Reverse = false;

	public bool DontShowDialogBox = false;

	public bool DontShowbuDialogBox = false;

	public bool UseSortedAndSplitedEntities = false;

	public bool CheckBoxBounding = false;

	public bool ShowLeadInOutPage = true;

	public bool ShowOptionPage = true;

	public bool ShowProgressForm = true;

	public bool ToolDataToCamData = false;

	public bool CheckIsCLosedEntities = true;

	public bool AllowIntercetionCurve = false;

	public bool SaveDefaultMWParameter = true;

	public Pnt3D BoxBoundingMin = new Pnt3D();

	public Pnt3D BoxBoundingMax = new Pnt3D();

	public int NumberofAxis = 3;

	public int CamID = -1;

	public string FourthAxis = "C";

	public CamMode Mode = CamMode.WireFrame;

	public ClockDirectionType Direction = ClockDirectionType.CW;

	public CamWireFrameType CamWireframeType = CamWireFrameType.Contour;

	public CamTriangularMeshType CamTriMeshType = CamTriangularMeshType.Rough;

	public CamTriangularMesh5AxType CamTriMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;

	public CamSurfaceType CamSurfType = CamSurfaceType.SurfaceParalel;

	public CamDrillType CamDrillType = CamDrillType.Line;

	public CamDrillMode CamDrillMode = CamDrillMode.Point;

	public actionTypeBU Action = actionTypeBU.None;

	public CamMode CamMode = CamMode.WireFrame;

	public CamRotationType CamRotateType = CamRotationType.Flat;

	public EntityDevideData DevideData = new EntityDevideData();

	public SortSettings SortingSettings = new SortSettings();

	public List<Point3D> ClickList = new List<Point3D>();

	public MWCalculationOptions()
	{
	}

	public MWCalculationOptions(MWCalculationOptions data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		data.DevideData = new EntityDevideData(data.DevideData);
		data.SortingSettings = new SortSettings(data.SortingSettings);
	}
}
