using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class MachineParts : buSerilization
{
	public KinematicBase Kinematic = new KinematicBase();

	public ToolBase ToolData = new ToolBase();

	public List<KinematicItem> MovingParts = new List<KinematicItem>();

	public MachineParts()
	{
	}

	public MachineParts(MachineParts data)
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
		ToolData = new ToolBase(data.ToolData);
		Kinematic = new KinematicBase(data.Kinematic);
		MovingParts.Clear();
		for (int j = 0; j <= data.MovingParts.Count - 1; j++)
		{
			MovingParts.Add(new KinematicItem(data.MovingParts[j]));
		}
	}
}
