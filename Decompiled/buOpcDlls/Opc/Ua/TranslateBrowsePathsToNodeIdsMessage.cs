using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TranslateBrowsePathsToNodeIdsMessage : IServiceMessage
{
	public TranslateBrowsePathsToNodeIdsRequest TranslateBrowsePathsToNodeIdsRequest;

	public TranslateBrowsePathsToNodeIdsMessage()
	{
	}

	public TranslateBrowsePathsToNodeIdsMessage(TranslateBrowsePathsToNodeIdsRequest TranslateBrowsePathsToNodeIdsRequest)
	{
		this.TranslateBrowsePathsToNodeIdsRequest = TranslateBrowsePathsToNodeIdsRequest;
	}

	public IServiceRequest GetRequest()
	{
		return TranslateBrowsePathsToNodeIdsRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		TranslateBrowsePathsToNodeIdsResponse translateBrowsePathsToNodeIdsResponse = response as TranslateBrowsePathsToNodeIdsResponse;
		if (translateBrowsePathsToNodeIdsResponse == null)
		{
			translateBrowsePathsToNodeIdsResponse = new TranslateBrowsePathsToNodeIdsResponse();
			translateBrowsePathsToNodeIdsResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new TranslateBrowsePathsToNodeIdsResponseMessage(translateBrowsePathsToNodeIdsResponse);
	}
}
