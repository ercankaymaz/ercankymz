using System.IO;
using System.Net.Http.Headers;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class MessageEncoder
{
	private string _traceSourceString;

	public abstract string ContentType { get; }

	public abstract string MediaType { get; }

	public abstract MessageVersion MessageVersion { get; }

	public virtual T GetProperty<T>() where T : class
	{
		if (typeof(T) == typeof(FaultConverter))
		{
			return (T)(object)FaultConverter.GetDefaultFaultConverter(MessageVersion);
		}
		return null;
	}

	public Message ReadMessage(Stream stream, int maxSizeOfHeaders)
	{
		return ReadMessage(stream, maxSizeOfHeaders, null);
	}

	public virtual Task<Message> ReadMessageAsync(Stream stream, int maxSizeOfHeaders, string contentType)
	{
		return Task.FromResult(ReadMessage(stream, maxSizeOfHeaders, contentType));
	}

	public virtual Task<Message> ReadMessageAsync(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
	{
		return Task.FromResult(ReadMessage(buffer, bufferManager, contentType));
	}

	public abstract Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType);

	public Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager)
	{
		return ReadMessage(buffer, bufferManager, null);
	}

	public abstract Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType);

	internal async Task<ArraySegment<byte>> BufferMessageStreamAsync(Stream stream, BufferManager bufferManager, int maxBufferSize, CancellationToken cancellationToken)
	{
		byte[] buffer = bufferManager.TakeBuffer(8192);
		int offset = 0;
		int currentBufferSize = Math.Min(buffer.Length, maxBufferSize);
		while (offset < currentBufferSize)
		{
			int num = await stream.ReadAsync(buffer, offset, currentBufferSize - offset, cancellationToken);
			if (num == 0)
			{
				stream.Dispose();
				break;
			}
			offset += num;
			if (offset == currentBufferSize)
			{
				if (currentBufferSize >= maxBufferSize)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(MaxMessageSizeStream.CreateMaxReceivedMessageSizeExceededException(maxBufferSize));
				}
				currentBufferSize = Math.Min(currentBufferSize * 2, maxBufferSize);
				byte[] array = bufferManager.TakeBuffer(currentBufferSize);
				Buffer.BlockCopy(buffer, 0, array, 0, offset);
				bufferManager.ReturnBuffer(buffer);
				buffer = array;
			}
		}
		return new ArraySegment<byte>(buffer, 0, offset);
	}

	internal virtual async Task<Message> ReadMessageAsync(Stream stream, BufferManager bufferManager, int maxBufferSize, string contentType, CancellationToken cancellationToken)
	{
		return ReadMessage(await BufferMessageStreamAsync(stream, bufferManager, maxBufferSize, cancellationToken), bufferManager, contentType);
	}

	public override string ToString()
	{
		return ContentType;
	}

	public abstract void WriteMessage(Message message, Stream stream);

	public virtual IAsyncResult BeginWriteMessage(Message message, Stream stream, AsyncCallback callback, object state)
	{
		return WriteMessageAsync(message, stream).ToApm(callback, state);
	}

	public virtual void EndWriteMessage(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	public ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager)
	{
		return WriteMessage(message, maxMessageSize, bufferManager, 0);
	}

	public abstract ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset);

	public virtual Task WriteMessageAsync(Message message, Stream stream)
	{
		WriteMessage(message, stream);
		return TaskHelpers.CompletedTask();
	}

	public virtual Task<ArraySegment<byte>> WriteMessageAsync(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
	{
		return Task.FromResult(WriteMessage(message, maxMessageSize, bufferManager, messageOffset));
	}

	public virtual bool IsContentTypeSupported(string contentType)
	{
		if (contentType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("contentType"));
		}
		return IsContentTypeSupported(contentType, ContentType, MediaType);
	}

	internal bool IsContentTypeSupported(string contentType, string supportedContentType, string supportedMediaType)
	{
		if (supportedContentType == contentType)
		{
			return true;
		}
		if (contentType.Length > supportedContentType.Length && contentType.StartsWith(supportedContentType, StringComparison.Ordinal) && contentType[supportedContentType.Length] == ';')
		{
			return true;
		}
		if (contentType.StartsWith(supportedContentType, StringComparison.OrdinalIgnoreCase))
		{
			if (contentType.Length == supportedContentType.Length)
			{
				return true;
			}
			if (contentType.Length > supportedContentType.Length)
			{
				char c = contentType[supportedContentType.Length];
				if (c == ';')
				{
					return true;
				}
				int i = supportedContentType.Length;
				if (c == '\r' && contentType.Length > supportedContentType.Length + 1 && contentType[i + 1] == '\n')
				{
					i += 2;
					c = contentType[i];
				}
				if (c == ' ' || c == '\t')
				{
					for (i++; i < contentType.Length; i++)
					{
						c = contentType[i];
						if (c != ' ' && c != '\t')
						{
							break;
						}
					}
				}
				if (c == ';' || i == contentType.Length)
				{
					return true;
				}
			}
		}
		try
		{
			MediaTypeHeaderValue mediaTypeHeaderValue = MediaTypeHeaderValue.Parse(contentType);
			if (supportedMediaType.Length > 0 && !supportedMediaType.Equals(mediaTypeHeaderValue.MediaType, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			if (!IsCharSetSupported(mediaTypeHeaderValue.CharSet))
			{
				return false;
			}
		}
		catch (FormatException)
		{
			return false;
		}
		return true;
	}

	internal virtual bool IsCharSetSupported(string charset)
	{
		return false;
	}

	internal void ThrowIfMismatchedMessageVersion(Message message)
	{
		if (message.Version != MessageVersion)
		{
			throw TraceUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.EncoderMessageVersionMismatch, message.Version, MessageVersion)), message);
		}
	}

	internal string GetTraceSourceString()
	{
		if (_traceSourceString == null)
		{
			_traceSourceString = DiagnosticTraceBase.CreateDefaultSourceString(this);
		}
		return _traceSourceString;
	}
}
