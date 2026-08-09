using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class AnalogInputData : buSerilization
{
	public int Value = 0;

	public string Name = "";

	public double ValueVolt = 0.0;

	public string Caption = "";

	public AnalogInputData()
	{
	}

	public AnalogInputData(string name)
	{
		Name = name;
	}

	public AnalogInputData(AnalogInputData data)
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
		return "Name: " + Name + " =  " + Value + "  (" + ValueVolt.ToString("f2") + ")";
	}
}
