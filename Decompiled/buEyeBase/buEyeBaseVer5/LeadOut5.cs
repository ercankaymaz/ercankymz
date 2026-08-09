using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class LeadOut5 : buSerilization5
{
	public bool Enable = false;

	public double TangentAngle = 90.0;

	public LeadInOutType LeadType = LeadInOutType.Arc;

	public double ArcRadius = 10.0;

	public double ArcSweepAngle = 90.0;

	public double Length = 10.0;

	public double ExtendLength = 0.0;

	public ClockDirectionType ClockDir = ClockDirectionType.CW;

	public static List<string> Captions = new List<string>();

	public LeadOut5()
	{
	}

	public LeadOut5(bool enable, double tangentAngle, LeadInOutType type, double len)
	{
		Enable = enable;
		TangentAngle = tangentAngle;
		LeadType = type;
		Length = len;
	}

	public LeadOut5(bool enable, double tangentAngle, LeadInOutType type, double len, double arcRad, double arcSweepAng)
	{
		Enable = enable;
		TangentAngle = tangentAngle;
		LeadType = type;
		Length = len;
		ArcRadius = arcRad;
		ArcSweepAngle = arcSweepAng;
	}

	public LeadOut5(LeadOut5 data)
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
