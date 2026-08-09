using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class MachineSettings : buSerilization
{
	public double AxisNumber = 3.0;

	public int InputCount = 16;

	public int OutputCount = 16;

	public int ToolCount = 6;

	public int G54Count = 2;

	public int ParkCount = 5;

	public int ToolChangerCount = 10;

	public static List<string> Captions = new List<string>();

	public MachineSettings()
	{
	}

	public MachineSettings(MachineSettings data)
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
