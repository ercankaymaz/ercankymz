using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DoorSettings : buSerilization5
{
	public bool ShowOperationButton = false;

	public double ZDownOneTimeLimit = 7.0;

	public bool GoFirstXYZSameTime = true;

	public Color colorPanel = Color.Tan;

	public Color colorOperation = Color.Blue;

	public Color colorOperationDisable = Color.DarkGray;

	public bool UseAngles = false;

	public DoorSettings()
	{
	}

	public DoorSettings(DoorSettings data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
