using System.IO;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Security;

internal sealed class SecurityVerifiedMessage : DelegatingMessage
{
	private enum BodyState
	{
		Created,
		Buffered,
		Decrypted,
		Disposed
	}

	private byte[] _decryptedBuffer;

	private XmlDictionaryReader _cachedDecryptedBodyContentReader;

	private XmlAttributeHolder[] _envelopeAttributes;

	private XmlAttributeHolder[] _headerAttributes;

	private XmlAttributeHolder[] _bodyAttributes;

	private string _envelopePrefix;

	private bool _bodyDecrypted;

	private BodyState _state;

	private string _bodyPrefix;

	private bool _isDecryptedBodyStatusDetermined;

	private bool _isDecryptedBodyFault;

	private bool _isDecryptedBodyEmpty;

	private XmlDictionaryReader _cachedReaderAtSecurityHeader;

	private XmlBuffer _messageBuffer;

	private bool _canDelegateCreateBufferedCopyToInnerMessage;

	public override bool IsEmpty
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			if (!_bodyDecrypted)
			{
				return base.InnerMessage.IsEmpty;
			}
			EnsureDecryptedBodyStatusDetermined();
			return _isDecryptedBodyEmpty;
		}
	}

	public override bool IsFault
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			if (!_bodyDecrypted)
			{
				return base.InnerMessage.IsFault;
			}
			EnsureDecryptedBodyStatusDetermined();
			return _isDecryptedBodyFault;
		}
	}

	internal byte[] PrimarySignatureValue => ReceivedSecurityHeader.PrimarySignatureValue;

	internal ReceiveSecurityHeader ReceivedSecurityHeader { get; }

	public SecurityVerifiedMessage(Message messageToProcess, ReceiveSecurityHeader securityHeader)
		: base(messageToProcess)
	{
		ReceivedSecurityHeader = securityHeader;
		if (securityHeader.RequireMessageProtection)
		{
			XmlDictionaryReader xmlDictionaryReader;
			if (base.InnerMessage is BufferedMessage bufferedMessage && Headers.ContainsOnlyBufferedMessageHeaders)
			{
				xmlDictionaryReader = bufferedMessage.GetMessageReader();
			}
			else
			{
				_messageBuffer = new XmlBuffer(int.MaxValue);
				XmlDictionaryWriter writer = _messageBuffer.OpenSection(ReceivedSecurityHeader.ReaderQuotas);
				base.InnerMessage.WriteMessage(writer);
				_messageBuffer.CloseSection();
				_messageBuffer.Close();
				xmlDictionaryReader = _messageBuffer.GetReader(0);
			}
			MoveToSecurityHeader(xmlDictionaryReader, securityHeader.HeaderIndex, captureAttributes: true);
			_cachedReaderAtSecurityHeader = xmlDictionaryReader;
			_state = BodyState.Buffered;
		}
		else
		{
			_envelopeAttributes = XmlAttributeHolder.emptyArray;
			_headerAttributes = XmlAttributeHolder.emptyArray;
			_bodyAttributes = XmlAttributeHolder.emptyArray;
			_canDelegateCreateBufferedCopyToInnerMessage = true;
		}
	}

	private Exception CreateBadStateException(string operation)
	{
		return new InvalidOperationException(System.SR.Format(System.SR.MessageBodyOperationNotValidInBodyState, operation, _state));
	}

	public XmlDictionaryReader CreateFullBodyReader()
	{
		return _state switch
		{
			BodyState.Buffered => CreateFullBodyReaderFromBufferedState(), 
			BodyState.Decrypted => CreateFullBodyReaderFromDecryptedState(), 
			_ => throw TraceUtility.ThrowHelperError(CreateBadStateException("CreateFullBodyReader"), this), 
		};
	}

	private XmlDictionaryReader CreateFullBodyReaderFromBufferedState()
	{
		if (_messageBuffer != null)
		{
			XmlDictionaryReader reader = _messageBuffer.GetReader(0);
			MoveToBody(reader);
			return reader;
		}
		return ((BufferedMessage)base.InnerMessage).GetBufferedReaderAtBody();
	}

	private XmlDictionaryReader CreateFullBodyReaderFromDecryptedState()
	{
		XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(_decryptedBuffer, 0, _decryptedBuffer.Length, ReceivedSecurityHeader.ReaderQuotas);
		MoveToBody(xmlDictionaryReader);
		return xmlDictionaryReader;
	}

	private void EnsureDecryptedBodyStatusDetermined()
	{
		if (!_isDecryptedBodyStatusDetermined)
		{
			XmlDictionaryReader xmlDictionaryReader = CreateFullBodyReader();
			if (Message.ReadStartBody(xmlDictionaryReader, base.InnerMessage.Version.Envelope, out _isDecryptedBodyFault, out _isDecryptedBodyEmpty))
			{
				_cachedDecryptedBodyContentReader = xmlDictionaryReader;
			}
			else
			{
				xmlDictionaryReader.Close();
			}
			_isDecryptedBodyStatusDetermined = true;
		}
	}

	public XmlAttributeHolder[] GetEnvelopeAttributes()
	{
		return _envelopeAttributes;
	}

	public XmlAttributeHolder[] GetHeaderAttributes()
	{
		return _headerAttributes;
	}

	private XmlDictionaryReader GetReaderAtEnvelope()
	{
		if (_messageBuffer != null)
		{
			return _messageBuffer.GetReader(0);
		}
		return ((BufferedMessage)base.InnerMessage).GetMessageReader();
	}

	public XmlDictionaryReader GetReaderAtFirstHeader()
	{
		XmlDictionaryReader readerAtEnvelope = GetReaderAtEnvelope();
		MoveToHeaderBlock(readerAtEnvelope, captureAttributes: false);
		readerAtEnvelope.ReadStartElement();
		return readerAtEnvelope;
	}

	public XmlDictionaryReader GetReaderAtSecurityHeader()
	{
		if (_cachedReaderAtSecurityHeader != null)
		{
			XmlDictionaryReader cachedReaderAtSecurityHeader = _cachedReaderAtSecurityHeader;
			_cachedReaderAtSecurityHeader = null;
			return cachedReaderAtSecurityHeader;
		}
		return Headers.GetReaderAtHeader(ReceivedSecurityHeader.HeaderIndex);
	}

	private void MoveToBody(XmlDictionaryReader reader)
	{
		if (reader.NodeType != XmlNodeType.Element)
		{
			reader.MoveToContent();
		}
		reader.ReadStartElement();
		if (reader.IsStartElement(XD.MessageDictionary.Header, Version.Envelope.DictionaryNamespace))
		{
			reader.Skip();
		}
		if (reader.NodeType != XmlNodeType.Element)
		{
			reader.MoveToContent();
		}
	}

	private void MoveToHeaderBlock(XmlDictionaryReader reader, bool captureAttributes)
	{
		if (reader.NodeType != XmlNodeType.Element)
		{
			reader.MoveToContent();
		}
		if (captureAttributes)
		{
			_envelopePrefix = reader.Prefix;
			_envelopeAttributes = XmlAttributeHolder.ReadAttributes(reader);
		}
		reader.ReadStartElement();
		reader.MoveToStartElement(XD.MessageDictionary.Header, Version.Envelope.DictionaryNamespace);
		if (captureAttributes)
		{
			_headerAttributes = XmlAttributeHolder.ReadAttributes(reader);
		}
	}

	private void MoveToSecurityHeader(XmlDictionaryReader reader, int headerIndex, bool captureAttributes)
	{
		MoveToHeaderBlock(reader, captureAttributes);
		reader.ReadStartElement();
		while (true)
		{
			if (reader.NodeType != XmlNodeType.Element)
			{
				reader.MoveToContent();
			}
			if (headerIndex != 0)
			{
				reader.Skip();
				headerIndex--;
				continue;
			}
			break;
		}
	}

	protected override void OnBodyToString(XmlDictionaryWriter writer)
	{
		if (_state == BodyState.Created)
		{
			base.OnBodyToString(writer);
		}
		else
		{
			OnWriteBodyContents(writer);
		}
	}

	protected override void OnClose()
	{
		if (_cachedDecryptedBodyContentReader != null)
		{
			try
			{
				_cachedDecryptedBodyContentReader.Close();
			}
			catch (IOException)
			{
			}
			finally
			{
				_cachedDecryptedBodyContentReader = null;
			}
		}
		if (_cachedReaderAtSecurityHeader != null)
		{
			try
			{
				_cachedReaderAtSecurityHeader.Close();
			}
			catch (IOException)
			{
			}
			finally
			{
				_cachedReaderAtSecurityHeader = null;
			}
		}
		_messageBuffer = null;
		_decryptedBuffer = null;
		_state = BodyState.Disposed;
		base.InnerMessage.Close();
	}

	protected override XmlDictionaryReader OnGetReaderAtBodyContents()
	{
		if (_state == BodyState.Created)
		{
			return base.InnerMessage.GetReaderAtBodyContents();
		}
		if (_bodyDecrypted)
		{
			EnsureDecryptedBodyStatusDetermined();
		}
		if (_cachedDecryptedBodyContentReader != null)
		{
			XmlDictionaryReader cachedDecryptedBodyContentReader = _cachedDecryptedBodyContentReader;
			_cachedDecryptedBodyContentReader = null;
			return cachedDecryptedBodyContentReader;
		}
		XmlDictionaryReader xmlDictionaryReader = CreateFullBodyReader();
		xmlDictionaryReader.ReadStartElement();
		xmlDictionaryReader.MoveToContent();
		return xmlDictionaryReader;
	}

	protected override MessageBuffer OnCreateBufferedCopy(int maxBufferSize)
	{
		if (_canDelegateCreateBufferedCopyToInnerMessage && base.InnerMessage is BufferedMessage)
		{
			return base.InnerMessage.CreateBufferedCopy(maxBufferSize);
		}
		return base.OnCreateBufferedCopy(maxBufferSize);
	}

	internal void OnMessageProtectionPassComplete(bool atLeastOneHeaderOrBodyEncrypted)
	{
		_canDelegateCreateBufferedCopyToInnerMessage = !atLeastOneHeaderOrBodyEncrypted;
	}

	protected override void OnWriteStartBody(XmlDictionaryWriter writer)
	{
		if (_state == BodyState.Created)
		{
			base.InnerMessage.WriteStartBody(writer);
			return;
		}
		XmlDictionaryReader xmlDictionaryReader = CreateFullBodyReader();
		xmlDictionaryReader.MoveToContent();
		writer.WriteStartElement(xmlDictionaryReader.Prefix, xmlDictionaryReader.LocalName, xmlDictionaryReader.NamespaceURI);
		writer.WriteAttributes(xmlDictionaryReader, defattr: false);
		xmlDictionaryReader.Close();
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		if (_state == BodyState.Created)
		{
			base.InnerMessage.WriteBodyContents(writer);
			return;
		}
		XmlDictionaryReader xmlDictionaryReader = CreateFullBodyReader();
		xmlDictionaryReader.ReadStartElement();
		while (xmlDictionaryReader.NodeType != XmlNodeType.EndElement)
		{
			writer.WriteNode(xmlDictionaryReader, defattr: false);
		}
		xmlDictionaryReader.ReadEndElement();
		xmlDictionaryReader.Close();
	}

	public void SetBodyPrefixAndAttributes(XmlDictionaryReader bodyReader)
	{
		_bodyPrefix = bodyReader.Prefix;
		_bodyAttributes = XmlAttributeHolder.ReadAttributes(bodyReader);
	}

	public void SetDecryptedBody(byte[] decryptedBodyContent)
	{
		if (_state != BodyState.Buffered)
		{
			throw TraceUtility.ThrowHelperError(CreateBadStateException("SetDecryptedBody"), this);
		}
		MemoryStream memoryStream = new MemoryStream();
		XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(memoryStream);
		xmlDictionaryWriter.WriteStartElement(_envelopePrefix, XD.MessageDictionary.Envelope, Version.Envelope.DictionaryNamespace);
		XmlAttributeHolder.WriteAttributes(_envelopeAttributes, xmlDictionaryWriter);
		xmlDictionaryWriter.WriteStartElement(_bodyPrefix, XD.MessageDictionary.Body, Version.Envelope.DictionaryNamespace);
		XmlAttributeHolder.WriteAttributes(_bodyAttributes, xmlDictionaryWriter);
		xmlDictionaryWriter.WriteString(" ");
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.Flush();
		_decryptedBuffer = ContextImportHelper.SpliceBuffers(decryptedBodyContent, memoryStream.GetBuffer(), (int)memoryStream.Length, 2);
		_bodyDecrypted = true;
		_state = BodyState.Decrypted;
	}
}
