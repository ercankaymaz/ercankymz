using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSheetData : buSerilization5
{
	public double Width = 200.0;

	public double Height = 100.0;

	public double Thickness = 10.0;

	public int Quantity = 1;

	public string Name = "Sheet";

	public string ItemNo = "";

	public string SalesNo = "";

	public string Other = "";

	public string Aux = "";

	public double UserData = 0.0;

	public ToolBase5 Tool = new ToolBase5();

	public static List<string> Captions = new List<string>();

	public buNestingSheetData()
	{
	}

	public buNestingSheetData(buNestingSheetData data)
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
		return "W: " + Width + " , H: " + Height + " , Qt: " + Quantity;
	}
}
