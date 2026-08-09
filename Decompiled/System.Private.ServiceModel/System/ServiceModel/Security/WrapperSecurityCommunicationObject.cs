using System.Runtime;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal class WrapperSecurityCommunicationObject : CommunicationObject
{
	private ISecurityCommunicationObject _innerCommunicationObject;

	protected override TimeSpan DefaultCloseTimeout => _innerCommunicationObject.DefaultCloseTimeout;

	protected override TimeSpan DefaultOpenTimeout => _innerCommunicationObject.DefaultOpenTimeout;

	public WrapperSecurityCommunicationObject(ISecurityCommunicationObject innerCommunicationObject)
	{
		_innerCommunicationObject = innerCommunicationObject ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("innerCommunicationObject");
		base.SupportsAsyncOpenClose = true;
	}

	protected override Type GetCommunicationObjectType()
	{
		return _innerCommunicationObject.GetType();
	}

	protected override void OnAbort()
	{
		_innerCommunicationObject.OnAbort();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnOpenAsync(timeout).ToApm(callback, state);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		_innerCommunicationObject.OnCloseAsync(timeout).GetAwaiter().GetResult();
	}

	protected override void OnClosed()
	{
		_innerCommunicationObject.OnClosed();
		base.OnClosed();
	}

	protected override void OnClosing()
	{
		_innerCommunicationObject.OnClosing();
		base.OnClosing();
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override void OnFaulted()
	{
		_innerCommunicationObject.OnFaulted();
		base.OnFaulted();
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		_innerCommunicationObject.OnOpenAsync(timeout).GetAwaiter().GetResult();
	}

	protected override void OnOpened()
	{
		_innerCommunicationObject.OnOpened();
		base.OnOpened();
	}

	protected override void OnOpening()
	{
		_innerCommunicationObject.OnOpening();
		base.OnOpening();
	}

	internal new void ThrowIfDisposedOrImmutable()
	{
		base.ThrowIfDisposedOrImmutable();
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		return _innerCommunicationObject.OnCloseAsync(timeout);
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		return _innerCommunicationObject.OnOpenAsync(timeout);
	}
}
