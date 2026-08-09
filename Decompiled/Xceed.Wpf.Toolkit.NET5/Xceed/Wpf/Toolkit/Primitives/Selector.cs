using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Xceed.Wpf.Toolkit.Primitives;

public class Selector : ItemsControl, IWeakEventListener
{
	private class ValueEqualityComparer : IEqualityComparer<string>
	{
		public bool Equals(string x, string y)
		{
			return string.Equals(x, y, StringComparison.InvariantCultureIgnoreCase);
		}

		public int GetHashCode(string obj)
		{
			return 1;
		}
	}

	private bool _surpressItemSelectionChanged;

	private bool _ignoreSelectedItemChanged;

	private bool _ignoreSelectedValueChanged;

	private int _ignoreSelectedItemsCollectionChanged;

	private int _ignoreSelectedMemberPathValuesChanged;

	private IList _selectedItems;

	private IList _removedItems = new ObservableCollection<object>();

	private object[] _internalSelectedItems;

	private ValueChangeHelper _selectedMemberPathValuesHelper;

	private ValueChangeHelper _valueMemberPathValuesHelper;

	public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(Selector), new PropertyMetadata((object)null));

	public static readonly DependencyProperty DelimiterProperty = DependencyProperty.Register("Delimiter", typeof(string), typeof(Selector), (PropertyMetadata)(object)new UIPropertyMetadata(",", new PropertyChangedCallback(OnDelimiterChanged)));

	public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(Selector), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnSelectedItemChanged)));

	public static readonly DependencyProperty SelectedItemsOverrideProperty = DependencyProperty.Register("SelectedItemsOverride", typeof(IList), typeof(Selector), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(SelectedItemsOverrideChanged)));

	public static readonly DependencyProperty SelectedMemberPathProperty = DependencyProperty.Register("SelectedMemberPath", typeof(string), typeof(Selector), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnSelectedMemberPathChanged)));

	public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(string), typeof(Selector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSelectedValueChanged)));

	public static readonly DependencyProperty ValueMemberPathProperty = DependencyProperty.Register("ValueMemberPath", typeof(string), typeof(Selector), (PropertyMetadata)(object)new UIPropertyMetadata(new PropertyChangedCallback(OnValueMemberPathChanged)));

	public static readonly RoutedEvent SelectedEvent = EventManager.RegisterRoutedEvent("SelectedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Selector));

	public static readonly RoutedEvent UnSelectedEvent = EventManager.RegisterRoutedEvent("UnSelectedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Selector));

	public static readonly RoutedEvent ItemSelectionChangedEvent = EventManager.RegisterRoutedEvent("ItemSelectionChanged", RoutingStrategy.Bubble, typeof(ItemSelectionChangedEventHandler), typeof(Selector));

	[TypeConverter(typeof(CommandConverter))]
	public ICommand Command
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public string Delimiter
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DelimiterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DelimiterProperty, (object)value);
		}
	}

	public object SelectedItem
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectedItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemProperty, value);
		}
	}

	public IList SelectedItems
	{
		get
		{
			return _selectedItems;
		}
		private set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			INotifyCollectionChanged notifyCollectionChanged = _selectedItems as INotifyCollectionChanged;
			INotifyCollectionChanged notifyCollectionChanged2 = value as INotifyCollectionChanged;
			if (notifyCollectionChanged != null)
			{
				CollectionChangedEventManager.RemoveListener(notifyCollectionChanged, (IWeakEventListener)(object)this);
			}
			if (notifyCollectionChanged2 != null)
			{
				CollectionChangedEventManager.AddListener(notifyCollectionChanged2, (IWeakEventListener)(object)this);
			}
			IList selectedItems = _selectedItems;
			if (selectedItems != null)
			{
				foreach (object item in selectedItems)
				{
					if ((value != null && !value.Contains(item)) || value == null)
					{
						OnItemSelectionChanged(new ItemSelectionChangedEventArgs(ItemSelectionChangedEvent, this, item, isSelected: false));
						if (Command != null)
						{
							Command.Execute(item);
						}
					}
				}
			}
			if (value != null)
			{
				foreach (object item2 in value)
				{
					OnItemSelectionChanged(new ItemSelectionChangedEventArgs(ItemSelectionChangedEvent, this, item2, isSelected: true));
					if (((selectedItems != null && !selectedItems.Contains(item2)) || selectedItems == null) && Command != null)
					{
						Command.Execute(item2);
					}
				}
			}
			_selectedItems = value;
		}
	}

	public IList SelectedItemsOverride
	{
		get
		{
			return (IList)((DependencyObject)this).GetValue(SelectedItemsOverrideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemsOverrideProperty, (object)value);
		}
	}

	public string SelectedMemberPath
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedMemberPathProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedMemberPathProperty, (object)value);
		}
	}

	public string SelectedValue
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedValueProperty, (object)value);
		}
	}

	public string ValueMemberPath
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ValueMemberPathProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueMemberPathProperty, (object)value);
		}
	}

	protected IEnumerable ItemsCollection
	{
		get
		{
			object obj = base.ItemsSource;
			if (obj == null)
			{
				IEnumerable items = base.Items;
				obj = items ?? new object[0];
			}
			return (IEnumerable)obj;
		}
	}

	public event ItemSelectionChangedEventHandler ItemSelectionChanged
	{
		add
		{
			AddHandler(ItemSelectionChangedEvent, value);
		}
		remove
		{
			RemoveHandler(ItemSelectionChangedEvent, value);
		}
	}

	public event EventHandler<ItemSelectionChangingEventArgs> ItemSelectionChanging;

	public Selector()
	{
		SelectedItems = new ObservableCollection<object>();
		AddHandler(SelectedEvent, (RoutedEventHandler)delegate(object s, RoutedEventArgs args)
		{
			OnItemSelectionChangedCore(args, unselected: false);
		});
		AddHandler(UnSelectedEvent, (RoutedEventHandler)delegate(object s, RoutedEventArgs args)
		{
			OnItemSelectionChangedCore(args, unselected: true);
		});
		_selectedMemberPathValuesHelper = new ValueChangeHelper(OnSelectedMemberPathValuesChanged);
		_valueMemberPathValuesHelper = new ValueChangeHelper(OnValueMemberPathValuesChanged);
	}

	private static void OnDelimiterChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((Selector)(object)o).OnSelectedItemChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected virtual void OnSelectedItemChanged(string oldValue, string newValue)
	{
		if (base.IsInitialized)
		{
			UpdateSelectedValue();
		}
	}

	private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		((Selector)(object)sender).OnSelectedItemChanged(((DependencyPropertyChangedEventArgs)(ref args)).OldValue, ((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
	}

	protected virtual void OnSelectedItemChanged(object oldValue, object newValue)
	{
		if (base.IsInitialized && !_ignoreSelectedItemChanged)
		{
			_ignoreSelectedItemsCollectionChanged++;
			SelectedItems.Clear();
			if (newValue != null)
			{
				SelectedItems.Add(newValue);
			}
			UpdateFromSelectedItems();
			_ignoreSelectedItemsCollectionChanged--;
		}
	}

	private static void SelectedItemsOverrideChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		((Selector)(object)sender).OnSelectedItemsOverrideChanged((IList)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (IList)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
	}

	protected virtual void OnSelectedItemsOverrideChanged(IList oldValue, IList newValue)
	{
		if (base.IsInitialized)
		{
			IList selectedItems;
			if (newValue == null)
			{
				IList list = new ObservableCollection<object>();
				selectedItems = list;
			}
			else
			{
				selectedItems = newValue;
			}
			SelectedItems = selectedItems;
			UpdateFromSelectedItems();
		}
	}

	private static void OnSelectedMemberPathChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((Selector)(object)o).OnSelectedMemberPathChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected virtual void OnSelectedMemberPathChanged(string oldValue, string newValue)
	{
		if (base.IsInitialized)
		{
			UpdateSelectedMemberPathValuesBindings();
		}
	}

	private static void OnSelectedValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is Selector selector)
		{
			selector.OnSelectedValueChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnSelectedValueChanged(string oldValue, string newValue)
	{
		if (this is PropertyGridEditorEnumCheckComboBox || (base.IsInitialized && !_ignoreSelectedValueChanged))
		{
			UpdateFromSelectedValue();
		}
	}

	private static void OnValueMemberPathChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((Selector)(object)o).OnValueMemberPathChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected virtual void OnValueMemberPathChanged(string oldValue, string newValue)
	{
		if (base.IsInitialized)
		{
			UpdateValueMemberPathValuesBindings();
		}
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is SelectorItem;
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new SelectorItem();
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		base.PrepareContainerForItemOverride(element, item);
		_surpressItemSelectionChanged = true;
		((DependencyObject)(element as FrameworkElement)).SetValue(SelectorItem.IsSelectedProperty, (object)SelectedItems.Contains(item));
		_surpressItemSelectionChanged = false;
	}

	protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
		base.OnItemsSourceChanged(oldValue, newValue);
		INotifyCollectionChanged notifyCollectionChanged = oldValue as INotifyCollectionChanged;
		INotifyCollectionChanged notifyCollectionChanged2 = newValue as INotifyCollectionChanged;
		if (notifyCollectionChanged != null)
		{
			CollectionChangedEventManager.RemoveListener(notifyCollectionChanged, (IWeakEventListener)(object)this);
		}
		if (notifyCollectionChanged2 != null)
		{
			CollectionChangedEventManager.AddListener(notifyCollectionChanged2, (IWeakEventListener)(object)this);
		}
		if (base.IsInitialized)
		{
			if (SelectedItemsOverride == null && (!VirtualizingPanel.GetIsVirtualizing((DependencyObject)(object)this) || (VirtualizingPanel.GetIsVirtualizing((DependencyObject)(object)this) && newValue != null)))
			{
				RemoveUnavailableSelectedItems();
			}
			UpdateSelectedMemberPathValuesBindings();
			UpdateValueMemberPathValuesBindings();
		}
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnItemsChanged(e);
		if (base.ItemsSource == null)
		{
			RemoveUnavailableSelectedItems();
		}
	}

	public override void EndInit()
	{
		base.EndInit();
		if (SelectedItemsOverride != null)
		{
			OnSelectedItemsOverrideChanged(null, SelectedItemsOverride);
		}
		else if (SelectedMemberPath != null)
		{
			OnSelectedMemberPathChanged(null, SelectedMemberPath);
		}
		else if (SelectedValue != null)
		{
			OnSelectedValueChanged(null, SelectedValue);
		}
		else if (SelectedItem != null)
		{
			OnSelectedItemChanged((object)null, SelectedItem);
		}
		if (ValueMemberPath != null)
		{
			OnValueMemberPathChanged(null, ValueMemberPath);
		}
	}

	protected object GetPathValue(object item, string propertyPath)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (string.IsNullOrEmpty(propertyPath) || propertyPath == ".")
		{
			return item;
		}
		if (propertyPath.Contains("."))
		{
			object obj = item;
			string[] array = propertyPath.Split(new char[1] { '.' });
			foreach (string name in array)
			{
				PropertyInfo property = obj.GetType().GetProperty(name);
				if (property != null)
				{
					obj = property.GetValue(obj, null);
					continue;
				}
				return null;
			}
			return obj;
		}
		PropertyInfo property2 = item.GetType().GetProperty(propertyPath);
		if (!(property2 != null))
		{
			return null;
		}
		return property2.GetValue(item, null);
	}

	protected object GetItemValue(object item)
	{
		if (item == null)
		{
			return null;
		}
		return GetPathValue(item, ValueMemberPath);
	}

	protected object ResolveItemByValue(string value)
	{
		if (!string.IsNullOrEmpty(ValueMemberPath))
		{
			foreach (object item in ItemsCollection)
			{
				PropertyInfo property = item.GetType().GetProperty(ValueMemberPath);
				if (property != null)
				{
					object value2 = property.GetValue(item, null);
					if (value.Equals(value2.ToString(), StringComparison.InvariantCultureIgnoreCase))
					{
						return item;
					}
				}
			}
		}
		return value;
	}

	internal void UpdateFromList(List<string> selectedValues, Func<object, object> GetItemfunction)
	{
		_ignoreSelectedItemsCollectionChanged++;
		SelectedItems.Clear();
		if (selectedValues != null && selectedValues.Count > 0)
		{
			ValueEqualityComparer comparer = new ValueEqualityComparer();
			foreach (object item in ItemsCollection)
			{
				object obj = GetItemfunction(item);
				if (obj != null && selectedValues.Contains<string>(obj.ToString(), comparer))
				{
					SelectedItems.Add(item);
				}
			}
		}
		_ignoreSelectedItemsCollectionChanged--;
		UpdateFromSelectedItems();
	}

	internal void UpdateSelectedItemsWithoutNotifications(List<object> selectedValues)
	{
		_ignoreSelectedItemsCollectionChanged++;
		SelectedItems.Clear();
		if (selectedValues != null && selectedValues.Count > 0)
		{
			foreach (object item in ItemsCollection)
			{
				SelectedItems.Add(item);
			}
		}
		_ignoreSelectedItemsCollectionChanged--;
		UpdateFromSelectedItems();
	}

	private bool? GetSelectedMemberPathValue(object item)
	{
		if (string.IsNullOrEmpty(SelectedMemberPath))
		{
			return null;
		}
		if (item == null)
		{
			return null;
		}
		string[] array = SelectedMemberPath.Split('.');
		if (array.Length == 1)
		{
			PropertyInfo property = item.GetType().GetProperty(SelectedMemberPath);
			if (property != null && property.PropertyType == typeof(bool))
			{
				return property.GetValue(item, null) as bool?;
			}
			return null;
		}
		for (int i = 0; i < array.Count(); i++)
		{
			PropertyInfo property2 = item.GetType().GetProperty(array[i]);
			if (property2 == null)
			{
				return null;
			}
			if (i == array.Count() - 1)
			{
				if (property2.PropertyType == typeof(bool))
				{
					return property2.GetValue(item, null) as bool?;
				}
			}
			else
			{
				item = property2.GetValue(item, null);
			}
		}
		return null;
	}

	private void SetSelectedMemberPathValue(object item, bool value)
	{
		if (string.IsNullOrEmpty(SelectedMemberPath) || item == null)
		{
			return;
		}
		string[] array = SelectedMemberPath.Split('.');
		if (array.Length == 1)
		{
			PropertyInfo property = item.GetType().GetProperty(SelectedMemberPath);
			if (property != null && property.PropertyType == typeof(bool) && (bool)property.GetValue(item, null) != value)
			{
				property.SetValue(item, value, null);
			}
			return;
		}
		for (int i = 0; i < array.Count(); i++)
		{
			PropertyInfo property2 = item.GetType().GetProperty(array[i]);
			if (property2 == null)
			{
				break;
			}
			if (i == array.Count() - 1)
			{
				if (property2.PropertyType == typeof(bool))
				{
					property2.SetValue(item, value, null);
				}
			}
			else
			{
				item = property2.GetValue(item, null);
			}
		}
	}

	protected virtual void OnSelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (_ignoreSelectedItemsCollectionChanged > 0)
		{
			return;
		}
		UpdateFromSelectedItems();
		if (e.Action == NotifyCollectionChangedAction.Reset && _internalSelectedItems != null)
		{
			object[] internalSelectedItems = _internalSelectedItems;
			foreach (object obj in internalSelectedItems)
			{
				OnItemSelectionChanged(new ItemSelectionChangedEventArgs(ItemSelectionChangedEvent, this, obj, isSelected: false));
				if (Command != null)
				{
					Command.Execute(obj);
				}
			}
		}
		if (e.OldItems != null)
		{
			foreach (object oldItem in e.OldItems)
			{
				OnItemSelectionChanged(new ItemSelectionChangedEventArgs(ItemSelectionChangedEvent, this, oldItem, isSelected: false));
				if (Command != null)
				{
					Command.Execute(oldItem);
				}
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (object newItem in e.NewItems)
		{
			OnItemSelectionChanged(new ItemSelectionChangedEventArgs(ItemSelectionChangedEvent, this, newItem, isSelected: true));
			if (Command != null)
			{
				Command.Execute(newItem);
			}
		}
	}

	private void OnItemSelectionChangedCore(RoutedEventArgs args, bool unselected)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		object obj = base.ItemContainerGenerator.ItemFromContainer((DependencyObject)args.OriginalSource);
		if (obj == DependencyProperty.UnsetValue)
		{
			obj = args.OriginalSource;
		}
		ItemSelectionChangingEventArgs e = new ItemSelectionChangingEventArgs(obj, !unselected);
		OnItemSelectionChanging(e);
		if (e.Cancel)
		{
			UpdateSelectorItem(obj, unselected, raiseSelectionChangedEvent: false);
		}
		else if (unselected)
		{
			while (SelectedItems.Contains(obj))
			{
				SelectedItems.Remove(obj);
			}
		}
		else if (!SelectedItems.Contains(obj))
		{
			SelectedItems.Add(obj);
		}
	}

	private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		RemoveUnavailableSelectedItems();
		AddAvailableRemovedItems();
		UpdateSelectedMemberPathValuesBindings();
		UpdateValueMemberPathValuesBindings();
	}

	private void OnSelectedMemberPathValuesChanged()
	{
		if (_ignoreSelectedMemberPathValuesChanged <= 0)
		{
			UpdateFromSelectedMemberPathValues();
		}
	}

	private void OnValueMemberPathValuesChanged()
	{
		UpdateSelectedValue();
	}

	private void UpdateSelectedMemberPathValuesBindings()
	{
		_selectedMemberPathValuesHelper.UpdateValueSource(ItemsCollection, SelectedMemberPath);
		UpdateFromSelectedMemberPathValues();
	}

	private void UpdateValueMemberPathValuesBindings()
	{
		_valueMemberPathValuesHelper.UpdateValueSource(ItemsCollection, ValueMemberPath);
	}

	protected virtual void OnItemSelectionChanged(ItemSelectionChangedEventArgs args)
	{
		if (!_surpressItemSelectionChanged)
		{
			RaiseEvent(args);
		}
	}

	protected virtual void OnItemSelectionChanging(ItemSelectionChangingEventArgs args)
	{
		if (this.ItemSelectionChanging != null)
		{
			this.ItemSelectionChanging(this, args);
		}
	}

	private void UpdateSelectedValue()
	{
		string text = string.Join(Delimiter, from object x in SelectedItems
			select GetItemValue(x));
		if (string.IsNullOrEmpty(SelectedValue) || !SelectedValue.Equals(text))
		{
			_ignoreSelectedValueChanged = true;
			SelectedValue = text;
			_ignoreSelectedValueChanged = false;
		}
	}

	private void UpdateSelectedItem()
	{
		if (!SelectedItems.Contains(SelectedItem))
		{
			_ignoreSelectedItemChanged = true;
			SelectedItem = ((SelectedItems.Count > 0) ? SelectedItems[0] : null);
			_ignoreSelectedItemChanged = false;
		}
	}

	private void UpdateFromSelectedMemberPathValues()
	{
		_ignoreSelectedItemsCollectionChanged++;
		foreach (object item in ItemsCollection)
		{
			bool? selectedMemberPathValue = GetSelectedMemberPathValue(item);
			if (!selectedMemberPathValue.HasValue)
			{
				continue;
			}
			if (selectedMemberPathValue.Value)
			{
				if (!SelectedItems.Contains(item))
				{
					SelectedItems.Add(item);
				}
			}
			else if (SelectedItems.Contains(item))
			{
				SelectedItems.Remove(item);
			}
			UpdateSelectorItem(item, selectedMemberPathValue.Value);
		}
		_ignoreSelectedItemsCollectionChanged--;
		UpdateSelectedItem();
		UpdateSelectedValue();
		UpdateInternalSelectedItems();
	}

	internal void UpdateSelectedItems(IList selectedItems)
	{
		if (selectedItems == null)
		{
			throw new ArgumentNullException("selectedItems");
		}
		if (selectedItems.Count == SelectedItems.Count && selectedItems.Cast<object>().SequenceEqual(SelectedItems.Cast<object>()))
		{
			return;
		}
		_ignoreSelectedItemsCollectionChanged++;
		SelectedItems.Clear();
		foreach (object selectedItem in selectedItems)
		{
			SelectedItems.Add(selectedItem);
		}
		_ignoreSelectedItemsCollectionChanged--;
		UpdateFromSelectedItems();
	}

	private void UpdateFromSelectedItems()
	{
		foreach (object item in ItemsCollection)
		{
			bool flag = SelectedItems.Contains(item);
			_ignoreSelectedMemberPathValuesChanged++;
			SetSelectedMemberPathValue(item, flag);
			_ignoreSelectedMemberPathValuesChanged--;
			UpdateSelectorItem(item, flag);
		}
		UpdateSelectedItem();
		UpdateSelectedValue();
		UpdateInternalSelectedItems();
	}

	private void UpdateInternalSelectedItems()
	{
		_internalSelectedItems = new object[SelectedItems.Count];
		SelectedItems.CopyTo(_internalSelectedItems, 0);
	}

	private void UpdateSelectorItem(object item, bool isSelected, bool raiseSelectionChangedEvent = true)
	{
		if (base.ItemContainerGenerator.ContainerFromItem(item) is SelectorItem selectorItem)
		{
			selectorItem.SetIsSelected(isSelected, raiseSelectionChangedEvent);
		}
	}

	private void RemoveUnavailableSelectedItems()
	{
		_ignoreSelectedItemsCollectionChanged++;
		HashSet<object> hashSet = new HashSet<object>(ItemsCollection.Cast<object>());
		for (int i = 0; i < SelectedItems.Count; i++)
		{
			if (!hashSet.Contains(SelectedItems[i]))
			{
				_removedItems.Add(SelectedItems[i]);
				SelectedItems.RemoveAt(i);
				i--;
			}
		}
		_ignoreSelectedItemsCollectionChanged--;
		UpdateSelectedItem();
		UpdateSelectedValue();
	}

	private void AddAvailableRemovedItems()
	{
		HashSet<object> hashSet = new HashSet<object>(ItemsCollection.Cast<object>());
		for (int i = 0; i < _removedItems.Count; i++)
		{
			if (hashSet.Contains(_removedItems[i]))
			{
				SelectedItems.Add(_removedItems[i]);
				_removedItems.RemoveAt(i);
				i--;
			}
		}
	}

	private void UpdateFromSelectedValue()
	{
		List<string> selectedValues = null;
		if (!string.IsNullOrEmpty(SelectedValue))
		{
			selectedValues = SelectedValue.Split(new string[1] { Delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
		}
		UpdateFromList(selectedValues, GetItemValue);
	}

	public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
	{
		if (managerType == typeof(CollectionChangedEventManager))
		{
			if (_selectedItems == sender)
			{
				OnSelectedItemsCollectionChanged(sender, (NotifyCollectionChangedEventArgs)e);
				return true;
			}
			if (ItemsCollection == sender)
			{
				OnItemsSourceCollectionChanged(sender, (NotifyCollectionChangedEventArgs)e);
				return true;
			}
		}
		return false;
	}
}
