using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TheoSetStartOffset : buSerilization
{
	public double StartOffset = 0.0;

	public TheoSetStartOffset()
	{
	}

	public TheoSetStartOffset(TheoSetStartOffset data)
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
