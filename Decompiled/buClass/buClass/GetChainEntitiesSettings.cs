using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class GetChainEntitiesSettings : buSerilization
{
	public bool AddToSelection = false;

	public int StartEntityIndex = -1;

	public bool UseOnlyFirstSelectedEntitiyLayer = false;

	public bool UseMinDistance = false;

	public double MinDistance = 5.0;

	public static List<string> Captions = new List<string>();

	public GetChainEntitiesSettings()
	{
	}

	public GetChainEntitiesSettings(bool addToselection, int startEntityIndex, bool useOnlyFirstSelectedEntitiyLayer)
	{
		AddToSelection = addToselection;
		StartEntityIndex = startEntityIndex;
		UseOnlyFirstSelectedEntitiyLayer = useOnlyFirstSelectedEntitiyLayer;
	}

	public GetChainEntitiesSettings(GetChainEntitiesSettings data)
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
		return "AddToSelection: " + AddToSelection;
	}
}
