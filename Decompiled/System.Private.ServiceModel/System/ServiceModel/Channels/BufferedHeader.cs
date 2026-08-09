using System.Xml;

namespace System.ServiceModel.Channels;

internal class BufferedHeader : ReadableMessageHeader
{
	private MessageVersion _version;

	private XmlBuffer _buffer;

	private int _bufferIndex;

	private string _actor;

	private bool _relay;

	private bool _mustUnderstand;

	private string _name;

	private string _ns;

	private bool _streamed;

	private bool _isRefParam;

	public override string Actor => _actor;

	public override bool IsReferenceParameter => _isRefParam;

	public override string Name => _name;

	public override string Namespace => _ns;

	public override bool MustUnderstand => _mustUnderstand;

	public override bool Relay => _relay;

	public BufferedHeader(MessageVersion version, XmlBuffer buffer, int bufferIndex, string name, string ns, bool mustUnderstand, string actor, bool relay, bool isRefParam)
	{
		_version = version;
		_buffer = buffer;
		_bufferIndex = bufferIndex;
		_name = name;
		_ns = ns;
		_mustUnderstand = mustUnderstand;
		_actor = actor;
		_relay = relay;
		_isRefParam = isRefParam;
	}

	public BufferedHeader(MessageVersion version, XmlBuffer buffer, int bufferIndex, MessageHeaderInfo headerInfo)
	{
		_version = version;
		_buffer = buffer;
		_bufferIndex = bufferIndex;
		_actor = headerInfo.Actor;
		_relay = headerInfo.Relay;
		_name = headerInfo.Name;
		_ns = headerInfo.Namespace;
		_isRefParam = headerInfo.IsReferenceParameter;
		_mustUnderstand = headerInfo.MustUnderstand;
	}

	public BufferedHeader(MessageVersion version, XmlBuffer buffer, XmlDictionaryReader reader, XmlAttributeHolder[] envelopeAttributes, XmlAttributeHolder[] headerAttributes)
	{
		_streamed = true;
		_buffer = buffer;
		_version = version;
		MessageHeader.GetHeaderAttributes(reader, version, out _actor, out _mustUnderstand, out _relay, out _isRefParam);
		_name = reader.LocalName;
		_ns = reader.NamespaceURI;
		_bufferIndex = buffer.SectionCount;
		XmlDictionaryWriter xmlDictionaryWriter = buffer.OpenSection(reader.Quotas);
		xmlDictionaryWriter.WriteStartElement("Envelope");
		if (envelopeAttributes != null)
		{
			XmlAttributeHolder.WriteAttributes(envelopeAttributes, xmlDictionaryWriter);
		}
		xmlDictionaryWriter.WriteStartElement("Header");
		if (headerAttributes != null)
		{
			XmlAttributeHolder.WriteAttributes(headerAttributes, xmlDictionaryWriter);
		}
		xmlDictionaryWriter.WriteNode(reader, defattr: false);
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.WriteEndElement();
		buffer.CloseSection();
	}

	public override bool IsMessageVersionSupported(MessageVersion messageVersion)
	{
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageVersion"));
		}
		return messageVersion == _version;
	}

	public override XmlDictionaryReader GetHeaderReader()
	{
		XmlDictionaryReader reader = _buffer.GetReader(_bufferIndex);
		if (_streamed)
		{
			reader.MoveToContent();
			reader.Read();
			reader.Read();
			reader.MoveToContent();
		}
		return reader;
	}
}
