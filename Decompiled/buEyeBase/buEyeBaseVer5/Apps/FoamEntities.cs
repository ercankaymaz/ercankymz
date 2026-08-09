using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamEntities : buSerilization5
{
	public buEntitiesGroup GroupEntity = new buEntitiesGroup();

	public FoamEntities()
	{
	}

	public FoamEntities(FoamEntities data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		GroupEntity = new buEntitiesGroup(data.GroupEntity);
	}

	public static void Copy(List<FoamEntities> refEntities, ref List<FoamEntities> copyEntities)
	{
		copyEntities = new List<FoamEntities>();
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			copyEntities.Add(new FoamEntities(refEntities[i]));
		}
	}
}
