using System;
using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public class CommandExceptionEventArgs : EventArgs
{
	private ICommand _command;

	private Exception _exception;

	public ICommand Command => _command;

	public Exception Exception => _exception;

	public CommandExceptionEventArgs(ICommand command, Exception exception)
	{
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		_command = command;
		_exception = exception;
	}
}
