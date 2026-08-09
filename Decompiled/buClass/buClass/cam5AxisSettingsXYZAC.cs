using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class cam5AxisSettingsXYZAC : buSerilization
{
	public double ZUpCLimitAngle = 20.0;

	public double ContinousMoveCLimitAngle = 5.0;

	public static List<string> Captions = new List<string>();

	public cam5AxisSettingsXYZAC()
	{
	}

	public cam5AxisSettingsXYZAC(cam5AxisSettingsXYZAC distance)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(distance, ref CopiedClass);
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
		return "ZUpCLimitAngle: " + ZUpCLimitAngle + " , ContinousMoveCLimitAngle: " + ContinousMoveCLimitAngle;
	}
}
