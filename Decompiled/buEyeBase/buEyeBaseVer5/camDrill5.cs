using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class camDrill5 : buSerilization5
{
	public bool Enable = false;

	public bool PeckMode = false;

	public bool PeckFullRetract = false;

	public bool IncremantalRotation = true;

	public double StartHeight = 10.0;

	public double EndHeight = 0.0;

	public double StartAngle = 0.0;

	public double EndAngle = 360.0;

	public double PeckDepth = 2.0;

	public double PeckMinRetractDistance = 2.0;

	public static List<string> Captions = new List<string>();

	public camDrill5()
	{
	}

	public camDrill5(camDrill5 distance)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(distance, ref CopiedClass);
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
		return "Enable: " + Enable;
	}
}
