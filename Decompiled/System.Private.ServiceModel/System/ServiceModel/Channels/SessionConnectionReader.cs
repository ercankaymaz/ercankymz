using System.Runtime;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class SessionConnectionReader : IMessageSource
{
	private bool _isAtEOF;

	private bool _usingAsyncReadBuffer;

	private IConnection _connection;

	private byte[] _buffer;

	private int _offset;

	private int _size;

	private int _envelopeSize;

	private bool _readIntoEnvelopeBuffer;

	private Message _pendingMessage;

	private Exception _pendingException;

	private SecurityMessageProperty _security;

	private IConnection _rawConnection;

	protected byte[] EnvelopeBuffer { get; set; }

	protected int EnvelopeOffset { get; set; }

	protected int EnvelopeSize
	{
		get
		{
			return _envelopeSize;
		}
		set
		{
			_envelopeSize = value;
		}
	}

	protected SessionConnectionReader(IConnection connection, IConnection rawConnection, int offset, int size, SecurityMessageProperty security)
	{
		_offset = offset;
		_size = size;
		if (size > 0)
		{
			_buffer = connection.AsyncReadBuffer;
		}
		_connection = connection;
		_rawConnection = rawConnection;
		_security = security;
	}

	private Message DecodeMessage(TimeSpan timeout)
	{
		if (!_readIntoEnvelopeBuffer)
		{
			return DecodeMessage(_buffer, ref _offset, ref _size, ref _isAtEOF, timeout);
		}
		int offset = EnvelopeOffset;
		return DecodeMessage(EnvelopeBuffer, ref offset, ref _size, ref _isAtEOF, timeout);
	}

	protected abstract Message DecodeMessage(byte[] buffer, ref int offset, ref int size, ref bool isAtEof, TimeSpan timeout);

	public IConnection GetRawConnection()
	{
		IConnection connection = null;
		if (_rawConnection != null)
		{
			connection = _rawConnection;
			_rawConnection = null;
			if (_size > 0)
			{
				if (connection is PreReadConnection preReadConnection)
				{
					preReadConnection.AddPreReadData(_buffer, _offset, _size);
				}
				else
				{
					connection = new PreReadConnection(connection, _buffer, _offset, _size);
				}
			}
		}
		return connection;
	}

	public async Task<Message> ReceiveAsync(TimeSpan timeout)
	{
		Message pendingMessage = GetPendingMessage();
		if (pendingMessage != null)
		{
			return pendingMessage;
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		while (true)
		{
			if (_isAtEOF)
			{
				return null;
			}
			if (_size > 0)
			{
				pendingMessage = DecodeMessage(timeoutHelper.RemainingTime());
				if (pendingMessage != null)
				{
					PrepareMessage(pendingMessage);
					return pendingMessage;
				}
				if (_isAtEOF)
				{
					return null;
				}
			}
			if (_size != 0)
			{
				break;
			}
			if (!_usingAsyncReadBuffer)
			{
				_buffer = _connection.AsyncReadBuffer;
				_usingAsyncReadBuffer = true;
			}
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			AsyncCompletionResult asyncCompletionResult = _connection.BeginRead(0, _buffer.Length, timeoutHelper.RemainingTime(), TaskHelpers.OnAsyncCompletionCallback, taskCompletionSource);
			if (asyncCompletionResult == AsyncCompletionResult.Completed)
			{
				taskCompletionSource.TrySetResult(result: true);
			}
			await taskCompletionSource.Task;
			int bytesRead = _connection.EndRead();
			HandleReadComplete(bytesRead, readIntoEnvelopeBuffer: false);
		}
		throw new Exception("Receive: DecodeMessage() should consume the outstanding buffer or return a message.");
	}

	public Message Receive(TimeSpan timeout)
	{
		Message pendingMessage = GetPendingMessage();
		if (pendingMessage != null)
		{
			return pendingMessage;
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		while (true)
		{
			if (_isAtEOF)
			{
				return null;
			}
			if (_size > 0)
			{
				pendingMessage = DecodeMessage(timeoutHelper.RemainingTime());
				if (pendingMessage != null)
				{
					PrepareMessage(pendingMessage);
					return pendingMessage;
				}
				if (_isAtEOF)
				{
					return null;
				}
			}
			if (_size != 0)
			{
				break;
			}
			if (_buffer == null)
			{
				_buffer = Fx.AllocateByteArray(_connection.AsyncReadBufferSize);
			}
			if (EnvelopeBuffer != null && EnvelopeSize - EnvelopeOffset >= _buffer.Length)
			{
				int bytesRead = _connection.Read(EnvelopeBuffer, EnvelopeOffset, _buffer.Length, timeoutHelper.RemainingTime());
				HandleReadComplete(bytesRead, readIntoEnvelopeBuffer: true);
			}
			else
			{
				int bytesRead = _connection.Read(_buffer, 0, _buffer.Length, timeoutHelper.RemainingTime());
				HandleReadComplete(bytesRead, readIntoEnvelopeBuffer: false);
			}
		}
		throw new Exception("Receive: DecodeMessage() should consume the outstanding buffer or return a message.");
	}

	public Message EndReceive()
	{
		return GetPendingMessage();
	}

	private Message GetPendingMessage()
	{
		if (_pendingException != null)
		{
			Exception pendingException = _pendingException;
			_pendingException = null;
			throw pendingException;
		}
		if (_pendingMessage != null)
		{
			Message pendingMessage = _pendingMessage;
			_pendingMessage = null;
			return pendingMessage;
		}
		return null;
	}

	public async Task<bool> WaitForMessageAsync(TimeSpan timeout)
	{
		try
		{
			_pendingMessage = await ReceiveAsync(timeout);
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

	protected abstract void EnsureDecoderAtEof();

	private void HandleReadComplete(int bytesRead, bool readIntoEnvelopeBuffer)
	{
		_readIntoEnvelopeBuffer = readIntoEnvelopeBuffer;
		if (bytesRead == 0)
		{
			EnsureDecoderAtEof();
			_isAtEOF = true;
		}
		else
		{
			_offset = 0;
			_size = bytesRead;
		}
	}

	protected virtual void PrepareMessage(Message message)
	{
		if (_security != null)
		{
			message.Properties.Security = (SecurityMessageProperty)_security.CreateCopy();
		}
	}
}
