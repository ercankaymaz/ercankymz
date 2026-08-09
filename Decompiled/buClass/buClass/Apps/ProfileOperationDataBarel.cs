using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataBarel : buSerilization
{
	public double BarrelLength = 50.0;

	public double BarrelDiameter = 16.0;

	public double BarrelWidth = 10.0;

	public double BarrelAngle = 0.0;

	public Color BarrelColor = Color.Blue;

	public double BarrelThickness = 1.0;

	public ProfileOperationDataBarel()
	{
	}

	public ProfileOperationDataBarel(ProfileOperationDataBarel data)
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
		return "Len : " + BarrelLength + " - Dia : " + BarrelDiameter + " - Width : " + BarrelWidth;
	}
}
