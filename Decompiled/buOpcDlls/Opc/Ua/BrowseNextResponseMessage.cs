using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BrowseNextResponseMessage
{
	public BrowseNextResponse BrowseNextResponse;

	public BrowseNextResponseMessage()
	{
	}

	public BrowseNextResponseMessage(BrowseNextResponse BrowseNextResponse)
	{
		this.BrowseNextResponse = BrowseNextResponse;
	}

	public BrowseNextResponseMessage(ServiceFault ServiceFault)
	{
		BrowseNextResponse = new BrowseNextResponse();
		if (ServiceFault != null)
		{
			BrowseNextResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
