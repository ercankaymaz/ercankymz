using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IEndpointBase
{
	IAsyncResult BeginInvokeService(InvokeServiceMessage request, AsyncCallback callback, object asyncState);

	InvokeServiceResponseMessage EndInvokeService(IAsyncResult result);
}
