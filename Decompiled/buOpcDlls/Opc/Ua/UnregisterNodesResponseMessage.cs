using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class UnregisterNodesResponseMessage
{
	public UnregisterNodesResponse UnregisterNodesResponse;

	public UnregisterNodesResponseMessage()
	{
	}

	public UnregisterNodesResponseMessage(UnregisterNodesResponse UnregisterNodesResponse)
	{
		this.UnregisterNodesResponse = UnregisterNodesResponse;
	}

	public UnregisterNodesResponseMessage(ServiceFault ServiceFault)
	{
		UnregisterNodesResponse = new UnregisterNodesResponse();
		if (ServiceFault != null)
		{
			UnregisterNodesResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
