using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_NewItemTypesComboBox", Type = typeof(ComboBox))]
[TemplatePart(Name = "PART_PropertyGrid", Type = typeof(Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid))]
[TemplatePart(Name = "PART_ListBox", Type = typeof(ListBox))]
public class CollectionControl : Control
{
	public delegate void ItemDeletingRoutedEventHandler(object sender, ItemDeletingEventArgs e);

	public delegate void ItemDeletedRoutedEventHandler(object sender, ItemEventArgs e);

	public delegate void ItemAddingRoutedEventHandler(object sender, ItemAddingEventArgs e);

	public delegate void ItemAddedRoutedEventHandler(object sender, ItemEventArgs e);

	public delegate void ItemMovedDownRoutedEventHandler(object sender, ItemEventArgs e);

	public delegate void ItemMovedUpRoutedEventHandler(object sender, ItemEventArgs e);

	private const string PART_NewItemTypesComboBox = "PART_NewItemTypesComboBox";

	private const string PART_PropertyGrid = "PART_PropertyGrid";

	private const string PART_ListBox = "PART_ListBox";

	private ComboBox _newItemTypesComboBox;

	private Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid _propertyGrid;

	private ListBox _listBox;

	private bool _isCollectionUpdated;

	public static readonly DependencyProperty IsReadOnlyProperty;

	public static readonly DependencyProperty ItemsProperty;

	public static readonly DependencyProperty ItemsSourceProperty;

	public static readonly DependencyProperty ItemsSourceTypeProperty;

	public static readonly DependencyProperty NewItemTypesProperty;

	public static readonly DependencyProperty PropertiesLabelProperty;

	public static readonly DependencyProperty SelectedItemProperty;

	public static readonly DependencyProperty TypeSelectionLabelProperty;

	public static readonly DependencyProperty EditorDefinitionsProperty;

	public static readonly RoutedEvent ItemDeletingEvent;

	public static readonly RoutedEvent ItemDeletedEvent;

	public static readonly RoutedEvent ItemAddingEvent;

	public static readonly RoutedEvent ItemAddedEvent;

	public static readonly RoutedEvent ItemMovedDownEvent;

	public static readonly RoutedEvent ItemMovedUpEvent;

	public bool IsReadOnly
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsReadOnlyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsReadOnlyProperty, (object)value);
		}
	}

	public ObservableCollection<object> Items
	{
		get
		{
			return (ObservableCollection<object>)((DependencyObject)this).GetValue(ItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsProperty, (object)value);
		}
	}

	public IEnumerable ItemsSource
	{
		get
		{
			return (IEnumerable)((DependencyObject)this).GetValue(ItemsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsSourceProperty, (object)value);
		}
	}

	public Type ItemsSourceType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(ItemsSourceTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsSourceTypeProperty, (object)value);
		}
	}

	public IList<Type> NewItemTypes
	{
		get
		{
			return (IList<Type>)((DependencyObject)this).GetValue(NewItemTypesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NewItemTypesProperty, (object)value);
		}
	}

	public object PropertiesLabel
	{
		get
		{
			return ((DependencyObject)this).GetValue(PropertiesLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertiesLabelProperty, value);
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

	public object TypeSelectionLabel
	{
		get
		{
			return ((DependencyObject)this).GetValue(TypeSelectionLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TypeSelectionLabelProperty, value);
		}
	}

	public EditorDefinitionCollection EditorDefinitions
	{
		get
		{
			return (EditorDefinitionCollection)((DependencyObject)this).GetValue(EditorDefinitionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditorDefinitionsProperty, (object)value);
		}
	}

	public Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid PropertyGrid
	{
		get
		{
			if (_propertyGrid == null)
			{
				ApplyTemplate();
			}
			return _propertyGrid;
		}
	}

	public event ItemDeletingRoutedEventHandler ItemDeleting
	{
		add
		{
			AddHandler(ItemDeletingEvent, value);
		}
		remove
		{
			RemoveHandler(ItemDeletingEvent, value);
		}
	}

	public event ItemDeletedRoutedEventHandler ItemDeleted
	{
		add
		{
			AddHandler(ItemDeletedEvent, value);
		}
		remove
		{
			RemoveHandler(ItemDeletedEvent, value);
		}
	}

	public event ItemAddingRoutedEventHandler ItemAdding
	{
		add
		{
			AddHandler(ItemAddingEvent, value);
		}
		remove
		{
			RemoveHandler(ItemAddingEvent, value);
		}
	}

	public event ItemAddedRoutedEventHandler ItemAdded
	{
		add
		{
			AddHandler(ItemAddedEvent, value);
		}
		remove
		{
			RemoveHandler(ItemAddedEvent, value);
		}
	}

	public event ItemMovedDownRoutedEventHandler ItemMovedDown
	{
		add
		{
			AddHandler(ItemMovedDownEvent, value);
		}
		remove
		{
			RemoveHandler(ItemMovedDownEvent, value);
		}
	}

	public event ItemMovedUpRoutedEventHandler ItemMovedUp
	{
		add
		{
			AddHandler(ItemMovedUpEvent, value);
		}
		remove
		{
			RemoveHandler(ItemMovedUpEvent, value);
		}
	}

	private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CollectionControl)(object)d)?.OnItemSourceChanged((IEnumerable)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IEnumerable)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public void OnItemSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
		if (newValue == null)
		{
			return;
		}
		if (newValue is IDictionary dictionary)
		{
			{
				foreach (DictionaryEntry item2 in dictionary)
				{
					Type keyType = ((item2.Key != null) ? item2.Key.GetType() : ((dictionary.GetType().GetGenericArguments().Count() > 0) ? dictionary.GetType().GetGenericArguments()[0] : typeof(object)));
					Type valueType = ((item2.Value != null) ? item2.Value.GetType() : ((dictionary.GetType().GetGenericArguments().Count() > 1) ? dictionary.GetType().GetGenericArguments()[1] : typeof(object)));
					object item = ListUtilities.CreateEditableKeyValuePair(item2.Key, keyType, item2.Value, valueType);
					Items.Add(item);
				}
				return;
			}
		}
		foreach (object item3 in newValue)
		{
			if (item3 != null)
			{
				Items.Add(item3);
			}
		}
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_newItemTypesComboBox != null)
		{
			_newItemTypesComboBox.Loaded -= NewItemTypesComboBox_Loaded;
		}
		_newItemTypesComboBox = GetTemplateChild("PART_NewItemTypesComboBox") as ComboBox;
		if (_newItemTypesComboBox != null)
		{
			_newItemTypesComboBox.Loaded += NewItemTypesComboBox_Loaded;
		}
		_listBox = GetTemplateChild("PART_ListBox") as ListBox;
		if (_propertyGrid != null)
		{
			_propertyGrid.PropertyValueChanged -= PropertyGrid_PropertyValueChanged;
		}
		_propertyGrid = GetTemplateChild("PART_PropertyGrid") as Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid;
		if (_propertyGrid != null)
		{
			_propertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
		}
	}

	static CollectionControl()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<object>), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnItemsSourceChanged)));
		ItemsSourceTypeProperty = DependencyProperty.Register("ItemsSourceType", typeof(Type), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		NewItemTypesProperty = DependencyProperty.Register("NewItemTypes", typeof(IList), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		PropertiesLabelProperty = DependencyProperty.Register("PropertiesLabel", typeof(object), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Properties:"));
		SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		TypeSelectionLabelProperty = DependencyProperty.Register("TypeSelectionLabel", typeof(object), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Select type:"));
		EditorDefinitionsProperty = DependencyProperty.Register("EditorDefinitions", typeof(EditorDefinitionCollection), typeof(CollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		ItemDeletingEvent = EventManager.RegisterRoutedEvent("ItemDeleting", RoutingStrategy.Bubble, typeof(ItemDeletingRoutedEventHandler), typeof(CollectionControl));
		ItemDeletedEvent = EventManager.RegisterRoutedEvent("ItemDeleted", RoutingStrategy.Bubble, typeof(ItemDeletedRoutedEventHandler), typeof(CollectionControl));
		ItemAddingEvent = EventManager.RegisterRoutedEvent("ItemAdding", RoutingStrategy.Bubble, typeof(ItemAddingRoutedEventHandler), typeof(CollectionControl));
		ItemAddedEvent = EventManager.RegisterRoutedEvent("ItemAdded", RoutingStrategy.Bubble, typeof(ItemAddedRoutedEventHandler), typeof(CollectionControl));
		ItemMovedDownEvent = EventManager.RegisterRoutedEvent("ItemMovedDown", RoutingStrategy.Bubble, typeof(ItemMovedDownRoutedEventHandler), typeof(CollectionControl));
		ItemMovedUpEvent = EventManager.RegisterRoutedEvent("ItemMovedUp", RoutingStrategy.Bubble, typeof(ItemMovedUpRoutedEventHandler), typeof(CollectionControl));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CollectionControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(CollectionControl)));
	}

	public CollectionControl()
	{
		Items = new ObservableCollection<object>();
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.New, AddNew, CanAddNew));
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, Delete, CanDelete));
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, Duplicate, CanDuplicate));
		base.CommandBindings.Add(new CommandBinding(ComponentCommands.MoveDown, MoveDown, CanMoveDown));
		base.CommandBindings.Add(new CommandBinding(ComponentCommands.MoveUp, MoveUp, CanMoveUp));
	}

	private void NewItemTypesComboBox_Loaded(object sender, RoutedEventArgs e)
	{
		if (_newItemTypesComboBox != null)
		{
			_newItemTypesComboBox.SelectedIndex = 0;
		}
	}

	private void PropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		if (_listBox != null)
		{
			_isCollectionUpdated = true;
			((DispatcherObject)_listBox).Dispatcher.BeginInvoke((DispatcherPriority)5, (Delegate)(Action)delegate
			{
				_listBox.Items.Refresh();
			});
		}
	}

	private void AddNew(object sender, ExecutedRoutedEventArgs e)
	{
		object newItem = CreateNewItem((Type)e.Parameter);
		AddNewCore(newItem);
	}

	private void CanAddNew(object sender, CanExecuteRoutedEventArgs e)
	{
		Type t = e.Parameter as Type;
		CanAddNewCore(t, e);
	}

	private void CanAddNewCore(Type t, CanExecuteRoutedEventArgs e)
	{
		if (t != null && !IsReadOnly && ((t.IsValueType && !t.IsEnum && !t.IsPrimitive) || t.GetConstructor(Type.EmptyTypes) != null))
		{
			e.CanExecute = true;
		}
	}

	private void AddNewCore(object newItem)
	{
		if (newItem == null)
		{
			throw new ArgumentNullException("newItem");
		}
		ItemAddingEventArgs e = new ItemAddingEventArgs(ItemAddingEvent, newItem);
		RaiseEvent(e);
		if (!e.Cancel)
		{
			newItem = e.Item;
			Items.Add(newItem);
			RaiseEvent(new ItemEventArgs(ItemAddedEvent, newItem));
			_isCollectionUpdated = true;
			SelectedItem = newItem;
		}
	}

	private void Delete(object sender, ExecutedRoutedEventArgs e)
	{
		ItemDeletingEventArgs e2 = new ItemDeletingEventArgs(ItemDeletingEvent, e.Parameter);
		RaiseEvent(e2);
		if (!e2.Cancel)
		{
			Items.Remove(e.Parameter);
			RaiseEvent(new ItemEventArgs(ItemDeletedEvent, e.Parameter));
			_isCollectionUpdated = true;
		}
	}

	private void CanDelete(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = e.Parameter != null && !IsReadOnly;
	}

	private void Duplicate(object sender, ExecutedRoutedEventArgs e)
	{
		object newItem = DuplicateItem(e);
		AddNewCore(newItem);
	}

	private void CanDuplicate(object sender, CanExecuteRoutedEventArgs e)
	{
		Type t = ((e.Parameter != null) ? e.Parameter.GetType() : null);
		CanAddNewCore(t, e);
	}

	private object DuplicateItem(ExecutedRoutedEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		object parameter = e.Parameter;
		Type type = parameter.GetType();
		if (typeof(ICloneable).IsAssignableFrom(type))
		{
			return ((ICloneable)parameter).Clone();
		}
		object obj = CreateNewItem(type);
		Type type2 = type;
		while (type2 != null)
		{
			FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(obj, fieldInfo.GetValue(parameter));
			}
			type2 = type2.BaseType;
		}
		return obj;
	}

	private void MoveDown(object sender, ExecutedRoutedEventArgs e)
	{
		object parameter = e.Parameter;
		int num = Items.IndexOf(parameter);
		Items.RemoveAt(num);
		Items.Insert(++num, parameter);
		RaiseEvent(new ItemEventArgs(ItemMovedDownEvent, parameter));
		_isCollectionUpdated = true;
		SelectedItem = parameter;
	}

	private void CanMoveDown(object sender, CanExecuteRoutedEventArgs e)
	{
		if (e.Parameter != null && Items.IndexOf(e.Parameter) < Items.Count - 1 && !IsReadOnly)
		{
			e.CanExecute = true;
		}
	}

	private void MoveUp(object sender, ExecutedRoutedEventArgs e)
	{
		object parameter = e.Parameter;
		int num = Items.IndexOf(parameter);
		Items.RemoveAt(num);
		Items.Insert(--num, parameter);
		RaiseEvent(new ItemEventArgs(ItemMovedUpEvent, parameter));
		_isCollectionUpdated = true;
		SelectedItem = parameter;
	}

	private void CanMoveUp(object sender, CanExecuteRoutedEventArgs e)
	{
		if (e.Parameter != null && Items.IndexOf(e.Parameter) > 0 && !IsReadOnly)
		{
			e.CanExecute = true;
		}
	}

	public bool PersistChanges()
	{
		PersistChanges(Items);
		return _isCollectionUpdated;
	}

	internal void PersistChanges(IList sourceList)
	{
		IEnumerable enumerable = ComputeItemsSource();
		if (enumerable == null)
		{
			return;
		}
		if (enumerable is IDictionary)
		{
			IDictionary dictionary = (IDictionary)enumerable;
			dictionary.Clear();
			{
				foreach (object source in sourceList)
				{
					PropertyInfo property = source.GetType().GetProperty("Key");
					PropertyInfo property2 = source.GetType().GetProperty("Value");
					if (property != null && property2 != null)
					{
						dictionary.Add(property.GetValue(source, null), property2.GetValue(source, null));
					}
				}
				return;
			}
		}
		if (enumerable is IList)
		{
			IList list = (IList)enumerable;
			list.Clear();
			if (list.IsFixedSize)
			{
				if (sourceList.Count > list.Count)
				{
					throw new IndexOutOfRangeException("Exceeding array size.");
				}
				for (int i = 0; i < sourceList.Count; i++)
				{
					list[i] = sourceList[i];
				}
				return;
			}
			{
				foreach (object source2 in sourceList)
				{
					list.Add(source2);
				}
				return;
			}
		}
		Type type = enumerable.GetType().GetInterfaces().FirstOrDefault((Type x) => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
		if (!(type != null))
		{
			return;
		}
		Type type2 = type.GetGenericArguments().FirstOrDefault();
		if (!(type2 != null))
		{
			return;
		}
		Type type3 = typeof(ICollection<>).MakeGenericType(type2);
		type3.GetMethod("Clear").Invoke(enumerable, null);
		foreach (object source3 in sourceList)
		{
			type3.GetMethod("Add").Invoke(enumerable, new object[1] { source3 });
		}
	}

	private IEnumerable CreateItemsSource()
	{
		IEnumerable result = null;
		if (ItemsSourceType != null)
		{
			ConstructorInfo constructor = ItemsSourceType.GetConstructor(Type.EmptyTypes);
			if (constructor != null)
			{
				result = (IEnumerable)constructor.Invoke(null);
			}
			else if (ItemsSourceType.IsArray)
			{
				result = Array.CreateInstance(ItemsSourceType.GetElementType(), Items.Count);
			}
		}
		return result;
	}

	private object CreateNewItem(Type type)
	{
		return Activator.CreateInstance(type);
	}

	private IEnumerable ComputeItemsSource()
	{
		if (ItemsSource == null)
		{
			ItemsSource = CreateItemsSource();
		}
		return ItemsSource;
	}
}
