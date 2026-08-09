using System.Collections.Generic;
using System.Runtime;
using System.Threading;

namespace System.ServiceModel;

internal class OpenCollectionAsyncResult : AsyncResult
{
	internal class CallbackState
	{
		private OpenCollectionAsyncResult _result;

		public ICommunicationObject Instance { get; }

		public OpenCollectionAsyncResult Result => _result;

		public CallbackState(OpenCollectionAsyncResult result, ICommunicationObject instance)
		{
			_result = result;
			Instance = instance;
		}
	}

	private bool _completedSynchronously;

	private Exception _exception;

	private static AsyncCallback s_nestedCallback = Fx.ThunkCallback(Callback);

	private int _count;

	private TimeoutHelper _timeoutHelper;

	public OpenCollectionAsyncResult(TimeSpan timeout, AsyncCallback otherCallback, object state, IList<ICommunicationObject> collection)
		: base(otherCallback, state)
	{
		_timeoutHelper = new TimeoutHelper(timeout);
		_completedSynchronously = true;
		_count = collection.Count;
		if (_count == 0)
		{
			Complete(completedSynchronously: true);
			return;
		}
		for (int i = 0; i < collection.Count; i++)
		{
			if (_exception != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_exception);
			}
			CallbackState state2 = new CallbackState(this, collection[i]);
			IAsyncResult asyncResult = collection[i].BeginOpen(_timeoutHelper.RemainingTime(), s_nestedCallback, state2);
			if (asyncResult.CompletedSynchronously)
			{
				collection[i].EndOpen(asyncResult);
				Decrement(completedSynchronously: true);
			}
		}
	}

	private static void Callback(IAsyncResult result)
	{
		if (result.CompletedSynchronously)
		{
			return;
		}
		CallbackState callbackState = (CallbackState)result.AsyncState;
		try
		{
			callbackState.Instance.EndOpen(result);
			callbackState.Result.Decrement(completedSynchronously: false);
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
			callbackState.Result.Decrement(completedSynchronously: false, exception);
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
		AsyncResult.End<OpenCollectionAsyncResult>(result);
	}
}
