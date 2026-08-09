using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GetEndpointsResponseMessage
{
	public GetEndpointsResponse GetEndpointsResponse;

	public GetEndpointsResponseMessage()
	{
	}

	public GetEndpointsResponseMessage(GetEndpointsResponse GetEndpointsResponse)
	{
		this.GetEndpointsResponse = GetEndpointsResponse;
	}

	public GetEndpointsResponseMessage(ServiceFault ServiceFault)
	{
		GetEndpointsResponse = new GetEndpointsResponse();
		if (ServiceFault != null)
		{
			GetEndpointsResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
