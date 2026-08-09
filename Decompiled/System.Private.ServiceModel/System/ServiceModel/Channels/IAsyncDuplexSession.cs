using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal interface IAsyncDuplexSession : IInputSession, ISession, IOutputSession
{
	Task CloseOutputSessionAsync();

	Task CloseOutputSessionAsync(TimeSpan timeout);
}
