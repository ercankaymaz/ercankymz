using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CancelMessage : IServiceMessage
{
	public CancelRequest CancelRequest;

	public CancelMessage()
	{
	}

	public CancelMessage(CancelRequest CancelRequest)
	{
		this.CancelRequest = CancelRequest;
	}

	public IServiceRequest GetRequest()
	{
		return CancelRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		CancelResponse cancelResponse = response as CancelResponse;
		if (cancelResponse == null)
		{
			cancelResponse = new CancelResponse();
			cancelResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new CancelResponseMessage(cancelResponse);
	}
}
