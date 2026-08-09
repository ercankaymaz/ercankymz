using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.Primitives;

public class SelectorItem : ContentControl
{
	private bool m_raiseSelectionChangedEvent = true;

	public static readonly DependencyProperty IsSelectedProperty;

	public static readonly RoutedEvent SelectedEvent;

	public static readonly RoutedEvent UnselectedEvent;

	public bool? IsSelected
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	internal Selector ParentSelector => ItemsControl.ItemsControlFromItemContainer((DependencyObject)(object)this) as Selector;

	static SelectorItem()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool?), typeof(SelectorItem), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsSelectedChanged)));
		SelectedEvent = Selector.SelectedEvent.AddOwner(typeof(SelectorItem));
		UnselectedEvent = Selector.UnSelectedEvent.AddOwner(typeof(SelectorItem));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectorItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(SelectorItem)));
	}

	private static void OnIsSelectedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is SelectorItem selectorItem)
		{
			selectorItem.OnIsSelectedChanged((bool?)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool?)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsSelectedChanged(bool? oldValue, bool? newValue)
	{
		if (m_raiseSelectionChangedEvent && newValue.HasValue)
		{
			if (newValue.Value)
			{
				RaiseEvent(new RoutedEventArgs(Selector.SelectedEvent, this));
			}
			else
			{
				RaiseEvent(new RoutedEventArgs(Selector.UnSelectedEvent, this));
			}
		}
	}

	internal void SetIsSelected(bool isSelected, bool raiseSelectionChangedEvent = true)
	{
		m_raiseSelectionChangedEvent = raiseSelectionChangedEvent;
		IsSelected = isSelected;
		m_raiseSelectionChangedEvent = true;
	}
}
