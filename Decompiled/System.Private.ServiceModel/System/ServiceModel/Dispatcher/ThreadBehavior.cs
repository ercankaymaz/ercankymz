using System.Runtime;
using System.Threading;

namespace System.ServiceModel.Dispatcher;

internal class ThreadBehavior
{
	private SendOrPostCallback _threadAffinityStartCallback;

	private SendOrPostCallback _threadAffinityEndCallback;

	private static Action<object> s_cleanThreadCallback;

	private readonly SynchronizationContext _context;

	private SendOrPostCallback ThreadAffinityStartCallbackDelegate
	{
		get
		{
			if (_threadAffinityStartCallback == null)
			{
				_threadAffinityStartCallback = SynchronizationContextStartCallback;
			}
			return _threadAffinityStartCallback;
		}
	}

	private SendOrPostCallback ThreadAffinityEndCallbackDelegate
	{
		get
		{
			if (_threadAffinityEndCallback == null)
			{
				_threadAffinityEndCallback = SynchronizationContextEndCallback;
			}
			return _threadAffinityEndCallback;
		}
	}

	private static Action<object> CleanThreadCallbackDelegate
	{
		get
		{
			if (s_cleanThreadCallback == null)
			{
				s_cleanThreadCallback = CleanThreadCallback;
			}
			return s_cleanThreadCallback;
		}
	}

	internal ThreadBehavior(DispatchRuntime dispatch)
	{
		_context = dispatch.SynchronizationContext;
	}

	internal void BindThread(ref MessageRpc rpc)
	{
		BindCore(ref rpc, startOperation: true);
	}

	internal void BindEndThread(ref MessageRpc rpc)
	{
		BindCore(ref rpc, startOperation: false);
	}

	private void BindCore(ref MessageRpc rpc, bool startOperation)
	{
		SynchronizationContext syncContext = GetSyncContext(rpc.InstanceContext);
		if (syncContext != null)
		{
			IResumeMessageRpc state = rpc.Pause();
			if (startOperation)
			{
				syncContext.OperationStarted();
				syncContext.Post(ThreadAffinityStartCallbackDelegate, state);
			}
			else
			{
				syncContext.Post(ThreadAffinityEndCallbackDelegate, state);
			}
		}
		else if (rpc.SwitchedThreads)
		{
			IResumeMessageRpc state2 = rpc.Pause();
			ActionItem.Schedule(CleanThreadCallbackDelegate, state2);
		}
	}

	private SynchronizationContext GetSyncContext(InstanceContext instanceContext)
	{
		return instanceContext.SynchronizationContext ?? _context;
	}

	private void SynchronizationContextStartCallback(object state)
	{
		ResumeProcessing((IResumeMessageRpc)state);
	}

	private void SynchronizationContextEndCallback(object state)
	{
		IResumeMessageRpc resumeMessageRpc = (IResumeMessageRpc)state;
		ResumeProcessing(resumeMessageRpc);
		SynchronizationContext syncContext = GetSyncContext(resumeMessageRpc.GetMessageInstanceContext());
		syncContext.OperationCompleted();
	}

	private void ResumeProcessing(IResumeMessageRpc resume)
	{
		resume.Resume(out var alreadyResumedNoLock);
		if (alreadyResumedNoLock)
		{
			string message = System.SR.Format(System.SR.SFxMultipleCallbackFromSynchronizationContext, _context.GetType().ToString());
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(message));
		}
	}

	private static void CleanThreadCallback(object state)
	{
		((IResumeMessageRpc)state).Resume(out var _);
	}

	internal static SynchronizationContext GetCurrentSynchronizationContext()
	{
		return SynchronizationContext.Current;
	}
}
