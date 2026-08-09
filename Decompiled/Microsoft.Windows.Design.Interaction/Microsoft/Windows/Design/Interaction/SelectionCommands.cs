using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public static class SelectionCommands
{
	private static RoutedCommand _clear;

	private static RoutedCommand _selectNext;

	private static RoutedCommand _selectPrevious;

	private static ToolCommand _selectTarget;

	private static ToolCommand _onlySelectTarget;

	private static ToolCommand _toggleSelectTarget;

	private static ToolCommand _unionSelectTarget;

	private static ToolCommand _showEvent;

	public static RoutedCommand Clear => EnsureCommand(ref _clear, "ClearSelection");

	public static RoutedCommand SelectAll => (RoutedCommand)(object)ApplicationCommands.SelectAll;

	public static RoutedCommand SelectNext => EnsureCommand(ref _selectNext, "SelectNext");

	public static RoutedCommand SelectPrevious => EnsureCommand(ref _selectPrevious, "SelectPrevious");

	public static ToolCommand SelectTarget => EnsureCommand(ref _selectTarget, "SelectTarget");

	public static ToolCommand SelectOnlyTarget => EnsureCommand(ref _onlySelectTarget, "SelectOnlyTarget");

	public static ToolCommand ToggleSelectTarget => EnsureCommand(ref _toggleSelectTarget, "ToggleSelectTarget");

	public static ToolCommand UnionSelectTarget => EnsureCommand(ref _unionSelectTarget, "UnionSelectTarget");

	public static ToolCommand ShowEvent => EnsureCommand(ref _showEvent, "ShowEvent");

	private static ToolCommand EnsureCommand(ref ToolCommand command, string name)
	{
		if (command == null)
		{
			command = new ToolCommand(name);
		}
		return command;
	}

	private static RoutedCommand EnsureCommand(ref RoutedCommand command, string name)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		if (command == null)
		{
			command = new RoutedCommand(name, typeof(SelectionCommands));
		}
		return command;
	}
}
