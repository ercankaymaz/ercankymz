using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateMonitoredItemsMessage : IServiceMessage
{
	public CreateMonitoredItemsRequest CreateMonitoredItemsRequest;

	public CreateMonitoredItemsMessage()
	{
	}

	public CreateMonitoredItemsMessage(CreateMonitoredItemsRequest CreateMonitoredItemsRequest)
	{
		this.CreateMonitoredItemsRequest = CreateMonitoredItemsRequest;
	}

	public IServiceRequest GetRequest()
	{
		return CreateMonitoredItemsRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		CreateMonitoredItemsResponse createMonitoredItemsResponse = response as CreateMonitoredItemsResponse;
		if (createMonitoredItemsResponse == null)
		{
			createMonitoredItemsResponse = new CreateMonitoredItemsResponse();
			createMonitoredItemsResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new CreateMonitoredItemsResponseMessage(createMonitoredItemsResponse);
	}
}
