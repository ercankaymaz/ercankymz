using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingNickTool : ToolBase
{
	public bool Pt1 = false;

	public bool Pt2 = false;

	public bool Pt3 = false;

	public bool Pt4 = false;

	public double Width = 4.5;

	public BendingNickTool()
	{
	}

	public BendingNickTool(BendingNickTool data)
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

	public override string ToString()
	{
		return "No:" + Data.No + " ; " + Data.Name;
	}
}
