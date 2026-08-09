using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ToolPositions5 : buSerilization5
{
	public Pnt6D Position = new Pnt6D();

	public Pnt6D Offset = new Pnt6D();

	public Pnt6D CommonOffset = new Pnt6D();

	public double AngularPosition = 0.0;

	public ToolLocationType Location = ToolLocationType.None;

	public ToolPositions5()
	{
	}

	public ToolPositions5(ToolPositions5 data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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

	public ToolPositions5(ToolPositions data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		return "Pos: " + Position.ToString();
	}
}
