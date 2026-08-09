using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ModifyMonitoredItemsMessage : IServiceMessage
{
	public ModifyMonitoredItemsRequest ModifyMonitoredItemsRequest;

	public ModifyMonitoredItemsMessage()
	{
	}

	public ModifyMonitoredItemsMessage(ModifyMonitoredItemsRequest ModifyMonitoredItemsRequest)
	{
		this.ModifyMonitoredItemsRequest = ModifyMonitoredItemsRequest;
	}

	public IServiceRequest GetRequest()
	{
		return ModifyMonitoredItemsRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		ModifyMonitoredItemsResponse modifyMonitoredItemsResponse = response as ModifyMonitoredItemsResponse;
		if (modifyMonitoredItemsResponse == null)
		{
			modifyMonitoredItemsResponse = new ModifyMonitoredItemsResponse();
			modifyMonitoredItemsResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new ModifyMonitoredItemsResponseMessage(modifyMonitoredItemsResponse);
	}
}
