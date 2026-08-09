using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMaterialPars : buSerilization5
{
	public double MaterialWidth = 2200.0;

	public double MaterialHeight = 1500.0;

	public double MaterialThickness = 20.0;

	public double EdgeBorderGap = 150.0;

	public double PartAndPartBorderDistance = 150.0;

	public static List<string> Captions = new List<string>();

	public marbleMaterialPars()
	{
	}

	public marbleMaterialPars(marbleMaterialPars data)
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

	public static void Copy(marbleMaterialPars Source, ref marbleMaterialPars Target)
	{
		Target = new marbleMaterialPars(Source);
	}

	public override string ToString()
	{
		return "MaterialWidth : " + MaterialWidth + " , MaterialHeight : " + MaterialHeight + " , MaterialThickness : " + MaterialThickness;
	}
}
