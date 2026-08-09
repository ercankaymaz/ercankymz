using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateSubscriptionMessage : IServiceMessage
{
	public CreateSubscriptionRequest CreateSubscriptionRequest;

	public CreateSubscriptionMessage()
	{
	}

	public CreateSubscriptionMessage(CreateSubscriptionRequest CreateSubscriptionRequest)
	{
		this.CreateSubscriptionRequest = CreateSubscriptionRequest;
	}

	public IServiceRequest GetRequest()
	{
		return CreateSubscriptionRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		CreateSubscriptionResponse createSubscriptionResponse = response as CreateSubscriptionResponse;
		if (createSubscriptionResponse == null)
		{
			createSubscriptionResponse = new CreateSubscriptionResponse();
			createSubscriptionResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new CreateSubscriptionResponseMessage(createSubscriptionResponse);
	}
}
