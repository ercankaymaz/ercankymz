using System;
using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public sealed class ExecutedToolEventArgs : EventArgs
{
	private ICommand _command;

	private object _parameter;

	public ICommand Command => _command;

	public object Parameter => _parameter;

	internal ExecutedToolEventArgs(ICommand command, object parameter)
	{
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		_command = command;
		_parameter = parameter;
	}
}
