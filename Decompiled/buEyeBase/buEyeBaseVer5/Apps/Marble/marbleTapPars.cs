using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleTapPars : buSerilization5
{
	public double TapDiameter = 30.0;

	public double TapLeftDiameter = 30.0;

	public double TapRightDiameter = 30.0;

	public double TapDepth = 5.0;

	public double TapLeftDepth = 5.0;

	public double TapRightDepth = 5.0;

	public double TapLeftXOffset = -20.0;

	public double TapLeftYOffset = 0.0;

	public double TapRightXOffset = 20.0;

	public double TapRightYOffset = 0.0;

	public bool LeftEnable = false;

	public bool RightEnable = false;

	public static List<string> Captions = new List<string>();

	public marbleTapPars()
	{
	}

	public marbleTapPars(marbleTapPars data)
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

	public override string ToString()
	{
		return "TapDiameter" + TapDiameter;
	}
}
