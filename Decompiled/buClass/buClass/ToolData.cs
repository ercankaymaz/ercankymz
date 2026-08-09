using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolData : buSerilization
{
	public string Name = "Tool";

	public int No = 1;

	public int Sector = 1;

	public int HeightOffsetIndex = 0;

	public string Tag = "";

	public bool Clone = false;

	public int CloneToolNo = 1;

	public bool Broken = false;

	public double MaxUsageHour = 100.0;

	public double ActiveUsageHour = 0.0;

	public bool TimeLimitExceed = false;

	public int Priority = 10;

	public bool isAgregateLeft = false;

	public bool isAgregate = false;

	public int GroupIndex = -1;

	public int GroupItemIndex = -1;

	public double LengthCorrection = 0.0;

	public double DepthOffset = 0.0;

	public ToolData()
	{
	}

	public ToolData(ToolData data)
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
		return "Name: " + Name.ToString() + " - No: " + No + " - Sector: " + Sector;
	}
}
