using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class DirectionArrowSetting : buSerilization5
{
	public bool Enable = false;

	public int ArrowPointCount = 0;

	public double MinLength = 0.0;

	public double ArrowLength = 2.0;

	public double ArrowAngle = 20.0;

	public DirectionArrowSetting()
	{
	}

	public DirectionArrowSetting(DirectionArrowSetting data)
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
		return "ArrowPointCount: " + ArrowPointCount + " - MinLength: " + MinLength;
	}
}
