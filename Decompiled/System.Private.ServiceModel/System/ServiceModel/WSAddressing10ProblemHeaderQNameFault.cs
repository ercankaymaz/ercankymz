using System.Globalization;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

internal class WSAddressing10ProblemHeaderQNameFault : MessageFault
{
	internal class WSAddressing10ProblemHeaderQNameHeader : MessageHeader
	{
		private string _invalidHeaderName;

		public override string Name => "FaultDetail";

		public override string Namespace => AddressingVersion.WSAddressing10.Namespace;

		public WSAddressing10ProblemHeaderQNameHeader(string invalidHeaderName)
		{
			_invalidHeaderName = invalidHeaderName;
		}

		protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteStartElement(Name, Namespace);
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteStartElement("ProblemHeaderQName", Namespace);
			writer.WriteQualifiedName(_invalidHeaderName, Namespace);
			writer.WriteEndElement();
		}
	}

	private FaultCode _code;

	private FaultReason _reason;

	private string _actor;

	private string _node;

	private string _invalidHeaderName;

	public override string Actor => _actor;

	public override FaultCode Code => _code;

	public override bool HasDetail => true;

	public override string Node => _node;

	public override FaultReason Reason => _reason;

	public WSAddressing10ProblemHeaderQNameFault(MessageHeaderException e)
	{
		_invalidHeaderName = e.HeaderName;
		if (e.IsDuplicate)
		{
			_code = FaultCode.CreateSenderFaultCode(new FaultCode("InvalidAddressingHeader", AddressingVersion.WSAddressing10.Namespace, new FaultCode("InvalidCardinality", AddressingVersion.WSAddressing10.Namespace)));
		}
		else
		{
			_code = FaultCode.CreateSenderFaultCode(new FaultCode("MessageAddressingHeaderRequired", AddressingVersion.WSAddressing10.Namespace));
		}
		_reason = new FaultReason(e.Message, CultureInfo.CurrentCulture);
		_actor = "";
		_node = "";
	}

	public WSAddressing10ProblemHeaderQNameFault(ActionMismatchAddressingException e)
	{
		_invalidHeaderName = "Action";
		_code = FaultCode.CreateSenderFaultCode(new FaultCode("ActionMismatch", AddressingVersion.WSAddressing10.Namespace));
		_reason = new FaultReason(e.Message, CultureInfo.CurrentCulture);
		_actor = "";
		_node = "";
	}

	protected override void OnWriteDetail(XmlDictionaryWriter writer, EnvelopeVersion version)
	{
		if (version == EnvelopeVersion.Soap12)
		{
			OnWriteStartDetail(writer, version);
			OnWriteDetailContents(writer);
			writer.WriteEndElement();
		}
	}

	protected override void OnWriteDetailContents(XmlDictionaryWriter writer)
	{
		writer.WriteStartElement("ProblemHeaderQName", AddressingVersion.WSAddressing10.Namespace);
		writer.WriteQualifiedName(_invalidHeaderName, AddressingVersion.WSAddressing10.Namespace);
		writer.WriteEndElement();
	}

	public void AddHeaders(MessageHeaders headers)
	{
		if (headers.MessageVersion.Envelope == EnvelopeVersion.Soap11)
		{
			headers.Add(new WSAddressing10ProblemHeaderQNameHeader(_invalidHeaderName));
		}
	}
}
