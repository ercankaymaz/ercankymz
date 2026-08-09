using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BrowseMessage : IServiceMessage
{
	public BrowseRequest BrowseRequest;

	public BrowseMessage()
	{
	}

	public BrowseMessage(BrowseRequest BrowseRequest)
	{
		this.BrowseRequest = BrowseRequest;
	}

	public IServiceRequest GetRequest()
	{
		return BrowseRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		BrowseResponse browseResponse = response as BrowseResponse;
		if (browseResponse == null)
		{
			browseResponse = new BrowseResponse();
			browseResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new BrowseResponseMessage(browseResponse);
	}
}
