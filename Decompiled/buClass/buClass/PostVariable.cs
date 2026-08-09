using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class PostVariable : buSerilization
{
	public string VariableName = "";

	public string Value = "";

	public List<string> ValueList = new List<string>();

	public PostVariable()
	{
	}

	public PostVariable(PostVariable data)
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

	public PostVariable(string name, string val)
	{
		VariableName = name;
		Value = val;
	}
}
