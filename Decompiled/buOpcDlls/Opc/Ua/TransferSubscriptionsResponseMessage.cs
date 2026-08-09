using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TransferSubscriptionsResponseMessage
{
	public TransferSubscriptionsResponse TransferSubscriptionsResponse;

	public TransferSubscriptionsResponseMessage()
	{
	}

	public TransferSubscriptionsResponseMessage(TransferSubscriptionsResponse TransferSubscriptionsResponse)
	{
		this.TransferSubscriptionsResponse = TransferSubscriptionsResponse;
	}

	public TransferSubscriptionsResponseMessage(ServiceFault ServiceFault)
	{
		TransferSubscriptionsResponse = new TransferSubscriptionsResponse();
		if (ServiceFault != null)
		{
			TransferSubscriptionsResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
