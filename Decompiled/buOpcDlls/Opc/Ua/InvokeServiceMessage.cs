using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class InvokeServiceMessage
{
	public byte[] InvokeServiceRequest;

	public InvokeServiceMessage()
	{
	}

	public InvokeServiceMessage(byte[] InvokeServiceRequest)
	{
		this.InvokeServiceRequest = InvokeServiceRequest;
	}
}
