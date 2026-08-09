using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class UnregisterNodesMessage : IServiceMessage
{
	public UnregisterNodesRequest UnregisterNodesRequest;

	public UnregisterNodesMessage()
	{
	}

	public UnregisterNodesMessage(UnregisterNodesRequest UnregisterNodesRequest)
	{
		this.UnregisterNodesRequest = UnregisterNodesRequest;
	}

	public IServiceRequest GetRequest()
	{
		return UnregisterNodesRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		UnregisterNodesResponse unregisterNodesResponse = response as UnregisterNodesResponse;
		if (unregisterNodesResponse == null)
		{
			unregisterNodesResponse = new UnregisterNodesResponse();
			unregisterNodesResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new UnregisterNodesResponseMessage(unregisterNodesResponse);
	}
}
