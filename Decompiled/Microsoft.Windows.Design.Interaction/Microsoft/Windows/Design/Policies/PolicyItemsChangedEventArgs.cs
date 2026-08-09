using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Policies;

public class PolicyItemsChangedEventArgs : EventArgs
{
	private ItemPolicy _policy;

	private IEnumerable<ModelItem> _itemsAdded;

	private IEnumerable<ModelItem> _itemsRemoved;

	public IEnumerable<ModelItem> ItemsAdded => _itemsAdded;

	public IEnumerable<ModelItem> ItemsRemoved => _itemsRemoved;

	public ItemPolicy Policy => _policy;

	public PolicyItemsChangedEventArgs(ItemPolicy policy, IEnumerable<ModelItem> itemsAdded, IEnumerable<ModelItem> itemsRemoved)
	{
		if (policy == null)
		{
			throw new ArgumentNullException("policy");
		}
		_policy = policy;
		_itemsAdded = itemsAdded;
		_itemsRemoved = itemsRemoved;
		if (_itemsAdded == null)
		{
			_itemsAdded = new ModelItem[0];
		}
		if (_itemsRemoved == null)
		{
			_itemsRemoved = new ModelItem[0];
		}
	}
}
