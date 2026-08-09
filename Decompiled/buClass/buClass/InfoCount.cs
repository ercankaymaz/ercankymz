using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class InfoCount : buSerilization
{
	public string Info;

	public double Count;

	public InfoCount()
	{
	}

	public InfoCount(double count, string info)
	{
		Count = count;
		Info = info;
	}

	public InfoCount(InfoCount size)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(size, ref CopiedClass);
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
		return "Info " + Info.ToString() + " - Count: " + Count;
	}
}
