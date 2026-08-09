using System;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class PointWithIndex : buSerilization5
{
	public Point3D Pnt = new Point3D();

	public int Index = -1;

	public PointWithIndex()
	{
	}

	public PointWithIndex(PointWithIndex data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		Pnt = buVector5.ToPoint3D(data.Pnt);
	}

	public override string ToString()
	{
		return "Index: " + Index + " - Pnt: " + Pnt.ToString();
	}
}
