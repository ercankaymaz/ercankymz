using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ToolData5 : buSerilization5
{
	public string Name = "Tool";

	public int No = 1;

	public int Sector = 1;

	public int HeightOffsetIndex = 0;

	public string Tag = "";

	public bool Clone = false;

	public bool Used = false;

	public int CloneToolNo = 1;

	public bool Broken = false;

	public double MaxUsageHour = 100.0;

	public double ActiveUsageHour = 0.0;

	public double TappingInfo = 1.0;

	public bool TimeLimitExceed = false;

	public int Priority = 10;

	public bool isAgregateLeft = false;

	public bool isAgregate = false;

	public int GroupIndex = -1;

	public int GroupItemIndex = -1;

	public int HeadNumber = 1;

	public ToolData5()
	{
	}

	public ToolData5(ToolData5 data)
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

	public ToolData5(ToolData data)
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
		return "Name: " + Name.ToString() + " - No: " + No + " - Sector: " + Sector;
	}
}
