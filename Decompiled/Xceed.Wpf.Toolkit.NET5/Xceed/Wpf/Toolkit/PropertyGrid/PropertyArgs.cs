using System.ComponentModel;
using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class PropertyArgs : RoutedEventArgs
{
	public PropertyDescriptor PropertyDescriptor { get; private set; }

	public PropertyArgs(PropertyDescriptor pd)
	{
		PropertyDescriptor = pd;
	}
}
