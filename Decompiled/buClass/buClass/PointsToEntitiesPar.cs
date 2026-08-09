using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class PointsToEntitiesPar : buSerilization
{
	public double AngleLimit = 170.0;

	public double LengthFilter = 0.0;

	public double LengthDifferanceLimit = 1.5;

	public double RadiusDifferanceWithPreRadius = 3.0;

	public bool CircleToArc = true;

	public PointsToEntitiesPar()
	{
	}

	public PointsToEntitiesPar(double angleLimit, double lengthFilter, double lengthDiffLimit)
	{
		AngleLimit = angleLimit;
		LengthDifferanceLimit = lengthDiffLimit;
		LengthFilter = lengthFilter;
	}

	public PointsToEntitiesPar(PointsToEntitiesPar data)
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
