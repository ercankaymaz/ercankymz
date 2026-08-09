using System.Xml;

namespace System.ServiceModel.Channels;

internal class RelatesToHeader : AddressingHeader
{
	internal class FullRelatesToHeader : RelatesToHeader
	{
		private string _actor;

		private bool _mustUnderstand;

		private bool _relay;

		public override string Actor => _actor;

		public override bool MustUnderstand => _mustUnderstand;

		public override bool Relay => _relay;

		public FullRelatesToHeader(UniqueId messageId, string actor, bool mustUnderstand, bool relay, AddressingVersion version)
			: base(messageId, version)
		{
			_actor = actor;
			_mustUnderstand = mustUnderstand;
			_relay = relay;
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteValue(base.UniqueId);
		}
	}

	private const bool mustUnderstandValue = false;

	internal static readonly Uri ReplyRelationshipType = new Uri("http://www.w3.org/2005/08/addressing/reply");

	public override XmlDictionaryString DictionaryName => XD.AddressingDictionary.RelatesTo;

	public UniqueId UniqueId { get; }

	public override bool MustUnderstand => false;

	public virtual Uri RelationshipType => ReplyRelationshipType;

	private RelatesToHeader(UniqueId messageId, AddressingVersion version)
		: base(version)
	{
		UniqueId = messageId;
	}

	public static RelatesToHeader Create(UniqueId messageId, AddressingVersion addressingVersion)
	{
		if ((object)messageId == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageId"));
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("addressingVersion"));
		}
		return new RelatesToHeader(messageId, addressingVersion);
	}

	public static RelatesToHeader Create(UniqueId messageId, AddressingVersion addressingVersion, Uri relationshipType)
	{
		if ((object)messageId == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageId"));
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("addressingVersion"));
		}
		if (relationshipType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("relationshipType"));
		}
		if (relationshipType == ReplyRelationshipType)
		{
			return new RelatesToHeader(messageId, addressingVersion);
		}
		return new FullRelatesToHeader(messageId, "", mustUnderstand: false, relay: false, addressingVersion);
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		writer.WriteValue(UniqueId);
	}

	public static void ReadHeaderValue(XmlDictionaryReader reader, AddressingVersion version, out Uri relationshipType, out UniqueId messageId)
	{
		AddressingDictionary addressingDictionary = XD.AddressingDictionary;
		relationshipType = ReplyRelationshipType;
		messageId = reader.ReadElementContentAsUniqueId();
	}

	public static RelatesToHeader ReadHeader(XmlDictionaryReader reader, AddressingVersion version, string actor, bool mustUnderstand, bool relay)
	{
		ReadHeaderValue(reader, version, out var relationshipType, out var messageId);
		if (actor.Length == 0 && !mustUnderstand && !relay && (object)relationshipType == ReplyRelationshipType)
		{
			return new RelatesToHeader(messageId, version);
		}
		return new FullRelatesToHeader(messageId, actor, mustUnderstand, relay, version);
	}
}
