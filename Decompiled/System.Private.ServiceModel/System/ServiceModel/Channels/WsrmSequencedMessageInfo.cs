using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmSequencedMessageInfo : WsrmHeaderInfo
{
	public UniqueId SequenceID { get; }

	public long SequenceNumber { get; }

	public bool LastMessage { get; }

	private WsrmSequencedMessageInfo(UniqueId sequenceID, long sequenceNumber, bool lastMessage, MessageHeaderInfo header)
		: base(header)
	{
		SequenceID = sequenceID;
		SequenceNumber = sequenceNumber;
		LastMessage = lastMessage;
	}

	public static WsrmSequencedMessageInfo ReadHeader(ReliableMessagingVersion reliableMessagingVersion, XmlDictionaryReader reader, MessageHeaderInfo header)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(reliableMessagingVersion);
		reader.ReadStartElement();
		reader.ReadStartElement(wsrmFeb2005Dictionary.Identifier, namespaceUri);
		UniqueId sequenceID = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		reader.ReadStartElement(wsrmFeb2005Dictionary.MessageNumber, namespaceUri);
		long sequenceNumber = WsrmUtilities.ReadSequenceNumber(reader);
		reader.ReadEndElement();
		bool lastMessage = false;
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005 && reader.IsStartElement(wsrmFeb2005Dictionary.LastMessage, namespaceUri))
		{
			WsrmUtilities.ReadEmptyElement(reader);
			lastMessage = true;
		}
		while (reader.IsStartElement())
		{
			reader.Skip();
		}
		reader.ReadEndElement();
		return new WsrmSequencedMessageInfo(sequenceID, sequenceNumber, lastMessage, header);
	}
}
