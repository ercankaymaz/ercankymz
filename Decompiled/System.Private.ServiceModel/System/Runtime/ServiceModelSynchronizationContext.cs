using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime;

internal class ServiceModelSynchronizationContext : SynchronizationContext
{
	public static ServiceModelSynchronizationContext Instance = new ServiceModelSynchronizationContext();

	public override void Post(SendOrPostCallback d, object state)
	{
		Task.Factory.StartNew(delegate(object s)
		{
			d(s);
		}, state, default(CancellationToken), TaskCreationOptions.RunContinuationsAsynchronously, IOThreadScheduler.IOTaskScheduler);
	}
}
