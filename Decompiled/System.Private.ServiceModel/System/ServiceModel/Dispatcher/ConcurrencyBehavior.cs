using System.Runtime;
using System.Threading;

namespace System.ServiceModel.Dispatcher;

internal class ConcurrencyBehavior
{
	internal interface IWaiter
	{
		void Signal();
	}

	internal class MessageRpcWaiter : IWaiter
	{
		private IResumeMessageRpc _resume;

		internal MessageRpcWaiter(IResumeMessageRpc resume)
		{
			_resume = resume;
		}

		void IWaiter.Signal()
		{
			try
			{
				_resume.Resume(out var _);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
			}
		}
	}

	internal class ThreadWaiter : IWaiter
	{
		private ManualResetEvent _wait = new ManualResetEvent(initialState: false);

		void IWaiter.Signal()
		{
			_wait.Set();
		}

		internal void Wait()
		{
			_wait.WaitOne();
			_wait.Dispose();
		}
	}

	private ConcurrencyMode _concurrencyMode;

	private bool _enforceOrderedReceive;

	internal ConcurrencyBehavior(DispatchRuntime runtime)
	{
		_concurrencyMode = runtime.ConcurrencyMode;
		_enforceOrderedReceive = runtime.EnsureOrderedDispatch;
	}

	internal bool IsConcurrent(ref MessageRpc rpc)
	{
		return IsConcurrent(_concurrencyMode, _enforceOrderedReceive, rpc.Channel.HasSession);
	}

	internal static bool IsConcurrent(ConcurrencyMode concurrencyMode, bool ensureOrderedDispatch, bool hasSession)
	{
		if (concurrencyMode != ConcurrencyMode.Single)
		{
			return true;
		}
		if (hasSession)
		{
			return false;
		}
		if (ensureOrderedDispatch)
		{
			return false;
		}
		return true;
	}

	internal static bool IsConcurrent(ChannelDispatcher runtime, bool hasSession)
	{
		bool flag = true;
		foreach (EndpointDispatcher endpoint in runtime.Endpoints)
		{
			if (endpoint.DispatchRuntime.EnsureOrderedDispatch)
			{
				return false;
			}
			if (endpoint.DispatchRuntime.ConcurrencyMode != ConcurrencyMode.Single)
			{
				flag = false;
			}
		}
		if (!flag)
		{
			return true;
		}
		if (!hasSession)
		{
			return true;
		}
		return false;
	}

	internal void LockInstance(ref MessageRpc rpc)
	{
		if (_concurrencyMode == ConcurrencyMode.Multiple)
		{
			return;
		}
		ConcurrencyInstanceContextFacet concurrency = rpc.InstanceContext.Concurrency;
		lock (rpc.InstanceContext.ThisLock)
		{
			if (!concurrency.Locked)
			{
				concurrency.Locked = true;
			}
			else
			{
				MessageRpcWaiter waiter = new MessageRpcWaiter(rpc.Pause());
				concurrency.EnqueueNewMessage(waiter);
			}
		}
		if (_concurrencyMode == ConcurrencyMode.Reentrant)
		{
			rpc.OperationContext.IsServiceReentrant = true;
		}
	}

	internal void UnlockInstance(ref MessageRpc rpc)
	{
		if (_concurrencyMode != ConcurrencyMode.Multiple)
		{
			UnlockInstance(rpc.InstanceContext);
		}
	}

	internal static void UnlockInstanceBeforeCallout(OperationContext operationContext)
	{
		if (operationContext != null && operationContext.IsServiceReentrant)
		{
			UnlockInstance(operationContext.InstanceContext);
		}
	}

	private static void UnlockInstance(InstanceContext instanceContext)
	{
		ConcurrencyInstanceContextFacet concurrency = instanceContext.Concurrency;
		lock (instanceContext.ThisLock)
		{
			if (concurrency.HasWaiters)
			{
				IWaiter waiter = concurrency.DequeueWaiter();
				waiter.Signal();
			}
			else
			{
				concurrency.Locked = false;
			}
		}
	}

	internal static void LockInstanceAfterCallout(OperationContext operationContext)
	{
		if (operationContext == null)
		{
			return;
		}
		InstanceContext instanceContext = operationContext.InstanceContext;
		if (!operationContext.IsServiceReentrant)
		{
			return;
		}
		ConcurrencyInstanceContextFacet concurrency = instanceContext.Concurrency;
		ThreadWaiter threadWaiter = null;
		lock (instanceContext.ThisLock)
		{
			if (!concurrency.Locked)
			{
				concurrency.Locked = true;
			}
			else
			{
				threadWaiter = new ThreadWaiter();
				concurrency.EnqueueCalloutMessage(threadWaiter);
			}
		}
		threadWaiter?.Wait();
	}
}
