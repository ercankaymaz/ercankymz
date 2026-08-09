using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CloseSecureChannelResponseMessage
{
	public CloseSecureChannelResponse CloseSecureChannelResponse;

	public CloseSecureChannelResponseMessage()
	{
	}

	public CloseSecureChannelResponseMessage(CloseSecureChannelResponse CloseSecureChannelResponse)
	{
		this.CloseSecureChannelResponse = CloseSecureChannelResponse;
	}

	public CloseSecureChannelResponseMessage(ServiceFault ServiceFault)
	{
		CloseSecureChannelResponse = new CloseSecureChannelResponse();
		if (ServiceFault != null)
		{
			CloseSecureChannelResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
