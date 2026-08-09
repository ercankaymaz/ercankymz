using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

public interface IInstanceContextProvider
{
	InstanceContext GetExistingInstanceContext(Message message, IContextChannel channel);
}
