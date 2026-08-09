using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class WrapShapeParameter : buSerilization
{
	public double LengthFor360Degree = 100.0;

	public double Width = 20.0;

	public VectorType CenterVector = VectorType.YVector;

	public WrapShapeParameter()
	{
	}

	public WrapShapeParameter(WrapShapeParameter data)
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
