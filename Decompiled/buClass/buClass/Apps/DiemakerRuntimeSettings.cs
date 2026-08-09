using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerRuntimeSettings : buSerilization
{
	public List<MachineType> MachineTypes = new List<MachineType>();

	public int SelectedMachine = 0;

	public DiemakerRuntimeSettings()
	{
	}

	public DiemakerRuntimeSettings(DiemakerRuntimeSettings data)
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
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		MachineTypes.Clear();
		for (int j = 0; j <= data.MachineTypes.Count - 1; j++)
		{
			MachineType item = new MachineType(data.MachineTypes[j]);
			MachineTypes.Add(item);
		}
	}

	public static void Copy(DiemakerRuntimeSettings Source, ref DiemakerRuntimeSettings Target)
	{
		Target = new DiemakerRuntimeSettings(Source);
	}

	public override string ToString()
	{
		return "Sel Machine : " + SelectedMachine;
	}
}
