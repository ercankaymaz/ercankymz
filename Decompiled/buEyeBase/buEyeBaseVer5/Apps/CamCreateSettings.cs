using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class CamCreateSettings : buSerilization5
{
	public bool DrawAll = false;

	public bool CamCreate = false;

	public int SelectedSheet = -1;

	public CamCreateSettings()
	{
	}

	public CamCreateSettings(CamCreateSettings data)
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
