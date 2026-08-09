using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IChannelOutgoingRequest
{
	IServiceRequest Request { get; }

	ChannelSendRequestEventHandler Handler { get; }

	void CallSynchronously();

	void OperationCompleted(IServiceResponse response, ServiceResult error);
}
