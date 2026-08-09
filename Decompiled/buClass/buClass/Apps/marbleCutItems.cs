using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class marbleCutItems : buSerilization
{
	public bool Enable = false;

	public double Length = 0.0;

	public int Count = 0;

	public double StartAngle = 0.0;

	public double EndAngle = 0.0;

	public static List<string> Captions = new List<string>();

	public static List<string> CaptionsUnits = new List<string>();

	public marbleCutItems()
	{
	}

	public marbleCutItems(marbleCutItems data)
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

	public static void Copy(marbleCutItems Source, ref marbleCutItems Target)
	{
		Target = new marbleCutItems(Source);
	}

	public static marbleCutItems Copy(marbleCutItems Source)
	{
		marbleCutItems Target = new marbleCutItems();
		Copy(Source, ref Target);
		return Target;
	}

	public static void Copy(List<marbleCutItems> Source, ref List<marbleCutItems> Target)
	{
		Source.Clear();
		for (int i = 0; i <= Source.Count - 1; i++)
		{
			marbleCutItems Target2 = new marbleCutItems();
			Copy(Source[i], ref Target2);
			Target.Add(Target2);
		}
	}

	public override string ToString()
	{
		return "Length : " + Length + " , Count : " + Count + " , Enable : " + Enable;
	}
}
