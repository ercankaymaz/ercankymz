using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingResultSettings : buSerilization5
{
	public bool ShowSheetSizeOnDisplay = true;

	public bool ShowSheetNameOnDisplay = true;

	public bool ShowSheetPersentageOnDisplay = true;

	public bool ShowSheetCountOnDisplay = true;

	public bool DrawPartAsSolid = true;

	public bool DrawPartOnlyOutterSolid = false;

	public bool PartAreaOnlyFromOutter = true;

	public bool DrawSheets = false;

	public bool DrawSheetOnlyPreview = true;

	public HorizontalVertical DrawNestingResultAligment = HorizontalVertical.Horizontal;

	public double DrawNestingResultSpace = 0.0;

	public bool DrawAddClearAll = true;

	public bool DrawAddToEnd = true;

	public double DrawAddToEndOffset = 10.0;

	public double RemnantMinLength = 300.0;

	public double RemnantSizeOffset = 10.0;

	public bool RemnantCalculate = false;

	public static List<string> Captions = new List<string>();

	public buNestingResultSettings()
	{
	}

	public buNestingResultSettings(buNestingResultSettings data)
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
