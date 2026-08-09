using System.Collections.Generic;
using System.Runtime.CompilerServices;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buLinearPathCam : LinearPath
{
	[CompilerGenerated]
	private double double_0 = 200.0;

	[CompilerGenerated]
	private CamMoveType camMoveType_0 = CamMoveType.G0;

	[CompilerGenerated]
	private CamLinkType camLinkType_0 = CamLinkType.NotALink;

	[CompilerGenerated]
	private bool bool_0 = false;

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

	public CamLinkType LinkType
	{
		[CompilerGenerated]
		get
		{
			return camLinkType_0;
		}
		[CompilerGenerated]
		set
		{
			camLinkType_0 = value;
		}
	}

	public bool isLink
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

	public buLinearPathCam(LinearPath another)
		: base(another)
	{
		if (another is buLinearPathCam)
		{
			MoveType = ((buLinearPathCam)another).MoveType;
			DirArrowDistances = ((buLinearPathCam)another).DirArrowDistances;
			CamID = ((buLinearPathCam)another).CamID;
			isLink = ((buLinearPathCam)another).isLink;
			LinkType = ((buLinearPathCam)another).LinkType;
		}
	}

	public buLinearPathCam(List<Point3D> points)
		: base(points)
	{
	}

	public buLinearPathCam(params Point3D[] points)
		: base(points)
	{
	}

	public buLinearPathCam(Point2D min, Point2D max)
		: base(min, max)
	{
	}

	public buLinearPathCam(Plane sketchPlane, params Point2D[] points)
		: base(sketchPlane, points)
	{
	}

	public buLinearPathCam(double width, double height)
		: base(width, height)
	{
	}

	public buLinearPathCam(Plane plane, Point2D min, Point2D max)
		: base(plane, min, max)
	{
	}

	public buLinearPathCam(double x, double y, double width, double height)
		: base(x, y, width, height)
	{
	}

	public buLinearPathCam(Plane plane, double x, double y, double width, double height)
		: base(plane, x, y, width, height)
	{
	}

	public override string ToString()
	{
		string text = "LPCam : " + base.StartPoint.ToString() + " - " + base.EndPoint.ToString() + " - " + MoveType.ToString() + " - Cnt: " + Vertices.Length;
		if (isLink)
		{
			text = text + " Link: " + LinkType;
		}
		return text;
	}
}
