using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSetAngle : buSerilization5
{
	public double Angle = 0.0;

	public static List<string> Captions = new List<string>();

	public marbleSetAngle()
	{
	}

	public marbleSetAngle(marbleSetAngle data)
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
