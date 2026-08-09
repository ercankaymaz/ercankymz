using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FindServersMessage : IServiceMessage
{
	public FindServersRequest FindServersRequest;

	public FindServersMessage()
	{
	}

	public FindServersMessage(FindServersRequest FindServersRequest)
	{
		this.FindServersRequest = FindServersRequest;
	}

	public IServiceRequest GetRequest()
	{
		return FindServersRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		FindServersResponse findServersResponse = response as FindServersResponse;
		if (findServersResponse == null)
		{
			findServersResponse = new FindServersResponse();
			findServersResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new FindServersResponseMessage(findServersResponse);
	}
}
