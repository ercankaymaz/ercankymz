using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class PlaneAngle : buSerilization5
{
	public double AngleXY = 0.0;

	public double AngleXZ = 0.0;

	public double AngleYZ = 0.0;

	public PlaneAngle()
	{
	}

	public PlaneAngle(PlaneAngle data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "XY: " + AngleXY.ToString("f3") + " XZ: " + AngleXZ.ToString("f3") + " YZ: " + AngleYZ.ToString("f3");
	}
}
