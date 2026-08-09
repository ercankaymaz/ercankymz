using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class RollerBendSettings : buSerilization5
{
	public double TopBottomCylinderDistance = 19.5;

	public double LeftCylinderAngle = 20.0;

	public double RightCylinderAngle = 20.0;

	public double LeftCylinderDiameter = 140.0;

	public double RightCylinderDiameter = 140.0;

	public double UpCylinderDiameter = 160.0;

	public double DownCylinderDiameter = 160.0;

	public double LeftCylinderXOffset = -178.0;

	public double LeftCylinderZOffset = 10.0;

	public double RightCylinderXOffset = 178.0;

	public double RightCylinderZOffset = 10.0;

	public int SimulationIntervalMs = 40;

	public RollerBendSettings()
	{
	}

	public RollerBendSettings(RollerBendSettings data)
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
