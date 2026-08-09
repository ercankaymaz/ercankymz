using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCuttingItems : buSerilization5
{
	public bool Enable = false;

	public double Length = 0.0;

	public int Count = 0;

	public double StartAngle = 0.0;

	public double EndAngle = 0.0;

	public static List<string> Captions = new List<string>();

	public static List<string> CaptionsUnits = new List<string>();

	public marbleCuttingItems()
	{
	}

	public marbleCuttingItems(double length, int count, double SA, double EA)
	{
		Length = length;
		Count = count;
		StartAngle = SA;
		EndAngle = EA;
	}

	public marbleCuttingItems(marbleCuttingItems data)
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

	public static void Copy(marbleCuttingItems Source, ref marbleCuttingItems Target)
	{
		Target = new marbleCuttingItems(Source);
	}

	public static marbleCuttingItems Copy(marbleCuttingItems Source)
	{
		marbleCuttingItems Target = new marbleCuttingItems();
		Copy(Source, ref Target);
		return Target;
	}

	public static void Copy(List<marbleCuttingItems> Source, ref List<marbleCuttingItems> Target)
	{
		Source.Clear();
		for (int i = 0; i <= Source.Count - 1; i++)
		{
			marbleCuttingItems Target2 = new marbleCuttingItems();
			Copy(Source[i], ref Target2);
			Target.Add(Target2);
		}
	}

	public override string ToString()
	{
		return "Length : " + Length + " , Count : " + Count + " , Enable : " + Enable;
	}
}
