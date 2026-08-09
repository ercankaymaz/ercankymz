using System.Collections.Generic;
using System.IO;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Diagnostics;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class BinaryMessageEncoderFactory : MessageEncoderFactory
{
	internal class BinaryBufferedMessageData : BufferedMessageData
	{
		private BinaryMessageEncoderFactory _factory;

		private BinaryMessageEncoder _messageEncoder;

		private Pool<XmlDictionaryReader> _readerPool;

		private OnXmlDictionaryReaderClose _onClose;

		public override MessageEncoder MessageEncoder => _messageEncoder;

		public override XmlDictionaryReaderQuotas Quotas => _factory.ReaderQuotas;

		public BinaryBufferedMessageData(BinaryMessageEncoderFactory factory, int maxPoolSize)
			: base(factory.RecycledStatePool)
		{
			_factory = factory;
			_readerPool = new Pool<XmlDictionaryReader>(maxPoolSize);
			_onClose = base.OnXmlReaderClosed;
		}

		public void SetMessageEncoder(BinaryMessageEncoder messageEncoder)
		{
			_messageEncoder = messageEncoder;
		}

		protected override XmlDictionaryReader TakeXmlReader()
		{
			ArraySegment<byte> buffer = base.Buffer;
			return XmlDictionaryReader.CreateBinaryReader(buffer.Array, buffer.Offset, buffer.Count, _factory._binaryVersion.Dictionary, _factory._bufferedReadReaderQuotas, _messageEncoder.ReaderSession);
		}

		protected override void ReturnXmlReader(XmlDictionaryReader reader)
		{
			_readerPool.Return(reader);
		}

		protected override void OnClosed()
		{
			_factory.ReturnBufferedData(this);
		}
	}

	internal class BinaryBufferedMessageWriter : BufferedMessageWriter
	{
		private IXmlDictionary _dictionary;

		private XmlBinaryWriterSession _session;

		public BinaryBufferedMessageWriter(IXmlDictionary dictionary)
		{
			_dictionary = dictionary;
		}

		public BinaryBufferedMessageWriter(IXmlDictionary dictionary, XmlBinaryWriterSession session)
		{
			_dictionary = dictionary;
			_session = session;
		}

		protected override XmlDictionaryWriter TakeXmlWriter(Stream stream)
		{
			return XmlDictionaryWriter.CreateBinaryWriter(stream, _dictionary, _session, ownsStream: false);
		}

		protected override void ReturnXmlWriter(XmlDictionaryWriter writer)
		{
			writer.Dispose();
		}
	}

	internal class BinaryMessageEncoder : MessageEncoder, ICompressedMessageEncoder
	{
		private const string SupportedCompressionTypesMessageProperty = "BinaryMessageEncoder.SupportedCompressionTypes";

		private BinaryMessageEncoderFactory _factory;

		private bool _isSession;

		private XmlBinaryWriterSessionWithQuota _writerSession;

		private BinaryBufferedMessageWriter _sessionMessageWriter;

		private XmlBinaryReaderSession _readerSessionForLogging;

		private bool _readerSessionForLoggingIsInvalid;

		private int _writeIdCounter;

		private int _idCounter;

		private int _maxSessionSize;

		private int _remainingReaderSessionSize;

		private bool _isReaderSessionInvalid;

		private MessagePatterns _messagePatterns;

		private string _contentType;

		private string _normalContentType;

		private string _gzipCompressedContentType;

		private string _deflateCompressedContentType;

		private CompressionFormat _sessionCompressionFormat;

		private readonly long _maxReceivedMessageSize;

		public override string ContentType => _contentType;

		public override MessageVersion MessageVersion => _factory._messageVersion;

		public override string MediaType => _contentType;

		public XmlBinaryReaderSession ReaderSession { get; private set; }

		public bool CompressionEnabled => _factory.CompressionFormat != CompressionFormat.None;

		public BinaryMessageEncoder(BinaryMessageEncoderFactory factory, bool isSession, int maxSessionSize)
		{
			_factory = factory;
			_isSession = isSession;
			_maxSessionSize = maxSessionSize;
			_remainingReaderSessionSize = maxSessionSize;
			_normalContentType = (isSession ? factory._binaryVersion.SessionContentType : factory._binaryVersion.ContentType);
			_gzipCompressedContentType = (isSession ? BinaryVersion.GZipVersion1.SessionContentType : BinaryVersion.GZipVersion1.ContentType);
			_deflateCompressedContentType = (isSession ? BinaryVersion.DeflateVersion1.SessionContentType : BinaryVersion.DeflateVersion1.ContentType);
			_sessionCompressionFormat = _factory.CompressionFormat;
			_maxReceivedMessageSize = _factory.MaxReceivedMessageSize;
			switch (_factory.CompressionFormat)
			{
			case CompressionFormat.Deflate:
				_contentType = _deflateCompressedContentType;
				break;
			case CompressionFormat.GZip:
				_contentType = _gzipCompressedContentType;
				break;
			default:
				_contentType = _normalContentType;
				break;
			}
		}

		private ArraySegment<byte> AddSessionInformationToMessage(ArraySegment<byte> messageData, BufferManager bufferManager, int maxMessageSize)
		{
			int num = 0;
			byte[] array = messageData.Array;
			if (_writerSession.HasNewStrings)
			{
				IList<XmlDictionaryString> newStrings = _writerSession.GetNewStrings();
				for (int i = 0; i < newStrings.Count; i++)
				{
					int byteCount = Encoding.UTF8.GetByteCount(newStrings[i].Value);
					num += IntEncoder.GetEncodedSize(byteCount) + byteCount;
				}
				int num2 = messageData.Offset + messageData.Count;
				int num3 = maxMessageSize - num2;
				if (num3 - num < 0)
				{
					string text = System.SR.Format(System.SR.MaxSentMessageSizeExceeded, maxMessageSize);
					if (WcfEventSource.Instance.MaxSentMessageSizeExceededIsEnabled())
					{
						WcfEventSource.Instance.MaxSentMessageSizeExceeded(text);
					}
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new QuotaExceededException(text));
				}
				int num4 = messageData.Offset + messageData.Count + num;
				if (array.Length < num4)
				{
					byte[] array2 = bufferManager.TakeBuffer(num4);
					Buffer.BlockCopy(array, messageData.Offset, array2, messageData.Offset, messageData.Count);
					bufferManager.ReturnBuffer(array);
					array = array2;
				}
				Buffer.BlockCopy(array, messageData.Offset, array, messageData.Offset + num, messageData.Count);
				int num5 = messageData.Offset;
				for (int j = 0; j < newStrings.Count; j++)
				{
					string value = newStrings[j].Value;
					int byteCount2 = Encoding.UTF8.GetByteCount(value);
					num5 += IntEncoder.Encode(byteCount2, array, num5);
					num5 += Encoding.UTF8.GetBytes(value, 0, value.Length, array, num5);
				}
				_writerSession.ClearNewStrings();
			}
			int encodedSize = IntEncoder.GetEncodedSize(num);
			int offset = messageData.Offset - encodedSize;
			int count = encodedSize + messageData.Count + num;
			IntEncoder.Encode(num, array, offset);
			return new ArraySegment<byte>(array, offset, count);
		}

		private ArraySegment<byte> ExtractSessionInformationFromMessage(ArraySegment<byte> messageData)
		{
			if (_isReaderSessionInvalid)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataException(System.SR.BinaryEncoderSessionInvalid));
			}
			byte[] array = messageData.Array;
			bool flag = true;
			int offset;
			int num2;
			try
			{
				IntDecoder intDecoder = default(IntDecoder);
				int num = intDecoder.Decode(array, messageData.Offset, messageData.Count);
				int value = intDecoder.Value;
				if (value > messageData.Count)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataException(System.SR.BinaryEncoderSessionMalformed));
				}
				offset = messageData.Offset + num + value;
				num2 = messageData.Count - num - value;
				if (num2 < 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataException(System.SR.BinaryEncoderSessionMalformed));
				}
				if (value > 0)
				{
					if (value > _remainingReaderSessionSize)
					{
						string text = System.SR.Format(System.SR.BinaryEncoderSessionTooLarge, _maxSessionSize);
						if (WcfEventSource.Instance.MaxSessionSizeReachedIsEnabled())
						{
							WcfEventSource.Instance.MaxSessionSizeReached(text);
						}
						Exception innerException = new QuotaExceededException(text);
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(text, innerException));
					}
					_remainingReaderSessionSize -= value;
					int num3 = value;
					int num4 = messageData.Offset + num;
					while (num3 > 0)
					{
						intDecoder.Reset();
						int num5 = intDecoder.Decode(array, num4, num3);
						int value2 = intDecoder.Value;
						num4 += num5;
						num3 -= num5;
						if (value2 > num3)
						{
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataException(System.SR.BinaryEncoderSessionMalformed));
						}
						string value3 = Encoding.UTF8.GetString(array, num4, value2);
						num4 += value2;
						num3 -= value2;
						ReaderSession.Add(_idCounter, value3);
						_idCounter++;
					}
				}
				flag = false;
			}
			finally
			{
				if (flag)
				{
					_isReaderSessionInvalid = true;
				}
			}
			return new ArraySegment<byte>(array, offset, num2);
		}

		public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
		{
			if (bufferManager == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bufferManager");
			}
			CompressionFormat compressionFormat = CheckContentType(contentType);
			if (WcfEventSource.Instance.BinaryMessageDecodingStartIsEnabled())
			{
				WcfEventSource.Instance.BinaryMessageDecodingStart();
			}
			if (compressionFormat != CompressionFormat.None)
			{
				MessageEncoderCompressionHandler.DecompressBuffer(ref buffer, bufferManager, compressionFormat, _maxReceivedMessageSize);
			}
			if (_isSession)
			{
				if (ReaderSession == null)
				{
					ReaderSession = new XmlBinaryReaderSession();
					_messagePatterns = new MessagePatterns(_factory._binaryVersion.Dictionary, ReaderSession, MessageVersion);
				}
				try
				{
					buffer = ExtractSessionInformationFromMessage(buffer);
				}
				catch (InvalidDataException)
				{
					MessageLogger.LogMessage(buffer, MessageLoggingSource.Malformed);
					throw;
				}
			}
			BinaryBufferedMessageData binaryBufferedMessageData = _factory.TakeBufferedData(this);
			Message message = ((_messagePatterns == null) ? null : _messagePatterns.TryCreateMessage(buffer.Array, buffer.Offset, buffer.Count, bufferManager, binaryBufferedMessageData));
			if (message == null)
			{
				binaryBufferedMessageData.Open(buffer, bufferManager);
				RecycledMessageState recycledMessageState = binaryBufferedMessageData.TakeMessageState();
				if (recycledMessageState == null)
				{
					recycledMessageState = new RecycledMessageState();
				}
				message = new BufferedMessage(binaryBufferedMessageData, recycledMessageState);
			}
			message.Properties.Encoder = this;
			if (MessageLogger.LogMessagesAtTransportLevel)
			{
				MessageLogger.LogMessage(ref message, MessageLoggingSource.TransportReceive);
			}
			return message;
		}

		public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
		{
			if (stream == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
			}
			CompressionFormat compressionFormat = CheckContentType(contentType);
			if (WcfEventSource.Instance.BinaryMessageDecodingStartIsEnabled())
			{
				WcfEventSource.Instance.BinaryMessageDecodingStart();
			}
			if (compressionFormat != CompressionFormat.None)
			{
				stream = new MaxMessageSizeStream(MessageEncoderCompressionHandler.GetDecompressStream(stream, compressionFormat), _maxReceivedMessageSize);
			}
			XmlDictionaryReader envelopeReader = _factory.TakeStreamedReader(stream);
			Message message = Message.CreateMessage(envelopeReader, maxSizeOfHeaders, _factory._messageVersion);
			message.Properties.Encoder = this;
			if (WcfEventSource.Instance.StreamedMessageReadByEncoderIsEnabled())
			{
				WcfEventSource.Instance.StreamedMessageReadByEncoder(EventTraceActivityHelper.TryExtractActivity(message, createIfNotExist: true));
			}
			if (MessageLogger.LogMessagesAtTransportLevel)
			{
				MessageLogger.LogMessage(ref message, MessageLoggingSource.TransportReceive);
			}
			return message;
		}

		public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
		{
			if (message == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
			}
			if (bufferManager == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bufferManager");
			}
			if (maxMessageSize < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxMessageSize", maxMessageSize, System.SR.ValueMustBeNonNegative));
			}
			EventTraceActivity eventTraceActivity = null;
			if (WcfEventSource.Instance.BinaryMessageEncodingStartIsEnabled())
			{
				eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
				WcfEventSource.Instance.BinaryMessageEncodingStart(eventTraceActivity);
			}
			message.Properties.Encoder = this;
			if (_isSession)
			{
				if (_writerSession == null)
				{
					_writerSession = new XmlBinaryWriterSessionWithQuota(_maxSessionSize);
					_sessionMessageWriter = new BinaryBufferedMessageWriter(_factory._binaryVersion.Dictionary, _writerSession);
				}
				messageOffset += 5;
			}
			if (messageOffset < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("messageOffset", messageOffset, System.SR.ValueMustBeNonNegative));
			}
			if (messageOffset > maxMessageSize)
			{
				string text = System.SR.Format(System.SR.MaxSentMessageSizeExceeded, maxMessageSize);
				if (WcfEventSource.Instance.MaxSentMessageSizeExceededIsEnabled())
				{
					WcfEventSource.Instance.MaxSentMessageSizeExceeded(text);
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new QuotaExceededException(text));
			}
			ThrowIfMismatchedMessageVersion(message);
			BinaryBufferedMessageWriter binaryBufferedMessageWriter = ((!_isSession) ? _factory.TakeBufferedWriter() : _sessionMessageWriter);
			ArraySegment<byte> buffer = binaryBufferedMessageWriter.WriteMessage(message, bufferManager, messageOffset, maxMessageSize);
			if (MessageLogger.LogMessagesAtTransportLevel && !_readerSessionForLoggingIsInvalid)
			{
				if (_isSession)
				{
					if (_readerSessionForLogging == null)
					{
						_readerSessionForLogging = new XmlBinaryReaderSession();
					}
					if (_writerSession.HasNewStrings)
					{
						foreach (XmlDictionaryString newString in _writerSession.GetNewStrings())
						{
							_readerSessionForLogging.Add(_writeIdCounter++, newString.Value);
						}
					}
				}
				XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateBinaryReader(buffer.Array, buffer.Offset, buffer.Count, XD.Dictionary, XmlDictionaryReaderQuotas.Max, _readerSessionForLogging);
				MessageLogger.LogMessage(ref message, xmlDictionaryReader, MessageLoggingSource.TransportSend);
			}
			else
			{
				_readerSessionForLoggingIsInvalid = true;
			}
			if (_isSession)
			{
				buffer = AddSessionInformationToMessage(buffer, bufferManager, maxMessageSize);
			}
			else
			{
				_factory.ReturnMessageWriter(binaryBufferedMessageWriter);
			}
			if (WcfEventSource.Instance.MessageWrittenByEncoderIsEnabled())
			{
				WcfEventSource.Instance.MessageWrittenByEncoder(eventTraceActivity ?? EventTraceActivityHelper.TryExtractActivity(message), buffer.Count, this);
			}
			CompressionFormat compressionFormat = CheckCompressedWrite(message);
			if (compressionFormat != CompressionFormat.None)
			{
				MessageEncoderCompressionHandler.CompressBuffer(ref buffer, bufferManager, compressionFormat);
			}
			return buffer;
		}

		public override void WriteMessage(Message message, Stream stream)
		{
			if (message == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
			}
			if (stream == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("stream"));
			}
			EventTraceActivity eventTraceActivity = null;
			if (WcfEventSource.Instance.BinaryMessageEncodingStartIsEnabled())
			{
				eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
				WcfEventSource.Instance.BinaryMessageEncodingStart(eventTraceActivity);
			}
			CompressionFormat compressionFormat = CheckCompressedWrite(message);
			if (compressionFormat != CompressionFormat.None)
			{
				stream = MessageEncoderCompressionHandler.GetCompressStream(stream, compressionFormat);
			}
			ThrowIfMismatchedMessageVersion(message);
			message.Properties.Encoder = this;
			XmlDictionaryWriter xmlDictionaryWriter = _factory.TakeStreamedWriter(stream);
			message.WriteMessage(xmlDictionaryWriter);
			xmlDictionaryWriter.Flush();
			if (WcfEventSource.Instance.StreamedMessageWrittenByEncoderIsEnabled())
			{
				WcfEventSource.Instance.StreamedMessageWrittenByEncoder(eventTraceActivity ?? EventTraceActivityHelper.TryExtractActivity(message));
			}
			_factory.ReturnStreamedWriter(xmlDictionaryWriter);
			if (MessageLogger.LogMessagesAtTransportLevel)
			{
				MessageLogger.LogMessage(ref message, MessageLoggingSource.TransportSend);
			}
			if (compressionFormat != CompressionFormat.None)
			{
				stream.Dispose();
			}
		}

		public override bool IsContentTypeSupported(string contentType)
		{
			bool result = true;
			if (!base.IsContentTypeSupported(contentType))
			{
				result = CompressionEnabled && ((_factory.CompressionFormat == CompressionFormat.GZip && IsContentTypeSupported(contentType, _gzipCompressedContentType, _gzipCompressedContentType)) || (_factory.CompressionFormat == CompressionFormat.Deflate && IsContentTypeSupported(contentType, _deflateCompressedContentType, _deflateCompressedContentType)) || IsContentTypeSupported(contentType, _normalContentType, _normalContentType));
			}
			return result;
		}

		public void SetSessionContentType(string contentType)
		{
			if (IsContentTypeSupported(contentType, _gzipCompressedContentType, _gzipCompressedContentType))
			{
				_sessionCompressionFormat = CompressionFormat.GZip;
			}
			else if (IsContentTypeSupported(contentType, _deflateCompressedContentType, _deflateCompressedContentType))
			{
				_sessionCompressionFormat = CompressionFormat.Deflate;
			}
			else
			{
				_sessionCompressionFormat = CompressionFormat.None;
			}
		}

		public void AddCompressedMessageProperties(Message message, string supportedCompressionTypes)
		{
			message.Properties.Add("BinaryMessageEncoder.SupportedCompressionTypes", supportedCompressionTypes);
		}

		private static bool ContentTypeEqualsOrStartsWith(string contentType, string supportedContentType)
		{
			if (!(contentType == supportedContentType))
			{
				return contentType.StartsWith(supportedContentType, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		private CompressionFormat CheckContentType(string contentType)
		{
			CompressionFormat result = CompressionFormat.None;
			if (contentType == null)
			{
				result = _sessionCompressionFormat;
			}
			else if (!CompressionEnabled)
			{
				if (!ContentTypeEqualsOrStartsWith(contentType, ContentType))
				{
					throw FxTrace.Exception.AsError(new ProtocolException(System.SR.Format(System.SR.EncoderUnrecognizedContentType, contentType, ContentType)));
				}
			}
			else if (_factory.CompressionFormat == CompressionFormat.GZip && ContentTypeEqualsOrStartsWith(contentType, _gzipCompressedContentType))
			{
				result = CompressionFormat.GZip;
			}
			else if (_factory.CompressionFormat == CompressionFormat.Deflate && ContentTypeEqualsOrStartsWith(contentType, _deflateCompressedContentType))
			{
				result = CompressionFormat.Deflate;
			}
			else
			{
				if (!ContentTypeEqualsOrStartsWith(contentType, _normalContentType))
				{
					throw FxTrace.Exception.AsError(new ProtocolException(System.SR.Format(System.SR.EncoderUnrecognizedContentType, contentType, ContentType)));
				}
				result = CompressionFormat.None;
			}
			return result;
		}

		private CompressionFormat CheckCompressedWrite(Message message)
		{
			CompressionFormat compressionFormat = _sessionCompressionFormat;
			if (compressionFormat != CompressionFormat.None && !_isSession && message.Properties.TryGetValue("BinaryMessageEncoder.SupportedCompressionTypes", out string property) && property != null)
			{
				property = property.ToLowerInvariant();
				if ((compressionFormat == CompressionFormat.GZip && !property.Contains("gzip")) || (compressionFormat == CompressionFormat.Deflate && !property.Contains("deflate")))
				{
					compressionFormat = CompressionFormat.None;
				}
			}
			return compressionFormat;
		}
	}

	internal class XmlBinaryWriterSessionWithQuota : XmlBinaryWriterSession
	{
		private int _bytesRemaining;

		private List<XmlDictionaryString> _newStrings;

		public bool HasNewStrings => _newStrings != null;

		public XmlBinaryWriterSessionWithQuota(int maxSessionSize)
		{
			_bytesRemaining = maxSessionSize;
		}

		public override bool TryAdd(XmlDictionaryString s, out int key)
		{
			if (_bytesRemaining == 0)
			{
				key = -1;
				return false;
			}
			int byteCount = Encoding.UTF8.GetByteCount(s.Value);
			byteCount += IntEncoder.GetEncodedSize(byteCount);
			if (byteCount > _bytesRemaining)
			{
				key = -1;
				_bytesRemaining = 0;
				return false;
			}
			if (base.TryAdd(s, out key))
			{
				if (_newStrings == null)
				{
					_newStrings = new List<XmlDictionaryString>();
				}
				_newStrings.Add(s);
				_bytesRemaining -= byteCount;
				return true;
			}
			return false;
		}

		public IList<XmlDictionaryString> GetNewStrings()
		{
			return _newStrings;
		}

		public void ClearNewStrings()
		{
			_newStrings = null;
		}
	}

	private const int maxPooledXmlReaderPerMessage = 2;

	private BinaryMessageEncoder _messageEncoder;

	private MessageVersion _messageVersion;

	private int _maxWritePoolSize;

	private volatile SynchronizedPool<BinaryBufferedMessageData> _bufferedDataPool;

	private volatile SynchronizedPool<BinaryBufferedMessageWriter> _bufferedWriterPool;

	private volatile SynchronizedPool<RecycledMessageState> _recycledStatePool;

	private XmlDictionaryReaderQuotas _bufferedReadReaderQuotas;

	private BinaryVersion _binaryVersion;

	public static IXmlDictionary XmlDictionary => XD.Dictionary;

	public override MessageEncoder Encoder => _messageEncoder;

	public override MessageVersion MessageVersion => _messageVersion;

	public int MaxWritePoolSize => _maxWritePoolSize;

	public XmlDictionaryReaderQuotas ReaderQuotas { get; }

	public int MaxReadPoolSize { get; }

	public int MaxSessionSize { get; }

	public CompressionFormat CompressionFormat { get; }

	private long MaxReceivedMessageSize { get; set; }

	private object ThisLock { get; }

	private SynchronizedPool<RecycledMessageState> RecycledStatePool
	{
		get
		{
			if (_recycledStatePool == null)
			{
				lock (ThisLock)
				{
					if (_recycledStatePool == null)
					{
						_recycledStatePool = new SynchronizedPool<RecycledMessageState>(MaxReadPoolSize);
					}
				}
			}
			return _recycledStatePool;
		}
	}

	public BinaryMessageEncoderFactory(MessageVersion messageVersion, int maxReadPoolSize, int maxWritePoolSize, int maxSessionSize, XmlDictionaryReaderQuotas readerQuotas, long maxReceivedMessageSize, BinaryVersion version, CompressionFormat compressionFormat)
	{
		_messageVersion = messageVersion;
		MaxReadPoolSize = maxReadPoolSize;
		_maxWritePoolSize = maxWritePoolSize;
		MaxSessionSize = maxSessionSize;
		ThisLock = new object();
		ReaderQuotas = new XmlDictionaryReaderQuotas();
		readerQuotas?.CopyTo(ReaderQuotas);
		_bufferedReadReaderQuotas = EncoderHelpers.GetBufferedReadQuotas(ReaderQuotas);
		MaxReceivedMessageSize = maxReceivedMessageSize;
		_binaryVersion = version;
		CompressionFormat = compressionFormat;
		_messageEncoder = new BinaryMessageEncoder(this, isSession: false, 0);
	}

	public override MessageEncoder CreateSessionEncoder()
	{
		return new BinaryMessageEncoder(this, isSession: true, MaxSessionSize);
	}

	private XmlDictionaryWriter TakeStreamedWriter(Stream stream)
	{
		return XmlDictionaryWriter.CreateBinaryWriter(stream, _binaryVersion.Dictionary, null, ownsStream: false);
	}

	private void ReturnStreamedWriter(XmlDictionaryWriter xmlWriter)
	{
		xmlWriter.Dispose();
	}

	private BinaryBufferedMessageWriter TakeBufferedWriter()
	{
		if (_bufferedWriterPool == null)
		{
			lock (ThisLock)
			{
				if (_bufferedWriterPool == null)
				{
					_bufferedWriterPool = new SynchronizedPool<BinaryBufferedMessageWriter>(_maxWritePoolSize);
				}
			}
		}
		BinaryBufferedMessageWriter binaryBufferedMessageWriter = _bufferedWriterPool.Take();
		if (binaryBufferedMessageWriter == null)
		{
			binaryBufferedMessageWriter = new BinaryBufferedMessageWriter(_binaryVersion.Dictionary);
			if (WcfEventSource.Instance.WritePoolMissIsEnabled())
			{
				WcfEventSource.Instance.WritePoolMiss(binaryBufferedMessageWriter.GetType().Name);
			}
		}
		return binaryBufferedMessageWriter;
	}

	private void ReturnMessageWriter(BinaryBufferedMessageWriter messageWriter)
	{
		_bufferedWriterPool.Return(messageWriter);
	}

	private XmlDictionaryReader TakeStreamedReader(Stream stream)
	{
		return XmlDictionaryReader.CreateBinaryReader(stream, _binaryVersion.Dictionary, ReaderQuotas, null);
	}

	private BinaryBufferedMessageData TakeBufferedData(BinaryMessageEncoder messageEncoder)
	{
		if (_bufferedDataPool == null)
		{
			lock (ThisLock)
			{
				if (_bufferedDataPool == null)
				{
					_bufferedDataPool = new SynchronizedPool<BinaryBufferedMessageData>(MaxReadPoolSize);
				}
			}
		}
		BinaryBufferedMessageData binaryBufferedMessageData = _bufferedDataPool.Take();
		if (binaryBufferedMessageData == null)
		{
			binaryBufferedMessageData = new BinaryBufferedMessageData(this, 2);
			if (WcfEventSource.Instance.ReadPoolMissIsEnabled())
			{
				WcfEventSource.Instance.ReadPoolMiss(binaryBufferedMessageData.GetType().Name);
			}
		}
		binaryBufferedMessageData.SetMessageEncoder(messageEncoder);
		return binaryBufferedMessageData;
	}

	private void ReturnBufferedData(BinaryBufferedMessageData messageData)
	{
		messageData.SetMessageEncoder(null);
		_bufferedDataPool.Return(messageData);
	}
}
