using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camOperationEnable : buSerilization
{
	public bool Height = true;

	public bool Direction = true;

	public static List<string> Captions = new List<string>();

	public camOperationEnable()
	{
	}

	public camOperationEnable(bool height, bool direction)
	{
		Height = height;
		Direction = direction;
	}

	public camOperationEnable(camOperationEnable Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
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
		return "Height: " + Height + " , Direction: " + Direction;
	}
}
