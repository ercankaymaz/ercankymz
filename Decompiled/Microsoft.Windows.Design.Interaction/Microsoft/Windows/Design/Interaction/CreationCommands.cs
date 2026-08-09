using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public static class CreationCommands
{
	private static RoutedCommand _create;

	private static ToolCommand _createAt;

	private static ToolCommand _createWithin;

	public static RoutedCommand Create => EnsureCommand(ref _create, "Create");

	public static ToolCommand CreateAt => EnsureCommand(ref _createAt, "CreateAt");

	public static ToolCommand CreateWithin => EnsureCommand(ref _createWithin, "CreateWithin");

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
			command = new RoutedCommand(name, typeof(CreationCommands));
		}
		return command;
	}
}
