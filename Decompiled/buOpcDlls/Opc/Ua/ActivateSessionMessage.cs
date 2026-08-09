using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ActivateSessionMessage : IServiceMessage
{
	public ActivateSessionRequest ActivateSessionRequest;

	public ActivateSessionMessage()
	{
	}

	public ActivateSessionMessage(ActivateSessionRequest ActivateSessionRequest)
	{
		this.ActivateSessionRequest = ActivateSessionRequest;
	}

	public IServiceRequest GetRequest()
	{
		return ActivateSessionRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		ActivateSessionResponse activateSessionResponse = response as ActivateSessionResponse;
		if (activateSessionResponse == null)
		{
			activateSessionResponse = new ActivateSessionResponse();
			activateSessionResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new ActivateSessionResponseMessage(activateSessionResponse);
	}
}
