using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public interface IAsyncRequest : IRequestBase
{
	Task SendRequestAsync(Message message, TimeoutHelper timeoutHelper);

	Task<Message> ReceiveReplyAsync(TimeoutHelper timeoutHelper);
}
