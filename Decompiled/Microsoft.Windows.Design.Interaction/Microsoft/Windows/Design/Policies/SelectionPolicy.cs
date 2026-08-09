using System.Collections.Generic;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Policies;

[RequiresContextItem(typeof(Selection))]
[RequiresContextItem(typeof(Tool))]
public class SelectionPolicy : ItemPolicy
{
	private List<ModelItem> _currentItems = new List<ModelItem>();

	public override IEnumerable<ModelItem> PolicyItems => _currentItems;

	protected virtual IEnumerable<ModelItem> GetPolicyItems(Selection selection)
	{
		if (selection == null)
		{
			yield break;
		}
		foreach (ModelItem item in selection.SelectedObjects)
		{
			if (IsInPolicy(selection, item))
			{
				yield return item;
			}
		}
	}

	protected virtual bool IsInPolicy(Selection selection, ModelItem item)
	{
		return true;
	}

	protected override void OnActivated()
	{
		base.Context.Items.Subscribe<Selection>(OnSelectionChanged);
	}

	protected override void OnDeactivated()
	{
		base.Context.Items.Unsubscribe<Selection>(OnSelectionChanged);
	}

	private void OnSelectionChanged(Selection newSelection)
	{
		IEnumerable<ModelItem> currentItems = _currentItems;
		IEnumerable<ModelItem> policyItems = GetPolicyItems(newSelection);
		Dictionary<ModelItem, ModelItem> dictionary = new Dictionary<ModelItem, ModelItem>(_currentItems.Count);
		List<ModelItem> list = new List<ModelItem>(newSelection.SelectionCount);
		foreach (ModelItem item in currentItems)
		{
			dictionary[item] = item;
		}
		_currentItems.Clear();
		foreach (ModelItem item2 in policyItems)
		{
			_currentItems.Add(item2);
			if (dictionary.ContainsKey(item2))
			{
				dictionary.Remove(item2);
			}
			else
			{
				list.Add(item2);
			}
		}
		if (dictionary.Count != 0 || list.Count != 0)
		{
			OnPolicyItemsChanged(new PolicyItemsChangedEventArgs(this, list, dictionary.Values));
		}
	}
}
