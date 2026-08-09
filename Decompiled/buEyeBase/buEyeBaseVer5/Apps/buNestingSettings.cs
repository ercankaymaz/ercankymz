using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSettings : buSerilization5
{
	public int NestingThreadCalculationCount = 2;

	public bool NestExecutionByThread = true;

	public int GarbageCollectionDisableSize = 200000000;

	public bool ShowResultPreviewAfterFinish = false;

	public bool ShowBetterResult = true;

	public bool DeleteNestedPartAfterNesting = false;

	public bool UseCallBacks = true;

	public bool UseCompactMethod = false;

	public double CompactTime = 10.0;

	public static List<string> Captions = new List<string>();

	public buNestingSettings()
	{
	}

	public buNestingSettings(buNestingSettings data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
