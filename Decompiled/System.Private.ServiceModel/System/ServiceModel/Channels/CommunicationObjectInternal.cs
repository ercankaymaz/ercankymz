using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public static class CommunicationObjectInternal
{
	public static void ThrowIfClosed(CommunicationObject communicationObject)
	{
		communicationObject.ThrowIfClosed();
	}

	public static void ThrowIfClosedOrOpened(CommunicationObject communicationObject)
	{
		communicationObject.ThrowIfClosedOrOpened();
	}

	public static void ThrowIfDisposedOrNotOpen(CommunicationObject communicationObject)
	{
		communicationObject.ThrowIfDisposedOrNotOpen();
	}

	public static void ThrowIfDisposed(CommunicationObject communicationObject)
	{
		communicationObject.ThrowIfDisposed();
	}

	public static TimeSpan GetInternalCloseTimeout(this CommunicationObject communicationObject)
	{
		return communicationObject.InternalCloseTimeout;
	}

	public static void OnClose(CommunicationObject communicationObject, TimeSpan timeout)
	{
		OnCloseAsyncInternal(communicationObject, timeout).WaitForCompletion();
	}

	public static IAsyncResult OnBeginClose(CommunicationObject communicationObject, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return communicationObject.OnCloseAsync(timeout).ToApm(callback, state);
	}

	public static void OnEnd(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	public static void OnOpen(CommunicationObject communicationObject, TimeSpan timeout)
	{
		OnOpenAsyncInternal(communicationObject, timeout).WaitForCompletion();
	}

	public static IAsyncResult OnBeginOpen(CommunicationObject communicationObject, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return communicationObject.OnOpenAsync(timeout).ToApm(callback, state);
	}

	public static async Task OnCloseAsyncInternal(CommunicationObject communicationObject, TimeSpan timeout)
	{
		await TaskHelpers.EnsureDefaultTaskScheduler();
		await communicationObject.OnCloseAsync(timeout);
	}

	public static async Task OnOpenAsyncInternal(CommunicationObject communicationObject, TimeSpan timeout)
	{
		await TaskHelpers.EnsureDefaultTaskScheduler();
		await communicationObject.OnOpenAsync(timeout);
	}
}
