using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camSettings : buSerilization
{
	public bool CopyToolDataToCamData = true;

	public bool CopyToolFeedToCamFeed = true;

	public bool CopyToolPlungeFeedToCamPlungeFeed = true;

	public bool CopyToolRetractFeedToCamRetractFeed = true;

	public static List<string> Captions = new List<string>();

	public camSettings()
	{
	}

	public camSettings(camSettings Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
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
		return "CopyToolDataToCamData: " + CopyToolDataToCamData;
	}
}
