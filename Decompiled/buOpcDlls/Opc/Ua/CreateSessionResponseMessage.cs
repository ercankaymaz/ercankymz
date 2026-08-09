using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateSessionResponseMessage
{
	public CreateSessionResponse CreateSessionResponse;

	public CreateSessionResponseMessage()
	{
	}

	public CreateSessionResponseMessage(CreateSessionResponse CreateSessionResponse)
	{
		this.CreateSessionResponse = CreateSessionResponse;
	}

	public CreateSessionResponseMessage(ServiceFault ServiceFault)
	{
		CreateSessionResponse = new CreateSessionResponse();
		if (ServiceFault != null)
		{
			CreateSessionResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
