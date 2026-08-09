using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingPerfoCombiPoint : BendingItem
{
	public double Z = 0.0;

	public double Depth = 0.0;

	public double Width = 0.0;

	public BendingPerfoCombiPoint()
	{
	}

	public BendingPerfoCombiPoint(BendingPerfoCombiPoint data)
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

	public BendingPerfoCombiPoint(double x, double z)
	{
		X = x;
		Z = z;
	}

	public override string ToString()
	{
		return "PerfoCombi->   X: " + X + " ; Z: " + Z + " , Part Index: " + PartIndex;
	}
}
