using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TheoParameter : buSerilization
{
	public string Name = "";

	public string FileName = "";

	public double OverrideY = 100.0;

	public double Pt = 0.0;

	public List<TheoParameterTool> Tools = new List<TheoParameterTool>();

	public static List<string> Captions = new List<string>();

	public TheoParameter()
	{
	}

	public TheoParameter(TheoParameter data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		Tools.Clear();
		for (int j = 0; j <= data.Tools.Count - 1; j++)
		{
			Tools.Add(new TheoParameterTool(data.Tools[j]));
		}
	}

	public override string ToString()
	{
		return "Ratio: " + OverrideY;
	}
}
