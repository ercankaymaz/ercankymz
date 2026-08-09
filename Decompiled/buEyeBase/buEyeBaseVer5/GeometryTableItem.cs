using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class GeometryTableItem : buSerilization5
{
	public double DiameterMin = 0.0;

	public double DiameterMax = 500.0;

	public double DevideLength = 10.0;

	public double RegenDeviation = 0.1;

	public GeometryTableItem()
	{
	}

	public GeometryTableItem(double diameterMin, double diameterMax, double devideLength, double regenDeviation)
	{
		DiameterMax = diameterMax;
		DiameterMin = diameterMin;
		DevideLength = devideLength;
		RegenDeviation = regenDeviation;
	}

	public GeometryTableItem(GeometryTableItem data)
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
		return "DiameterMin: " + DiameterMin + " - DiameterMax: " + DiameterMax + " - DevideLength: " + DevideLength + " - RegenDeviation: " + RegenDeviation;
	}
}
