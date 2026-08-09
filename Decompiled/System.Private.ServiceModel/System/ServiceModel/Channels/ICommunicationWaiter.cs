using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal interface ICommunicationWaiter : IDisposable
{
	void Signal();

	Task<CommunicationWaitResult> WaitAsync(TimeSpan timeout, bool aborting);

	CommunicationWaitResult Wait(TimeSpan timeout, bool aborting);
}
