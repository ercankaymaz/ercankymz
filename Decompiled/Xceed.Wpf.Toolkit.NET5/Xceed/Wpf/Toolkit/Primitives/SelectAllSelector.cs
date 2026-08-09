using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Primitives;

[TemplatePart(Name = "PART_SelectAllSelectorItem", Type = typeof(SelectAllSelectorItem))]
public class SelectAllSelector : Selector
{
	private const string PART_SelectAllSelectorItem = "PART_SelectAllSelectorItem";

	private SelectAllSelectorItem _selectAllSelecotrItem;

	public static readonly DependencyProperty AllItemsSelectedContentProperty = DependencyProperty.Register("AllItemsSelectedContent", typeof(string), typeof(SelectAllSelector), (PropertyMetadata)(object)new UIPropertyMetadata("All", new PropertyChangedCallback(OnAllItemsSelectedContentChanged)));

	public static readonly DependencyProperty IsSelectAllActiveProperty = DependencyProperty.Register("IsSelectAllActive", typeof(bool), typeof(SelectAllSelector), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsSelectAllActiveChanged)));

	public static readonly DependencyProperty SelectAllContentProperty = DependencyProperty.Register("SelectAllContent", typeof(object), typeof(SelectAllSelector), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Select All"));

	public string AllItemsSelectedContent
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AllItemsSelectedContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllItemsSelectedContentProperty, (object)value);
		}
	}

	public bool IsSelectAllActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectAllActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectAllActiveProperty, (object)value);
		}
	}

	public object SelectAllContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectAllContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAllContentProperty, value);
		}
	}

	private static void OnAllItemsSelectedContentChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is SelectAllSelector selectAllSelector)
		{
			selectAllSelector.OnAllItemsSelectedContentChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnAllItemsSelectedContentChanged(string oldValue, string newValue)
	{
	}

	private static void OnIsSelectAllActiveChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is SelectAllSelector selectAllSelector)
		{
			selectAllSelector.OnIsSelectAllActiveChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsSelectAllActiveChanged(bool oldValue, bool newValue)
	{
		if (newValue && base.Items.Count > 0)
		{
			UpdateSelectAllSelectorItem();
		}
	}

	protected override void OnSelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		base.OnSelectedItemsCollectionChanged(sender, e);
		UpdateSelectAllSelectorItem();
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnItemsChanged(e);
		UpdateSelectAllSelectorItem();
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_selectAllSelecotrItem = GetTemplateChild("PART_SelectAllSelectorItem") as SelectAllSelectorItem;
	}

	public void SelectAll()
	{
		List<object> second = new List<object>(base.SelectedItems as IEnumerable<object>);
		IEnumerable<object> enumerable = base.ItemsCollection.Cast<object>();
		UpdateSelectedItemsWithoutNotifications(enumerable.ToList());
		foreach (object item in enumerable.Except(second))
		{
			OnItemSelectionChanged(new ItemSelectionChangedEventArgs(Selector.ItemSelectionChangedEvent, this, item, isSelected: true));
			if (base.Command != null)
			{
				base.Command.Execute(item);
			}
		}
	}

	public void UnSelectAll()
	{
		List<object> list = new List<object>(base.SelectedItems as IEnumerable<object>);
		base.SelectedItems.Clear();
		foreach (object item in list)
		{
			OnItemSelectionChanged(new ItemSelectionChangedEventArgs(Selector.ItemSelectionChangedEvent, this, item, isSelected: false));
			if (base.Command != null)
			{
				base.Command.Execute(item);
			}
		}
	}

	private void UpdateSelectAllSelectorItem()
	{
		if (_selectAllSelecotrItem != null)
		{
			if (base.Items.Count == base.SelectedItems.Count)
			{
				_selectAllSelecotrItem.ModifyCurrentSelection(true);
			}
			else if (base.SelectedItems.Count > 0)
			{
				_selectAllSelecotrItem.ModifyCurrentSelection(null);
			}
			else
			{
				_selectAllSelecotrItem.ModifyCurrentSelection(false);
			}
		}
	}
}
