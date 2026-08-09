using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

public static class CalculatorCommands
{
	private static RoutedCommand _calculatorButtonClickCommand = new RoutedCommand();

	public static RoutedCommand CalculatorButtonClick => _calculatorButtonClickCommand;
}
