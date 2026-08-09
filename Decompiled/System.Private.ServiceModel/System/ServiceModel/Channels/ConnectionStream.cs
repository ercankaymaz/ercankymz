using System.IO;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class ConnectionStream : Stream
{
	private int _readTimeout;

	private int _writeTimeout;

	private static Action<object> s_onWriteComplete = OnWriteComplete;

	private static Action<object> s_onReadComplete = OnReadComplete;

	public IConnection Connection { get; }

	public override bool CanRead => true;

	public override bool CanSeek => false;

	public override bool CanTimeout => true;

	public override bool CanWrite => true;

	public TimeSpan CloseTimeout { get; set; }

	public override int ReadTimeout
	{
		get
		{
			return _readTimeout;
		}
		set
		{
			if (value < -1)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.Format(System.SR.ValueMustBeInRange, -1, int.MaxValue)));
			}
			_readTimeout = value;
		}
	}

	public override int WriteTimeout
	{
		get
		{
			return _writeTimeout;
		}
		set
		{
			if (value < -1)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.Format(System.SR.ValueMustBeInRange, -1, int.MaxValue)));
			}
			_writeTimeout = value;
		}
	}

	public bool Immediate { get; set; }

	public override long Length
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.SPS_SeekNotSupported));
		}
	}

	public override long Position
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.SPS_SeekNotSupported));
		}
		set
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.SPS_SeekNotSupported));
		}
	}

	public ConnectionStream(IConnection connection, IDefaultCommunicationTimeouts defaultTimeouts)
	{
		Connection = connection;
		CloseTimeout = defaultTimeouts.CloseTimeout;
		ReadTimeout = TimeoutHelper.ToMilliseconds(defaultTimeouts.ReceiveTimeout);
		WriteTimeout = TimeoutHelper.ToMilliseconds(defaultTimeouts.SendTimeout);
		Immediate = true;
	}

	public void Abort()
	{
		Connection.Abort();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Connection.Close(CloseTimeout, asyncAndLinger: false);
		}
	}

	public override void Flush()
	{
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(this);
		AsyncCompletionResult asyncCompletionResult = Connection.BeginWrite(buffer, offset, count, Immediate, TimeoutHelper.FromMilliseconds(WriteTimeout), s_onWriteComplete, taskCompletionSource);
		if (asyncCompletionResult == AsyncCompletionResult.Completed)
		{
			Connection.EndWrite();
			taskCompletionSource.TrySetResult(result: true);
		}
		return taskCompletionSource.Task;
	}

	private static void OnWriteComplete(object state)
	{
		if (state == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("state");
		}
		if (!(state is TaskCompletionSource<bool> taskCompletionSource))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("state", System.SR.SPS_InvalidAsyncResult);
		}
		if (!(taskCompletionSource.Task.AsyncState is ConnectionStream connectionStream))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("state", System.SR.SPS_InvalidAsyncResult);
		}
		try
		{
			connectionStream.Connection.EndWrite();
			taskCompletionSource.TrySetResult(result: true);
		}
		catch (Exception exception)
		{
			taskCompletionSource.TrySetException(exception);
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		Connection.Write(buffer, offset, count, Immediate, TimeoutHelper.FromMilliseconds(WriteTimeout));
	}

	public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		TaskCompletionSource<int> taskCompletionSource = new TaskCompletionSource<int>(this);
		AsyncCompletionResult asyncCompletionResult = Connection.BeginRead(0, Math.Min(count, Connection.AsyncReadBufferSize), TimeoutHelper.FromMilliseconds(ReadTimeout), s_onReadComplete, taskCompletionSource);
		if (asyncCompletionResult == AsyncCompletionResult.Completed)
		{
			taskCompletionSource.TrySetResult(Connection.EndRead());
		}
		int num = await taskCompletionSource.Task;
		Buffer.BlockCopy(Connection.AsyncReadBuffer, 0, buffer, offset, num);
		return num;
	}

	private static void OnReadComplete(object state)
	{
		if (state == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("state");
		}
		if (!(state is TaskCompletionSource<int> taskCompletionSource))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("state", System.SR.SPS_InvalidAsyncResult);
		}
		if (!(taskCompletionSource.Task.AsyncState is ConnectionStream connectionStream))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("state", System.SR.SPS_InvalidAsyncResult);
		}
		try
		{
			taskCompletionSource.TrySetResult(connectionStream.Connection.EndRead());
		}
		catch (Exception exception)
		{
			taskCompletionSource.TrySetException(exception);
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return Read(buffer, offset, count, TimeoutHelper.FromMilliseconds(ReadTimeout));
	}

	protected int Read(byte[] buffer, int offset, int count, TimeSpan timeout)
	{
		return Connection.Read(buffer, offset, count, timeout);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.SPS_SeekNotSupported));
	}

	public override void SetLength(long value)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.SPS_SeekNotSupported));
	}
}
