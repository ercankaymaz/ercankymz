using System;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleDrillType : buSerilization5
{
	public Point3D pntCenter = new Point3D();

	public double Diameter = 10.0;

	public double Depth = 12.0;

	public marbleDrillType()
	{
	}

	public marbleDrillType(marbleDrillType data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		return "Diameter: " + Diameter + " - Depth: " + Depth + " - Center: " + pntCenter.ToString();
	}
}
