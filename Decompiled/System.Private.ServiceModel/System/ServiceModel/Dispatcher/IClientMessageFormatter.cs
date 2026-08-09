using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

public interface IClientMessageFormatter
{
	Message SerializeRequest(MessageVersion messageVersion, object[] parameters);

	object DeserializeReply(Message message, object[] parameters);
}
