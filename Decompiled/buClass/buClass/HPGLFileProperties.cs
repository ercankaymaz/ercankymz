using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class HPGLFileProperties : buSerilization
{
	public int RepeatCount = 1;

	public bool UseFLStart = true;

	public bool UseFLEnd = true;

	public bool UseFFEnd = true;

	public double XMultiply = 1.0;

	public double YMultiply = 1.0;

	public HPGLFileProperties()
	{
	}

	public HPGLFileProperties(HPGLFileProperties data)
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
