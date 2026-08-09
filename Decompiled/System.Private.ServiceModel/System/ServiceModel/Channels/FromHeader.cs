using System.Xml;

namespace System.ServiceModel.Channels;

internal class FromHeader : AddressingHeader
{
	internal class FullFromHeader : FromHeader
	{
		private string _actor;

		private bool _mustUnderstand;

		private bool _relay;

		public override string Actor => _actor;

		public override bool MustUnderstand => _mustUnderstand;

		public override bool Relay => _relay;

		public FullFromHeader(EndpointAddress from, string actor, bool mustUnderstand, bool relay, AddressingVersion version)
			: base(from, version)
		{
			_actor = actor;
			_mustUnderstand = mustUnderstand;
			_relay = relay;
		}
	}

	private const bool mustUnderstandValue = false;

	public EndpointAddress From { get; }

	public override XmlDictionaryString DictionaryName => XD.AddressingDictionary.From;

	public override bool MustUnderstand => false;

	private FromHeader(EndpointAddress from, AddressingVersion version)
		: base(version)
	{
		From = from;
	}

	public static FromHeader Create(EndpointAddress from, AddressingVersion addressingVersion)
	{
		if (from == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("from"));
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		return new FromHeader(from, addressingVersion);
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		From.WriteContentsTo(base.Version, writer);
	}

	public static FromHeader ReadHeader(XmlDictionaryReader reader, AddressingVersion version, string actor, bool mustUnderstand, bool relay)
	{
		EndpointAddress endpointAddress = ReadHeaderValue(reader, version);
		if (actor.Length == 0 && !mustUnderstand && !relay)
		{
			return new FromHeader(endpointAddress, version);
		}
		return new FullFromHeader(endpointAddress, actor, mustUnderstand, relay, version);
	}

	public static EndpointAddress ReadHeaderValue(XmlDictionaryReader reader, AddressingVersion addressingVersion)
	{
		return EndpointAddress.ReadFrom(addressingVersion, reader);
	}
}
