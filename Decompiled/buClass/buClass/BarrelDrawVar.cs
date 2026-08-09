using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class BarrelDrawVar : buSerilization
{
	public double HeadRadius = 19.0;

	public double TaleRadius = 10.0;

	public double Length = 40.0;

	public double Heigth = 10.0;

	public double Angle = 0.0;

	public bool Reverse = false;

	public static List<string> Captions = new List<string>();

	public BarrelDrawVar()
	{
	}

	public BarrelDrawVar(BarrelDrawVar data)
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

	public BarrelDrawVar(double headradius, double taleradius, double length, double height, bool reverse, WorkPlane plane)
	{
		HeadRadius = headradius;
		TaleRadius = taleradius;
		Length = length;
		Heigth = height;
		Reverse = reverse;
	}

	public override string ToString()
	{
		return "Head Rad: " + HeadRadius + " , Tale Rad: " + TaleRadius;
	}
}
