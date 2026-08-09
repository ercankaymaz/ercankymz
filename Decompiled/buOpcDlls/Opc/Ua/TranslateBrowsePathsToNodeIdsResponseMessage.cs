using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TranslateBrowsePathsToNodeIdsResponseMessage
{
	public TranslateBrowsePathsToNodeIdsResponse TranslateBrowsePathsToNodeIdsResponse;

	public TranslateBrowsePathsToNodeIdsResponseMessage()
	{
	}

	public TranslateBrowsePathsToNodeIdsResponseMessage(TranslateBrowsePathsToNodeIdsResponse TranslateBrowsePathsToNodeIdsResponse)
	{
		this.TranslateBrowsePathsToNodeIdsResponse = TranslateBrowsePathsToNodeIdsResponse;
	}

	public TranslateBrowsePathsToNodeIdsResponseMessage(ServiceFault ServiceFault)
	{
		TranslateBrowsePathsToNodeIdsResponse = new TranslateBrowsePathsToNodeIdsResponse();
		if (ServiceFault != null)
		{
			TranslateBrowsePathsToNodeIdsResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
