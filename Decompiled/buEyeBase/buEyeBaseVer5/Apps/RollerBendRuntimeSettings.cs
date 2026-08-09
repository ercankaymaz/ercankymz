using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class RollerBendRuntimeSettings : buSerilization5
{
	public int SimStep = 1;

	public bool StepRun = false;

	public double CircleDiameter = 150.0;

	public double CircleLength = 1000.0;

	public double CircleThickness = 6.0;

	public double RectangleRadius = 300.0;

	public double RectangleWidth = 1000.0;

	public double RectangleHeight = 800.0;

	public double RectangleLength = 1000.0;

	public double RectangleThickness = 6.0;

	public RollerBendRuntimeSettings()
	{
	}

	public RollerBendRuntimeSettings(RollerBendRuntimeSettings data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
