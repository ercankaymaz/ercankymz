using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillMachineSettings : buSerilization5
{
	public double X1Velocity = 2075.0;

	public double X1AccDec = 50000.0;

	public double X2Velocity = 2075.0;

	public double X2AccDec = 50000.0;

	public double Y1Velocity = 1100.0;

	public double Y1AccDec = 40000.0;

	public double Y2Velocity = 1100.0;

	public double Y2AccDec = 40000.0;

	public double Y3Velocity = 1100.0;

	public double Y3AccDec = 40000.0;

	public double Z1Velocity = 450.0;

	public double Z1AccDec = 60000.0;

	public double Z2Velocity = 450.0;

	public double Z2AccDec = 60000.0;

	public double Z3Velocity = 450.0;

	public double Z3AccDec = 60000.0;

	public double ClamperUpTime = 1.0;

	public double ClamperDownTime = 1.0;

	public double ToolResetTime = 0.15;

	public double ToolSetTime = 0.06;

	public double MachineMaxXStroke = 2800.0;

	public double MachineMinXStroke = -1300.0;

	public double MachineMillingStandartXStroke = 2400.0;

	public double MachineMillingStandartXMaxLimit = 3400.0;

	public string ClamperVersion = "V1";

	public double MillingHolderOffset = 0.0;

	public int SimulationIntervalMs = 30;

	public DrillMachineSettings()
	{
	}

	public DrillMachineSettings(DrillMachineSettings data)
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
}
