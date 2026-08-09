using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ITransportListenerCallback : IAuditEventCallback
{
	IAsyncResult BeginProcessRequest(string channeId, EndpointDescription endpointDescription, IServiceRequest request, AsyncCallback callback, object callbackData);

	IServiceResponse EndProcessRequest(IAsyncResult result);
}
