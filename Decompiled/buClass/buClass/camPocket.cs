using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camPocket : buSerilization
{
	public bool Enable = false;

	public bool UsePoints = false;

	public static List<string> Captions = new List<string>();

	public camPocket()
	{
	}

	public camPocket(camPocket distance)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(distance, ref CopiedClass);
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
		return "Enable: " + Enable;
	}
}
