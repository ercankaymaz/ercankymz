using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class HandWheelSystemSettings : buSerilization
{
	public bool Enable = true;

	public double HandwheelPosFilterFactor = 0.2;

	public bool HandwheelPosUseAvarage = false;

	public int HandwheelPosAvarageCount = 10;

	public bool HandwheelPosUseFilterFactor = false;

	public int HandwheelVelAvarageCount = 50;

	public double stepFeedRateEncoderPulse = 5.0;

	public double stepSpindleRateEncoderPulse = 5.0;

	public double stepGCodeLinesEncoderPulse = 5.0;

	public double FeedOverrideCalibration = 0.1;

	public static List<string> Captions = new List<string>();

	public HandWheelSystemSettings()
	{
	}

	public HandWheelSystemSettings(HandWheelSystemSettings data)
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
		return "Enable: " + Enable;
	}
}
