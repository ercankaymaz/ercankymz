using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerOffsetSettings : buSerilization
{
	public double LeftCustomOffset1 = 1.35;

	public double LeftCustomOffset2 = 2.0;

	public double LeftCustomOffset3 = 3.0;

	public double RightCustomOffset1 = 1.35;

	public double RightCustomOffset2 = 2.0;

	public double RightCustomOffset3 = 3.0;

	public double Creasing1PtExtraOffset = -0.1;

	public double Creasing2PtExtraOffset = -0.1;

	public double Creasing3PtExtraOffset = -0.1;

	public double Creasing4PtExtraOffset = -0.1;

	public double CuttingStraight1PtOffset = 0.25;

	public double CuttingStraight2PtOffset = 0.4;

	public double CuttingStraight3PtOffset = 0.6;

	public double CuttingStraight4PtOffset = 0.7;

	public double CuttingLip1PtOffset = -0.25;

	public double CuttingLip2PtOffset = -0.3;

	public double CuttingLip3PtOffset = -0.5;

	public double CuttingLip4PtOffset = -0.7;

	public static List<string> Captions = new List<string>();

	public DiemakerOffsetSettings()
	{
	}

	public DiemakerOffsetSettings(DiemakerOffsetSettings data)
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

	public static void Copy(DiemakerOffsetSettings Source, ref DiemakerOffsetSettings Target)
	{
		Target = new DiemakerOffsetSettings(Source);
	}

	public override string ToString()
	{
		return "LeftCustomOffset1 : " + LeftCustomOffset1 + " - RightCustomOffset1 : " + RightCustomOffset1;
	}
}
