using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class MoveScaleRotateStretchVar : buSerilization
{
	public double MoveX = 1.0;

	public double MoveY = 1.0;

	public double MoveZ = 1.0;

	public double Rotate = 5.0;

	public double Scale = 1.0;

	public double StretchX = 1.0;

	public double StretchY = 1.0;

	public double XConstantValue = 0.0;

	public double YConstantValue = 0.0;

	public bool XConstantEnable = false;

	public bool YConstantEnable = false;

	public double RangeMinX = 0.0;

	public double RangeMaxX = 0.0;

	public double RangeMinY = 0.0;

	public double RangeMaxY = 0.0;

	public static List<string> Captions = new List<string>();

	public MoveScaleRotateStretchVar()
	{
	}

	public MoveScaleRotateStretchVar(MoveScaleRotateStretchVar data)
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
