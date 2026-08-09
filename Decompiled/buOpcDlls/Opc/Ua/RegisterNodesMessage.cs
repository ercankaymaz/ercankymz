using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterNodesMessage : IServiceMessage
{
	public RegisterNodesRequest RegisterNodesRequest;

	public RegisterNodesMessage()
	{
	}

	public RegisterNodesMessage(RegisterNodesRequest RegisterNodesRequest)
	{
		this.RegisterNodesRequest = RegisterNodesRequest;
	}

	public IServiceRequest GetRequest()
	{
		return RegisterNodesRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		RegisterNodesResponse registerNodesResponse = response as RegisterNodesResponse;
		if (registerNodesResponse == null)
		{
			registerNodesResponse = new RegisterNodesResponse();
			registerNodesResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new RegisterNodesResponseMessage(registerNodesResponse);
	}
}
