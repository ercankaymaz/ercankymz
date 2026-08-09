using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camStrategy : buSerilization
{
	public bool UseTangentLimit = true;

	public bool UseLimitAngleForOtherPlane = false;

	public double AngleLimitXY = 30.0;

	public double AngleLimitXZ = 30.0;

	public double AngleLimitYZ = 30.0;

	public double AngleLimit = 30.0;

	public double MinTangentValue = -360.0;

	public double MaxTangentValue = 360.0;

	public double TangentOffset = 0.0;

	public double ContantTangent = 0.0;

	public double OverrideC = 0.0;

	public bool UseContantTangent = false;

	public bool OverrideCEnable = false;

	public bool ArcToPoints = false;

	public bool StartFromAnyPoint = false;

	public bool OpenContourTwoDirectionCut = true;

	public static List<string> Captions = new List<string>();

	public camStrategy()
	{
	}

	public camStrategy(double anglelimit)
	{
		AngleLimit = anglelimit;
	}

	public camStrategy(camStrategy Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
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

	public override string ToString()
	{
		return "AngleLimit: " + AngleLimit;
	}
}
