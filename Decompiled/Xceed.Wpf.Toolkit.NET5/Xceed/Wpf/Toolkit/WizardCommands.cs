using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

public static class WizardCommands
{
	private static RoutedCommand _cancelCommand = new RoutedCommand();

	private static RoutedCommand _finishCommand = new RoutedCommand();

	private static RoutedCommand _helpCommand = new RoutedCommand();

	private static RoutedCommand _nextPageCommand = new RoutedCommand();

	private static RoutedCommand _previousPageCommand = new RoutedCommand();

	private static RoutedCommand _selectPageCommand = new RoutedCommand();

	public static RoutedCommand Cancel => _cancelCommand;

	public static RoutedCommand Finish => _finishCommand;

	public static RoutedCommand Help => _helpCommand;

	public static RoutedCommand NextPage => _nextPageCommand;

	public static RoutedCommand PreviousPage => _previousPageCommand;

	public static RoutedCommand SelectPage => _selectPageCommand;
}
