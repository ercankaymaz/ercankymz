using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCutRemainMaterial : buSerilization5
{
	public double MaterialCutWidth = 2000.0;

	public double MaterialCutHeight = 1000.0;

	public double HorizontalOffset = 0.0;

	public double MaterialHorizontalMinDistance = 200.0;

	public double MaterialVerticalMinDistance = 200.0;

	public double VerticalOffset = 0.0;

	public bool HorizontalCutEnable = true;

	public bool VerticalCutEnable = true;

	public bool PauseAfterCut = false;

	public bool UseMaterialData = false;

	public static List<string> Captions = new List<string>();

	public marbleCutRemainMaterial()
	{
	}

	public marbleCutRemainMaterial(marbleCutRemainMaterial data)
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
}
