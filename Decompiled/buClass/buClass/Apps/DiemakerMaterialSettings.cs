using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerMaterialSettings : buSerilization
{
	public double PT1Thickness = 0.35;

	public double PT2Thickness = 0.71;

	public double PT3Thickness = 1.05;

	public double PT4Thickness = 1.42;

	public double BridgeHeight = 15.0;

	public double BladeHeigth = 23.5;

	public double LipWidthRatio = 0.04;

	public double LipHeightRatio = 0.05;

	public double LipClickArea = 0.1;

	public double RuleHeight = 23.8;

	public static List<string> Captions = new List<string>();

	public DiemakerMaterialSettings()
	{
	}

	public DiemakerMaterialSettings(DiemakerMaterialSettings data)
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

	public static void Copy(DiemakerMaterialSettings Source, ref DiemakerMaterialSettings Target)
	{
		Target = new DiemakerMaterialSettings(Source);
	}

	public override string ToString()
	{
		return "PT2Thickness : " + PT2Thickness;
	}
}
