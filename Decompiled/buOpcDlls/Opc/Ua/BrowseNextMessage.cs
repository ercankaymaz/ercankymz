using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BrowseNextMessage : IServiceMessage
{
	public BrowseNextRequest BrowseNextRequest;

	public BrowseNextMessage()
	{
	}

	public BrowseNextMessage(BrowseNextRequest BrowseNextRequest)
	{
		this.BrowseNextRequest = BrowseNextRequest;
	}

	public IServiceRequest GetRequest()
	{
		return BrowseNextRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		BrowseNextResponse browseNextResponse = response as BrowseNextResponse;
		if (browseNextResponse == null)
		{
			browseNextResponse = new BrowseNextResponse();
			browseNextResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new BrowseNextResponseMessage(browseNextResponse);
	}
}
