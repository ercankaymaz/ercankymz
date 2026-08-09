using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class TuftingSequenceItem : buSerilization
{
	public string LayerName = "";

	public bool Enable = true;

	public List<Entity> SortedEntities = new List<Entity>();

	public TuftingSequenceItem()
	{
	}

	public TuftingSequenceItem(TuftingSequenceItem data)
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
		SortedEntities.Clear();
		buVector5.CopyEntities(data.SortedEntities, ref SortedEntities);
	}
}
