using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileArray : buSerilization5
{
	public bool CircularEnable = false;

	public int CircularCount = 1;

	public double CircularAngle = 45.0;

	public bool LineerEnable = false;

	public int LineerXCount = 1;

	public double LineerXDistance = 100.0;

	public int LineerYCount = 1;

	public double LineerYDistance = 100.0;

	public ProfileArray()
	{
	}

	public ProfileArray(ProfileArray data)
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

	public override string ToString()
	{
		return "Lineer :" + LineerEnable + " , Circular : " + CircularEnable;
	}
}
