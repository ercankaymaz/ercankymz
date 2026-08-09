using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal static class ReliableChannelBinderHelper
{
	internal static async Task CloseDuplexSessionChannelAsync(ReliableChannelBinder<IDuplexSessionChannel> binder, IDuplexSessionChannel channel, TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await ((ISessionChannel<IAsyncDuplexSession>)channel).Session.CloseOutputSessionAsync(timeoutHelper.RemainingTime());
		await binder.WaitForPendingOperationsAsync(timeoutHelper.RemainingTime());
		TimeSpan timeSpan = timeoutHelper.RemainingTime();
		bool lastIteration = timeSpan == TimeSpan.Zero;
		while (true)
		{
			Message message = null;
			bool receiveThrowing = true;
			try
			{
				bool flag;
				if (!(channel is IAsyncDuplexSessionChannel))
				{
					(flag, message) = await TaskHelpers.FromAsync<TimeSpan, bool, Message>(channel.BeginTryReceive, channel.EndTryReceive, timeout, null);
				}
				else
				{
					(flag, message) = await ((IAsyncDuplexSessionChannel)channel).TryReceiveAsync(timeout);
				}
				receiveThrowing = false;
				if (flag && message == null)
				{
					await channel.CloseHelperAsync(timeoutHelper.RemainingTime());
					return;
				}
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (!receiveThrowing)
				{
					throw;
				}
				if (!MaskHandled(binder.DefaultMaskingMode) || !binder.IsHandleable(ex))
				{
					throw;
				}
				receiveThrowing = false;
			}
			finally
			{
				message?.Close();
				if (receiveThrowing)
				{
					channel.Abort();
				}
			}
			if (lastIteration || channel.State != CommunicationState.Opened)
			{
				break;
			}
			timeSpan = timeoutHelper.RemainingTime();
			lastIteration = timeSpan == TimeSpan.Zero;
		}
		channel.Abort();
	}

	internal static async Task CloseReplySessionChannelAsync(ReliableChannelBinder<IReplySessionChannel> binder, IReplySessionChannel channel, TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await binder.WaitForPendingOperationsAsync(timeoutHelper.RemainingTime());
		TimeSpan timeSpan = timeoutHelper.RemainingTime();
		bool lastIteration = timeSpan == TimeSpan.Zero;
		while (true)
		{
			RequestContext context = null;
			bool receiveThrowing = true;
			try
			{
				(bool, RequestContext) tuple = await TaskHelpers.FromAsync<TimeSpan, bool, RequestContext>(channel.BeginTryReceiveRequest, channel.EndTryReceiveRequest, timeSpan, null);
				bool item = tuple.Item1;
				context = tuple.Item2;
				receiveThrowing = false;
				if (item && context == null)
				{
					await channel.CloseHelperAsync(timeoutHelper.RemainingTime());
					return;
				}
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (!receiveThrowing)
				{
					throw;
				}
				if (!MaskHandled(binder.DefaultMaskingMode) || !binder.IsHandleable(ex))
				{
					throw;
				}
				receiveThrowing = false;
			}
			finally
			{
				if (context != null)
				{
					context.RequestMessage.Close();
					context.Close();
				}
				if (receiveThrowing)
				{
					channel.Abort();
				}
			}
			if (lastIteration || channel.State != CommunicationState.Opened)
			{
				break;
			}
			timeSpan = timeoutHelper.RemainingTime();
			lastIteration = timeSpan == TimeSpan.Zero;
		}
		channel.Abort();
	}

	internal static bool MaskHandled(MaskingMode maskingMode)
	{
		return (maskingMode & MaskingMode.Handled) == MaskingMode.Handled;
	}

	internal static bool MaskUnhandled(MaskingMode maskingMode)
	{
		return (maskingMode & MaskingMode.Unhandled) == MaskingMode.Unhandled;
	}
}
