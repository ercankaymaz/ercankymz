using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodeRepetition : buSerilization
{
	public bool Coordinate;

	public bool Feed;

	public bool Tool;

	public bool Command;

	public AxesEnableWithUVW AxesRepetation = new AxesEnableWithUVW();

	public CodeRepetition()
	{
	}

	public CodeRepetition(CodeRepetition data)
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
		AxesRepetation = new AxesEnableWithUVW(data.AxesRepetation);
	}

	public CodeRepetition(bool coordinate, bool feed, bool tool, bool command)
	{
		Coordinate = coordinate;
		Feed = feed;
		Tool = tool;
		Command = command;
	}

	public override string ToString()
	{
		return "Tool: " + Tool + " , Feed: " + Feed + " , Coordinate: " + Coordinate;
	}
}
