using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IServerBase : IAuditEventCallback
{
	IServiceMessageContext MessageContext { get; }

	ServiceResult ServerError { get; }

	EndpointDescriptionCollection GetEndpoints();

	void ScheduleIncomingRequest(IEndpointIncomingRequest request);
}
