using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal interface IAsyncRequestChannel : IRequestChannel, IChannel, ICommunicationObject, IAsyncCommunicationObject
{
	Task<Message> RequestAsync(Message message);

	Task<Message> RequestAsync(Message message, TimeSpan timeout);
}
