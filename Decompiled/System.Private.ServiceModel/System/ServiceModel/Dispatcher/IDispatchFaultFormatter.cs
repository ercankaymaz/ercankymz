using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal interface IDispatchFaultFormatter
{
	MessageFault Serialize(FaultException faultException, out string action);
}
