using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterServerMessage : IServiceMessage
{
	public RegisterServerRequest RegisterServerRequest;

	public RegisterServerMessage()
	{
	}

	public RegisterServerMessage(RegisterServerRequest RegisterServerRequest)
	{
		this.RegisterServerRequest = RegisterServerRequest;
	}

	public IServiceRequest GetRequest()
	{
		return RegisterServerRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		RegisterServerResponse registerServerResponse = response as RegisterServerResponse;
		if (registerServerResponse == null)
		{
			registerServerResponse = new RegisterServerResponse();
			registerServerResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new RegisterServerResponseMessage(registerServerResponse);
	}
}
