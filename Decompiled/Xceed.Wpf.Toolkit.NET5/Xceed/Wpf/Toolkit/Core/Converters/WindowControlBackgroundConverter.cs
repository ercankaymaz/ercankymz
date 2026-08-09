using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class WindowControlBackgroundConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		Brush brush = (Brush)values[0];
		double opacity = (double)values[1];
		if (brush != null && ((DependencyObject)brush).ReadLocalValue(Brush.OpacityProperty) == DependencyProperty.UnsetValue)
		{
			brush = brush.Clone();
			brush.Opacity = opacity;
		}
		return brush;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
