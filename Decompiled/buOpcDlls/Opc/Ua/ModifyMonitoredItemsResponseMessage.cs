using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ModifyMonitoredItemsResponseMessage
{
	public ModifyMonitoredItemsResponse ModifyMonitoredItemsResponse;

	public ModifyMonitoredItemsResponseMessage()
	{
	}

	public ModifyMonitoredItemsResponseMessage(ModifyMonitoredItemsResponse ModifyMonitoredItemsResponse)
	{
		this.ModifyMonitoredItemsResponse = ModifyMonitoredItemsResponse;
	}

	public ModifyMonitoredItemsResponseMessage(ServiceFault ServiceFault)
	{
		ModifyMonitoredItemsResponse = new ModifyMonitoredItemsResponse();
		if (ServiceFault != null)
		{
			ModifyMonitoredItemsResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
