using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmUsesSequenceSTRInfo : WsrmHeaderInfo
{
	private WsrmUsesSequenceSTRInfo(MessageHeaderInfo header)
		: base(header)
	{
	}

	public static WsrmUsesSequenceSTRInfo ReadHeader(XmlDictionaryReader reader, MessageHeaderInfo header)
	{
		WsrmUtilities.ReadEmptyElement(reader);
		return new WsrmUsesSequenceSTRInfo(header);
	}
}
