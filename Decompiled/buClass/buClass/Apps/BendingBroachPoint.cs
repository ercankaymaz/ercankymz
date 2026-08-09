using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingBroachPoint : BendingItem
{
	public double A = 0.0;

	public UpDownLeftRightDirectionType Direction = UpDownLeftRightDirectionType.Up;

	public BendingBroachPoint()
	{
	}

	public BendingBroachPoint(BendingBroachPoint data)
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

	public BendingBroachPoint(double x)
	{
		X = x;
	}

	public BendingBroachPoint(double x, UpDownLeftRightDirectionType dir, double a)
	{
		X = x;
		Direction = dir;
		A = a;
	}

	public override string ToString()
	{
		return "Broach->   X: " + X + "  A: " + A + " ; Dir: " + Direction.ToString() + " , Part Index: " + PartIndex;
	}
}
