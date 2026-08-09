using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class PointAndIndex : buSerilization5
{
	public Point3D refPoint = new Point3D();

	public int Index = -1;

	public double DomainValue = 0.0;

	public PointAndIndex()
	{
	}

	public PointAndIndex(Point3D refPnt, int Indx)
	{
		refPoint = new Point3D(refPnt.X, refPnt.Y, refPnt.Z);
		Index = Indx;
	}

	public PointAndIndex(Point3D refPnt, int Indx, double domainVal)
	{
		refPoint = new Point3D(refPnt.X, refPnt.Y, refPnt.Z);
		Index = Indx;
		DomainValue = domainVal;
	}

	public PointAndIndex(PointAndIndex data)
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
		return "X: " + refPoint.X.ToString("f3") + " Y: " + refPoint.Y.ToString("f3") + " Index: " + Index.ToString("");
	}
}
