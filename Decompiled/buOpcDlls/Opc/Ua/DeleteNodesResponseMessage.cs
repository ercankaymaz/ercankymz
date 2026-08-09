using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteNodesResponseMessage
{
	public DeleteNodesResponse DeleteNodesResponse;

	public DeleteNodesResponseMessage()
	{
	}

	public DeleteNodesResponseMessage(DeleteNodesResponse DeleteNodesResponse)
	{
		this.DeleteNodesResponse = DeleteNodesResponse;
	}

	public DeleteNodesResponseMessage(ServiceFault ServiceFault)
	{
		DeleteNodesResponse = new DeleteNodesResponse();
		if (ServiceFault != null)
		{
			DeleteNodesResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
