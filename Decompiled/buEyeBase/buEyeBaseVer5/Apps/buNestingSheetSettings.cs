using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSheetSettings : buSerilization5
{
	public nestCorner CornerType = nestCorner.LeftBottom;

	public nestDirection Direction = nestDirection.XDirection;

	public nestAlgorithm Algorithm = nestAlgorithm.TrueShape;

	public double RectangleMarginLeft = 0.5;

	public double RectangleMarginRight = 0.5;

	public double RectangleMarginTop = 0.5;

	public double RectangleMarginBottom = 0.5;

	public double IrregularMargin = 0.5;

	public bool DeleteSheetAfterImport = false;

	public bool SaveSheetsBeforeDeleted = false;

	public bool UseSmallAreaFirst = true;

	public string DefaultSheetName = "Sheet";

	public bool AddAutoSheetQuantityIfAvailable = true;

	public bool AddAutoSheetNameIfAvailable = true;

	public string AutoSheetNameRef = "Name";

	public string AutoSheetQuantityRef = "Quantity";

	public string AutoSheetNameEquality = ":";

	public string AutoSheetQuantityEquality = ":";

	public static List<string> Captions = new List<string>();

	public buNestingSheetSettings()
	{
	}

	public buNestingSheetSettings(buNestingSheetSettings data)
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
