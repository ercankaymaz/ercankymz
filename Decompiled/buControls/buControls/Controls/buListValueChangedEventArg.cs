using System.Collections.Generic;
using buClass;

namespace buControls.Controls;

public class buListValueChangedEventArg
{
	public List<ValuesItem> Items = new List<ValuesItem>();

	public ValuesItem Value = new ValuesItem();

	public int IndexItem = -1;

	public string Command = "";

	public buListValueChangedEventArg()
	{
	}

	public buListValueChangedEventArg(List<ValuesItem> items, ValuesItem value, int indexItem, string command)
	{
		for (int i = 0; i <= items.Count - 1; i++)
		{
			Items.Add(items[i]);
		}
		Value = new ValuesItem(value);
		IndexItem = indexItem;
		Command = command;
	}
}
