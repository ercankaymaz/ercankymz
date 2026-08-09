using System.Reflection;

namespace buClass.Apps;

public class AngleBendCorrection
{
	public double Angle;

	public double LimitDegree;

	public double LowPositiveRatio;

	public double LowNegativeRatio;

	public double HighPositiveRatio;

	public double HighNegativeRatio;

	public AngleBendCorrection()
	{
	}

	public AngleBendCorrection(double Angle_, double LimitDegree_, double LowPositiveRatio_, double LowNegativeRatio_, double HighPositiveRatio_, double HighNegativeRatio_)
	{
		Angle = Angle_;
		LimitDegree = LimitDegree_;
		LowPositiveRatio = LowPositiveRatio_;
		LowNegativeRatio = LowNegativeRatio_;
		HighPositiveRatio = HighPositiveRatio_;
		HighNegativeRatio = HighNegativeRatio_;
	}

	public AngleBendCorrection(AngleBendCorrection data)
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
		return "Ang: " + Angle.ToString("f2") + " - Limit: " + LimitDegree.ToString("f2") + " - Low Rt+: " + LowPositiveRatio.ToString("f4") + " - Low Rt-: " + LowNegativeRatio.ToString("f4") + " - High Rt+: " + HighPositiveRatio.ToString("f4") + " - High Rt-: " + HighNegativeRatio.ToString("f4");
	}
}
