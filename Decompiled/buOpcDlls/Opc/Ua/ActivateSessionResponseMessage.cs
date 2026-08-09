using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ActivateSessionResponseMessage
{
	public ActivateSessionResponse ActivateSessionResponse;

	public ActivateSessionResponseMessage()
	{
	}

	public ActivateSessionResponseMessage(ActivateSessionResponse ActivateSessionResponse)
	{
		this.ActivateSessionResponse = ActivateSessionResponse;
	}

	public ActivateSessionResponseMessage(ServiceFault ServiceFault)
	{
		ActivateSessionResponse = new ActivateSessionResponse();
		if (ServiceFault != null)
		{
			ActivateSessionResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
