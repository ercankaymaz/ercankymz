using System.Windows;

namespace Xceed.Wpf.AvalonDock.Controls;

internal abstract class DropTargetBase : DependencyObject
{
	public static readonly DependencyProperty IsDraggingOverProperty = DependencyProperty.RegisterAttached("IsDraggingOver", typeof(bool), typeof(DropTargetBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static bool GetIsDraggingOver(DependencyObject d)
	{
		return (bool)d.GetValue(IsDraggingOverProperty);
	}

	public static void SetIsDraggingOver(DependencyObject d, bool value)
	{
		d.SetValue(IsDraggingOverProperty, (object)value);
	}
}
