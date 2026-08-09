using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class Numbering : buSerilization
{
	public double Start = 1.0;

	public double Step = 1.0;

	public double Max = -1.0;

	public bool Enable = true;

	public Numbering()
	{
	}

	public Numbering(Numbering data)
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

	public Numbering(double start, double step, double max, bool enable)
	{
		Start = start;
		Step = step;
		Max = max;
		Enable = enable;
	}
}
