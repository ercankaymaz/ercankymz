using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TransferSubscriptionsMessage : IServiceMessage
{
	public TransferSubscriptionsRequest TransferSubscriptionsRequest;

	public TransferSubscriptionsMessage()
	{
	}

	public TransferSubscriptionsMessage(TransferSubscriptionsRequest TransferSubscriptionsRequest)
	{
		this.TransferSubscriptionsRequest = TransferSubscriptionsRequest;
	}

	public IServiceRequest GetRequest()
	{
		return TransferSubscriptionsRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		TransferSubscriptionsResponse transferSubscriptionsResponse = response as TransferSubscriptionsResponse;
		if (transferSubscriptionsResponse == null)
		{
			transferSubscriptionsResponse = new TransferSubscriptionsResponse();
			transferSubscriptionsResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new TransferSubscriptionsResponseMessage(transferSubscriptionsResponse);
	}
}
