using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingTempVars : buSerilization5
{
	public string layerSheet = "Panel";

	public string layerPart = "Operation";

	public string layerWireframe = "General";

	public buNestingTempVars()
	{
	}

	public buNestingTempVars(buNestingTempVars data)
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
