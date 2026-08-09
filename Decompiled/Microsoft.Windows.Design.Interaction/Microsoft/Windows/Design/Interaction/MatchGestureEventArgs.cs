using System;
using System.Globalization;
using System.Windows.Input;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Interaction;

public class MatchGestureEventArgs : EventArgs
{
	internal delegate GestureData GetGestureData(Task sourceTask, InputEventArgs inputEvent);

	private InputEventArgs _inputEvent;

	private InputBinding _binding;

	private GestureData _data;

	private Task _sourceTask;

	private GetGestureData _dataCallback;

	public InputEventArgs InputEvent => _inputEvent;

	public InputBinding Binding
	{
		get
		{
			return _binding;
		}
		set
		{
			_binding = value;
		}
	}

	public GestureData Data
	{
		get
		{
			if (_data == null)
			{
				_data = _dataCallback(_sourceTask, _inputEvent);
			}
			return _data;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (!Data.GetType().IsInstanceOfType(value))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_IncompatibleGestureData, new object[2]
				{
					value.GetType().Name,
					_data.GetType().Name
				}));
			}
			_data = value;
		}
	}

	internal MatchGestureEventArgs(InputEventArgs inputEvent, InputBinding binding, Task sourceTask, GetGestureData dataCallback)
	{
		_inputEvent = inputEvent;
		_dataCallback = dataCallback;
		_sourceTask = sourceTask;
		_binding = binding;
	}
}
