namespace System.ServiceModel;

internal class WSReliableMessaging11Version : ReliableMessagingVersion
{
	internal static ReliableMessagingVersion Instance { get; } = new WSReliableMessaging11Version();

	private WSReliableMessaging11Version()
		: base("http://docs.oasis-open.org/ws-rx/wsrm/200702", DXD.Wsrm11Dictionary.Namespace)
	{
	}

	public override string ToString()
	{
		return "WSReliableMessaging11";
	}
}
