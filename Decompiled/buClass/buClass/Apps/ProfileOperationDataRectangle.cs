using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataRectangle : buSerilization
{
	public double RectangleWidth = 20.0;

	public double RectangleHeight = 20.0;

	public double RectangleAngle = 0.0;

	public Color RectangleColor = Color.Blue;

	public double RectangleThickness = 1.0;

	public ProfileOperationDataRectangle()
	{
	}

	public ProfileOperationDataRectangle(ProfileOperationDataRectangle data)
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
		return "Width : " + RectangleWidth + " - Height : " + RectangleHeight;
	}
}
