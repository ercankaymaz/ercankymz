namespace System.ServiceModel.Channels;

internal abstract class WsrmHeaderInfo
{
	public MessageHeaderInfo MessageHeader { get; }

	protected WsrmHeaderInfo(MessageHeaderInfo messageHeader)
	{
		MessageHeader = messageHeader;
	}
}
