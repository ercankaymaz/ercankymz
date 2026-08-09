using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleChamferBothSideData : buSerilization5
{
	public bool Enable = false;

	public bool TopEnable = false;

	public bool BottomEnable = false;

	public double TopHeight = 10.0;

	public double TopAngle = 45.0;

	public double BottomHeight = 0.0;

	public double BottomAngle = 0.0;

	public static List<string> Captions = new List<string>();

	public marbleChamferBothSideData()
	{
	}

	public marbleChamferBothSideData(marbleChamferBothSideData data)
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
		return "Enable : " + Enable + " , Top : " + TopEnable + " , BottomEnable : " + BottomEnable + " , TopAngle : " + TopAngle + " , BottomAngle : " + BottomAngle;
	}
}
