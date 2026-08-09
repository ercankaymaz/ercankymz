using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class BarrelData : ShapeData
{
	public double HeadRadius = 0.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Rotation = 0.0;

	public Pnt3D HeadCenterPoint = new Pnt3D();

	public static List<string> Captions = new List<string>();

	public BarrelData()
	{
	}

	public BarrelData(BarrelData data)
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
}
