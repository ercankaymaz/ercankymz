using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateMonitoredItemsResponseMessage
{
	public CreateMonitoredItemsResponse CreateMonitoredItemsResponse;

	public CreateMonitoredItemsResponseMessage()
	{
	}

	public CreateMonitoredItemsResponseMessage(CreateMonitoredItemsResponse CreateMonitoredItemsResponse)
	{
		this.CreateMonitoredItemsResponse = CreateMonitoredItemsResponse;
	}

	public CreateMonitoredItemsResponseMessage(ServiceFault ServiceFault)
	{
		CreateMonitoredItemsResponse = new CreateMonitoredItemsResponse();
		if (ServiceFault != null)
		{
			CreateMonitoredItemsResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
