using System;
using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public sealed class CanExecuteToolEventArgs : EventArgs
{
	private ICommand _command;

	private object _parameter;

	private bool _canExecute;

	public bool CanExecute
	{
		get
		{
			return _canExecute;
		}
		set
		{
			_canExecute = value;
		}
	}

	public ICommand Command => _command;

	public object Parameter => _parameter;

	internal CanExecuteToolEventArgs(ICommand command, object parameter)
	{
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		_command = command;
		_parameter = parameter;
	}
}
