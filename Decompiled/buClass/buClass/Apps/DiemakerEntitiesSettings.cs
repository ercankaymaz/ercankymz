using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerEntitiesSettings : buSerilization
{
	public double MinEntitiyLength = 0.15;

	public static List<string> Captions = new List<string>();

	public DiemakerEntitiesSettings()
	{
	}

	public DiemakerEntitiesSettings(DiemakerEntitiesSettings data)
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

	public static void Copy(DiemakerEntitiesSettings Source, ref DiemakerEntitiesSettings Target)
	{
		Target = new DiemakerEntitiesSettings(Source);
	}

	public override string ToString()
	{
		return "MinEntitiyLength : " + MinEntitiyLength;
	}
}
