using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace Xceed.Wpf.Toolkit;

public class CollectionControlButton : Button
{
	public static readonly DependencyProperty EditorDefinitionsProperty;

	public static readonly DependencyProperty IsReadOnlyProperty;

	public static readonly DependencyProperty ItemsSourceProperty;

	public static readonly DependencyProperty ItemsSourceTypeProperty;

	public static readonly DependencyProperty NewItemTypesProperty;

	public static readonly RoutedEvent CollectionUpdatedEvent;

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

	public event RoutedEventHandler CollectionUpdated
	{
		add
		{
			AddHandler(CollectionUpdatedEvent, value);
		}
		remove
		{
			RemoveHandler(CollectionUpdatedEvent, value);
		}
	}

	static CollectionControlButton()
	{
		EditorDefinitionsProperty = DependencyProperty.Register("EditorDefinitions", typeof(EditorDefinitionCollection), typeof(CollectionControlButton), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CollectionControlButton), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CollectionControlButton), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		ItemsSourceTypeProperty = DependencyProperty.Register("ItemsSourceType", typeof(Type), typeof(CollectionControlButton), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		NewItemTypesProperty = DependencyProperty.Register("NewItemTypes", typeof(IList), typeof(CollectionControlButton), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CollectionUpdatedEvent = EventManager.RegisterRoutedEvent("CollectionUpdated", RoutingStrategy.Bubble, typeof(EventHandler), typeof(CollectionControlButton));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CollectionControlButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(CollectionControlButton)));
	}

	public CollectionControlButton()
	{
		base.Click += CollectionControlButton_Click;
	}

	private void CollectionControlButton_Click(object sender, RoutedEventArgs e)
	{
		CollectionControlDialog collectionControlDialog = new CollectionControlDialog();
		BindingOperations.SetBinding(binding: new Binding("ItemsSource")
		{
			Source = this,
			Mode = BindingMode.TwoWay
		}, target: (DependencyObject)(object)collectionControlDialog, dp: CollectionControlDialog.ItemsSourceProperty);
		collectionControlDialog.NewItemTypes = NewItemTypes;
		collectionControlDialog.ItemsSourceType = ItemsSourceType;
		collectionControlDialog.IsReadOnly = IsReadOnly;
		collectionControlDialog.EditorDefinitions = EditorDefinitions;
		bool? flag = collectionControlDialog.ShowDialog();
		if (flag.HasValue && flag.Value)
		{
			RaiseEvent(new RoutedEventArgs(CollectionUpdatedEvent, this));
		}
	}
}
