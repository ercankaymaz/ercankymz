using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class DepthPositionOptions : buSerilization5
{
	public double MinThickness = 0.2;

	public double MaxThickness = 10.0;

	public bool AreaCalculation = false;

	public int AreaStep = 10;

	public double ConnectGap = 0.5;

	public DepthPositionOptions()
	{
	}

	public DepthPositionOptions(double minThickness, double maxThickness, bool areacalc, int areastep, double connectGap)
	{
		MinThickness = minThickness;
		MaxThickness = maxThickness;
		AreaCalculation = areacalc;
		AreaStep = areastep;
		ConnectGap = connectGap;
	}

	public DepthPositionOptions(DepthPositionOptions data)
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
		return "MinThickness: " + MinThickness + " - MaxThickness: " + MaxThickness;
	}
}
