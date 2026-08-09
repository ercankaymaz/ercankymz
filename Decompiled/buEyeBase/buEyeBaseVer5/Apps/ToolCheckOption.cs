using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ToolCheckOption : buSerilization5
{
	public double ToolBaseLength = 0.0;

	public bool checkToolLength = true;

	public ToolCheckOption()
	{
	}

	public ToolCheckOption(ToolCheckOption data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "checkToolLength :" + checkToolLength;
	}
}
