using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IEndpointIncomingRequest
{
	IServiceRequest Request { get; }

	SecureChannelContext SecureChannelContext { get; }

	object Calldata { get; set; }

	void CallSynchronously();

	void OperationCompleted(IServiceResponse response, ServiceResult error);
}
