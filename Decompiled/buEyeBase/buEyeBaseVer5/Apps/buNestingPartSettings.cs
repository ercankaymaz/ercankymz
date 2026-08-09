using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingPartSettings : buSerilization5
{
	public double PartsSpace = 1.0;

	public int Multiply = 1;

	public bool DeletePartAfterImport = true;

	public bool SavePartsBeforeDeleted = false;

	public double ConnectTolerance = 0.02;

	public double PartRotateStep = 10.0;

	public string DefaultPartName = "Part";

	public bool AddAutoPartQuantityIfAvailable = true;

	public bool AddAutoPartNameIfAvailable = true;

	public string AutoPartNameRef = "Name";

	public string AutoPartQuantityRef = "Quantity";

	public string AutoPartNameEquality = ":";

	public string AutoPartQuantityEquality = ":";

	public bool PartInPart = false;

	public bool CheckLinearPathToBackwardToFindClosed = false;

	public nestingPartMainDrawAddModes PartMainAddType = nestingPartMainDrawAddModes.Color;

	public Color PartListPreviewBackColor = Color.Gray;

	public bool GetInternalEntitiesFromConnectedOutter = true;

	public double MultiplePArtAddOusideFilterLength = 10.0;

	public static List<string> Captions = new List<string>();

	public buNestingPartSettings()
	{
	}

	public buNestingPartSettings(buNestingPartSettings data)
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
