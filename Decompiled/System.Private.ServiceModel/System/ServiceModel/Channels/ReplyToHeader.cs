using System.Xml;

namespace System.ServiceModel.Channels;

internal class ReplyToHeader : AddressingHeader
{
	internal class FullReplyToHeader : ReplyToHeader
	{
		private string _actor;

		private bool _mustUnderstand;

		private bool _relay;

		public override string Actor => _actor;

		public override bool MustUnderstand => _mustUnderstand;

		public override bool Relay => _relay;

		public FullReplyToHeader(EndpointAddress replyTo, string actor, bool mustUnderstand, bool relay, AddressingVersion version)
			: base(replyTo, version)
		{
			_actor = actor;
			_mustUnderstand = mustUnderstand;
			_relay = relay;
		}
	}

	private const bool mustUnderstandValue = false;

	private static ReplyToHeader s_anonymousReplyToHeader10;

	public EndpointAddress ReplyTo { get; }

	public override XmlDictionaryString DictionaryName => XD.AddressingDictionary.ReplyTo;

	public override bool MustUnderstand => false;

	public static ReplyToHeader AnonymousReplyTo10
	{
		get
		{
			if (s_anonymousReplyToHeader10 == null)
			{
				s_anonymousReplyToHeader10 = new ReplyToHeader(EndpointAddress.AnonymousAddress, AddressingVersion.WSAddressing10);
			}
			return s_anonymousReplyToHeader10;
		}
	}

	private ReplyToHeader(EndpointAddress replyTo, AddressingVersion version)
		: base(version)
	{
		ReplyTo = replyTo;
	}

	public static ReplyToHeader Create(EndpointAddress replyTo, AddressingVersion addressingVersion)
	{
		if (replyTo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("replyTo"));
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("addressingVersion"));
		}
		return new ReplyToHeader(replyTo, addressingVersion);
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		ReplyTo.WriteContentsTo(base.Version, writer);
	}

	public static ReplyToHeader ReadHeader(XmlDictionaryReader reader, AddressingVersion version, string actor, bool mustUnderstand, bool relay)
	{
		EndpointAddress endpointAddress = ReadHeaderValue(reader, version);
		if (actor.Length == 0 && !mustUnderstand && !relay)
		{
			if ((object)endpointAddress == EndpointAddress.AnonymousAddress)
			{
				if (version == AddressingVersion.WSAddressing10)
				{
					return AnonymousReplyTo10;
				}
				throw ExceptionHelper.PlatformNotSupported();
			}
			return new ReplyToHeader(endpointAddress, version);
		}
		return new FullReplyToHeader(endpointAddress, actor, mustUnderstand, relay, version);
	}

	public static EndpointAddress ReadHeaderValue(XmlDictionaryReader reader, AddressingVersion version)
	{
		return EndpointAddress.ReadFrom(version, reader);
	}
}
