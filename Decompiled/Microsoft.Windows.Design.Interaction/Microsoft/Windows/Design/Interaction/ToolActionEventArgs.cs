using System;
using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public class ToolActionEventArgs : InputEventArgs
{
	private ToolAction _toolAction;

	private EventArgs _sourceEvent;

	public ToolAction ToolAction => _toolAction;

	public EventArgs SourceEvent => _sourceEvent;

	public ToolActionEventArgs(ToolAction toolAction, InputEventArgs sourceEvent)
		: base((sourceEvent == null) ? null : sourceEvent.Device, (sourceEvent != null) ? sourceEvent.Timestamp : 0)
	{
		if (sourceEvent == null)
		{
			throw new ArgumentNullException("sourceEvent");
		}
		if (!EnumValidator.IsValid(toolAction))
		{
			throw new ArgumentOutOfRangeException("toolAction");
		}
		_toolAction = toolAction;
		_sourceEvent = (EventArgs)(object)sourceEvent;
	}

	public ToolActionEventArgs(ToolAction toolAction, EventArgs sourceEvent, InputDevice inputDevice, int timestamp)
		: base(inputDevice, timestamp)
	{
		if (sourceEvent == null)
		{
			throw new ArgumentNullException("sourceEvent");
		}
		_toolAction = toolAction;
		_sourceEvent = sourceEvent;
	}

	public override string ToString()
	{
		return string.Concat(_toolAction, " : ", ((InputEventArgs)this).Timestamp, " : ", _sourceEvent.ToString());
	}
}
