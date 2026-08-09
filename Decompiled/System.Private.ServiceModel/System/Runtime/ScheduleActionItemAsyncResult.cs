namespace System.Runtime;

internal abstract class ScheduleActionItemAsyncResult : AsyncResult
{
	private static Action<object> s_doWork = DoWork;

	protected ScheduleActionItemAsyncResult(AsyncCallback callback, object state)
		: base(callback, state)
	{
	}

	protected void Schedule()
	{
		ActionItem.Schedule(s_doWork, this);
	}

	private static void DoWork(object state)
	{
		ScheduleActionItemAsyncResult scheduleActionItemAsyncResult = (ScheduleActionItemAsyncResult)state;
		Exception exception = null;
		try
		{
			scheduleActionItemAsyncResult.OnDoWork();
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			exception = ex;
		}
		scheduleActionItemAsyncResult.Complete(completedSynchronously: false, exception);
	}

	protected abstract void OnDoWork();

	public static void End(IAsyncResult result)
	{
		AsyncResult.End<ScheduleActionItemAsyncResult>(result);
	}
}
