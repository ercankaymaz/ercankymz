using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCamSawFeedAnalysisPars : buSerilization5
{
	public double MaxCStepDegree = 1.0;

	public double MaxXYLength = 1.5;

	public double FixRatio = 1.5;

	public double MinFeedValue = 0.5;

	public static List<string> Captions = new List<string>();

	public marbleCamSawFeedAnalysisPars()
	{
	}

	public marbleCamSawFeedAnalysisPars(double maxCStepDegree, double maxXYLength, double fixRatio)
	{
		FixRatio = fixRatio;
		MaxCStepDegree = maxCStepDegree;
		MaxXYLength = maxXYLength;
	}

	public marbleCamSawFeedAnalysisPars(marbleCamSawFeedAnalysisPars data)
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

	public static void Copy(marbleCamSawFeedAnalysisPars Source, ref marbleCamSawFeedAnalysisPars Target)
	{
		Target = new marbleCamSawFeedAnalysisPars(Source);
	}

	public override string ToString()
	{
		return "MaxCStepDegree : " + MaxCStepDegree + " , MaxXYLength : " + MaxXYLength + " , FixRatio : " + FixRatio;
	}
}
