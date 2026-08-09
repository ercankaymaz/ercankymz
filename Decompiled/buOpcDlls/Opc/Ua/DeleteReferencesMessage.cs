using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteReferencesMessage : IServiceMessage
{
	public DeleteReferencesRequest DeleteReferencesRequest;

	public DeleteReferencesMessage()
	{
	}

	public DeleteReferencesMessage(DeleteReferencesRequest DeleteReferencesRequest)
	{
		this.DeleteReferencesRequest = DeleteReferencesRequest;
	}

	public IServiceRequest GetRequest()
	{
		return DeleteReferencesRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		DeleteReferencesResponse deleteReferencesResponse = response as DeleteReferencesResponse;
		if (deleteReferencesResponse == null)
		{
			deleteReferencesResponse = new DeleteReferencesResponse();
			deleteReferencesResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new DeleteReferencesResponseMessage(deleteReferencesResponse);
	}
}
