using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class ChannelFactoryBase : ChannelManagerBase, IChannelFactory, ICommunicationObject, IAsyncChannelFactory, IAsyncCommunicationObject
{
	private TimeSpan _closeTimeout = ServiceDefaults.CloseTimeout;

	private TimeSpan _openTimeout = ServiceDefaults.OpenTimeout;

	private TimeSpan _receiveTimeout = ServiceDefaults.ReceiveTimeout;

	private TimeSpan _sendTimeout = ServiceDefaults.SendTimeout;

	protected override TimeSpan DefaultCloseTimeout => _closeTimeout;

	protected override TimeSpan DefaultOpenTimeout => _openTimeout;

	protected override TimeSpan DefaultReceiveTimeout => _receiveTimeout;

	protected override TimeSpan DefaultSendTimeout => _sendTimeout;

	protected ChannelFactoryBase()
	{
	}

	protected ChannelFactoryBase(IDefaultCommunicationTimeouts timeouts)
	{
		InitializeTimeouts(timeouts);
	}

	public virtual T GetProperty<T>() where T : class
	{
		if (typeof(T) == typeof(IChannelFactory))
		{
			return (T)(object)this;
		}
		return null;
	}

	protected override void OnAbort()
	{
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return new CompletedAsyncResult(callback, state);
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		return TaskHelpers.CompletedTask();
	}

	protected override void OnClose(TimeSpan timeout)
	{
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		CompletedAsyncResult.End(result);
	}

	private void InitializeTimeouts(IDefaultCommunicationTimeouts timeouts)
	{
		if (timeouts != null)
		{
			_closeTimeout = timeouts.CloseTimeout;
			_openTimeout = timeouts.OpenTimeout;
			_receiveTimeout = timeouts.ReceiveTimeout;
			_sendTimeout = timeouts.SendTimeout;
		}
	}
}
public abstract class ChannelFactoryBase<TChannel> : ChannelFactoryBase, IChannelFactory<TChannel>, IChannelFactory, ICommunicationObject
{
	private CommunicationObjectManager<IChannel> _channels;

	protected ChannelFactoryBase()
		: this((IDefaultCommunicationTimeouts)null)
	{
	}

	protected ChannelFactoryBase(IDefaultCommunicationTimeouts timeouts)
		: base(timeouts)
	{
		_channels = new CommunicationObjectManager<IChannel>(base.ThisLock);
	}

	public TChannel CreateChannel(EndpointAddress address)
	{
		if (address == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("address");
		}
		return InternalCreateChannel(address, address.Uri);
	}

	public TChannel CreateChannel(EndpointAddress address, Uri via)
	{
		if (address == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("address");
		}
		if (via == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("via");
		}
		return InternalCreateChannel(address, via);
	}

	private TChannel InternalCreateChannel(EndpointAddress address, Uri via)
	{
		ValidateCreateChannel();
		TChannel val = OnCreateChannel(address, via);
		bool flag = false;
		try
		{
			_channels.Add((IChannel)(object)val);
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				((IChannel)(object)val).Abort();
			}
		}
		return val;
	}

	protected abstract TChannel OnCreateChannel(EndpointAddress address, Uri via);

	protected void ValidateCreateChannel()
	{
		ThrowIfDisposed();
		if (base.State != CommunicationState.Opened)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ChannelFactoryCannotBeUsedToCreateChannels, GetType().ToString())));
		}
	}

	protected override void OnAbort()
	{
		IChannel[] array = _channels.ToArray();
		IChannel[] array2 = array;
		foreach (IChannel channel in array2)
		{
			channel.Abort();
		}
		_channels.Abort();
	}

	protected override void OnClose(TimeSpan timeout)
	{
		IChannel[] array = _channels.ToArray();
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		IChannel[] array2 = array;
		foreach (IChannel channel in array2)
		{
			channel.Close(timeoutHelper.RemainingTime());
		}
		_channels.Close(timeoutHelper.RemainingTime());
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		return OnCloseAsyncInternal(timeout);
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	private async Task OnCloseAsyncInternal(TimeSpan timeout)
	{
		IChannel[] array = _channels.ToArray();
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		IChannel[] array2 = array;
		foreach (IChannel other in array2)
		{
			await CloseOtherAsync(other, timeoutHelper.RemainingTime());
		}
		await _channels.CloseAsync(timeoutHelper.RemainingTime());
	}
}
