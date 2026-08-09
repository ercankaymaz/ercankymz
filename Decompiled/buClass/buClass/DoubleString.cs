using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class DoubleString : buSerilization
{
	public double Value = 0.0;

	public string Str = "";

	public DoubleString()
	{
	}

	public DoubleString(double val, string str)
	{
		Value = val;
		Str = str;
	}

	public DoubleString(DoubleString data)
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

	public override string ToString()
	{
		return "Val : " + Value + " - Str : " + Str.ToString();
	}
}
