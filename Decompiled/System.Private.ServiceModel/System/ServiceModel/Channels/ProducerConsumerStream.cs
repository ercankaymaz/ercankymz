using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class ProducerConsumerStream : Stream
{
	private struct WriteBufferWrapper : IEquatable<WriteBufferWrapper>
	{
		public static readonly WriteBufferWrapper EmptyContainer = new WriteBufferWrapper(null, -1, -1, isReadOnly: true);

		private int _count;

		private readonly bool _readOnly;

		public byte[] ByteBuffer { get; }

		public int Offset { get; private set; }

		public int Count => _count;

		public int BytesWritten { get; private set; }

		public WriteBufferWrapper(byte[] buffer, int offset, int count)
			: this(buffer, offset, count, isReadOnly: false)
		{
		}

		private WriteBufferWrapper(byte[] buffer, int offset, int count, bool isReadOnly)
		{
			this = default(WriteBufferWrapper);
			ByteBuffer = buffer;
			Offset = offset;
			_count = count;
			_readOnly = isReadOnly;
		}

		public override bool Equals(object obj)
		{
			if (obj is WriteBufferWrapper)
			{
				return Equals((WriteBufferWrapper)obj);
			}
			return false;
		}

		public bool Equals(WriteBufferWrapper other)
		{
			if (_readOnly || other._readOnly)
			{
				return _readOnly == other._readOnly;
			}
			if (other.ByteBuffer == ByteBuffer && other.Offset == Offset)
			{
				return other._count == _count;
			}
			return false;
		}

		public static bool operator ==(WriteBufferWrapper a, WriteBufferWrapper b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(WriteBufferWrapper a, WriteBufferWrapper b)
		{
			return !(a == b);
		}

		internal int Write(byte[] srcBuffer, int srcOffset, int srcCount)
		{
			if (_readOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			int num = Math.Min(_count, srcCount);
			Buffer.BlockCopy(srcBuffer, srcOffset, ByteBuffer, Offset, num);
			Offset += num;
			_count -= num;
			BytesWritten += num;
			return num;
		}
	}

	private TaskCompletionSource<WriteBufferWrapper> _buffer;

	private TaskCompletionSource<int> _dataAvail;

	private WriteBufferWrapper _currentBuffer;

	private bool _disposed;

	public override bool CanRead => !_disposed;

	public override bool CanSeek => false;

	public override bool CanWrite => !_disposed;

	public override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public ProducerConsumerStream()
	{
		_buffer = new TaskCompletionSource<WriteBufferWrapper>();
		_dataAvail = new TaskCompletionSource<int>();
		_currentBuffer = WriteBufferWrapper.EmptyContainer;
	}

	public override void Flush()
	{
		int bytesWritten = _currentBuffer.BytesWritten;
		_currentBuffer = WriteBufferWrapper.EmptyContainer;
		_dataAvail.TrySetResult(bytesWritten);
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		try
		{
			return ReadAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();
		}
		catch (OperationCanceledException innerException)
		{
			throw new ObjectDisposedException("ProducerConsumerStream", innerException);
		}
	}

	public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || offset > buffer.Length)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count <= 0 || count > buffer.Length - offset)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		cancellationToken.ThrowIfCancellationRequested();
		_dataAvail = new TaskCompletionSource<int>();
		if (_disposed)
		{
			return 0;
		}
		using (cancellationToken.Register(CancelAndDispose, this))
		{
			_buffer.TrySetResult(new WriteBufferWrapper(buffer, offset, count));
			return await _dataAvail.Task;
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		try
		{
			WriteAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();
		}
		catch (OperationCanceledException innerException)
		{
			throw new ObjectDisposedException("ProducerConsumerStream", innerException);
		}
	}

	public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || offset > buffer.Length)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count < 0 || count > buffer.Length - offset)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		cancellationToken.ThrowIfCancellationRequested();
		if (_disposed)
		{
			throw new ObjectDisposedException("ProducerConsumerStream");
		}
		using (cancellationToken.Register(CancelAndDispose, this))
		{
			while (count > 0)
			{
				if (_currentBuffer == WriteBufferWrapper.EmptyContainer)
				{
					_currentBuffer = await _buffer.Task;
					_buffer = new TaskCompletionSource<WriteBufferWrapper>();
				}
				int num = _currentBuffer.Write(buffer, offset, count);
				count -= num;
				offset += num;
				if (_currentBuffer.Count == 0)
				{
					Flush();
				}
			}
		}
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && !_disposed)
		{
			_disposed = true;
			Flush();
		}
		base.Dispose(disposing);
	}

	private static void CancelAndDispose(object state)
	{
		if (state is ProducerConsumerStream producerConsumerStream)
		{
			producerConsumerStream._dataAvail.TrySetCanceled();
			producerConsumerStream._buffer.TrySetCanceled();
			producerConsumerStream.Dispose();
		}
	}
}
