using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CloseSessionMessage : IServiceMessage
{
	public CloseSessionRequest CloseSessionRequest;

	public CloseSessionMessage()
	{
	}

	public CloseSessionMessage(CloseSessionRequest CloseSessionRequest)
	{
		this.CloseSessionRequest = CloseSessionRequest;
	}

	public IServiceRequest GetRequest()
	{
		return CloseSessionRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		CloseSessionResponse closeSessionResponse = response as CloseSessionResponse;
		if (closeSessionResponse == null)
		{
			closeSessionResponse = new CloseSessionResponse();
			closeSessionResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new CloseSessionResponseMessage(closeSessionResponse);
	}
}
