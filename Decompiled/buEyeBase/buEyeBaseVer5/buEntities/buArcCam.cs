using System.Runtime.CompilerServices;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buArcCam : Arc
{
	[CompilerGenerated]
	private double double_0 = 200.0;

	[CompilerGenerated]
	private CamMoveType camMoveType_0 = CamMoveType.G0;

	[CompilerGenerated]
	private int int_0 = -1;

	[CompilerGenerated]
	private bool bool_0 = false;

	public double DirArrowDistances
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		set
		{
			double_0 = value;
		}
	}

	public CamMoveType MoveType
	{
		[CompilerGenerated]
		get
		{
			return camMoveType_0;
		}
		[CompilerGenerated]
		set
		{
			camMoveType_0 = value;
		}
	}

	public int CamID
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public bool isReverse
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public buArcCam(Arc another)
		: base(another)
	{
		if (another is buArcCam)
		{
			MoveType = ((buArcCam)another).MoveType;
			DirArrowDistances = ((buArcCam)another).DirArrowDistances;
			CamID = ((buArcCam)another).CamID;
			isReverse = ((buArcCam)another).isReverse;
		}
	}

	public buArcCam(Point3D center, double radius, double angleInRadians)
		: base(center, radius, angleInRadians)
	{
	}

	public buArcCam(Point3D center, Point3D start, Point3D end)
		: base(center, start, end)
	{
	}

	public buArcCam(Plane arcPlane, Point3D center, double radius, double angleInRadians)
		: base(arcPlane, center, radius, angleInRadians)
	{
	}

	public buArcCam(Point3D center, double radius, double startAngleInRadians, double endAngleInRadians)
		: base(center, radius, startAngleInRadians, endAngleInRadians)
	{
	}

	public buArcCam(Plane arcPlane, Point2D center, Point2D start, Point2D end)
		: base(arcPlane, center, start, end)
	{
	}

	public buArcCam(Point3D first, Point3D second, Point3D third, bool flip)
		: base(first, second, third, flip)
	{
	}

	public buArcCam(Plane arcPlane, Point3D center, double radius, double startAngleInRadians, double endAngleInRadians)
		: base(arcPlane, center, radius, startAngleInRadians, endAngleInRadians)
	{
	}

	public buArcCam(Plane arcPlane, Point2D center, double radius, double startAngleInRadians, double endAngleInRadians)
		: base(arcPlane, center, radius, startAngleInRadians, endAngleInRadians)
	{
	}

	public buArcCam(Plane arcPlane, Point2D first, Point2D second, Point2D third, bool flip)
		: base(arcPlane, first, second, third, flip)
	{
	}

	public buArcCam(double x, double y, double z, double radius, double startAngleInRadians, double endAngleInRadians)
		: base(x, y, z, radius, startAngleInRadians, endAngleInRadians)
	{
	}

	public buArcCam(Plane arcPlane, Point3D center, double radius, Point3D start, Point3D end, bool flip)
		: base(arcPlane, center, radius, start, end, flip)
	{
	}

	public override string ToString()
	{
		return "ArcCam : " + StartPoint.ToString() + " - " + EndPoint.ToString() + " - " + MoveType;
	}
}
