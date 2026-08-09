using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmSequencedMessageHeader : WsrmMessageHeader
{
	private bool _lastMessage;

	private UniqueId _sequenceID;

	private long _sequenceNumber;

	public override XmlDictionaryString DictionaryName => XD.WsrmFeb2005Dictionary.Sequence;

	public override bool MustUnderstand => true;

	public WsrmSequencedMessageHeader(ReliableMessagingVersion reliableMessagingVersion, UniqueId sequenceID, long sequenceNumber, bool lastMessage)
		: base(reliableMessagingVersion)
	{
		_sequenceID = sequenceID;
		_sequenceNumber = sequenceNumber;
		_lastMessage = lastMessage;
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString dictionaryNamespace = DictionaryNamespace;
		writer.WriteStartElement(wsrmFeb2005Dictionary.Identifier, dictionaryNamespace);
		writer.WriteValue(_sequenceID);
		writer.WriteEndElement();
		writer.WriteStartElement(wsrmFeb2005Dictionary.MessageNumber, dictionaryNamespace);
		writer.WriteValue(_sequenceNumber);
		writer.WriteEndElement();
		if (base.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005 && _lastMessage)
		{
			writer.WriteStartElement(wsrmFeb2005Dictionary.LastMessage, dictionaryNamespace);
			writer.WriteEndElement();
		}
	}
}
