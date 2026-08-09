using System.IO;
using System.Runtime;
using System.ServiceModel.Channels.ConnectionHelpers;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class SingletonConnectionReader
{
	private class SingletonInputConnectionStream : ConnectionStream
	{
		private SingletonMessageDecoder _decoder;

		private SingletonConnectionReader _reader;

		private bool _atEof;

		private byte[] _chunkBuffer;

		private int _chunkBufferOffset;

		private int _chunkBufferSize;

		private int _chunkBytesRemaining;

		public SingletonInputConnectionStream(SingletonConnectionReader reader, IConnection connection, IDefaultCommunicationTimeouts defaultTimeouts)
			: base(connection, defaultTimeouts)
		{
			_reader = reader;
			_decoder = new SingletonMessageDecoder(reader.StreamPosition);
			_chunkBytesRemaining = 0;
			_chunkBuffer = new byte[5];
		}

		private void AbortReader()
		{
			_reader.Abort();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_reader.DoneReceiving(_atEof);
			}
		}

		private void DecodeData(byte[] buffer, int offset, int size)
		{
			while (size > 0)
			{
				int num = _decoder.Decode(buffer, offset, size);
				offset += num;
				size -= num;
			}
		}

		private void DecodeSize(byte[] buffer, ref int offset, ref int size)
		{
			while (size > 0)
			{
				int num = _decoder.Decode(buffer, offset, size);
				if (num > 0)
				{
					offset += num;
					size -= num;
				}
				switch (_decoder.CurrentState)
				{
				case SingletonMessageDecoder.State.ChunkStart:
					_chunkBytesRemaining = _decoder.ChunkSize;
					if (size > 0 && buffer != _chunkBuffer)
					{
						Buffer.BlockCopy(buffer, offset, _chunkBuffer, 0, size);
						_chunkBufferOffset = 0;
						_chunkBufferSize = size;
					}
					return;
				case SingletonMessageDecoder.State.End:
					ProcessEof();
					return;
				}
			}
		}

		private int ReadCore(byte[] buffer, int offset, int count)
		{
			int num = -1;
			try
			{
				num = base.Read(buffer, offset, count);
				if (num == 0)
				{
					ProcessEof();
				}
			}
			finally
			{
				if (num == -1)
				{
					AbortReader();
				}
			}
			return num;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = 0;
			while (true)
			{
				if (count == 0)
				{
					return num;
				}
				if (_atEof)
				{
					return num;
				}
				if (_chunkBufferSize > 0)
				{
					int num2 = Math.Min(_chunkBytesRemaining, Math.Min(_chunkBufferSize, count));
					Buffer.BlockCopy(_chunkBuffer, _chunkBufferOffset, buffer, offset, num2);
					DecodeData(_chunkBuffer, _chunkBufferOffset, num2);
					_chunkBufferOffset += num2;
					_chunkBufferSize -= num2;
					_chunkBytesRemaining -= num2;
					if (_chunkBytesRemaining == 0 && _chunkBufferSize > 0)
					{
						DecodeSize(_chunkBuffer, ref _chunkBufferOffset, ref _chunkBufferSize);
					}
					num += num2;
					offset += num2;
					count -= num2;
				}
				else
				{
					if (_chunkBytesRemaining > 0)
					{
						break;
					}
					if (count < 5)
					{
						_chunkBufferOffset = 0;
						_chunkBufferSize = ReadCore(_chunkBuffer, 0, _chunkBuffer.Length);
						DecodeSize(_chunkBuffer, ref _chunkBufferOffset, ref _chunkBufferSize);
					}
					else
					{
						int size = ReadCore(buffer, offset, 5);
						int offset2 = offset;
						DecodeSize(buffer, ref offset2, ref size);
					}
				}
			}
			int count2 = count;
			if (int.MaxValue - _chunkBytesRemaining >= 5)
			{
				count2 = Math.Min(count, _chunkBytesRemaining + 5);
			}
			int num3 = ReadCore(buffer, offset, count2);
			DecodeData(buffer, offset, Math.Min(num3, _chunkBytesRemaining));
			if (num3 > _chunkBytesRemaining)
			{
				num += _chunkBytesRemaining;
				int size2 = num3 - _chunkBytesRemaining;
				int offset3 = offset + _chunkBytesRemaining;
				_chunkBytesRemaining = 0;
				DecodeSize(buffer, ref offset3, ref size2);
			}
			else
			{
				num += num3;
				_chunkBytesRemaining -= num3;
			}
			return num;
		}

		private void ProcessEof()
		{
			if (!_atEof)
			{
				_atEof = true;
				if (_chunkBufferSize > 0 || _chunkBytesRemaining > 0 || _decoder.CurrentState != SingletonMessageDecoder.State.End)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_decoder.CreatePrematureEOFException());
				}
				_reader.DoneReceiving(atEof: true);
			}
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return base.ReadAsync(buffer, offset, count, cancellationToken);
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return base.WriteAsync(buffer, offset, count, cancellationToken);
		}
	}

	private bool _doneReceiving;

	private bool _doneSending;

	private bool _isAtEof;

	private bool _isClosed;

	private SecurityMessageProperty _security;

	private int _offset;

	private int _size;

	private IConnectionOrientedTransportFactorySettings _transportSettings;

	private Uri _via;

	private Stream _inputStream;

	protected IConnection Connection { get; }

	protected object ThisLock { get; } = new object();

	protected virtual string ContentType => null;

	protected abstract long StreamPosition { get; }

	protected SingletonConnectionReader(IConnection connection, int offset, int size, SecurityMessageProperty security, IConnectionOrientedTransportFactorySettings transportSettings, Uri via)
	{
		Connection = connection;
		_offset = offset;
		_size = size;
		_security = security;
		_transportSettings = transportSettings;
		_via = via;
	}

	public void Abort()
	{
		Connection.Abort();
	}

	public void DoneReceiving(bool atEof)
	{
		DoneReceiving(atEof, _transportSettings.CloseTimeout);
	}

	private void DoneReceiving(bool atEof, TimeSpan timeout)
	{
		if (!_doneReceiving)
		{
			_isAtEof = atEof;
			_doneReceiving = true;
			if (_doneSending)
			{
				Close(timeout);
			}
		}
	}

	public void Close(TimeSpan timeout)
	{
		lock (ThisLock)
		{
			if (_isClosed)
			{
				return;
			}
			_isClosed = true;
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		bool flag = false;
		try
		{
			if (_inputStream != null)
			{
				byte[] array = Fx.AllocateByteArray(_transportSettings.ConnectionBufferSize);
				while (!_isAtEof)
				{
					_inputStream.ReadTimeout = TimeoutHelper.ToMilliseconds(timeoutHelper.RemainingTime());
					if (_inputStream.Read(array, 0, array.Length) == 0)
					{
						_isAtEof = true;
					}
				}
			}
			OnClose(timeoutHelper.RemainingTime());
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				Abort();
			}
		}
	}

	protected abstract void OnClose(TimeSpan timeout);

	public void DoneSending(TimeSpan timeout)
	{
		_doneSending = true;
		if (_doneReceiving)
		{
			Close(timeout);
		}
	}

	protected abstract bool DecodeBytes(byte[] buffer, ref int offset, ref int size, ref bool isAtEof);

	protected virtual void PrepareMessage(Message message)
	{
		message.Properties.Via = _via;
		message.Properties.Security = ((_security != null) ? ((SecurityMessageProperty)_security.CreateCopy()) : null);
	}

	public async Task<Message> ReceiveAsync(TimeoutHelper timeoutHelper)
	{
		byte[] buffer = Fx.AllocateByteArray(Connection.AsyncReadBufferSize);
		if (_size > 0)
		{
			Buffer.BlockCopy(Connection.AsyncReadBuffer, _offset, buffer, _offset, _size);
		}
		while (!DecodeBytes(buffer, ref _offset, ref _size, ref _isAtEof))
		{
			if (_isAtEof)
			{
				DoneReceiving(atEof: true, timeoutHelper.RemainingTime());
				return null;
			}
			if (_size == 0)
			{
				_offset = 0;
				_size = await Connection.ReadAsync(buffer, 0, buffer.Length, timeoutHelper.RemainingTime());
				if (_size == 0)
				{
					DoneReceiving(atEof: true, timeoutHelper.RemainingTime());
					return null;
				}
			}
		}
		IConnection connection = Connection;
		if (_size > 0)
		{
			byte[] array = Fx.AllocateByteArray(_size);
			Buffer.BlockCopy(buffer, _offset, array, 0, _size);
			connection = new PreReadConnection(connection, array);
		}
		Stream stream = new SingletonInputConnectionStream(this, connection, _transportSettings);
		_inputStream = new MaxMessageSizeStream(stream, _transportSettings.MaxReceivedMessageSize);
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity(suspendCurrent: true) : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityProcessingMessage, TraceUtility.RetrieveMessageNumber()), ActivityType.ProcessMessage);
		}
		Message message;
		try
		{
			message = await _transportSettings.MessageEncoderFactory.Encoder.ReadMessageAsync(_inputStream, _transportSettings.MaxBufferSize, ContentType);
		}
		catch (XmlException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.MessageXmlProtocolError), innerException));
		}
		if (DiagnosticUtility.ShouldUseActivity)
		{
			TraceUtility.TransferFromTransport(message);
		}
		PrepareMessage(message);
		return message;
	}
}
