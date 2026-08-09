using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal interface IClientReliableChannelBinder : IReliableChannelBinder
{
	Uri Via { get; }

	event EventHandler ConnectionLost;

	Task<bool> EnsureChannelForRequestAsync();

	Task<Message> RequestAsync(Message message, TimeSpan timeout);

	Task<Message> RequestAsync(Message message, TimeSpan timeout, MaskingMode maskingMode);
}
