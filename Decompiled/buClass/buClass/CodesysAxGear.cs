using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxGear : buSerilization
{
	public int gearNumerator = 1;

	public int gearDenominator = 1;

	public double gearAcc = 500.0;

	public double gearDec = 500.0;

	public double gearJerk = 2500.0;

	public static List<string> Captions = new List<string>();

	public CodesysAxGear()
	{
	}

	public CodesysAxGear(CodesysAxGear data)
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
		return "Numerator: " + gearNumerator + " , Denominator: " + gearDenominator;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + gearNumerator + ";" + gearDenominator + ";" + gearAcc;
		return text + ";" + gearDec + ";" + gearJerk;
	}
}
