using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingBendPoint : BendingItem
{
	public double C = 0.0;

	public double R = 0.0;

	public double ShapeModeOverride = 100.0;

	public BendingBendPoint()
	{
	}

	public BendingBendPoint(BendingBendPoint data)
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

	public BendingBendPoint(double x, double c)
	{
		X = x;
		C = c;
	}

	public override string ToString()
	{
		return "Bend->  X: " + X + " , C: " + C + " , R: " + R + " , Part Index: " + PartIndex;
	}
}
