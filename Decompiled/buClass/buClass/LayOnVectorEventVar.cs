using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class LayOnVectorEventVar : buSerilization
{
	public double Angle = 0.0;

	public Vec3D DirVector = new Vec3D(1.0, 0.0, 0.0);

	public static List<string> Captions = new List<string>();

	public LayOnVectorEventVar()
	{
	}

	public LayOnVectorEventVar(LayOnVectorEventVar data)
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
