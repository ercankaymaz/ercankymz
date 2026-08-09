using System;

namespace Microsoft.Windows.Design.Interaction;

public class ToolCommandBinding
{
	private ToolCommand _command;

	public ToolCommand Command
	{
		get
		{
			return _command;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_command = value;
		}
	}

	public event ExecutedToolEventHandler Execute;

	public event CanExecuteToolEventHandler CanExecute;

	public ToolCommandBinding()
	{
	}

	public ToolCommandBinding(ToolCommand command)
	{
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		Command = command;
	}

	public ToolCommandBinding(ToolCommand command, ExecutedToolEventHandler executedToolEventHandler)
	{
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		if (executedToolEventHandler == null)
		{
			throw new ArgumentNullException("executedToolEventHandler");
		}
		Execute += executedToolEventHandler;
		Command = command;
	}

	public ToolCommandBinding(ToolCommand command, ExecutedToolEventHandler executedToolEventHandler, CanExecuteToolEventHandler canExecuteToolEventHandler)
	{
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		if (executedToolEventHandler == null)
		{
			throw new ArgumentNullException("executedToolEventHandler");
		}
		if (canExecuteToolEventHandler == null)
		{
			throw new ArgumentNullException("canExecuteToolEventHandler");
		}
		CanExecute += canExecuteToolEventHandler;
		Execute += executedToolEventHandler;
		Command = command;
	}

	internal bool OnCanExecute(EditingContext sender, CanExecuteToolEventArgs e)
	{
		if (this.CanExecute != null)
		{
			this.CanExecute(sender, e);
			if (!e.CanExecute)
			{
				return false;
			}
		}
		return e.CanExecute = this.Execute != null;
	}

	internal bool OnExecute(EditingContext sender, ExecutedToolEventArgs e)
	{
		CanExecuteToolEventArgs e2 = new CanExecuteToolEventArgs(_command, e.Parameter);
		if (this.Execute != null && OnCanExecute(sender, e2))
		{
			this.Execute(sender, e);
			return true;
		}
		return false;
	}
}
