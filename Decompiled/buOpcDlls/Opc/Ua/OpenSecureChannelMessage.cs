using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OpenSecureChannelMessage : IServiceMessage
{
	public OpenSecureChannelRequest OpenSecureChannelRequest;

	public OpenSecureChannelMessage()
	{
	}

	public OpenSecureChannelMessage(OpenSecureChannelRequest OpenSecureChannelRequest)
	{
		this.OpenSecureChannelRequest = OpenSecureChannelRequest;
	}

	public IServiceRequest GetRequest()
	{
		return OpenSecureChannelRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		OpenSecureChannelResponse openSecureChannelResponse = response as OpenSecureChannelResponse;
		if (openSecureChannelResponse == null)
		{
			openSecureChannelResponse = new OpenSecureChannelResponse();
			openSecureChannelResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new OpenSecureChannelResponseMessage(openSecureChannelResponse);
	}
}
