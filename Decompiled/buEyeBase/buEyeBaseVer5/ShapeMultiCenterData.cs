using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class ShapeMultiCenterData : buSerilization5
{
	public Point3D Center = new Point3D();

	public double Diameter = 0.0;

	public ShapeMultiCenterData()
	{
	}

	public ShapeMultiCenterData(Point3D center, double dia)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		Diameter = dia;
	}

	public ShapeMultiCenterData(ShapeMultiCenterData data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "Diameter :" + Diameter + " - Center :" + Center.ToString();
	}
}
