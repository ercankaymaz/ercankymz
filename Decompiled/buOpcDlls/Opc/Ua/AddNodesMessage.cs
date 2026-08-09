using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddNodesMessage : IServiceMessage
{
	public AddNodesRequest AddNodesRequest;

	public AddNodesMessage()
	{
	}

	public AddNodesMessage(AddNodesRequest AddNodesRequest)
	{
		this.AddNodesRequest = AddNodesRequest;
	}

	public IServiceRequest GetRequest()
	{
		return AddNodesRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		AddNodesResponse addNodesResponse = response as AddNodesResponse;
		if (addNodesResponse == null)
		{
			addNodesResponse = new AddNodesResponse();
			addNodesResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new AddNodesResponseMessage(addNodesResponse);
	}
}
