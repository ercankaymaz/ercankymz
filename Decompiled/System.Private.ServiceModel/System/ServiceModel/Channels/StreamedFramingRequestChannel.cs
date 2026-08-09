using System.Runtime;
using System.Security.Authentication.ExtendedProtection;
using System.ServiceModel.Channels.ConnectionHelpers;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class StreamedFramingRequestChannel : RequestChannel
{
	internal class StreamedConnectionPoolHelper : ConnectionPoolHelper
	{
		private class ClientSingletonConnectionReader : SingletonConnectionReader
		{
			private StreamedConnectionPoolHelper _connectionPoolHelper;

			protected override long StreamPosition => _connectionPoolHelper.Decoder.StreamPosition;

			public ClientSingletonConnectionReader(IConnection connection, StreamedConnectionPoolHelper connectionPoolHelper, IConnectionOrientedTransportFactorySettings settings)
				: base(connection, 0, 0, connectionPoolHelper.RemoteSecurity, settings, null)
			{
				_connectionPoolHelper = connectionPoolHelper;
			}

			protected override bool DecodeBytes(byte[] buffer, ref int offset, ref int size, ref bool isAtEof)
			{
				while (size > 0)
				{
					int num = _connectionPoolHelper.Decoder.Decode(buffer, offset, size);
					if (num > 0)
					{
						offset += num;
						size -= num;
					}
					switch (_connectionPoolHelper.Decoder.CurrentState)
					{
					case ClientFramingDecoderState.EnvelopeStart:
						return true;
					case ClientFramingDecoderState.End:
						isAtEof = true;
						return false;
					}
				}
				return false;
			}

			protected override void OnClose(TimeSpan timeout)
			{
				_connectionPoolHelper.Close(timeout);
			}
		}

		internal class StreamedFramingAsyncRequest : IAsyncRequest, IRequestBase
		{
			private StreamedFramingRequestChannel _channel;

			private IConnection _connection;

			private StreamedConnectionPoolHelper _connectionPoolHelper;

			private Message _message;

			private TimeoutHelper _timeoutHelper;

			private ClientSingletonConnectionReader _connectionReader;

			public StreamedFramingAsyncRequest(StreamedFramingRequestChannel channel)
			{
				_channel = channel;
				_connectionPoolHelper = new StreamedConnectionPoolHelper(channel);
			}

			public async Task SendRequestAsync(Message message, TimeoutHelper timeoutHelper)
			{
				_timeoutHelper = timeoutHelper;
				_message = message;
				bool success = false;
				try
				{
					_ = 1;
					try
					{
						_connection = await _connectionPoolHelper.EstablishConnectionAsync(timeoutHelper.RemainingTime());
						ChannelBindingUtility.TryAddToMessage(_channel._channelBindingToken, _message, messagePropertyOwnsCleanup: false);
						await StreamingConnectionHelper.WriteMessageAsync(_message, _connection, isRequest: true, _channel._settings, timeoutHelper);
					}
					catch (TimeoutException innerException)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TimeoutOnRequest, timeoutHelper.RemainingTime()), innerException));
					}
					success = true;
				}
				finally
				{
					if (!success)
					{
						Cleanup();
					}
				}
			}

			public void Abort(RequestChannel requestChannel)
			{
				Cleanup();
			}

			public void Fault(RequestChannel requestChannel)
			{
				Cleanup();
			}

			private void Cleanup()
			{
				_connectionPoolHelper.Abort();
			}

			public void OnReleaseRequest()
			{
			}

			public async Task<Message> ReceiveReplyAsync(TimeoutHelper timeoutHelper)
			{
				try
				{
					_connectionReader = new ClientSingletonConnectionReader(_connection, _connectionPoolHelper, _channel._settings);
					_connectionReader.DoneSending(TimeSpan.Zero);
					return await _connectionReader.ReceiveAsync(timeoutHelper);
				}
				catch (OperationCanceledException)
				{
					if (_timeoutHelper.GetCancellationToken().IsCancellationRequested)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.RequestChannelWaitForReplyTimedOut, timeoutHelper.OriginalTimeout)));
					}
					throw;
				}
			}
		}

		private StreamedFramingRequestChannel _channel;

		private SecurityMessageProperty _remoteSecurity;

		public ClientSingletonDecoder Decoder { get; private set; }

		public SecurityMessageProperty RemoteSecurity => _remoteSecurity;

		public StreamedConnectionPoolHelper(StreamedFramingRequestChannel channel)
			: base(channel._connectionPool, channel._connectionInitiator, channel.Via)
		{
			_channel = channel;
		}

		protected override TimeoutException CreateNewConnectionTimeoutException(TimeSpan timeout, TimeoutException innerException)
		{
			return new TimeoutException(System.SR.Format(System.SR.RequestTimedOutEstablishingTransportSession, timeout, _channel.Via.AbsoluteUri), innerException);
		}

		protected override IConnection AcceptPooledConnection(IConnection connection, ref TimeoutHelper timeoutHelper)
		{
			Decoder = new ClientSingletonDecoder(0L);
			return _channel.SendPreamble(connection, ref timeoutHelper, Decoder, out _remoteSecurity);
		}

		protected override Task<IConnection> AcceptPooledConnectionAsync(IConnection connection, ref TimeoutHelper timeoutHelper)
		{
			Decoder = new ClientSingletonDecoder(0L);
			return _channel.SendPreambleAsync(connection, timeoutHelper, Decoder);
		}
	}

	internal IConnectionInitiator _connectionInitiator;

	internal ConnectionPool _connectionPool;

	private MessageEncoder _messageEncoder;

	private IConnectionOrientedTransportFactorySettings _settings;

	private StreamUpgradeProvider _upgrade;

	private ChannelBinding _channelBindingToken;

	private byte[] Preamble { get; set; }

	public StreamedFramingRequestChannel(ChannelManagerBase factory, IConnectionOrientedTransportChannelFactorySettings settings, EndpointAddress remoteAddress, Uri via, IConnectionInitiator connectionInitiator, ConnectionPool connectionPool)
		: base(factory, remoteAddress, via, settings.ManualAddressing)
	{
		_settings = settings;
		_connectionInitiator = connectionInitiator;
		_connectionPool = connectionPool;
		_messageEncoder = settings.MessageEncoderFactory.Encoder;
		_upgrade = settings.Upgrade;
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		return TaskHelpers.CompletedTask();
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnOpenAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override void OnOpen(TimeSpan timeout)
	{
	}

	protected override void OnOpened()
	{
		EncodedVia via = new EncodedVia(base.Via.AbsoluteUri);
		EncodedContentType contentType = EncodedContentType.Create(_settings.MessageEncoderFactory.Encoder.ContentType);
		int num = ClientSingletonEncoder.ModeBytes.Length + ClientSingletonEncoder.CalcStartSize(via, contentType);
		int num2 = 0;
		if (_upgrade == null)
		{
			num2 = num;
			num += SessionEncoder.PreambleEndBytes.Length;
		}
		Preamble = Fx.AllocateByteArray(num);
		Buffer.BlockCopy(ClientSingletonEncoder.ModeBytes, 0, Preamble, 0, ClientSingletonEncoder.ModeBytes.Length);
		ClientSingletonEncoder.EncodeStart(Preamble, ClientSingletonEncoder.ModeBytes.Length, via, contentType);
		if (num2 > 0)
		{
			Buffer.BlockCopy(ClientSingletonEncoder.PreambleEndBytes, 0, Preamble, num2, ClientSingletonEncoder.PreambleEndBytes.Length);
		}
		base.OnOpened();
	}

	protected override IAsyncRequest CreateAsyncRequest(Message message)
	{
		return new StreamedConnectionPoolHelper.StreamedFramingAsyncRequest(this);
	}

	internal IConnection SendPreamble(IConnection connection, ref TimeoutHelper timeoutHelper, ClientFramingDecoder decoder, out SecurityMessageProperty remoteSecurity)
	{
		connection.Write(Preamble, 0, Preamble.Length, immediate: true, timeoutHelper.RemainingTime());
		if (_upgrade != null)
		{
			IStreamUpgradeChannelBindingProvider property = _upgrade.GetProperty<IStreamUpgradeChannelBindingProvider>();
			StreamUpgradeInitiator upgradeInitiator = _upgrade.CreateUpgradeInitiator(base.RemoteAddress, base.Via);
			if (!ConnectionUpgradeHelper.InitiateUpgrade(upgradeInitiator, ref connection, decoder, this, ref timeoutHelper))
			{
				ConnectionUpgradeHelper.DecodeFramingFault(decoder, connection, base.Via, _messageEncoder.ContentType, ref timeoutHelper);
			}
			if (property != null && property.IsChannelBindingSupportEnabled)
			{
				_channelBindingToken = property.GetChannelBinding(upgradeInitiator, ChannelBindingKind.Endpoint);
			}
			remoteSecurity = StreamSecurityUpgradeInitiator.GetRemoteSecurity(upgradeInitiator);
			connection.Write(ClientSingletonEncoder.PreambleEndBytes, 0, ClientSingletonEncoder.PreambleEndBytes.Length, immediate: true, timeoutHelper.RemainingTime());
		}
		else
		{
			remoteSecurity = null;
		}
		byte[] array = new byte[1];
		int count = connection.Read(array, 0, array.Length, timeoutHelper.RemainingTime());
		if (!ConnectionUpgradeHelper.ValidatePreambleResponse(array, count, decoder, base.Via))
		{
			ConnectionUpgradeHelper.DecodeFramingFault(decoder, connection, base.Via, _messageEncoder.ContentType, ref timeoutHelper);
		}
		return connection;
	}

	internal async Task<IConnection> SendPreambleAsync(IConnection connection, TimeoutHelper timeoutHelper, ClientFramingDecoder decoder)
	{
		await connection.WriteAsync(Preamble, 0, Preamble.Length, immediate: true, timeoutHelper.RemainingTime());
		if (_upgrade != null)
		{
			StreamUpgradeInitiator upgradeInitiator = _upgrade.CreateUpgradeInitiator(base.RemoteAddress, base.Via);
			await upgradeInitiator.OpenAsync(timeoutHelper.RemainingTime());
			OutWrapper<IConnection> connectionWrapper = new OutWrapper<IConnection>
			{
				Value = connection
			};
			bool flag = await ConnectionUpgradeHelper.InitiateUpgradeAsync(upgradeInitiator, connectionWrapper, decoder, this, timeoutHelper.RemainingTime());
			connection = connectionWrapper.Value;
			if (!flag)
			{
				await ConnectionUpgradeHelper.DecodeFramingFaultAsync(decoder, connection, base.Via, _messageEncoder.ContentType, timeoutHelper.RemainingTime());
			}
			await upgradeInitiator.CloseAsync(timeoutHelper.RemainingTime());
			await connection.WriteAsync(ClientSingletonEncoder.PreambleEndBytes, 0, ClientSingletonEncoder.PreambleEndBytes.Length, immediate: true, timeoutHelper.RemainingTime());
		}
		byte[] ackBuffer = new byte[1];
		if (!ConnectionUpgradeHelper.ValidatePreambleResponse(ackBuffer, await connection.ReadAsync(ackBuffer, 0, ackBuffer.Length, timeoutHelper.RemainingTime()), decoder, base.Via))
		{
			await ConnectionUpgradeHelper.DecodeFramingFaultAsync(decoder, connection, base.Via, _messageEncoder.ContentType, timeoutHelper.RemainingTime());
		}
		return connection;
	}

	protected override void OnClose(TimeSpan timeout)
	{
		WaitForPendingRequests(timeout);
	}

	protected override void OnClosed()
	{
		base.OnClosed();
		ChannelBindingUtility.Dispose(ref _channelBindingToken);
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		return WaitForPendingRequestsAsync(timeout);
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}
}
