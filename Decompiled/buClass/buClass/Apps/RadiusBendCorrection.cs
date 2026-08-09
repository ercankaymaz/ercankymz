using System.Reflection;

namespace buClass.Apps;

public class RadiusBendCorrection
{
	public double Radius;

	public double Degree;

	public double PositiveRatio;

	public double NegativeRatio;

	public RadiusBendCorrection()
	{
	}

	public RadiusBendCorrection(double Radius_, double Degree_, double PositiveRatio_, double NegativeRatio_)
	{
		Radius = Radius_;
		Degree = Degree_;
		PositiveRatio = PositiveRatio_;
		NegativeRatio = NegativeRatio_;
	}

	public RadiusBendCorrection(RadiusBendCorrection data)
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
		return "Rad: " + Radius.ToString("f2") + " - Degree: " + Degree.ToString("f2") + " - Rt+: " + PositiveRatio.ToString("f6") + " - Rt-: " + NegativeRatio.ToString("f6");
	}
}
