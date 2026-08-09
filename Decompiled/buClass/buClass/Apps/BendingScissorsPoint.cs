using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingScissorsPoint : BendingItem
{
	public double C = 0.0;

	public UpDownLeftRightDirectionType Direction = UpDownLeftRightDirectionType.Up;

	public BendingScissorsPoint()
	{
	}

	public BendingScissorsPoint(BendingScissorsPoint data)
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

	public BendingScissorsPoint(double x, int mode)
	{
		X = x;
		Mode = mode;
	}

	public override string ToString()
	{
		return "Scissors->   X: " + X + " ; Mode: " + Mode + " ; Dir: " + Direction.ToString() + " , Part Index: " + PartIndex;
	}
}
