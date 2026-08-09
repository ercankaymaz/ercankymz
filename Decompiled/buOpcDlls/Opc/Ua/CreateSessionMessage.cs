using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateSessionMessage : IServiceMessage
{
	public CreateSessionRequest CreateSessionRequest;

	public CreateSessionMessage()
	{
	}

	public CreateSessionMessage(CreateSessionRequest CreateSessionRequest)
	{
		this.CreateSessionRequest = CreateSessionRequest;
	}

	public IServiceRequest GetRequest()
	{
		return CreateSessionRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		CreateSessionResponse createSessionResponse = response as CreateSessionResponse;
		if (createSessionResponse == null)
		{
			createSessionResponse = new CreateSessionResponse();
			createSessionResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new CreateSessionResponseMessage(createSessionResponse);
	}
}
