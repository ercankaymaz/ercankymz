using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolPositions : buSerilization
{
	public Pnt6D Position = new Pnt6D();

	public Pnt6D Offset = new Pnt6D();

	public double AngularPosition = 0.0;

	public ToolLocationType Location = ToolLocationType.None;

	public ToolPositions()
	{
	}

	public ToolPositions(ToolPositions data)
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
		return "Pos: " + Position.ToString();
	}
}
