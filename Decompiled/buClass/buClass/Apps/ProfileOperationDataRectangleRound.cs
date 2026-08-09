using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataRectangleRound : buSerilization
{
	public double RoundRectangleWidth = 20.0;

	public double RoundRectangleHeight = 20.0;

	public double RoundRectangleRadius = 2.0;

	public double RoundRectangleAngle = 0.0;

	public Color RoundRectangleColor = Color.Blue;

	public double RoundRectangleThickness = 1.0;

	public ProfileOperationDataRectangleRound()
	{
	}

	public ProfileOperationDataRectangleRound(ProfileOperationDataRectangleRound data)
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
		return "Width : " + RoundRectangleWidth + " - Height : " + RoundRectangleHeight + " - Radius : " + RoundRectangleRadius;
	}
}
