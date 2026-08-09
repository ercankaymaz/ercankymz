using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

public class jewelStepSettings : buSerilization
{
	public double MaxCuttingDistance = 0.2;

	public CamMachiningSequenceType Sequance = CamMachiningSequenceType.Region;

	public CamMoveUpType MoveUpType = CamMoveUpType.Incremental;

	public double SafeDistance = 10.0;

	public static List<string> Captions = new List<string>();

	public jewelStepSettings()
	{
	}

	public jewelStepSettings(jewelStepSettings data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
