using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class LayeredDuplexChannel : LayeredInputChannel, IAsyncDuplexChannel, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel
{
	private IOutputChannel _innerOutputChannel;

	private EndpointAddress _localAddress;

	private EventHandler _onInnerOutputChannelFaulted;

	public override EndpointAddress LocalAddress => _localAddress;

	public EndpointAddress RemoteAddress => _innerOutputChannel.RemoteAddress;

	public Uri Via => _innerOutputChannel.Via;

	public LayeredDuplexChannel(ChannelManagerBase channelManager, IInputChannel innerInputChannel, EndpointAddress localAddress, IOutputChannel innerOutputChannel)
		: base(channelManager, innerInputChannel)
	{
		_localAddress = localAddress;
		_innerOutputChannel = innerOutputChannel;
		_onInnerOutputChannelFaulted = OnInnerOutputChannelFaulted;
		_innerOutputChannel.Faulted += _onInnerOutputChannelFaulted;
	}

	protected override void OnClosing()
	{
		_innerOutputChannel.Faulted -= _onInnerOutputChannelFaulted;
		base.OnClosing();
	}

	protected override void OnAbort()
	{
		_innerOutputChannel.Abort();
		base.OnAbort();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await _innerOutputChannel.CloseHelperAsync(timeout);
		await base.OnCloseAsync(timeoutHelper.RemainingTime());
	}

	protected override void OnClose(TimeSpan timeout)
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

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await base.OnOpenAsync(timeoutHelper.RemainingTime());
		await _innerOutputChannel.OpenHelperAsync(timeoutHelper.RemainingTime());
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		base.OnOpen(timeoutHelper.RemainingTime());
		_innerOutputChannel.Open(timeoutHelper.RemainingTime());
	}

	public Task SendAsync(Message message)
	{
		return SendAsync(message, base.DefaultSendTimeout);
	}

	public Task SendAsync(Message message, TimeSpan timeout)
	{
		if (_innerOutputChannel is IAsyncOutputChannel asyncOutputChannel)
		{
			return asyncOutputChannel.SendAsync(message, timeout);
		}
		return Task.Factory.FromAsync(_innerOutputChannel.BeginSend, _innerOutputChannel.EndSend, message, timeout, null);
	}

	public void Send(Message message)
	{
		Send(message, base.DefaultSendTimeout);
	}

	public void Send(Message message, TimeSpan timeout)
	{
		SendAsync(message, timeout).GetAwaiter().GetResult();
	}

	public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
	{
		return BeginSend(message, base.DefaultSendTimeout, callback, state);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return SendAsync(message, timeout).ToApm(callback, state);
	}

	public void EndSend(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	private void OnInnerOutputChannelFaulted(object sender, EventArgs e)
	{
		Fault();
	}
}
