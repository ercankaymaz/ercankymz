using System.Reflection;

namespace buClass;

public class MinMidMaxRange : buSerilization
{
	public double Min = 0.0;

	public double Max = 0.0;

	public double Mid = 0.0;

	public double Range = 0.0;

	public MinMidMaxRange()
	{
	}

	public MinMidMaxRange(double min, double mid, double max, double range)
	{
		Min = min;
		Mid = mid;
		Max = max;
		Range = range;
	}

	public MinMidMaxRange(MinMidMaxRange data)
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
		return "Min: " + Min.ToString("f2") + " - Mid: " + Mid.ToString("f2") + " - Max: " + Max.ToString("f2") + " - Range: " + Range.ToString("f2");
	}
}
