using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterNodesResponseMessage
{
	public RegisterNodesResponse RegisterNodesResponse;

	public RegisterNodesResponseMessage()
	{
	}

	public RegisterNodesResponseMessage(RegisterNodesResponse RegisterNodesResponse)
	{
		this.RegisterNodesResponse = RegisterNodesResponse;
	}

	public RegisterNodesResponseMessage(ServiceFault ServiceFault)
	{
		RegisterNodesResponse = new RegisterNodesResponse();
		if (ServiceFault != null)
		{
			RegisterNodesResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
