using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class TerminateSequence : BodyWriter
{
	private UniqueId _identifier;

	private long _lastMsgNumber;

	private ReliableMessagingVersion _reliableMessagingVersion;

	public TerminateSequence()
		: base(isBuffered: true)
	{
	}

	public TerminateSequence(ReliableMessagingVersion reliableMessagingVersion, UniqueId identifier, long last)
		: base(isBuffered: true)
	{
		_reliableMessagingVersion = reliableMessagingVersion;
		_identifier = identifier;
		_lastMsgNumber = last;
	}

	public static TerminateSequenceInfo Create(ReliableMessagingVersion reliableMessagingVersion, XmlDictionaryReader reader)
	{
		TerminateSequenceInfo terminateSequenceInfo = new TerminateSequenceInfo();
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(reliableMessagingVersion);
		reader.ReadStartElement(wsrmFeb2005Dictionary.TerminateSequence, namespaceUri);
		reader.ReadStartElement(wsrmFeb2005Dictionary.Identifier, namespaceUri);
		terminateSequenceInfo.Identifier = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11 && reader.IsStartElement(DXD.Wsrm11Dictionary.LastMsgNumber, namespaceUri))
		{
			reader.ReadStartElement();
			terminateSequenceInfo.LastMsgNumber = WsrmUtilities.ReadSequenceNumber(reader, allowZero: false);
			reader.ReadEndElement();
		}
		while (reader.IsStartElement())
		{
			reader.Skip();
		}
		reader.ReadEndElement();
		return terminateSequenceInfo;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(_reliableMessagingVersion);
		writer.WriteStartElement(wsrmFeb2005Dictionary.TerminateSequence, namespaceUri);
		writer.WriteStartElement(wsrmFeb2005Dictionary.Identifier, namespaceUri);
		writer.WriteValue(_identifier);
		writer.WriteEndElement();
		if (_reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11 && _lastMsgNumber > 0)
		{
			writer.WriteStartElement(DXD.Wsrm11Dictionary.LastMsgNumber, namespaceUri);
			writer.WriteValue(_lastMsgNumber);
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}
}
