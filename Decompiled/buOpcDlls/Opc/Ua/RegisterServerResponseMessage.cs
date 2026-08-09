using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterServerResponseMessage
{
	public RegisterServerResponse RegisterServerResponse;

	public RegisterServerResponseMessage()
	{
	}

	public RegisterServerResponseMessage(RegisterServerResponse RegisterServerResponse)
	{
		this.RegisterServerResponse = RegisterServerResponse;
	}

	public RegisterServerResponseMessage(ServiceFault ServiceFault)
	{
		RegisterServerResponse = new RegisterServerResponse();
		if (ServiceFault != null)
		{
			RegisterServerResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
