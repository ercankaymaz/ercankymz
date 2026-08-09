using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class LayeredChannelFactory<TChannel> : ChannelFactoryBase<TChannel>
{
	protected IChannelFactory InnerChannelFactory { get; }

	public LayeredChannelFactory(IDefaultCommunicationTimeouts timeouts, IChannelFactory innerChannelFactory)
		: base(timeouts)
	{
		InnerChannelFactory = innerChannelFactory;
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(IChannelFactory<TChannel>))
		{
			return (T)(object)this;
		}
		T property = base.GetProperty<T>();
		if (property != null)
		{
			return property;
		}
		return InnerChannelFactory.GetProperty<T>();
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return InnerChannelFactory.BeginOpen(timeout, callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		InnerChannelFactory.EndOpen(result);
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await base.OnCloseAsync(timeoutHelper.RemainingTime());
		await InnerChannelFactory.CloseHelperAsync(timeoutHelper.RemainingTime());
	}

	protected override void OnClose(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		base.OnClose(timeoutHelper.RemainingTime());
		InnerChannelFactory.Close(timeoutHelper.RemainingTime());
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		return InnerChannelFactory.OpenHelperAsync(timeout);
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		InnerChannelFactory.Open(timeout);
	}

	protected override void OnAbort()
	{
		base.OnAbort();
		InnerChannelFactory.Abort();
	}
}
