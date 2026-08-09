using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingTrimcutPoint : BendingItem
{
	public double W = 0.0;

	public double C = 0.0;

	public int Closed = 0;

	public bool TrimcutPress = false;

	public UpDownType Direction = UpDownType.Up;

	public TrimcutSequence Sequence = TrimcutSequence.Start;

	public BendingTrimcutPoint()
	{
	}

	public BendingTrimcutPoint(BendingTrimcutPoint data)
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

	public BendingTrimcutPoint(double x, UpDownType dir, TrimcutSequence sequence)
	{
		X = x;
		Direction = dir;
		Sequence = sequence;
	}

	public override string ToString()
	{
		return "Trimcut->   X: " + X + " ; Dir: " + Direction.ToString() + " , Part Index: " + PartIndex;
	}
}
