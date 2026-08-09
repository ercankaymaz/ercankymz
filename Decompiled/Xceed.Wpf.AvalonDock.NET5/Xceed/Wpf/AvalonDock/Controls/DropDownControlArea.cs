using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Xceed.Wpf.AvalonDock.Controls;

public class DropDownControlArea : UserControl
{
	public static readonly DependencyProperty DropDownContextMenuProperty = DependencyProperty.Register("DropDownContextMenu", typeof(ContextMenu), typeof(DropDownControlArea), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));

	public static readonly DependencyProperty DropDownContextMenuDataContextProperty = DependencyProperty.Register("DropDownContextMenuDataContext", typeof(object), typeof(DropDownControlArea), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));

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

	protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
	{
		base.OnMouseRightButtonDown(e);
	}

	protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
	{
		base.OnPreviewMouseRightButtonUp(e);
		if (!e.Handled && DropDownContextMenu != null)
		{
			DropDownContextMenu.PlacementTarget = null;
			DropDownContextMenu.Placement = PlacementMode.MousePoint;
			DropDownContextMenu.HorizontalOffset = 0.0;
			DropDownContextMenu.VerticalOffset = 0.0;
			DropDownContextMenu.DataContext = DropDownContextMenuDataContext;
			DropDownContextMenu.IsOpen = true;
		}
	}
}
