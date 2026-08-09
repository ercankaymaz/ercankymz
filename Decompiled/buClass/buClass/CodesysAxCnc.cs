using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxCnc : buSerilization
{
	public double cncMaxAccDec = 1000.0;

	public double cncMaxFeed = 100.0;

	public double cncMaxDifferance = 0.01;

	public bool cncIncludePathSettings = false;

	public bool cncStrictlyHoldAccDecABC = false;

	public static List<string> Captions = new List<string>();

	public CodesysAxCnc()
	{
	}

	public CodesysAxCnc(CodesysAxCnc data)
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
		return "cncMaxAccDec: " + cncMaxAccDec;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + cncMaxAccDec + ";" + cncMaxFeed + ";" + cncMaxDifferance;
		return text + ";" + buSerilization.BoolToString(cncIncludePathSettings) + ";" + buSerilization.BoolToString(cncStrictlyHoldAccDecABC);
	}
}
