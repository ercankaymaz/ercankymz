using System;
using System.Collections.ObjectModel;

namespace Microsoft.Windows.Design.Interaction;

public class MenuGroup : MenuBase
{
	private ObservableCollection<MenuBase> _items;

	private bool _hasDropDown;

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

	public bool HasDropDown
	{
		get
		{
			return _hasDropDown;
		}
		set
		{
			if (_hasDropDown != value)
			{
				_hasDropDown = value;
				OnPropertyChanged("HasDropDown");
			}
		}
	}

	public MenuGroup(string groupName)
		: this(groupName, groupName)
	{
	}

	public MenuGroup(string groupName, string displayName)
	{
		if (string.IsNullOrEmpty(groupName))
		{
			throw new ArgumentNullException("groupName");
		}
		base.Name = groupName;
		base.DisplayName = displayName;
	}
}
