using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxRuntimeMisc : buSerilization
{
	public double AbsolutePosition;

	public double IncrementalPosition;

	public double maintenanceTotalMeter = 0.0;

	public double measureTotalHour = 0.0;

	public double measureTotalAlarmdHour = 0.0;

	public double measureTotalEnergizedHour = 0.0;

	public double measureMaxCurrent = 0.0;

	public double measureMaxVelocity = 0.0;

	public double measureTotalTravelMeter = 0.0;

	public double measureTotalTravelMeterRun = 0.0;

	public double measureTotalTravelMeterFree = 0.0;

	public double measureTotalTravelMeterNoEnable = 0.0;

	public int measureTotalAlarmCount = 0;

	public int measureTotalEnableCount = 0;

	public string AxisNotAllowMessage = "";

	public CodesysAxRuntimeMisc()
	{
	}

	public CodesysAxRuntimeMisc(CodesysAxRuntimeMisc data)
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
		return "AbsolutePosition: " + AbsolutePosition + " , IncrementalPosition: " + IncrementalPosition;
	}
}
