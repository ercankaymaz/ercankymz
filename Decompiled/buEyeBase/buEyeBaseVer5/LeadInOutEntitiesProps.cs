using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5;

[Serializable]
public class LeadInOutEntitiesProps : buSerilization5
{
	public buEntity RefEntity = new buEntity();

	public double PointTangentAngle = 0.0;

	public static List<string> Captions = new List<string>();

	public LeadInOutEntitiesProps()
	{
	}

	public LeadInOutEntitiesProps(LeadInOutEntitiesProps data)
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
