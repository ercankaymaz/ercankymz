using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetTriggeringResponseMessage
{
	public SetTriggeringResponse SetTriggeringResponse;

	public SetTriggeringResponseMessage()
	{
	}

	public SetTriggeringResponseMessage(SetTriggeringResponse SetTriggeringResponse)
	{
		this.SetTriggeringResponse = SetTriggeringResponse;
	}

	public SetTriggeringResponseMessage(ServiceFault ServiceFault)
	{
		SetTriggeringResponse = new SetTriggeringResponse();
		if (ServiceFault != null)
		{
			SetTriggeringResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
