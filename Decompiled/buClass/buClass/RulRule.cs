using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class RulRule : buSerilization
{
	public int No = 0;

	public List<Pnt3D> Position = new List<Pnt3D>();

	public RulRule()
	{
	}

	public RulRule(RulRule data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		Position.Clear();
		for (int j = 0; j <= data.Position.Count - 1; j++)
		{
			Position.Add(new Pnt3D(data.Position[j]));
		}
	}

	public override string ToString()
	{
		return "No : " + No;
	}
}
