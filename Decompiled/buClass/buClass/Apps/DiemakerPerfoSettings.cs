using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerPerfoSettings : buSerilization
{
	public double UsageOfPerfoToolWidth = 75.0;

	public static List<string> Captions = new List<string>();

	public DiemakerPerfoSettings()
	{
	}

	public DiemakerPerfoSettings(DiemakerPerfoSettings data)
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

	public static void Copy(DiemakerPerfoSettings Source, ref DiemakerPerfoSettings Target)
	{
		Target = new DiemakerPerfoSettings(Source);
	}

	public override string ToString()
	{
		return "Tool Width % : " + UsageOfPerfoToolWidth;
	}
}
