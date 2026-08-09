using System.Reflection;

namespace buEyeBaseVer5;

public class MeshToSurfacePointsSettings : buSerilization5
{
	public double AMinLimit = -360.0;

	public double AMaxLimit = 360.0;

	public double BMinLimit = -360.0;

	public double BMaxLimit = 360.0;

	public double CMinLimit = -360.0;

	public double CMaxLimit = 360.0;

	public bool FindMaxX = false;

	public bool FindMaxY = false;

	public bool FindMaxZ = true;

	public double TangentAngleFromNormal = -90.0;

	public bool isFirst = false;

	public bool isFirstEachSegment = false;

	public bool isLast = false;

	public bool isLastEachSegment = false;

	public bool isOutside = true;

	public bool isInside = true;

	public bool CheckIsClosedContour = true;

	public double SurfaceNormalLength = 30.0;

	public double LeadInDistance = 100.0;

	public double SafeDistance = 80.0;

	public double ToolOffset = 0.0;

	public double ExtraDepth = 0.0;

	public double BoxBoundOffset = 0.0;

	public double RotationStep = 1.0;

	public double RotationStartAngle = 0.0;

	public double RotationSweepAngle = 360.0;

	public double MaxChangeDistanceFormPrevious = 10.0;

	public double FindCorrectPosMoveStep = 0.1;

	public int FindCorrectPosIterationCount = 10;

	public MeshToSurfacePointsSettings()
	{
	}

	public MeshToSurfacePointsSettings(MeshToSurfacePointsSettings Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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
}
