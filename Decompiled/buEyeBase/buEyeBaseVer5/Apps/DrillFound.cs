using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillFound : buSerilization5
{
	public List<DrillCalcItem> Items = new List<DrillCalcItem>();

	public List<int> OriginalIndexList = new List<int>();

	public DrillFound()
	{
	}

	public DrillFound(DrillFound data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		DrillCalcItem.Copy(data.Items, ref Items);
	}

	public static void Add(DrillCalcItem Item, int ToolNo, ref DrillFound Found)
	{
		DrillCalcItem drillCalcItem = new DrillCalcItem(Item);
		drillCalcItem.Calculated = true;
		drillCalcItem.Tool = ToolNo;
		Found.Items.Add(drillCalcItem);
	}

	public override string ToString()
	{
		string text = "Items: " + Items.Count;
		if (Items.Count > 0)
		{
			text = text + " , " + Items[0].planeName;
			if (Items[0].OffsetedPoint.X != 0.0)
			{
				text = text + " , XOff: " + Items[0].OffsetedPoint.X.ToString("f1");
			}
		}
		return text;
	}
}
