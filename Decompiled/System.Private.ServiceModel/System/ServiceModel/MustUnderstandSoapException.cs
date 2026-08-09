using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

[Serializable]
internal class MustUnderstandSoapException : CommunicationException
{
	internal class NotUnderstoodHeader : MessageHeader
	{
		private string _notUnderstoodName;

		private string _notUnderstoodNs;

		public override string Name => "NotUnderstood";

		public override string Namespace => "http://www.w3.org/2003/05/soap-envelope";

		public NotUnderstoodHeader(string name, string ns)
		{
			_notUnderstoodName = name;
			_notUnderstoodNs = ns;
		}

		protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteStartElement(Name, Namespace);
			writer.WriteXmlnsAttribute(null, _notUnderstoodNs);
			writer.WriteStartAttribute("qname");
			writer.WriteQualifiedName(_notUnderstoodName, _notUnderstoodNs);
			writer.WriteEndAttribute();
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
		}
	}

	private EnvelopeVersion _envelopeVersion;

	public Collection<MessageHeaderInfo> NotUnderstoodHeaders { get; }

	public EnvelopeVersion EnvelopeVersion => _envelopeVersion;

	public MustUnderstandSoapException()
	{
	}

	protected MustUnderstandSoapException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public MustUnderstandSoapException(Collection<MessageHeaderInfo> notUnderstoodHeaders, EnvelopeVersion envelopeVersion)
	{
		NotUnderstoodHeaders = notUnderstoodHeaders;
		_envelopeVersion = envelopeVersion;
	}

	internal Message ProvideFault(MessageVersion messageVersion)
	{
		string name = NotUnderstoodHeaders[0].Name;
		string p = NotUnderstoodHeaders[0].Namespace;
		FaultCode code = new FaultCode("MustUnderstand", _envelopeVersion.Namespace);
		FaultReason reason = new FaultReason(System.SR.Format(System.SR.SFxHeaderNotUnderstood, name, p), CultureInfo.CurrentCulture);
		MessageFault fault = MessageFault.CreateFault(code, reason);
		string defaultFaultAction = messageVersion.Addressing.DefaultFaultAction;
		Message message = System.ServiceModel.Channels.Message.CreateMessage(messageVersion, fault, defaultFaultAction);
		if (_envelopeVersion == EnvelopeVersion.Soap12)
		{
			AddNotUnderstoodHeaders(message.Headers);
		}
		return message;
	}

	private void AddNotUnderstoodHeaders(MessageHeaders headers)
	{
		for (int i = 0; i < NotUnderstoodHeaders.Count; i++)
		{
			headers.Add(new NotUnderstoodHeader(NotUnderstoodHeaders[i].Name, NotUnderstoodHeaders[i].Namespace));
		}
	}
}
