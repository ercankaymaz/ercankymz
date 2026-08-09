using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GetEndpointsMessage : IServiceMessage
{
	public GetEndpointsRequest GetEndpointsRequest;

	public GetEndpointsMessage()
	{
	}

	public GetEndpointsMessage(GetEndpointsRequest GetEndpointsRequest)
	{
		this.GetEndpointsRequest = GetEndpointsRequest;
	}

	public IServiceRequest GetRequest()
	{
		return GetEndpointsRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		GetEndpointsResponse getEndpointsResponse = response as GetEndpointsResponse;
		if (getEndpointsResponse == null)
		{
			getEndpointsResponse = new GetEndpointsResponse();
			getEndpointsResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new GetEndpointsResponseMessage(getEndpointsResponse);
	}
}
