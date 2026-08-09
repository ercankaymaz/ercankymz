using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class TextMessageEncoderFactory : MessageEncoderFactory
{
	internal class ContentEncoding
	{
		internal string contentType;

		internal Encoding encoding;
	}

	internal class TextMessageEncoder : MessageEncoder
	{
		internal class UTF8BufferedMessageData : BufferedMessageData
		{
			private TextMessageEncoder _messageEncoder;

			private Encoding _encoding;

			private const int additionalNodeSpace = 1024;

			internal Encoding Encoding
			{
				set
				{
					_encoding = value;
				}
			}

			public override MessageEncoder MessageEncoder => _messageEncoder;

			public override XmlDictionaryReaderQuotas Quotas => _messageEncoder._bufferedReadReaderQuotas;

			public UTF8BufferedMessageData(TextMessageEncoder messageEncoder, int maxReaderPoolSize)
				: base(messageEncoder.RecycledStatePool)
			{
				_messageEncoder = messageEncoder;
			}

			protected override void OnClosed()
			{
				_messageEncoder.ReturnBufferedData(this);
			}

			protected override XmlDictionaryReader TakeXmlReader()
			{
				ArraySegment<byte> buffer = base.Buffer;
				return XmlDictionaryReader.CreateTextReader(buffer.Array, buffer.Offset, buffer.Count, Quotas);
			}

			protected override void ReturnXmlReader(XmlDictionaryReader xmlReader)
			{
				xmlReader.Dispose();
			}
		}

		internal class TextBufferedMessageWriter : BufferedMessageWriter
		{
			private TextMessageEncoder _messageEncoder;

			public TextBufferedMessageWriter(TextMessageEncoder messageEncoder)
			{
				_messageEncoder = messageEncoder;
			}

			protected override void OnWriteStartMessage(XmlDictionaryWriter writer)
			{
				if (!_messageEncoder._optimizeWriteForUTF8)
				{
					writer.WriteStartDocument();
				}
			}

			protected override void OnWriteEndMessage(XmlDictionaryWriter writer)
			{
				if (!_messageEncoder._optimizeWriteForUTF8)
				{
					writer.WriteEndDocument();
				}
			}

			protected override XmlDictionaryWriter TakeXmlWriter(Stream stream)
			{
				if (_messageEncoder._optimizeWriteForUTF8)
				{
					return XmlDictionaryWriter.CreateTextWriter(stream, _messageEncoder._writeEncoding, ownsStream: false);
				}
				return _messageEncoder.CreateWriter(stream);
			}

			protected override void ReturnXmlWriter(XmlDictionaryWriter writer)
			{
				writer.Flush();
				writer.Dispose();
			}
		}

		private int _maxWritePoolSize;

		private volatile SynchronizedPool<UTF8BufferedMessageData> _bufferedReaderPool;

		private volatile SynchronizedPool<TextBufferedMessageWriter> _bufferedWriterPool;

		private volatile SynchronizedPool<RecycledMessageState> _recycledStatePool;

		private string _contentType;

		private string _mediaType;

		private Encoding _writeEncoding;

		private MessageVersion _version;

		private bool _optimizeWriteForUTF8;

		private const int maxPooledXmlReadersPerMessage = 2;

		private XmlDictionaryReaderQuotas _bufferedReadReaderQuotas;

		private ContentEncoding[] _contentEncodingMap;

		private static readonly byte[] s_xmlDeclarationStartText = new byte[5] { 60, 63, 120, 109, 108 };

		private static readonly byte[] s_version10Text = new byte[13]
		{
			118, 101, 114, 115, 105, 111, 110, 61, 34, 49,
			46, 48, 34
		};

		private static readonly byte[] s_encodingText = new byte[9] { 101, 110, 99, 111, 100, 105, 110, 103, 61 };

		public override string ContentType => _contentType;

		public int MaxWritePoolSize => _maxWritePoolSize;

		public int MaxReadPoolSize { get; }

		public XmlDictionaryReaderQuotas ReaderQuotas { get; }

		public override string MediaType => _mediaType;

		public override MessageVersion MessageVersion => _version;

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

		public TextMessageEncoder(MessageVersion version, Encoding writeEncoding, int maxReadPoolSize, int maxWritePoolSize, XmlDictionaryReaderQuotas quotas)
		{
			if (writeEncoding == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writeEncoding");
			}
			TextEncoderDefaults.ValidateEncoding(writeEncoding);
			_writeEncoding = writeEncoding;
			_optimizeWriteForUTF8 = IsUTF8Encoding(writeEncoding);
			ThisLock = new object();
			_version = version ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("version");
			MaxReadPoolSize = maxReadPoolSize;
			_maxWritePoolSize = maxWritePoolSize;
			ReaderQuotas = new XmlDictionaryReaderQuotas();
			quotas.CopyTo(ReaderQuotas);
			_bufferedReadReaderQuotas = EncoderHelpers.GetBufferedReadQuotas(ReaderQuotas);
			_mediaType = GetMediaType(version);
			_contentType = GetContentType(_mediaType, writeEncoding);
			if (version.Envelope == EnvelopeVersion.Soap12)
			{
				_contentEncodingMap = Soap12Content;
				return;
			}
			if (version.Envelope == EnvelopeVersion.Soap11)
			{
				_contentEncodingMap = Soap11Content;
				return;
			}
			if (version.Envelope == EnvelopeVersion.None)
			{
				_contentEncodingMap = SoapNoneContent;
				return;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EnvelopeVersionNotSupported, version.Envelope)));
		}

		private static bool IsUTF8Encoding(Encoding encoding)
		{
			return encoding.WebName == "utf-8";
		}

		internal override bool IsCharSetSupported(string charSet)
		{
			if (!TextEncoderDefaults.TryGetEncoding(charSet, out var encoding))
			{
				if (charSet.Length > 2 && charSet[0] == '"' && charSet[charSet.Length - 1] == '"')
				{
					charSet = charSet.Substring(1, charSet.Length - 2);
					return TextEncoderDefaults.TryGetEncoding(charSet, out encoding);
				}
				return false;
			}
			return true;
		}

		public override bool IsContentTypeSupported(string contentType)
		{
			if (contentType == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contentType");
			}
			if (base.IsContentTypeSupported(contentType))
			{
				return true;
			}
			if (MessageVersion == MessageVersion.None)
			{
				if (IsContentTypeSupported(contentType, "text/xml", "text/xml"))
				{
					return true;
				}
				if (IsContentTypeSupported(contentType, "application/rss+xml", "application/rss+xml"))
				{
					return true;
				}
				if (IsContentTypeSupported(contentType, "text/html", "application/atom+xml"))
				{
					return true;
				}
				if (IsContentTypeSupported(contentType, "application/atom+xml", "application/atom+xml"))
				{
					return true;
				}
			}
			return false;
		}

		public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
		{
			if (bufferManager == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("bufferManager"));
			}
			if (WcfEventSource.Instance.TextMessageDecodingStartIsEnabled())
			{
				WcfEventSource.Instance.TextMessageDecodingStart();
			}
			UTF8BufferedMessageData uTF8BufferedMessageData = TakeBufferedReader();
			uTF8BufferedMessageData.Encoding = GetEncodingFromContentType(contentType, _contentEncodingMap);
			uTF8BufferedMessageData.Open(buffer, bufferManager);
			RecycledMessageState recycledMessageState = uTF8BufferedMessageData.TakeMessageState();
			if (recycledMessageState == null)
			{
				recycledMessageState = new RecycledMessageState();
			}
			Message message = new BufferedMessage(uTF8BufferedMessageData, recycledMessageState);
			message.Properties.Encoder = this;
			if (WcfEventSource.Instance.MessageReadByEncoderIsEnabled())
			{
				WcfEventSource.Instance.MessageReadByEncoder(EventTraceActivityHelper.TryExtractActivity(message, createIfNotExist: true), buffer.Count, this);
			}
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
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("stream"));
			}
			if (WcfEventSource.Instance.TextMessageDecodingStartIsEnabled())
			{
				WcfEventSource.Instance.TextMessageDecodingStart();
			}
			XmlReader envelopeReader = TakeStreamedReader(stream, GetEncodingFromContentType(contentType, _contentEncodingMap));
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
			return WriteMessageAsync(message, maxMessageSize, bufferManager, messageOffset).WaitForCompletionNoSpin();
		}

		public override void WriteMessage(Message message, Stream stream)
		{
			WriteMessageAsyncInternal(message, stream).WaitForCompletionNoSpin();
		}

		public override Task<ArraySegment<byte>> WriteMessageAsync(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
		{
			if (message == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
			}
			if (bufferManager == null)
			{
				throw TraceUtility.ThrowHelperError(new ArgumentNullException("bufferManager"), message);
			}
			if (maxMessageSize < 0)
			{
				throw TraceUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxMessageSize", maxMessageSize, System.SR.ValueMustBeNonNegative), message);
			}
			if (messageOffset < 0 || messageOffset > maxMessageSize)
			{
				throw TraceUtility.ThrowHelperError(new ArgumentOutOfRangeException("messageOffset", messageOffset, System.SR.Format(System.SR.ValueMustBeInRange, 0, maxMessageSize)), message);
			}
			ThrowIfMismatchedMessageVersion(message);
			EventTraceActivity eventTraceActivity = null;
			if (WcfEventSource.Instance.TextMessageEncodingStartIsEnabled())
			{
				eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
				WcfEventSource.Instance.TextMessageEncodingStart(eventTraceActivity);
			}
			message.Properties.Encoder = this;
			TextBufferedMessageWriter textBufferedMessageWriter = TakeBufferedWriter();
			ArraySegment<byte> result = textBufferedMessageWriter.WriteMessage(message, bufferManager, messageOffset, maxMessageSize);
			ReturnMessageWriter(textBufferedMessageWriter);
			if (WcfEventSource.Instance.MessageWrittenByEncoderIsEnabled())
			{
				WcfEventSource.Instance.MessageWrittenByEncoder(eventTraceActivity ?? EventTraceActivityHelper.TryExtractActivity(message), result.Count, this);
			}
			if (MessageLogger.LogMessagesAtTransportLevel)
			{
				XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(result.Array, result.Offset, result.Count, XmlDictionaryReaderQuotas.Max);
				MessageLogger.LogMessage(ref message, xmlDictionaryReader, MessageLoggingSource.TransportSend);
			}
			return Task.FromResult(result);
		}

		private async Task WriteMessageAsyncInternal(Message message, Stream stream)
		{
			await TaskHelpers.EnsureDefaultTaskScheduler();
			await WriteMessageAsync(message, stream);
		}

		public override async Task WriteMessageAsync(Message message, Stream stream)
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
			if (WcfEventSource.Instance.TextMessageEncodingStartIsEnabled())
			{
				eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
				WcfEventSource.Instance.TextMessageEncodingStart(eventTraceActivity);
			}
			message.Properties.Encoder = this;
			XmlDictionaryWriter xmlWriter = TakeStreamedWriter(stream);
			if (_optimizeWriteForUTF8)
			{
				await message.WriteMessageAsync(xmlWriter);
			}
			else
			{
				xmlWriter.WriteStartDocument();
				await message.WriteMessageAsync(xmlWriter);
				xmlWriter.WriteEndDocument();
			}
			await xmlWriter.FlushAsync();
			ReturnStreamedWriter(xmlWriter);
			if (WcfEventSource.Instance.StreamedMessageWrittenByEncoderIsEnabled())
			{
				WcfEventSource.Instance.StreamedMessageWrittenByEncoder(eventTraceActivity ?? EventTraceActivityHelper.TryExtractActivity(message));
			}
			if (MessageLogger.LogMessagesAtTransportLevel)
			{
				MessageLogger.LogMessage(ref message, MessageLoggingSource.TransportSend);
			}
		}

		public override IAsyncResult BeginWriteMessage(Message message, Stream stream, AsyncCallback callback, object state)
		{
			return WriteMessageAsync(message, stream).ToApm(callback, state);
		}

		public override void EndWriteMessage(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		private XmlDictionaryWriter TakeStreamedWriter(Stream stream)
		{
			return XmlDictionaryWriter.CreateTextWriter(stream, _writeEncoding, ownsStream: false);
		}

		private void ReturnStreamedWriter(XmlWriter xmlWriter)
		{
			xmlWriter.Flush();
			xmlWriter.Dispose();
		}

		private TextBufferedMessageWriter TakeBufferedWriter()
		{
			if (_bufferedWriterPool == null)
			{
				lock (ThisLock)
				{
					if (_bufferedWriterPool == null)
					{
						_bufferedWriterPool = new SynchronizedPool<TextBufferedMessageWriter>(_maxWritePoolSize);
					}
				}
			}
			TextBufferedMessageWriter textBufferedMessageWriter = _bufferedWriterPool.Take();
			if (textBufferedMessageWriter == null)
			{
				textBufferedMessageWriter = new TextBufferedMessageWriter(this);
				if (WcfEventSource.Instance.WritePoolMissIsEnabled())
				{
					WcfEventSource.Instance.WritePoolMiss(textBufferedMessageWriter.GetType().Name);
				}
			}
			return textBufferedMessageWriter;
		}

		private void ReturnMessageWriter(TextBufferedMessageWriter messageWriter)
		{
			_bufferedWriterPool.Return(messageWriter);
		}

		private XmlReader TakeStreamedReader(Stream stream, Encoding enc)
		{
			return XmlDictionaryReader.CreateTextReader(stream, ReaderQuotas);
		}

		private XmlDictionaryWriter CreateWriter(Stream stream)
		{
			return XmlDictionaryWriter.CreateTextWriter(stream, _writeEncoding, ownsStream: false);
		}

		private UTF8BufferedMessageData TakeBufferedReader()
		{
			if (_bufferedReaderPool == null)
			{
				lock (ThisLock)
				{
					if (_bufferedReaderPool == null)
					{
						_bufferedReaderPool = new SynchronizedPool<UTF8BufferedMessageData>(MaxReadPoolSize);
					}
				}
			}
			UTF8BufferedMessageData uTF8BufferedMessageData = _bufferedReaderPool.Take();
			if (uTF8BufferedMessageData == null)
			{
				uTF8BufferedMessageData = new UTF8BufferedMessageData(this, 2);
				if (WcfEventSource.Instance.ReadPoolMissIsEnabled())
				{
					WcfEventSource.Instance.ReadPoolMiss(uTF8BufferedMessageData.GetType().Name);
				}
			}
			return uTF8BufferedMessageData;
		}

		private void ReturnBufferedData(UTF8BufferedMessageData messageData)
		{
			_bufferedReaderPool.Return(messageData);
		}
	}

	private TextMessageEncoder _messageEncoder;

	internal static ContentEncoding[] Soap11Content = GetContentEncodingMap(MessageVersion.Soap11WSAddressing10);

	internal static ContentEncoding[] Soap12Content = GetContentEncodingMap(MessageVersion.Soap12WSAddressing10);

	internal static ContentEncoding[] SoapNoneContent = GetContentEncodingMap(MessageVersion.None);

	internal const string Soap11MediaType = "text/xml";

	internal const string Soap12MediaType = "application/soap+xml";

	private const string XmlMediaType = "application/xml";

	public override MessageEncoder Encoder => _messageEncoder;

	public override MessageVersion MessageVersion => _messageEncoder.MessageVersion;

	public int MaxWritePoolSize => _messageEncoder.MaxWritePoolSize;

	public int MaxReadPoolSize => _messageEncoder.MaxReadPoolSize;

	public XmlDictionaryReaderQuotas ReaderQuotas => _messageEncoder.ReaderQuotas;

	public TextMessageEncoderFactory(MessageVersion version, Encoding writeEncoding, int maxReadPoolSize, int maxWritePoolSize, XmlDictionaryReaderQuotas quotas)
	{
		_messageEncoder = new TextMessageEncoder(version, writeEncoding, maxReadPoolSize, maxWritePoolSize, quotas);
	}

	public static Encoding[] GetSupportedEncodings()
	{
		Encoding[] supportedEncodings = TextEncoderDefaults.SupportedEncodings;
		Encoding[] array = new Encoding[supportedEncodings.Length];
		Array.Copy(supportedEncodings, array, supportedEncodings.Length);
		return array;
	}

	internal static string GetMediaType(MessageVersion version)
	{
		string text = null;
		if (version.Envelope == EnvelopeVersion.Soap12)
		{
			return "application/soap+xml";
		}
		if (version.Envelope == EnvelopeVersion.Soap11)
		{
			return "text/xml";
		}
		if (version.Envelope == EnvelopeVersion.None)
		{
			return "application/xml";
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EnvelopeVersionNotSupported, version.Envelope)));
	}

	internal static string GetContentType(string mediaType, Encoding encoding)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}; charset={1}", mediaType, TextEncoderDefaults.EncodingToCharSet(encoding));
	}

	private static ContentEncoding[] GetContentEncodingMap(MessageVersion version)
	{
		Encoding[] supportedEncodings = GetSupportedEncodings();
		string mediaType = GetMediaType(version);
		ContentEncoding[] array = new ContentEncoding[supportedEncodings.Length];
		for (int i = 0; i < supportedEncodings.Length; i++)
		{
			ContentEncoding contentEncoding = new ContentEncoding();
			contentEncoding.contentType = GetContentType(mediaType, supportedEncodings[i]);
			contentEncoding.encoding = supportedEncodings[i];
			array[i] = contentEncoding;
		}
		return array;
	}

	internal static Encoding GetEncodingFromContentType(string contentType, ContentEncoding[] contentMap)
	{
		if (contentType == null)
		{
			return null;
		}
		for (int i = 0; i < contentMap.Length; i++)
		{
			if (contentMap[i].contentType == contentType)
			{
				return contentMap[i].encoding;
			}
		}
		int num = contentType.IndexOf(';');
		if (num == -1)
		{
			return null;
		}
		int num2 = -1;
		if (contentType.Length > num + 11 && contentType[num + 2] == 'c' && string.Compare("charset=", 0, contentType, num + 2, 8, StringComparison.OrdinalIgnoreCase) == 0)
		{
			num2 = num + 10;
		}
		else
		{
			int num3 = contentType.IndexOf("charset=", num + 1, StringComparison.OrdinalIgnoreCase);
			if (num3 != -1)
			{
				for (int num4 = num3 - 1; num4 >= num; num4--)
				{
					if (contentType[num4] == ';')
					{
						num2 = num3 + 8;
						break;
					}
					if (contentType[num4] == '\n')
					{
						if (num4 == num || contentType[num4 - 1] != '\r')
						{
							break;
						}
						num4--;
					}
					else if (contentType[num4] != ' ' && contentType[num4] != '\t')
					{
						break;
					}
				}
			}
		}
		Encoding encoding;
		string text;
		if (num2 != -1)
		{
			num = contentType.IndexOf(';', num2);
			text = ((num != -1) ? contentType.Substring(num2, num - num2) : contentType.Substring(num2));
			if (text.Length > 2 && text[0] == '"' && text[text.Length - 1] == '"')
			{
				text = text.Substring(1, text.Length - 2);
			}
			if (TryGetEncodingFromCharSet(text, out encoding))
			{
				return encoding;
			}
		}
		try
		{
			MediaTypeHeaderValue mediaTypeHeaderValue = MediaTypeHeaderValue.Parse(contentType);
			text = mediaTypeHeaderValue.CharSet;
		}
		catch (FormatException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.EncoderBadContentType, innerException));
		}
		if (TryGetEncodingFromCharSet(text, out encoding))
		{
			return encoding;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.EncoderUnrecognizedCharSet, text)));
	}

	internal static bool TryGetEncodingFromCharSet(string charSet, out Encoding encoding)
	{
		encoding = null;
		if (charSet == null || charSet.Length == 0)
		{
			return true;
		}
		return TextEncoderDefaults.TryGetEncoding(charSet, out encoding);
	}
}
