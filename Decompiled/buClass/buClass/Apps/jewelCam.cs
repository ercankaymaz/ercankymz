using System.Reflection;

namespace buClass.Apps;

public class jewelCam : buSerilization
{
	public double AirZ = 50.0;

	public double SafeAbsZ = 10.0;

	public double SafeIncZ = 10.0;

	public double EkstraZOffset = 0.0;

	public double BOffset = 0.0;

	public double ConvexOutBOffset = -90.0;

	public double ConcaveInBOffset = -270.0;

	public double RigthToLeftZOffset = 0.0;

	public double LeftToRightZOffset = 0.0;

	public double COffset = 0.0;

	public double FeedSpeed = 100.0;

	public double PlungeSpeed = 10.0;

	public double Depth = 0.0;

	public double Leave5AxisSpeed = 20.0;

	public bool YAxisInDegree = true;

	public bool G0CalculationWithFollowingSurfaceEnable = true;

	public double G0CalculationWithFollowingSurfaceZOffset = 2.0;

	public double G0CalculationWithFollowingSurfaceSpeed = 2000.0;

	public double GCodeFileZProcessLimit = 0.0;

	public double ConvexConcaveShapeResolution = 0.1;

	public double CamDevideLineLength = 0.5;

	public double CamDevidePolylineLength = 0.5;

	public double CamDevideCircleLength = 0.2;

	public double CamDevideArcLength = 0.2;

	public double CamDevideSplineLength = 0.5;

	public double CamDevideOtherLength = 0.5;

	public int CamDevideCircularEntityCountLimit = 5;

	public double CamMinFilterLength = 0.001;

	public double CamFlatSurfReadMinFilterLength = 0.7;

	public double DevideMinLimit = 2.0;

	public bool CreatTCode = true;

	public bool MirrorCalculation = false;

	public double RotateCenterX = 0.0;

	public double RotateCenterZ = 0.0;

	public short Mode = 0;

	public bool Enable5AxisCalculation = true;

	public bool ZSafeAbsoluteMode = true;

	public string JewelName = "";

	public bool MoveToFrame = true;

	public double G0FollowSurfaceResolution = 0.5;

	public bool PolylineToSpline = false;

	public bool AngularMode = false;

	public double AngluarModeBAngle = 0.0;

	public bool FlatSheetMode = false;

	public bool SurfaceReadMode = false;

	public bool TriangularCut = false;

	public bool BValueEffectedByZDepth = false;

	public double BSplineRatio = 0.2;

	public double EllipseMajorMinorRotationOffset = 90.0;

	public double EllipseModeEllipseToPolylineResolution = 0.02;

	public double EllipsePreCalculateResolution = 0.01;

	public bool EllipseModeUseYValues = false;

	public double SortStartX = 0.0;

	public double SortStartY = 0.0;

	public bool SortStartPointEnable = false;

	public jewelCam()
	{
	}

	public jewelCam(jewelCam data)
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

	public override string ToString()
	{
		return "Feed: " + FeedSpeed + "  -  ZOffset: " + EkstraZOffset;
	}
}
