using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxHomings : buSerilization
{
	public double homingFastVelocity = 10.0;

	public double homingSlowVelocity = 2.0;

	public double homingSetPosition = 0.0;

	public double homingOffset = 0.0;

	public double homingAcc = 2000.0;

	public double homingDec = 2000.0;

	public double homingJerk = 1000.0;

	public double homingDelay = 0.0;

	public double homingTimeoutSec = 120.0;

	public CodesysHomeMode homingMode = CodesysHomeMode.FAST_BSLOW_S_STOP;

	public CodesysHomeMethod homingMethod = CodesysHomeMethod.SMCHome;

	public int homingDriveHomeMode = 0;

	public bool homingReverseDir = false;

	public bool homingSwitchNC = false;

	public bool homingDisableLimits = true;

	public bool homingUseSecondSlowSpeed = false;

	public double homingAbsoluteHomePosition = 0.0;

	public static List<string> Captions = new List<string>();

	public CodesysAxHomings()
	{
	}

	public CodesysAxHomings(CodesysAxHomings data)
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
		return "Fast Vel: " + homingFastVelocity + " , Slow Vel: " + homingSlowVelocity + " , Set Pos: " + homingSetPosition;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + homingFastVelocity + ";" + homingSlowVelocity + ";" + homingSetPosition;
		text = text + ";" + homingOffset + ";" + homingAcc + ";" + homingDec;
		text = text + ";" + homingJerk + ";" + homingDelay + ";" + homingTimeoutSec;
		text = text + ";" + homingMode.ToString() + ";" + homingMethod.ToString() + ";" + homingDriveHomeMode;
		text = text + ";" + homingAbsoluteHomePosition + ";" + buSerilization.BoolToString(homingReverseDir) + ";" + buSerilization.BoolToString(homingSwitchNC);
		return text + ";" + buSerilization.BoolToString(homingDisableLimits) + ";" + buSerilization.BoolToString(homingUseSecondSlowSpeed);
	}
}
