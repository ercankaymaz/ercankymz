using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class SpindleSystemSettings : buSerilization
{
	public double SpindleSpeed = 3000.0;

	public double SpindleOverrideMin = 0.0;

	public double SpindleOverrideMax = 100.0;

	public double SpindleOverrideStep = 500.0;

	public double SpindleMinSpeed = 1000.0;

	public double SpindleMaxSpeed = 24000.0;

	public double SpindleStartTimeSec = 4.0;

	public double SpindleStopTimeSec = 4.0;

	public OverrideType SpindleRateMode = OverrideType.Value;

	public static List<string> Captions = new List<string>();

	public SpindleSystemSettings()
	{
	}

	public SpindleSystemSettings(SpindleSystemSettings data)
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

	public override string ToString()
	{
		return "SpindleMinSpeed: " + SpindleMinSpeed + " , SpindleMaxSpeed : " + SpindleMaxSpeed;
	}
}
