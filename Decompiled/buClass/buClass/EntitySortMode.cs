using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class EntitySortMode : buSerilization
{
	public bool AngleLimitation = false;

	public double MinAngle = 0.0;

	public double MaxAngle = 360.0;

	public bool Enable = false;

	public EntitySortMode()
	{
	}

	public EntitySortMode(EntitySortMode data)
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
