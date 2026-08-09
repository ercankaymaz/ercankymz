namespace System.ServiceModel;

internal class WSReliableMessagingFebruary2005Version : ReliableMessagingVersion
{
	internal static ReliableMessagingVersion Instance { get; } = new WSReliableMessagingFebruary2005Version();

	private WSReliableMessagingFebruary2005Version()
		: base("http://schemas.xmlsoap.org/ws/2005/02/rm", XD.WsrmFeb2005Dictionary.Namespace)
	{
	}

	public override string ToString()
	{
		return "WSReliableMessagingFebruary2005";
	}
}
