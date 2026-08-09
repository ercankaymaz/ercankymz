using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class SortCamData : buSerilization5
{
	public ToolBase5 Tool = new ToolBase5();

	public SortCamData()
	{
	}

	public SortCamData(SortCamData data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		Tool = new ToolBase5(data.Tool);
	}
}
