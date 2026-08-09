using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class PositionPost : buSerilization
{
	public PositionPostType PositionType = PositionPostType.G90;

	public List<string> G90Def = new List<string>();

	public List<string> G91Def = new List<string>();

	public PositionPost()
	{
	}

	public PositionPost(PositionPost data)
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

	public PositionPost(PositionPostType type)
	{
		PositionType = type;
	}
}
