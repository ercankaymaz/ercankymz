using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class LeadInOutEnable : buSerilization
{
	public bool TangentAngle = true;

	public bool LeadType = true;

	public bool ArcRadius = true;

	public bool ArcSweepAngle = true;

	public bool Length = true;

	public static List<string> Captions = new List<string>();

	public LeadInOutEnable()
	{
	}

	public LeadInOutEnable(bool tangentangle, bool leadtype, bool arcradius, bool arcsweepang, bool length)
	{
		TangentAngle = tangentangle;
		LeadType = leadtype;
		ArcRadius = arcradius;
		ArcSweepAngle = arcsweepang;
		Length = length;
	}

	public LeadInOutEnable(LeadInOutEnable Data)
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
		return "LeadType: " + LeadType + " , Length: " + Length + " , TangentAngle: " + TangentAngle + " , ArcRadius: " + ArcRadius + " , ArcSweepAngle: " + ArcSweepAngle;
	}
}
