using System.Runtime;
using System.ServiceModel.Channels;
using System.Threading;

namespace System.ServiceModel.Dispatcher;

internal class TerminatingOperationBehavior
{
	private static TimerCallback s_abortChannelTimerCallback = Fx.ThunkCallback<object>(AbortChannel).Invoke;

	private static void AbortChannel(object state)
	{
		((IChannel)state).Abort();
	}

	public static TerminatingOperationBehavior CreateIfNecessary(DispatchRuntime dispatch)
	{
		if (IsTerminatingOperationBehaviorNeeded(dispatch))
		{
			return new TerminatingOperationBehavior();
		}
		return null;
	}

	private static bool IsTerminatingOperationBehaviorNeeded(DispatchRuntime dispatch)
	{
		for (int i = 0; i < dispatch.Operations.Count; i++)
		{
			DispatchOperation dispatchOperation = dispatch.Operations[i];
			if (dispatchOperation.IsTerminating)
			{
				return true;
			}
		}
		return false;
	}

	internal void AfterReply(ref MessageRpc rpc)
	{
		if (rpc.Operation.IsTerminating && rpc.Channel.HasSession)
		{
			Timer timer = new Timer(s_abortChannelTimerCallback, rpc.Channel.Binder.Channel, rpc.Channel.CloseTimeout, TimeSpan.FromMilliseconds(-1.0));
		}
	}

	internal static void AfterReply(ref ProxyRpc rpc)
	{
		if (rpc.Operation.IsTerminating && rpc.Channel.HasSession)
		{
			IChannel channel = rpc.Channel.Binder.Channel;
			rpc.Channel.Close(rpc.TimeoutHelper.RemainingTime());
		}
	}
}
