using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerChangeRuleType : buSerilization
{
	public double PtValue = 2.0;

	public DiemakerType ChangeType = DiemakerType.Cutting;

	public static List<string> Captions = new List<string>();

	public DiemakerChangeRuleType()
	{
	}

	public DiemakerChangeRuleType(DiemakerChangeRuleType data)
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

	public static void Copy(DiemakerChangeRuleType Source, ref DiemakerChangeRuleType Target)
	{
		Target = new DiemakerChangeRuleType(Source);
	}

	public override string ToString()
	{
		return "PtValue : " + PtValue + " - ChangeType : " + ChangeType;
	}
}
