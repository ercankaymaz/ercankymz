using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ReadResponseMessage
{
	public ReadResponse ReadResponse;

	public ReadResponseMessage()
	{
	}

	public ReadResponseMessage(ReadResponse ReadResponse)
	{
		this.ReadResponse = ReadResponse;
	}

	public ReadResponseMessage(ServiceFault ServiceFault)
	{
		ReadResponse = new ReadResponse();
		if (ServiceFault != null)
		{
			ReadResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
