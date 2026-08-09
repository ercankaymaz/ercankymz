using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class PointABC : buSerilization5
{
	public double A = 0.0;

	public double B = 0.0;

	public double C = 0.0;

	public PointABC()
	{
	}

	public PointABC(double a, double b, double c)
	{
		A = a;
		B = b;
		C = c;
	}

	public PointABC(PointABC data)
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
		return "A: " + A + " ; B: " + B + " ; C: " + C;
	}
}
