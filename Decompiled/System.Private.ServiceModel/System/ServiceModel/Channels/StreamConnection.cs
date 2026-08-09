using System.IO;
using System.Net;
using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class StreamConnection : IConnection
{
	private byte[] _asyncReadBuffer;

	private int _bytesRead;

	private ConnectionStream _innerStream;

	private Action<Task<int>, object> _onRead;

	private Action<Task, object> _onWrite;

	private Task<int> _readResult;

	private Task _writeResult;

	private Action<object> _readCallback;

	private Action<object> _writeCallback;

	public byte[] AsyncReadBuffer
	{
		get
		{
			if (_asyncReadBuffer == null)
			{
				lock (ThisLock)
				{
					if (_asyncReadBuffer == null)
					{
						_asyncReadBuffer = Fx.AllocateByteArray(_innerStream.Connection.AsyncReadBufferSize);
					}
				}
			}
			return _asyncReadBuffer;
		}
	}

	public int AsyncReadBufferSize => _innerStream.Connection.AsyncReadBufferSize;

	public Stream Stream { get; }

	public object ThisLock => this;

	public IPEndPoint RemoteIPEndPoint
	{
		get
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	public StreamConnection(Stream stream, ConnectionStream innerStream)
	{
		Stream = stream;
		_innerStream = innerStream;
		_onRead = OnRead;
		_onWrite = OnWrite;
	}

	public void Abort()
	{
		_innerStream.Abort();
	}

	private Exception ConvertIOException(IOException ioException)
	{
		if (ioException.InnerException is TimeoutException)
		{
			return new TimeoutException(ioException.InnerException.Message, ioException);
		}
		if (ioException.InnerException is CommunicationObjectAbortedException)
		{
			return new CommunicationObjectAbortedException(ioException.InnerException.Message, ioException);
		}
		if (ioException.InnerException is CommunicationException)
		{
			return new CommunicationException(ioException.InnerException.Message, ioException);
		}
		return new CommunicationException(System.SR.StreamError, ioException);
	}

	public void Close(TimeSpan timeout, bool asyncAndLinger)
	{
		_innerStream.CloseTimeout = timeout;
		try
		{
			Stream.Dispose();
		}
		catch (IOException ioException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertIOException(ioException));
		}
	}

	public AsyncCompletionResult BeginWrite(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, Action<object> callback, object state)
	{
		_writeCallback = callback;
		bool flag = true;
		try
		{
			_innerStream.Immediate = immediate;
			SetWriteTimeout(timeout);
			Task task = Stream.WriteAsync(buffer, offset, size);
			flag = false;
			if (!task.IsCompleted)
			{
				task.ContinueWith(_onWrite, state);
				return AsyncCompletionResult.Queued;
			}
			task.GetAwaiter().GetResult();
		}
		catch (IOException ioException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertIOException(ioException));
		}
		finally
		{
			if (flag)
			{
				_writeCallback = null;
			}
		}
		return AsyncCompletionResult.Completed;
	}

	public void EndWrite()
	{
		Task writeResult = _writeResult;
		_writeResult = null;
		_writeCallback = null;
		if (writeResult != null)
		{
			try
			{
				writeResult.GetAwaiter().GetResult();
			}
			catch (IOException ioException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertIOException(ioException));
			}
		}
	}

	private void OnWrite(Task antecedent, object state)
	{
		_writeResult = antecedent;
		_writeCallback(state);
	}

	public void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout)
	{
		try
		{
			_innerStream.Immediate = immediate;
			SetWriteTimeout(timeout);
			Stream.Write(buffer, offset, size);
		}
		catch (IOException ioException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertIOException(ioException));
		}
	}

	public void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, BufferManager bufferManager)
	{
		Write(buffer, offset, size, immediate, timeout);
		bufferManager.ReturnBuffer(buffer);
	}

	private void SetReadTimeout(TimeSpan timeout)
	{
		int readTimeout = TimeoutHelper.ToMilliseconds(timeout);
		if (Stream.CanTimeout)
		{
			Stream.ReadTimeout = readTimeout;
		}
		_innerStream.ReadTimeout = readTimeout;
	}

	private void SetWriteTimeout(TimeSpan timeout)
	{
		int writeTimeout = TimeoutHelper.ToMilliseconds(timeout);
		if (Stream.CanTimeout)
		{
			Stream.WriteTimeout = writeTimeout;
		}
		_innerStream.WriteTimeout = writeTimeout;
	}

	public int Read(byte[] buffer, int offset, int size, TimeSpan timeout)
	{
		try
		{
			SetReadTimeout(timeout);
			return Stream.Read(buffer, offset, size);
		}
		catch (IOException ioException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertIOException(ioException));
		}
	}

	public AsyncCompletionResult BeginRead(int offset, int size, TimeSpan timeout, Action<object> callback, object state)
	{
		ConnectionUtilities.ValidateBufferBounds(AsyncReadBufferSize, offset, size);
		_readCallback = callback;
		try
		{
			SetReadTimeout(timeout);
			Task<int> task = Stream.ReadAsync(AsyncReadBuffer, offset, size);
			if (!task.IsCompleted)
			{
				task.ContinueWith(_onRead, state);
				return AsyncCompletionResult.Queued;
			}
			_bytesRead = task.GetAwaiter().GetResult();
		}
		catch (IOException ioException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertIOException(ioException));
		}
		return AsyncCompletionResult.Completed;
	}

	public int EndRead()
	{
		Task<int> readResult = _readResult;
		_readResult = null;
		if (readResult != null)
		{
			try
			{
				_bytesRead = readResult.GetAwaiter().GetResult();
			}
			catch (IOException ioException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertIOException(ioException));
			}
		}
		return _bytesRead;
	}

	private void OnRead(Task<int> antecedent, object state)
	{
		_readResult = antecedent;
		_readCallback(state);
	}

	public virtual object GetCoreTransport()
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotImplementedException());
	}
}
