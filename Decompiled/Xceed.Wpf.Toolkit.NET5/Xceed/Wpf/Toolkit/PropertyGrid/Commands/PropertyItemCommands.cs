using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Commands;

public static class PropertyItemCommands
{
	private static RoutedCommand _resetValueCommand = new RoutedCommand();

	public static RoutedCommand ResetValue => _resetValueCommand;
}
