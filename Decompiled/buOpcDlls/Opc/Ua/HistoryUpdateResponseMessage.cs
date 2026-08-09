using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class HistoryUpdateResponseMessage
{
	public HistoryUpdateResponse HistoryUpdateResponse;

	public HistoryUpdateResponseMessage()
	{
	}

	public HistoryUpdateResponseMessage(HistoryUpdateResponse HistoryUpdateResponse)
	{
		this.HistoryUpdateResponse = HistoryUpdateResponse;
	}

	public HistoryUpdateResponseMessage(ServiceFault ServiceFault)
	{
		HistoryUpdateResponse = new HistoryUpdateResponse();
		if (ServiceFault != null)
		{
			HistoryUpdateResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
