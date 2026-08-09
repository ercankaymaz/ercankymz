using System;
using System.Collections.ObjectModel;
using MS.Internal.Features;
using Microsoft.Windows.Design.Features;

namespace Microsoft.Windows.Design.Interaction;

[FeatureConnector(typeof(ContextMenuFeatureConnector))]
public abstract class ContextMenuProvider : FeatureProvider
{
	private ObservableCollection<MenuBase> _items;

	public ObservableCollection<MenuBase> Items
	{
		get
		{
			if (_items == null)
			{
				_items = new ObservableCollection<MenuBase>();
			}
			return _items;
		}
	}

	public event EventHandler<MenuActionEventArgs> UpdateItemStatus;

	public void Update(EditingContext context)
	{
		if (this.UpdateItemStatus != null)
		{
			this.UpdateItemStatus(this, new MenuActionEventArgs(context));
		}
		AssignContext(context, Items);
	}

	private void AssignContext(EditingContext context, ObservableCollection<MenuBase> items)
	{
		foreach (MenuBase item in items)
		{
			item.Context = context;
			if (item is MenuGroup menuGroup)
			{
				AssignContext(context, menuGroup.Items);
			}
		}
	}
}
