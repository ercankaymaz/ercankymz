using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class PagePanelSetting : buSerilization
{
	public bool ShowPageName = true;

	public bool ShowSceneName = true;

	public bool ShowEntityCount = true;

	public bool ShowPlane = true;

	public bool ShowPageInfoArea = true;

	public bool ShowPageButtonArea = true;

	public static List<string> Captions = new List<string>();

	public PagePanelSetting()
	{
	}

	public PagePanelSetting(PagePanelSetting info)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(info, ref CopiedClass);
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
		return "Name: " + ShowPageName;
	}
}
