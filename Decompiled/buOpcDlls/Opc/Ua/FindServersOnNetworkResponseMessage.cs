using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FindServersOnNetworkResponseMessage
{
	public FindServersOnNetworkResponse FindServersOnNetworkResponse;

	public FindServersOnNetworkResponseMessage()
	{
	}

	public FindServersOnNetworkResponseMessage(FindServersOnNetworkResponse FindServersOnNetworkResponse)
	{
		this.FindServersOnNetworkResponse = FindServersOnNetworkResponse;
	}

	public FindServersOnNetworkResponseMessage(ServiceFault ServiceFault)
	{
		FindServersOnNetworkResponse = new FindServersOnNetworkResponse();
		if (ServiceFault != null)
		{
			FindServersOnNetworkResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
