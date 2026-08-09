using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class BufferedMessage : ReceivedMessage
{
	private MessageHeaders _headers;

	private MessageProperties _properties;

	private RecycledMessageState _recycledMessageState;

	private XmlDictionaryReader _reader;

	private XmlAttributeHolder[] _bodyAttributes;

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

	internal IBufferedMessageData MessageData { get; private set; }

	public override MessageProperties Properties
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			return _properties;
		}
	}

	internal override RecycledMessageState RecycledMessageState => _recycledMessageState;

	public override MessageVersion Version => _headers.MessageVersion;

	public BufferedMessage(IBufferedMessageData messageData, RecycledMessageState recycledMessageState)
		: this(messageData, recycledMessageState, null, understoodHeadersModified: false)
	{
	}

	public BufferedMessage(IBufferedMessageData messageData, RecycledMessageState recycledMessageState, bool[] understoodHeaders, bool understoodHeadersModified)
	{
		bool flag = true;
		try
		{
			_recycledMessageState = recycledMessageState;
			MessageData = messageData;
			_properties = recycledMessageState.TakeProperties();
			if (_properties == null)
			{
				_properties = new MessageProperties();
			}
			XmlDictionaryReader messageReader = messageData.GetMessageReader();
			MessageVersion messageVersion = messageData.MessageEncoder.MessageVersion;
			if (messageVersion.Envelope == EnvelopeVersion.None)
			{
				_reader = messageReader;
				_headers = new MessageHeaders(messageVersion);
			}
			else
			{
				EnvelopeVersion envelopeVersion = ReceivedMessage.ReadStartEnvelope(messageReader);
				if (messageVersion.Envelope != envelopeVersion)
				{
					Exception ex = new ArgumentException(System.SR.Format(System.SR.EncoderEnvelopeVersionMismatch, envelopeVersion, messageVersion.Envelope), "reader");
					throw TraceUtility.ThrowHelperError(new CommunicationException(ex.Message, ex), this);
				}
				if (ReceivedMessage.HasHeaderElement(messageReader, envelopeVersion))
				{
					_headers = recycledMessageState.TakeHeaders();
					if (_headers == null)
					{
						_headers = new MessageHeaders(messageVersion, messageReader, messageData, recycledMessageState, understoodHeaders, understoodHeadersModified);
					}
					else
					{
						_headers.Init(messageVersion, messageReader, messageData, recycledMessageState, understoodHeaders, understoodHeadersModified);
					}
				}
				else
				{
					_headers = new MessageHeaders(messageVersion);
				}
				ReceivedMessage.VerifyStartBody(messageReader, envelopeVersion);
				int maxSizeOfHeaders = int.MaxValue;
				_bodyAttributes = XmlAttributeHolder.ReadAttributes(messageReader, ref maxSizeOfHeaders);
				if (maxSizeOfHeaders < 2147479551)
				{
					_bodyAttributes = null;
				}
				if (ReadStartBody(messageReader))
				{
					_reader = messageReader;
				}
				else
				{
					messageReader.Dispose();
				}
			}
			flag = false;
		}
		finally
		{
			if (flag && MessageLogger.LoggingEnabled)
			{
				MessageLogger.LogMessage(messageData.Buffer, MessageLoggingSource.Malformed);
			}
		}
	}

	protected override XmlDictionaryReader OnGetReaderAtBodyContents()
	{
		XmlDictionaryReader reader = _reader;
		_reader = null;
		return reader;
	}

	internal override XmlDictionaryReader GetReaderAtHeader()
	{
		if (!_headers.ContainsOnlyBufferedMessageHeaders)
		{
			return base.GetReaderAtHeader();
		}
		XmlDictionaryReader messageReader = MessageData.GetMessageReader();
		if (messageReader.NodeType != XmlNodeType.Element)
		{
			messageReader.MoveToContent();
		}
		messageReader.Read();
		if (ReceivedMessage.HasHeaderElement(messageReader, _headers.MessageVersion.Envelope))
		{
			return messageReader;
		}
		return base.GetReaderAtHeader();
	}

	public XmlDictionaryReader GetBufferedReaderAtBody()
	{
		XmlDictionaryReader messageReader = MessageData.GetMessageReader();
		if (messageReader.NodeType != XmlNodeType.Element)
		{
			messageReader.MoveToContent();
		}
		if (Version.Envelope != EnvelopeVersion.None)
		{
			messageReader.Read();
			if (ReceivedMessage.HasHeaderElement(messageReader, _headers.MessageVersion.Envelope))
			{
				messageReader.Skip();
			}
			if (messageReader.NodeType != XmlNodeType.Element)
			{
				messageReader.MoveToContent();
			}
		}
		return messageReader;
	}

	public XmlDictionaryReader GetMessageReader()
	{
		return MessageData.GetMessageReader();
	}

	protected override void OnBodyToString(XmlDictionaryWriter writer)
	{
		using XmlDictionaryReader xmlDictionaryReader = GetBufferedReaderAtBody();
		if (Version == MessageVersion.None)
		{
			writer.WriteNode(xmlDictionaryReader, defattr: false);
		}
		else if (!xmlDictionaryReader.IsEmptyElement)
		{
			xmlDictionaryReader.ReadStartElement();
			while (xmlDictionaryReader.NodeType != XmlNodeType.EndElement)
			{
				writer.WriteNode(xmlDictionaryReader, defattr: false);
			}
		}
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
		try
		{
			_recycledMessageState.ReturnHeaders(_headers);
			_recycledMessageState.ReturnProperties(_properties);
			MessageData.ReturnMessageState(_recycledMessageState);
			_recycledMessageState = null;
			MessageData.Close();
			MessageData = null;
		}
		catch (Exception ex5)
		{
			if (Fx.IsFatal(ex5))
			{
				throw;
			}
			if (ex == null)
			{
				ex = ex5;
			}
		}
		if (ex != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
		}
	}

	protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
	{
		using XmlDictionaryReader xmlDictionaryReader = GetMessageReader();
		xmlDictionaryReader.MoveToContent();
		EnvelopeVersion envelope = Version.Envelope;
		writer.WriteStartElement(xmlDictionaryReader.Prefix, "Envelope", envelope.Namespace);
		writer.WriteAttributes(xmlDictionaryReader, defattr: false);
	}

	protected override void OnWriteStartHeaders(XmlDictionaryWriter writer)
	{
		using XmlDictionaryReader xmlDictionaryReader = GetMessageReader();
		xmlDictionaryReader.MoveToContent();
		EnvelopeVersion envelope = Version.Envelope;
		xmlDictionaryReader.Read();
		if (ReceivedMessage.HasHeaderElement(xmlDictionaryReader, envelope))
		{
			writer.WriteStartElement(xmlDictionaryReader.Prefix, "Header", envelope.Namespace);
			writer.WriteAttributes(xmlDictionaryReader, defattr: false);
		}
		else
		{
			writer.WriteStartElement("s", "Header", envelope.Namespace);
		}
	}

	protected override void OnWriteStartBody(XmlDictionaryWriter writer)
	{
		using XmlDictionaryReader xmlDictionaryReader = GetBufferedReaderAtBody();
		writer.WriteStartElement(xmlDictionaryReader.Prefix, "Body", Version.Envelope.Namespace);
		writer.WriteAttributes(xmlDictionaryReader, defattr: false);
	}

	protected override MessageBuffer OnCreateBufferedCopy(int maxBufferSize)
	{
		if (_headers.ContainsOnlyBufferedMessageHeaders)
		{
			KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[Properties.Count];
			((ICollection<KeyValuePair<string, object>>)Properties).CopyTo(array, 0);
			MessageData.EnableMultipleUsers();
			bool[] array2 = null;
			if (_headers.HasMustUnderstandBeenModified)
			{
				array2 = new bool[_headers.Count];
				for (int i = 0; i < _headers.Count; i++)
				{
					array2[i] = _headers.IsUnderstood(i);
				}
			}
			return new BufferedMessageBuffer(MessageData, array, array2, _headers.HasMustUnderstandBeenModified);
		}
		if (_reader != null)
		{
			return OnCreateBufferedCopy(maxBufferSize, _reader.Quotas);
		}
		return OnCreateBufferedCopy(maxBufferSize, XmlDictionaryReaderQuotas.Max);
	}

	protected override string OnGetBodyAttribute(string localName, string ns)
	{
		if (_bodyAttributes != null)
		{
			return XmlAttributeHolder.GetAttribute(_bodyAttributes, localName, ns);
		}
		using XmlDictionaryReader xmlDictionaryReader = GetBufferedReaderAtBody();
		return xmlDictionaryReader.GetAttribute(localName, ns);
	}
}
