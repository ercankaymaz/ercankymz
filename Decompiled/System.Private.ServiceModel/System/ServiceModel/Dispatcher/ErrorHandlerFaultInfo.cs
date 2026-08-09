using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal struct ErrorHandlerFaultInfo(string defaultFaultAction)
{
	private string _defaultFaultAction = defaultFaultAction;

	public Message Fault { get; set; } = null;

	public string DefaultFaultAction
	{
		get
		{
			return _defaultFaultAction;
		}
		set
		{
			_defaultFaultAction = value;
		}
	}

	public bool IsConsideredUnhandled { get; set; } = false;
}
