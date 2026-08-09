using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

public class ContextMenuUtilities
{
	public static readonly DependencyProperty OpenOnMouseLeftButtonClickProperty = DependencyProperty.RegisterAttached("OpenOnMouseLeftButtonClick", typeof(bool), typeof(ContextMenuUtilities), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OpenOnMouseLeftButtonClickChanged)));

	public static void SetOpenOnMouseLeftButtonClick(FrameworkElement element, bool value)
	{
		((DependencyObject)element).SetValue(OpenOnMouseLeftButtonClickProperty, (object)value);
	}

	public static bool GetOpenOnMouseLeftButtonClick(FrameworkElement element)
	{
		return (bool)((DependencyObject)element).GetValue(OpenOnMouseLeftButtonClickProperty);
	}

	public static void OpenOnMouseLeftButtonClickChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is FrameworkElement frameworkElement)
		{
			if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
			{
				frameworkElement.PreviewMouseLeftButtonDown += Control_PreviewMouseLeftButtonDown;
			}
			else
			{
				frameworkElement.PreviewMouseLeftButtonDown -= Control_PreviewMouseLeftButtonDown;
			}
		}
	}

	private static void Control_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		if (!(sender is FrameworkElement { ContextMenu: not null } frameworkElement))
		{
			return;
		}
		for (DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)(object)frameworkElement); parent != null; parent = VisualTreeHelper.GetParent(parent))
		{
			if (parent is PropertyItemBase dataContext)
			{
				frameworkElement.ContextMenu.DataContext = dataContext;
				break;
			}
		}
		frameworkElement.ContextMenu.PlacementTarget = frameworkElement;
		frameworkElement.ContextMenu.IsOpen = true;
	}
}
