using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class HistoryReadResponseMessage
{
	public HistoryReadResponse HistoryReadResponse;

	public HistoryReadResponseMessage()
	{
	}

	public HistoryReadResponseMessage(HistoryReadResponse HistoryReadResponse)
	{
		this.HistoryReadResponse = HistoryReadResponse;
	}

	public HistoryReadResponseMessage(ServiceFault ServiceFault)
	{
		HistoryReadResponse = new HistoryReadResponse();
		if (ServiceFault != null)
		{
			HistoryReadResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
