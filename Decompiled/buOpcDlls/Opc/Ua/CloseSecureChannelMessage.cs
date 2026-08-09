using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CloseSecureChannelMessage : IServiceMessage
{
	public CloseSecureChannelRequest CloseSecureChannelRequest;

	public CloseSecureChannelMessage()
	{
	}

	public CloseSecureChannelMessage(CloseSecureChannelRequest CloseSecureChannelRequest)
	{
		this.CloseSecureChannelRequest = CloseSecureChannelRequest;
	}

	public IServiceRequest GetRequest()
	{
		return CloseSecureChannelRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		CloseSecureChannelResponse closeSecureChannelResponse = response as CloseSecureChannelResponse;
		if (closeSecureChannelResponse == null)
		{
			closeSecureChannelResponse = new CloseSecureChannelResponse();
			closeSecureChannelResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new CloseSecureChannelResponseMessage(closeSecureChannelResponse);
	}
}
