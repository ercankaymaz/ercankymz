using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ModifySubscriptionResponseMessage
{
	public ModifySubscriptionResponse ModifySubscriptionResponse;

	public ModifySubscriptionResponseMessage()
	{
	}

	public ModifySubscriptionResponseMessage(ModifySubscriptionResponse ModifySubscriptionResponse)
	{
		this.ModifySubscriptionResponse = ModifySubscriptionResponse;
	}

	public ModifySubscriptionResponseMessage(ServiceFault ServiceFault)
	{
		ModifySubscriptionResponse = new ModifySubscriptionResponse();
		if (ServiceFault != null)
		{
			ModifySubscriptionResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
