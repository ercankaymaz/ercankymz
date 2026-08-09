using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ParameterInfo : buSerilization
{
	public string Name = "";

	public string Caption = "";

	public string Explanation = "";

	public string imageFileName = "";

	public ParameterInfo()
	{
	}

	public ParameterInfo(string name, string caption, string explanation, string imageFilename)
	{
		Name = name;
		Caption = caption;
		Explanation = explanation;
		imageFileName = imageFilename;
	}

	public ParameterInfo(ParameterInfo data)
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
		return "Name: " + Name + " - Cap: " + Caption;
	}
}
