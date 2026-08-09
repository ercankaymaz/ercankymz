using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Xceed.Wpf.AvalonDock.Controls;

public class ContextMenuEx : ContextMenu
{
	static ContextMenuEx()
	{
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new MenuItemEx();
	}

	protected override void OnOpened(RoutedEventArgs e)
	{
		BindingOperations.GetBindingExpression((DependencyObject)(object)this, ItemsControl.ItemsSourceProperty).UpdateTarget();
		base.OnOpened(e);
	}
}
