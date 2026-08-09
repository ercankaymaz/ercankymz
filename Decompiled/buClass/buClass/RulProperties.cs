using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class RulProperties : buSerilization
{
	public string Version = "";

	public string Author = "";

	public string Date = "";

	public string Time = "";

	public string Unit = "";

	public string RuleTable = "";

	public string SampleSize = "";

	public int NumberOfSize = 0;

	public List<string> SizeList = new List<string>();

	public List<RulRule> RuleList = new List<RulRule>();

	public RulProperties()
	{
	}

	public RulProperties(RulProperties data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
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
		RuleList.Clear();
		RuleList.Clear();
		for (int j = 0; j <= data.RuleList.Count - 1; j++)
		{
			RulRule item = new RulRule(data.RuleList[j]);
			RuleList.Add(item);
		}
	}

	public override string ToString()
	{
		return "Sample Size : " + SampleSize;
	}
}
