using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolGroup : buSerilization
{
	public List<ToolBase> Tools = new List<ToolBase>();

	public string GroupName = "Tools";

	public ToolGroup()
	{
	}

	public ToolGroup(ToolGroup Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		Tools.Clear();
		for (int j = 0; j <= Data.Tools.Count - 1; j++)
		{
			Tools.Add(new ToolBase(Data.Tools[j]));
		}
	}
}
