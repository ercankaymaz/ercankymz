using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class OffsetEventVar : buSerilization
{
	public double Offset = 2.0;

	public bool DeleteOriginal = false;

	public bool SelectLast = true;

	public int OffsetCount = 1;

	public static List<string> Captions = new List<string>();

	public OffsetEventVar()
	{
	}

	public OffsetEventVar(OffsetEventVar data)
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
