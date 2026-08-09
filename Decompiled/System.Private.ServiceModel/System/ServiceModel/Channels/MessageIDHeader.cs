using System.Xml;

namespace System.ServiceModel.Channels;

internal class MessageIDHeader : AddressingHeader
{
	internal class FullMessageIDHeader : MessageIDHeader
	{
		private string _actor;

		private bool _mustUnderstand;

		private bool _relay;

		public override string Actor => _actor;

		public override bool MustUnderstand => _mustUnderstand;

		public override bool Relay => _relay;

		public FullMessageIDHeader(UniqueId messageId, string actor, bool mustUnderstand, bool relay, AddressingVersion version)
			: base(messageId, version)
		{
			_actor = actor;
			_mustUnderstand = mustUnderstand;
			_relay = relay;
		}
	}

	private const bool mustUnderstandValue = false;

	public override XmlDictionaryString DictionaryName => XD.AddressingDictionary.MessageId;

	public UniqueId MessageId { get; }

	public override bool MustUnderstand => false;

	private MessageIDHeader(UniqueId messageId, AddressingVersion version)
		: base(version)
	{
		MessageId = messageId;
	}

	public static MessageIDHeader Create(UniqueId messageId, AddressingVersion addressingVersion)
	{
		if ((object)messageId == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageId"));
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("addressingVersion"));
		}
		return new MessageIDHeader(messageId, addressingVersion);
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		writer.WriteValue(MessageId);
	}

	public static UniqueId ReadHeaderValue(XmlDictionaryReader reader, AddressingVersion version)
	{
		return reader.ReadElementContentAsUniqueId();
	}

	public static MessageIDHeader ReadHeader(XmlDictionaryReader reader, AddressingVersion version, string actor, bool mustUnderstand, bool relay)
	{
		UniqueId messageId = ReadHeaderValue(reader, version);
		if (actor.Length == 0 && !mustUnderstand && !relay)
		{
			return new MessageIDHeader(messageId, version);
		}
		return new FullMessageIDHeader(messageId, actor, mustUnderstand, relay, version);
	}
}
