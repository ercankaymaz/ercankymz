using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingParameterItem : buSerilization
{
	public double PositivePosition = 0.0;

	public double NegativePosition = 0.0;

	public double Angle = 0.0;

	public BendingParameterItem()
	{
	}

	public BendingParameterItem(double angle, double posposition, double negposition)
	{
		Angle = angle;
		PositivePosition = posposition;
		NegativePosition = negposition;
	}

	public BendingParameterItem(BendingParameterItem data)
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
		return "Angle : " + Angle + " ; PositivePosition (+) : " + PositivePosition + " ; NegativePosition (-) : " + NegativePosition;
	}
}
