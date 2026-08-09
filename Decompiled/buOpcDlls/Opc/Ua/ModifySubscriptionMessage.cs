using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ModifySubscriptionMessage : IServiceMessage
{
	public ModifySubscriptionRequest ModifySubscriptionRequest;

	public ModifySubscriptionMessage()
	{
	}

	public ModifySubscriptionMessage(ModifySubscriptionRequest ModifySubscriptionRequest)
	{
		this.ModifySubscriptionRequest = ModifySubscriptionRequest;
	}

	public IServiceRequest GetRequest()
	{
		return ModifySubscriptionRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		ModifySubscriptionResponse modifySubscriptionResponse = response as ModifySubscriptionResponse;
		if (modifySubscriptionResponse == null)
		{
			modifySubscriptionResponse = new ModifySubscriptionResponse();
			modifySubscriptionResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new ModifySubscriptionResponseMessage(modifySubscriptionResponse);
	}
}
