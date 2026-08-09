using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

public class jewelSettings : buSerilization
{
	public bool ShowCamDataPageWhileCamOperation = false;

	public bool UseCommentCharOnSurfaceFollow = false;

	public static List<string> Captions = new List<string>();

	public jewelSettings()
	{
	}

	public jewelSettings(jewelSettings data)
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
