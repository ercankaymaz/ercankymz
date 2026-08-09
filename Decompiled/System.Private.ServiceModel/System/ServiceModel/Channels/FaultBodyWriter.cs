using System.Xml;

namespace System.ServiceModel.Channels;

internal class FaultBodyWriter : BodyWriter
{
	private MessageFault _fault;

	private EnvelopeVersion _version;

	internal override bool IsFault => true;

	public FaultBodyWriter(MessageFault fault, EnvelopeVersion version)
		: base(isBuffered: true)
	{
		_fault = fault;
		_version = version;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		_fault.WriteTo(writer, _version);
	}
}
