using System.Reflection;

namespace buClass;

public class MinMax : buSerilization
{
	public double Min = 0.0;

	public double Max = 0.0;

	public MinMax()
	{
	}

	public MinMax(double min, double max)
	{
		Min = min;
		Max = max;
	}

	public MinMax(MinMax data)
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
		return "Min: " + Min.ToString("f2") + " - Max: " + Max.ToString("f2");
	}
}
