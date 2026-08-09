using System.Reflection;

namespace buClass.Apps;

public class jewelMode : buSerilization
{
	public jewelOperationModeType OperationMode = jewelOperationModeType.Spindle;

	public jewelCamModeType CamMode = jewelCamModeType.Contour3AX;

	public jewelCamOperationType CamOperation = jewelCamOperationType.Contour;

	public jewelCurveType FormMode = jewelCurveType.Flat;

	public CamOffsetType OffsetType = CamOffsetType.Center;

	public jewelMaterialType MaterialMode = jewelMaterialType.Ring;

	public geoArc ArcShapeData = new geoArc();

	public Pnt3D pntCamRotateCenter = new Pnt3D();

	public Pnt3D ArcCenter = new Pnt3D();

	public double RingRotateCenterX = 0.0;

	public double RingRotateCenterZ = 0.0;

	public double BraceletRotateCenterX = 0.0;

	public double BraceletRotateCenterZ = 0.0;

	public double SpindleSpeed = 15000.0;

	public double EngravingSpeed = 3000.0;

	public double DiamondCutSpeed1 = 3000.0;

	public double DiamondCutSpeed2 = 3000.0;

	public double LatheSpeed = 3000.0;

	public double LaserSpeed = 3000.0;

	public bool TangentCalculationMode = false;

	public bool SlideEnable = true;

	public double StepSafeDistance = 10.0;

	public bool StepZAbsoluteMode = true;

	public CamMoveUpType CamCoreMoveUpType = CamMoveUpType.Incremental;

	public double ExtraDepth = 0.0;

	public bool ResetCAxis = false;

	public int Stiffness = 5;

	public bool Mirror = false;

	public bool ConvexMachiningFor3Axis = false;

	public bool SyncMode = false;

	public double SyncRatio = 1.0;

	public bool ReadSurfaceEllipse = false;

	public bool BAxisFor3Axis = false;

	public jewelMode()
	{
	}

	public jewelMode(jewelMode data)
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
