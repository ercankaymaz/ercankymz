using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class PointAndAngleRange : buSerilization5
{
	public Point3D refPoint = new Point3D();

	public double AngleMin = 0.0;

	public double AngleMax = 0.0;

	public int Index = -1;

	public PointAndAngleRange()
	{
	}

	public PointAndAngleRange(Point3D pntRef, double AngMin, double AngMax, int Indx)
	{
		Index = Indx;
		AngleMax = AngMax;
		AngleMin = AngMin;
		refPoint = new Point3D(pntRef.X, pntRef.Y, pntRef.Z);
	}

	public PointAndAngleRange(PointAndAngleRange data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		refPoint = new Point3D(data.refPoint.X, data.refPoint.Y, data.refPoint.Z);
	}

	public override string ToString()
	{
		return "X: " + refPoint.X.ToString("f3") + " Y: " + refPoint.Y.ToString("f3") + " Min: " + AngleMin.ToString("f1") + " Max: " + AngleMax.ToString("f1") + " Index: " + Index.ToString("");
	}
}
