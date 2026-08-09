using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterServer2ResponseMessage
{
	public RegisterServer2Response RegisterServer2Response;

	public RegisterServer2ResponseMessage()
	{
	}

	public RegisterServer2ResponseMessage(RegisterServer2Response RegisterServer2Response)
	{
		this.RegisterServer2Response = RegisterServer2Response;
	}

	public RegisterServer2ResponseMessage(ServiceFault ServiceFault)
	{
		RegisterServer2Response = new RegisterServer2Response();
		if (ServiceFault != null)
		{
			RegisterServer2Response.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
