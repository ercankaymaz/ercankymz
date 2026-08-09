using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendXOffset : buSerilization
{
	public double Angle;

	public double Constant;

	public static List<string> Captions = new List<string>();

	public BendXOffset()
	{
	}

	public BendXOffset(BendXOffset data)
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

	public override string ToString()
	{
		return "Angle: " + Angle.ToString("f2") + " -  Constant: " + Constant.ToString("f4");
	}
}
