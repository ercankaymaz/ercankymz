using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OpenSecureChannelResponseMessage
{
	public OpenSecureChannelResponse OpenSecureChannelResponse;

	public OpenSecureChannelResponseMessage()
	{
	}

	public OpenSecureChannelResponseMessage(OpenSecureChannelResponse OpenSecureChannelResponse)
	{
		this.OpenSecureChannelResponse = OpenSecureChannelResponse;
	}

	public OpenSecureChannelResponseMessage(ServiceFault ServiceFault)
	{
		OpenSecureChannelResponse = new OpenSecureChannelResponse();
		if (ServiceFault != null)
		{
			OpenSecureChannelResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
