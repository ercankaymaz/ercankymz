using System.IO;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public class BufferedReadStream : Stream
{
	private const int DefaultBufferSize = 8192;

	private Stream _stream;

	private byte[] _buffer;

	private readonly int _bufferSize;

	private int _readPos;

	private int _readLen;

	private Task<int> _lastSyncCompletedReadTask;

	private BufferManager _bufferManager;

	private readonly SemaphoreSlim _sem = new SemaphoreSlim(1, 1);

	public const string BufferedReadStreamPropertyName = "ServiceModelBufferedReadStreamProperty";

	public override bool CanRead
	{
		get
		{
			if (_stream != null)
			{
				return _stream.CanRead;
			}
			return false;
		}
	}

	public override bool CanWrite => false;

	public override bool CanSeek => false;

	public override long Length
	{
		get
		{
			throw new NotSupportedException("Length");
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException("Position");
		}
		set
		{
			throw new NotSupportedException("Position");
		}
	}

	public bool IsBufferEmpty => _readPos == _readLen;

	public BufferedReadStream(Stream stream)
		: this(stream, null, 8192)
	{
	}

	public BufferedReadStream(Stream stream, BufferManager bufferManager)
		: this(stream, bufferManager, 8192)
	{
	}

	public BufferedReadStream(Stream stream, BufferManager bufferManager, int bufferSize)
	{
		_stream = stream;
		_bufferManager = bufferManager;
		_bufferSize = bufferSize;
		EnsureBufferAllocated();
	}

	private void EnsureNotClosed()
	{
		if (_stream == null)
		{
			throw new ObjectDisposedException("BufferedReadStream");
		}
	}

	private void EnsureCanRead()
	{
	}

	private void EnsureBufferAllocated()
	{
		if (_buffer == null)
		{
			if (_bufferManager != null)
			{
				_buffer = _bufferManager.TakeBuffer(_bufferSize);
			}
			else
			{
				_buffer = new byte[_bufferSize];
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			try
			{
				_stream?.Dispose();
			}
			finally
			{
				_stream = null;
				byte[] buffer = _buffer;
				_buffer = null;
				_bufferManager?.ReturnBuffer(buffer);
				_bufferManager = null;
			}
		}
		base.Dispose(disposing);
	}

	public override void Flush()
	{
	}

	public override Task FlushAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}

	private int ReadFromBuffer(byte[] array, int offset, int count)
	{
		int num = _readLen - _readPos;
		if (num == 0)
		{
			return 0;
		}
		if (num > count)
		{
			num = count;
		}
		Array.Copy(_buffer, _readPos, array, offset, num);
		_readPos += num;
		return num;
	}

	private int ReadFromBuffer(byte[] array, int offset, int count, out Exception error)
	{
		try
		{
			error = null;
			return ReadFromBuffer(array, offset, count);
		}
		catch (Exception ex)
		{
			error = ex;
			return 0;
		}
	}

	public override int Read(byte[] array, int offset, int count)
	{
		EnsureNotClosed();
		EnsureCanRead();
		int num = ReadFromBuffer(array, offset, count);
		if (num == count)
		{
			return num;
		}
		int num2 = num;
		if (num > 0)
		{
			count -= num;
			offset += num;
		}
		_readPos = (_readLen = 0);
		using (TaskHelpers.RunTaskContinuationsOnOurThreads())
		{
			if (count >= _bufferSize)
			{
				return _stream.Read(array, offset, count) + num2;
			}
			_readLen = _stream.Read(_buffer, 0, _bufferSize);
		}
		num = ReadFromBuffer(array, offset, count);
		return num + num2;
	}

	private Task<int> LastSyncCompletedReadTask(int val)
	{
		Task<int> lastSyncCompletedReadTask = _lastSyncCompletedReadTask;
		if (lastSyncCompletedReadTask != null && lastSyncCompletedReadTask.Result == val)
		{
			return lastSyncCompletedReadTask;
		}
		return _lastSyncCompletedReadTask = Task.FromResult(val);
	}

	public async Task PreReadBufferAsync(byte preBufferedByte, CancellationToken cancellationToken)
	{
		_buffer[0] = preBufferedByte;
		_readLen = 1 + await _stream.ReadAsync(_buffer, 1, _bufferSize - 1, cancellationToken);
		_readPos = 0;
	}

	public Task PreReadBufferAsync(CancellationToken cancellationToken)
	{
		if (IsBufferEmpty || _readLen < _bufferSize)
		{
			return PreReadBufferAsyncInternal(cancellationToken);
		}
		return Task.CompletedTask;
	}

	private async Task PreReadBufferAsyncInternal(CancellationToken cancellationToken)
	{
		if (IsBufferEmpty)
		{
			_readLen = await _stream.ReadAsync(_buffer, 0, _bufferSize, cancellationToken);
			_readPos = 0;
		}
		else
		{
			int readLen = _readLen;
			_readLen = readLen + await _stream.ReadAsync(_buffer, _readLen, _bufferSize - _readLen, cancellationToken);
		}
	}

	public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return Task.FromCanceled<int>(cancellationToken);
		}
		EnsureNotClosed();
		EnsureCanRead();
		int num = 0;
		Task task = _sem.WaitAsync(cancellationToken);
		if (task.Status == TaskStatus.RanToCompletion)
		{
			bool flag = true;
			try
			{
				num = ReadFromBuffer(buffer, offset, count, out var error);
				flag = num == count || error != null;
				if (flag)
				{
					return (error == null) ? LastSyncCompletedReadTask(num) : Task.FromException<int>(error);
				}
			}
			finally
			{
				if (flag)
				{
					_sem.Release();
				}
			}
		}
		return ReadFromUnderlyingStreamAsync(buffer, offset + num, count - num, cancellationToken, num, task);
	}

	private async Task<int> ReadFromUnderlyingStreamAsync(byte[] array, int offset, int count, CancellationToken cancellationToken, int bytesAlreadySatisfied, Task semaphoreLockTask)
	{
		await semaphoreLockTask.ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			int num = ReadFromBuffer(array, offset, count);
			if (num == count)
			{
				return bytesAlreadySatisfied + num;
			}
			if (num > 0)
			{
				count -= num;
				offset += num;
				bytesAlreadySatisfied += num;
			}
			_readPos = (_readLen = 0);
			if (count >= _bufferSize)
			{
				int num2 = bytesAlreadySatisfied;
				return num2 + await _stream.ReadAsync(array, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			_readLen = await _stream.ReadAsync(_buffer, 0, _bufferSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			num = ReadFromBuffer(array, offset, count);
			return bytesAlreadySatisfied + num;
		}
		finally
		{
			_sem.Release();
		}
	}

	public override int ReadByte()
	{
		EnsureNotClosed();
		EnsureCanRead();
		if (_readPos == _readLen)
		{
			using (TaskHelpers.RunTaskContinuationsOnOurThreads())
			{
				_readLen = _stream.Read(_buffer, 0, _bufferSize);
			}
			_readPos = 0;
		}
		if (_readPos == _readLen)
		{
			return -1;
		}
		return _buffer[_readPos++];
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException("Write");
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		throw new NotSupportedException("WriteAsync");
	}

	public override void WriteByte(byte value)
	{
		throw new NotSupportedException("WriteByte");
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("Seek");
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException("SetLength");
	}
}
