using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddReferencesMessage : IServiceMessage
{
	public AddReferencesRequest AddReferencesRequest;

	public AddReferencesMessage()
	{
	}

	public AddReferencesMessage(AddReferencesRequest AddReferencesRequest)
	{
		this.AddReferencesRequest = AddReferencesRequest;
	}

	public IServiceRequest GetRequest()
	{
		return AddReferencesRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		AddReferencesResponse addReferencesResponse = response as AddReferencesResponse;
		if (addReferencesResponse == null)
		{
			addReferencesResponse = new AddReferencesResponse();
			addReferencesResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new AddReferencesResponseMessage(addReferencesResponse);
	}
}
