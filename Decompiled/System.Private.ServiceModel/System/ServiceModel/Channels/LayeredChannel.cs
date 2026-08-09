using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class LayeredChannel<TInnerChannel> : ChannelBase where TInnerChannel : class, IChannel
{
	private EventHandler _onInnerChannelFaulted;

	protected TInnerChannel InnerChannel { get; }

	protected LayeredChannel(ChannelManagerBase channelManager, TInnerChannel innerChannel)
		: base(channelManager)
	{
		InnerChannel = innerChannel;
		_onInnerChannelFaulted = OnInnerChannelFaulted;
		InnerChannel.Faulted += _onInnerChannelFaulted;
		base.SupportsAsyncOpenClose = true;
	}

	public override T GetProperty<T>()
	{
		T property = base.GetProperty<T>();
		if (property != null)
		{
			return property;
		}
		return InnerChannel.GetProperty<T>();
	}

	protected override void OnClosing()
	{
		InnerChannel.Faulted -= _onInnerChannelFaulted;
		base.OnClosing();
	}

	protected override void OnAbort()
	{
		InnerChannel.Abort();
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		return InnerChannel.CloseHelperAsync(timeout);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		return InnerChannel.OpenHelperAsync(timeout);
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	private void OnInnerChannelFaulted(object sender, EventArgs e)
	{
		Fault();
	}
}
