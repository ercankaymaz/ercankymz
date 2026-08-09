using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CloseSessionResponseMessage
{
	public CloseSessionResponse CloseSessionResponse;

	public CloseSessionResponseMessage()
	{
	}

	public CloseSessionResponseMessage(CloseSessionResponse CloseSessionResponse)
	{
		this.CloseSessionResponse = CloseSessionResponse;
	}

	public CloseSessionResponseMessage(ServiceFault ServiceFault)
	{
		CloseSessionResponse = new CloseSessionResponse();
		if (ServiceFault != null)
		{
			CloseSessionResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
