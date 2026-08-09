using System;
using System.Globalization;
using System.Windows.Data;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Converters;

[ValueConversion(typeof(AnchorSide), typeof(double))]
public class AnchorSideToAngleConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		AnchorSide anchorSide = (AnchorSide)value;
		if (anchorSide == AnchorSide.Left || anchorSide == AnchorSide.Right)
		{
			return 90.0;
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
