using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class SpinPatternCommand : buSerilization
{
	public bool ShowPattern = false;

	public bool NextPattern = false;

	public bool SimStart = false;

	public bool SimStop = false;

	public bool Undo = false;

	public bool OK = false;

	public bool Finish = false;

	public bool Cancel = false;

	public static List<string> Captions = new List<string>();

	public SpinPatternCommand()
	{
	}

	public SpinPatternCommand(SpinPatternCommand data)
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
}
