using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendingProgramSettings : buSerilization5
{
	public string pathLRAFiles = Application.StartupPath;

	public int SimulationIntervalMs = 5;

	public bool CollisionCheck = true;

	public static List<string> Captions = new List<string>();

	public PipeBendingProgramSettings()
	{
	}

	public PipeBendingProgramSettings(PipeBendingProgramSettings data)
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

	public static void Copy(PipeBendingProgramSettings Source, ref PipeBendingProgramSettings Target)
	{
		Target = new PipeBendingProgramSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
