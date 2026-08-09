using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class AnalyseEntitiesResult : buSerilization5
{
	public bool isError = false;

	public List<AnalyseEntitiesResultError> ErrorList = new List<AnalyseEntitiesResultError>();

	public AnalyseEntitiesResult()
	{
	}

	public AnalyseEntitiesResult(AnalyseEntitiesResult data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		ErrorList.Clear();
		ErrorList = new List<AnalyseEntitiesResultError>();
		for (int j = 0; j <= data.ErrorList.Count - 1; j++)
		{
			ErrorList.Add(new AnalyseEntitiesResultError(data.ErrorList[j]));
		}
	}

	public override string ToString()
	{
		return "isError: " + isError;
	}
}
