using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CallResponseMessage
{
	public CallResponse CallResponse;

	public CallResponseMessage()
	{
	}

	public CallResponseMessage(CallResponse CallResponse)
	{
		this.CallResponse = CallResponse;
	}

	public CallResponseMessage(ServiceFault ServiceFault)
	{
		CallResponse = new CallResponse();
		if (ServiceFault != null)
		{
			CallResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
