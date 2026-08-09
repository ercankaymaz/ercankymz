using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RepublishResponseMessage
{
	public RepublishResponse RepublishResponse;

	public RepublishResponseMessage()
	{
	}

	public RepublishResponseMessage(RepublishResponse RepublishResponse)
	{
		this.RepublishResponse = RepublishResponse;
	}

	public RepublishResponseMessage(ServiceFault ServiceFault)
	{
		RepublishResponse = new RepublishResponse();
		if (ServiceFault != null)
		{
			RepublishResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
