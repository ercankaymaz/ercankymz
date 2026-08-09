using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Converters;

public class PropertyNameTextTrimmingConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return ((TextWrapping)value == TextWrapping.NoWrap) ? TextTrimming.CharacterEllipsis : TextTrimming.None;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
