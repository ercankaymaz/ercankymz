using System.Runtime.CompilerServices;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buUpperLineEnt : Line
{
	[CompilerGenerated]
	private double double_0 = 50.0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private double double_2;

	[CompilerGenerated]
	private entitySortDirection entitySortDirection_0 = entitySortDirection.Normal;

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

	public double infoLength
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		set
		{
			double_1 = value;
		}
	}

	public double infoAngle
	{
		[CompilerGenerated]
		get
		{
			return double_2;
		}
		[CompilerGenerated]
		set
		{
			double_2 = value;
		}
	}

	public entitySortDirection sortDirection
	{
		[CompilerGenerated]
		get
		{
			return entitySortDirection_0;
		}
		[CompilerGenerated]
		set
		{
			entitySortDirection_0 = value;
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

	public buUpperLineEnt(Line another)
		: base(another)
	{
		if (another is buUpperLineEnt)
		{
			sortDirection = ((buUpperLineEnt)another).sortDirection;
			Tags = ((buUpperLineEnt)another).Tags;
			DirArrowDistances = ((buUpperLineEnt)another).DirArrowDistances;
			infoAngle = ((buUpperLineEnt)another).infoAngle;
			infoLength = ((buUpperLineEnt)another).infoLength;
			CamID = ((buUpperLineEnt)another).CamID;
			SceneName = ((buUpperLineEnt)another).SceneName;
			EntityName = ((buUpperLineEnt)another).EntityName;
			ActionName = ((buUpperLineEnt)another).ActionName;
			GroupIdIndex = ((buUpperLineEnt)another).GroupIdIndex;
			CamSelected = ((buUpperLineEnt)another).CamSelected;
		}
	}

	public buUpperLineEnt(Segment2D seg)
		: base(seg)
	{
	}

	public buUpperLineEnt(Segment3D seg)
		: base(seg)
	{
	}

	public buUpperLineEnt(Point3D start, Point3D end)
		: base(start, end)
	{
	}

	public buUpperLineEnt(Plane sketchPlane, Point2D startPoint, Point2D endPoint)
		: base(sketchPlane, startPoint, endPoint)
	{
	}

	public buUpperLineEnt(double x1, double y1, double x2, double y2)
		: base(x1, y1, x2, y2)
	{
	}

	public buUpperLineEnt(Plane sketchPlane, double x1, double y1, double x2, double y2)
		: base(sketchPlane, x1, y1, x2, y2)
	{
	}

	public buUpperLineEnt(double x1, double y1, double z1, double x2, double y2, double z2)
		: base(x1, y1, z1, x2, y2, z2)
	{
	}

	public override string ToString()
	{
		return "UpperLine - S : " + base.StartPoint.ToString() + " - E : " + base.EndPoint.ToString() + " - " + sortDirection;
	}
}
