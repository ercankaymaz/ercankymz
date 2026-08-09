using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class SelectionArg : buSerilization
{
	public bool SmartSelection = true;

	public bool OnlyECamEntities = false;

	public SelectionArg()
	{
	}

	public SelectionArg(SelectionArg data)
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
}
