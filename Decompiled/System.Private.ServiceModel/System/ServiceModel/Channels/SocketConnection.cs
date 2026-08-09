using System.Net;
using System.Net.Sockets;
using System.Runtime;
using System.Threading;

namespace System.ServiceModel.Channels;

internal class SocketConnection : IConnection
{
	private enum CloseState
	{
		Open,
		Closing,
		Closed
	}

	private enum TransferOperation
	{
		Write,
		Read,
		Undefined
	}

	private static AsyncCallback s_onReceiveCompleted;

	private static EventHandler<SocketAsyncEventArgs> s_onReceiveAsyncCompleted;

	private static EventHandler<SocketAsyncEventArgs> s_onSocketSendCompleted;

	private Socket _socket;

	private TimeSpan _asyncSendTimeout;

	private TimeSpan _readFinTimeout;

	private TimeSpan _asyncReceiveTimeout;

	private TimeSpan _socketSyncSendTimeout;

	private TimeSpan _socketSyncReceiveTimeout;

	private CloseState _closeState;

	private bool _isShutdown;

	private bool _noDelay;

	private bool _aborted;

	private TimeoutHelper _closeTimeoutHelper;

	private static Action<object> s_onWaitForFinComplete = OnWaitForFinComplete;

	private int _asyncReadSize;

	private SocketAsyncEventArgs _asyncReadEventArgs;

	private byte[] _readBuffer;

	private int _asyncReadBufferSize;

	private object _asyncReadState;

	private Action<object> _asyncReadCallback;

	private Exception _asyncReadException;

	private bool _asyncReadPending;

	private SocketAsyncEventArgs _asyncWriteEventArgs;

	private object _asyncWriteState;

	private Action<object> _asyncWriteCallback;

	private Exception _asyncWriteException;

	private bool _asyncWritePending;

	private IOThreadTimer _receiveTimer;

	private static Action<object> s_onReceiveTimeout;

	private IOThreadTimer _sendTimer;

	private static Action<object> s_onSendTimeout;

	private string _timeoutErrorString;

	private TransferOperation _timeoutErrorTransferOperation;

	private IPEndPoint _remoteEndpoint;

	private ConnectionBufferPool _connectionBufferPool;

	private string _remoteEndpointAddress;

	public int AsyncReadBufferSize => _asyncReadBufferSize;

	public byte[] AsyncReadBuffer => _readBuffer;

	private object ThisLock => this;

	public IPEndPoint RemoteIPEndPoint
	{
		get
		{
			if (_remoteEndpoint == null && _closeState == CloseState.Open)
			{
				try
				{
					_remoteEndpoint = (IPEndPoint)_socket.RemoteEndPoint;
				}
				catch (SocketException socketException)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertReceiveException(socketException, TimeSpan.Zero, TimeSpan.Zero));
				}
				catch (ObjectDisposedException ex)
				{
					Exception ex2 = ConvertObjectDisposedException(ex, TransferOperation.Undefined);
					if (ex2 == ex)
					{
						throw;
					}
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex2);
				}
			}
			return _remoteEndpoint;
		}
	}

	private IOThreadTimer SendTimer
	{
		get
		{
			if (_sendTimer == null)
			{
				if (s_onSendTimeout == null)
				{
					s_onSendTimeout = OnSendTimeout;
				}
				_sendTimer = new IOThreadTimer(s_onSendTimeout, this, isTypicallyCanceledShortlyAfterBeingSet: false);
			}
			return _sendTimer;
		}
	}

	private IOThreadTimer ReceiveTimer
	{
		get
		{
			if (_receiveTimer == null)
			{
				if (s_onReceiveTimeout == null)
				{
					s_onReceiveTimeout = OnReceiveTimeout;
				}
				_receiveTimer = new IOThreadTimer(s_onReceiveTimeout, this, isTypicallyCanceledShortlyAfterBeingSet: false);
			}
			return _receiveTimer;
		}
	}

	private string RemoteEndpointAddress
	{
		get
		{
			if (_remoteEndpointAddress == null)
			{
				try
				{
					if (TryGetEndpoints(out var _, out var remoteIPEndpoint))
					{
						_remoteEndpointAddress = remoteIPEndpoint.Address?.ToString() + ":" + remoteIPEndpoint.Port;
					}
					else
					{
						_remoteEndpointAddress = string.Empty;
					}
				}
				catch (Exception exception)
				{
					if (Fx.IsFatal(exception))
					{
						throw;
					}
				}
			}
			return _remoteEndpointAddress;
		}
	}

	public SocketConnection(Socket socket, ConnectionBufferPool connectionBufferPool, bool autoBindToCompletionPort)
	{
		_connectionBufferPool = connectionBufferPool ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("connectionBufferPool");
		_socket = socket ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("socket");
		_closeState = CloseState.Open;
		_readBuffer = connectionBufferPool.Take();
		_asyncReadBufferSize = _readBuffer.Length;
		_socket.SendBufferSize = (_socket.ReceiveBufferSize = _asyncReadBufferSize);
		_asyncSendTimeout = (_asyncReceiveTimeout = TimeSpan.MaxValue);
		_socketSyncSendTimeout = (_socketSyncReceiveTimeout = TimeSpan.MaxValue);
		_remoteEndpoint = null;
		if (autoBindToCompletionPort)
		{
			_socket.UseOnlyOverlappedIO = false;
		}
		if (_socket.UseOnlyOverlappedIO && s_onReceiveCompleted == null)
		{
			s_onReceiveCompleted = Fx.ThunkCallback(OnReceiveCompleted);
		}
	}

	private static void OnReceiveTimeout(object state)
	{
		SocketConnection socketConnection = (SocketConnection)state;
		socketConnection.Abort(System.SR.Format(System.SR.SocketAbortedReceiveTimedOut, socketConnection._asyncReceiveTimeout), TransferOperation.Read);
	}

	private static void OnSendTimeout(object state)
	{
		SocketConnection socketConnection = (SocketConnection)state;
		socketConnection.Abort(4, System.SR.Format(System.SR.SocketAbortedSendTimedOut, socketConnection._asyncSendTimeout), TransferOperation.Write);
	}

	private static void OnReceiveCompleted(IAsyncResult result)
	{
		((SocketConnection)result.AsyncState).OnReceive(result);
	}

	private static void OnReceiveAsyncCompleted(object sender, SocketAsyncEventArgs e)
	{
		((SocketConnection)e.UserToken).OnReceiveAsync(sender, e);
	}

	private static void OnSendAsyncCompleted(object sender, SocketAsyncEventArgs e)
	{
		((SocketConnection)e.UserToken).OnSendAsync(sender, e);
	}

	public void Abort()
	{
		Abort(null, TransferOperation.Undefined);
	}

	private void Abort(string timeoutErrorString, TransferOperation transferOperation)
	{
		int traceEventType = 4;
		Abort(traceEventType, timeoutErrorString, transferOperation);
	}

	private void Abort(int traceEventType)
	{
		Abort(traceEventType, null, TransferOperation.Undefined);
	}

	private void Abort(int traceEventType, string timeoutErrorString, TransferOperation transferOperation)
	{
		lock (ThisLock)
		{
			if (_closeState == CloseState.Closed)
			{
				return;
			}
			_timeoutErrorString = timeoutErrorString;
			_timeoutErrorTransferOperation = transferOperation;
			_aborted = true;
			_closeState = CloseState.Closed;
			if (_asyncReadPending)
			{
				CancelReceiveTimer();
			}
			else
			{
				DisposeReadEventArgs();
			}
			if (_asyncWritePending)
			{
				CancelSendTimer();
			}
			else
			{
				DisposeWriteEventArgs();
			}
		}
		_socket.Close(0);
	}

	private void AbortRead()
	{
		lock (ThisLock)
		{
			if (_asyncReadPending)
			{
				if (_closeState != CloseState.Closed)
				{
					SetUserToken(_asyncReadEventArgs, null);
					_asyncReadPending = false;
					CancelReceiveTimer();
				}
				else
				{
					DisposeReadEventArgs();
				}
			}
		}
	}

	private void CancelReceiveTimer()
	{
		if (_receiveTimer != null)
		{
			_receiveTimer.Cancel();
		}
	}

	private void CancelSendTimer()
	{
		_sendTimer?.Cancel();
	}

	private void CloseAsyncAndLinger()
	{
		_readFinTimeout = _closeTimeoutHelper.RemainingTime();
		try
		{
			if (BeginReadCore(0, 1, _readFinTimeout, s_onWaitForFinComplete, this) == AsyncCompletionResult.Queued)
			{
				return;
			}
			int num = EndRead();
			if (num > 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SocketCloseReadReceivedData, _socket.RemoteEndPoint)));
			}
		}
		catch (TimeoutException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.SocketCloseReadTimeout, _socket.RemoteEndPoint, _readFinTimeout), innerException));
		}
		ContinueClose(_closeTimeoutHelper.RemainingTime());
	}

	private static void OnWaitForFinComplete(object state)
	{
		SocketConnection socketConnection = (SocketConnection)state;
		try
		{
			try
			{
				int num = socketConnection.EndRead();
				if (num > 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SocketCloseReadReceivedData, socketConnection._socket.RemoteEndPoint)));
				}
			}
			catch (TimeoutException innerException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.SocketCloseReadTimeout, socketConnection._socket.RemoteEndPoint, socketConnection._readFinTimeout), innerException));
			}
			socketConnection.ContinueClose(socketConnection._closeTimeoutHelper.RemainingTime());
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
			socketConnection.Abort();
		}
	}

	public void Close(TimeSpan timeout, bool asyncAndLinger)
	{
		lock (ThisLock)
		{
			if (_closeState == CloseState.Closing || _closeState == CloseState.Closed)
			{
				return;
			}
			_closeState = CloseState.Closing;
		}
		_closeTimeoutHelper = new TimeoutHelper(timeout);
		Shutdown(_closeTimeoutHelper.RemainingTime());
		if (asyncAndLinger)
		{
			CloseAsyncAndLinger();
		}
		else
		{
			CloseSync();
		}
	}

	private void CloseSync()
	{
		byte[] buffer = new byte[1];
		_readFinTimeout = _closeTimeoutHelper.RemainingTime();
		try
		{
			int num = ReadCore(buffer, 0, 1, _readFinTimeout, closing: true);
			if (num > 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SocketCloseReadReceivedData, _socket.RemoteEndPoint)));
			}
		}
		catch (TimeoutException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.SocketCloseReadTimeout, _socket.RemoteEndPoint, _readFinTimeout), innerException));
		}
		ContinueClose(_closeTimeoutHelper.RemainingTime());
	}

	public void ContinueClose(TimeSpan timeout)
	{
		_socket.Close(TimeoutHelper.ToMilliseconds(timeout));
		lock (ThisLock)
		{
			if (_closeState != CloseState.Closed)
			{
				if (!_asyncReadPending)
				{
					DisposeReadEventArgs();
				}
				if (!_asyncWritePending)
				{
					DisposeWriteEventArgs();
				}
			}
			_closeState = CloseState.Closed;
		}
	}

	public void Shutdown(TimeSpan timeout)
	{
		lock (ThisLock)
		{
			if (_isShutdown)
			{
				return;
			}
			_isShutdown = true;
		}
		try
		{
			_socket.Shutdown(SocketShutdown.Send);
		}
		catch (SocketException socketException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertSendException(socketException, TimeSpan.MaxValue, _socketSyncSendTimeout));
		}
		catch (ObjectDisposedException ex)
		{
			Exception ex2 = ConvertObjectDisposedException(ex, TransferOperation.Undefined);
			if (ex2 == ex)
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex2);
		}
	}

	private void ThrowIfNotOpen()
	{
		if (_closeState == CloseState.Closing || _closeState == CloseState.Closed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertObjectDisposedException(new ObjectDisposedException(GetType().ToString(), System.SR.SocketConnectionDisposed), TransferOperation.Undefined));
		}
	}

	private void ThrowIfClosed()
	{
		if (_closeState == CloseState.Closed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertObjectDisposedException(new ObjectDisposedException(GetType().ToString(), System.SR.SocketConnectionDisposed), TransferOperation.Undefined));
		}
	}

	private bool TryGetEndpoints(out IPEndPoint localIPEndpoint, out IPEndPoint remoteIPEndpoint)
	{
		localIPEndpoint = null;
		remoteIPEndpoint = null;
		if (_closeState == CloseState.Open)
		{
			try
			{
				remoteIPEndpoint = _remoteEndpoint ?? ((IPEndPoint)_socket.RemoteEndPoint);
				localIPEndpoint = (IPEndPoint)_socket.LocalEndPoint;
			}
			catch (Exception exception)
			{
				if (Fx.IsFatal(exception))
				{
					throw;
				}
			}
		}
		if (localIPEndpoint != null)
		{
			return remoteIPEndpoint != null;
		}
		return false;
	}

	public object GetCoreTransport()
	{
		return _socket;
	}

	public IAsyncResult BeginValidate(Uri uri, AsyncCallback callback, object state)
	{
		return new CompletedAsyncResult<bool>(data: true, callback, state);
	}

	public bool EndValidate(IAsyncResult result)
	{
		return CompletedAsyncResult<bool>.End(result);
	}

	private Exception ConvertSendException(SocketException socketException, TimeSpan remainingTime, TimeSpan timeout)
	{
		return ConvertTransferException(socketException, timeout, socketException, TransferOperation.Write, _aborted, _timeoutErrorString, _timeoutErrorTransferOperation, this, remainingTime);
	}

	private Exception ConvertReceiveException(SocketException socketException, TimeSpan remainingTime, TimeSpan timeout)
	{
		return ConvertTransferException(socketException, timeout, socketException, TransferOperation.Read, _aborted, _timeoutErrorString, _timeoutErrorTransferOperation, this, remainingTime);
	}

	internal static Exception ConvertTransferException(SocketException socketException, TimeSpan timeout, Exception originalException)
	{
		return ConvertTransferException(socketException, timeout, originalException, TransferOperation.Undefined, aborted: false, null, TransferOperation.Undefined, null, TimeSpan.MaxValue);
	}

	private Exception ConvertObjectDisposedException(ObjectDisposedException originalException, TransferOperation transferOperation)
	{
		if (_timeoutErrorString != null)
		{
			return ConvertTimeoutErrorException(originalException, transferOperation, _timeoutErrorString, _timeoutErrorTransferOperation);
		}
		if (_aborted)
		{
			return new CommunicationObjectAbortedException(System.SR.SocketConnectionDisposed, originalException);
		}
		return originalException;
	}

	private static Exception ConvertTransferException(SocketException socketException, TimeSpan timeout, Exception originalException, TransferOperation transferOperation, bool aborted, string timeoutErrorString, TransferOperation timeoutErrorTransferOperation, SocketConnection socketConnection, TimeSpan remainingTime)
	{
		if (socketException.ErrorCode == 6)
		{
			return new CommunicationObjectAbortedException(socketException.Message, socketException);
		}
		if (timeoutErrorString != null)
		{
			return ConvertTimeoutErrorException(originalException, transferOperation, timeoutErrorString, timeoutErrorTransferOperation);
		}
		if (socketException.ErrorCode == 10053 && remainingTime <= TimeSpan.Zero)
		{
			return new TimeoutException(System.SR.Format(System.SR.TcpConnectionTimedOut, timeout), originalException);
		}
		if (socketException.ErrorCode == 10052 || socketException.ErrorCode == 10053 || socketException.ErrorCode == 10054)
		{
			if (aborted)
			{
				return new CommunicationObjectAbortedException(System.SR.TcpLocalConnectionAborted, originalException);
			}
			return new CommunicationException(System.SR.Format(System.SR.TcpConnectionResetError, timeout), originalException);
		}
		if (socketException.ErrorCode == 10060)
		{
			return new TimeoutException(System.SR.Format(System.SR.TcpConnectionTimedOut, timeout), originalException);
		}
		if (aborted)
		{
			return new CommunicationObjectAbortedException(System.SR.Format(System.SR.TcpTransferError, socketException.ErrorCode, socketException.Message), originalException);
		}
		return new CommunicationException(System.SR.Format(System.SR.TcpTransferError, socketException.ErrorCode, socketException.Message), originalException);
	}

	private static Exception ConvertTimeoutErrorException(Exception originalException, TransferOperation transferOperation, string timeoutErrorString, TransferOperation timeoutErrorTransferOperation)
	{
		if (transferOperation == timeoutErrorTransferOperation)
		{
			return new TimeoutException(timeoutErrorString, originalException);
		}
		return new CommunicationException(timeoutErrorString, originalException);
	}

	public AsyncCompletionResult BeginWrite(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, Action<object> callback, object state)
	{
		ConnectionUtilities.ValidateBufferBounds(buffer, offset, size);
		bool flag = true;
		try
		{
			if (WcfEventSource.Instance.SocketAsyncWriteStartIsEnabled())
			{
				TraceWriteStart(size, async: true);
			}
			lock (ThisLock)
			{
				ThrowIfClosed();
				EnsureWriteEventArgs();
				SetImmediate(immediate);
				SetWriteTimeout(timeout, synchronous: false);
				SetUserToken(_asyncWriteEventArgs, this);
				_asyncWritePending = true;
				_asyncWriteCallback = callback;
				_asyncWriteState = state;
			}
			_asyncWriteEventArgs.SetBuffer(buffer, offset, size);
			if (_socket.SendAsync(_asyncWriteEventArgs))
			{
				flag = false;
				return AsyncCompletionResult.Queued;
			}
			HandleSendAsyncCompleted();
			flag = false;
			return AsyncCompletionResult.Completed;
		}
		catch (SocketException socketException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertSendException(socketException, TimeSpan.MaxValue, _asyncSendTimeout));
		}
		catch (ObjectDisposedException ex)
		{
			Exception ex2 = ConvertObjectDisposedException(ex, TransferOperation.Write);
			if (ex2 == ex)
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex2);
		}
		finally
		{
			if (flag)
			{
				AbortWrite();
			}
		}
	}

	public void EndWrite()
	{
		if (_asyncWriteException != null)
		{
			AbortWrite();
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_asyncWriteException);
		}
		lock (ThisLock)
		{
			if (!_asyncWritePending)
			{
				throw Fx.AssertAndThrow("SocketConnection.EndWrite called with no write pending.");
			}
			SetUserToken(_asyncWriteEventArgs, null);
			_asyncWritePending = false;
			if (_closeState == CloseState.Closed)
			{
				DisposeWriteEventArgs();
			}
		}
	}

	private void OnSendAsync(object sender, SocketAsyncEventArgs eventArgs)
	{
		CancelSendTimer();
		try
		{
			HandleSendAsyncCompleted();
		}
		catch (SocketException socketException)
		{
			_asyncWriteException = ConvertSendException(socketException, TimeSpan.MaxValue, _asyncSendTimeout);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			_asyncWriteException = ex;
		}
		FinishWrite();
	}

	private void HandleSendAsyncCompleted()
	{
		if (_asyncWriteEventArgs.SocketError == SocketError.Success)
		{
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SocketException((int)_asyncWriteEventArgs.SocketError));
	}

	private void DisposeWriteEventArgs()
	{
		if (_asyncWriteEventArgs != null)
		{
			_asyncWriteEventArgs.Completed -= s_onSocketSendCompleted;
			_asyncWriteEventArgs.Dispose();
		}
	}

	private void AbortWrite()
	{
		lock (ThisLock)
		{
			if (_asyncWritePending)
			{
				if (_closeState != CloseState.Closed)
				{
					SetUserToken(_asyncWriteEventArgs, null);
					_asyncWritePending = false;
					CancelSendTimer();
				}
				else
				{
					DisposeWriteEventArgs();
				}
			}
		}
	}

	private void FinishWrite()
	{
		Action<object> asyncWriteCallback = _asyncWriteCallback;
		object asyncWriteState = _asyncWriteState;
		_asyncWriteState = null;
		_asyncWriteCallback = null;
		asyncWriteCallback(asyncWriteState);
	}

	public void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout)
	{
		ConnectionUtilities.ValidateBufferBounds(buffer, offset, size);
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		try
		{
			SetImmediate(immediate);
			int num = size;
			while (num > 0)
			{
				SetWriteTimeout(timeoutHelper.RemainingTime(), synchronous: true);
				size = Math.Min(num, 65536);
				_socket.Send(buffer, offset, size, SocketFlags.None);
				num -= size;
				offset += size;
				timeout = timeoutHelper.RemainingTime();
			}
		}
		catch (SocketException socketException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertSendException(socketException, timeoutHelper.RemainingTime(), _socketSyncSendTimeout));
		}
		catch (ObjectDisposedException ex)
		{
			Exception ex2 = ConvertObjectDisposedException(ex, TransferOperation.Write);
			if (ex2 == ex)
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex2);
		}
	}

	private void TraceWriteStart(int size, bool async)
	{
		if (!async)
		{
			WcfEventSource.Instance.SocketWriteStart(_socket.GetHashCode(), size, RemoteEndpointAddress);
		}
		else
		{
			WcfEventSource.Instance.SocketAsyncWriteStart(_socket.GetHashCode(), size, RemoteEndpointAddress);
		}
	}

	public void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, BufferManager bufferManager)
	{
		try
		{
			Write(buffer, offset, size, immediate, timeout);
		}
		finally
		{
			bufferManager.ReturnBuffer(buffer);
		}
	}

	public int Read(byte[] buffer, int offset, int size, TimeSpan timeout)
	{
		ConnectionUtilities.ValidateBufferBounds(buffer, offset, size);
		ThrowIfNotOpen();
		return ReadCore(buffer, offset, size, timeout, closing: false);
	}

	private int ReadCore(byte[] buffer, int offset, int size, TimeSpan timeout, bool closing)
	{
		int num = 0;
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		try
		{
			SetReadTimeout(timeoutHelper.RemainingTime(), synchronous: true, closing);
			return _socket.Receive(buffer, offset, size, SocketFlags.None);
		}
		catch (SocketException socketException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertReceiveException(socketException, timeoutHelper.RemainingTime(), _socketSyncReceiveTimeout));
		}
		catch (ObjectDisposedException ex)
		{
			Exception ex2 = ConvertObjectDisposedException(ex, TransferOperation.Read);
			if (ex2 == ex)
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex2);
		}
	}

	private void TraceSocketReadStop(int bytesRead, bool async)
	{
		if (!async)
		{
			WcfEventSource.Instance.SocketReadStop((_socket != null) ? _socket.GetHashCode() : (-1), bytesRead, RemoteEndpointAddress);
		}
		else
		{
			WcfEventSource.Instance.SocketAsyncReadStop((_socket != null) ? _socket.GetHashCode() : (-1), bytesRead, RemoteEndpointAddress);
		}
	}

	public virtual AsyncCompletionResult BeginRead(int offset, int size, TimeSpan timeout, Action<object> callback, object state)
	{
		ConnectionUtilities.ValidateBufferBounds(AsyncReadBufferSize, offset, size);
		ThrowIfNotOpen();
		return BeginReadCore(offset, size, timeout, callback, state);
	}

	private AsyncCompletionResult BeginReadCore(int offset, int size, TimeSpan timeout, Action<object> callback, object state)
	{
		bool flag = true;
		lock (ThisLock)
		{
			ThrowIfClosed();
			EnsureReadEventArgs();
			_asyncReadState = state;
			_asyncReadCallback = callback;
			SetUserToken(_asyncReadEventArgs, this);
			_asyncReadPending = true;
			SetReadTimeout(timeout, synchronous: false, closing: false);
		}
		try
		{
			if (_socket.UseOnlyOverlappedIO)
			{
				IAsyncResult asyncResult = _socket.BeginReceive(AsyncReadBuffer, offset, size, SocketFlags.None, s_onReceiveCompleted, this);
				if (!asyncResult.CompletedSynchronously)
				{
					flag = false;
					return AsyncCompletionResult.Queued;
				}
				_asyncReadSize = _socket.EndReceive(asyncResult);
			}
			else
			{
				if (offset != _asyncReadEventArgs.Offset || size != _asyncReadEventArgs.Count)
				{
					_asyncReadEventArgs.SetBuffer(offset, size);
				}
				if (ReceiveAsync())
				{
					flag = false;
					return AsyncCompletionResult.Queued;
				}
				HandleReceiveAsyncCompleted();
				_asyncReadSize = _asyncReadEventArgs.BytesTransferred;
			}
			if (WcfEventSource.Instance.SocketReadStopIsEnabled())
			{
				TraceSocketReadStop(_asyncReadSize, async: true);
			}
			flag = false;
			return AsyncCompletionResult.Completed;
		}
		catch (SocketException socketException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertReceiveException(socketException, TimeSpan.MaxValue, _asyncReceiveTimeout));
		}
		catch (ObjectDisposedException ex)
		{
			Exception ex2 = ConvertObjectDisposedException(ex, TransferOperation.Read);
			if (ex2 == ex)
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex2);
		}
		finally
		{
			if (flag)
			{
				AbortRead();
			}
		}
	}

	private bool ReceiveAsync()
	{
		if (!ExecutionContext.IsFlowSuppressed())
		{
			return ReceiveAsyncNoFlow();
		}
		return _socket.ReceiveAsync(_asyncReadEventArgs);
	}

	private bool ReceiveAsyncNoFlow()
	{
		using (ExecutionContext.SuppressFlow())
		{
			return _socket.ReceiveAsync(_asyncReadEventArgs);
		}
	}

	private void OnReceive(IAsyncResult result)
	{
		CancelReceiveTimer();
		if (result.CompletedSynchronously)
		{
			return;
		}
		try
		{
			_asyncReadSize = _socket.EndReceive(result);
			if (WcfEventSource.Instance.SocketReadStopIsEnabled())
			{
				TraceSocketReadStop(_asyncReadSize, async: true);
			}
		}
		catch (SocketException socketException)
		{
			_asyncReadException = ConvertReceiveException(socketException, TimeSpan.MaxValue, _asyncReceiveTimeout);
		}
		catch (ObjectDisposedException originalException)
		{
			_asyncReadException = ConvertObjectDisposedException(originalException, TransferOperation.Read);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			_asyncReadException = ex;
		}
		FinishRead();
	}

	private void OnReceiveAsync(object sender, SocketAsyncEventArgs eventArgs)
	{
		CancelReceiveTimer();
		try
		{
			HandleReceiveAsyncCompleted();
			_asyncReadSize = eventArgs.BytesTransferred;
			if (WcfEventSource.Instance.SocketReadStopIsEnabled())
			{
				TraceSocketReadStop(_asyncReadSize, async: true);
			}
		}
		catch (SocketException socketException)
		{
			_asyncReadException = ConvertReceiveException(socketException, TimeSpan.MaxValue, _asyncReceiveTimeout);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			_asyncReadException = ex;
		}
		FinishRead();
	}

	private void HandleReceiveAsyncCompleted()
	{
		if (_asyncReadEventArgs.SocketError == SocketError.Success)
		{
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SocketException((int)_asyncReadEventArgs.SocketError));
	}

	private void FinishRead()
	{
		Action<object> asyncReadCallback = _asyncReadCallback;
		object asyncReadState = _asyncReadState;
		_asyncReadState = null;
		_asyncReadCallback = null;
		asyncReadCallback(asyncReadState);
	}

	public int EndRead()
	{
		if (_asyncReadException != null)
		{
			AbortRead();
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_asyncReadException);
		}
		lock (ThisLock)
		{
			if (!_asyncReadPending)
			{
				throw Fx.AssertAndThrow("SocketConnection.EndRead called with no read pending.");
			}
			SetUserToken(_asyncReadEventArgs, null);
			_asyncReadPending = false;
			if (_closeState == CloseState.Closed)
			{
				DisposeReadEventArgs();
			}
		}
		return _asyncReadSize;
	}

	private void DisposeReadEventArgs()
	{
		if (_asyncReadEventArgs != null)
		{
			_asyncReadEventArgs.Completed -= s_onReceiveAsyncCompleted;
			_asyncReadEventArgs.Dispose();
		}
		TryReturnReadBuffer();
	}

	private void TryReturnReadBuffer()
	{
		if (_readBuffer != null && !_aborted)
		{
			_connectionBufferPool.Return(_readBuffer);
			_readBuffer = null;
		}
	}

	private void SetUserToken(SocketAsyncEventArgs args, object userToken)
	{
		if (args != null)
		{
			args.UserToken = userToken;
		}
	}

	private void SetImmediate(bool immediate)
	{
		if (immediate != _noDelay)
		{
			lock (ThisLock)
			{
				ThrowIfNotOpen();
				_socket.NoDelay = immediate;
			}
			_noDelay = immediate;
		}
	}

	private void SetReadTimeout(TimeSpan timeout, bool synchronous, bool closing)
	{
		if (synchronous)
		{
			CancelReceiveTimer();
			if (timeout <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TcpConnectionTimedOut, timeout)));
			}
			if (!ShouldUpdateTimeout(_socketSyncReceiveTimeout, timeout))
			{
				return;
			}
			lock (ThisLock)
			{
				if (!closing || _closeState != CloseState.Closing)
				{
					ThrowIfNotOpen();
				}
				_socket.ReceiveTimeout = TimeoutHelper.ToMilliseconds(timeout);
			}
			_socketSyncReceiveTimeout = timeout;
		}
		else
		{
			_asyncReceiveTimeout = timeout;
			if (timeout == TimeSpan.MaxValue)
			{
				CancelReceiveTimer();
			}
			else
			{
				ReceiveTimer.Set(timeout);
			}
		}
	}

	private void SetWriteTimeout(TimeSpan timeout, bool synchronous)
	{
		if (synchronous)
		{
			CancelSendTimer();
			if (timeout <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TcpConnectionTimedOut, timeout)));
			}
			if (ShouldUpdateTimeout(_socketSyncSendTimeout, timeout))
			{
				lock (ThisLock)
				{
					ThrowIfNotOpen();
					_socket.SendTimeout = TimeoutHelper.ToMilliseconds(timeout);
				}
				_socketSyncSendTimeout = timeout;
			}
		}
		else
		{
			_asyncSendTimeout = timeout;
			if (timeout == TimeSpan.MaxValue)
			{
				CancelSendTimer();
			}
			else
			{
				ReceiveTimer.Set(timeout);
			}
		}
	}

	private bool ShouldUpdateTimeout(TimeSpan oldTimeout, TimeSpan newTimeout)
	{
		if (oldTimeout == newTimeout)
		{
			return false;
		}
		long num = oldTimeout.Ticks / 10;
		long num2 = Math.Max(oldTimeout.Ticks, newTimeout.Ticks) - Math.Min(oldTimeout.Ticks, newTimeout.Ticks);
		return num2 > num;
	}

	private void EnsureReadEventArgs()
	{
		if (_asyncReadEventArgs == null)
		{
			if (s_onReceiveAsyncCompleted == null)
			{
				s_onReceiveAsyncCompleted = OnReceiveAsyncCompleted;
			}
			_asyncReadEventArgs = new SocketAsyncEventArgs();
			_asyncReadEventArgs.SetBuffer(_readBuffer, 0, _readBuffer.Length);
			_asyncReadEventArgs.Completed += s_onReceiveAsyncCompleted;
		}
	}

	private void EnsureWriteEventArgs()
	{
		if (_asyncWriteEventArgs == null)
		{
			if (s_onSocketSendCompleted == null)
			{
				s_onSocketSendCompleted = OnSendAsyncCompleted;
			}
			_asyncWriteEventArgs = new SocketAsyncEventArgs();
			_asyncWriteEventArgs.Completed += s_onSocketSendCompleted;
		}
	}
}
