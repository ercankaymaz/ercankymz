using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class MostClosestPointOption : buSerilization5
{
	public bool UseStartEndPointCompositeCurve = true;

	public double Resolution = 0.01;

	public MostClosestPointOption()
	{
	}

	public MostClosestPointOption(MostClosestPointOption data)
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
