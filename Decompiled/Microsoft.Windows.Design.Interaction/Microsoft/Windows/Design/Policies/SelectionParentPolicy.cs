using System.Collections.Generic;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Policies;

public class SelectionParentPolicy : SelectionPolicy
{
	private Dictionary<ModelItem, ModelItem> _lastParents;

	private Selection _lastSelection;

	protected override IEnumerable<ModelItem> GetPolicyItems(Selection selection)
	{
		if (selection == _lastSelection)
		{
			return _lastParents.Keys;
		}
		Dictionary<ModelItem, ModelItem> dictionary = new Dictionary<ModelItem, ModelItem>();
		foreach (ModelItem selectedObject in selection.SelectedObjects)
		{
			ModelItem parent = selectedObject.Parent;
			if (parent != null && IsInPolicy(selection, selectedObject, parent))
			{
				dictionary[parent] = parent;
			}
		}
		_lastParents = dictionary;
		_lastSelection = selection;
		return dictionary.Keys;
	}

	protected virtual bool IsInPolicy(Selection selection, ModelItem item, ModelItem parent)
	{
		return true;
	}
}
