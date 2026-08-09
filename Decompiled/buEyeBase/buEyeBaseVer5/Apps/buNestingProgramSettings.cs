using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingProgramSettings : buSerilization5
{
	public LengthUnit UnitLength = LengthUnit.mm;

	public LengthUnit UnitArea = LengthUnit.m;

	public SpeedUnit UnitSpeed = SpeedUnit.mmPerMin;

	public nestCalculationShowFormat CalculationShowFormat = nestCalculationShowFormat.PastalAsSingleSheet;

	public bool isCutter = false;

	public bool View3D = true;

	public bool DoubleSheetAtPdf = true;

	public double PenUpTime = 0.2;

	public double PenDownTime = 0.2;

	public double CuttingSpeed = 500.0;

	public double NoneCuttingSpeed = 800.0;

	public bool UseNoneCutting = true;

	public double TextTime = 0.0;

	public double Layer0Speed = 1000.0;

	public double Layer1Speed = 1200.0;

	public double Layer2Speed = 1400.0;

	public double Layer3Speed = 1000.0;

	public double Layer4Speed = 1000.0;

	public double Layer5Speed = 1000.0;

	public double Layer6Speed = 1000.0;

	public double Layer7Speed = 1000.0;

	public double Layer8Speed = 1000.0;

	public double Layer9Speed = 1000.0;

	public static List<string> Captions = new List<string>();

	public buNestingProgramSettings()
	{
	}

	public buNestingProgramSettings(buNestingProgramSettings data)
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
