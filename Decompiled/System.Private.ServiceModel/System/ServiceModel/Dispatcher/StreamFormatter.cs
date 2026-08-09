using System.IO;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal class StreamFormatter
{
	internal class SerializeAsyncResult : AsyncResult
	{
		private static AsyncCompletion s_handleEndSerialize = HandleEndSerialize;

		private StreamFormatter _streamFormatter;

		private XmlDictionaryWriter _writer;

		internal SerializeAsyncResult(StreamFormatter streamFormatter, XmlDictionaryWriter writer, object[] parameters, object returnValue, AsyncCallback callback, object state)
			: base(callback, state)
		{
			_streamFormatter = streamFormatter;
			_writer = writer;
			throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
		}

		private static bool HandleEndSerialize(IAsyncResult result)
		{
			SerializeAsyncResult serializeAsyncResult = (SerializeAsyncResult)result.AsyncState;
			serializeAsyncResult._streamFormatter.WriteEndWrapperIfNecessary(serializeAsyncResult._writer);
			return true;
		}

		public static void End(IAsyncResult result)
		{
			AsyncResult.End<SerializeAsyncResult>(result);
		}
	}

	internal class MessageBodyStream : Stream
	{
		private Message _message;

		private XmlDictionaryReader _reader;

		private System.ServiceModel.Channels.BufferedReadStream _bufferedReadStream;

		private long _position;

		private string _wrapperName;

		private string _wrapperNs;

		private string _elementName;

		private string _elementNs;

		private bool _isRequest;

		public override long Position
		{
			get
			{
				EnsureStreamIsOpen();
				return _position;
			}
			set
			{
				throw TraceUtility.ThrowHelperError(new NotSupportedException(), _message);
			}
		}

		public override bool CanRead => _message.State != MessageState.Closed;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length
		{
			get
			{
				throw TraceUtility.ThrowHelperError(new NotSupportedException(), _message);
			}
		}

		internal MessageBodyStream(Message message, string wrapperName, string wrapperNs, string elementName, string elementNs, bool isRequest)
		{
			_message = message;
			_position = 0L;
			_wrapperName = wrapperName;
			_wrapperNs = wrapperNs;
			_elementName = elementName;
			_elementNs = elementNs;
			_isRequest = isRequest;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (count == 0)
			{
				return 0;
			}
			if (_reader == null && _message.Properties.ContainsKey("ServiceModelBufferedReadStreamProperty"))
			{
				_bufferedReadStream = _message.Properties["ServiceModelBufferedReadStreamProperty"] as System.ServiceModel.Channels.BufferedReadStream;
			}
			using (TaskHelpers.RunTaskContinuationsOnOurThreads())
			{
				if (_bufferedReadStream != null)
				{
					await _bufferedReadStream.PreReadBufferAsync(cancellationToken);
				}
				return Read(buffer, offset, count);
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			EnsureStreamIsOpen();
			if (buffer == null)
			{
				throw TraceUtility.ThrowHelperError(new ArgumentNullException("buffer"), _message);
			}
			if (offset < 0)
			{
				throw TraceUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", offset, System.SR.Format(System.SR.ValueMustBeNonNegative)), _message);
			}
			if (count < 0)
			{
				throw TraceUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", count, System.SR.Format(System.SR.ValueMustBeNonNegative)), _message);
			}
			if (buffer.Length - offset < count)
			{
				throw TraceUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.SFxInvalidStreamOffsetLength, offset + count)), _message);
			}
			if (count == 0)
			{
				return 0;
			}
			try
			{
				if (_reader == null)
				{
					_reader = _message.GetReaderAtBodyContents();
					if (_wrapperName != null)
					{
						_reader.MoveToContent();
						_reader.ReadStartElement(_wrapperName, _wrapperNs);
					}
					_reader.MoveToContent();
					if (_reader.NodeType == XmlNodeType.EndElement)
					{
						return 0;
					}
					_reader.ReadStartElement(_elementName, _elementNs);
				}
				if (_reader.MoveToContent() != XmlNodeType.Text)
				{
					Exhaust(_reader);
					return 0;
				}
				int num = _reader.ReadContentAsBase64(buffer, offset, count);
				_position += num;
				if (num == 0)
				{
					Exhaust(_reader);
				}
				return num;
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new IOException(System.SR.Format(System.SR.SFxStreamIOException), ex));
			}
		}

		private void EnsureStreamIsOpen()
		{
			if (_message.State == MessageState.Closed)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(System.SR.Format(_isRequest ? System.SR.SFxStreamRequestMessageClosed : System.SR.SFxStreamResponseMessageClosed)));
			}
		}

		private static void Exhaust(XmlDictionaryReader reader)
		{
			if (reader != null)
			{
				while (reader.Read())
				{
				}
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			_message.Close();
			if (_reader != null)
			{
				_reader.Dispose();
				_reader = null;
			}
			base.Dispose(isDisposing);
		}

		public override void Flush()
		{
			throw TraceUtility.ThrowHelperError(new NotSupportedException(), _message);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw TraceUtility.ThrowHelperError(new NotSupportedException(), _message);
		}

		public override void SetLength(long value)
		{
			throw TraceUtility.ThrowHelperError(new NotSupportedException(), _message);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw TraceUtility.ThrowHelperError(new NotSupportedException(), _message);
		}
	}

	internal class OperationStreamProvider
	{
		private Stream _stream;

		internal OperationStreamProvider(Stream stream)
		{
			_stream = stream;
		}

		public Stream GetStream()
		{
			return _stream;
		}

		public void ReleaseStream(Stream stream)
		{
		}
	}

	internal class StreamFormatterHelper
	{
		public static void WriteValue(XmlDictionaryWriter writer, OperationStreamProvider value)
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
			}
			Stream stream = value.GetStream();
			if (stream == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.XmlInvalidStream)));
			}
			int num = 256;
			int num2 = 0;
			byte[] buffer = new byte[num];
			while (true)
			{
				num2 = stream.Read(buffer, 0, num);
				if (num2 <= 0)
				{
					break;
				}
				writer.WriteBase64(buffer, 0, num2);
				if (num < 65536 && num2 == num)
				{
					num *= 16;
					buffer = new byte[num];
				}
			}
			value.ReleaseStream(stream);
		}

		public static async Task WriteValueAsync(XmlDictionaryWriter writer, OperationStreamProvider value)
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
			}
			Stream stream = value.GetStream();
			if (stream == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.XmlInvalidStream)));
			}
			int blockSize = 256;
			byte[] block = new byte[blockSize];
			while (true)
			{
				int num = await stream.ReadAsync(block, 0, blockSize);
				if (num <= 0)
				{
					break;
				}
				writer.WriteBase64(block, 0, num);
				if (blockSize < 65536 && num == blockSize)
				{
					blockSize *= 16;
					block = new byte[blockSize];
				}
			}
			value.ReleaseStream(stream);
		}
	}

	private string _partNS;

	private int _streamIndex;

	private bool _isRequest;

	private string _operationName;

	private const int returnValueIndex = -1;

	internal string WrapperName { get; set; }

	internal string WrapperNamespace { get; set; }

	internal string PartName { get; }

	internal string PartNamespace => _partNS;

	internal static StreamFormatter Create(MessageDescription messageDescription, string operationName, bool isRequest)
	{
		MessagePartDescription messagePartDescription = ValidateAndGetStreamPart(messageDescription, isRequest, operationName);
		if (messagePartDescription == null)
		{
			return null;
		}
		return new StreamFormatter(messageDescription, messagePartDescription, operationName, isRequest);
	}

	private StreamFormatter(MessageDescription messageDescription, MessagePartDescription streamPart, string operationName, bool isRequest)
	{
		if (streamPart == messageDescription.Body.ReturnValue)
		{
			_streamIndex = -1;
		}
		else
		{
			_streamIndex = streamPart.Index;
		}
		WrapperName = messageDescription.Body.WrapperName;
		WrapperNamespace = messageDescription.Body.WrapperNamespace;
		PartName = streamPart.Name;
		_partNS = streamPart.Namespace;
		_isRequest = isRequest;
		_operationName = operationName;
	}

	internal void Serialize(XmlDictionaryWriter writer, object[] parameters, object returnValue)
	{
		Stream streamAndWriteStartWrapperIfNecessary = GetStreamAndWriteStartWrapperIfNecessary(writer, parameters, returnValue);
		OperationStreamProvider value = new OperationStreamProvider(streamAndWriteStartWrapperIfNecessary);
		StreamFormatterHelper.WriteValue(writer, value);
		WriteEndWrapperIfNecessary(writer);
	}

	internal async Task SerializeAsync(XmlDictionaryWriter writer, object[] parameters, object returnValue)
	{
		OperationStreamProvider value = new OperationStreamProvider(await GetStreamAndWriteStartWrapperIfNecessaryAsync(writer, parameters, returnValue));
		await StreamFormatterHelper.WriteValueAsync(writer, value);
		await WriteEndWrapperIfNecessaryAsync(writer);
	}

	private Stream GetStreamAndWriteStartWrapperIfNecessary(XmlDictionaryWriter writer, object[] parameters, object returnValue)
	{
		Stream streamValue = GetStreamValue(parameters, returnValue);
		if (streamValue == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(PartName);
		}
		if (WrapperName != null)
		{
			writer.WriteStartElement(WrapperName, WrapperNamespace);
		}
		writer.WriteStartElement(PartName, PartNamespace);
		return streamValue;
	}

	private async Task<Stream> GetStreamAndWriteStartWrapperIfNecessaryAsync(XmlDictionaryWriter writer, object[] parameters, object returnValue)
	{
		Stream streamValue = GetStreamValue(parameters, returnValue);
		if (streamValue == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(PartName);
		}
		if (WrapperName != null)
		{
			await writer.WriteStartElementAsync(null, WrapperName, WrapperNamespace);
		}
		await writer.WriteStartElementAsync(null, PartName, PartNamespace);
		return streamValue;
	}

	private void WriteEndWrapperIfNecessary(XmlDictionaryWriter writer)
	{
		writer.WriteEndElement();
		if (WrapperName != null)
		{
			writer.WriteEndElement();
		}
	}

	private async Task WriteEndWrapperIfNecessaryAsync(XmlDictionaryWriter writer)
	{
		await writer.WriteEndElementAsync();
		if (WrapperName != null)
		{
			await writer.WriteEndElementAsync();
		}
	}

	internal IAsyncResult BeginSerialize(XmlDictionaryWriter writer, object[] parameters, object returnValue, AsyncCallback callback, object state)
	{
		return new SerializeAsyncResult(this, writer, parameters, returnValue, callback, state);
	}

	public void EndSerialize(IAsyncResult result)
	{
		SerializeAsyncResult.End(result);
	}

	internal void Deserialize(object[] parameters, ref object retVal, Message message)
	{
		SetStreamValue(parameters, ref retVal, new MessageBodyStream(message, WrapperName, WrapperNamespace, PartName, PartNamespace, _isRequest));
	}

	private Stream GetStreamValue(object[] parameters, object returnValue)
	{
		if (_streamIndex == -1)
		{
			return (Stream)returnValue;
		}
		return (Stream)parameters[_streamIndex];
	}

	private void SetStreamValue(object[] parameters, ref object returnValue, Stream streamValue)
	{
		if (_streamIndex == -1)
		{
			returnValue = streamValue;
		}
		else
		{
			parameters[_streamIndex] = streamValue;
		}
	}

	private static MessagePartDescription ValidateAndGetStreamPart(MessageDescription messageDescription, bool isRequest, string operationName)
	{
		MessagePartDescription streamPart = GetStreamPart(messageDescription);
		if (streamPart != null)
		{
			return streamPart;
		}
		if (HasStream(messageDescription))
		{
			if (messageDescription.IsTypedMessage)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidStreamInTypedMessage, messageDescription.MessageName)));
			}
			if (isRequest)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidStreamInRequest, operationName)));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidStreamInResponse, operationName)));
		}
		return null;
	}

	private static bool HasStream(MessageDescription messageDescription)
	{
		if (messageDescription.Body.ReturnValue != null && messageDescription.Body.ReturnValue.Type == typeof(Stream))
		{
			return true;
		}
		foreach (MessagePartDescription part in messageDescription.Body.Parts)
		{
			if (part.Type == typeof(Stream))
			{
				return true;
			}
		}
		return false;
	}

	private static MessagePartDescription GetStreamPart(MessageDescription messageDescription)
	{
		if (OperationFormatter.IsValidReturnValue(messageDescription.Body.ReturnValue))
		{
			if (messageDescription.Body.Parts.Count == 0 && messageDescription.Body.ReturnValue.Type == typeof(Stream))
			{
				return messageDescription.Body.ReturnValue;
			}
		}
		else if (messageDescription.Body.Parts.Count == 1 && messageDescription.Body.Parts[0].Type == typeof(Stream))
		{
			return messageDescription.Body.Parts[0];
		}
		return null;
	}

	internal static bool IsStream(MessageDescription messageDescription)
	{
		return GetStreamPart(messageDescription) != null;
	}
}
