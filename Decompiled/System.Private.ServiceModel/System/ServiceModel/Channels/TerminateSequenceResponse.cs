using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class TerminateSequenceResponse : BodyWriter
{
	public UniqueId Identifier { get; set; }

	public TerminateSequenceResponse()
		: base(isBuffered: true)
	{
	}

	public TerminateSequenceResponse(UniqueId identifier)
		: base(isBuffered: true)
	{
		Identifier = identifier;
	}

	public static TerminateSequenceResponseInfo Create(XmlDictionaryReader reader)
	{
		TerminateSequenceResponseInfo terminateSequenceResponseInfo = new TerminateSequenceResponseInfo();
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(ReliableMessagingVersion.WSReliableMessaging11);
		reader.ReadStartElement(DXD.Wsrm11Dictionary.TerminateSequenceResponse, namespaceUri);
		reader.ReadStartElement(XD.WsrmFeb2005Dictionary.Identifier, namespaceUri);
		terminateSequenceResponseInfo.Identifier = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		while (reader.IsStartElement())
		{
			reader.Skip();
		}
		reader.ReadEndElement();
		return terminateSequenceResponseInfo;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(ReliableMessagingVersion.WSReliableMessaging11);
		writer.WriteStartElement(DXD.Wsrm11Dictionary.TerminateSequenceResponse, namespaceUri);
		writer.WriteStartElement(XD.WsrmFeb2005Dictionary.Identifier, namespaceUri);
		writer.WriteValue(Identifier);
		writer.WriteEndElement();
		writer.WriteEndElement();
	}
}
