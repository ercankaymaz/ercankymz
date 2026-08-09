using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CamPanelSetting : buSerilization
{
	public bool ShowCamName = true;

	public bool ShowTool = true;

	public bool ShowCamType = true;

	public bool ShowProcessTime = true;

	public bool ShowTotalLength = true;

	public bool ShowCamInfoArea = true;

	public bool ShowCamButtonArea = true;

	public bool ShowCamSimulationArea = true;

	public static List<string> Captions = new List<string>();

	public CamPanelSetting()
	{
	}

	public CamPanelSetting(CamPanelSetting info)
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
		return "Name: " + ShowCamName;
	}
}
