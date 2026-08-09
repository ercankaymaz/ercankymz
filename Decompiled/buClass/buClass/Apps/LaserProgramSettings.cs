using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class LaserProgramSettings : buSerilization
{
	public double G0FeedMmperSec = 50.0;

	public double Pt1ThicknessValue = 0.355;

	public double Pt2ThicknessValue = 0.71;

	public double Pt3ThicknessValue = 1.05;

	public double Pt4ThicknessValue = 1.42;

	public double Pt6ThicknessValue = 2.1;

	public bool Pt3DoubleCutEnable = true;

	public bool Pt4DoubleCutEnable = true;

	public bool Pt6DoubleCutEnable = true;

	public bool isBuSorting = true;

	public bool isBuCalculation = true;

	public bool UseStartPoint = true;

	public double StartPointX = 0.0;

	public double StartPointY = 0.0;

	public double LaserStartTime = 200.0;

	public double LaserStopTime = 200.0;

	public static List<string> Captions = new List<string>();

	public LaserProgramSettings()
	{
	}

	public LaserProgramSettings(LaserProgramSettings data)
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

	public static void Copy(LaserProgramSettings Source, ref LaserProgramSettings Target)
	{
		Target = new LaserProgramSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
