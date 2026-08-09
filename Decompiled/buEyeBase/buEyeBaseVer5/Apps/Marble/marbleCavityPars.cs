using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCavityPars : buSerilization5
{
	public double CavityLength = 500.0;

	public double CavityHeight = 10.0;

	public double CavityDepth = 5.0;

	public double CavityAngle = 0.0;

	public double CavitySpace = 20.0;

	public int CavityCount = 1;

	public bool CavityZigzagMode = true;

	public static List<string> Captions = new List<string>();

	public marbleCavityPars()
	{
	}

	public marbleCavityPars(marbleCavityPars data)
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
		return "Len" + CavityLength;
	}
}
