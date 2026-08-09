using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolPanelSetting : buSerilization
{
	public bool ShowToolName = true;

	public bool ShowToolType = true;

	public bool ShowSpindleSpeed = true;

	public bool ShowFeed = true;

	public bool ShowSafeDistance = true;

	public bool ShowPurpose = true;

	public bool ShowLength = true;

	public bool ShowDiameter = true;

	public bool ShowToolInfoArea = true;

	public bool ShowToolButtonArea = true;

	public bool ShowToolPreviewArea = true;

	public static List<string> Captions = new List<string>();

	public ToolPanelSetting()
	{
	}

	public ToolPanelSetting(ToolPanelSetting info)
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
		return "Name: " + ShowToolName;
	}
}
