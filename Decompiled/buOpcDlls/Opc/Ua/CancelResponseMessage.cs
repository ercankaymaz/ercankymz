using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CancelResponseMessage
{
	public CancelResponse CancelResponse;

	public CancelResponseMessage()
	{
	}

	public CancelResponseMessage(CancelResponse CancelResponse)
	{
		this.CancelResponse = CancelResponse;
	}

	public CancelResponseMessage(ServiceFault ServiceFault)
	{
		CancelResponse = new CancelResponse();
		if (ServiceFault != null)
		{
			CancelResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
