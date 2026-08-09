using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class FeedSettings : buSerilization
{
	public double FeedOverrideG0 = 100.0;

	public double FeedOverrideG1 = 100.0;

	public double FeedOverride = 100.0;

	public double FeedOverrideAxes = 100.0;

	public double FeedOverrideMin = 0.0;

	public double FeedOverrideMax = 100.0;

	public double FeedOverrideStep = 2.0;

	public bool FeedFromAnalogInput = false;

	public OverrideType FeedOverrideMode = OverrideType.Value;

	public static List<string> Captions = new List<string>();

	public FeedSettings()
	{
	}

	public FeedSettings(FeedSettings data)
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
		return "FeedOverrideMin: " + FeedOverrideMin + " , FeedOverrideMax : " + FeedOverrideMax;
	}
}
