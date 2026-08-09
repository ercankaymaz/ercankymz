using System.Collections.Generic;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buLinearPathArrow : LinearPath
{
	[CompilerGenerated]
	private double double_0 = 0.0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0 = -1;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private int int_1 = -1;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private Point3D point3D_0;

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

	public string Tags
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
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

	public string SceneName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string EntityName
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public string ActionName
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public int GroupIdIndex
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int RefEntity
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public Point3D infoBasePoint
	{
		[CompilerGenerated]
		get
		{
			return point3D_0;
		}
		[CompilerGenerated]
		set
		{
			point3D_0 = value;
		}
	}

	public buLinearPathArrow(LinearPath another)
		: base(another)
	{
		if (another is buLinearPathArrow)
		{
			Tags = ((buLinearPathArrow)another).Tags;
			DirArrowDistances = ((buLinearPathArrow)another).DirArrowDistances;
			CamID = ((buLinearPathArrow)another).CamID;
			SceneName = ((buLinearPathArrow)another).SceneName;
			EntityName = ((buLinearPathArrow)another).EntityName;
			ActionName = ((buLinearPathArrow)another).ActionName;
			GroupIdIndex = ((buLinearPathArrow)another).GroupIdIndex;
			RefEntity = ((buLinearPathArrow)another).RefEntity;
			if (((buLinearPathArrow)another).infoBasePoint != null)
			{
				infoBasePoint = (Point3D)((buLinearPathArrow)another).infoBasePoint.Clone();
			}
		}
	}

	public buLinearPathArrow(List<Point3D> points)
		: base(points)
	{
	}

	public buLinearPathArrow(params Point3D[] points)
		: base(points)
	{
	}

	public buLinearPathArrow(Point2D min, Point2D max)
		: base(min, max)
	{
	}

	public buLinearPathArrow(Plane sketchPlane, params Point2D[] points)
		: base(sketchPlane, points)
	{
	}

	public buLinearPathArrow(double width, double height)
		: base(width, height)
	{
	}

	public buLinearPathArrow(Plane plane, Point2D min, Point2D max)
		: base(plane, min, max)
	{
	}

	public buLinearPathArrow(double x, double y, double width, double height)
		: base(x, y, width, height)
	{
	}

	public buLinearPathArrow(Plane plane, double x, double y, double width, double height)
		: base(plane, x, y, width, height)
	{
	}

	public override string ToString()
	{
		return "ArrowLinearPath - S: " + base.StartPoint.ToString() + " - E: " + base.EndPoint.ToString() + " - Ref Ent : " + RefEntity;
	}
}
