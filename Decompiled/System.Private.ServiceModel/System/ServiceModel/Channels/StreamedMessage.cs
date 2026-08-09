using System.Runtime;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class StreamedMessage : ReceivedMessage
{
	private MessageHeaders _headers;

	private XmlAttributeHolder[] _envelopeAttributes;

	private XmlAttributeHolder[] _headerAttributes;

	private XmlAttributeHolder[] _bodyAttributes;

	private string _envelopePrefix;

	private string _headerPrefix;

	private string _bodyPrefix;

	private MessageProperties _properties;

	private XmlDictionaryReader _reader;

	private XmlDictionaryReaderQuotas _quotas;

	public override MessageHeaders Headers
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			return _headers;
		}
	}

	public override MessageVersion Version => _headers.MessageVersion;

	public override MessageProperties Properties => _properties;

	public StreamedMessage(XmlDictionaryReader reader, int maxSizeOfHeaders, MessageVersion desiredVersion)
	{
		_properties = new MessageProperties();
		if (reader.NodeType != XmlNodeType.Element)
		{
			reader.MoveToContent();
		}
		if (desiredVersion.Envelope == EnvelopeVersion.None)
		{
			_reader = reader;
			_headerAttributes = XmlAttributeHolder.emptyArray;
			_headers = new MessageHeaders(desiredVersion);
			return;
		}
		_envelopeAttributes = XmlAttributeHolder.ReadAttributes(reader, ref maxSizeOfHeaders);
		_envelopePrefix = reader.Prefix;
		EnvelopeVersion envelopeVersion = ReceivedMessage.ReadStartEnvelope(reader);
		if (desiredVersion.Envelope != envelopeVersion)
		{
			Exception ex = new ArgumentException(System.SR.Format(System.SR.EncoderEnvelopeVersionMismatch, envelopeVersion, desiredVersion.Envelope), "reader");
			throw TraceUtility.ThrowHelperError(new CommunicationException(ex.Message, ex), this);
		}
		if (ReceivedMessage.HasHeaderElement(reader, envelopeVersion))
		{
			_headerPrefix = reader.Prefix;
			_headerAttributes = XmlAttributeHolder.ReadAttributes(reader, ref maxSizeOfHeaders);
			_headers = new MessageHeaders(desiredVersion, reader, _envelopeAttributes, _headerAttributes, ref maxSizeOfHeaders);
		}
		else
		{
			_headerAttributes = XmlAttributeHolder.emptyArray;
			_headers = new MessageHeaders(desiredVersion);
		}
		if (reader.NodeType != XmlNodeType.Element)
		{
			reader.MoveToContent();
		}
		_bodyPrefix = reader.Prefix;
		ReceivedMessage.VerifyStartBody(reader, envelopeVersion);
		_bodyAttributes = XmlAttributeHolder.ReadAttributes(reader, ref maxSizeOfHeaders);
		if (ReadStartBody(reader))
		{
			_reader = reader;
			return;
		}
		_quotas = new XmlDictionaryReaderQuotas();
		reader.Quotas.CopyTo(_quotas);
		reader.Dispose();
	}

	protected override void OnBodyToString(XmlDictionaryWriter writer)
	{
		writer.WriteString(System.SR.MessageBodyIsStream);
	}

	protected override void OnClose()
	{
		Exception ex = null;
		try
		{
			base.OnClose();
		}
		catch (Exception ex2)
		{
			if (Fx.IsFatal(ex2))
			{
				throw;
			}
			ex = ex2;
		}
		try
		{
			_properties.Dispose();
		}
		catch (Exception ex3)
		{
			if (Fx.IsFatal(ex3))
			{
				throw;
			}
			if (ex == null)
			{
				ex = ex3;
			}
		}
		try
		{
			if (_reader != null)
			{
				_reader.Dispose();
			}
		}
		catch (Exception ex4)
		{
			if (Fx.IsFatal(ex4))
			{
				throw;
			}
			if (ex == null)
			{
				ex = ex4;
			}
		}
		if (ex != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
		}
	}

	protected override XmlDictionaryReader OnGetReaderAtBodyContents()
	{
		XmlDictionaryReader reader = _reader;
		_reader = null;
		return reader;
	}

	protected override MessageBuffer OnCreateBufferedCopy(int maxBufferSize)
	{
		if (_reader != null)
		{
			return OnCreateBufferedCopy(maxBufferSize, _reader.Quotas);
		}
		return OnCreateBufferedCopy(maxBufferSize, _quotas);
	}

	protected override void OnWriteStartBody(XmlDictionaryWriter writer)
	{
		writer.WriteStartElement(_bodyPrefix, "Body", Version.Envelope.Namespace);
		XmlAttributeHolder.WriteAttributes(_bodyAttributes, writer);
	}

	protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
	{
		EnvelopeVersion envelope = Version.Envelope;
		writer.WriteStartElement(_envelopePrefix, "Envelope", envelope.Namespace);
		XmlAttributeHolder.WriteAttributes(_envelopeAttributes, writer);
	}

	protected override void OnWriteStartHeaders(XmlDictionaryWriter writer)
	{
		EnvelopeVersion envelope = Version.Envelope;
		writer.WriteStartElement(_headerPrefix, "Header", envelope.Namespace);
		XmlAttributeHolder.WriteAttributes(_headerAttributes, writer);
	}

	protected override string OnGetBodyAttribute(string localName, string ns)
	{
		return XmlAttributeHolder.GetAttribute(_bodyAttributes, localName, ns);
	}
}
