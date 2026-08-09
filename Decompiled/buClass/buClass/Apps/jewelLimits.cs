using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class jewelLimits : buSerilization
{
	public double MinX = 0.0;

	public double MaxX = 0.0;

	public double MinY = 0.0;

	public double MaxY = 0.0;

	public double MinZ = 0.0;

	public double MaxZ = 0.0;

	public double MinA = 0.0;

	public double MaxA = 0.0;

	public double MinB = 0.0;

	public double MaxB = 0.0;

	public double MinC = 0.0;

	public double MaxC = 0.0;

	public jewelLimits()
	{
	}

	public jewelLimits(jewelLimits data)
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
		return "Min X: " + MinX;
	}
}
