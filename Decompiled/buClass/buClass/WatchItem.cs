using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class WatchItem : buSerilization
{
	public string Name = "";

	public string NameShort = "";

	public string Explanation = "";

	public string Program = "";

	public string Task = "";

	public double Value = 0.0;

	public string ValueString = "";

	public double MaxValue = double.MinValue;

	public double MinValue = double.MaxValue;

	public double AvarageValue = 0.0;

	public string NewValue = "";

	public int Counter = 0;

	public string Status = "";

	public bool CommStatus = false;

	public bool UseJustName = false;

	public VariableType VarType = VariableType.LREAL;

	public static List<string> Captions = new List<string>();

	public WatchItem()
	{
	}

	public WatchItem(string Name)
	{
		this.Name = Name;
	}

	public WatchItem(WatchItem item)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(item, ref CopiedClass);
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
		return Name;
	}
}
