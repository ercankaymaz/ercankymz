using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

public class jewelPositioningSettings : buSerilization
{
	public double XStartSpace = 0.0;

	public double XEndSpace = 0.0;

	public double YSpace = 0.0;

	public static List<string> Captions = new List<string>();

	public jewelPositioningSettings()
	{
	}

	public jewelPositioningSettings(jewelPositioningSettings data)
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
