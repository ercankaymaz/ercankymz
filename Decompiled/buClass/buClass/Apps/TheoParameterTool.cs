using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TheoParameterTool : buSerilization
{
	public double No = 0.0;

	public string Name = "";

	public double Radius = 0.0;

	public double Mode1OverrideY = 100.0;

	public double MaxYPosition = 50.0;

	public List<TheoParameterItem> CornerBendingList = new List<TheoParameterItem>();

	public static List<string> Captions = new List<string>();

	public TheoParameterTool()
	{
	}

	public TheoParameterTool(TheoParameterTool data)
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
		CornerBendingList.Clear();
		for (int j = 0; j <= data.CornerBendingList.Count - 1; j++)
		{
			CornerBendingList.Add(new TheoParameterItem(data.CornerBendingList[j]));
		}
	}

	public override string ToString()
	{
		return "No: " + No;
	}
}
