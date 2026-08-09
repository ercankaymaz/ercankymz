using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class BreakEntitiesByRefLineEventVar : buSerilization
{
	public double PersentageOfBoxSize = 50.0;

	public double SortResolution = 0.1;

	public TopBottomType RefDirection = TopBottomType.Bottom;

	public BreakEntitiesByRefLineEventVar()
	{
	}

	public BreakEntitiesByRefLineEventVar(BreakEntitiesByRefLineEventVar data)
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
