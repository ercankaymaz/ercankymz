using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CallMessage : IServiceMessage
{
	public CallRequest CallRequest;

	public CallMessage()
	{
	}

	public CallMessage(CallRequest CallRequest)
	{
		this.CallRequest = CallRequest;
	}

	public IServiceRequest GetRequest()
	{
		return CallRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		CallResponse callResponse = response as CallResponse;
		if (callResponse == null)
		{
			callResponse = new CallResponse();
			callResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new CallResponseMessage(callResponse);
	}
}
