using System;
using System.Globalization;
using System.Windows.Input;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Interaction;

public class ToolCommand : ICommand
{
	private string _name;

	public string Name
	{
		get
		{
			if (_name != null)
			{
				return _name;
			}
			return string.Empty;
		}
	}

	public event EventHandler CanExecuteChanged
	{
		add
		{
			throw new NotSupportedException();
		}
		remove
		{
			throw new NotSupportedException();
		}
	}

	public ToolCommand()
	{
	}

	public ToolCommand(string commandName)
	{
		if (commandName == null)
		{
			throw new ArgumentNullException("commandName");
		}
		_name = commandName;
	}

	public void Execute(GestureData data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (data.Context == null)
		{
			throw new ArgumentException(MS.Internal.Properties.Resources.Error_MissingContext);
		}
		ToolCommandBinding commandBinding = GetCommandBinding(data);
		if (commandBinding != null)
		{
			ExecutedToolEventArgs e = new ExecutedToolEventArgs(this, data);
			commandBinding.OnExecute(data.Context, e);
		}
	}

	private ToolCommandBinding GetCommandBinding(GestureData data)
	{
		Tool value = data.Context.Items.GetValue<Tool>();
		return value.GetToolCommandBinding(this, data);
	}

	public bool CanExecute(GestureData data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (data.Context == null)
		{
			throw new ArgumentException(MS.Internal.Properties.Resources.Error_MissingContext);
		}
		ToolCommandBinding commandBinding = GetCommandBinding(data);
		if (commandBinding != null)
		{
			CanExecuteToolEventArgs e = new CanExecuteToolEventArgs(this, data);
			return commandBinding.OnCanExecute(data.Context, e);
		}
		return false;
	}

	private static GestureData GetGestureData(object parameter, bool throwIfMissing)
	{
		GestureData gestureData = parameter as GestureData;
		if (gestureData == null && throwIfMissing)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ArgIncorrectType, new object[2]
			{
				"parameter",
				typeof(GestureData).Name
			}));
		}
		return gestureData;
	}

	public override string ToString()
	{
		if (_name != null)
		{
			return _name;
		}
		return base.ToString();
	}

	void ICommand.Execute(object parameter)
	{
		if (parameter == null)
		{
			throw new ArgumentNullException("parameter");
		}
		GestureData gestureData = GetGestureData(parameter, throwIfMissing: true);
		Execute(gestureData);
	}

	bool ICommand.CanExecute(object parameter)
	{
		GestureData gestureData = GetGestureData(parameter, throwIfMissing: false);
		if (gestureData == null)
		{
			return false;
		}
		return CanExecute(gestureData);
	}
}
