using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct DefaultTaskSchedulerAwaiter : INotifyCompletion
{
	public static DefaultTaskSchedulerAwaiter Singleton;

	public bool IsCompleted
	{
		get
		{
			if (TaskScheduler.Current == TaskScheduler.Default)
			{
				if (SynchronizationContext.Current != null)
				{
					return SynchronizationContext.Current.GetType() == typeof(SynchronizationContext);
				}
				return true;
			}
			return false;
		}
	}

	public void OnCompleted(Action continuation)
	{
		Task.Run(continuation);
	}

	public void GetResult()
	{
	}

	public DefaultTaskSchedulerAwaiter GetAwaiter()
	{
		return this;
	}
}
