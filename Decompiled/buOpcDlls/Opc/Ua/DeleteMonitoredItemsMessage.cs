using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteMonitoredItemsMessage : IServiceMessage
{
	public DeleteMonitoredItemsRequest DeleteMonitoredItemsRequest;

	public DeleteMonitoredItemsMessage()
	{
	}

	public DeleteMonitoredItemsMessage(DeleteMonitoredItemsRequest DeleteMonitoredItemsRequest)
	{
		this.DeleteMonitoredItemsRequest = DeleteMonitoredItemsRequest;
	}

	public IServiceRequest GetRequest()
	{
		return DeleteMonitoredItemsRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		DeleteMonitoredItemsResponse deleteMonitoredItemsResponse = response as DeleteMonitoredItemsResponse;
		if (deleteMonitoredItemsResponse == null)
		{
			deleteMonitoredItemsResponse = new DeleteMonitoredItemsResponse();
			deleteMonitoredItemsResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new DeleteMonitoredItemsResponseMessage(deleteMonitoredItemsResponse);
	}
}
