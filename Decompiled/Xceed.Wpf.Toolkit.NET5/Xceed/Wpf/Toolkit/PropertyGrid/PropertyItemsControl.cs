using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class PropertyItemsControl : ItemsControl
{
	internal static readonly RoutedEvent PreparePropertyItemEvent = EventManager.RegisterRoutedEvent("PreparePropertyItem", RoutingStrategy.Bubble, typeof(PropertyItemEventHandler), typeof(PropertyItemsControl));

	internal static readonly RoutedEvent ClearPropertyItemEvent = EventManager.RegisterRoutedEvent("ClearPropertyItem", RoutingStrategy.Bubble, typeof(PropertyItemEventHandler), typeof(PropertyItemsControl));

	internal event PropertyItemEventHandler PreparePropertyItem
	{
		add
		{
			AddHandler(PreparePropertyItemEvent, value);
		}
		remove
		{
			RemoveHandler(PreparePropertyItemEvent, value);
		}
	}

	internal event PropertyItemEventHandler ClearPropertyItem
	{
		add
		{
			AddHandler(ClearPropertyItemEvent, value);
		}
		remove
		{
			RemoveHandler(ClearPropertyItemEvent, value);
		}
	}

	public PropertyItemsControl()
	{
		base.Initialized += PropertyItemsControl_Initialized;
	}

	private void RaisePreparePropertyItemEvent(PropertyItemBase propertyItem, object item)
	{
		RaiseEvent(new PropertyItemEventArgs(PreparePropertyItemEvent, this, propertyItem, item));
	}

	private void RaiseClearPropertyItemEvent(PropertyItemBase propertyItem, object item)
	{
		RaiseEvent(new PropertyItemEventArgs(ClearPropertyItemEvent, this, propertyItem, item));
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is PropertyItemBase;
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		base.PrepareContainerForItemOverride(element, item);
		RaisePreparePropertyItemEvent((PropertyItemBase)(object)element, item);
	}

	protected override void ClearContainerForItemOverride(DependencyObject element, object item)
	{
		RaiseClearPropertyItemEvent((PropertyItemBase)(object)element, item);
		base.ClearContainerForItemOverride(element, item);
	}

	private void PropertyItemsControl_Initialized(object sender, EventArgs e)
	{
		if (!(sender is PropertyItemsControl propertyItemsControl))
		{
			return;
		}
		if (propertyItemsControl.TemplatedParent is PropertyGrid propertyGrid)
		{
			if (propertyGrid.IsVirtualizing)
			{
				SetVirtualizingWhenGrouping();
			}
		}
		else if (propertyItemsControl.TemplatedParent is PropertyItem { ParentElement: PropertyGrid { IsVirtualizing: not false } })
		{
			SetVirtualizingWhenGrouping();
		}
	}

	private void SetVirtualizingWhenGrouping()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, new Attribute[1] { (Attribute)new PropertyFilterAttribute((PropertyFilterOptions)15) });
		properties.Find("VirtualizingPanel.IsVirtualizingWhenGrouping", ignoreCase: false)?.SetValue(this, true);
		PropertyDescriptor propertyDescriptor = properties.Find("VirtualizingPanel.CacheLengthUnit", ignoreCase: false);
		propertyDescriptor?.SetValue(this, Enum.ToObject(propertyDescriptor.PropertyType, 1));
	}
}
