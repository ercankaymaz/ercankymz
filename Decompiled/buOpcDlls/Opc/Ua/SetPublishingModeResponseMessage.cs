using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetPublishingModeResponseMessage
{
	public SetPublishingModeResponse SetPublishingModeResponse;

	public SetPublishingModeResponseMessage()
	{
	}

	public SetPublishingModeResponseMessage(SetPublishingModeResponse SetPublishingModeResponse)
	{
		this.SetPublishingModeResponse = SetPublishingModeResponse;
	}

	public SetPublishingModeResponseMessage(ServiceFault ServiceFault)
	{
		SetPublishingModeResponse = new SetPublishingModeResponse();
		if (ServiceFault != null)
		{
			SetPublishingModeResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
