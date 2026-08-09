using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class screenInfo : buSerilization5
{
	public Point3D pntMin = new Point3D();

	public Point3D pntMax = new Point3D();

	public Point3D pntCurrent = new Point3D();

	public Length3D ScreenSize = new Length3D();

	public screenInfo()
	{
	}

	public screenInfo(screenInfo Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
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
}
