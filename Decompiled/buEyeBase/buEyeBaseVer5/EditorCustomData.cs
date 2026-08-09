using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class EditorCustomData
{
	public List<string> Commands = new List<string>();

	public int EntityIndex = -1;

	public EditorCustomData()
	{
	}

	public EditorCustomData(EditorCustomData data)
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
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		for (int j = 0; j <= data.Commands.Count - 1; j++)
		{
			Commands.Add(data.Commands[j]);
		}
	}

	public override string ToString()
	{
		string text = EntityIndex + ": ";
		if (Commands.Count > 0)
		{
			string text2 = "";
			for (int i = 0; i <= Commands.Count - 1; i++)
			{
				if (i > 0)
				{
					text2 = " , ";
				}
				text = text + text2 + Commands[i];
			}
		}
		return text;
	}
}
