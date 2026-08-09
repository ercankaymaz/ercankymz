using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Commands;

public class PropertyGridCommands
{
	private static RoutedCommand _clearFilterCommand = new RoutedCommand();

	public static RoutedCommand ClearFilter => _clearFilterCommand;
}
