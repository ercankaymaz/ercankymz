using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Xceed.Wpf.AvalonDock.Controls;

public class DropDownButton : ToggleButton
{
	public static readonly DependencyProperty DropDownContextMenuProperty = DependencyProperty.Register("DropDownContextMenu", typeof(ContextMenu), typeof(DropDownButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnDropDownContextMenuChanged)));

	public static readonly DependencyProperty DropDownContextMenuDataContextProperty = DependencyProperty.Register("DropDownContextMenuDataContext", typeof(object), typeof(DropDownButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));

	public ContextMenu DropDownContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(DropDownContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownContextMenuProperty, (object)value);
		}
	}

	public object DropDownContextMenuDataContext
	{
		get
		{
			return ((DependencyObject)this).GetValue(DropDownContextMenuDataContextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownContextMenuDataContextProperty, value);
		}
	}

	public DropDownButton()
	{
		base.Unloaded += DropDownButton_Unloaded;
	}

	private static void OnDropDownContextMenuChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DropDownButton)(object)d).OnDropDownContextMenuChanged(e);
	}

	protected virtual void OnDropDownContextMenuChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is ContextMenu contextMenu && base.IsChecked == true)
		{
			contextMenu.Closed -= OnContextMenuClosed;
		}
	}

	protected override void OnClick()
	{
		if (DropDownContextMenu != null)
		{
			DropDownContextMenu.PlacementTarget = this;
			DropDownContextMenu.Placement = PlacementMode.Bottom;
			DropDownContextMenu.DataContext = DropDownContextMenuDataContext;
			DropDownContextMenu.Closed += OnContextMenuClosed;
			DropDownContextMenu.IsOpen = true;
		}
		base.OnClick();
	}

	private void OnContextMenuClosed(object sender, RoutedEventArgs e)
	{
		(sender as ContextMenu).Closed -= OnContextMenuClosed;
		base.IsChecked = false;
	}

	private void DropDownButton_Unloaded(object sender, RoutedEventArgs e)
	{
		if (base.IsLoaded)
		{
			DropDownContextMenu = null;
		}
	}
}
