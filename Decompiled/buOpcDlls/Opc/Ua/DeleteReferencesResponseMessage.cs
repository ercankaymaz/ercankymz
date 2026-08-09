using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteReferencesResponseMessage
{
	public DeleteReferencesResponse DeleteReferencesResponse;

	public DeleteReferencesResponseMessage()
	{
	}

	public DeleteReferencesResponseMessage(DeleteReferencesResponse DeleteReferencesResponse)
	{
		this.DeleteReferencesResponse = DeleteReferencesResponse;
	}

	public DeleteReferencesResponseMessage(ServiceFault ServiceFault)
	{
		DeleteReferencesResponse = new DeleteReferencesResponse();
		if (ServiceFault != null)
		{
			DeleteReferencesResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
