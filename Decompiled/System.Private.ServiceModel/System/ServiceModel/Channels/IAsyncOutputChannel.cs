using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public interface IAsyncOutputChannel : IOutputChannel, IChannel, ICommunicationObject, IAsyncCommunicationObject
{
	Task SendAsync(Message message);

	Task SendAsync(Message message, TimeSpan timeout);
}
