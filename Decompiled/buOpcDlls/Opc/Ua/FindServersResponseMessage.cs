using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FindServersResponseMessage
{
	public FindServersResponse FindServersResponse;

	public FindServersResponseMessage()
	{
	}

	public FindServersResponseMessage(FindServersResponse FindServersResponse)
	{
		this.FindServersResponse = FindServersResponse;
	}

	public FindServersResponseMessage(ServiceFault ServiceFault)
	{
		FindServersResponse = new FindServersResponse();
		if (ServiceFault != null)
		{
			FindServersResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
