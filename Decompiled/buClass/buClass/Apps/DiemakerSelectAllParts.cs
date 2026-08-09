using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerSelectAllParts : buSerilization
{
	public double PtValue = 2.0;

	public bool SelectAll = true;

	public bool SelectVertical = true;

	public bool SelectHorizontal = true;

	public bool SelectAngle = true;

	public bool SelectHeight = true;

	public bool SelectNegative = true;

	public static List<string> Captions = new List<string>();

	public DiemakerSelectAllParts()
	{
	}

	public DiemakerSelectAllParts(DiemakerSelectAllParts data)
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

	public static void Copy(DiemakerSelectAllParts Source, ref DiemakerSelectAllParts Target)
	{
		Target = new DiemakerSelectAllParts(Source);
	}

	public override string ToString()
	{
		return "PtValue : " + PtValue + " - SelectAll : " + SelectAll;
	}
}
