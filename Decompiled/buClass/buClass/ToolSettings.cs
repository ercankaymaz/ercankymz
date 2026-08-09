using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolSettings : buSerilization
{
	public double toolClamperOpenTimeSec = 1.0;

	public double toolClamperCloseTimeSec = 1.0;

	public double toolChangeFastVelocity = 20.0;

	public double toolChangeSlowVelocity = 10.0;

	public double toolChangeTimeOutSec = 120.0;

	public double toolChangeWaitTimeSec = 1000.0;

	public double toolChangeBrokenToolLimit = 1.0;

	public double toolMeasureTimeOutSec = 120.0;

	public double toolMeasureLengthConstant = 100.0;

	public double toolMeasureFastVelocity = 20.0;

	public double toolMeasureSlowVelocity = 10.0;

	public bool btoolMeasureLengthBeforeLeave = false;

	public bool btoolMeasureLengthAfterTake = false;

	public double toolBrokenToolControlDistance = 0.1;

	public static List<string> Captions = new List<string>();

	public ToolSettings()
	{
	}

	public ToolSettings(ToolSettings data)
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
		return "toolMeasureFastVelocity: " + toolMeasureFastVelocity;
	}
}
