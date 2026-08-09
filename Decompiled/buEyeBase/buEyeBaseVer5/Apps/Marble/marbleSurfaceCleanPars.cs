using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSurfaceCleanPars : buSerilization5
{
	public double ToolDiameterUsagePersentage = 90.0;

	public double SafeDistance = 50.0;

	public double RapidDistance = 20.0;

	public double StepDownDistance = 5.0;

	public double PlungeFeed = 20.0;

	public double CuttingFeed = 50.0;

	public double SpindleSpeed = 3000.0;

	public double ZOffset = 0.0;

	public bool ZigzagMode = true;

	public static List<string> Captions = new List<string>();

	public marbleSurfaceCleanPars()
	{
	}

	public marbleSurfaceCleanPars(marbleSurfaceCleanPars data)
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

	public static void Copy(marbleSurfaceCleanPars Source, ref marbleSurfaceCleanPars Target)
	{
		Target = new marbleSurfaceCleanPars(Source);
	}

	public override string ToString()
	{
		return "SafeDistance : " + SafeDistance + " , CuttingFeed : " + CuttingFeed;
	}
}
