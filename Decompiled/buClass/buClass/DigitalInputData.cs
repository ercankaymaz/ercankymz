using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class DigitalInputData : buSerilization
{
	public bool Status = false;

	public string Name = "";

	public string Caption = "";

	public string FullAddress = "";

	public bool Invert = false;

	public int SourceIndex = -1;

	public DigitalInputData()
	{
	}

	public DigitalInputData(string name)
	{
		Name = name;
	}

	public DigitalInputData(string name, string caption, int sourceindex, bool inverted)
	{
		Name = name;
		Caption = caption;
		SourceIndex = sourceindex;
		Invert = inverted;
	}

	public DigitalInputData(string name, string caption, int sourceindex, bool inverted, string fulladdrsss)
	{
		Name = name;
		Caption = caption;
		SourceIndex = sourceindex;
		Invert = inverted;
		FullAddress = fulladdrsss;
	}

	public DigitalInputData(DigitalInputData data)
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
		string text = Name + " : " + Status;
		if (SourceIndex >= 0)
		{
			text = text + " - Index: " + SourceIndex;
		}
		if (Invert)
		{
			text = text + " - Invert: " + Invert;
		}
		return text;
	}
}
