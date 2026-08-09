using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class BreakEventVar : buSerilization
{
	public BreakEntityType Type = BreakEntityType.ByClick;

	public double Length = 4.0;

	public double Count = 5.0;

	public static List<string> Captions = new List<string>();

	public BreakEventVar()
	{
	}

	public BreakEventVar(BreakEventVar data)
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
}
