using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteSubscriptionsMessage : IServiceMessage
{
	public DeleteSubscriptionsRequest DeleteSubscriptionsRequest;

	public DeleteSubscriptionsMessage()
	{
	}

	public DeleteSubscriptionsMessage(DeleteSubscriptionsRequest DeleteSubscriptionsRequest)
	{
		this.DeleteSubscriptionsRequest = DeleteSubscriptionsRequest;
	}

	public IServiceRequest GetRequest()
	{
		return DeleteSubscriptionsRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		DeleteSubscriptionsResponse deleteSubscriptionsResponse = response as DeleteSubscriptionsResponse;
		if (deleteSubscriptionsResponse == null)
		{
			deleteSubscriptionsResponse = new DeleteSubscriptionsResponse();
			deleteSubscriptionsResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new DeleteSubscriptionsResponseMessage(deleteSubscriptionsResponse);
	}
}
