using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishResponseMessage
{
	public PublishResponse PublishResponse;

	public PublishResponseMessage()
	{
	}

	public PublishResponseMessage(PublishResponse PublishResponse)
	{
		this.PublishResponse = PublishResponse;
	}

	public PublishResponseMessage(ServiceFault ServiceFault)
	{
		PublishResponse = new PublishResponse();
		if (ServiceFault != null)
		{
			PublishResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
