using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class InvokeServiceResponseMessage
{
	public byte[] InvokeServiceResponse;

	public InvokeServiceResponseMessage()
	{
	}

	public InvokeServiceResponseMessage(byte[] InvokeServiceResponse)
	{
		this.InvokeServiceResponse = InvokeServiceResponse;
	}
}
