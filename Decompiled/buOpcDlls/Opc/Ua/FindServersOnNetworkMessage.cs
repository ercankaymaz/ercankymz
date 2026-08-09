using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FindServersOnNetworkMessage : IServiceMessage
{
	public FindServersOnNetworkRequest FindServersOnNetworkRequest;

	public FindServersOnNetworkMessage()
	{
	}

	public FindServersOnNetworkMessage(FindServersOnNetworkRequest FindServersOnNetworkRequest)
	{
		this.FindServersOnNetworkRequest = FindServersOnNetworkRequest;
	}

	public IServiceRequest GetRequest()
	{
		return FindServersOnNetworkRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		FindServersOnNetworkResponse findServersOnNetworkResponse = response as FindServersOnNetworkResponse;
		if (findServersOnNetworkResponse == null)
		{
			findServersOnNetworkResponse = new FindServersOnNetworkResponse();
			findServersOnNetworkResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new FindServersOnNetworkResponseMessage(findServersOnNetworkResponse);
	}
}
