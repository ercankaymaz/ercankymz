using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetMonitoringModeMessage : IServiceMessage
{
	public SetMonitoringModeRequest SetMonitoringModeRequest;

	public SetMonitoringModeMessage()
	{
	}

	public SetMonitoringModeMessage(SetMonitoringModeRequest SetMonitoringModeRequest)
	{
		this.SetMonitoringModeRequest = SetMonitoringModeRequest;
	}

	public IServiceRequest GetRequest()
	{
		return SetMonitoringModeRequest;
	}

	public object CreateResponse(IServiceResponse response)
	{
		SetMonitoringModeResponse setMonitoringModeResponse = response as SetMonitoringModeResponse;
		if (setMonitoringModeResponse == null)
		{
			setMonitoringModeResponse = new SetMonitoringModeResponse();
			setMonitoringModeResponse.ResponseHeader = ((ServiceFault)response).ResponseHeader;
		}
		return new SetMonitoringModeResponseMessage(setMonitoringModeResponse);
	}
}
