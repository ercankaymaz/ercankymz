using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Converters;

public class BorderThicknessConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		Thickness? thickness = value as Thickness?;
		if (thickness.HasValue)
		{
			return new Thickness(thickness.Value.Left, thickness.Value.Top, thickness.Value.Left, thickness.Value.Bottom);
		}
		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
