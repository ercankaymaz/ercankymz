using System.Runtime;
using System.ServiceModel.Channels.ConnectionHelpers;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class ClientFramingDuplexSessionChannel : FramingDuplexSessionChannel
{
	internal class DuplexConnectionPoolHelper : ConnectionPoolHelper
	{
		private ClientFramingDuplexSessionChannel _channel;

		private ArraySegment<byte> _preamble;

		public DuplexConnectionPoolHelper(ClientFramingDuplexSessionChannel channel, ConnectionPool connectionPool, IConnectionInitiator connectionInitiator)
			: base(connectionPool, connectionInitiator, channel.Via)
		{
			_channel = channel;
			_preamble = channel.CreatePreamble();
		}

		protected override TimeoutException CreateNewConnectionTimeoutException(TimeSpan timeout, TimeoutException innerException)
		{
			return new TimeoutException(System.SR.Format(System.SR.OpenTimedOutEstablishingTransportSession, timeout, _channel.Via.AbsoluteUri), innerException);
		}

		protected override IConnection AcceptPooledConnection(IConnection connection, ref TimeoutHelper timeoutHelper)
		{
			return _channel.SendPreamble(connection, _preamble, ref timeoutHelper);
		}

		protected override Task<IConnection> AcceptPooledConnectionAsync(IConnection connection, ref TimeoutHelper timeoutHelper)
		{
			return _channel.SendPreambleAsync(connection, _preamble, timeoutHelper.RemainingTime());
		}
	}

	private IConnectionOrientedTransportChannelFactorySettings _settings;

	private ClientDuplexDecoder _decoder;

	private StreamUpgradeProvider _upgrade;

	private ConnectionPoolHelper _connectionPoolHelper;

	private bool _flowIdentity;

	public ClientFramingDuplexSessionChannel(ChannelManagerBase factory, IConnectionOrientedTransportChannelFactorySettings settings, EndpointAddress remoteAddress, Uri via, IConnectionInitiator connectionInitiator, ConnectionPool connectionPool, bool exposeConnectionProperty, bool flowIdentity)
		: base(factory, settings, remoteAddress, via, exposeConnectionProperty)
	{
		_settings = settings;
		base.MessageEncoder = settings.MessageEncoderFactory.CreateSessionEncoder();
		_upgrade = settings.Upgrade;
		_flowIdentity = flowIdentity;
		_connectionPoolHelper = new DuplexConnectionPoolHelper(this, connectionPool, connectionInitiator);
	}

	private ArraySegment<byte> CreatePreamble()
	{
		EncodedVia via = new EncodedVia(Via.AbsoluteUri);
		EncodedContentType contentType = EncodedContentType.Create(base.MessageEncoder.ContentType);
		int num = ClientDuplexEncoder.ModeBytes.Length + SessionEncoder.CalcStartSize(via, contentType);
		int num2 = 0;
		if (_upgrade == null)
		{
			num2 = num;
			num += SessionEncoder.PreambleEndBytes.Length;
		}
		byte[] array = Fx.AllocateByteArray(num);
		Buffer.BlockCopy(ClientDuplexEncoder.ModeBytes, 0, array, 0, ClientDuplexEncoder.ModeBytes.Length);
		SessionEncoder.EncodeStart(array, ClientDuplexEncoder.ModeBytes.Length, via, contentType);
		if (num2 > 0)
		{
			Buffer.BlockCopy(SessionEncoder.PreambleEndBytes, 0, array, num2, SessionEncoder.PreambleEndBytes.Length);
		}
		return new ArraySegment<byte>(array, 0, num);
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnOpenAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	public override T GetProperty<T>()
	{
		T property = base.GetProperty<T>();
		if (property == null && _upgrade != null)
		{
			property = _upgrade.GetProperty<T>();
		}
		return property;
	}

	private async Task<IConnection> SendPreambleAsync(IConnection connection, ArraySegment<byte> preamble, TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		_decoder = new ClientDuplexDecoder(0L);
		byte[] ackBuffer = new byte[1];
		if (!(await base.SendLock.WaitAsync(TimeoutHelper.ToMilliseconds(timeout))))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.CloseTimedOut, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		try
		{
			await connection.WriteAsync(preamble.Array, preamble.Offset, preamble.Count, immediate: true, timeoutHelper.RemainingTime());
			if (_upgrade != null)
			{
				StreamUpgradeInitiator upgradeInitiator = _upgrade.CreateUpgradeInitiator(RemoteAddress, Via);
				await upgradeInitiator.OpenAsync(timeoutHelper.RemainingTime());
				OutWrapper<IConnection> connectionWrapper = new OutWrapper<IConnection>
				{
					Value = connection
				};
				bool flag = await ConnectionUpgradeHelper.InitiateUpgradeAsync(upgradeInitiator, connectionWrapper, _decoder, this, timeoutHelper.RemainingTime());
				connection = connectionWrapper.Value;
				if (!flag)
				{
					await ConnectionUpgradeHelper.DecodeFramingFaultAsync(_decoder, connection, Via, base.MessageEncoder.ContentType, timeoutHelper.RemainingTime());
				}
				SetRemoteSecurity(upgradeInitiator);
				await upgradeInitiator.CloseAsync(timeoutHelper.RemainingTime());
				await connection.WriteAsync(SessionEncoder.PreambleEndBytes, 0, SessionEncoder.PreambleEndBytes.Length, immediate: true, timeoutHelper.RemainingTime());
			}
			if (!ConnectionUpgradeHelper.ValidatePreambleResponse(ackBuffer, await connection.ReadAsync(ackBuffer, 0, ackBuffer.Length, timeoutHelper.RemainingTime()), _decoder, Via))
			{
				await ConnectionUpgradeHelper.DecodeFramingFaultAsync(_decoder, connection, Via, base.MessageEncoder.ContentType, timeoutHelper.RemainingTime());
			}
			return connection;
		}
		finally
		{
			base.SendLock.Release();
		}
	}

	private IConnection SendPreamble(IConnection connection, ArraySegment<byte> preamble, ref TimeoutHelper timeoutHelper)
	{
		TimeSpan timeSpan = timeoutHelper.RemainingTime();
		if (!base.SendLock.Wait(TimeoutHelper.ToMilliseconds(timeSpan)))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.CloseTimedOut, timeSpan), TimeoutHelper.CreateEnterTimedOutException(timeSpan)));
		}
		try
		{
			_decoder = new ClientDuplexDecoder(0L);
			byte[] array = new byte[1];
			connection.Write(preamble.Array, preamble.Offset, preamble.Count, immediate: true, timeoutHelper.RemainingTime());
			if (_upgrade != null)
			{
				StreamUpgradeInitiator streamUpgradeInitiator = _upgrade.CreateUpgradeInitiator(RemoteAddress, Via);
				streamUpgradeInitiator.Open(timeoutHelper.RemainingTime());
				if (!ConnectionUpgradeHelper.InitiateUpgrade(streamUpgradeInitiator, ref connection, _decoder, this, ref timeoutHelper))
				{
					ConnectionUpgradeHelper.DecodeFramingFault(_decoder, connection, Via, base.MessageEncoder.ContentType, ref timeoutHelper);
				}
				SetRemoteSecurity(streamUpgradeInitiator);
				streamUpgradeInitiator.Close(timeoutHelper.RemainingTime());
				connection.Write(SessionEncoder.PreambleEndBytes, 0, SessionEncoder.PreambleEndBytes.Length, immediate: true, timeoutHelper.RemainingTime());
			}
			int count = connection.Read(array, 0, array.Length, timeoutHelper.RemainingTime());
			if (!ConnectionUpgradeHelper.ValidatePreambleResponse(array, count, _decoder, Via))
			{
				ConnectionUpgradeHelper.DecodeFramingFault(_decoder, connection, Via, base.MessageEncoder.ContentType, ref timeoutHelper);
			}
			return connection;
		}
		finally
		{
			base.SendLock.Release();
		}
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		IConnection connection;
		try
		{
			using (TaskHelpers.RunTaskContinuationsOnOurThreads())
			{
				connection = await _connectionPoolHelper.EstablishConnectionAsync(timeout);
			}
		}
		catch (TimeoutException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TimeoutOnOpen, timeout), innerException));
		}
		bool flag = false;
		try
		{
			AcceptConnection(connection);
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				_connectionPoolHelper.Abort();
			}
		}
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		IConnection connection;
		try
		{
			connection = _connectionPoolHelper.EstablishConnection(timeout);
		}
		catch (TimeoutException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TimeoutOnOpen, timeout), innerException));
		}
		bool flag = false;
		try
		{
			AcceptConnection(connection);
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				_connectionPoolHelper.Abort();
			}
		}
	}

	protected override void ReturnConnectionIfNecessary(bool abort, TimeSpan timeout)
	{
		lock (base.ThisLock)
		{
			if (abort)
			{
				_connectionPoolHelper.Abort();
			}
			else
			{
				_connectionPoolHelper.Close(timeout);
			}
		}
	}

	private void AcceptConnection(IConnection connection)
	{
		SetMessageSource(new ClientDuplexConnectionReader(this, connection, _decoder, _settings, base.MessageEncoder));
		lock (base.ThisLock)
		{
			if (base.State != CommunicationState.Opening)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationObjectAbortedException(System.SR.Format(System.SR.DuplexChannelAbortedDuringOpen, Via)));
			}
			base.Connection = connection;
		}
	}

	private void SetRemoteSecurity(StreamUpgradeInitiator upgradeInitiator)
	{
		base.RemoteSecurity = StreamSecurityUpgradeInitiator.GetRemoteSecurity(upgradeInitiator);
	}

	protected override void PrepareMessage(Message message)
	{
		base.PrepareMessage(message);
	}
}
