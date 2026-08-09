using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingBendCut : BendingItem
{
	public BendingBendCut()
	{
	}

	public BendingBendCut(BendingBendCut data)
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

	public BendingBendCut(double x)
	{
		X = x;
	}

	public override string ToString()
	{
		return "BendCut->   X: " + X + " , Part Index: " + PartIndex;
	}
}
