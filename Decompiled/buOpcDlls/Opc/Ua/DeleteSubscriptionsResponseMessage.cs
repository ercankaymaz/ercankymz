using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteSubscriptionsResponseMessage
{
	public DeleteSubscriptionsResponse DeleteSubscriptionsResponse;

	public DeleteSubscriptionsResponseMessage()
	{
	}

	public DeleteSubscriptionsResponseMessage(DeleteSubscriptionsResponse DeleteSubscriptionsResponse)
	{
		this.DeleteSubscriptionsResponse = DeleteSubscriptionsResponse;
	}

	public DeleteSubscriptionsResponseMessage(ServiceFault ServiceFault)
	{
		DeleteSubscriptionsResponse = new DeleteSubscriptionsResponse();
		if (ServiceFault != null)
		{
			DeleteSubscriptionsResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
