using System.Collections.Generic;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace MS.Internal;

internal static class SelectionUtilities
{
	internal enum CollectionTraversalDirection
	{
		Forward,
		Backward
	}

	internal static Selection ReduceSelection(Selection selection)
	{
		Dictionary<ModelItem, ModelItem> dictionary = new Dictionary<ModelItem, ModelItem>();
		foreach (ModelItem selectedObject in selection.SelectedObjects)
		{
			if (!dictionary.ContainsKey(selectedObject))
			{
				dictionary.Add(selectedObject, selectedObject);
			}
		}
		List<ModelItem> list = new List<ModelItem>();
		foreach (KeyValuePair<ModelItem, ModelItem> item in dictionary)
		{
			ModelItem parent = item.Key.Parent;
			while (parent != null && !dictionary.ContainsKey(parent))
			{
				parent = parent.Parent;
			}
			if (parent == null)
			{
				list.Add(item.Key);
			}
		}
		return new Selection(list);
	}

	internal static ModelItem GetNextSelectableChild(ModelItem parent, int startIndex, CollectionTraversalDirection direction)
	{
		if (parent != null && parent.Content != null)
		{
			ModelItemCollection collection = parent.Content.Collection;
			if (collection != null)
			{
				switch (direction)
				{
				case CollectionTraversalDirection.Forward:
				{
					int num2 = 0;
					foreach (ModelItem item in collection)
					{
						if (num2 >= startIndex && IsSelectable(item))
						{
							return item;
						}
						num2++;
					}
					break;
				}
				case CollectionTraversalDirection.Backward:
				{
					ModelItem[] array = new ModelItem[collection.Count];
					collection.CopyTo(array, 0);
					if (array == null || array.Length <= 0)
					{
						break;
					}
					int num = startIndex;
					while (num >= 0 && num < collection.Count)
					{
						ModelItem modelItem = array[num];
						if (IsSelectable(modelItem))
						{
							return modelItem;
						}
						num--;
					}
					break;
				}
				}
			}
		}
		return null;
	}

	private static bool IsSelectable(ModelItem item)
	{
		if (item != null && item.View != null)
		{
			return item.View.IsVisible;
		}
		return false;
	}
}
