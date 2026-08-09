using System.Runtime;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Security;

internal class OperationWithTimeoutAsyncResult : TraceAsyncResult
{
	private static readonly Action<object> s_scheduledCallback = OnScheduled;

	private TimeoutHelper _timeoutHelper;

	private Action<TimeSpan> _operationWithTimeout;

	public OperationWithTimeoutAsyncResult(Action<TimeSpan> operationWithTimeout, TimeSpan timeout, AsyncCallback callback, object state)
		: base(callback, state)
	{
		_operationWithTimeout = operationWithTimeout;
		_timeoutHelper = new TimeoutHelper(timeout);
		ActionItem.Schedule(s_scheduledCallback, this);
	}

	private static void OnScheduled(object state)
	{
		OperationWithTimeoutAsyncResult operationWithTimeoutAsyncResult = (OperationWithTimeoutAsyncResult)state;
		Exception exception = null;
		try
		{
			using ((operationWithTimeoutAsyncResult.CallbackActivity == null) ? null : ServiceModelActivity.BoundOperation(operationWithTimeoutAsyncResult.CallbackActivity))
			{
				operationWithTimeoutAsyncResult._operationWithTimeout(operationWithTimeoutAsyncResult._timeoutHelper.RemainingTime());
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			exception = ex;
		}
		operationWithTimeoutAsyncResult.Complete(completedSynchronously: false, exception);
	}

	public static void End(IAsyncResult result)
	{
		AsyncResult.End<OperationWithTimeoutAsyncResult>(result);
	}
}
