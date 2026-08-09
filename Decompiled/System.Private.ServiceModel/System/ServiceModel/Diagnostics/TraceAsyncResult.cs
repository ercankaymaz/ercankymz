using System.Runtime;

namespace System.ServiceModel.Diagnostics;

internal abstract class TraceAsyncResult : AsyncResult
{
	private static Action<AsyncCallback, IAsyncResult> s_waitResultCallback = DoCallback;

	public ServiceModelActivity CallbackActivity { get; private set; }

	protected TraceAsyncResult(AsyncCallback callback, object state)
		: base(callback, state)
	{
		if (TraceUtility.MessageFlowTracingOnly)
		{
			base.VirtualCallback = s_waitResultCallback;
		}
		else if (DiagnosticUtility.ShouldUseActivity)
		{
			CallbackActivity = ServiceModelActivity.Current;
			if (CallbackActivity != null)
			{
				base.VirtualCallback = s_waitResultCallback;
			}
		}
	}

	private static void DoCallback(AsyncCallback callback, IAsyncResult result)
	{
		if (result is TraceAsyncResult)
		{
			TraceAsyncResult traceAsyncResult = result as TraceAsyncResult;
			if (TraceUtility.MessageFlowTracingOnly)
			{
				traceAsyncResult.CallbackActivity = null;
			}
			using (ServiceModelActivity.BoundOperation(traceAsyncResult.CallbackActivity))
			{
				callback(result);
			}
		}
	}
}
