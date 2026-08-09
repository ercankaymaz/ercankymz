using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateSubscriptionResponseMessage
{
	public CreateSubscriptionResponse CreateSubscriptionResponse;

	public CreateSubscriptionResponseMessage()
	{
	}

	public CreateSubscriptionResponseMessage(CreateSubscriptionResponse CreateSubscriptionResponse)
	{
		this.CreateSubscriptionResponse = CreateSubscriptionResponse;
	}

	public CreateSubscriptionResponseMessage(ServiceFault ServiceFault)
	{
		CreateSubscriptionResponse = new CreateSubscriptionResponse();
		if (ServiceFault != null)
		{
			CreateSubscriptionResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
