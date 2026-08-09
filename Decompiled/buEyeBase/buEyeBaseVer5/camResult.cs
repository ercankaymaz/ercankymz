using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5;

[Serializable]
public class camResult : buSerilization5
{
	public List<CalculationError> Errors = new List<CalculationError>();

	public List<Entity> UsedEntities = new List<Entity>();

	public camResult()
	{
	}

	public camResult(camResult data)
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
		Errors.Clear();
		for (int j = 0; j <= data.Errors.Count - 1; j++)
		{
			CalculationError item = new CalculationError(data.Errors[j]);
			Errors.Add(item);
		}
	}
}
