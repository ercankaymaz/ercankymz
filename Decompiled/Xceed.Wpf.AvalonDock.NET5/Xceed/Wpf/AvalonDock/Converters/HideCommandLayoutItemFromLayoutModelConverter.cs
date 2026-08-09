using System;
using System.Globalization;
using System.Windows.Data;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Converters;

public class HideCommandLayoutItemFromLayoutModelConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!(value is LayoutContent layoutContent))
		{
			return null;
		}
		if (layoutContent.Root == null)
		{
			return null;
		}
		if (layoutContent.Root.Manager == null)
		{
			return null;
		}
		if (!(layoutContent.Root.Manager.GetLayoutItemFromModel(layoutContent) is LayoutAnchorableItem layoutAnchorableItem))
		{
			return Binding.DoNothing;
		}
		return layoutAnchorableItem.HideCommand;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
