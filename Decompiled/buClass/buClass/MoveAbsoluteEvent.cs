using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class MoveAbsoluteEvent : buSerilization
{
	public double PointX = 0.0;

	public double PointY = 0.0;

	public ContentAlignment Location = ContentAlignment.MiddleCenter;

	public static List<string> Captions = new List<string>();

	public MoveAbsoluteEvent()
	{
	}

	public MoveAbsoluteEvent(MoveAbsoluteEvent data)
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
}
