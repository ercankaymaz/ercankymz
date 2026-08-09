using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class PropertyItemCollection : ReadOnlyObservableCollection<PropertyItem>
{
	internal static readonly string CategoryPropertyName;

	internal static readonly string CategoryOrderPropertyName;

	internal static readonly string PropertyOrderPropertyName;

	internal static readonly string DisplayNamePropertyName;

	private bool _preventNotification;

	internal Predicate<object> FilterPredicate
	{
		get
		{
			return GetDefaultView().Filter;
		}
		set
		{
			GetDefaultView().Filter = value;
		}
	}

	public ObservableCollection<PropertyItem> EditableCollection { get; private set; }

	static PropertyItemCollection()
	{
		PropertyItem p = null;
		CategoryPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.Category);
		CategoryOrderPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.CategoryOrder);
		PropertyOrderPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.PropertyOrder);
		DisplayNamePropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.DisplayName);
	}

	public PropertyItemCollection(ObservableCollection<PropertyItem> editableCollection)
		: base(editableCollection)
	{
		EditableCollection = editableCollection;
	}

	private ICollectionView GetDefaultView()
	{
		return CollectionViewSource.GetDefaultView(this);
	}

	public void GroupBy(string name)
	{
		GetDefaultView().GroupDescriptions.Add((GroupDescription)(object)new PropertyGroupDescription(name));
	}

	public void SortBy(string name, ListSortDirection sortDirection)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		((Collection<SortDescription>)(object)GetDefaultView().SortDescriptions).Add(new SortDescription(name, sortDirection));
	}

	public void Filter(string text)
	{
		Predicate<object> filter = CreateFilter(text, base.Items, null);
		GetDefaultView().Filter = filter;
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
	{
		if (!_preventNotification)
		{
			base.OnCollectionChanged(args);
		}
	}

	internal void UpdateItems(IEnumerable<PropertyItem> newItems)
	{
		if (newItems == null)
		{
			throw new ArgumentNullException("newItems");
		}
		_preventNotification = true;
		using (GetDefaultView().DeferRefresh())
		{
			EditableCollection.Clear();
			foreach (PropertyItem newItem in newItems)
			{
				EditableCollection.Add(newItem);
			}
		}
		_preventNotification = false;
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	internal void UpdateCategorization(GroupDescription groupDescription, bool isPropertyGridCategorized, bool sortAlphabetically)
	{
		foreach (PropertyItem item in base.Items)
		{
			item.DescriptorDefinition.DisplayOrder = item.DescriptorDefinition.ComputeDisplayOrderInternal(isPropertyGridCategorized);
			item.PropertyOrder = item.DescriptorDefinition.DisplayOrder;
		}
		ICollectionView defaultView = GetDefaultView();
		using (defaultView.DeferRefresh())
		{
			defaultView.GroupDescriptions.Clear();
			((Collection<SortDescription>)(object)defaultView.SortDescriptions).Clear();
			if (groupDescription != null)
			{
				defaultView.GroupDescriptions.Add(groupDescription);
				SortBy(CategoryOrderPropertyName, ListSortDirection.Ascending);
				SortBy(CategoryPropertyName, ListSortDirection.Ascending);
			}
			SortBy(PropertyOrderPropertyName, ListSortDirection.Ascending);
			if (sortAlphabetically)
			{
				SortBy(DisplayNamePropertyName, ListSortDirection.Ascending);
			}
		}
	}

	internal void RefreshView()
	{
		GetDefaultView().Refresh();
	}

	internal static Predicate<object> CreateFilter(string text, IList<PropertyItem> PropertyItems, IPropertyContainer propertyContainer)
	{
		Predicate<object> result = null;
		if (!string.IsNullOrEmpty(text))
		{
			result = delegate(object item)
			{
				PropertyItem propertyItem = item as PropertyItem;
				if (propertyItem.DisplayName != null)
				{
					DisplayAttribute attribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(propertyItem.PropertyDescriptor);
					if (attribute != null)
					{
						bool? autoGenerateFilter = attribute.GetAutoGenerateFilter();
						if (autoGenerateFilter.HasValue && !autoGenerateFilter.Value)
						{
							return false;
						}
					}
					propertyItem.HighlightedText = (propertyItem.DisplayName.ToLower().Contains(text.ToLower()) ? text : null);
					return propertyItem.HighlightedText != null;
				}
				return false;
			};
		}
		else
		{
			ClearFilterSubItems(PropertyItems.ToList());
		}
		return result;
	}

	private static void ClearFilterSubItems(IList items)
	{
		foreach (object item in items)
		{
			if (item is PropertyItemBase propertyItemBase)
			{
				propertyItemBase.HighlightedText = null;
			}
		}
	}
}
