using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class BufferedMessageContent : MessageContent
{
	private bool _disposed;

	private bool _messageEncoded;

	private ArraySegment<byte> _buffer;

	private long? _contentLength;

	public BufferedMessageContent(Message message, MessageEncoder messageEncoder, BufferManager bufferManager)
		: base(message, messageEncoder, bufferManager)
	{
		_messageEncoded = false;
	}

	protected override Task<Stream> CreateContentReadStreamAsync()
	{
		EnsureMessageEncoded();
		_stream = new MemoryStream(_buffer.Array, _buffer.Offset, _buffer.Count, writable: false, publiclyVisible: true);
		_writeCompletedTcs.TrySetResult(result: true);
		return Task.FromResult(_stream);
	}

	private void EnsureMessageEncoded()
	{
		if (!_messageEncoded)
		{
			_buffer = _messageEncoder.WriteMessage(_message, int.MaxValue, _bufferManager);
			_contentLength = _buffer.Count;
			_messageEncoded = true;
		}
	}

	protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
	{
		try
		{
			EnsureMessageEncoded();
			await stream.WriteAsync(_buffer.Array, _buffer.Offset, _buffer.Count);
		}
		finally
		{
			_writeCompletedTcs.TrySetResult(result: true);
		}
	}

	protected override bool TryComputeLength(out long length)
	{
		EnsureMessageEncoded();
		if (_contentLength.HasValue)
		{
			length = _contentLength.Value;
			return true;
		}
		length = 0L;
		return false;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && !_disposed)
		{
			_disposed = true;
			if (_buffer.Array != null)
			{
				byte[] array = _buffer.Array;
				_buffer = default(ArraySegment<byte>);
				_bufferManager.ReturnBuffer(array);
			}
		}
		base.Dispose(disposing);
	}
}
