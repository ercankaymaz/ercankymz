using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSlatData : buSerilization5
{
	public bool Enable = false;

	public double Width = 0.0;

	public double StartAngle = 0.0;

	public double EndAngle = 0.0;

	public int indexEntitiy = -1;

	public int ItemID = -1;

	public int StripID = -1;

	public int EdgeID = -1;

	public int CamID = -1;

	public static List<string> Captions = new List<string>();

	public marbleSlatData()
	{
	}

	public marbleSlatData(marbleSlatData data)
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
		string text = "Enable : " + Enable + " , Width : " + Width + " , StartAngle : " + StartAngle + " , EndAngle : " + EndAngle;
		if (ItemID >= 0)
		{
			text = text + " Item: " + ItemID;
		}
		if (CamID >= 0)
		{
			text = text + " Cam: " + CamID;
		}
		if (EdgeID >= 0)
		{
			text = text + " Edge: " + EdgeID;
		}
		if (StripID >= 0)
		{
			text = text + " Strip: " + StripID;
		}
		return text;
	}
}
