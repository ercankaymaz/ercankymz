using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.AvalonDock.Converters;

public class AnchorableContextMenuHideVisibilityConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values.Count() == 2 && values[0] != DependencyProperty.UnsetValue && values[1] != DependencyProperty.UnsetValue && values[1] is bool)
		{
			if (!(bool)values[1])
			{
				return values[0];
			}
			return Visibility.Collapsed;
		}
		return values[0];
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
