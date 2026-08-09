using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddReferencesResponseMessage
{
	public AddReferencesResponse AddReferencesResponse;

	public AddReferencesResponseMessage()
	{
	}

	public AddReferencesResponseMessage(AddReferencesResponse AddReferencesResponse)
	{
		this.AddReferencesResponse = AddReferencesResponse;
	}

	public AddReferencesResponseMessage(ServiceFault ServiceFault)
	{
		AddReferencesResponse = new AddReferencesResponse();
		if (ServiceFault != null)
		{
			AddReferencesResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
