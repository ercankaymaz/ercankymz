using System.Runtime;
using System.Threading;

namespace System.ServiceModel.Channels;

internal class BufferedConnection : DelegatingConnection
{
	private byte[] _writeBuffer;

	private int _writeBufferSize;

	private int _pendingWriteSize;

	private Exception _pendingWriteException;

	private Timer _flushTimer;

	private TimeSpan _flushTimeout;

	private TimeSpan _pendingTimeout;

	private const int maxFlushSkew = 100;

	private object ThisLock => this;

	public BufferedConnection(IConnection connection, TimeSpan flushTimeout, int writeBufferSize)
		: base(connection)
	{
		_flushTimeout = flushTimeout;
		_writeBufferSize = writeBufferSize;
	}

	public override void Close(TimeSpan timeout, bool asyncAndLinger)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		Flush(timeoutHelper.RemainingTime());
		base.Close(timeoutHelper.RemainingTime(), asyncAndLinger);
	}

	private void CancelFlushTimer()
	{
		if (_flushTimer != null)
		{
			_flushTimer.Change(TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0));
			_pendingTimeout = TimeSpan.Zero;
		}
	}

	private void Flush(TimeSpan timeout)
	{
		ThrowPendingWriteException();
		lock (ThisLock)
		{
			FlushCore(timeout);
		}
	}

	private void FlushCore(TimeSpan timeout)
	{
		if (_pendingWriteSize > 0)
		{
			base.Connection.Write(_writeBuffer, 0, _pendingWriteSize, immediate: false, timeout);
			_pendingWriteSize = 0;
		}
	}

	private void OnFlushTimer(object state)
	{
		lock (ThisLock)
		{
			try
			{
				FlushCore(_pendingTimeout);
				_pendingTimeout = TimeSpan.Zero;
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				_pendingWriteException = ex;
				CancelFlushTimer();
			}
		}
	}

	private void SetFlushTimer()
	{
		if (_flushTimer == null)
		{
			_flushTimer = new Timer(new Action<object>(OnFlushTimer).Invoke, null, TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0));
		}
		_flushTimer.Change(_flushTimeout, TimeSpan.FromMilliseconds(-1.0));
	}

	public override void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, BufferManager bufferManager)
	{
		if (size <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("size", size, System.SR.ValueMustBePositive));
		}
		ThrowPendingWriteException();
		if (immediate || _flushTimeout == TimeSpan.Zero)
		{
			WriteNow(buffer, offset, size, timeout, bufferManager);
			return;
		}
		WriteLater(buffer, offset, size, timeout);
		bufferManager.ReturnBuffer(buffer);
	}

	public override void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout)
	{
		if (size <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("size", size, System.SR.ValueMustBePositive));
		}
		ThrowPendingWriteException();
		if (immediate || _flushTimeout == TimeSpan.Zero)
		{
			WriteNow(buffer, offset, size, timeout);
		}
		else
		{
			WriteLater(buffer, offset, size, timeout);
		}
	}

	private void WriteNow(byte[] buffer, int offset, int size, TimeSpan timeout)
	{
		WriteNow(buffer, offset, size, timeout, null);
	}

	private void WriteNow(byte[] buffer, int offset, int size, TimeSpan timeout, BufferManager bufferManager)
	{
		lock (ThisLock)
		{
			if (_pendingWriteSize > 0)
			{
				int num = _writeBufferSize - _pendingWriteSize;
				CancelFlushTimer();
				if (size <= num)
				{
					Buffer.BlockCopy(buffer, offset, _writeBuffer, _pendingWriteSize, size);
					bufferManager?.ReturnBuffer(buffer);
					_pendingWriteSize += size;
					FlushCore(timeout);
					return;
				}
				TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
				FlushCore(timeoutHelper.RemainingTime());
				timeout = timeoutHelper.RemainingTime();
			}
			if (bufferManager == null)
			{
				base.Connection.Write(buffer, offset, size, immediate: true, timeout);
			}
			else
			{
				base.Connection.Write(buffer, offset, size, immediate: true, timeout, bufferManager);
			}
		}
	}

	private void WriteLater(byte[] buffer, int offset, int size, TimeSpan timeout)
	{
		lock (ThisLock)
		{
			bool flag = _pendingWriteSize == 0;
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			while (size > 0)
			{
				if (size >= _writeBufferSize && _pendingWriteSize == 0)
				{
					base.Connection.Write(buffer, offset, size, immediate: false, timeoutHelper.RemainingTime());
					size = 0;
					continue;
				}
				if (_writeBuffer == null)
				{
					_writeBuffer = Fx.AllocateByteArray(_writeBufferSize);
				}
				int num = _writeBufferSize - _pendingWriteSize;
				int num2 = size;
				if (num2 > num)
				{
					num2 = num;
				}
				Buffer.BlockCopy(buffer, offset, _writeBuffer, _pendingWriteSize, num2);
				_pendingWriteSize += num2;
				if (_pendingWriteSize == _writeBufferSize)
				{
					FlushCore(timeoutHelper.RemainingTime());
					flag = true;
				}
				size -= num2;
				offset += num2;
			}
			if (_pendingWriteSize > 0)
			{
				if (flag)
				{
					SetFlushTimer();
					_pendingTimeout = TimeoutHelper.Add(_pendingTimeout, timeoutHelper.RemainingTime());
				}
			}
			else
			{
				CancelFlushTimer();
			}
		}
	}

	public override AsyncCompletionResult BeginWrite(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, Action<object> callback, object state)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		Flush(timeoutHelper.RemainingTime());
		return base.BeginWrite(buffer, offset, size, immediate, timeoutHelper.RemainingTime(), callback, state);
	}

	public override void EndWrite()
	{
		base.EndWrite();
	}

	private void ThrowPendingWriteException()
	{
		if (_pendingWriteException == null)
		{
			return;
		}
		lock (ThisLock)
		{
			if (_pendingWriteException != null)
			{
				Exception pendingWriteException = _pendingWriteException;
				_pendingWriteException = null;
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(pendingWriteException);
			}
		}
	}
}
