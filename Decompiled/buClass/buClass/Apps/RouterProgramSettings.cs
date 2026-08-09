using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class RouterProgramSettings : buSerilization
{
	public bool isBuSorting = true;

	public bool isBuCalculation = true;

	public bool UseStartPoint = true;

	public double StartPointX = 0.0;

	public double StartPointY = 0.0;

	public ClockDirectionType InsideCutClosedPatternCutDirection = ClockDirectionType.CCW;

	public TopBottomType WoodBottomRefSide = TopBottomType.Bottom;

	public double WoodBottomTrimPersentage = 50.0;

	public double SafeDistance = 50.0;

	public double LeaveSpeed = 80.0;

	public bool RapidRetract = false;

	public bool ShowBuDialog = false;

	public static List<string> Captions = new List<string>();

	public RouterProgramSettings()
	{
	}

	public RouterProgramSettings(RouterProgramSettings data)
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

	public static void Copy(RouterProgramSettings Source, ref RouterProgramSettings Target)
	{
		Target = new RouterProgramSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
