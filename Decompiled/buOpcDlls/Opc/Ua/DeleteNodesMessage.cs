using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteNodesMessage : IServiceMessage
{
	public DeleteNodesRequest DeleteNodesRequest;

	public DeleteNodesMessage()
	{
	}

	public DeleteNodesMessage(DeleteNodesRequest DeleteNodesRequest)
	{
		this.DeleteNodesRequest = DeleteNodesRequest;
	}

	public IServiceRequest GetRequest()
	{
		return DeleteNodesRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		DeleteNodesResponse deleteNodesResponse = response as DeleteNodesResponse;
		if (deleteNodesResponse == null)
		{
			deleteNodesResponse = new DeleteNodesResponse();
			deleteNodesResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new DeleteNodesResponseMessage(deleteNodesResponse);
	}
}
