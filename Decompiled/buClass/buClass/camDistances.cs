using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camDistances : buSerilization
{
	public double Safe = 100.0;

	public double SafeSmall = 80.0;

	public double FirstApproach = 20.0;

	public double StepUp = 20.0;

	public double LeftSafe = 100.0;

	public double LeftSafeSmall = 80.0;

	public double LeftFirstApproach = 20.0;

	public double LeftStepUp = 20.0;

	public double RightSafe = 100.0;

	public double RightSafeSmall = 80.0;

	public double RightFirstApproach = 20.0;

	public double RightStepUp = 20.0;

	public double Air = 500.0;

	public double Rapid = 100.0;

	public bool IncrementalSafe = false;

	public static List<string> Captions = new List<string>();

	public camDistances()
	{
	}

	public camDistances(double safe, double stepup, double air, bool increemntalsafe)
	{
		Safe = safe;
		StepUp = stepup;
		Air = air;
		IncrementalSafe = increemntalsafe;
	}

	public camDistances(camDistances distance)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(distance, ref CopiedClass);
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
		return "Safe: " + Safe + " , StepUp: " + StepUp + " , Air: " + Air + " , IncrementalSafe: " + IncrementalSafe;
	}
}
