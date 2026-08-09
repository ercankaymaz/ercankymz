using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmAckRequestedHeader : WsrmMessageHeader
{
	private UniqueId sequenceID;

	public override XmlDictionaryString DictionaryName => XD.WsrmFeb2005Dictionary.AckRequested;

	public WsrmAckRequestedHeader(ReliableMessagingVersion reliableMessagingVersion, UniqueId sequenceID)
		: base(reliableMessagingVersion)
	{
		this.sequenceID = sequenceID;
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString dictionaryNamespace = DictionaryNamespace;
		writer.WriteStartElement(wsrmFeb2005Dictionary.Identifier, dictionaryNamespace);
		writer.WriteValue(sequenceID);
		writer.WriteEndElement();
	}
}
