using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleMachineSettings : buSerilization5
{
	public MarbleMachineLatheSettings LatheSettings = new MarbleMachineLatheSettings();

	public MarbleMachineSimultionSettings SimulationSettings = new MarbleMachineSimultionSettings();

	public MarbleMachineOptionsSettings OptionSettings = new MarbleMachineOptionsSettings();

	public double BaseWoodWidth = 3000.0;

	public double BaseWoodHeight = 2000.0;

	public double BaseWoodThickness = 50.0;

	public double BaseWoodXOffset = 0.0;

	public double BaseWoodYOffset = 0.0;

	public double BaseWoodZOffset = -0.5;

	public double MotorBlockBottomHeight = 0.0;

	public static List<string> Captions = new List<string>();

	public MarbleMachineSettings()
	{
	}

	public MarbleMachineSettings(MarbleMachineSettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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

	public static void Copy(MarbleMachineSettings Source, ref MarbleMachineSettings Target)
	{
		Target = new MarbleMachineSettings(Source);
	}

	public override string ToString()
	{
		return "BaseWoodZOffset: " + BaseWoodZOffset;
	}
}
