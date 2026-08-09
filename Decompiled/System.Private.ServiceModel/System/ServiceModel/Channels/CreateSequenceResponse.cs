using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class CreateSequenceResponse : BodyWriter
{
	private AddressingVersion _addressingVersion;

	private ReliableMessagingVersion _reliableMessagingVersion;

	public EndpointAddress AcceptAcksTo { get; set; }

	public TimeSpan? Expires { get; set; }

	public UniqueId Identifier { get; set; }

	public bool Ordered { get; set; }

	private CreateSequenceResponse()
		: base(isBuffered: true)
	{
	}

	public CreateSequenceResponse(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion)
		: base(isBuffered: true)
	{
		_addressingVersion = addressingVersion;
		_reliableMessagingVersion = reliableMessagingVersion;
	}

	public static CreateSequenceResponseInfo Create(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion, XmlDictionaryReader reader)
	{
		CreateSequenceResponseInfo createSequenceResponseInfo = new CreateSequenceResponseInfo();
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString xmlDictionaryString = WsrmIndex.GetNamespace(reliableMessagingVersion);
		reader.ReadStartElement(wsrmFeb2005Dictionary.CreateSequenceResponse, xmlDictionaryString);
		reader.ReadStartElement(wsrmFeb2005Dictionary.Identifier, xmlDictionaryString);
		createSequenceResponseInfo.Identifier = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		if (reader.IsStartElement(wsrmFeb2005Dictionary.Expires, xmlDictionaryString))
		{
			reader.ReadElementContentAsTimeSpan();
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11 && reader.IsStartElement(DXD.Wsrm11Dictionary.IncompleteSequenceBehavior, xmlDictionaryString))
		{
			string text = reader.ReadElementContentAsString();
			if (text != "DiscardEntireSequence" && text != "DiscardFollowingFirstGap" && text != "NoDiscard")
			{
				string cSResponseWithInvalidIncompleteSequenceBehavior = System.SR.CSResponseWithInvalidIncompleteSequenceBehavior;
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(cSResponseWithInvalidIncompleteSequenceBehavior));
			}
		}
		if (reader.IsStartElement(wsrmFeb2005Dictionary.Accept, xmlDictionaryString))
		{
			reader.ReadStartElement();
			createSequenceResponseInfo.AcceptAcksTo = EndpointAddress.ReadFrom(addressingVersion, reader, wsrmFeb2005Dictionary.AcksTo, xmlDictionaryString);
			while (reader.IsStartElement())
			{
				reader.Skip();
			}
			reader.ReadEndElement();
		}
		while (reader.IsStartElement())
		{
			reader.Skip();
		}
		reader.ReadEndElement();
		return createSequenceResponseInfo;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString xmlDictionaryString = WsrmIndex.GetNamespace(_reliableMessagingVersion);
		writer.WriteStartElement(wsrmFeb2005Dictionary.CreateSequenceResponse, xmlDictionaryString);
		writer.WriteStartElement(wsrmFeb2005Dictionary.Identifier, xmlDictionaryString);
		writer.WriteValue(Identifier);
		writer.WriteEndElement();
		if (Expires.HasValue)
		{
			writer.WriteStartElement(wsrmFeb2005Dictionary.Expires, xmlDictionaryString);
			writer.WriteValue(Expires.Value);
			writer.WriteEndElement();
		}
		if (_reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			Wsrm11Dictionary wsrm11Dictionary = DXD.Wsrm11Dictionary;
			writer.WriteStartElement(wsrm11Dictionary.IncompleteSequenceBehavior, xmlDictionaryString);
			writer.WriteValue(Ordered ? wsrm11Dictionary.DiscardFollowingFirstGap : wsrm11Dictionary.NoDiscard);
			writer.WriteEndElement();
		}
		if (AcceptAcksTo != null)
		{
			writer.WriteStartElement(wsrmFeb2005Dictionary.Accept, xmlDictionaryString);
			AcceptAcksTo.WriteTo(_addressingVersion, writer, wsrmFeb2005Dictionary.AcksTo, xmlDictionaryString);
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}
}
