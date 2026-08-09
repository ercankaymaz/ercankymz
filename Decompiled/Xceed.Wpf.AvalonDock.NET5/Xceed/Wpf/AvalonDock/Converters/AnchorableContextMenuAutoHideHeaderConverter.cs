using System;
using System.Globalization;
using System.Windows.Data;
using Xceed.Wpf.AvalonDock.Properties;

namespace Xceed.Wpf.AvalonDock.Converters;

public class AnchorableContextMenuAutoHideHeaderConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		bool? flag = value as bool?;
		if (!flag.HasValue || !flag.Value)
		{
			return Resources.Anchorable_AutoHide;
		}
		return Resources.Window_Restore;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
