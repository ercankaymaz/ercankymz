using System.ServiceModel.Channels;

namespace System.ServiceModel;

public class OptionalReliableSession : ReliableSession
{
	public bool Enabled { get; set; }

	public OptionalReliableSession()
	{
	}

	public OptionalReliableSession(ReliableSessionBindingElement reliableSessionBindingElement)
		: base(reliableSessionBindingElement)
	{
	}

	internal void CopySettings(OptionalReliableSession copyFrom)
	{
		CopySettings((ReliableSession)copyFrom);
		Enabled = copyFrom.Enabled;
	}
}
