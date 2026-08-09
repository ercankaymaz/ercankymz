using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetPublishingModeMessage : IServiceMessage
{
	public SetPublishingModeRequest SetPublishingModeRequest;

	public SetPublishingModeMessage()
	{
	}

	public SetPublishingModeMessage(SetPublishingModeRequest SetPublishingModeRequest)
	{
		this.SetPublishingModeRequest = SetPublishingModeRequest;
	}

	public IServiceRequest GetRequest()
	{
		return SetPublishingModeRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		SetPublishingModeResponse setPublishingModeResponse = response as SetPublishingModeResponse;
		if (setPublishingModeResponse == null)
		{
			setPublishingModeResponse = new SetPublishingModeResponse();
			setPublishingModeResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new SetPublishingModeResponseMessage(setPublishingModeResponse);
	}
}
