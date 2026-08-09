using System.Collections.Generic;
using System.Reflection;

namespace buClass;

public class RasterToVectorVar : buSerilization
{
	public int ColorToBWThreshold = 75;

	public int DPI = 0;

	public double SimplifyTolerance = 1.0;

	public double SplineToleranca = 1.0;

	public static List<string> Captions = new List<string>();

	public RasterToVectorVar()
	{
	}

	public RasterToVectorVar(RasterToVectorVar data)
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
}
