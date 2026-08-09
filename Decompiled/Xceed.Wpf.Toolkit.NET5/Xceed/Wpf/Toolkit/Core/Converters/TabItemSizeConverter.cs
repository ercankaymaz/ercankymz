using System;
using System.Globalization;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class TabItemSizeConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value != null)
		{
			double num = System.Convert.ToDouble(value);
			if (num > 0.0)
			{
				return num;
			}
		}
		return double.PositiveInfinity;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
