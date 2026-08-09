using System.IO;
using System.Net.WebSockets;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class WebSocketTransportDuplexSessionChannel : TransportDuplexSessionChannel
{
	protected class WebSocketMessageSource : IMessageSource
	{
		private static class AsyncReceiveState
		{
			internal const int Started = 0;

			internal const int Finished = 1;

			internal const int Cancelled = 2;
		}

		private MessageEncoder _encoder;

		private BufferManager _bufferManager;

		private EndpointAddress _localAddress;

		private Message _pendingMessage;

		private Exception _pendingException;

		private WebSocket _webSocket;

		private bool _closureReceived;

		private bool _useStreaming;

		private int _receiveBufferSize;

		private int _maxBufferSize;

		private long _maxReceivedMessageSize;

		private TaskCompletionSource<object> _streamWaitTask;

		private IDefaultCommunicationTimeouts _defaultTimeouts;

		private WebSocketCloseDetails _closeDetails;

		private TimeSpan _asyncReceiveTimeout;

		private TaskCompletionSource<object> _receiveTask;

		private int _asyncReceiveState;

		public WebSocketMessageSource(WebSocketTransportDuplexSessionChannel webSocketTransportDuplexSessionChannel, WebSocket webSocket, bool useStreaming, IDefaultCommunicationTimeouts defaultTimeouts)
		{
			Initialize(webSocketTransportDuplexSessionChannel, webSocket, useStreaming, defaultTimeouts);
			StartNextReceiveAsync();
		}

		private void Initialize(WebSocketTransportDuplexSessionChannel webSocketTransportDuplexSessionChannel, WebSocket webSocket, bool useStreaming, IDefaultCommunicationTimeouts defaultTimeouts)
		{
			_webSocket = webSocket;
			_encoder = webSocketTransportDuplexSessionChannel.MessageEncoder;
			_bufferManager = webSocketTransportDuplexSessionChannel.BufferManager;
			_localAddress = webSocketTransportDuplexSessionChannel.LocalAddress;
			_maxBufferSize = webSocketTransportDuplexSessionChannel.MaxBufferSize;
			_maxReceivedMessageSize = webSocketTransportDuplexSessionChannel.TransportFactorySettings.MaxReceivedMessageSize;
			_receiveBufferSize = Math.Min(WebSocketHelper.GetReceiveBufferSize(_maxReceivedMessageSize), _maxBufferSize);
			_useStreaming = useStreaming;
			_defaultTimeouts = defaultTimeouts;
			_closeDetails = webSocketTransportDuplexSessionChannel._webSocketCloseDetails;
			_asyncReceiveTimeout = _defaultTimeouts.ReceiveTimeout;
			_asyncReceiveState = 1;
		}

		private static void OnAsyncReceiveCancelled(object target)
		{
			WebSocketMessageSource webSocketMessageSource = (WebSocketMessageSource)target;
			webSocketMessageSource.AsyncReceiveCancelled();
		}

		private void AsyncReceiveCancelled()
		{
			if (Interlocked.CompareExchange(ref _asyncReceiveState, 2, 0) == 0)
			{
				_receiveTask.SetResult(null);
			}
		}

		public async Task<Message> ReceiveAsync(TimeSpan timeout)
		{
			bool flag = await _receiveTask.Task.AwaitWithTimeout(timeout);
			ThrowOnPendingException(ref _pendingException);
			if (!flag)
			{
				throw FxTrace.Exception.AsError(new TimeoutException(System.SR.Format(System.SR.WaitForMessageTimedOut, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
			}
			Message pendingMessage = GetPendingMessage();
			if (pendingMessage != null)
			{
				StartNextReceiveAsync();
			}
			return pendingMessage;
		}

		public Message Receive(TimeSpan timeout)
		{
			return ReceiveAsyncInternal(timeout).WaitForCompletionNoSpin();
		}

		private async Task<Message> ReceiveAsyncInternal(TimeSpan timeout)
		{
			await TaskHelpers.EnsureDefaultTaskScheduler();
			return await ReceiveAsync(timeout);
		}

		private async Task ReadBufferedMessageAsync()
		{
			byte[] internalBuffer = null;
			try
			{
				internalBuffer = _bufferManager.TakeBuffer(_receiveBufferSize);
				int receivedByteCount = 0;
				bool endOfMessage = false;
				WebSocketReceiveResult result = null;
				do
				{
					try
					{
						if (WcfEventSource.Instance.WebSocketAsyncReadStartIsEnabled())
						{
							WcfEventSource.Instance.WebSocketAsyncReadStart(_webSocket.GetHashCode());
						}
						result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(internalBuffer, receivedByteCount, internalBuffer.Length - receivedByteCount), CancellationToken.None);
						CheckCloseStatus(result);
						endOfMessage = result.EndOfMessage;
						receivedByteCount += result.Count;
						if (receivedByteCount >= internalBuffer.Length && !result.EndOfMessage)
						{
							if (internalBuffer.Length >= _maxBufferSize)
							{
								_pendingException = FxTrace.Exception.AsError(new QuotaExceededException(System.SR.Format(System.SR.MaxReceivedMessageSizeExceeded, _maxBufferSize)));
								return;
							}
							int bufferSize = (int)Math.Min((double)internalBuffer.Length * 2.0, _maxBufferSize);
							byte[] array = _bufferManager.TakeBuffer(bufferSize);
							Buffer.BlockCopy(internalBuffer, 0, array, 0, receivedByteCount);
							_bufferManager.ReturnBuffer(internalBuffer);
							internalBuffer = array;
						}
						if (WcfEventSource.Instance.WebSocketAsyncReadStopIsEnabled())
						{
							WcfEventSource.Instance.WebSocketAsyncReadStop(_webSocket.GetHashCode(), receivedByteCount, string.Empty);
						}
					}
					catch (AggregateException ex)
					{
						WebSocketHelper.ThrowCorrectException(ex, TimeSpan.MaxValue, "ReceiveOperation");
					}
				}
				while (!endOfMessage && !_closureReceived);
				byte[] array2 = null;
				bool flag = false;
				try
				{
					array2 = _bufferManager.TakeBuffer(receivedByteCount);
					Buffer.BlockCopy(internalBuffer, 0, array2, 0, receivedByteCount);
					_pendingMessage = PrepareMessage(result, array2, receivedByteCount);
					flag = true;
				}
				finally
				{
					if (array2 != null && (!flag || _pendingMessage == null))
					{
						_bufferManager.ReturnBuffer(array2);
					}
				}
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				_pendingException = WebSocketHelper.ConvertAndTraceException(ex2, TimeSpan.MaxValue, "ReceiveOperation");
			}
			finally
			{
				if (internalBuffer != null)
				{
					_bufferManager.ReturnBuffer(internalBuffer);
				}
			}
		}

		public bool WaitForMessage(TimeSpan timeout)
		{
			try
			{
				Message pendingMessage = Receive(timeout);
				_pendingMessage = pendingMessage;
				return true;
			}
			catch (TimeoutException ex)
			{
				if (WcfEventSource.Instance.ReceiveTimeoutIsEnabled())
				{
					WcfEventSource.Instance.ReceiveTimeout(ex.Message);
				}
				return false;
			}
		}

		public async Task<bool> WaitForMessageAsync(TimeSpan timeout)
		{
			if (await _receiveTask.Task.AwaitWithTimeout(timeout))
			{
				_pendingMessage = await ReceiveAsync(timeout);
				return true;
			}
			if (WcfEventSource.Instance.ReceiveTimeoutIsEnabled())
			{
				WcfEventSource.Instance.ReceiveTimeout(System.SR.Format(System.SR.WaitForMessageTimedOut, timeout));
			}
			return false;
		}

		internal void FinishUsingMessageStream(Exception ex)
		{
			if (ex != null && _pendingException == null)
			{
				_pendingException = ex;
			}
			_streamWaitTask.SetResult(null);
		}

		internal void CheckCloseStatus(WebSocketReceiveResult result)
		{
			if (result.MessageType == WebSocketMessageType.Close)
			{
				if (WcfEventSource.Instance.WebSocketCloseStatusReceivedIsEnabled())
				{
					WcfEventSource.Instance.WebSocketCloseStatusReceived(_webSocket.GetHashCode(), result.CloseStatus.ToString());
				}
				_closureReceived = true;
				_closeDetails.InputCloseStatus = result.CloseStatus;
				_closeDetails.InputCloseStatusDescription = result.CloseStatusDescription;
			}
		}

		private async void StartNextReceiveAsync()
		{
			_receiveTask = new TaskCompletionSource<object>();
			int num = Interlocked.CompareExchange(ref _asyncReceiveState, 0, 1);
			if (num != 1)
			{
				throw FxTrace.Exception.AsError(new InvalidOperationException());
			}
			try
			{
				if (_useStreaming)
				{
					if (_streamWaitTask != null)
					{
						await _streamWaitTask.Task;
					}
					_streamWaitTask = new TaskCompletionSource<object>();
				}
				if (_pendingException != null)
				{
					return;
				}
				if (!_useStreaming)
				{
					await ReadBufferedMessageAsync();
					return;
				}
				byte[] buffer = _bufferManager.TakeBuffer(_receiveBufferSize);
				bool success = false;
				try
				{
					if (WcfEventSource.Instance.WebSocketAsyncReadStartIsEnabled())
					{
						WcfEventSource.Instance.WebSocketAsyncReadStart(_webSocket.GetHashCode());
					}
					try
					{
						CancellationToken cancellationToken = await new TimeoutHelper(_asyncReceiveTimeout).GetCancellationTokenAsync();
						WebSocketReceiveResult webSocketReceiveResult = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer, 0, _receiveBufferSize), cancellationToken);
						CheckCloseStatus(webSocketReceiveResult);
						_pendingMessage = PrepareMessage(webSocketReceiveResult, buffer, webSocketReceiveResult.Count);
						if (WcfEventSource.Instance.WebSocketAsyncReadStopIsEnabled())
						{
							WcfEventSource.Instance.WebSocketAsyncReadStop(_webSocket.GetHashCode(), webSocketReceiveResult.Count, string.Empty);
						}
					}
					catch (AggregateException ex)
					{
						WebSocketHelper.ThrowCorrectException(ex, _asyncReceiveTimeout, "ReceiveOperation");
					}
					success = true;
				}
				catch (Exception ex2)
				{
					if (Fx.IsFatal(ex2))
					{
						throw;
					}
					_pendingException = WebSocketHelper.ConvertAndTraceException(ex2, _asyncReceiveTimeout, "ReceiveOperation");
				}
				finally
				{
					if (!success)
					{
						_bufferManager.ReturnBuffer(buffer);
					}
				}
			}
			finally
			{
				if (Interlocked.CompareExchange(ref _asyncReceiveState, 1, 0) == 0)
				{
					_receiveTask.SetResult(null);
				}
			}
		}

		private Message GetPendingMessage()
		{
			ThrowOnPendingException(ref _pendingException);
			if (_pendingMessage != null)
			{
				Message pendingMessage = _pendingMessage;
				_pendingMessage = null;
				return pendingMessage;
			}
			return null;
		}

		private Message PrepareMessage(WebSocketReceiveResult result, byte[] buffer, int count)
		{
			if (result.MessageType != WebSocketMessageType.Close)
			{
				Message message;
				if (_useStreaming)
				{
					MaxMessageSizeStream stream = new MaxMessageSizeStream(new TimeoutStream(new WebSocketStream(this, new ArraySegment<byte>(buffer, 0, count), _webSocket, result.EndOfMessage, _bufferManager, _defaultTimeouts.CloseTimeout), _defaultTimeouts.ReceiveTimeout), _maxReceivedMessageSize);
					message = _encoder.ReadMessage(stream, _maxBufferSize);
				}
				else
				{
					ArraySegment<byte> buffer2 = new ArraySegment<byte>(buffer, 0, count);
					message = _encoder.ReadMessage(buffer2, _bufferManager);
				}
				if (message.Version.Addressing != AddressingVersion.None || !_localAddress.IsAnonymous)
				{
					_localAddress.ApplyTo(message);
				}
				if (message.Version.Addressing == AddressingVersion.None && message.Headers.Action == null)
				{
					if (result.MessageType == WebSocketMessageType.Binary)
					{
						message.Headers.Action = "http://schemas.microsoft.com/2011/02/websockets/onbinarymessage";
					}
					else
					{
						message.Headers.Action = "http://schemas.microsoft.com/2011/02/websockets/ontextmessage";
					}
				}
				return message;
			}
			return null;
		}
	}

	private class WebSocketStream : Stream
	{
		private readonly WebSocket _webSocket;

		private readonly WebSocketMessageSource _messageSource;

		private readonly TimeSpan _closeTimeout;

		private ArraySegment<byte> _initialReadBuffer;

		private bool _endOfMessageReached;

		private readonly bool _isForRead;

		private bool _endofMessageReceived;

		private readonly WebSocketMessageType _outgoingMessageType;

		private readonly BufferManager _bufferManager;

		private int _messageSourceCleanState;

		private int _endOfMessageWritten;

		private int _readTimeout;

		private int _writeTimeout;

		private TimeoutHelper _readTimeoutHelper;

		private TimeoutHelper _writeTimeoutHelper;

		public override bool CanRead => _isForRead;

		public override bool CanSeek => false;

		public override bool CanTimeout => true;

		public override bool CanWrite => !_isForRead;

		public override long Length
		{
			get
			{
				throw FxTrace.Exception.AsError(new NotSupportedException(InternalSR.SeekNotSupported));
			}
		}

		public override long Position
		{
			get
			{
				throw FxTrace.Exception.AsError(new NotSupportedException(InternalSR.SeekNotSupported));
			}
			set
			{
				throw FxTrace.Exception.AsError(new NotSupportedException(InternalSR.SeekNotSupported));
			}
		}

		public override int ReadTimeout
		{
			get
			{
				return _readTimeout;
			}
			set
			{
				_readTimeout = value;
				_readTimeoutHelper = new TimeoutHelper(TimeoutHelper.FromMilliseconds(_readTimeout));
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
				_writeTimeout = value;
				_writeTimeoutHelper = new TimeoutHelper(TimeoutHelper.FromMilliseconds(_readTimeout));
			}
		}

		public WebSocketStream(WebSocketMessageSource messageSource, ArraySegment<byte> initialBuffer, WebSocket webSocket, bool endofMessageReceived, BufferManager bufferManager, TimeSpan closeTimeout)
			: this(webSocket, WebSocketMessageType.Binary, closeTimeout)
		{
			_messageSource = messageSource;
			_initialReadBuffer = initialBuffer;
			_isForRead = true;
			_endofMessageReceived = endofMessageReceived;
			_bufferManager = bufferManager;
			_messageSourceCleanState = 0;
			_endOfMessageWritten = 0;
		}

		public WebSocketStream(WebSocket webSocket, WebSocketMessageType outgoingMessageType, TimeSpan closeTimeout)
		{
			_webSocket = webSocket;
			_isForRead = false;
			_outgoingMessageType = outgoingMessageType;
			_messageSourceCleanState = 1;
			_closeTimeout = closeTimeout;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			Cleanup();
		}

		public override void Flush()
		{
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (_readTimeoutHelper.GetCancellationToken().IsCancellationRequested)
			{
				throw FxTrace.Exception.AsError(WebSocketHelper.GetTimeoutException(null, _readTimeoutHelper.OriginalTimeout, "ReceiveOperation"));
			}
			if (_endOfMessageReached)
			{
				return Task.FromResult(0);
			}
			if (_initialReadBuffer.Count != 0)
			{
				return Task.FromResult(GetBytesFromInitialReadBuffer(buffer, offset, count));
			}
			if (_endofMessageReceived)
			{
				_endOfMessageReached = true;
				Cleanup();
				return Task.FromResult(0);
			}
			return ReadAsyncCore(buffer, offset, count, cancellationToken);
		}

		private async Task<int> ReadAsyncCore(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (WcfEventSource.Instance.WebSocketAsyncReadStartIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncReadStart(_webSocket.GetHashCode());
			}
			WebSocketReceiveResult webSocketReceiveResult;
			try
			{
				webSocketReceiveResult = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer, offset, count), cancellationToken);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (cancellationToken.IsCancellationRequested)
				{
					throw Fx.Exception.AsError(new TimeoutException(InternalSR.TaskTimedOutError(new TimeSpan(ReadTimeout))));
				}
				throw WebSocketHelper.ConvertAndTraceException(ex, new TimeSpan(ReadTimeout), "ReceiveOperation");
			}
			if (webSocketReceiveResult.EndOfMessage)
			{
				_endofMessageReceived = true;
				_endOfMessageReached = true;
			}
			int count2 = webSocketReceiveResult.Count;
			CheckResultAndEnsureNotCloseMessage(_messageSource, webSocketReceiveResult);
			if (WcfEventSource.Instance.WebSocketAsyncReadStopIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncReadStop(_webSocket.GetHashCode(), count2, string.Empty);
			}
			if (_endOfMessageReached)
			{
				Cleanup();
			}
			return count2;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw FxTrace.Exception.AsError(new NotSupportedException("this method should never get called"));
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw FxTrace.Exception.AsError(new NotSupportedException());
		}

		public override void SetLength(long value)
		{
			throw FxTrace.Exception.AsError(new NotSupportedException());
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw FxTrace.Exception.AsError(new NotSupportedException("this method should never get called"));
		}

		public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (_endOfMessageWritten == 1)
			{
				throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.WebSocketStreamWriteCalledAfterEOMSent));
			}
			if (WcfEventSource.Instance.WebSocketAsyncWriteStartIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStart(_webSocket.GetHashCode(), count, string.Empty);
			}
			try
			{
				await _webSocket.SendAsync(new ArraySegment<byte>(buffer, offset, count), _outgoingMessageType, endOfMessage: false, cancellationToken);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (cancellationToken.IsCancellationRequested)
				{
					throw Fx.Exception.AsError(new TimeoutException(InternalSR.TaskTimedOutError(new TimeSpan(WriteTimeout))));
				}
				throw WebSocketHelper.ConvertAndTraceException(ex, new TimeSpan(WriteTimeout), "SendOperation");
			}
			if (WcfEventSource.Instance.WebSocketAsyncWriteStopIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStop(_webSocket.GetHashCode());
			}
		}

		private async Task WriteAsyncInternal(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			await TaskHelpers.EnsureDefaultTaskScheduler();
			await WriteAsync(buffer, offset, count, cancellationToken);
		}

		public void WriteEndOfMessage()
		{
			if (WcfEventSource.Instance.WebSocketAsyncWriteStartIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStart(_webSocket.GetHashCode(), 0, string.Empty);
			}
			TimeoutHelper timeoutHelper = new TimeoutHelper(_closeTimeout);
			if (Interlocked.CompareExchange(ref _endOfMessageWritten, 1, 0) == 0)
			{
				Task task = _webSocket.SendAsync(new ArraySegment<byte>(Array.Empty<byte>(), 0, 0), _outgoingMessageType, endOfMessage: true, timeoutHelper.GetCancellationToken());
				task.Wait(timeoutHelper.RemainingTime(), WebSocketHelper.ThrowCorrectException, "SendOperation");
			}
			if (WcfEventSource.Instance.WebSocketAsyncWriteStopIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStop(_webSocket.GetHashCode());
			}
		}

		public async void WriteEndOfMessageAsync(Action<object> callback, object state)
		{
			if (WcfEventSource.Instance.WebSocketAsyncWriteStartIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStart(_webSocket.GetHashCode(), 0, string.Empty);
			}
			TimeoutHelper timeoutHelper = new TimeoutHelper(_closeTimeout);
			Task<CancellationToken> cancelTokenTask = timeoutHelper.GetCancellationTokenAsync();
			try
			{
				CancellationToken cancellationToken = await cancelTokenTask;
				await _webSocket.SendAsync(new ArraySegment<byte>(Array.Empty<byte>(), 0, 0), _outgoingMessageType, endOfMessage: true, cancellationToken);
				if (WcfEventSource.Instance.WebSocketAsyncWriteStopIsEnabled())
				{
					WcfEventSource.Instance.WebSocketAsyncWriteStop(_webSocket.GetHashCode());
				}
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (cancelTokenTask.Result.IsCancellationRequested)
				{
					throw Fx.Exception.AsError(new TimeoutException(InternalSR.TaskTimedOutError(timeoutHelper.OriginalTimeout)));
				}
				throw WebSocketHelper.ConvertAndTraceException(ex, timeoutHelper.OriginalTimeout, "SendOperation");
			}
			finally
			{
				callback(state);
			}
		}

		private static void CheckResultAndEnsureNotCloseMessage(WebSocketMessageSource messageSource, WebSocketReceiveResult result)
		{
			messageSource.CheckCloseStatus(result);
			if (result.MessageType == WebSocketMessageType.Close)
			{
				throw FxTrace.Exception.AsError(new ProtocolException(System.SR.WebSocketUnexpectedCloseMessageError));
			}
		}

		private int GetBytesFromInitialReadBuffer(byte[] buffer, int offset, int count)
		{
			int num = ((_initialReadBuffer.Count > count) ? count : _initialReadBuffer.Count);
			Buffer.BlockCopy(_initialReadBuffer.Array, _initialReadBuffer.Offset, buffer, offset, num);
			_initialReadBuffer = new ArraySegment<byte>(_initialReadBuffer.Array, _initialReadBuffer.Offset + num, _initialReadBuffer.Count - num);
			return num;
		}

		private void Cleanup()
		{
			if (_isForRead)
			{
				if (Interlocked.CompareExchange(ref _messageSourceCleanState, 1, 0) != 0)
				{
					return;
				}
				Exception ex = null;
				try
				{
					if (!_endofMessageReceived && (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.CloseSent))
					{
						TimeoutHelper timeoutHelper = new TimeoutHelper(_closeTimeout);
						do
						{
							CancellationToken cancellationToken = timeoutHelper.GetCancellationToken();
							Task<WebSocketReceiveResult> task = _webSocket.ReceiveAsync(new ArraySegment<byte>(_initialReadBuffer.Array), cancellationToken);
							task.Wait(timeoutHelper.RemainingTime(), WebSocketHelper.ThrowCorrectException, "ReceiveOperation");
							_endofMessageReceived = task.GetAwaiter().GetResult().EndOfMessage;
						}
						while (!_endofMessageReceived && (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.CloseSent));
					}
				}
				catch (Exception ex2)
				{
					if (Fx.IsFatal(ex2))
					{
						throw;
					}
					ex = WebSocketHelper.ConvertAndTraceException(ex2, _closeTimeout, "CloseOperation");
				}
				_bufferManager.ReturnBuffer(_initialReadBuffer.Array);
				_messageSource.FinishUsingMessageStream(ex);
			}
			else if (Interlocked.CompareExchange(ref _endOfMessageWritten, 1, 0) == 0)
			{
				WriteEndOfMessage();
			}
		}
	}

	private class WebSocketCloseDetails
	{
		private string _outputCloseStatusDescription;

		public WebSocketCloseStatus? InputCloseStatus { get; internal set; }

		public string InputCloseStatusDescription { get; internal set; }

		internal WebSocketCloseStatus OutputCloseStatus { get; private set; } = WebSocketCloseStatus.NormalClosure;

		internal string OutputCloseStatusDescription => _outputCloseStatusDescription;

		public void SetOutputCloseStatus(WebSocketCloseStatus closeStatus, string closeStatusDescription)
		{
			OutputCloseStatus = closeStatus;
			_outputCloseStatusDescription = closeStatusDescription;
		}
	}

	private static readonly AsyncCallback s_streamedWriteCallback = Fx.ThunkCallback(StreamWriteCallback);

	private readonly WebSocketCloseDetails _webSocketCloseDetails = new WebSocketCloseDetails();

	private Action<object> _waitCallback;

	private WebSocket _webSocket;

	private WebSocketStream _webSocketStream;

	private object _state;

	private int _cleanupStatus;

	private bool _shouldDisposeWebSocketAfterClosed = true;

	private Exception _pendingWritingMessageException;

	protected WebSocket WebSocket
	{
		get
		{
			return _webSocket;
		}
		set
		{
			_webSocket = value;
		}
	}

	protected WebSocketTransportSettings WebSocketSettings { get; }

	protected TransferMode TransferMode { get; }

	protected int MaxBufferSize { get; }

	protected ITransportFactorySettings TransportFactorySettings { get; }

	public WebSocketTransportDuplexSessionChannel(HttpChannelFactory<IDuplexSessionChannel> channelFactory, EndpointAddress remoteAddress, Uri via)
		: base(channelFactory, channelFactory, EndpointAddress.AnonymousAddress, channelFactory.MessageVersion.Addressing.AnonymousUri, remoteAddress, via)
	{
		WebSocketSettings = channelFactory.WebSocketSettings;
		TransferMode = channelFactory.TransferMode;
		MaxBufferSize = channelFactory.MaxBufferSize;
		TransportFactorySettings = channelFactory;
	}

	protected override void OnAbort()
	{
		if (WcfEventSource.Instance.WebSocketConnectionAbortedIsEnabled())
		{
			WcfEventSource.Instance.WebSocketConnectionAborted(base.EventTraceActivity, (WebSocket != null) ? WebSocket.GetHashCode() : (-1));
		}
		Cleanup();
	}

	protected override void CompleteClose(TimeSpan timeout)
	{
		if (WcfEventSource.Instance.WebSocketCloseSentIsEnabled())
		{
			WcfEventSource.Instance.WebSocketCloseSent(WebSocket.GetHashCode(), _webSocketCloseDetails.OutputCloseStatus.ToString(), (RemoteAddress != null) ? RemoteAddress.ToString() : string.Empty);
		}
		Task task = CloseAsync();
		task.Wait(timeout, WebSocketHelper.ThrowCorrectException, "CloseOperation");
		if (WcfEventSource.Instance.WebSocketConnectionClosedIsEnabled())
		{
			WcfEventSource.Instance.WebSocketConnectionClosed(WebSocket.GetHashCode());
		}
	}

	protected override void CloseOutputSessionCore(TimeSpan timeout)
	{
		if (WcfEventSource.Instance.WebSocketCloseOutputSentIsEnabled())
		{
			WcfEventSource.Instance.WebSocketCloseOutputSent(WebSocket.GetHashCode(), _webSocketCloseDetails.OutputCloseStatus.ToString(), (RemoteAddress != null) ? RemoteAddress.ToString() : string.Empty);
		}
		Task task = CloseOutputAsync(CancellationToken.None);
		task.Wait(timeout, WebSocketHelper.ThrowCorrectException, "CloseOperation");
	}

	protected override async Task CloseOutputSessionCoreAsync(TimeSpan timeout)
	{
		if (WcfEventSource.Instance.WebSocketCloseOutputSentIsEnabled())
		{
			WcfEventSource.Instance.WebSocketCloseOutputSent(WebSocket.GetHashCode(), _webSocketCloseDetails.OutputCloseStatus.ToString(), (RemoteAddress != null) ? RemoteAddress.ToString() : string.Empty);
		}
		CancellationToken cancelToken = await new TimeoutHelper(timeout).GetCancellationTokenAsync();
		try
		{
			await CloseOutputAsync(cancelToken);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (cancelToken.IsCancellationRequested)
			{
				throw Fx.Exception.AsError(new TimeoutException(InternalSR.TaskTimedOutError(timeout)));
			}
			throw WebSocketHelper.ConvertAndTraceException(ex, timeout, "ReceiveOperation");
		}
	}

	protected override void OnClose(TimeSpan timeout)
	{
		try
		{
			base.OnClose(timeout);
		}
		finally
		{
			Cleanup();
		}
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		try
		{
			await base.OnCloseAsync(timeout);
		}
		finally
		{
			Cleanup();
		}
	}

	protected override void ReturnConnectionIfNecessary(bool abort, TimeSpan timeout)
	{
	}

	protected override AsyncCompletionResult StartWritingBufferedMessage(Message message, ArraySegment<byte> messageData, bool allowOutputBatching, TimeSpan timeout, Action<object> callback, object state)
	{
		ConnectionUtilities.ValidateBufferBounds(messageData);
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		WebSocketMessageType webSocketMessageType = GetWebSocketMessageType(message);
		if (WcfEventSource.Instance.WebSocketAsyncWriteStartIsEnabled())
		{
			WcfEventSource.Instance.WebSocketAsyncWriteStart(WebSocket.GetHashCode(), messageData.Count, (RemoteAddress != null) ? RemoteAddress.ToString() : string.Empty);
		}
		Task task = WebSocket.SendAsync(messageData, webSocketMessageType, endOfMessage: true, timeoutHelper.GetCancellationToken());
		if (task.IsCompleted)
		{
			if (WcfEventSource.Instance.WebSocketAsyncWriteStopIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStop(WebSocket.GetHashCode());
			}
			_pendingWritingMessageException = WebSocketHelper.CreateExceptionOnTaskFailure(task, timeout, "SendOperation");
			return AsyncCompletionResult.Completed;
		}
		HandleSendAsyncCompletion(task, timeout, callback, state);
		return AsyncCompletionResult.Queued;
	}

	protected override void FinishWritingMessage()
	{
		ThrowOnPendingException(ref _pendingWritingMessageException);
		base.FinishWritingMessage();
	}

	protected override AsyncCompletionResult StartWritingStreamedMessage(Message message, TimeSpan timeout, Action<object> callback, object state)
	{
		WebSocketMessageType webSocketMessageType = GetWebSocketMessageType(message);
		WebSocketStream webSocketStream = new WebSocketStream(WebSocket, webSocketMessageType, ((IDefaultCommunicationTimeouts)this).CloseTimeout);
		_waitCallback = callback;
		_state = state;
		_webSocketStream = webSocketStream;
		IAsyncResult asyncResult = base.MessageEncoder.BeginWriteMessage(message, new TimeoutStream(webSocketStream, timeout), s_streamedWriteCallback, this);
		if (!asyncResult.CompletedSynchronously)
		{
			return AsyncCompletionResult.Queued;
		}
		base.MessageEncoder.EndWriteMessage(asyncResult);
		webSocketStream.WriteEndOfMessageAsync(callback, state);
		return AsyncCompletionResult.Queued;
	}

	protected override AsyncCompletionResult BeginCloseOutput(TimeSpan timeout, Action<object> callback, object state)
	{
		Task task = CloseOutputAsync(new TimeoutHelper(timeout).GetCancellationToken());
		if (task.IsCompleted)
		{
			_pendingWritingMessageException = WebSocketHelper.CreateExceptionOnTaskFailure(task, timeout, "CloseOperation");
			return AsyncCompletionResult.Completed;
		}
		HandleCloseOutputAsyncCompletion(task, timeout, callback, state);
		return AsyncCompletionResult.Queued;
	}

	protected override void OnSendCore(Message message, TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		WebSocketMessageType webSocketMessageType = GetWebSocketMessageType(message);
		if (IsStreamedOutput)
		{
			WebSocketStream webSocketStream = new WebSocketStream(WebSocket, webSocketMessageType, ((IDefaultCommunicationTimeouts)this).CloseTimeout);
			TimeoutStream stream = new TimeoutStream(webSocketStream, timeout);
			base.MessageEncoder.WriteMessage(message, stream);
			webSocketStream.WriteEndOfMessage();
			return;
		}
		ArraySegment<byte> buffer = EncodeMessage(message);
		bool flag = false;
		try
		{
			if (WcfEventSource.Instance.WebSocketAsyncWriteStartIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStart(WebSocket.GetHashCode(), buffer.Count, (RemoteAddress != null) ? RemoteAddress.ToString() : string.Empty);
			}
			Task task = WebSocket.SendAsync(buffer, webSocketMessageType, endOfMessage: true, timeoutHelper.GetCancellationToken());
			task.Wait(timeoutHelper.RemainingTime(), WebSocketHelper.ThrowCorrectException, "SendOperation");
			if (WcfEventSource.Instance.WebSocketAsyncWriteStopIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStop(_webSocket.GetHashCode());
			}
			flag = true;
		}
		finally
		{
			try
			{
				base.BufferManager.ReturnBuffer(buffer.Array);
			}
			catch (Exception exception)
			{
				if (Fx.IsFatal(exception) || flag)
				{
					throw;
				}
				FxTrace.Exception.TraceUnhandledException(exception);
			}
		}
	}

	protected override ArraySegment<byte> EncodeMessage(Message message)
	{
		return base.MessageEncoder.WriteMessage(message, int.MaxValue, base.BufferManager, 0);
	}

	protected void Cleanup()
	{
		if (Interlocked.CompareExchange(ref _cleanupStatus, 1, 0) == 0)
		{
			OnCleanup();
		}
	}

	protected virtual void OnCleanup()
	{
		if (_shouldDisposeWebSocketAfterClosed && _webSocket != null)
		{
			_webSocket.Dispose();
		}
	}

	private static void ThrowOnPendingException(ref Exception pendingException)
	{
		Exception ex = pendingException;
		if (ex != null)
		{
			pendingException = null;
			throw FxTrace.Exception.AsError(ex);
		}
	}

	private Task CloseAsync()
	{
		try
		{
			if (WebSocket.State == WebSocketState.Closed)
			{
				return Task.CompletedTask;
			}
			return WebSocket.CloseAsync(_webSocketCloseDetails.OutputCloseStatus, _webSocketCloseDetails.OutputCloseStatusDescription, CancellationToken.None);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw WebSocketHelper.ConvertAndTraceException(ex);
		}
	}

	private Task CloseOutputAsync(CancellationToken cancellationToken)
	{
		try
		{
			return WebSocket.CloseOutputAsync(_webSocketCloseDetails.OutputCloseStatus, _webSocketCloseDetails.OutputCloseStatusDescription, cancellationToken);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw WebSocketHelper.ConvertAndTraceException(ex);
		}
	}

	private static WebSocketMessageType GetWebSocketMessageType(Message message)
	{
		return WebSocketMessageType.Binary;
	}

	private async void HandleCloseOutputAsyncCompletion(Task task, TimeSpan timeout, Action<object> callback, object state)
	{
		try
		{
			await task;
		}
		catch (Exception)
		{
			_pendingWritingMessageException = WebSocketHelper.CreateExceptionOnTaskFailure(task, timeout, "CloseOperation");
		}
		finally
		{
			callback(state);
		}
	}

	private async void HandleSendAsyncCompletion(Task task, TimeSpan timeout, Action<object> callback, object state)
	{
		try
		{
			await task;
		}
		catch (Exception)
		{
			_pendingWritingMessageException = WebSocketHelper.CreateExceptionOnTaskFailure(task, timeout, "SendOperation");
		}
		finally
		{
			if (WcfEventSource.Instance.WebSocketAsyncWriteStopIsEnabled())
			{
				WcfEventSource.Instance.WebSocketAsyncWriteStop(WebSocket.GetHashCode());
			}
			callback(state);
		}
	}

	private static void StreamWriteCallback(IAsyncResult ar)
	{
		if (ar.CompletedSynchronously)
		{
			return;
		}
		WebSocketTransportDuplexSessionChannel webSocketTransportDuplexSessionChannel = (WebSocketTransportDuplexSessionChannel)ar.AsyncState;
		try
		{
			webSocketTransportDuplexSessionChannel.MessageEncoder.EndWriteMessage(ar);
			webSocketTransportDuplexSessionChannel._webSocketStream.WriteEndOfMessage();
			webSocketTransportDuplexSessionChannel._waitCallback(webSocketTransportDuplexSessionChannel._state);
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
	}
}
