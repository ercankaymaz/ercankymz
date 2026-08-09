using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleDrillPars : buSerilization5
{
	public double HoleSafeDistance = 150.0;

	public double HoleDiameter = 50.0;

	public double PlungeSpeed = 30.0;

	public double HoleDepth = 8.0;

	public double HoleScanXStep = 50.0;

	public double HoleScanYStep = 50.0;

	public double HoleZDepthStep = 40.0;

	public double HoleBottomOffset = 30.0;

	public double HoleTopOffset = 10.0;

	public double HoleContourOffset = 0.0;

	public static List<string> Captions = new List<string>();

	public marbleDrillPars()
	{
	}

	public marbleDrillPars(marbleDrillPars data)
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

	public static void Copy(marbleDrillPars Source, ref marbleDrillPars Target)
	{
		Target = new marbleDrillPars(Source);
	}

	public override string ToString()
	{
		return "HoleDiameter : " + HoleDiameter;
	}
}
