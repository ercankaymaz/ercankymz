using System;

namespace buClass;

[Serializable]
public class ValuesItem : buSerilization
{
	public string Name = "";

	public bool Bool1 = false;

	public bool Bool2 = false;

	public bool Bool3 = false;

	public bool Bool4 = false;

	public double Value1 = 0.0;

	public double Value2 = 0.0;

	public double Value3 = 0.0;

	public double Value4 = 0.0;

	public double Value5 = 0.0;

	public double Value6 = 0.0;

	public ValuesItem()
	{
	}

	public ValuesItem(ValuesItem data)
	{
		Bool1 = data.Bool1;
		Bool2 = data.Bool2;
		Bool3 = data.Bool3;
		Bool4 = data.Bool4;
		Value1 = data.Value1;
		Value2 = data.Value2;
		Value3 = data.Value3;
		Value4 = data.Value4;
		Value5 = data.Value5;
		Value6 = data.Value6;
		Name = data.Name;
	}

	public ValuesItem(string name, double value1)
	{
		Name = name;
		Value1 = value1;
	}

	public ValuesItem(string name, bool bool1, double value1, double value2)
	{
		Name = name;
		Bool1 = bool1;
		Value1 = value1;
		Value2 = value2;
	}

	public ValuesItem(string name, bool bool1, double value1, double value2, double value3)
	{
		Name = name;
		Bool1 = bool1;
		Value1 = value1;
		Value2 = value2;
		Value3 = value3;
	}

	public ValuesItem(string name, bool bool1, double value1, double value2, double value3, double value4)
	{
		Name = name;
		Bool1 = bool1;
		Value1 = value1;
		Value2 = value2;
		Value3 = value3;
		Value4 = value4;
	}

	public ValuesItem(string name, bool bool1, bool bool2, double value1, double value2, double value3, double value4)
	{
		Name = name;
		Bool1 = bool1;
		Bool2 = bool2;
		Value1 = value1;
		Value2 = value2;
		Value3 = value3;
		Value4 = value4;
	}

	public override string ToString()
	{
		string text = "";
		if (Name.Length > 0)
		{
			text = text + Name + ": ";
			text = text + "V1: " + Value1 + " - V2: " + Value2 + " - V3: " + Value2 + " - V4: " + Value2 + " - B1: " + Bool1 + " - B2: " + Bool2;
		}
		return base.ToString();
	}
}
