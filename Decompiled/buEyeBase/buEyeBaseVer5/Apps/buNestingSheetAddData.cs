using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSheetAddData : buSerilization5
{
	public bool UseColorForSelection = false;

	public Color SelectionColor = Color.Black;

	public bool DeleteSelectedEntities = true;

	public double Thickness = 10.0;

	public int Quantity = 1;

	public string Name = "Sheet";

	public bool AddUselessEntities = true;

	public double LastSheetWidth = 1000.0;

	public double LastSheetHeight = 500.0;

	public int LastSheetQuantity = 10;

	public static List<string> Captions = new List<string>();

	public buNestingSheetAddData()
	{
	}

	public buNestingSheetAddData(buNestingSheetAddData data)
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
}
