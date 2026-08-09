using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxRuntimeActive : buSerilization
{
	public double actualPosition;

	public double actualVelocity;

	public double actualCurrent;

	public double actualFollowError;

	public double actualGCodeOffset;

	public double actualOffsetedPosition;

	public double actualAcc;

	public double actualJerk;

	public double actualRpm;

	public double distanceToGo;

	public int CommState;

	public int State;

	public CodesysAxRuntimeActive()
	{
	}

	public CodesysAxRuntimeActive(CodesysAxRuntimeActive data)
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
		return "Pos: " + actualPosition + " , actualGCodeOffset: " + actualGCodeOffset;
	}
}
