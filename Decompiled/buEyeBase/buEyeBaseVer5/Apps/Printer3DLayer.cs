using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Printer3DLayer : buSerilization5
{
	public bool Enable = true;

	public double LevelZ = 0.0;

	public List<buEntity> entitiesInfill = new List<buEntity>();

	public List<buEntity> entitiesOffsetedSlices = new List<buEntity>();

	public Printer3DLayer()
	{
	}

	public Printer3DLayer(Printer3DLayer data)
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
		buEntity.Copy(data.entitiesInfill, ref entitiesInfill);
		buEntity.Copy(data.entitiesOffsetedSlices, ref entitiesOffsetedSlices);
	}

	public override string ToString()
	{
		return LevelZ.ToString();
	}
}
