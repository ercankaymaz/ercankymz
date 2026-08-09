using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class RadiusParameterItem : buSerilization
{
	public double RatioPositive = 0.0;

	public double RatioNegative = 0.0;

	public double Radius = 0.0;

	public double Correction = 1.0;

	public RadiusParameterItem()
	{
	}

	public RadiusParameterItem(double Radius_, double RatioPositive_, double RatioNegative_)
	{
		RatioPositive = RatioPositive_;
		RatioNegative = RatioNegative_;
		Radius = Radius_;
	}

	public RadiusParameterItem(double Radius_, double RatioPositive_, double RatioNegative_, double Correction_)
	{
		RatioPositive = RatioPositive_;
		RatioNegative = RatioNegative_;
		Radius = Radius_;
		Correction = Correction_;
	}

	public RadiusParameterItem(RadiusParameterItem data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
		return "Radius : " + Radius + " ; Ratio (+) : " + RatioPositive + " ; Ratio (-) : " + RatioNegative + " ; Corr : " + Correction;
	}
}
