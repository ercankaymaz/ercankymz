using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmAckRequestedInfo : WsrmHeaderInfo
{
	public UniqueId SequenceID { get; }

	public WsrmAckRequestedInfo(UniqueId sequenceID, MessageHeaderInfo header)
		: base(header)
	{
		SequenceID = sequenceID;
	}

	public static WsrmAckRequestedInfo ReadHeader(ReliableMessagingVersion reliableMessagingVersion, XmlDictionaryReader reader, MessageHeaderInfo header)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(reliableMessagingVersion);
		reader.ReadStartElement();
		reader.ReadStartElement(wsrmFeb2005Dictionary.Identifier, namespaceUri);
		UniqueId sequenceID = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005 && reader.IsStartElement(wsrmFeb2005Dictionary.MessageNumber, namespaceUri))
		{
			reader.ReadStartElement();
			WsrmUtilities.ReadSequenceNumber(reader, allowZero: true);
			reader.ReadEndElement();
		}
		while (reader.IsStartElement())
		{
			reader.Skip();
		}
		reader.ReadEndElement();
		return new WsrmAckRequestedInfo(sequenceID, header);
	}
}
