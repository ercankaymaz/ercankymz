using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleChamferPars : buSerilization5
{
	public double ChamferWidth = 20.0;

	public double ChamferHeight = 20.0;

	public double ChamferLengthStep = 50.0;

	public UpDownType ChamferUpDown = UpDownType.Down;

	public static List<string> Captions = new List<string>();

	public marbleChamferPars()
	{
	}

	public marbleChamferPars(marbleChamferPars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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

	public static void Copy(marbleChamferPars Source, ref marbleChamferPars Target)
	{
		Target = new marbleChamferPars(Source);
	}

	public override string ToString()
	{
		return "ChamferWidth : " + ChamferWidth + " , ChamferHeight : " + ChamferHeight + " , ChamferLengthStep : " + ChamferLengthStep + " , ChmaferUpDown : " + ChamferUpDown;
	}
}
