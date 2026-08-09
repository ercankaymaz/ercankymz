using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CounterItem : buSerilization
{
	public string Name = "";

	public string Address = "";

	public double ActualCount = 0.0;

	public double PreviousCount = 0.0;

	public double Limit = 0.0;

	public double TotalCount = 0.0;

	public bool isValueTime = false;

	public DateTime ResetDate = DateTime.Now;

	public static List<string> Captions = new List<string>();

	public CounterItem()
	{
	}

	public CounterItem(string Name)
	{
		this.Name = Name;
	}

	public CounterItem(CounterItem item)
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
		return Address + " : " + ActualCount;
	}
}
