using System.Threading.Tasks;

namespace System.ServiceModel;

public interface IAsyncCommunicationObject : ICommunicationObject
{
	Task CloseAsync(TimeSpan timeout);

	Task OpenAsync(TimeSpan timeout);
}
