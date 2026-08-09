using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class WindowContentBorderMarginConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		double num = (double)values[0];
		double bottom = (double)values[1];
		return (string)parameter switch
		{
			"0" => new Thickness(num, 0.0, num, bottom), 
			"1" => new Thickness(0.0, 0.0, num, bottom), 
			"2" => new Thickness(0.0, 0.0, num, 0.0), 
			_ => throw new NotSupportedException("'parameter' for WindowContentBorderMarginConverter is not valid."), 
		};
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
