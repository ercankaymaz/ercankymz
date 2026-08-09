using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public interface IAsyncInputChannel : IInputChannel, IChannel, ICommunicationObject, IAsyncCommunicationObject
{
	Task<Message> ReceiveAsync();

	Task<Message> ReceiveAsync(TimeSpan timeout);

	Task<(bool, Message)> TryReceiveAsync(TimeSpan timeout);

	Task<bool> WaitForMessageAsync(TimeSpan timeout);
}
