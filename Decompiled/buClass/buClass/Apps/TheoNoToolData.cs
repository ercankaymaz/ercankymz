using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TheoNoToolData
{
	public double Radius = 0.0;

	public double MaleTool = 0.0;

	public double FemaleTool = 0.0;

	public double YPosition = 0.0;

	public string Explanation = "";

	public static List<string> Captions = new List<string>();

	public TheoNoToolData()
	{
	}

	public TheoNoToolData(TheoNoToolData data)
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
		return "Radius: " + Radius + " - MaleTool: " + MaleTool + " - FemaleTool: " + FemaleTool + " - Y Position: " + YPosition;
	}
}
