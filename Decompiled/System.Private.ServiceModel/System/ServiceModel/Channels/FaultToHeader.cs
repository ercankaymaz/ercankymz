using System.Xml;

namespace System.ServiceModel.Channels;

internal class FaultToHeader : AddressingHeader
{
	internal class FullFaultToHeader : FaultToHeader
	{
		private string _actor;

		private bool _mustUnderstand;

		private bool _relay;

		public override string Actor => _actor;

		public override bool MustUnderstand => _mustUnderstand;

		public override bool Relay => _relay;

		public FullFaultToHeader(EndpointAddress faultTo, string actor, bool mustUnderstand, bool relay, AddressingVersion version)
			: base(faultTo, version)
		{
			_actor = actor;
			_mustUnderstand = mustUnderstand;
			_relay = relay;
		}
	}

	private const bool mustUnderstandValue = false;

	public EndpointAddress FaultTo { get; }

	public override XmlDictionaryString DictionaryName => XD.AddressingDictionary.FaultTo;

	public override bool MustUnderstand => false;

	private FaultToHeader(EndpointAddress faultTo, AddressingVersion version)
		: base(version)
	{
		FaultTo = faultTo;
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		FaultTo.WriteContentsTo(base.Version, writer);
	}

	public static FaultToHeader Create(EndpointAddress faultTo, AddressingVersion addressingVersion)
	{
		if (faultTo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("faultTo"));
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		return new FaultToHeader(faultTo, addressingVersion);
	}

	public static FaultToHeader ReadHeader(XmlDictionaryReader reader, AddressingVersion version, string actor, bool mustUnderstand, bool relay)
	{
		EndpointAddress faultTo = ReadHeaderValue(reader, version);
		if (actor.Length == 0 && !mustUnderstand && !relay)
		{
			return new FaultToHeader(faultTo, version);
		}
		return new FullFaultToHeader(faultTo, actor, mustUnderstand, relay, version);
	}

	public static EndpointAddress ReadHeaderValue(XmlDictionaryReader reader, AddressingVersion version)
	{
		return EndpointAddress.ReadFrom(version, reader);
	}
}
