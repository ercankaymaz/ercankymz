using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BrowseResponseMessage
{
	public BrowseResponse BrowseResponse;

	public BrowseResponseMessage()
	{
	}

	public BrowseResponseMessage(BrowseResponse BrowseResponse)
	{
		this.BrowseResponse = BrowseResponse;
	}

	public BrowseResponseMessage(ServiceFault ServiceFault)
	{
		BrowseResponse = new BrowseResponse();
		if (ServiceFault != null)
		{
			BrowseResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
