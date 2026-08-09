using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class WriteResponseMessage
{
	public WriteResponse WriteResponse;

	public WriteResponseMessage()
	{
	}

	public WriteResponseMessage(WriteResponse WriteResponse)
	{
		this.WriteResponse = WriteResponse;
	}

	public WriteResponseMessage(ServiceFault ServiceFault)
	{
		WriteResponse = new WriteResponse();
		if (ServiceFault != null)
		{
			WriteResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
