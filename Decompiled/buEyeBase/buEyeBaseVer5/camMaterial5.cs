using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camMaterial5 : buSerilization5
{
	public double Thickness = 2.0;

	public double StartZ = 0.0;

	public Pnt3D MaxPoint = new Pnt3D();

	public Pnt3D MinPoint = new Pnt3D();

	public static List<string> Captions = new List<string>();

	public camMaterial5()
	{
	}

	public camMaterial5(camMaterial5 distance)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(distance, ref CopiedClass);
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
		return "Thickness: " + Thickness + " , StartZ: " + StartZ;
	}
}
