using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class CloseSequence : BodyWriter
{
	private UniqueId _identifier;

	private long _lastMsgNumber;

	public CloseSequence(UniqueId identifier, long lastMsgNumber)
		: base(isBuffered: true)
	{
		_identifier = identifier;
		_lastMsgNumber = lastMsgNumber;
	}

	public static CloseSequenceInfo Create(XmlDictionaryReader reader)
	{
		CloseSequenceInfo closeSequenceInfo = new CloseSequenceInfo();
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(ReliableMessagingVersion.WSReliableMessaging11);
		Wsrm11Dictionary wsrm11Dictionary = DXD.Wsrm11Dictionary;
		reader.ReadStartElement(wsrm11Dictionary.CloseSequence, namespaceUri);
		reader.ReadStartElement(XD.WsrmFeb2005Dictionary.Identifier, namespaceUri);
		closeSequenceInfo.Identifier = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		if (reader.IsStartElement(wsrm11Dictionary.LastMsgNumber, namespaceUri))
		{
			reader.ReadStartElement();
			closeSequenceInfo.LastMsgNumber = WsrmUtilities.ReadSequenceNumber(reader, allowZero: false);
			reader.ReadEndElement();
		}
		while (reader.IsStartElement())
		{
			reader.Skip();
		}
		reader.ReadEndElement();
		return closeSequenceInfo;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(ReliableMessagingVersion.WSReliableMessaging11);
		Wsrm11Dictionary wsrm11Dictionary = DXD.Wsrm11Dictionary;
		writer.WriteStartElement(wsrm11Dictionary.CloseSequence, namespaceUri);
		writer.WriteStartElement(XD.WsrmFeb2005Dictionary.Identifier, namespaceUri);
		writer.WriteValue(_identifier);
		writer.WriteEndElement();
		if (_lastMsgNumber > 0)
		{
			writer.WriteStartElement(wsrm11Dictionary.LastMsgNumber, namespaceUri);
			writer.WriteValue(_lastMsgNumber);
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}
}
