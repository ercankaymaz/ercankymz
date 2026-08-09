using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddNodesResponseMessage
{
	public AddNodesResponse AddNodesResponse;

	public AddNodesResponseMessage()
	{
	}

	public AddNodesResponseMessage(AddNodesResponse AddNodesResponse)
	{
		this.AddNodesResponse = AddNodesResponse;
	}

	public AddNodesResponseMessage(ServiceFault ServiceFault)
	{
		AddNodesResponse = new AddNodesResponse();
		if (ServiceFault != null)
		{
			AddNodesResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
