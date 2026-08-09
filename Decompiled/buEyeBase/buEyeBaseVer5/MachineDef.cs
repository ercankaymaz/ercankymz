using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class MachineDef : buSerilization5
{
	public KinematicBase5 Kinematic = new KinematicBase5();

	public ToolBase5 ToolData = new ToolBase5();

	public List<MachineDefPart> MachineParts = new List<MachineDefPart>();

	public List<MachineDefPart> Clampers = new List<MachineDefPart>();

	public MachineDef()
	{
	}

	public MachineDef(MachineDef data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
		ToolData = new ToolBase5(data.ToolData);
		Kinematic = new KinematicBase5(data.Kinematic);
		MachineParts.Clear();
		for (int j = 0; j <= data.MachineParts.Count - 1; j++)
		{
			MachineParts.Add(new MachineDefPart(data.MachineParts[j]));
		}
		MachineParts.Clear();
		for (int k = 0; k <= data.Clampers.Count - 1; k++)
		{
			Clampers.Add(new MachineDefPart(data.Clampers[k]));
		}
	}
}
