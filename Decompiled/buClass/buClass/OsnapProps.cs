using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class OsnapProps : buSerilization
{
	public bool Snap = false;

	public bool Osnap = false;

	public bool Ortho = false;

	public bool Track = false;

	public bool Over = false;

	public bool Alingment = false;

	public bool OrthoAuto = false;

	public bool LimitedDistance = false;

	public double LimitedValue = 5.0;

	public double CatchResolution = 10.0;

	public double OverResolution = 5.0;

	public double OrthoAutoAngle = 3.0;

	public double TrackPerpendicularAngleLimit = 3.0;

	public Vec3D SnapDistance = new Vec3D(50.0, 50.0, 0.0);

	public bool OsnapPoint = true;

	public bool OsnapOnlyStartEndPoint = true;

	public bool OsnapMiddle = false;

	public bool OsnapOutside = false;

	public bool OsnapIntersection = false;

	public bool OsnapVertice = false;

	public bool OsnapCenter = true;

	public bool OsnapBoxSize = false;

	public bool OsnapZeroPoint = true;

	public bool OsnapControlPoints = true;

	public bool OsnapBrep = false;

	public bool OsnapEntities = true;

	public int TrackCatchTime = 1000;

	public bool ConstantPlaneEnable = true;

	public double ConstantPlaneHeight = 0.0;

	public static List<string> Captions = new List<string>();

	public OsnapProps()
	{
	}

	public OsnapProps(OsnapProps data)
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
		return "Osnap : " + Osnap + " ;  Snap : " + Snap;
	}
}
