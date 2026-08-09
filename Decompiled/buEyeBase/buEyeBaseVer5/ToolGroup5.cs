using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class ToolGroup5 : buSerilization5
{
	public List<ToolBase5> Tools = new List<ToolBase5>();

	public string GroupName = "Tools";

	public ToolGroup5()
	{
	}

	public ToolGroup5(ToolGroup5 Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		Tools.Clear();
		for (int j = 0; j <= Data.Tools.Count - 1; j++)
		{
			Tools.Add(new ToolBase5(Data.Tools[j]));
		}
	}
}
