using System;
using System.Collections.Generic;
using System.Reflection;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5;

[Serializable]
public class EntitiesGroup : buSerilization5
{
	public List<Entity> Outside = null;

	public List<List<Entity>> Inside = null;

	public EntitiesGroup()
	{
		Outside = new List<Entity>();
		Inside = new List<List<Entity>>();
	}

	public EntitiesGroup(EntitiesGroup data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
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
		Outside = new List<Entity>();
		Inside = new List<List<Entity>>();
		buVector5.CopyEntities(data.Outside, ref Outside);
		buVector5.CopyEntities(data.Inside, ref Inside);
	}
}
