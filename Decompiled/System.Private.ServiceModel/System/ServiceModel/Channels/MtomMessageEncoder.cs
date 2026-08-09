using System.Globalization;
using System.IO;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class MtomMessageEncoder : MessageEncoder, ITraceSourceStringProvider
{
	internal class MtomBufferedMessageData : BufferedMessageData
	{
		private MtomMessageEncoder _messageEncoder;

		private Pool<XmlDictionaryReader> _readerPool;

		internal string _contentType;

		private OnXmlDictionaryReaderClose _onClose;

		public override MessageEncoder MessageEncoder => _messageEncoder;

		public override XmlDictionaryReaderQuotas Quotas => _messageEncoder._bufferedReadReaderQuotas;

		public MtomBufferedMessageData(MtomMessageEncoder messageEncoder, int maxReaderPoolSize)
			: base(messageEncoder._factory.RecycledStatePool)
		{
			_messageEncoder = messageEncoder;
			_readerPool = new Pool<XmlDictionaryReader>(maxReaderPoolSize);
			_onClose = base.OnXmlReaderClosed;
		}

		protected override void OnClosed()
		{
			_messageEncoder._factory.ReturnBufferedData(this);
		}

		protected override XmlDictionaryReader TakeXmlReader()
		{
			try
			{
				ArraySegment<byte> buffer = base.Buffer;
				XmlDictionaryReader xmlDictionaryReader = _readerPool.Take();
				if (_contentType == null || _messageEncoder.IsMTOMContentType(_contentType))
				{
					if (xmlDictionaryReader != null && xmlDictionaryReader is IXmlMtomReaderInitializer)
					{
						((IXmlMtomReaderInitializer)xmlDictionaryReader).SetInput(buffer.Array, buffer.Offset, buffer.Count, MtomMessageEncoderFactory.GetSupportedEncodings(), _contentType, Quotas, _messageEncoder.MaxBufferSize, _onClose);
					}
					else
					{
						xmlDictionaryReader = XmlMtomReader.Create(buffer.Array, buffer.Offset, buffer.Count, MtomMessageEncoderFactory.GetSupportedEncodings(), _contentType, Quotas, _messageEncoder.MaxBufferSize, _onClose);
						if (WcfEventSource.Instance.ReadPoolMissIsEnabled())
						{
							WcfEventSource.Instance.ReadPoolMiss(xmlDictionaryReader.GetType().Name);
						}
					}
				}
				else if (xmlDictionaryReader != null && xmlDictionaryReader is IXmlTextReaderInitializer)
				{
					((IXmlTextReaderInitializer)xmlDictionaryReader).SetInput(buffer.Array, buffer.Offset, buffer.Count, TextMessageEncoderFactory.GetEncodingFromContentType(_contentType, _messageEncoder._factory.ContentEncodingMap), Quotas, _onClose);
				}
				else
				{
					xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(buffer.Array, buffer.Offset, buffer.Count, TextMessageEncoderFactory.GetEncodingFromContentType(_contentType, _messageEncoder._factory.ContentEncodingMap), Quotas, _onClose);
					if (WcfEventSource.Instance.ReadPoolMissIsEnabled())
					{
						WcfEventSource.Instance.ReadPoolMiss(xmlDictionaryReader.GetType().Name);
					}
				}
				return xmlDictionaryReader;
			}
			catch (FormatException innerException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxErrorCreatingMtomReader, innerException));
			}
			catch (XmlException innerException2)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxErrorCreatingMtomReader, innerException2));
			}
		}

		protected override void ReturnXmlReader(XmlDictionaryReader xmlReader)
		{
			if (xmlReader != null)
			{
				_readerPool.Return(xmlReader);
			}
		}
	}

	internal class MtomBufferedMessageWriter : BufferedMessageWriter
	{
		private MtomMessageEncoder _messageEncoder;

		internal bool _writeMessageHeaders;

		internal string _startInfo;

		internal string _startUri;

		internal string _boundary;

		internal int _maxSizeInBytes = int.MaxValue;

		private XmlDictionaryWriter _writer;

		public MtomBufferedMessageWriter(MtomMessageEncoder messageEncoder)
		{
			_messageEncoder = messageEncoder;
		}

		protected override XmlDictionaryWriter TakeXmlWriter(Stream stream)
		{
			XmlDictionaryWriter xmlDictionaryWriter = _writer;
			if (xmlDictionaryWriter == null)
			{
				xmlDictionaryWriter = XmlMtomWriter.Create(stream, _messageEncoder._writeEncoding, _maxSizeInBytes, _startInfo, _boundary, _startUri, _writeMessageHeaders, ownsStream: false);
			}
			else
			{
				_writer = null;
				((IXmlMtomWriterInitializer)xmlDictionaryWriter).SetOutput(stream, _messageEncoder._writeEncoding, _maxSizeInBytes, _startInfo, _boundary, _startUri, _writeMessageHeaders, ownsStream: false);
			}
			if (_messageEncoder._writeEncoding.WebName != "utf-8")
			{
				xmlDictionaryWriter.WriteStartDocument();
			}
			return xmlDictionaryWriter;
		}

		protected override void ReturnXmlWriter(XmlDictionaryWriter writer)
		{
			writer.Close();
			if (_writer == null)
			{
				_writer = writer;
			}
		}
	}

	private Encoding _writeEncoding;

	private string _contentType;

	private string _boundary;

	private MessageVersion _version;

	private static UriGenerator s_mimeBoundaryGenerator;

	private XmlDictionaryReaderQuotas _bufferedReadReaderQuotas;

	private MtomMessageEncoderFactory _factory;

	private const string MtomMediaType = "multipart/related";

	private const string MtomContentType = "multipart/related; type=\"application/xop+xml\"";

	private const string MtomStartUri = "http://tempuri.org/0";

	private static UriGenerator MimeBoundaryGenerator
	{
		get
		{
			if (s_mimeBoundaryGenerator == null)
			{
				s_mimeBoundaryGenerator = new UriGenerator("uuid", "+");
			}
			return s_mimeBoundaryGenerator;
		}
	}

	public override string ContentType => _contentType;

	public int MaxWritePoolSize { get; }

	public int MaxReadPoolSize { get; }

	public XmlDictionaryReaderQuotas ReaderQuotas { get; }

	public int MaxBufferSize { get; }

	public override string MediaType => "multipart/related";

	public override MessageVersion MessageVersion => _version;

	public MtomMessageEncoder(MessageVersion version, Encoding writeEncoding, int maxReadPoolSize, int maxWritePoolSize, int maxBufferSize, XmlDictionaryReaderQuotas quotas, MtomMessageEncoderFactory factory)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("version");
		}
		if (writeEncoding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writeEncoding");
		}
		_factory = factory;
		TextEncoderDefaults.ValidateEncoding(writeEncoding);
		_writeEncoding = writeEncoding;
		MaxReadPoolSize = maxReadPoolSize;
		MaxWritePoolSize = maxWritePoolSize;
		ReaderQuotas = new XmlDictionaryReaderQuotas();
		quotas.CopyTo(ReaderQuotas);
		_bufferedReadReaderQuotas = EncoderHelpers.GetBufferedReadQuotas(ReaderQuotas);
		MaxBufferSize = maxBufferSize;
		_version = version;
		_contentType = GetContentType(out _boundary);
	}

	internal bool IsMTOMContentType(string contentType)
	{
		return IsContentTypeSupported(contentType, ContentType, MediaType);
	}

	internal bool IsTextContentType(string contentType)
	{
		string mediaType = TextMessageEncoderFactory.GetMediaType(_version);
		string contentType2 = TextMessageEncoderFactory.GetContentType(mediaType, _writeEncoding);
		return IsContentTypeSupported(contentType, contentType2, mediaType);
	}

	public override bool IsContentTypeSupported(string contentType)
	{
		if (contentType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("contentType"));
		}
		if (!IsMTOMContentType(contentType))
		{
			return IsTextContentType(contentType);
		}
		return true;
	}

	internal override bool IsCharSetSupported(string charSet)
	{
		if (charSet == null || charSet.Length == 0)
		{
			return true;
		}
		Encoding encoding;
		return TextEncoderDefaults.TryGetEncoding(charSet, out encoding);
	}

	private string GenerateStartInfoString()
	{
		if (_version.Envelope != EnvelopeVersion.Soap12)
		{
			return "text/xml";
		}
		return "application/soap+xml";
	}

	public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
	{
		if (bufferManager == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bufferManager");
		}
		if (contentType == ContentType)
		{
			contentType = null;
		}
		if (WcfEventSource.Instance.MtomMessageDecodingStartIsEnabled())
		{
			WcfEventSource.Instance.MtomMessageDecodingStart();
		}
		MtomBufferedMessageData mtomBufferedMessageData = _factory.TakeBufferedReader(this);
		mtomBufferedMessageData._contentType = contentType;
		mtomBufferedMessageData.Open(buffer, bufferManager);
		RecycledMessageState recycledMessageState = mtomBufferedMessageData.TakeMessageState();
		if (recycledMessageState == null)
		{
			recycledMessageState = new RecycledMessageState();
		}
		Message message = new BufferedMessage(mtomBufferedMessageData, recycledMessageState);
		message.Properties.Encoder = this;
		if (MessageLogger.LogMessagesAtTransportLevel)
		{
			MessageLogger.LogMessage(ref message, MessageLoggingSource.TransportReceive);
		}
		if (WcfEventSource.Instance.MessageReadByEncoderIsEnabled())
		{
			WcfEventSource.Instance.MessageReadByEncoder(EventTraceActivityHelper.TryExtractActivity(message, createIfNotExist: true), buffer.Count, this);
		}
		return message;
	}

	public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("stream"));
		}
		if (contentType == ContentType)
		{
			contentType = null;
		}
		if (WcfEventSource.Instance.MtomMessageDecodingStartIsEnabled())
		{
			WcfEventSource.Instance.MtomMessageDecodingStart();
		}
		XmlReader envelopeReader = _factory.TakeStreamedReader(stream, contentType, contentType == null || IsMTOMContentType(contentType));
		Message message = Message.CreateMessage(envelopeReader, maxSizeOfHeaders, _version);
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
		return WriteMessageInternal(message, maxMessageSize, bufferManager, messageOffset, GenerateStartInfoString(), _boundary, "http://tempuri.org/0", writeMessageHeaders: true);
	}

	public override Task<ArraySegment<byte>> WriteMessageAsync(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
	{
		return Task.FromResult(WriteMessageInternal(message, maxMessageSize, bufferManager, messageOffset, GenerateStartInfoString(), _boundary, "http://tempuri.org/0", writeMessageHeaders: true));
	}

	private string GetContentType(out string boundary)
	{
		string startInfo = GenerateStartInfoString();
		boundary = MimeBoundaryGenerator.Next();
		return FormatContentType(boundary, startInfo);
	}

	internal string FormatContentType(string boundary, string startInfo)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0};start=\"<{1}>\";boundary=\"{2}\";start-info=\"{3}\"", "multipart/related; type=\"application/xop+xml\"", "http://tempuri.org/0", boundary, startInfo);
	}

	private ArraySegment<byte> WriteMessageInternal(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset, string startInfo, string boundary, string startUri, bool writeMessageHeaders)
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
		if (messageOffset < 0 || messageOffset > maxMessageSize)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("messageOffset", messageOffset, System.SR.Format(System.SR.ValueMustBeInRange, 0, maxMessageSize)));
		}
		ThrowIfMismatchedMessageVersion(message);
		EventTraceActivity eventTraceActivity = null;
		if (WcfEventSource.Instance.MtomMessageEncodingStartIsEnabled())
		{
			eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
			WcfEventSource.Instance.MtomMessageEncodingStart(eventTraceActivity);
		}
		message.Properties.Encoder = this;
		MtomBufferedMessageWriter mtomBufferedMessageWriter = _factory.TakeBufferedWriter(this);
		mtomBufferedMessageWriter._startInfo = startInfo;
		mtomBufferedMessageWriter._boundary = boundary;
		mtomBufferedMessageWriter._startUri = startUri;
		mtomBufferedMessageWriter._writeMessageHeaders = writeMessageHeaders;
		mtomBufferedMessageWriter._maxSizeInBytes = maxMessageSize;
		ArraySegment<byte> result = mtomBufferedMessageWriter.WriteMessage(message, bufferManager, messageOffset, maxMessageSize);
		_factory.ReturnMessageWriter(mtomBufferedMessageWriter);
		if (WcfEventSource.Instance.MessageWrittenByEncoderIsEnabled())
		{
			WcfEventSource.Instance.MessageWrittenByEncoder(eventTraceActivity ?? EventTraceActivityHelper.TryExtractActivity(message), result.Count, this);
		}
		if (MessageLogger.LogMessagesAtTransportLevel)
		{
			string contentType = null;
			if (boundary != null)
			{
				contentType = FormatContentType(boundary, startInfo ?? GenerateStartInfoString());
			}
			XmlDictionaryReader xmlDictionaryReader = XmlMtomReader.Create(result.Array, result.Offset, result.Count, MtomMessageEncoderFactory.GetSupportedEncodings(), contentType, XmlDictionaryReaderQuotas.Max, int.MaxValue, null);
			MessageLogger.LogMessage(ref message, xmlDictionaryReader, MessageLoggingSource.TransportSend);
		}
		return result;
	}

	public override void WriteMessage(Message message, Stream stream)
	{
		WriteMessageAsync(message, stream).WaitForCompletionNoSpin();
	}

	public override Task WriteMessageAsync(Message message, Stream stream)
	{
		return WriteMessageInternalAsync(message, stream, GenerateStartInfoString(), _boundary, "http://tempuri.org/0", writeMessageHeaders: true);
	}

	public override IAsyncResult BeginWriteMessage(Message message, Stream stream, AsyncCallback callback, object state)
	{
		return WriteMessageAsync(message, stream).ToApm(callback, state);
	}

	public override void EndWriteMessage(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	private async Task WriteMessageInternalAsync(Message message, Stream stream, string startInfo, string boundary, string startUri, bool writeMessageHeaders)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
		}
		if (stream == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("stream"), message);
		}
		ThrowIfMismatchedMessageVersion(message);
		EventTraceActivity eventTraceActivity = null;
		if (WcfEventSource.Instance.MtomMessageEncodingStartIsEnabled())
		{
			eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
			WcfEventSource.Instance.MtomMessageEncodingStart(eventTraceActivity);
		}
		message.Properties.Encoder = this;
		if (MessageLogger.LogMessagesAtTransportLevel)
		{
			MessageLogger.LogMessage(ref message, MessageLoggingSource.TransportSend);
		}
		XmlDictionaryWriter xmlWriter = _factory.TakeStreamedWriter(stream, startInfo, boundary, startUri, writeMessageHeaders);
		if (!(_writeEncoding.WebName == "utf-8"))
		{
			await xmlWriter.WriteStartDocumentAsync();
			await message.WriteMessageAsync(xmlWriter);
			await xmlWriter.WriteEndDocumentAsync();
		}
		else
		{
			await message.WriteMessageAsync(xmlWriter);
		}
		await xmlWriter.FlushAsync();
		_factory.ReturnStreamedWriter(xmlWriter);
		if (WcfEventSource.Instance.StreamedMessageWrittenByEncoderIsEnabled())
		{
			WcfEventSource.Instance.StreamedMessageWrittenByEncoder(eventTraceActivity ?? EventTraceActivityHelper.TryExtractActivity(message));
		}
	}

	string ITraceSourceStringProvider.GetSourceString()
	{
		return GetTraceSourceString();
	}
}
