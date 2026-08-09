using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileArray : buSerilization
{
	public int CircularCount = 1;

	public int LineerCount = 1;

	public double CircularAngle = 45.0;

	public double LineerDistance = 100.0;

	public bool CircularEnable = false;

	public bool LineerEnable = false;

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
				string name = fields[i].Name;
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
