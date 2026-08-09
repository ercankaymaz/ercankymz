using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Converters;

[Obsolete("This class is no longer used internaly and may be removed in a future release")]
public class SliderThumbWidthConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is Slider)
		{
			string text = parameter.ToString();
			if (text == "0")
			{
				return RangeSlider.GetThumbWidth((Slider)value);
			}
			if (text == "1")
			{
				return RangeSlider.GetThumbHeight((Slider)value);
			}
		}
		return 0.0;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
