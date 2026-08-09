using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelEntityData : buSerilization5
{
	public int Depth = 0;

	public int XIndex = -1;

	public int YIndex = -1;

	public string Note = "";

	public int NodeID = -1;

	public nestPanelNodeType NodeType = nestPanelNodeType.Assembly;

	public PanelEntityData()
	{
	}

	public PanelEntityData(PanelEntityData data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
