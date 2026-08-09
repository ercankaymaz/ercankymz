using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class RotateVectorEventVar : buSerilization
{
	public double Angle = 0.0;

	public VectorType Axis = VectorType.XVector;

	public bool DeleteOriginal = false;

	public static List<string> Captions = new List<string>();

	public RotateVectorEventVar()
	{
	}

	public RotateVectorEventVar(RotateVectorEventVar data)
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
