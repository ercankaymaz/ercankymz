using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataCircle : buSerilization
{
	public double CircleDiameter = 10.0;

	public Color CircleColor = Color.Blue;

	public double CircleThickness = 1.0;

	public ProfileOperationDataCircle()
	{
	}

	public ProfileOperationDataCircle(ProfileOperationDataCircle data)
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
		return "Dia : " + CircleDiameter;
	}
}
