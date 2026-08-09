using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime;

public static class TaskHelpers
{
	public delegate TResult EndWithOutDelegate<T1, TResult>(IAsyncResult iar, out T1 arg1);

	private class SyncContextScope : IDisposable
	{
		private readonly SynchronizationContext _prevContext;

		public SyncContextScope()
		{
			_prevContext = SynchronizationContext.Current;
			SynchronizationContext.SetSynchronizationContext(ServiceModelSynchronizationContext.Instance);
		}

		public void Dispose()
		{
			SynchronizationContext.SetSynchronizationContext(_prevContext);
		}
	}

	public static Action<object> OnAsyncCompletionCallback = OnAsyncCompletion;

	public static async Task AsyncWait<TException>(this Task task)
	{
		try
		{
			await task;
		}
		catch
		{
			throw Fx.Exception.AsError<TException>(task.Exception);
		}
	}

	public static Task<TResult> ToApm<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
	{
		if (task.AsyncState == state)
		{
			if (callback != null)
			{
				task.ContinueWith(delegate(Task<TResult> antecedent, object obj)
				{
					AsyncCallback asyncCallback = obj as AsyncCallback;
					asyncCallback(antecedent);
				}, callback, CancellationToken.None, TaskContinuationOptions.HideScheduler, TaskScheduler.Default);
			}
			return task;
		}
		TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>(state);
		Tuple<TaskCompletionSource<TResult>, AsyncCallback> state2 = Tuple.Create(taskCompletionSource, callback);
		task.ContinueWith(delegate(Task<TResult> antecedent, object obj)
		{
			Tuple<TaskCompletionSource<TResult>, AsyncCallback> tuple = obj as Tuple<TaskCompletionSource<TResult>, AsyncCallback>;
			TaskCompletionSource<TResult> item = tuple.Item1;
			AsyncCallback item2 = tuple.Item2;
			if (antecedent.IsFaulted)
			{
				item.TrySetException(antecedent.Exception.InnerException);
			}
			else if (antecedent.IsCanceled)
			{
				item.TrySetCanceled();
			}
			else
			{
				item.TrySetResult(antecedent.Result);
			}
			item2?.Invoke(item.Task);
		}, state2, CancellationToken.None, TaskContinuationOptions.HideScheduler, TaskScheduler.Default);
		return taskCompletionSource.Task;
	}

	public static Task ToApm(this Task task, AsyncCallback callback, object state)
	{
		if (task.AsyncState == state)
		{
			if (callback != null)
			{
				task.ContinueWith(delegate(Task antecedent, object obj)
				{
					AsyncCallback asyncCallback = obj as AsyncCallback;
					asyncCallback(antecedent);
				}, callback, CancellationToken.None, TaskContinuationOptions.HideScheduler, TaskScheduler.Default);
			}
			return task;
		}
		TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>(state);
		Tuple<TaskCompletionSource<object>, AsyncCallback> state2 = Tuple.Create(taskCompletionSource, callback);
		task.ContinueWith(delegate(Task antecedent, object obj)
		{
			Tuple<TaskCompletionSource<object>, AsyncCallback> tuple = obj as Tuple<TaskCompletionSource<object>, AsyncCallback>;
			TaskCompletionSource<object> item = tuple.Item1;
			AsyncCallback item2 = tuple.Item2;
			if (antecedent.IsFaulted)
			{
				item.TrySetException(antecedent.Exception.InnerException);
			}
			else if (antecedent.IsCanceled)
			{
				item.TrySetCanceled();
			}
			else
			{
				item.TrySetResult(null);
			}
			item2?.Invoke(item.Task);
		}, state2, CancellationToken.None, TaskContinuationOptions.HideScheduler, TaskScheduler.Default);
		return taskCompletionSource.Task;
	}

	public static TResult ToApmEnd<TResult>(this IAsyncResult iar)
	{
		Task<TResult> task = iar as Task<TResult>;
		return task.GetAwaiter().GetResult();
	}

	public static void ToApmEnd(this IAsyncResult iar)
	{
		Task task = iar as Task;
		task.GetAwaiter().GetResult();
	}

	public static Task<(TOut1, TOut2)> FromAsync<TIn, TOut1, TOut2>(Func<TIn, AsyncCallback, object, IAsyncResult> beginDelegate, EndWithOutDelegate<TOut2, TOut1> endDelegate, TIn arg1, object state)
	{
		TaskCompletionSource<(TOut1, TOut2)> taskCompletionSource = new TaskCompletionSource<(TOut1, TOut2)>(state);
		try
		{
			beginDelegate(arg1, delegate(IAsyncResult iar)
			{
				Tuple<EndWithOutDelegate<TOut2, TOut1>, TaskCompletionSource<(TOut1, TOut2)>> tuple = iar.AsyncState as Tuple<EndWithOutDelegate<TOut2, TOut1>, TaskCompletionSource<(TOut1, TOut2)>>;
				EndWithOutDelegate<TOut2, TOut1> item = tuple.Item1;
				TaskCompletionSource<(TOut1, TOut2)> item2 = tuple.Item2;
				try
				{
					TOut2 arg2;
					TOut1 item3 = item(iar, out arg2);
					item2.TrySetResult((item3, arg2));
				}
				catch (Exception exception2)
				{
					item2.TrySetException(exception2);
				}
			}, Tuple.Create(endDelegate, taskCompletionSource));
		}
		catch (Exception exception)
		{
			taskCompletionSource.TrySetException(exception);
		}
		return taskCompletionSource.Task;
	}

	public static Task CloseHelperAsync(this ICommunicationObject communicationObject, TimeSpan timeout)
	{
		if (communicationObject is IAsyncCommunicationObject)
		{
			return ((IAsyncCommunicationObject)communicationObject).CloseAsync(timeout);
		}
		return Task.Factory.FromAsync(communicationObject.BeginClose, communicationObject.EndClose, timeout, null);
	}

	public static Task OpenHelperAsync(this ICommunicationObject communicationObject, TimeSpan timeout)
	{
		if (communicationObject is IAsyncCommunicationObject)
		{
			return ((IAsyncCommunicationObject)communicationObject).OpenAsync(timeout);
		}
		return Task.Factory.FromAsync(communicationObject.BeginOpen, communicationObject.EndOpen, timeout, null);
	}

	public static async Task<bool> AwaitWithTimeout(this Task task, TimeSpan timeout)
	{
		if (task.IsCompleted)
		{
			return true;
		}
		if (timeout == TimeSpan.MaxValue || timeout == Timeout.InfiniteTimeSpan)
		{
			await task;
			return true;
		}
		using CancellationTokenSource cts = new CancellationTokenSource();
		if (await Task.WhenAny(new Task[2]
		{
			task,
			Task.Delay(timeout, cts.Token)
		}) == task)
		{
			cts.Cancel();
			return true;
		}
		return task.IsCompleted;
	}

	public static void WaitForCompletion(this Task task)
	{
		task.GetAwaiter().GetResult();
	}

	public static void WaitForCompletionNoSpin(this Task task)
	{
		if (!task.IsCompleted)
		{
			((IAsyncResult)task).AsyncWaitHandle.WaitOne();
		}
		task.GetAwaiter().GetResult();
	}

	public static TResult WaitForCompletion<TResult>(this Task<TResult> task)
	{
		return task.GetAwaiter().GetResult();
	}

	public static TResult WaitForCompletionNoSpin<TResult>(this Task<TResult> task)
	{
		if (!task.IsCompleted)
		{
			((IAsyncResult)task).AsyncWaitHandle.WaitOne();
		}
		return task.GetAwaiter().GetResult();
	}

	public static bool WaitForCompletionNoSpin(this Task task, TimeSpan timeout)
	{
		if (timeout >= TimeoutHelper.MaxWait)
		{
			task.WaitForCompletionNoSpin();
			return true;
		}
		bool flag = true;
		if (!task.IsCompleted)
		{
			flag = ((IAsyncResult)task).AsyncWaitHandle.WaitOne(timeout);
		}
		if (flag)
		{
			task.GetAwaiter().GetResult();
		}
		return flag;
	}

	public static void Wait(this Task task, TimeSpan timeout, Action<Exception, TimeSpan, string> exceptionConverter, string operationType)
	{
		bool flag = false;
		try
		{
			flag = !task.WaitForCompletionNoSpin(timeout);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex) || exceptionConverter == null)
			{
				throw;
			}
			exceptionConverter(ex, timeout, operationType);
		}
		if (flag)
		{
			throw Fx.Exception.AsError(new TimeoutException(InternalSR.TaskTimedOutError(timeout)));
		}
	}

	public static Task CompletedTask()
	{
		return Task.FromResult(result: true);
	}

	public static DefaultTaskSchedulerAwaiter EnsureDefaultTaskScheduler()
	{
		return DefaultTaskSchedulerAwaiter.Singleton;
	}

	private static void OnAsyncCompletion(object state)
	{
		TaskCompletionSource<bool> taskCompletionSource = state as TaskCompletionSource<bool>;
		taskCompletionSource.TrySetResult(result: true);
	}

	public static IDisposable RunTaskContinuationsOnOurThreads()
	{
		if (SynchronizationContext.Current == ServiceModelSynchronizationContext.Instance)
		{
			return null;
		}
		return new SyncContextScope();
	}

	public static async Task CallActionAsync<TArg>(Action<TArg> action, TArg argument)
	{
		if (!Thread.CurrentThread.IsThreadPoolThread)
		{
			SynchronizationContext.SetSynchronizationContext(null);
			await Task.Yield();
		}
		using (RunTaskContinuationsOnOurThreads())
		{
			action(argument);
		}
	}
}
