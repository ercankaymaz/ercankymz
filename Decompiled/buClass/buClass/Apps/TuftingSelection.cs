using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TuftingSelection : buSerilization
{
	public tuftingSelectionModeType Type = tuftingSelectionModeType.Auto;

	public tuftingManuelModeType ManuelMode = tuftingManuelModeType.ClickBlockPoints;

	public SortingNextGroupFindRulesType AutoNextGroupRules = SortingNextGroupFindRulesType.ClosestLength;

	public SortingNextGroupFindRulesType ManuelNextGroupRules = SortingNextGroupFindRulesType.ClosestLength;

	public tuftingManuelModeLayerType LayerMode = tuftingManuelModeLayerType.SelectedLayer;

	public bool OutlineFirst = true;

	public static List<string> Captions = new List<string>();

	public TuftingSelection()
	{
	}

	public TuftingSelection(TuftingSelection data)
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
}
