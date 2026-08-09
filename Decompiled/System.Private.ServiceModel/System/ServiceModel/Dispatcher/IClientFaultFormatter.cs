using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal interface IClientFaultFormatter
{
	FaultException Deserialize(MessageFault messageFault, string action);
}
