using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMillingAnalyzePars : buSerilization5
{
	public double AxisAPosition = 90.0;

	public bool Apply90DegreeToMillingHead = true;

	public static List<string> Captions = new List<string>();

	public marbleMillingAnalyzePars()
	{
	}

	public marbleMillingAnalyzePars(marbleMillingAnalyzePars data)
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

	public static void Copy(marbleMillingAnalyzePars Source, ref marbleMillingAnalyzePars Target)
	{
		Target = new marbleMillingAnalyzePars(Source);
	}

	public override string ToString()
	{
		return "AxisAPosition : " + AxisAPosition;
	}
}
