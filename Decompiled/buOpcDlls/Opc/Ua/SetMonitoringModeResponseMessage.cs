using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetMonitoringModeResponseMessage
{
	public SetMonitoringModeResponse SetMonitoringModeResponse;

	public SetMonitoringModeResponseMessage()
	{
	}

	public SetMonitoringModeResponseMessage(SetMonitoringModeResponse SetMonitoringModeResponse)
	{
		this.SetMonitoringModeResponse = SetMonitoringModeResponse;
	}

	public SetMonitoringModeResponseMessage(ServiceFault ServiceFault)
	{
		SetMonitoringModeResponse = new SetMonitoringModeResponse();
		if (ServiceFault != null)
		{
			SetMonitoringModeResponse.ResponseHeader = ServiceFault.ResponseHeader;
		}
	}
}
