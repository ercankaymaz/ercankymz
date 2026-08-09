using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class BufferedWriteStream : Stream
{
	public const int DefaultBufferSize = 8192;

	private Stream _stream;

	private BufferManager _bufferManager;

	private byte[] _buffer;

	private readonly int _bufferSize;

	private int _writePos;

	private readonly SemaphoreSlim _sem = new SemaphoreSlim(1, 1);

	private const int MaxShadowBufferSize = 81920;

	public override bool CanRead => false;

	public override bool CanWrite
	{
		get
		{
			if (_stream != null)
			{
				return _stream.CanWrite;
			}
			return false;
		}
	}

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

	public BufferedWriteStream(Stream stream)
		: this(stream, null, 8192)
	{
	}

	public BufferedWriteStream(Stream stream, BufferManager bufferManager)
		: this(stream, bufferManager, 8192)
	{
	}

	public BufferedWriteStream(Stream stream, BufferManager bufferManager, int bufferSize)
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
			throw new ObjectDisposedException("BufferedWriteStream");
		}
	}

	private void EnsureCanWrite()
	{
	}

	private void EnsureShadowBufferAllocated()
	{
		if (_buffer.Length == _bufferSize && _bufferSize < 81920)
		{
			byte[] array = new byte[Math.Min(_bufferSize + _bufferSize, 81920)];
			Array.Copy(_buffer, 0, array, 0, _writePos);
			_buffer = array;
		}
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
		EnsureNotClosed();
		if (_writePos > 0)
		{
			FlushWrite();
		}
		else
		{
			_stream.Flush();
		}
	}

	public override Task FlushAsync(CancellationToken cancellationToken)
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return Task.FromCanceled<int>(cancellationToken);
		}
		EnsureNotClosed();
		return FlushAsyncInternal(cancellationToken);
	}

	private async Task FlushAsyncInternal(CancellationToken cancellationToken)
	{
		await _sem.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			if (_writePos > 0)
			{
				await FlushWriteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				await _stream.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		finally
		{
			_sem.Release();
		}
	}

	private void FlushWrite()
	{
		_stream.Write(_buffer, 0, _writePos);
		_writePos = 0;
		_stream.Flush();
	}

	private async Task FlushWriteAsync(CancellationToken cancellationToken)
	{
		await _stream.WriteAsync(_buffer, 0, _writePos, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		_writePos = 0;
		await _stream.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public override int Read(byte[] array, int offset, int count)
	{
		throw new NotSupportedException("Read");
	}

	public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		throw new NotSupportedException("ReadAsync");
	}

	public override int ReadByte()
	{
		throw new NotSupportedException("ReadByte");
	}

	private void WriteToBuffer(byte[] array, ref int offset, ref int count)
	{
		int num = Math.Min(_bufferSize - _writePos, count);
		if (num > 0)
		{
			Array.Copy(array, offset, _buffer, _writePos, num);
			_writePos += num;
			count -= num;
			offset += num;
		}
	}

	private void WriteToBuffer(byte[] array, ref int offset, ref int count, out Exception error)
	{
		try
		{
			error = null;
			WriteToBuffer(array, ref offset, ref count);
		}
		catch (Exception ex)
		{
			error = ex;
		}
	}

	public override void Write(byte[] array, int offset, int count)
	{
		EnsureNotClosed();
		EnsureCanWrite();
		int num;
		checked
		{
			num = _writePos + count;
			if (num + count < _bufferSize + _bufferSize)
			{
				WriteToBuffer(array, ref offset, ref count);
				if (_writePos >= _bufferSize)
				{
					_stream.Write(_buffer, 0, _writePos);
					_writePos = 0;
					WriteToBuffer(array, ref offset, ref count);
				}
				return;
			}
		}
		if (_writePos > 0)
		{
			if (num <= _bufferSize + _bufferSize && num <= 81920)
			{
				EnsureShadowBufferAllocated();
				Array.Copy(array, offset, _buffer, _writePos, count);
				_stream.Write(_buffer, 0, num);
				_writePos = 0;
				return;
			}
			_stream.Write(_buffer, 0, _writePos);
			_writePos = 0;
		}
		_stream.Write(array, offset, count);
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return Task.FromCanceled<int>(cancellationToken);
		}
		EnsureNotClosed();
		EnsureCanWrite();
		Task task = _sem.WaitAsync(cancellationToken);
		if (task.Status == TaskStatus.RanToCompletion)
		{
			bool flag = true;
			try
			{
				flag = count < _bufferSize - _writePos;
				if (flag)
				{
					WriteToBuffer(buffer, ref offset, ref count, out var error);
					return (error == null) ? Task.CompletedTask : Task.FromException(error);
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
		return WriteToUnderlyingStreamAsync(buffer, offset, count, cancellationToken, task);
	}

	private async Task WriteToUnderlyingStreamAsync(byte[] array, int offset, int count, CancellationToken cancellationToken, Task semaphoreLockTask)
	{
		EnsureNotClosed();
		EnsureCanWrite();
		await semaphoreLockTask.ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			int num;
			checked
			{
				num = _writePos + count;
				if (num + count < _bufferSize + _bufferSize)
				{
					WriteToBuffer(array, ref offset, ref count);
					if (_writePos >= _bufferSize)
					{
						await _stream.WriteAsync(_buffer, 0, _writePos, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						_writePos = 0;
						WriteToBuffer(array, ref offset, ref count);
					}
					return;
				}
			}
			if (_writePos > 0)
			{
				if (num <= _bufferSize + _bufferSize && num <= 81920)
				{
					EnsureShadowBufferAllocated();
					Buffer.BlockCopy(array, offset, _buffer, _writePos, count);
					await _stream.WriteAsync(_buffer, 0, num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					_writePos = 0;
					return;
				}
				await _stream.WriteAsync(_buffer, 0, _writePos, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				_writePos = 0;
			}
			await _stream.WriteAsync(array, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			_sem.Release();
		}
	}

	public override void WriteByte(byte value)
	{
		EnsureNotClosed();
		if (_writePos >= _bufferSize - 1)
		{
			FlushWrite();
		}
		_buffer[_writePos++] = value;
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
