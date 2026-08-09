using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

public class jewelUserSettings : buSerilization
{
	public double UserCamDevideLength = 0.5;

	public bool UserZSafeAbsoluteMode = true;

	public bool UserG0CalculationWithFollowingSurfaceEnable = true;

	public double UserG0CalculationWithFollowingSurfaceZOffset = 2.0;

	public static List<string> Captions = new List<string>();

	public jewelUserSettings()
	{
	}

	public jewelUserSettings(jewelUserSettings data)
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
