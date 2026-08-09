using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleColoumsPars : buSerilization5
{
	public double ColoumsRadiusTopDistance = 0.0;

	public double ColoumsSafeDistance = 100.0;

	public double ColoumsPlungeFeed = 10.0;

	public double ColoumsCutFeed = 20.0;

	public double ColoumsBaseHeight = 0.0;

	public double ColoumsZStep = 3.0;

	public double ColoumsCRotationStep = 5.0;

	public bool ColoumsZigzagMode = true;

	public static List<string> Captions = new List<string>();

	public marbleColoumsPars()
	{
	}

	public marbleColoumsPars(marbleColoumsPars data)
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

	public static void Copy(marbleColoumsPars Source, ref marbleColoumsPars Target)
	{
		Target = new marbleColoumsPars(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
