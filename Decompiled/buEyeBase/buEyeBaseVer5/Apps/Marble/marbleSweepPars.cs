using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSweepPars : buSerilization5
{
	public double SweepRampHeight = 20.0;

	public double SweepRampWidth = 20.0;

	public double SweepTargetZ = 0.0;

	public double SweepFollowOffset = 0.0;

	public double SweepWidth = 0.0;

	public double SweepYStep = 3.0;

	public CamZRampType SawRampType = CamZRampType.Linear;

	public double SweepResolution = 0.5;

	public double SafeDistance = 100.0;

	public static List<string> Captions = new List<string>();

	public marbleSweepPars()
	{
	}

	public marbleSweepPars(marbleSweepPars data)
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

	public static void Copy(marbleSweepPars Source, ref marbleSweepPars Target)
	{
		Target = new marbleSweepPars(Source);
	}

	public override string ToString()
	{
		return "SweepRampHeight : " + SweepRampHeight + " , SweepRampWidth : " + SweepRampWidth + " , SweepTargetZ : " + SweepTargetZ + " , SweepFollowOffset : " + SweepFollowOffset;
	}
}
