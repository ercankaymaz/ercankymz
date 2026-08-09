using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetTriggeringMessage : IServiceMessage
{
	public SetTriggeringRequest SetTriggeringRequest;

	public SetTriggeringMessage()
	{
	}

	public SetTriggeringMessage(SetTriggeringRequest SetTriggeringRequest)
	{
		this.SetTriggeringRequest = SetTriggeringRequest;
	}

	public IServiceRequest GetRequest()
	{
		return SetTriggeringRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		SetTriggeringResponse setTriggeringResponse = response as SetTriggeringResponse;
		if (setTriggeringResponse == null)
		{
			setTriggeringResponse = new SetTriggeringResponse();
			setTriggeringResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new SetTriggeringResponseMessage(setTriggeringResponse);
	}
}
