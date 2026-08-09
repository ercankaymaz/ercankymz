using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class CloseSequenceResponse : BodyWriter
{
	private readonly UniqueId _identifier;

	public CloseSequenceResponse(UniqueId identifier)
		: base(isBuffered: true)
	{
		_identifier = identifier;
	}

	public static CloseSequenceResponseInfo Create(XmlDictionaryReader reader)
	{
		CloseSequenceResponseInfo closeSequenceResponseInfo = new CloseSequenceResponseInfo();
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(ReliableMessagingVersion.WSReliableMessaging11);
		reader.ReadStartElement(DXD.Wsrm11Dictionary.CloseSequenceResponse, namespaceUri);
		reader.ReadStartElement(XD.WsrmFeb2005Dictionary.Identifier, namespaceUri);
		closeSequenceResponseInfo.Identifier = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		while (reader.IsStartElement())
		{
			reader.Skip();
		}
		reader.ReadEndElement();
		return closeSequenceResponseInfo;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(ReliableMessagingVersion.WSReliableMessaging11);
		writer.WriteStartElement(DXD.Wsrm11Dictionary.CloseSequenceResponse, namespaceUri);
		writer.WriteStartElement(XD.WsrmFeb2005Dictionary.Identifier, namespaceUri);
		writer.WriteValue(_identifier);
		writer.WriteEndElement();
		writer.WriteEndElement();
	}
}
