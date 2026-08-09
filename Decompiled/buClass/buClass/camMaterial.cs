using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camMaterial : buSerilization
{
	public double Thickness = 2.0;

	public double StartZ = 0.0;

	public Pnt3D MaxPoint = new Pnt3D();

	public Pnt3D MinPoint = new Pnt3D();

	public static List<string> Captions = new List<string>();

	public camMaterial()
	{
	}

	public camMaterial(camMaterial distance)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(distance, ref CopiedClass);
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
		return "Thickness: " + Thickness + " , StartZ: " + StartZ;
	}
}
