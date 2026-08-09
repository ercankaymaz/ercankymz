using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxMisc : buSerilization
{
	public double TestPosition1 = 20.0;

	public double TestPosition2 = 1000.0;

	public double TestWaitTime = 1000.0;

	public double TestReleativePosition = 2500.0;

	public static List<string> Captions = new List<string>();

	public CodesysAxMisc()
	{
	}

	public CodesysAxMisc(CodesysAxMisc data)
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
		return "Pos1 : " + TestPosition1 + " , Pos2: " + TestPosition2;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + TestPosition1 + ";" + TestPosition2 + ";" + TestWaitTime;
		return text + ";" + TestReleativePosition;
	}
}
