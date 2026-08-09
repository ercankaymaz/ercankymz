using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class GCodeConverter : buSerilization5
{
	public double XOffset = 0.0;

	public double YOffset = 0.0;

	public double ZOffset = 0.0;

	public double AOffset = 0.0;

	public double BOffset = 0.0;

	public double COffset = 0.0;

	public double FOffset = 0.0;

	public double SOffset = 0.0;

	public double XMultiply = 1.0;

	public double YMultiply = 1.0;

	public double ZMultiply = 1.0;

	public double AMultiply = 1.0;

	public double BMultiply = 1.0;

	public double CMultiply = 1.0;

	public double FMultiply = 1.0;

	public double SMultiply = 1.0;

	public double FilterLength = 0.0;

	public static List<string> Captions = new List<string>();

	public GCodeConverter()
	{
	}

	public GCodeConverter(GCodeConverter distance)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "XOffset: " + XOffset + " , YOffset: " + YOffset;
	}
}
