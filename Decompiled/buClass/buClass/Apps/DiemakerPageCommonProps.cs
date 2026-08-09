using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerPageCommonProps : buSerilization
{
	public bool SplitJobEnable = false;

	public int SplitFrom = 0;

	public int SplitTo = 0;

	public int MachineIndex = 0;

	public DiemakerPageCommonProps()
	{
	}

	public DiemakerPageCommonProps(DiemakerPageCommonProps data)
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
		return "Split : " + SplitJobEnable + " - SplitFrom : " + SplitFrom + " - SplitTo : " + SplitTo + " - MachineIndex : " + MachineIndex;
	}
}
