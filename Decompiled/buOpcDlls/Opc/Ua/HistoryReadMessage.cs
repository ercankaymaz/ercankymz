using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class HistoryReadMessage : IServiceMessage
{
	public HistoryReadRequest HistoryReadRequest;

	public HistoryReadMessage()
	{
	}

	public HistoryReadMessage(HistoryReadRequest HistoryReadRequest)
	{
		this.HistoryReadRequest = HistoryReadRequest;
	}

	public IServiceRequest GetRequest()
	{
		return HistoryReadRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		HistoryReadResponse historyReadResponse = response as HistoryReadResponse;
		if (historyReadResponse == null)
		{
			historyReadResponse = new HistoryReadResponse();
			historyReadResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new HistoryReadResponseMessage(historyReadResponse);
	}
}
