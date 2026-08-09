using System.Runtime.CompilerServices;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buLineCam : Line
{
	[CompilerGenerated]
	private double double_0 = 200.0;

	[CompilerGenerated]
	private CamMoveType camMoveType_0 = CamMoveType.G0;

	[CompilerGenerated]
	private int int_0 = -1;

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

	public buLineCam(Line another)
		: base(another)
	{
		if (another is buLineCam)
		{
			MoveType = ((buLineCam)another).MoveType;
			DirArrowDistances = ((buLineCam)another).DirArrowDistances;
			CamID = ((buLineCam)another).CamID;
		}
	}

	public buLineCam(Segment2D seg)
		: base(seg)
	{
	}

	public buLineCam(Segment3D seg)
		: base(seg)
	{
	}

	public buLineCam(Point3D start, Point3D end)
		: base(start, end)
	{
	}

	public buLineCam(Plane sketchPlane, Point2D startPoint, Point2D endPoint)
		: base(sketchPlane, startPoint, endPoint)
	{
	}

	public buLineCam(double x1, double y1, double x2, double y2)
		: base(x1, y1, x2, y2)
	{
	}

	public buLineCam(Plane sketchPlane, double x1, double y1, double x2, double y2)
		: base(sketchPlane, x1, y1, x2, y2)
	{
	}

	public buLineCam(double x1, double y1, double z1, double x2, double y2, double z2)
		: base(x1, y1, z1, x2, y2, z2)
	{
	}

	public override string ToString()
	{
		return "LineCam : " + base.StartPoint.ToString() + " - " + base.EndPoint.ToString() + " - " + MoveType;
	}
}
