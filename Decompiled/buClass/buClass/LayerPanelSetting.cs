using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class LayerPanelSetting : buSerilization
{
	public bool ShowLayerName = true;

	public bool ShowLayerColor = true;

	public bool ShowLayerThickness = true;

	public bool ShowLayerInfoArea = true;

	public bool ShowLayerButtonArea = true;

	public static List<string> Captions = new List<string>();

	public LayerPanelSetting()
	{
	}

	public LayerPanelSetting(LayerPanelSetting info)
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
		return "Name: " + ShowLayerName;
	}
}
