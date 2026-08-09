using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class GrindingPageData : buSerilization
{
	public List<GrindingPin> Pins = new List<GrindingPin>();

	public List<GrindingVacuum> Vacuums = new List<GrindingVacuum>();

	public GrindingPageData()
	{
	}

	public GrindingPageData(GrindingPageData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		Pins = new List<GrindingPin>();
		for (int j = 0; j <= data.Pins.Count - 1; j++)
		{
			GrindingPin item = new GrindingPin(data.Pins[j]);
			Pins.Add(item);
		}
		Vacuums = new List<GrindingVacuum>();
		for (int k = 0; k <= data.Vacuums.Count - 1; k++)
		{
			GrindingVacuum item2 = new GrindingVacuum(data.Vacuums[k]);
			Vacuums.Add(item2);
		}
	}
}
