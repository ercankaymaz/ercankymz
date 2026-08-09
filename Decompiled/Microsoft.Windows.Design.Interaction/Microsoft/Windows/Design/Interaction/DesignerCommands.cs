using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public static class DesignerCommands
{
	private static RoutedCommand _cancel;

	public static RoutedCommand Cancel => EnsureCommand(ref _cancel, "Cancel");

	private static RoutedCommand EnsureCommand(ref RoutedCommand command, string name)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		if (command == null)
		{
			command = new RoutedCommand(name, typeof(DesignerCommands));
		}
		return command;
	}
}
