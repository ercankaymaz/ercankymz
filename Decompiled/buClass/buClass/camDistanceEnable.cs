using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camDistanceEnable : buSerilization
{
	public bool Safe = true;

	public bool StepUp = true;

	public bool Air = false;

	public bool IncrementalSafe = false;

	public static List<string> Captions = new List<string>();

	public camDistanceEnable()
	{
	}

	public camDistanceEnable(bool safe, bool stepup, bool air, bool incrementalsafe)
	{
		Safe = safe;
		StepUp = stepup;
		Air = air;
		IncrementalSafe = incrementalsafe;
	}

	public camDistanceEnable(camDistanceEnable Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
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

	public override string ToString()
	{
		return "Safe: " + Safe + " , StepUp: " + StepUp + " , Air: " + Air + " , IncrementalSafe: " + IncrementalSafe;
	}
}
