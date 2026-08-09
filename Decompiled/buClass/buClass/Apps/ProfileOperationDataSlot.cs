using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataSlot : buSerilization
{
	public double SlotWidth = 50.0;

	public double SlotDiameter = 10.0;

	public double SlotAngle = 0.0;

	public Color SlotColor = Color.Blue;

	public double SlotThickness = 1.0;

	public ProfileOperationDataSlot()
	{
	}

	public ProfileOperationDataSlot(ProfileOperationDataSlot data)
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
		return "Width : " + SlotWidth + " - Dia : " + SlotDiameter;
	}
}
