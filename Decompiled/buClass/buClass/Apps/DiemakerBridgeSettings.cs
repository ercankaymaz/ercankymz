using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerBridgeSettings : buSerilization
{
	public double UsageOfBridgeToolWidth = 75.0;

	public DiemakerBridgeSettings()
	{
	}

	public DiemakerBridgeSettings(DiemakerBridgeSettings data)
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

	public static void Copy(DiemakerBridgeSettings Source, ref DiemakerBridgeSettings Target)
	{
		Target = new DiemakerBridgeSettings(Source);
	}

	public override string ToString()
	{
		return "Tool Width % : " + UsageOfBridgeToolWidth;
	}
}
