using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxBase : buSerilization
{
	public int baseNo = 0;

	public string baseName = "Axis";

	public string baseChar = "";

	public string baseUnit = "mm";

	public bool baseRotaryAxis = false;

	public bool baseEnable = true;

	public static List<string> Captions = new List<string>();

	public CodesysAxBase()
	{
	}

	public CodesysAxBase(CodesysAxBase data)
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
		return "Name: " + baseName.ToString() + " , Char: " + baseChar.ToString() + " , No: " + baseNo;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + baseNo + ";" + baseName.ToString() + ";" + baseChar.ToString();
		text = text + ";" + baseUnit.ToString();
		return text + ";" + buSerilization.BoolToString(baseRotaryAxis);
	}
}
