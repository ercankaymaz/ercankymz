using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class DistanceData : buSerilization
{
	public double Length = 0.0;

	public double dX = 0.0;

	public double dY = 0.0;

	public double dZ = 0.0;

	public double AngleXY = 0.0;

	public double AngleXZ = 0.0;

	public double AngleYZ = 0.0;

	public DistanceData()
	{
	}

	public DistanceData(DistanceData data)
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
		return "Length :" + Length + " - dX : " + dX + " - dY : " + dY + " - dZ : " + dZ;
	}
}
