using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteMonitoredItemsResponseMessage
{
	public DeleteMonitoredItemsResponse DeleteMonitoredItemsResponse;

	public DeleteMonitoredItemsResponseMessage()
	{
	}

	public DeleteMonitoredItemsResponseMessage(DeleteMonitoredItemsResponse DeleteMonitoredItemsResponse)
	{
		this.DeleteMonitoredItemsResponse = DeleteMonitoredItemsResponse;
	}

	public DeleteMonitoredItemsResponseMessage(ServiceFault ServiceFault)
	{
		DeleteMonitoredItemsResponse = new DeleteMonitoredItemsResponse();
		if (ServiceFault != null)
		{
			DeleteMonitoredItemsResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
