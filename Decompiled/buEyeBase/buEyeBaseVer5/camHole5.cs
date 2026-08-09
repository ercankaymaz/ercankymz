using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camHole5 : buSerilization5
{
	public double StartHeight = 100.0;

	public double EndHeight = 80.0;

	public double DownStep = 2.0;

	public double UpStep = 1.0;

	public grindingHoleType HoleType = grindingHoleType.UpDownByStep;

	public static List<string> Captions = new List<string>();

	public camHole5()
	{
	}

	public camHole5(camHole5 distance)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(distance, ref CopiedClass);
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

	public override string ToString()
	{
		return "StartHeight: " + StartHeight + " , EndHeight: " + EndHeight + " , DownStep: " + DownStep + " , HoleType: " + HoleType;
	}
}
