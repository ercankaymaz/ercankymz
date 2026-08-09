using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class PropertyGridContextMenu : ContextMenu
{
	protected override void OnOpened(RoutedEventArgs e)
	{
		base.OnOpened(e);
		if (!(e.OriginalSource is ContextMenu { PlacementTarget: not null } contextMenu))
		{
			return;
		}
		for (DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)(object)contextMenu.PlacementTarget); parent != null; parent = VisualTreeHelper.GetParent(parent))
		{
			if (parent is PropertyItemBase dataContext)
			{
				contextMenu.DataContext = dataContext;
				break;
			}
		}
	}
}
