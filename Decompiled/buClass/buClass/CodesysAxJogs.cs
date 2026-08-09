using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxJogs : buSerilization
{
	public double jogVelocity = 20.0;

	public double jogAcc = 1000.0;

	public double jogDec = 1000.0;

	public double jogJerk = 2500.0;

	public double jogFirstSpeedPersentage = 20.0;

	public double jogSecondSpeedPersentage = 50.0;

	public double jogFirstSpeedTimeSec = 0.0;

	public double jogSecondSpeedTimeSec = 0.0;

	public bool jogWithAbsoluteMove = false;

	public bool jogOverrideEnable = true;

	public bool jogDynamicVelocityFromFeed = false;

	public static List<string> Captions = new List<string>();

	public CodesysAxJogs()
	{
	}

	public CodesysAxJogs(CodesysAxJogs data)
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
		return "Vel : " + jogVelocity + " , Acc: " + jogAcc + " , Dec: " + jogDec + " , Jerk: " + jogJerk;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + jogVelocity + ";" + jogAcc + ";" + jogDec;
		text = text + ";" + jogJerk;
		text = text + ";" + buSerilization.BoolToString(jogWithAbsoluteMove) + ";" + buSerilization.BoolToString(jogOverrideEnable);
		return text + ";" + buSerilization.BoolToString(jogDynamicVelocityFromFeed);
	}
}
