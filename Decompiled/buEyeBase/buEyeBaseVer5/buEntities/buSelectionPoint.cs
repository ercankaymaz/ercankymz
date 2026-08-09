using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buSelectionPoint : Point
{
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
	private bool bool_0;

	[CompilerGenerated]
	private double double_0;

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

	public bool CamSelected
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

	public double OrientationC
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

	public buSelectionPoint(Point another)
		: base(another)
	{
		if (another is buSelectionPoint)
		{
			Tags = ((buSelectionPoint)another).Tags;
			CamID = ((buSelectionPoint)another).CamID;
			SceneName = ((buSelectionPoint)another).SceneName;
			EntityName = ((buSelectionPoint)another).EntityName;
			ActionName = ((buSelectionPoint)another).ActionName;
			GroupIdIndex = ((buSelectionPoint)another).GroupIdIndex;
			CamSelected = ((buSelectionPoint)another).CamSelected;
			OrientationC = ((buSelectionPoint)another).OrientationC;
		}
	}

	public buSelectionPoint(Point2D p)
		: base(p)
	{
	}

	public buSelectionPoint(Point3D p)
		: base(p)
	{
	}

	public buSelectionPoint(double x, double y)
		: base(x, y)
	{
	}

	public buSelectionPoint(Point2D p, float size)
		: base(p, size)
	{
	}

	public buSelectionPoint(Point3D p, float size)
		: base(p, size)
	{
	}

	public buSelectionPoint(Plane sketchPlane, Point2D p)
		: base(sketchPlane, p)
	{
	}

	public buSelectionPoint(double x, double y, double z)
		: base(x, y, z)
	{
	}

	public buSelectionPoint(Plane sketchPlane, double x, double y)
		: base(sketchPlane, x, y)
	{
	}

	public buSelectionPoint(double x, double y, double z, float size)
		: base(x, y, z, size)
	{
	}

	public override string ToString()
	{
		return "Point - S " + base.StartPoint.ToString();
	}
}
