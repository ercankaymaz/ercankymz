using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class SlotDrawVar : buSerilization
{
	public double Length = 40.0;

	public double Radius = 10.0;

	public double Angle = 0.0;

	public static List<string> Captions = new List<string>();

	public SlotDrawVar()
	{
	}

	public SlotDrawVar(SlotDrawVar data)
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

	public SlotDrawVar(double length, double height)
	{
		Length = length;
		Radius = height;
	}

	public override string ToString()
	{
		return "L: " + Length + " , H: " + Radius;
	}
}
