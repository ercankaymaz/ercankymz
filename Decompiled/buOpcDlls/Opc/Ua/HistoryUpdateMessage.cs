using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class HistoryUpdateMessage : IServiceMessage
{
	public HistoryUpdateRequest HistoryUpdateRequest;

	public HistoryUpdateMessage()
	{
	}

	public HistoryUpdateMessage(HistoryUpdateRequest HistoryUpdateRequest)
	{
		this.HistoryUpdateRequest = HistoryUpdateRequest;
	}

	public IServiceRequest GetRequest()
	{
		return HistoryUpdateRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		HistoryUpdateResponse historyUpdateResponse = response as HistoryUpdateResponse;
		if (historyUpdateResponse == null)
		{
			historyUpdateResponse = new HistoryUpdateResponse();
			historyUpdateResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new HistoryUpdateResponseMessage(historyUpdateResponse);
	}
}
