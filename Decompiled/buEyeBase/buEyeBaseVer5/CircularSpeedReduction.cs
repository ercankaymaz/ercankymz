using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class CircularSpeedReduction : buSerilization5
{
	public double MinDiameter = 0.0;

	public double MaxDiameter = 500.0;

	public double Persentage = 100.0;

	public CircularSpeedReduction()
	{
	}

	public CircularSpeedReduction(double mindiameter, double maxdiameter, double persentage)
	{
		MinDiameter = mindiameter;
		MaxDiameter = maxdiameter;
		Persentage = persentage;
	}

	public CircularSpeedReduction(CircularSpeedReduction data)
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

	public static void GetPersentage(List<CircularSpeedReduction> SpeedList, double Diameter, ref double FoundPersentage)
	{
		if (SpeedList.Count <= 0)
		{
			FoundPersentage = 100.0;
			return;
		}
		FoundPersentage = 100.0;
		for (int i = 0; i <= SpeedList.Count - 1; i++)
		{
			if (!(Diameter < SpeedList[i].MinDiameter) && Diameter <= SpeedList[i].MaxDiameter)
			{
				FoundPersentage = SpeedList[i].Persentage;
				i = SpeedList.Count;
			}
		}
	}

	public override string ToString()
	{
		return "MinDiameter: " + MinDiameter + " - MaxDiameter: " + MaxDiameter + " - Persentage: " + Persentage;
	}
}
