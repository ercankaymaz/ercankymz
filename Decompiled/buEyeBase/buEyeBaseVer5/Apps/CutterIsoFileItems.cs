using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterIsoFileItems : buSerilization
{
	public List<List<Entity>> Entities = new List<List<Entity>>();

	public CutterIsoFileItems()
	{
	}

	public CutterIsoFileItems(CutterIsoFileItems data)
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
