using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class VectorFromTriangles : buSerilization
{
	public double ReferanceZ = 0.0;

	public double Resolution = 1.0;

	public VectorType Direction = VectorType.XVector;

	public VectorFromTriangles()
	{
	}

	public VectorFromTriangles(VectorFromTriangles data)
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
