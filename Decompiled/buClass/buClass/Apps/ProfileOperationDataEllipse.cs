using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataEllipse : buSerilization
{
	public double EllipseWidth = 20.0;

	public double EllipseHeight = 20.0;

	public double EllipseAngle = 0.0;

	public Color EllipseColor = Color.Blue;

	public double EllipseThickness = 1.0;

	public ProfileOperationDataEllipse()
	{
	}

	public ProfileOperationDataEllipse(ProfileOperationDataEllipse data)
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
		return "Width : " + EllipseWidth + " - EllipseHeight : " + EllipseHeight;
	}
}
