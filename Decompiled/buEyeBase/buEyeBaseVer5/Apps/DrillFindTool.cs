using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillFindTool : buSerilization5
{
	public int TNo1 = 0;

	public int TNo2 = 0;

	public int TNo3 = 0;

	public int TNo4 = 0;

	public int TNo5 = 0;

	public int TNo6 = 0;

	public int TNo7 = 0;

	public int TNo8 = 0;

	public int TNo9 = 0;

	public int TNo10 = 0;

	public int TNo11 = 0;

	public int TNo12 = 0;

	public DrillFindTool()
	{
	}

	public DrillFindTool(DrillFindTool data)
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
