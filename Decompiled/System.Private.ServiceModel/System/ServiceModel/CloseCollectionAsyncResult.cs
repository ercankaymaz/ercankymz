using System.Collections.Generic;
using System.Runtime;
using System.Threading;

namespace System.ServiceModel;

internal class CloseCollectionAsyncResult : AsyncResult
{
	internal class CallbackState
	{
		private CloseCollectionAsyncResult _result;

		public ICommunicationObject Instance { get; }

		public CloseCollectionAsyncResult Result => _result;

		public CallbackState(CloseCollectionAsyncResult result, ICommunicationObject instance)
		{
			_result = result;
			Instance = instance;
		}
	}

	private bool _completedSynchronously;

	private Exception _exception;

	private static AsyncCallback s_nestedCallback = Fx.ThunkCallback(Callback);

	private int _count;

	public CloseCollectionAsyncResult(TimeSpan timeout, AsyncCallback otherCallback, object state, IList<ICommunicationObject> collection)
		: base(otherCallback, state)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		_completedSynchronously = true;
		_count = collection.Count;
		if (_count == 0)
		{
			Complete(completedSynchronously: true);
			return;
		}
		for (int i = 0; i < collection.Count; i++)
		{
			CallbackState state2 = new CallbackState(this, collection[i]);
			IAsyncResult asyncResult;
			try
			{
				asyncResult = collection[i].BeginClose(timeoutHelper.RemainingTime(), s_nestedCallback, state2);
			}
			catch (Exception exception)
			{
				if (Fx.IsFatal(exception))
				{
					throw;
				}
				Decrement(completedSynchronously: true, exception);
				collection[i].Abort();
				continue;
			}
			if (asyncResult.CompletedSynchronously)
			{
				CompleteClose(collection[i], asyncResult);
			}
		}
	}

	private void CompleteClose(ICommunicationObject communicationObject, IAsyncResult result)
	{
		Exception exception = null;
		try
		{
			communicationObject.EndClose(result);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			exception = ex;
			communicationObject.Abort();
		}
		Decrement(result.CompletedSynchronously, exception);
	}

	private static void Callback(IAsyncResult result)
	{
		if (!result.CompletedSynchronously)
		{
			CallbackState callbackState = (CallbackState)result.AsyncState;
			callbackState.Result.CompleteClose(callbackState.Instance, result);
		}
	}

	private void Decrement(bool completedSynchronously)
	{
		if (!completedSynchronously)
		{
			_completedSynchronously = false;
		}
		if (Interlocked.Decrement(ref _count) == 0)
		{
			if (_exception != null)
			{
				Complete(_completedSynchronously, _exception);
			}
			else
			{
				Complete(_completedSynchronously);
			}
		}
	}

	private void Decrement(bool completedSynchronously, Exception exception)
	{
		_exception = exception;
		Decrement(completedSynchronously);
	}

	public static void End(IAsyncResult result)
	{
		AsyncResult.End<CloseCollectionAsyncResult>(result);
	}
}
